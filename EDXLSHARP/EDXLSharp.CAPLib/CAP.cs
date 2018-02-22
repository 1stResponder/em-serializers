// ———————————————————————–
// <copyright file="CAP.cs" company="EDXLSharp">
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The alert segment provides basic information about the current message: its purpose, its source and its status,
  /// as well as a unique identifier for the current message and links to any other, related messages.  
  /// An alert segment may be used alone for message acknowledgements, cancellations or other system functions, 
  /// but most alert segments will include at least one info segment.
  /// </summary>
  [Serializable]
  public partial class CAP : IGeoRSS, IContentObject
  {
    #region Private Member Variables

    /// <summary>
    /// Class Variable To Store Concatenated Schema Validation Errors
    /// </summary>
    private static string schemaErrorString = string.Empty;

    /// <summary>
    /// Class Variable To Store Number of Schema Validation Errors
    /// </summary>
    private static int schemaErrors = 0;

    /// <summary>
    /// The identifier of the alert message (REQUIRED) 
    /// </summary>
    private string messageID;

    /// <summary>
    /// The time and date of the origination of the alert message (REQUIRED) 
    /// </summary>
    private string senderID;

    /// <summary>
    /// The time and date of the origination of the alert message (REQUIRED)
    /// </summary>
    private DateTime sentDateTime;

    /// <summary>
    /// The code denoting the appropriate handling of the alert message (REQUIRED)
    /// </summary>
    private StatusType? messageStatus;

    /// <summary>
    /// The code denoting the nature of the alert message (REQUIRED)
    /// </summary>
    private MsgType? messageType;

    /// <summary>
    /// The text identifying the source of the alert message (OPTIONAL)
    /// </summary>
    private string source;

    /// <summary>
    /// The code denoting the intended distribution of the alert message (REQUIRED)
    /// </summary>
    private ScopeType? scope;

    /// <summary>
    /// The text describing the rule for limiting distribution of the restricted alert message (CONDITIONAL)
    /// </summary>
    private string restriction;

    /// <summary>
    /// The group listing of intended recipients of the alert message (CONDITIONAL)
    /// </summary>
    private string addresses;

    /// <summary>
    /// The code denoting the special handling of the alert message (OPTIONAL)
    /// </summary>
    private List<string> handlingCode;

    /// <summary>
    /// The text describing the purpose or significance of the alert message (OPTIONAL)
    /// </summary>
    private string note;

    /// <summary>
    /// The group listing identifying earlier message(s) referenced by the alert message (OPTIONAL)
    /// </summary>
    private string referenceIDs;

    /// <summary>
    /// The group listing naming the referent incident(s) of the alert message (OPTIONAL)
    /// </summary>
    private string incidentIDs;

    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message (OPTIONAL)
    /// </summary>
    private List<InfoType> info;

    /// <summary>
    /// The namespace of the CAP element
    /// </summary>
    private string capNamespace;

    /// <summary>
    /// Special requirements allowing for signature of the content of a contentObject. 
    /// </summary>
    private List<XElement> other;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the CAP class Default Constructor - Initializes Lists
    /// </summary>
    public CAP()
    {
      this.capNamespace = null;
      this.handlingCode = new List<string>();
      this.info = new List<InfoType>();
      this.other = new List<XElement>();
    }

    /// <summary>
    /// Initializes a new instance of the CAP class 
    /// Constructor That Will Parse A CAP Message from a String
    /// </summary>
    /// <param name="xmlString">Valid XML CAP Message Data in a String</param>
    public CAP(string xmlString)
    {
      this.capNamespace = null;
      this.handlingCode = new List<string>();
      this.info = new List<InfoType>();
      this.other = new List<XElement>();

      this.ReadXML(xmlString);
      this.Validate();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The identifier of the alert message
    /// </summary>
    public string MessageID
    {
      get { return this.messageID; }
      set { this.messageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The identifier of the sender of the alert message
    /// </summary>
    public string SenderID
    {
      get { return this.senderID; }
      set { this.senderID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The time and date of the origination of the alert message
    /// </summary>
    public DateTime SentDateTime
    {
      get
      {
        return this.sentDateTime;
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.sentDateTime = value;
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets the time this message expires
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get
      {
        if (this.info == null || this.info[0] == null)
        {
          // Using this as default value.  Should this be something else?
          return this.SentDateTime.AddHours(24);
        }

        return this.info[0].Expires;
      }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the appropriate handling of the alert message
    /// </summary>
    public StatusType? MessageStatus
    {
      get { return this.messageStatus; }
      set { this.messageStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the nature of the alert message
    /// </summary>
    public MsgType? MessageType
    {
      get { return this.messageType; }
      set { this.messageType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text identifying the source of the alert message
    /// </summary>
    public string Source
    {
      get { return this.source; }
      set { this.source = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the intended distribution of the alert message
    /// </summary>
    public ScopeType? Scope
    {
      get { return this.scope; }
      set { this.scope = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the rule for limiting distribution of the restricted alert message 
    /// </summary>
    public string Restriction
    {
      get { return this.restriction; }
      set { this.restriction = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The group listing of intended recipients of the alert message
    /// </summary>
    public string Addresses
    {
      get { return this.addresses; }
      set { this.addresses = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the special handling of the alert message 
    /// </summary>
    public List<string> HandlingCode
    {
      get { return this.handlingCode; }
      set { this.handlingCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the purpose or significance of the alert message
    /// </summary>
    public string Note
    {
      get { return this.note; }
      set { this.note = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The group listing identifying earlier message(s) referenced by the alert message
    /// </summary>
    public string ReferenceIDs
    {
      get
      {
        return this.referenceIDs;
      }

      set
      {
        this.CheckReferences(value);
        this.referenceIDs = value;
      }
    }

    /// <summary>
    /// Gets or sets
    /// The group listing naming the referent incident(s) of the alert message
    /// </summary>
    public string IncidentIDs
    {
      get { return this.incidentIDs; }
      set { this.incidentIDs = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The container for all component parts of the info sub-element of the alert message
    /// </summary>
    public List<InfoType> Info
    {
      get { return this.info; }
      set { this.info = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Any:Other for Custom Data or Key/Signature Info
    /// </summary>
    [XmlIgnore]
    public List<XElement> Other
    {
      get { return this.other; }
      set { this.other = value; }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Xml Any Other
    /// </summary>
    [XmlAnyElement]
    public XElement[] OtherXML
    {
      get
      {
        if (this.other.Count == 0)
        {
          return null;
        }
        else
        {
          return this.other.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.other = value.ToList();
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// A string representing a IPAWS Profile v1.0 compliant CAP v1.1 message
    /// </summary>
    public string CAPv11_IPAWSProfilev10
    {
      get { return this.GetIPAWSProfilev10ForCAPv11(); }
      set { this.SetIPAWSProfilev10ForCAPv11(value); }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Adds Any Other XML Content To The List
    /// </summary>
    /// <param name="otherxmlin">Valid XML Element</param>
    public void AddOther(XElement otherxmlin)
    {
      this.other.Add(otherxmlin);
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    /// <returns>String to Process ContentKeyWords Value From</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      if (ckw == (ValueList)null)
      {
        throw new ArgumentNullException("CKW");
      }

      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("EDXL-CAP");
      return "EDXL-CAP Alert";
    }

    /// <summary>
    /// Writes this CAP Message to XML
    /// </summary>
    /// <param name="xwriter">XML Writer to Use</param>
    /// <param name="withValidation">Whether to validate this message to the schema or not</param>
    public void WriteXML(XmlWriter xwriter, bool withValidation)
    {
      if (withValidation)
      {
        this.Validate();
      }

      if (string.IsNullOrEmpty(this.capNamespace))
      {
        this.capNamespace = EDXLConstants.CAP12Namespace;
      }

      xwriter.WriteStartElement(EDXLConstants.CAPPrefix, "alert", this.capNamespace);
      xwriter.WriteElementString("identifier", this.capNamespace, this.messageID);
      xwriter.WriteElementString("sender", this.capNamespace, this.senderID);
      xwriter.WriteElementString("sent", this.capNamespace, this.sentDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      xwriter.WriteElementString("status", this.capNamespace, this.messageStatus.ToString());
      xwriter.WriteElementString("msgType", this.capNamespace, this.messageType.ToString());
      if (!string.IsNullOrEmpty(this.source))
      {
        xwriter.WriteElementString("source", this.capNamespace, this.source);
      }

      if (this.scope != null)
      {
        xwriter.WriteElementString("scope", this.capNamespace, this.scope.ToString());
      }

      if (this.scope == ScopeType.Restricted)
      {
        xwriter.WriteElementString("restriction", this.capNamespace, this.restriction);
      }

      if (this.scope == ScopeType.Private)
      {
        xwriter.WriteElementString("addresses", this.capNamespace, this.addresses);
      }
      else
      {
        if (!string.IsNullOrEmpty(this.addresses))
        {
          xwriter.WriteElementString("addresses", this.capNamespace, this.addresses);
        }
      }

      if (this.handlingCode.Count != 0)
      {
        foreach (string code in this.handlingCode)
        {
          if (string.IsNullOrEmpty(code))
          {
            continue;
          }

          xwriter.WriteElementString("code", this.capNamespace, code);
        }
      }

      if (!string.IsNullOrEmpty(this.note))
      {
        xwriter.WriteElementString("note", this.capNamespace, this.note);
      }

      if (!string.IsNullOrEmpty(this.referenceIDs))
      {
        xwriter.WriteElementString("references", this.capNamespace, this.referenceIDs);
      }

      if (!string.IsNullOrEmpty(this.incidentIDs))
      {
        xwriter.WriteElementString("incidents", this.capNamespace, this.incidentIDs);
      }

      if (this.info.Count != 0)
      {
        foreach (InfoType type in this.info)
        {
          xwriter.WriteStartElement("info", this.capNamespace);
          type.CapNamespace = this.capNamespace;
          type.WriteXML(xwriter, this.sentDateTime);
          xwriter.WriteEndElement();
        }
      }

      if (this.other.Count != 0)
      {
        foreach (XElement xe in this.other)
        {
          xe.WriteTo(xwriter);
        }
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.WriteXML(xwriter, true);
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the Root Object Element</param>
    public void ReadXML(XmlNode rootNode)
    {
      if (rootNode == (XmlNode)null)
      {
        throw new ArgumentNullException("RootNode");
      }

      if (rootNode.LocalName != "alert")
      {
        throw new ArgumentException("No alert Element found!");
      }

      XmlNode caproot = rootNode;
      this.capNamespace = caproot.NamespaceURI;

      InfoType infotypetmp;

      foreach (XmlNode node in caproot.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "identifier":
            this.messageID = node.InnerText;
            break;
          case "sender":
            this.senderID = node.InnerText;
            break;
          case "sent":
            this.sentDateTime = DateTime.Parse(node.InnerText);
            if (this.sentDateTime.Kind == DateTimeKind.Unspecified)
            {
              this.sentDateTime = DateTime.MinValue;
              throw new ArgumentException("TimeZone Information Must Be Specified");
            }

            this.sentDateTime = this.sentDateTime.ToUniversalTime();
            break;
          case "status":
            this.messageStatus = (StatusType)Enum.Parse(typeof(StatusType), node.InnerText);
            break;
          case "msgType":
            this.messageType = (MsgType)Enum.Parse(typeof(MsgType), node.InnerText);
            break;
          case "source":
            this.source = node.InnerText;
            break;
          case "scope":
            this.scope = (ScopeType)Enum.Parse(typeof(ScopeType), node.InnerText);
            break;
          case "restriction":
            this.restriction = node.InnerText;
            break;
          case "addresses":
            this.addresses = node.InnerText;
            break;
          case "code":
            this.handlingCode.Add(node.InnerText);
            break;
          case "note":
            this.note = node.InnerText;
            break;
          case "references":
            this.referenceIDs = node.InnerText;
            break;
          case "incidents":
            this.incidentIDs = node.InnerText;
            break;
          case "info":
            infotypetmp = new InfoType();
            infotypetmp.ReadXML(node, this.sentDateTime);
            this.info.Add(infotypetmp);
            break;
          case "#comment":
            break;
          default:
            XElement xe = XElement.Load(new XmlNodeReader(node));
            this.other.Add(xe);
            break;
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="items">Pointer to a Valid List of Syndication Items to Populate</param>
    /// <param name="linkUID">Unique Identifier to Link This Item To</param>
    public void ToGeoRSS(List<SyndicationItem> items, Guid linkUID)
    {
      StringBuilder contentstr = new StringBuilder();
      if (items == null)
      {
        throw new ArgumentNullException("Syndication Items List Can't Be Null");
      }

      if (linkUID == null)
      {
        throw new ArgumentNullException("LinkUID Can't Be Null");
      }

      SyndicationItem myitem;
      this.Validate();
      myitem = new SyndicationItem();
      myitem.Authors.Add(new SyndicationPerson(this.addresses, this.senderID, string.Empty));
      myitem.Categories.Add(new SyndicationCategory(EDXLConstants.CAPSyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.sentDateTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "CAP/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;
      myitem.Summary = new TextSyndicationContent("MessageID: " + this.messageID + "\nSender: " + this.senderID);
      myitem.Title = new TextSyndicationContent("Alert - " + this.messageStatus.ToString() + " - " + this.messageType.ToString() + " (EDXL-CAP)");
      contentstr.AppendLine("Sent: " + this.sentDateTime.ToString("o"));
      foreach (InfoType myinfo in this.info)
      {
        myinfo.ToGeoRSS(myitem, contentstr);
      }

      myitem.Content = new TextSyndicationContent(contentstr.ToString());
      items.Add(myitem);
    }

    /// <summary>
    /// Writes This CAP Message to a String
    /// </summary>
    /// <param name="withValidation">Determines if validate method is called before writing</param>
    /// <returns>String of XML CAP Data</returns>
    public string WriteToXML(bool withValidation)
    {
      if (withValidation)
      {
        this.Validate();
      }

      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      StringBuilder output = new StringBuilder();
      using (XmlWriter xwriter = XmlWriter.Create(output, xsettings))
      {
        this.WriteXML(xwriter, withValidation);
        xwriter.Flush();
      }

      string strout = output.ToString();
      if (EDXLConstants.SecondarySchemaValidation && withValidation)
      {
        this.ValidateToSchema();
      }

      return strout;
    }

    /// <summary>
    /// Writes This CAP Message to a String
    /// </summary>
    /// <returns>String of XML CAP Data</returns>
    public string WriteToXML()
    {
      return this.WriteToXML(true);
    }

    /// <summary>
    /// Reads A CAP Message From A String
    /// </summary>
    /// <param name="xmlData">String of XML CAP Data</param>
    public void ReadXML(string xmlData)
    {
      if (string.IsNullOrEmpty(xmlData))
      {
        throw new ArgumentNullException("XMLData Can't Be Null or Empty!");
      }

      XmlDocument doc = new XmlDocument();
      try
      {
        doc.LoadXml(xmlData);
      }
      catch (XmlException)
      {
        throw new ArgumentException("Invalid XML Data");
      }

      XmlNode capnode = doc.DocumentElement;
      this.ReadXML(capnode);

      if (EDXLConstants.SecondarySchemaValidation)
      {
        this.ValidateToSchema();
      }
    }

    /// <summary>
    /// Validates The Current CAP Object Against The CAP 1.2 XSD Schema File
    /// </summary>
    public void ValidateToSchema()
    {
      XmlReader vr;
      XmlReaderSettings xs = new XmlReaderSettings();
      XmlSchemaSet coll = new XmlSchemaSet();
      StringReader xsdsr = new StringReader(EDXLSharp.CAPLib.Properties.Resources.CAP_v1_2_os);
      Stream xmlStream = new MemoryStream();
      XmlWriter xw = XmlWriter.Create(xmlStream);
      this.WriteXML(xw);
      XmlReader xsdread = XmlReader.Create(xsdsr);
      coll.Add(EDXLConstants.CAP12Namespace, xsdread);
      xs.Schemas.Add(coll);
      xs.ValidationType = ValidationType.Schema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      vr = XmlReader.Create(xmlStream, xs);
      while (vr.Read())
      {
      }

      vr.Close();
      xw.Close();
      xsdread.Close();
      xsdsr.Close();
      if (schemaErrors > 0)
      {
        throw new ArgumentException("Schema Validation Error: " + schemaErrorString);
      }
    }

    /// <summary>
    /// Checks This CAP Message For Compatibility to Be Used on a CAP 1.1 Based System
    /// </summary>
    /// <returns>True if Compatible</returns>
    public bool CheckCAP11Compatibility()
    {
      foreach (InfoType myinfo in this.info)
      {
        foreach (ResponseType myresponse in myinfo.ResponseType)
        {
          if (myresponse == ResponseType.Avoid || myresponse == ResponseType.AllClear)
          {
            return false;
          }
        }
      }

      return true;
    }

    /// <summary>
    /// Validates This CAP Message Against IPAWS Profile v1.0 for CAP v1.2
    /// </summary>
    public void ValidateToIPAWSProfilev10ForCAPv12()
    {
      // check code
      if (this.handlingCode == null || this.handlingCode.Count < 1 || !this.handlingCode.Contains("IPAWSv1.0"))
      {
        throw new System.ArgumentException("IPAWS Profile v1.0 requires 'IPAWSv1.0' be included in the CAP code");
      }

      if (this.messageID.Contains(" ") || this.messageID.Contains(",") || this.messageID.Contains("<") || this.messageID.Contains("&"))
      {
        throw new System.ArgumentException("IPAWS Profile v1.0 does not allow whitespace, commas, '<', or '&' in the identifier field.");
      }

      if (this.senderID.Contains(" ") || this.senderID.Contains(",") || this.senderID.Contains("<") || this.senderID.Contains("&"))
      {
        throw new System.ArgumentException("IPAWS Profile v1.0 does not allow whitespace, commas, '<', or '&' in the sender field.");
      }

      this.ValidateIPAWSProfilev10ForCAPv12InfoBlocks();
    }

    /// <summary>
    /// Validates This CAP Message Against IPAWS EAS Profile v1.0 for CAP v1.2
    /// </summary>
    public void ValidateToIPAWS_EASProfilev10ForCAPv12()
    {
      this.ValidateToIPAWSProfilev10ForCAPv12();
      this.ValidateIPAWS_EASProfilev10ForCAPv12InfoBlocks();
    }

    /// <summary>
    /// Validates this CAP Message Against IPAWS CMAS Profile v1.0 for CAP v1.2
    /// </summary>
    public void ValidateToIPAWS_CMASProfilev10ForCAPv12()
    {
      this.ValidateToIPAWSProfilev10ForCAPv12();
      this.ValidateIPAWS_CMASProfilev10ForCAPv12InfoBlocks();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.messageID))
      {
        throw new ArgumentNullException("Message ID is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.senderID))
      {
        throw new ArgumentNullException("Sender ID is required and can't be null");
      }

      if (this.sentDateTime == DateTime.MinValue)
      {
        throw new ArgumentNullException("Sent Date Time is required and can't be null");
      }

      if (this.messageStatus == null)
      {
        throw new ArgumentNullException("Message Status is required and can't be null");
      }

      if (this.messageType == null)
      {
        throw new ArgumentNullException("Mesage Type is required and can't be null");
      }

      if (this.scope == ScopeType.Restricted && string.IsNullOrEmpty(this.restriction))
      {
        throw new ArgumentException("Restriction is required when ScopeType==Restricted");
      }

      if (this.scope == ScopeType.Private && string.IsNullOrEmpty(this.addresses))
      {
        throw new ArgumentException("Addresses are required when ScopeType==Private");
      }

      this.CheckRestrictedCharacters(this.messageID, "identifier");
      this.CheckRestrictedCharacters(this.senderID, "sender");

      if (!string.IsNullOrEmpty(this.referenceIDs))
      {
        this.CheckReferences(this.referenceIDs);
      }
    }
    #endregion

    #region Private Member Functions

    /// <summary>
    /// Callback Function For Schema Errors
    /// </summary>
    /// <param name="sender">Which object fired this event callback</param>
    /// <param name="args">Validation Event Arguments</param>
    private static void SchemaErrorCallback(object sender, ValidationEventArgs args)
    {
      if (args.Severity == XmlSeverityType.Error)
      {
        schemaErrorString = schemaErrorString + args.Message + "\r\n";
        schemaErrors++;
      }
    }

    /// <summary>
    /// Checks A String For Restricted CAP Characters
    /// </summary>
    /// <param name="data">data string to parse for restricted characters</param>
    /// <param name="name">name of the element to appear in an error message</param>
    private void CheckRestrictedCharacters(string data, string name)
    {
      if (data.Contains(" ") || data.Contains(",") || data.Contains("<") || data.Contains("&") || data.Contains(">"))
      {
        throw new ArgumentException(name + " MUST NOT include spaces, commas or restricted characters (<, &, and >)");
      }
    }

    /// <summary>
    /// Checks A Reference ID for Proper Conformance
    /// </summary>
    /// <param name="s">Input String to Check</param>
    private void CheckReferences(string s)
    {
      if (s.Contains("\""))
      {
        throw new ArgumentException("This library doesn't support References with whitespace");
      }

      char[] refsplit = new char[] { ' ' };
      string[] refs = s.Split(refsplit);
      string[] refsplitstr;
      char[] split = new char[] { ',' };
      DateTime tempdt;
      foreach (string myref in refs)
      {
        refsplitstr = myref.Split(split);
        if (refsplitstr.Length != 3)
        {
          throw new ArgumentException("Reference ID's must be a three element ',' delimted string");
        }

        tempdt = DateTime.Parse(refsplitstr[2]);
        if (tempdt.Kind == DateTimeKind.Unspecified)
        {
          throw new ArgumentException("TimeZone Information Must Be Specified in the third element of a reference id");
        }
      }
    }

    /// <summary>
    /// Reads a CAP message from a string and validates that it meets the IPAWS 1.0 Profile for CAP 1.1
    /// </summary>
    /// <param name="xmlString">String value containing the XML data to parse</param>
    private void SetIPAWSProfilev10ForCAPv11(string xmlString)
    {
      if (string.IsNullOrEmpty(xmlString))
      {
        throw new ArgumentNullException("XMLData Can't Be Null or Empty!");
      }

      XmlDocument doc = new XmlDocument();
      try
      {
        doc.LoadXml(xmlString);
      }
      catch (XmlException)
      {
        throw new ArgumentException("Invalid XML Data");
      }

      XmlNode capnode = doc.DocumentElement;
      this.ReadXML(capnode);

      this.capNamespace = EDXLConstants.CAP11Namespace;

      this.Validate();
      this.ValidateToIPAWSProfilev10ForCAPv11();
    }

    /// <summary>
    /// Writes a 1.1 CAP message to a string, validating that it meets the IPAWS 1.0 Profile
    /// </summary>
    /// <returns>String of the XML data for the IPAWS Profile</returns>
    private string GetIPAWSProfilev10ForCAPv11()
    {
      if (this.CheckCAP11Compatibility())
      {
        try
        {
          this.Validate();
        }
        catch (Exception ex)
        {
          throw new System.InvalidCastException("CAP message is not IPAWS Profile v1.0 compliant", ex);
        }

        try
        {
          this.ValidateToIPAWSProfilev10ForCAPv11();
          string xml = this.WriteToXML();
          return xml;
        }
        catch (Exception ex)
        {
          throw new System.InvalidCastException("CAP message is not IPAWS Profile v1.0 compliant.", ex);
        }
      }
      else
      {
        throw new System.InvalidCastException("CAP message is not CAP v1.1 compliant.");
      }
    }

    /// <summary>
    /// Validates the CAP 1.1 Info elements are IPAWS Profile 1.0 compliant
    /// </summary>
    private void ValidateIPAWSProfilev10ForCAPv11InfoBlocks()
    {
      foreach (InfoType someInfo in this.info)
      {
        someInfo.Validate();

        if (someInfo.EventCode == null || someInfo.EventCode.Count < 1 || someInfo.EventCode.Count > 1)
        {
          throw new System.ArgumentException("IPAWS Profile v1.0 requires one and only one eventCode block in the info block.");
        }

        /*
        //NameValueType eCode = someInfo.EventCode[0];
        //if (eCode.Value.Length != 3)
        //{
        //  throw new System.ArgumentException("IPAWS Profile v1.0 requires the eventCode value be a three-letter code.");
        //}

        //if (!eCode.Name.Equals("SAME"))
        //{
        //  throw new System.ArgumentException("IPAWS Profile v1.0 requires the eventCode valueName be 'SAME'.");
        //}*/

        if (!string.IsNullOrEmpty(someInfo.Language) && !someInfo.Language.Equals("en-US"))
        {
          throw new System.ArgumentException("Multiple language usage is not defined in this version of the IPAWS CAP v1.1 Profile.");
        }

        if (someInfo.Parameter != null && someInfo.Parameter.Count > 0)
        {
          List<NameValueType> paramList = someInfo.Parameter.FindAll(p => p.Name.Equals("EAS-ORG"));

          if (paramList != null && paramList.Count > 1)
          {
            throw new System.ArgumentException("IPAWS Profile v1.0 requires there can only be one EAS-ORG parameter in an info block.");
          }

          paramList = someInfo.Parameter.FindAll(p => p.Name.Equals("EAS-STN-ID"));

          if (paramList != null && paramList.Count > 1)
          {
            throw new System.ArgumentException("IPAWS Profile v1.0 requires there can only be one EAS-STN-ID parameter in an info block.");
          }

          if (paramList != null && paramList.Count == 1)
          {
            string stnIDValue = paramList[0].Value;

            if (stnIDValue.Length > 8)
            {
              throw new System.ArgumentException("IPAWS Profile v1.0 requires the EAS Station ID not be more than 8 printable characters.");
            }

            if (stnIDValue.Contains("-") || stnIDValue.Contains("+"))
            {
              throw new System.ArgumentException("IPAWS Profile v1.0 requires the EAS Station ID not contain a dash '-' or plus '+'.");
            }
          }
        }

        this.ValidateIPAWSProfilev10ForCAPv11ResourceBlocks(someInfo);
        this.ValidateIPAWSProfilev10ForCAPv11AreaBlocks(someInfo);
      }
    }

    /// <summary>
    /// Validates the CAP 1.1 Resource elements are IPAWS Profile 1.0 compliant
    /// </summary>
    /// <param name="infoBlock">Information block portion of the CAP message</param>
    private void ValidateIPAWSProfilev10ForCAPv11ResourceBlocks(InfoType infoBlock)
    {
      if (infoBlock.Resource != null && infoBlock.Resource.Count > 0)
      {
        foreach (ResourceType rblock in infoBlock.Resource)
        {
          /*
          //if (rBlock.ResourceDesc != null && (rBlock.ResourceDesc.Equals("EAS Audio") || rBlock.ResourceDesc.Equals("EAS Streaming Audio")) == false)
          //{
          //  throw new System.ArgumentException("IPAWS Profile v1.0 requires the resourceDesc block to set to 'EAS Audio' or 'EAS Streaming Audio");
          //}*/

          if (string.IsNullOrEmpty(rblock.UriString) && string.IsNullOrEmpty(rblock.DerefUri))
          {
            throw new System.ArgumentNullException("IPAWS Profile v1.0 requires that either the uri block or the drefUri block not be null or empty.");
          }
        }
      }
    }

    /// <summary>
    /// Validates the CAP 1.1 Area elements are IPAWS Profile 1.0 compliant
    /// </summary>
    /// <param name="infoBlock">The information block portion of the CAP message</param>
    private void ValidateIPAWSProfilev10ForCAPv11AreaBlocks(InfoType infoBlock)
    {
      if (infoBlock.Area != null && infoBlock.Area.Count > 0)
      {
        AreaType ablock = infoBlock.Area[0]; // only first area is processed by IPAWS
        if (string.IsNullOrEmpty(ablock.AreaDesc))
        {
          throw new System.ArgumentNullException("IPAWS Profile v1.0 requires that the areaDesc block not be null or empty.");
        }

        List<NameValueType> geoCodes = ablock.GeoCode.FindAll(g => g.Name.Equals("SAME"));
        if (geoCodes == null || geoCodes.Count < 1)
        {
          throw new System.ArgumentException("IPAWS Profile v1.0 requires that there is at least one geoCode block with the valueName of SAME");
        }

        foreach (NameValueType geoCode in geoCodes)
        {
          if (geoCode.Value.Length != 6)
          {
            throw new System.ArgumentException("IPAWS Profile v1.0 requires that the value of a geoCode block with the valueName of SAME be in PSSCCC format.");
          }

          int psscccCode = 0;
          bool canParse = int.TryParse(geoCode.Value, out psscccCode);
          if (!canParse)
          {
            throw new System.ArgumentException("IPAWS Profile v1.0 requires that the value of a geoCode block with the valueName of SAME be in PSSCCC format.");
          }
        }
      }
    }

    /// <summary>
    /// Validates a CAP 1.1 message is IPAWS Profile 1.0 compliant
    /// </summary>
    private void ValidateToIPAWSProfilev10ForCAPv11()
    {
      if (this.info == null || this.info.Count < 1)
      {
        throw new System.ArgumentNullException("IPAWS Profile v1.0 requires at least one info block.");
      }

      this.ValidateIPAWSProfilev10ForCAPv11InfoBlocks();
    }

    /// <summary>
    /// Validates this CAP message to the IPAWS Profile
    /// </summary>
    private void ValidateIPAWSProfilev10ForCAPv12InfoBlocks()
    {
      if (this.info != null)
      {
        foreach (InfoType info in this.info)
        {
          if (info.EventCode == null || info.EventCode.Count < 1)
          {
            throw new System.ArgumentNullException("IPAWS Profile v1.0 requires at least one eventCode.");
          }

          if (info.Expires == DateTime.MinValue)
          {
            throw new System.ArgumentException("IPAWS Profile v1.0 requires the expires field be set.");
          }

          if (info.Area == null || info.Area.Count < 1)
          {
            throw new System.ArgumentNullException("IPAWS Profile v1.0 requires at least one area block.");
          }
        }
      }
    }

    /// <summary>
    /// Validates this Cap message for the IPAWS EAS Profile
    /// </summary>
    private void ValidateIPAWS_EASProfilev10ForCAPv12InfoBlocks()
    {
      if (this.info != null)
      {
        foreach (InfoType info in this.info)
        {
          if (info.EventCode != null)
          {
            bool foundSAMECode = false;

            foreach (NameValueType evt in info.EventCode)
            {
              if (evt.Name.Equals("SAME"))
              {
                if (!foundSAMECode)
                {
                  foundSAMECode = true;
                }
                else
                {
                  throw new System.ArgumentException("IPAWS EAS Profile v1.0 requires one and only one eventCode of type SAME.");
                }

                if (evt.Value.Length != 3)
                {
                  throw new System.ArgumentException("IPAWS EAS Profile v1.0 requires a three-letter SAME code.");
                }
              }
            }

            if (!foundSAMECode)
            {
              throw new System.ArgumentException("IPAWS EAS Profile v1.0 requires one and only one eventCode of type SAME.");
            }
          }

          if (info.Area == null)
          {
            throw new System.ArgumentNullException("IPAWS EAS Profile v1.0 requires at least one Area block.");
          }

          if (info.Parameter == null)
          {
            throw new System.ArgumentNullException("IPAWS EAS Profile v1.0 requires a parameter with the valueName of EAS-ORG");
          }
          else
          {
            bool foundEASORGParameter = false;
            foreach (NameValueType param in info.Parameter)
            {
              if (param.Name.Equals("EAS-ORG"))
              {
                if (!foundEASORGParameter)
                {
                  foundEASORGParameter = true;
                }
                else
                {
                  throw new System.ArgumentException("IPAWS EAS Profile v1.0 requires one and only one parameter with the valueName of EAS-ORG");
                }
              }
            }

            if (!foundEASORGParameter)
            {
              throw new System.ArgumentNullException("IPAWS EAS Profile v1.0 requires a parameter with the valueName of EAS-ORG");
            }
          }

          if (string.IsNullOrEmpty(info.Description))
          {
            throw new System.ArgumentNullException("IPAWS EAS Profile v1.0 requires an event description.");
          }
        }
      }
    }

    /// <summary>
    /// Validates this CAP message to the CMAS IPAWS profile
    /// </summary>
    private void ValidateIPAWS_CMASProfilev10ForCAPv12InfoBlocks()
    {
      DateTime sent = this.sentDateTime;

      if (this.info != null)
      {
        foreach (InfoType info in this.info)
        {
          DateTime expires = info.Expires;

          TimeSpan diff = expires - sent;

          if (diff.Hours > 24)
          {
            throw new System.ArgumentException("IPAWS CMAS Profile v1.0 requires the duration (Expires - Sent) of the alert not exceed 24 hours.");
          }

          foreach (AreaType area in info.Area)
          {
            if (area.Polygon != null && area.Polygon.Count > 100)
            {
              throw new System.ArgumentException("IPAWS CMAS Profile v1.0 requires a polygon have 100 points or less.");
            }
          }
        }
      }
    }
    #endregion
  }
}
