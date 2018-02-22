// ———————————————————————–
// <copyright file="InfoType.cs" company="EDXLSharp">
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
using System.ComponentModel;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The info segment describes an anticipated or actual event in terms of its urgency (time available to prepare),
  /// severity (intensity of impact) and certainty (confidence in the observation or prediction),
  /// as well as providing both categorical and textual descriptions of the subject event.  
  /// It may also provide instructions for appropriate response by message recipients and various other 
  /// details (hazard duration, technical parameters, contact information, links to additional information sources, etc.)  
  /// Multiple info segments may be used to describe differing parameters (e.g., for different probability or intensity “bands”) 
  /// or to provide the information in multiple languages. 
  /// </summary>
  [Serializable]
  public partial class InfoType
  {
    /// <summary>
    /// Regular expression representing valid values for language type as per RFC3066
    /// </summary>
    private static Regex languageRegex = new Regex("^[A-Za-z]{1,8}(-[A-Za-z0-9]{1,8})*$", RegexOptions.Compiled);

    #region Private Member Variables

    /// <summary>
    /// Local Copy Of DateTime Object for Default Value
    /// </summary>
    private DateTime sent;

    /// <summary>
    /// The code denoting the language of the info sub-element of the alert message (OPTIONAL)
    /// </summary>
    private string language;

    /// <summary>
    /// The code denoting the category of the subject event of the alert message (REQUIRED)
    /// </summary>
    private List<CategoryType> category;

    /// <summary>
    /// The text denoting the type of the subject event of the alert message (REQUIRED)
    /// </summary>
    private string eventType;

    /// <summary>
    /// The code denoting the type of action recommended for the target audience (OPTIONAL)
    /// </summary>
    private List<ResponseType> responseType;

    /// <summary>
    /// The code denoting the urgency of the subject event of the alert message (REQUIRED)
    /// </summary>
    private UrgencyType? urgency;

    /// <summary>
    /// The code denoting the severity of the subject event of the alert message (REQUIRED)
    /// </summary>
    private SeverityType? severity;

    /// <summary>
    /// The code denoting the certainty of the subject event of the alert message (REQUIRED)
    /// </summary>
    private CertaintyType? certainty;

    /// <summary>
    /// The text describing the intended audience of the alert message (OPTIONAL)
    /// </summary>
    private string audience;

    /// <summary>
    /// A system-specific code identifying the event type of the alert message (OPTIONAL)
    /// </summary>
    private List<NameValueType> eventCode;

    /// <summary>
    /// The effective time of the information of the alert message (OPTIONAL)
    /// </summary>
    private DateTime effective;

    /// <summary>
    /// The expected time of the beginning of the subject event of the alert message (OPTIONAL)
    /// </summary>
    private DateTime infoOnSet;

    /// <summary>
    /// The expiry time of the information of the alert message (OPTIONAL)
    /// </summary>
    private DateTime expires;

    /// <summary>
    /// The text naming the originator of the alert message (OPTIONAL)
    /// </summary>
    private string senderName;

    /// <summary>
    /// The text headline of the alert message (OPTIONAL)
    /// </summary>
    private string headline;

    /// <summary>
    /// The text describing the subject event of the alert message (OPTIONAL)
    /// </summary>
    private string description;

    /// <summary>
    /// The text describing the recommended action to be taken by recipients of the alert message (OPTIONAL)
    /// </summary>
    private string instruction;

    /// <summary>
    /// The identifier of the hyperlink associating additional information with the alert message (OPTIONAL)
    /// </summary>
    private Uri web;

    /// <summary>
    /// The text describing the contact for follow-up and confirmation of the alert message (OPTIONAL)
    /// </summary>
    private string contact;

    /// <summary>
    /// A system-specific additional parameter associated with the alert message (OPTIONAL)
    /// </summary>
    private List<NameValueType> parameter;

    /// <summary>
    /// The container for all component parts of the resource sub-element of the info sub-element of the alert element (OPTIONAL)
    /// </summary>
    private List<ResourceType> resource;

    /// <summary>
    /// The container for all component parts of the area sub-element of the info sub-element of the alert message (OPTIONAL)
    /// </summary>
    private List<AreaType> area;

    /// <summary>
    /// The namespace of the CAP element
    /// </summary>
    private string capNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the InfoType class 
    /// Default Constructor - Initializes Lists
    /// </summary>
    public InfoType()
    {
      this.category = new List<CategoryType>();
      this.responseType = new List<ResponseType>();
      this.eventCode = new List<NameValueType>();
      this.parameter = new List<NameValueType>();
      this.resource = new List<ResourceType>();
      this.area = new List<AreaType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The code denoting the language of the info sub-element of the alert message
    /// </summary>
    public string Language
    {
      get
      {
        return this.language;
      }

      set
      {
        this.CheckRFC3066(value);
        this.language = value;
      }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the category of the subject event of the alert message
    /// </summary>
    public List<CategoryType> Category
    {
      get { return this.category; }
      set { this.category = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text denoting the type of the subject event of the alert message
    /// </summary>
    public string Event
    {
      get { return this.eventType; }
      set { this.eventType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the type of action recommended for the target audience
    /// </summary>
    public List<ResponseType> ResponseType
    {
      get { return this.responseType; }
      set { this.responseType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the urgency of the subject event of the alert message
    /// </summary>
    public UrgencyType? Urgency
    {
      get { return this.urgency; }
      set { this.urgency = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the severity of the subject event of the alert message
    /// </summary>
    public SeverityType? Severity
    {
      get { return this.severity; }
      set { this.severity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The code denoting the certainty of the subject event of the alert message
    /// </summary>
    public CertaintyType? Certainty
    {
      get { return this.certainty; }
      set { this.certainty = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the intended audience of the alert message
    /// </summary>
    public string Audience
    {
      get { return this.audience; }
      set { this.audience = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A system-specific code identifying the event type of the alert message
    /// </summary>
    public List<NameValueType> EventCode
    {
      get { return this.eventCode; }
      set { this.eventCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The effective time of the information of the alert message
    /// </summary>
    public DateTime Effective
    {
      get
      {
        return this.effective;
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.effective = value;
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// The expected time of the beginning of the subject event of the alert message
    /// </summary>
    public DateTime OnSet
    {
      get
      {
        return this.infoOnSet;
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.infoOnSet = value;
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// The expiry time of the information of the alert message
    /// </summary>
    public DateTime Expires
    {
      get
      {
        return this.expires;
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.expires = value;
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// The text naming the originator of the alert message
    /// </summary>
    public string SenderName
    {
      get { return this.senderName; }
      set { this.senderName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text headline of the alert message
    /// </summary>
    public string Headline
    {
      get { return this.headline; }
      set { this.headline = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the subject event of the alert message
    /// </summary>
    public string Description
    {
      get { return this.description; }
      set { this.description = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the recommended action to be taken by recipients of the alert message
    /// </summary>
    public string Instruction
    {
      get { return this.instruction; }
      set { this.instruction = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The identifier of the hyperlink associating additional information with the alert message
    /// </summary>
    [XmlIgnore]
    public Uri Web
    {
        get { return this.web; }
        set { this.web = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable string of the web string
    /// </summary>
    [XmlAttribute("web")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string WebString
    {
        get { return this.web == null ? null : this.web.ToString(); }
        set { this.web = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// The text describing the contact for follow-up and confirmation of the alert message
    /// </summary>
    public string Contact
    {
      get { return this.contact; }
      set { this.contact = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A system-specific additional parameter associated with the alert message
    /// </summary>
    public List<NameValueType> Parameter
    {
      get { return this.parameter; }
      set { this.parameter = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The container for all component parts of the resource sub-element of the info sub-element of the alert element
    /// </summary>
    public List<ResourceType> Resource
    {
      get { return this.resource; }
      set { this.resource = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The container for all component parts of the area sub-element of the info sub-element of the alert message 
    /// </summary>
    public List<AreaType> Area
    {
      get { return this.area; }
      set { this.area = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The CAP namespace for serialization
    /// </summary>
    [XmlIgnore]
    public string CapNamespace
    {
      get { return this.capNamespace; }
      set { this.capNamespace = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (this.category.Count == 0)
      {
        throw new ArgumentNullException("Event Category is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.eventType))
      {
        throw new ArgumentNullException("Event Type is required and can't be null");
      }

      if (this.urgency == null)
      {
        throw new ArgumentNullException("Urgency is required and can't be null");
      }

      if (this.severity == null)
      {
        throw new ArgumentNullException("Severity is required and can't be null");
      }

      if (this.certainty == null)
      {
        throw new ArgumentNullException("Certainty is required and can't be null");
      }

      // To handle default val of effective date/time
      if (this.effective == DateTime.MinValue)
      {
        this.effective = this.sent;
      }

      if (!string.IsNullOrEmpty(this.language))
      {
        this.CheckRFC3066(this.language);
      }
    }
    #endregion

    #region Private Member Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="sentDateTime">DateTime Object From Parent for Default Value</param>
    internal void WriteXML(XmlWriter xwriter, DateTime sentDateTime)
    {
      this.Validate();

      if (string.IsNullOrEmpty(this.capNamespace))
      {
        this.capNamespace = EDXLConstants.CAP12Namespace;
      }

      if (!string.IsNullOrEmpty(this.language))
      {
        xwriter.WriteElementString("language", this.capNamespace, this.language);
      }

      if (this.category.Count != 0)
      {
        foreach (CategoryType cat in this.category)
        {
          xwriter.WriteElementString("category", this.capNamespace, cat.ToString());
        }
      }

      xwriter.WriteElementString("event", this.capNamespace, this.eventType);
      if (this.responseType.Count != 0)
      {
        foreach (ResponseType type in this.responseType)
        {
          xwriter.WriteElementString("responseType", this.capNamespace, type.ToString());
        }
      }

      xwriter.WriteElementString("urgency", this.capNamespace, this.urgency.ToString());
      xwriter.WriteElementString("severity", this.capNamespace, this.severity.ToString());
      xwriter.WriteElementString("certainty", this.capNamespace, this.certainty.ToString());
      if (!string.IsNullOrEmpty(this.audience))
      {
        xwriter.WriteElementString("audience", this.capNamespace, this.audience.ToString());
      }

      if (this.eventCode.Count != 0)
      {
        foreach (NameValueType name_type in this.eventCode)
        {
          xwriter.WriteStartElement("eventCode", this.capNamespace);
          name_type.CapNamespace = this.capNamespace;
          name_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      // To handle default val of effective date/time
      if (this.effective != DateTime.MinValue)
      {
        xwriter.WriteElementString("effective", this.capNamespace, this.effective.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.infoOnSet != DateTime.MinValue)
      {
        xwriter.WriteElementString("onset", this.capNamespace, this.infoOnSet.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.expires != DateTime.MinValue)
      {
        xwriter.WriteElementString("expires", this.capNamespace, this.expires.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (!string.IsNullOrEmpty(this.senderName))
      {
        xwriter.WriteElementString("senderName", this.capNamespace, this.senderName);
      }

      if (!string.IsNullOrEmpty(this.headline))
      {
        xwriter.WriteElementString("headline", this.capNamespace, this.headline);
      }

      if (!string.IsNullOrEmpty(this.description))
      {
        xwriter.WriteElementString("description", this.capNamespace, this.description);
      }

      if (!string.IsNullOrEmpty(this.instruction))
      {
        xwriter.WriteElementString("instruction", this.capNamespace, this.instruction);
      }

      if (this.web != null)
      {
        xwriter.WriteElementString("web", this.capNamespace, this.web.ToString());
      }

      if (!string.IsNullOrEmpty(this.contact))
      {
        xwriter.WriteElementString("contact", this.capNamespace, this.contact);
      }

      if (this.parameter.Count != 0)
      {
        foreach (NameValueType name_type in this.parameter)
        {
          xwriter.WriteStartElement("parameter", this.capNamespace);
          name_type.CapNamespace = this.capNamespace;
          name_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      if (this.resource.Count != 0)
      {
        foreach (ResourceType res_type in this.resource)
        {
          xwriter.WriteStartElement("resource", this.capNamespace);
          res_type.CapNamespace = this.capNamespace;
          res_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      if (this.area.Count != 0)
      {
        foreach (AreaType area_type in this.area)
        {
          xwriter.WriteStartElement("area", this.capNamespace);
          area_type.CapNamespace = this.capNamespace;
          area_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the Root Object Element</param>
    /// <param name="sentDateTime">DateTime From Parent for Default Value</param>
    internal void ReadXML(XmlNode rootNode, DateTime sentDateTime)
    {
      ResourceType resourcetypetmp;
      AreaType areatypetmp;
      NameValueType eventcodetmp, parametertmp;
      this.sent = sentDateTime;
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        if (node.InnerText != string.Empty)
        {
          switch (node.LocalName)
          {
            case "language":
              this.language = node.InnerText;
              break;
            case "category":
              this.category.Add((CategoryType)Enum.Parse(typeof(CategoryType), node.InnerText));
              break;
            case "event":
              this.eventType = node.InnerText;
              break;
            case "responseType":
              this.responseType.Add((ResponseType)Enum.Parse(typeof(ResponseType), node.InnerText));
              break;
            case "urgency":
              this.urgency = (UrgencyType)Enum.Parse(typeof(UrgencyType), node.InnerText);
              break;
            case "severity":
              this.severity = (SeverityType)Enum.Parse(typeof(SeverityType), node.InnerText);
              break;
            case "certainty":
              this.certainty = (CertaintyType)Enum.Parse(typeof(CertaintyType), node.InnerText);
              break;
            case "audience":
              this.audience = node.InnerText;
              break;
            case "eventCode":
              eventcodetmp = new NameValueType();
              eventcodetmp.ReadXML(node);
              this.eventCode.Add(eventcodetmp);
              break;
            case "effective":
              this.effective = DateTime.Parse(node.InnerText);
              if (this.effective.Kind == DateTimeKind.Unspecified)
              {
                this.effective = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.effective = this.effective.ToUniversalTime();
              break;
            case "onset":
              this.infoOnSet = DateTime.Parse(node.InnerText);
              if (this.infoOnSet.Kind == DateTimeKind.Unspecified)
              {
                this.infoOnSet = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.infoOnSet = this.infoOnSet.ToUniversalTime();
              break;
            case "expires":
              this.expires = DateTime.Parse(node.InnerText);
              if (this.expires.Kind == DateTimeKind.Unspecified)
              {
                this.expires = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.expires = this.expires.ToUniversalTime();
              break;
            case "senderName":
              this.senderName = node.InnerText;
              break;
            case "headline":
              this.headline = node.InnerText;
              break;
            case "description":
              this.description = node.InnerText;
              break;
            case "instruction":
              this.instruction = node.InnerText;
              break;
            case "web":
              this.web = new Uri(node.InnerText);
              break;
            case "contact":
              this.contact = node.InnerText;
              break;
            case "parameter":
              parametertmp = new NameValueType();
              parametertmp.ReadXML(node);
              this.parameter.Add(parametertmp);
              break;
            case "resource":
              resourcetypetmp = new ResourceType();
              resourcetypetmp.ReadXML(node);
              this.resource.Add(resourcetypetmp);
              break;
            case "area":
              areatypetmp = new AreaType();
              areatypetmp.ReadXML(node);
              this.area.Add(areatypetmp);
              break;
            case "#comment":
              break;
            default:
              throw new FormatException("Invalid value: " + node.Name + " found in Info Type");
          }
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    /// <param name="contentstr">Content StringBuilder for the Content of the item</param>
    internal void ToGeoRSS(SyndicationItem myitem, StringBuilder contentstr)
    {
      StringBuilder sbtemp = new StringBuilder();
      foreach (CategoryType cat in this.category)
      {
        sbtemp.Append(cat.ToString() + ", ");
      }

      contentstr.AppendLine("Category: " + sbtemp.ToString().Remove(sbtemp.ToString().LastIndexOf(", ")));
      contentstr.AppendLine("Event: " + this.eventType);
      if (this.responseType.Count > 0)
      {
        sbtemp = new StringBuilder();
        foreach (ResponseType resp in this.responseType)
        {
          sbtemp.Append(resp.ToString() + ", ");
        }

        contentstr.AppendLine("Response Type: " + sbtemp.ToString().Remove(sbtemp.ToString().LastIndexOf(", ")));
      }

      contentstr.AppendLine("Urgency: " + this.urgency.ToString());
      contentstr.AppendLine("Severity: " + this.severity.ToString());
      contentstr.AppendLine("Expires: " + this.expires.ToUniversalTime().ToString());
      foreach (AreaType area in this.area)
      {
        // Have to do this funky workaround due to the wacky structure of area here...
        StringBuilder output = new StringBuilder();
        XmlWriterSettings xsettings = new XmlWriterSettings();
        xsettings.Indent = true;
        xsettings.IndentChars = "\t";
        xsettings.OmitXmlDeclaration = true;
        XmlWriter xwriter = XmlWriter.Create(output, xsettings);
        xwriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
        area.ToGeoRSS(xwriter);
        xwriter.WriteEndElement();
        xwriter.Flush();
        xwriter.Close();
        MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
        myitem.ElementExtensions.Add(XmlReader.Create(ms));
      }
    }

    /// <summary>
    /// Checks Input String For Compliance to RFC3066
    /// </summary>
    /// <param name="s">String in the form xx-xx</param>
    private void CheckRFC3066(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        throw new ArgumentNullException("Input string can't be null");
      }

      if (!languageRegex.IsMatch(s))
      {
        throw new ArgumentException("Language string is incorrect. Must comply with RFC3066.\n" + s);
      }
    }
    #endregion
  }
}