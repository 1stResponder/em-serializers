// ———————————————————————–
// <copyright file="TestAppSettings.cs" company="EDXLSharp">
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

using System.IO;
using System.Xml.Serialization;
using EDXLSharp.EDXLDELib;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// Test application class object
  /// </summary>
  [XmlRoot("EDXLDebugAppSettings")]
  public class TestAppSettings
  {
    #region private Member Variables

    /// <summary>
    /// Log file name
    /// </summary>
    private string logFile;

    /// <summary>
    /// log file length
    /// </summary>
    private uint maxLogLen;

    /// <summary>
    /// send rate in seconds
    /// </summary>
    private int period;

    /// <summary>
    /// Hold socket open between messages
    /// </summary>
    private bool txsocketStayOpen;

    /// <summary>
    /// How many messages to hold onto
    /// </summary>
    private uint historyLength;

    /// <summary>
    /// text prefix to use
    /// </summary>
    private string distributionPrefix;

    /// <summary>
    /// default sender name
    /// </summary>
    private string senderDefault;

    /// <summary>
    /// default distribution value
    /// </summary>
    private StatusValue distStatusDefault;

    /// <summary>
    /// default distribution type
    /// </summary>
    private TypeValue distTypeDefault;

    /// <summary>
    /// default Configuration value
    /// </summary>
    private string confDefault;

    /// <summary>
    /// default language value
    /// </summary>
    private string languageDefault;

    /// <summary>
    /// Send via TCP value
    /// </summary>
    private bool tcpSend;

    /// <summary>
    /// Receive via TCP value
    /// </summary>
    private bool tcpRecv;

    /// <summary>
    /// Send via UDP value
    /// </summary>
    private bool udpSend;

    /// <summary>
    /// Receive via UDP value
    /// </summary>
    private bool udpRecv;

    /// <summary>
    /// TCP Destination host value
    /// </summary>
    private string tcpDestHost;

    /// <summary>
    /// TCP destination port value
    /// </summary>
    private int tcpDestPort;

    /// <summary>
    /// TCP listen port value
    /// </summary>
    private int tcpListenPort;

    /// <summary>
    /// UDP Destination host value
    /// </summary>
    private string udpDestHost;

    /// <summary>
    /// UDP destination host port value
    /// </summary>
    private int udpDestPort;

    /// <summary>
    /// UDP listening port value
    /// </summary>
    private int udpListenPort;

    /// <summary>
    /// File Send value
    /// </summary>
    private bool fileSend;

    /// <summary>
    /// File receive value
    /// </summary>
    private bool fileRecv;

    /// <summary>
    /// Send File Name Value
    /// </summary>
    private string sendFileName;

    /// <summary>
    /// Receive File name value
    /// </summary>
    private string recvFileName;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TestAppSettings class
    /// Default Constructor - Sets Default Values
    /// </summary>
    public TestAppSettings()
    {
      this.logFile = "debug.log";
      this.maxLogLen = 5000;
      this.period = 1000;
      this.txsocketStayOpen = true;
      this.historyLength = 100;
      this.distributionPrefix = "Debug.";
      this.senderDefault = "edxltest@oasis-open.org";
      this.distStatusDefault = StatusValue.Test;
      this.distTypeDefault = TypeValue.Report;
      this.confDefault = "Unclassified and not sensitive";
      this.languageDefault = "en-US";
      this.tcpSend = true;
      this.tcpRecv = true;
      this.udpSend = true;
      this.udpRecv = true;
      this.tcpDestHost = "localhost";
      this.tcpDestPort = 16000;
      this.tcpListenPort = 16000;
      this.udpDestHost = "localhost";
      this.udpDestPort = 16001;
      this.udpListenPort = 16001;
      this.fileSend = false;
      this.fileRecv = false;
      this.sendFileName = "sendlog.txt";
      this.recvFileName = "recievelog.txt";
    }

    /// <summary>
    /// Initializes a new instance of the TestAppSettings class
    /// Copy Constructor Needed for Serialization
    /// </summary>
    /// <param name="settings">Object to Copy</param>
    public TestAppSettings(TestAppSettings settings)
    {
      this.logFile = settings.LogFile;
      this.maxLogLen = settings.MaxLogLength;
      this.period = settings.Period;
      this.txsocketStayOpen = settings.TxSocketStayOpen;
      this.historyLength = settings.HistoryLength;
      this.distributionPrefix = settings.DistributionPrefix;
      this.senderDefault = settings.SenderDefault;
      this.distStatusDefault = settings.DistStatusDefault;
      this.distTypeDefault = settings.DistTypeDefault;
      this.confDefault = settings.ConfDefault;
      this.tcpSend = settings.TCPSend;
      this.tcpRecv = settings.TCPRecv;
      this.udpSend = settings.UDPSend;
      this.udpRecv = settings.UDPRecv;
      this.tcpDestHost = settings.TCPDestHost;
      this.tcpDestPort = settings.TCPDestPort;
      this.tcpListenPort = settings.TCPListenPort;
      this.udpDestHost = settings.UDPDestHost;
      this.udpDestPort = settings.UDPDestPort;
      this.udpListenPort = settings.UDPListenPort;
      this.fileSend = settings.FileSend;
      this.fileRecv = settings.FileRecv;
      this.sendFileName = settings.SendFileName;
      this.recvFileName = settings.RecvFileName;
    }

    /// <summary>
    /// Initializes a new instance of the TestAppSettings class
    /// Constructor That Will Load From Specified File
    /// </summary>
    /// <param name="fileName">file name to use</param>
    public TestAppSettings(string fileName)
    {
      this.Load(fileName);
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets a value indicating whether Is File Send Enabled?
    /// </summary>
    public bool FileSend
    {
      get { return this.fileSend; }
      set { this.fileSend = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Is File Receive Enabled?
    /// </summary>
    public bool FileRecv
    {
      get { return this.fileRecv; }
      set { this.fileRecv = value; }
    }

    /// <summary>
    /// Gets or sets FileName TO Store Send Data In
    /// </summary>
    public string SendFileName
    {
      get { return this.sendFileName; }
      set { this.sendFileName = value; }
    }

    /// <summary>
    /// Gets or sets FileName To Store Received Data In
    /// </summary>
    public string RecvFileName
    {
      get { return this.recvFileName; }
      set { this.recvFileName = value; }
    }

    /// <summary>
    /// Gets or sets Destination Hostname for TCP Send
    /// </summary>
    public string TCPDestHost
    {
      get { return this.tcpDestHost; }
      set { this.tcpDestHost = value; }
    }

    /// <summary>
    /// Gets or sets Destination Port number for TCP Send
    /// </summary>
    public int TCPDestPort
    {
      get { return this.tcpDestPort; }
      set { this.tcpDestPort = value; }
    }

    /// <summary>
    /// Gets or sets Port Number To Listen on For TCP Traffic
    /// </summary>
    public int TCPListenPort
    {
      get { return this.tcpListenPort; }
      set { this.tcpListenPort = value; }
    }

    /// <summary>
    /// Gets or sets Destination IP Address For UDP Traffic
    /// </summary>
    public string UDPDestHost
    {
      get { return this.udpDestHost; }
      set { this.udpDestHost = value; }
    }

    /// <summary>
    /// Gets or sets Destination Port For UDP Traffic
    /// </summary>
    public int UDPDestPort
    {
      get { return this.udpDestPort; }
      set { this.udpDestPort = value; }
    }

    /// <summary>
    /// Gets or sets Port To Listen on For UDP Traffic
    /// </summary>
    public int UDPListenPort
    {
      get { return this.udpListenPort; }
      set { this.udpListenPort = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Is Sending Over TCP Enabled
    /// </summary>
    public bool TCPSend
    {
      get { return this.tcpSend; }
      set { this.tcpSend = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Is Receiving Over TCP Enabled
    /// </summary>
    public bool TCPRecv
    {
      get { return this.tcpRecv; }
      set { this.tcpRecv = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Is Sending Over UDP Enabled
    /// </summary>
    public bool UDPSend
    {
      get { return this.udpSend; }
      set { this.udpSend = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Is Receiving on UDP Enabled
    /// </summary>
    public bool UDPRecv
    {
      get { return this.udpRecv; }
      set { this.udpRecv = value; }
    }

    /// <summary>
    /// Gets or sets Default Distribution Status
    /// </summary>
    public StatusValue DistStatusDefault
    {
      get { return this.distStatusDefault; }
      set { this.distStatusDefault = value; }
    }

    /// <summary>
    /// Gets or sets Default Distribution Type
    /// </summary>
    public TypeValue DistTypeDefault
    {
      get { return this.distTypeDefault; }
      set { this.distTypeDefault = value; }
    }

    /// <summary>
    /// Gets or sets Default Combined Confidentiality
    /// </summary>
    public string ConfDefault
    {
      get { return this.confDefault; }
      set { this.confDefault = value; }
    }

    /// <summary>
    /// Gets or sets Default Language string
    /// </summary>
    public string LanguageDefault
    {
      get { return this.languageDefault; }
      set { this.languageDefault = value; }
    }

    /// <summary>
    /// Gets or sets Default Sender ID When Generating
    /// </summary>
    public string SenderDefault
    {
      get { return this.senderDefault; }
      set { this.senderDefault = value; }
    }

    /// <summary>
    /// Gets or sets Prefix For Distribution ID When Generating
    /// </summary>
    public string DistributionPrefix
    {
      get { return this.distributionPrefix; }
      set { this.distributionPrefix = value; }
    }

    /// <summary>
    /// Gets or sets Length of the Message History Stored in Memory # of Messages
    /// </summary>
    public uint HistoryLength
    {
      get { return this.historyLength; }
      set { this.historyLength = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Transmit Socket Behavior (True=stay open; False=close after each message)
    /// </summary>
    public bool TxSocketStayOpen
    {
      get { return this.txsocketStayOpen; }
      set { this.txsocketStayOpen = value; }
    }

    /// <summary>
    /// Gets or sets Delta T Between Burst Messages in Milliseconds
    /// </summary>
    public int Period
    {
      get { return this.period; }
      set { this.period = value; }
    }

    /// <summary>
    /// Gets or sets Max Log Length in KB
    /// </summary>
    public uint MaxLogLength
    {
      get { return this.maxLogLen; }
      set { this.maxLogLen = value; }
    }

    /// <summary>
    /// Gets or sets Filename of the log file
    /// </summary>
    public string LogFile
    {
      get { return this.logFile; }
      set { this.logFile = value; }
    }

    #endregion

    #region Public Member Function
    /// <summary>
    /// Save the Settings to the Specified File
    /// </summary>
    /// <param name="file">Settings File Path and Name</param>
    public void Save(string file)
    {
      XmlSerializer s = new XmlSerializer(typeof(TestAppSettings));
      StreamWriter sw = new StreamWriter(file);
      s.Serialize(sw, this);
      sw.Flush();
      sw.Close();
    }

    /// <summary>
    /// Loads Settings From The Specified File
    /// </summary>
    /// <param name="file">Settings File Path and Name</param>
    public void Load(string file)
    {
      TestAppSettings temp;
      XmlSerializer s = new XmlSerializer(typeof(TestAppSettings));
      StreamReader sr = new StreamReader(file);
      temp = (TestAppSettings)s.Deserialize(sr);
      sr.Close();
      this.CopyThis(temp);
    }
    #endregion

    #region Private Member Functions
    /// <summary>
    /// Copies New Object From DeSerialization
    /// </summary>
    /// <param name="msettings">Object to copy</param>
    private void CopyThis(TestAppSettings msettings)
    {
      this.logFile = msettings.LogFile;
      this.maxLogLen = msettings.MaxLogLength;
      this.period = msettings.Period;
      this.txsocketStayOpen = msettings.TxSocketStayOpen;
      this.historyLength = msettings.HistoryLength;
      this.distributionPrefix = msettings.distributionPrefix;
      this.senderDefault = msettings.SenderDefault;
      this.distStatusDefault = msettings.DistStatusDefault;
      this.distTypeDefault = msettings.DistTypeDefault;
      this.confDefault = msettings.ConfDefault;
      this.tcpSend = msettings.TCPSend;
      this.tcpRecv = msettings.TCPRecv;
      this.udpSend = msettings.UDPSend;
      this.udpRecv = msettings.UDPRecv;
      this.tcpDestHost = msettings.TCPDestHost;
      this.tcpDestPort = msettings.TCPDestPort;
      this.tcpListenPort = msettings.TCPListenPort;
      this.udpDestHost = msettings.UDPDestHost;
      this.udpDestPort = msettings.UDPDestPort;
      this.udpListenPort = msettings.UDPListenPort;
      this.fileSend = msettings.FileSend;
      this.fileRecv = msettings.FileRecv;
      this.sendFileName = msettings.SendFileName;
      this.recvFileName = msettings.RecvFileName;
    }
    #endregion
  }
}
