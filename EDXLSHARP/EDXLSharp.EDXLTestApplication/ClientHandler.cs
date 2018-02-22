// ———————————————————————–
// <copyright file="ClientHandler.cs" company="EDXLSharp">
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
/*
 * Operations:
 * ------------------
 * Handles Client Messages on Multiple Threads and Passes Complete Messages Into A Shared Thread Safe Queu
 * 
*/
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using ThreadSafeBlockingQ;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// Handles Server-Side Processing of Messages For Each TCP Client
  /// </summary>
  public class ClientHandler
  {
    #region Private Member Variables

    /// <summary>
    /// Socket to receive messages
    /// </summary>
    private Socket receiveSocket = null;

    /// <summary>
    /// TCP Receiving queue
    /// </summary>
    private BlockingQueue<string> tcpRecieveQ;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ClientHandler class
    /// /// Default Constructor
    /// </summary>
    public ClientHandler()
    {
      this.tcpRecieveQ = new BlockingQueue<string>();
    }

    /// <summary>
    /// Initializes a new instance of the ClientHandler class
    /// Constructor That Will Take Pointer to Shared Q
    /// </summary>
    /// <param name="mQ">Pointer To The Shared ThreadSafe Q</param>
    public ClientHandler(BlockingQueue<string> mQ)
    {
      this.tcpRecieveQ = mQ;
    }

    #endregion
    
    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// The Underlying TCP Socket
    /// </summary>
    public Socket RecieveSocket
    {
      get { return this.receiveSocket; }
      set { this.receiveSocket = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Thread safe Queue of Received Messages
    /// </summary>
    public BlockingQueue<string> TCPRecieveQ
    {
      get { return this.tcpRecieveQ; }
      set { this.tcpRecieveQ = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Override to Clone a Client for new Connection
    /// </summary>
    /// <returns>New ClientHandler Object</returns>
    public virtual ClientHandler CloneClientHandler()
    {
      ClientHandler returnCh = new ClientHandler();
      returnCh.TCPRecieveQ = this.tcpRecieveQ;
      return returnCh;
    }

    /// <summary>
    /// This Starts The Receive Process Thread Virtualized For Polymorphism
    /// </summary>
    public virtual void HandleClientProc()
    {
      Thread recvThread = new Thread(new ThreadStart(this.RecieveProc));
      recvThread.Start();
    }

    #endregion

    #region Public Member Functions
    
    /// <summary>
    /// Parses The Messages Byte by Byte from the Socket; EnQueues when Complete
    /// </summary>
    private void RecieveProc()
    {
      int bytesRecvd;
      if (this.receiveSocket == null)
      {
        throw new NullReferenceException("ClientHandler has null Socket");
      }

      this.receiveSocket.Blocking = true;
      StringBuilder msg = new StringBuilder();
      byte[] buffer = new byte[1];
      char mCh = ' ';
      while (true)
      {
        try
        {
          bytesRecvd = this.receiveSocket.Receive(buffer, 1, SocketFlags.None);
        }
        catch (Exception ex)
        {
          throw ex;
        }

        if (bytesRecvd == 1)
        {
          mCh = (char)buffer[0];
          msg.Append(mCh);
        }
        else
        {
          return;
        }

        int mlen = msg.Length;
        if (msg.ToString().Contains("</EDXLDistribution>"))
        {
          this.tcpRecieveQ.EnQueue(msg.ToString());
          msg = new StringBuilder();
        }
      }
    }

    #endregion
  }
}
