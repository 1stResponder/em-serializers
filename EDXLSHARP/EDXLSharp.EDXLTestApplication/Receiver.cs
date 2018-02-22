// ———————————————————————–
// <copyright file="Receiver.cs" company="EDXLSharp">
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

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using ThreadSafeBlockingQ;

namespace EDXLSharp.EDXLTestApplication
{ 
  /// <summary>
  /// Receiver class definition
  /// </summary>
  public class Receiver
  {
    #region Private Member Variables

    /// <summary>
    /// TCP Listener to receive messages on
    /// </summary>
    private TcpListener tcpListener;
    
    /// <summary>
    /// Port to listen for TCP messages on
    /// </summary>
    private int tcpListenPort;
    
    /// <summary>
    /// Client handler for messages
    /// </summary>
    private ClientHandler derivedClientHandler;
    
    /// <summary>
    /// Thread for listening activity
    /// </summary>
    private Thread listenThr;
    
    /// <summary>
    /// Status of listening for messages
    /// </summary>
    private bool islistening;
    
    /// <summary>
    /// Blocking queue for TCP
    /// </summary>
    private BlockingQueue<string> tcpRecieveQ;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the Receiver class
    /// Default Constructor
    /// </summary>
    public Receiver()
    {
      this.tcpRecieveQ = new BlockingQueue<string>();
      this.derivedClientHandler = new ClientHandler(this.tcpRecieveQ);
      this.islistening = false;
    }

    /// <summary>
    /// Initializes a new instance of the Receiver class
    /// Constructor That Takes In Port #
    /// </summary>
    /// <param name="port">TCP Port # to Listen On</param>
    public Receiver(int port)
    {
      this.tcpListenPort = port;
      this.tcpRecieveQ = new BlockingQueue<string>();
      this.derivedClientHandler = new ClientHandler(this.tcpRecieveQ);
      this.islistening = false;
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets the port for TCP messages.
    /// TCP Port To Listen On
    /// </summary>
    public int TCPListenPort
    {
      get { return this.tcpListenPort; }
      set { this.tcpListenPort = value; }
    }

    /// <summary>
    /// Gets the queue for receiving TCP messages
    /// The Shared TCP Receive Queue
    /// </summary>
    public BlockingQueue<string> TCPRecieveQ
    {
      get { return this.tcpRecieveQ; }
    }

    /// <summary>
    /// Gets a value indicating whether this is currently listening for TCP
    /// Are We Listening For Incoming TCP Connections Now?
    /// </summary>
    public bool IsTCPListening
    {
      get { return this.islistening; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Start The Listener
    /// </summary>
    /// <returns>Thread That Listener is Running On</returns>
    public Thread StartListener()
    {
      this.listenThr = new Thread(new ThreadStart(this.ListenProc));
      try
      {
        this.listenThr.Start();
      }
      catch (Exception e)
      {
        throw e;
      }

      return this.listenThr;
    }

    /// <summary>
    /// Stops The Listener
    /// </summary>
    public void Close()
    {
      this.islistening = false;
      this.tcpListener.Stop();
      this.tcpRecieveQ = null;
    }
    #endregion

    /// <summary>
    /// Function To Give a Receiver A ClientHandler
    /// </summary>
    /// <param name="ch">Client Handler value</param>
    private void RegisterClientHandler(ClientHandler ch)
    {
      this.derivedClientHandler = ch;
    }

    /// <summary>
    /// Listens For TCP Connections
    /// </summary>
    private void ListenProc()
    {
      try
      {
        if (this.derivedClientHandler == null)
        {
          this.derivedClientHandler = new ClientHandler();
        }

        try
        {
          this.tcpListener = new TcpListener(IPAddress.Any, this.tcpListenPort);
          this.tcpListener.Start();
          this.islistening = true;
        }
        catch (Exception e)
        {
          throw e;
        }

        while (this.islistening)
        {
          try
          {
            Socket clientSocket = this.tcpListener.AcceptSocket();
            ClientHandler ch = this.derivedClientHandler.CloneClientHandler();
            ch.RecieveSocket = clientSocket;
            Thread clientHandlerThr = new Thread(new ThreadStart(ch.HandleClientProc));
            clientHandlerThr.Start();
          }
          catch (Exception e)
          {
            throw e;
          }
        }
      }
      catch
      {
      }
    }
  }
}
