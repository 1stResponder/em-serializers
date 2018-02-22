// ———————————————————————–
// <copyright file="MessageManager.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// ———————————————————————–

using EDXLSharp.EDXLDELib;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ThreadSafeBlockingQ;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// Class to define a MessageManager
  /// </summary>
  public class MessageManager
  {
    #region Private Member Variables

    /// <summary>
    /// Settings container for TestApp
    /// </summary>
    private TestAppSettings settings;

    /// <summary>
    /// Blocking send queue
    /// </summary>
    private BlockingQueue<EDXLDE> sendQ;

    /// <summary>
    /// Blocking receiver queue
    /// </summary>
    private BlockingQueue<NameObject<string, EDXLDE>> recvQ;

    /// <summary>
    /// Bit to enable message sending
    /// </summary>
    private bool sendEnabled;

    /// <summary>
    /// Bit to enable message receiving
    /// </summary>
    private bool recvEnabled;

    /// <summary>
    /// Threads for sending, receiving, and listening
    /// </summary>
    private Thread sendThr, recvThr, listenThr;

    /// <summary>
    /// UDP send and and receive clients
    /// </summary>
    private UdpClient udpSendClient, udpRecieveClient;

    /// <summary>
    /// Define a TCP Socket
    /// </summary>
    private Socket tcpSocket;

    /// <summary>
    /// Define UDP and TCP endpoints
    /// </summary>
    private IPEndPoint udpPublishEndPoint, udpSubscribeEndPoint, tcpPublishEndPoint;

    /// <summary>
    /// Define asynchronous callback for UDP receiver
    /// </summary>
    private AsyncCallback udpRecieveCallback;

    /// <summary>
    /// Define method to handle received UDP messages
    /// </summary>
    private RecieveMessageCallback messageReceived;

    /// <summary>
    /// Define the TCP receiver
    /// </summary>
    private Receiver tcpReciever;

    /// <summary>
    /// String to describe UDP queues
    /// </summary>
    private string udpString = string.Empty;

    /// <summary>
    /// String to describe TCP queues
    /// </summary>
    private string tcpString = string.Empty;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the MessageManager class
    /// Default Constructors
    /// </summary>
    public MessageManager()
    {
      this.sendQ = new BlockingQueue<EDXLDE>();
      this.recvQ = new BlockingQueue<NameObject<string, EDXLDE>>();
      this.sendEnabled = false;
      this.recvEnabled = false;
      this.tcpReciever = new Receiver();
      this.sendThr = new Thread(new ThreadStart(this.SendQThr));
      this.recvThr = new Thread(new ThreadStart(this.RecvQThr));
    }

    /// <summary>
    /// Initializes a new instance of the MessageManager class
    /// Constructor That Will Take Pointer To Settings Object
    /// </summary>
    /// <param name="msettings">Pointer to Settings Object</param>
    public MessageManager(TestAppSettings msettings)
    {
      this.settings = msettings;
      this.sendQ = new BlockingQueue<EDXLDE>();
      this.recvQ = new BlockingQueue<NameObject<string, EDXLDE>>();
      this.sendEnabled = true;
      this.recvEnabled = true;
      this.tcpReciever = new Receiver(this.settings.TCPListenPort);
      this.sendThr = new Thread(new ThreadStart(this.SendQThr));
    }
    #endregion

    #region Public Events
    /// <summary>
    /// Message Receiver callback
    /// </summary>
    public delegate void RecieveMessageCallback();
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Subscribe to this Delegate Callback to be notified when a new message is Received
    /// </summary>
    public RecieveMessageCallback MessageReceived
    {
      get { return this.messageReceived; }
      set { this.messageReceived = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Queue of Received Messages
    /// </summary>
    public BlockingQueue<NameObject<string, EDXLDE>> RecieveQueue
    {
      get { return this.recvQ; }
      set { this.recvQ = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Places an EDXL-DE Message In Queue To Be Sent
    /// </summary>
    /// <param name="message">EDXL Message To Send</param>
    public void Send(EDXLDE message)
    {
      this.sendQ.EnQueue(message);
    }

    /// <summary>
    /// Starts the Appropriate Send and Receive Threads and Callbacks
    /// </summary>
    public void Start()
    {
      this.sendThr.Start();
      this.StartRecv();
    }

    /// <summary>
    /// Aborts All Threads and Closes Open Listeners and Sockets
    /// </summary>
    public void Close()
    {
      this.sendEnabled = false;
      this.recvEnabled = false;
      if (this.sendThr != null)
      {
        try
        {
          this.sendThr.Abort();
          while (this.sendThr.IsAlive)
          {
            ThreadState mT = this.sendThr.ThreadState;
          }
        }
        catch (Exception ex)
        {
          ex.Message.ToString();
        }
      }

      if (this.recvThr != null)
      {
        this.tcpReciever.Close();
        this.recvThr.Abort();
        while (this.recvThr.IsAlive)
        {
          ThreadState mT = this.recvThr.ThreadState;
        }
      }

      if (this.listenThr != null)
      {
        this.listenThr.Abort();
        while (this.listenThr.IsAlive)
        {
          ThreadState mT = this.listenThr.ThreadState;
        }
      }

      if (this.udpRecieveClient != null)
      {
        this.udpRecieveClient.Close();
        while (this.udpRecieveClient.Client != null)
        {
          if (true) 
          {
          }
        }
      }
    }

    #endregion

    #region Private Member Functions

    /// <summary>
    /// Closes The UDP Connection
    /// </summary>
    public void EndUDPListen()
    {
      this.udpRecieveClient.Close();
    }

    /// <summary>
    /// Starts The Receive Threads
    /// </summary>
    private void StartRecv()
    {
      this.recvEnabled = true;
      this.BeginUDPListen();
      this.BeginTCPListen();
    }

    #region UDP Functions

    /// <summary>
    /// Begins Listening On Specified Port for UDP Messages
    /// </summary>
    private void BeginUDPListen()
    {
      this.udpString = "UDP:" + this.settings.UDPListenPort;
      if (this.messageReceived == null)
      {
        throw new NullReferenceException("UDP Message Recieve Callback Can't Be Null!\nPlease Subscribe To This Delegate For Message Callback!");
      }

      this.udpSubscribeEndPoint = new IPEndPoint(IPAddress.Any, this.settings.UDPListenPort);
      this.udpRecieveClient = new UdpClient(this.udpSubscribeEndPoint);
      this.udpRecieveCallback = new AsyncCallback(this.EndUDPRecieve);
      this.udpRecieveClient.BeginReceive(this.udpRecieveCallback, this.udpRecieveClient);
    }

    /// <summary>
    /// Get's The Binary Data From A Received UDP Message
    /// </summary>
    /// <param name="ar">Gets the received message</param>
    private void EndUDPRecieve(IAsyncResult ar)
    {
      EDXLDE temp;
      if (this.udpRecieveClient.Client != null)
      {
        try
        {
          byte[] recieveBytes = this.udpRecieveClient.EndReceive(ar, ref this.udpSubscribeEndPoint);
          this.udpRecieveClient.BeginReceive(this.udpRecieveCallback, this.udpRecieveClient);
          string recieveString = Encoding.ASCII.GetString(recieveBytes);

          // We Have An EDXL Terminator
          if (recieveString.Contains("</EDXLDistribution>"))
          {
            temp = new EDXLDE(recieveString);
            this.recvQ.EnQueue(new NameObject<string, EDXLDE>(this.udpString, temp));
            this.messageReceived.Invoke();
          }
        }
        catch (ObjectDisposedException e)
        {
////          throw e;
          e.Message.ToString();
        }
        catch (NullReferenceException e)
        {
          throw e;
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    }

    #endregion

    #region Public TCP Functions

    /// <summary>
    /// Begins The Asynchronous TCP Listen Operation
    /// </summary>
    private void BeginTCPListen()
    {
      this.tcpString = "TCP:" + this.settings.TCPListenPort;
      this.tcpReciever = new Receiver(this.settings.TCPListenPort);
      this.listenThr = this.tcpReciever.StartListener();
      this.recvThr = new Thread(new ThreadStart(this.RecvQThr));
      this.recvThr.Start();
    }

    /// <summary>
    /// Closes The TCP Send Socket
    /// </summary>
    private void EndTCPSend()
    {
      this.tcpSocket.Close();
    }

    /// <summary>
    /// Closes The TCP Listener Socket
    /// </summary>
    private void EndTCPListen()
    {
      this.tcpReciever.Close();
      this.listenThr.Abort();
      this.recvThr.Abort();
    }

    #endregion

    /// <summary>
    /// Thread Operation For the Send Queue
    /// </summary>
    private void SendQThr()
    {
      EDXLDE temp;
      string senddata;
      while (this.sendEnabled)
      {
        temp = this.sendQ.DeQueue();
        senddata = temp.WriteToXML();
        if (this.settings.TCPSend)
        {
          this.TCPSendMsg(senddata);
        }

        if (this.settings.UDPSend)
        {
          this.UDPSendMsg(senddata);
        }
      }
    }

    /// <summary>
    /// Thread Operation for the Receive Queue
    /// </summary>
    private void RecvQThr()
    {
      EDXLDE temp;
      while (this.recvEnabled)
      {
        temp = new EDXLDE(this.tcpReciever.TCPRecieveQ.DeQueue());
        this.recvQ.EnQueue(new NameObject<string, EDXLDE>(this.tcpString, temp));
        this.messageReceived.Invoke();
      }
    }

    /// <summary>
    /// If We Have IPV6 Or Other Crazy Connections This will Nix Them...Needs To be Updated
    /// </summary>
    /// <param name="entry">host Entry Table</param>
    /// <returns>Good IP Address To Use</returns>
    private IPAddress ResolveAddressList(IPHostEntry entry)
    {
      IPAddress ipaddr;
      string testeout;
      for (int i = 0; i < entry.AddressList.Count(); i++)
      {
        try
        {
          ipaddr = entry.AddressList[i];

          // Not IPv6 Compatible...Needs Updating
          if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
          {
            return ipaddr;
          }
        }
        catch (Exception e)
        {
          testeout = e.ToString();
        }
      }

      return null;
    }

    /// <summary>
    /// Thread Process For Sending TCP Messages From The Send Queue
    /// </summary>
    /// <param name="msg">Message to be sent over TCP</param>
    private void TCPSendMsg(string msg)
    {
      IPHostEntry entry = Dns.GetHostEntry(this.settings.TCPDestHost);
      IPAddress destIP;
      if (entry.AddressList.Count() > 1)
      {
        destIP = this.ResolveAddressList(entry);
      }
      else
      {
        destIP = entry.AddressList[0];
      }

      this.tcpPublishEndPoint = new IPEndPoint(destIP, this.settings.TCPDestPort);
      this.tcpSocket = new Socket(this.tcpPublishEndPoint.AddressFamily, SocketType.Stream, ProtocolType.IP);
      this.tcpSocket.Connect(this.tcpPublishEndPoint);
      byte[] senddata = Encoding.ASCII.GetBytes(msg);
      this.tcpSocket.Send(senddata);
      this.tcpSocket.Close();
    }

    /// <summary>
    /// Thread Process For Sending UDP Messages From The Send Queue
    /// </summary>
    /// <param name="msg">Message to be sent through the UDP Sender</param>
    private void UDPSendMsg(string msg)
    {
      IPHostEntry entry = Dns.GetHostEntry(this.settings.UDPDestHost);
      IPAddress destIP;
      if (entry.AddressList.Count() > 1)
      {
        destIP = this.ResolveAddressList(entry);
      }
      else
      {
        destIP = entry.AddressList[0];
      }

      this.udpPublishEndPoint = new IPEndPoint(destIP, this.settings.UDPDestPort);
      this.udpSendClient = new UdpClient();
      this.udpSendClient.Send(Encoding.ASCII.GetBytes(msg), Encoding.ASCII.GetByteCount(msg), this.udpPublishEndPoint);
      this.udpSendClient.Close();
    }

    #endregion
  }
}
