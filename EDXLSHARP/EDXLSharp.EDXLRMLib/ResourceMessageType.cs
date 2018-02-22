// ———————————————————————–
// <copyright file="ResourceMessageType.cs" company="EDXLSharp">
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
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the ResourceMessageType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ResourceMessageType : IContentObject, IGeoRSS
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
    /// Usage
    ///    REQUIRED, MUST be used once and only once
    ///  Definition
    ///    Each EDXL resource message contains an identifier that uniquely identifies the
    ///    resource message.
    ///  Comments 
    ///    The EDXL Distribution element contains the "Distribution ID", which identifies
    ///    the "container" for the distribution message information.
    /// </summary>
    private string messageID;

    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once
    ///  Definition 
    ///    The system stamped date and time the resource message was sent. (1) The date and
    ///    time is represented in [dateTime] format (e. g., "2002-05-24T16:49:00-07:00"
    ///    for 24 May 2002 at 16: 49 PDT). (2) Alphabetic time zone designators such
    ///    as “Z” MUST NOT be used. The time zone for UTC MUST be represented as “-00:00”
    ///    or “+00:00.
    ///  Comments 
    ///    Original requirement = ICS "Request Date/Time"
    /// </summary>
    private DateTime sentDateTime;

    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 102 of 174
    ///  Definition 
    ///    Specifies the purpose / type of resource content / payload being sent within the
    ///    Resource Messaging – element Reference Model
    ///  Constraints 
    ///    Value MUST be one of the following:
    ///    1. RequestResource
    ///    2. ResponseToRequestResource
    ///    3. RequisitionResource
    ///    4. CommitResource
    ///    5. RequestInformation
    ///    6. ResponseToRequestInformation
    ///    7. OfferUnsolicitedResource
    ///    8. ReleaseResource
    ///    9. RequestReturn
    ///    10. ResponseToRequestReturn
    ///    11. RequestQuote
    ///    12. ResponseToRequestQuote
    ///    13. RequestResourceDeploymentStatus
    ///    14. ReportResourceDeploymentStatus
    ///    15. RequestExtendedDeploymentDuration
    ///    16. ResponseToRequestExtendedDeploymentDuration
    /// </summary>
    private MessageType? messageContentType;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Text field used to specify the information requested in a request for information and
    ///    the response to a request for information. May also be used to include additional
    ///    information in other message types.
    ///  Constraints 
    ///    Conditional Usage:
    ///      o Required:
    ///          EDXLResourceMessage:messageContentType =
    ///          “RequestInformation”
    ///      o Optional:
    ///          Otherwise
    /// </summary>
    private string messageDescription;

    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once
    ///  Definition 
    ///    Each EDXL resource message contains a MessageID that uniquely identifies the
    ///    resource message. OriginatingMessageID identifies the MessageID of the first
    ///    message in a message sequence to which the message belongs. If the message is
    ///    itself the originating message in a new sequence, OriginatingMessageID will have
    ///    the same val as the MessageID element. In some other cases, the
    ///    OriginatingMessageID element will have the same val as the PrecedingMessageID
    ///    element. The OriginatingMessageID val essentially forms a unique identifier for a
    ///    group of related messages, linking them together so that the relationship between the
    ///    messages is made explicit and unambiguous (and threads of messages can be
    ///    tracked by resource management software).
    ///  Comments 
    ///    This MessageID is an EDXL-RM MessageID, not an EDXL-Distribution element
    ///    MessageID.
    /// </summary>
    private string originatingMessageID;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    The PrecedingMessageID identifies the message that immediately preceded the
    ///    current message in the message sequence. This MessageID is an EDXL-RM
    ///    MessageID not and EDXL-Distribution element MessageID.
    ///  Constraints • Conditional Usage:
    ///      o Required:
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “CommitResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestInformation”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestReturn”
    ///        EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///        Copyright © OASIS® 1993–2008 Page 104 of 174
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestQuote”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestExtendedDeploymentDuration”
    ///      o Optional:
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequisitionResource”
    ///        􀂃 EDXLResourceMessage:messageContentType = “Request
    ///        Information”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ReleaseResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestReturn”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestQuote”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestResourceDeploymentStatus”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ReportResourceDeploymentStatus”
    ///      o Not Applicable:
    ///        􀂃 Otherwise
    /// </summary>
    private string precedingMessageID;

    /// <summary>
    /// Identifies and describes the incident with which the message is
    /// 80 concerned;
    /// </summary>
    private List<IncidentInformationType> incidentInformation;

    /// <summary>
    /// Needed when a message updates or cancels a previous message
    /// </summary>
    private MessageRecallType messageRecall;

    /// <summary>
    /// Specifies applicable codes and specific funding information
    /// </summary>
    private List<FundingType> funding;

    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used at least once
    ///  Definition 
    ///    The contact associated with the resource message.
    ///  Comments 
    ///    Refer to Section 4.1.13.1 for ContactInformationType
    ///      • There may be more than one contact given – message sender, requester,
    ///      subject matter expert, approver, owner, etc.
    /// </summary>
    private List<ContactInformationType> contactInformation;

    /// <summary>
    /// Specifies the resource information or resource requirement
    /// </summary>
    private List<ResourceInformationType> resourceInformation;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResourceMessageType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ResourceMessageType()
    {
      this.contactInformation = new List<ContactInformationType>();
      this.funding = new List<FundingType>();
      this.resourceInformation = new List<ResourceInformationType>();
      this.incidentInformation = new List<IncidentInformationType>();
    }

    /// <summary>
    /// Initializes a new instance of the ResourceMessageType class and sets The RM Message Type
    /// </summary>
    /// <param name="type">MessageType of the RM Message</param>
    public ResourceMessageType(MessageType type)
    {
      this.contactInformation = new List<ContactInformationType>();
      this.messageContentType = type;
      this.funding = new List<FundingType>();
      this.resourceInformation = new List<ResourceInformationType>();
      this.incidentInformation = new List<IncidentInformationType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Each EDXL resource message contains an identifier that uniquely identifies the
    /// resource message.
    /// </summary>
    public string MessageID
    {
      get { return this.messageID; }
      set { this.messageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The system stamped date and time the resource message was sent. (1) The date and
    /// time is represented in [dateTime] format (e. g., "2002-05-24T16:49:00-07:00"
    /// for 24 May 2002 at 16: 49 PDT). (2) Alphabetic time zone designators such
    /// as “Z” MUST NOT be used. The time zone for UTC MUST be represented as “-00:00”
    /// or “+00:00.
    /// </summary>
    public DateTime SentDateTime
    {
      get
      {
        return this.sentDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.sentDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets the date and time when this message expires
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get { return this.SentDateTime.AddHours(24); }
    }

    /// <summary>
    /// Gets or sets
    /// Specifies the purpose / type of resource content / payload being sent within the
    /// Resource Messaging – element Reference Model
    /// </summary>
    public MessageType? MessageContentType
    {
      get { return this.messageContentType; }
      set { this.messageContentType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Text field used to specify the information requested in a request for information and
    /// the response to a request for information. May also be used to include additional
    /// information in other message types.
    /// </summary>
    public string MessageDescription
    {
      get { return this.messageDescription; }
      set { this.messageDescription = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Each EDXL resource message contains a MessageID that uniquely identifies the
    /// resource message. OriginatingMessageID identifies the MessageID of the first
    /// message in a message sequence to which the message belongs. If the message is
    /// itself the originating message in a new sequence, OriginatingMessageID will have
    /// the same val as the MessageID element. In some other cases, the
    /// OriginatingMessageID element will have the same val as the PrecedingMessageID
    /// element. The OriginatingMessageID val essentially forms a unique identifier for a
    /// group of related messages, linking them together so that the relationship between the
    /// messages is made explicit and unambiguous (and threads of messages can be
    /// tracked by resource management software).
    /// </summary>
    public string OriginatingMessageID
    {
      get { return this.originatingMessageID; }
      set { this.originatingMessageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The PrecedingMessageID identifies the message that immediately preceded the
    /// current message in the message sequence. This MessageID is an EDXL-RM
    /// MessageID not and EDXL-Distribution element MessageID.
    /// </summary>
    public string PrecedingMessageID
    {
      get { return this.precedingMessageID; }
      set { this.precedingMessageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Identifies and describes the incident with which the message is
    /// 80 concerned;
    /// </summary>
    public List<IncidentInformationType> IncidentInformation
    {
      get { return this.incidentInformation; }
      set { this.incidentInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Needed when a message updates or cancels a previous message
    /// </summary>
    public MessageRecallType MessageRecall
    {
      get { return this.messageRecall; }
      set { this.messageRecall = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Specifies applicable codes and specific funding information
    /// </summary>
    public List<FundingType> FundingType
    {
      get { return this.funding; }
      set { this.funding = value; }
    }

    /// <summary>
    /// Gets or sets
    /// List of the contact associated with the resource message.
    /// </summary>
    public List<ContactInformationType> ContactInformation
    {
      get { return this.contactInformation; }
      set { this.contactInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Specifies the resource information or resource requirement
    /// </summary>
    public List<ResourceInformationType> ResourceInformation
    {
      get { return this.resourceInformation; }
      set { this.resourceInformation = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    /// <returns>String to Process ContentKeyword Value From</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      if (ckw == (ValueList)null)
      {
        throw new ArgumentNullException("CKW");
      }

      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("EDXL-RM");
      if (this.messageContentType != null)
      {
        ckw.Value.Add("EDXL-RM " + this.messageContentType.ToString());
        return "EDXL-RM" + this.messageContentType.ToString();
      }

      return "EDXL-RM";
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (xwriter == null)
      {
        throw new ArgumentNullException("XMLWriter Can't Be Null");
      }

      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, this.messageContentType.ToString(), EDXLConstants.RM10MsgNamespace);
      xwriter.WriteAttributeString("xmlns", EDXLConstants.RM10Prefix, null, EDXLConstants.RM10Namespace);
      xwriter.WriteAttributeString("xmlns", EDXLConstants.XPILPrefix, null, EDXLConstants.XPIL10Namespace);
      xwriter.WriteAttributeString("xmlns", EDXLConstants.XALPrefix, null, EDXLConstants.XAL10Namespace);
      xwriter.WriteAttributeString("xmlns", EDXLConstants.GMLPrefix, null, EDXLConstants.GMLNamespace);

      if (!string.IsNullOrEmpty(this.messageID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "MessageID", EDXLConstants.RM10MsgNamespace, this.messageID);
      }

      if (this.sentDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "SentDateTime", EDXLConstants.RM10MsgNamespace, this.sentDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.messageContentType != null)
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "MessageContentType", EDXLConstants.RM10MsgNamespace, this.messageContentType.ToString());
      }

      if (!string.IsNullOrEmpty(this.messageDescription))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "MessageDescription", EDXLConstants.RM10MsgNamespace, this.messageDescription);
      }

      if (!string.IsNullOrEmpty(this.originatingMessageID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "OriginatingMessageID", EDXLConstants.RM10MsgNamespace, this.originatingMessageID);
      }

      if (!string.IsNullOrEmpty(this.precedingMessageID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "PrecedingMessageID", EDXLConstants.RM10MsgNamespace, this.precedingMessageID);
      }

      foreach (IncidentInformationType incident in this.incidentInformation)
      {
        incident.WriteToXML(xwriter);
      }

      if (this.messageRecall != null)
      {
        this.messageRecall.WriteToXML(xwriter);
      }

      foreach (FundingType fund in this.funding)
      {
        fund.WriteToXML(xwriter);
      }

      foreach (ContactInformationType contactInfo in this.contactInformation)
      {
        contactInfo.WriteXML(xwriter, "ContactInformation");
      }

      foreach (ResourceInformationType resinfo in this.resourceInformation)
      {
        resinfo.WriteToXML(xwriter, this.messageContentType);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootNode)
    {
      ContactInformationType contactinfotmp;
      FundingType fundtmp;
      IncidentInformationType incidenttemp;
      ResourceInformationType restmp;
      if (rootNode == null)
      {
        throw new ArgumentNullException("Input XML Node Can't Be Null");
      }

      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "MessageID":
            this.messageID = node.InnerText;
            break;
          case "SentDateTime":
            this.sentDateTime = DateTime.Parse(node.InnerText);
            if (this.sentDateTime.Kind == DateTimeKind.Unspecified)
            {
              this.sentDateTime = DateTime.MinValue;
              throw new ArgumentException("TimeZone Information Must Be Specified");
            }

            this.sentDateTime = this.sentDateTime.ToUniversalTime();
            break;
          case "MessageContentType":
            this.messageContentType = (MessageType)Enum.Parse(typeof(MessageType), node.InnerText);
            break;
          case "MessageDescription":
            this.messageDescription = node.InnerText;
            break;
          case "OriginatingMessageID":
            this.originatingMessageID = node.InnerText;
            break;
          case "PrecedingMessageID":
            this.precedingMessageID = node.InnerText;
            break;
          case "IncidentInformation":
            if (this.incidentInformation == null)
            {
              this.incidentInformation = new List<IncidentInformationType>();
            }

            incidenttemp = new IncidentInformationType();
            incidenttemp.ReadXML(node);
            this.incidentInformation.Add(incidenttemp);
            break;
          case "MessageRecall":
            this.messageRecall = new MessageRecallType();
            this.messageRecall.ReadXML(node);
            break;
          case "Funding":
            if (this.funding == null)
            {
              this.funding = new List<FundingType>();
            }

            fundtmp = new FundingType();
            fundtmp.ReadXML(node);
            this.funding.Add(fundtmp);
            break;
          case "ContactInformation":
            if (this.contactInformation == null)
            {
              this.contactInformation = new List<ContactInformationType>();
            }

            contactinfotmp = new ContactInformationType();
            contactinfotmp.ReadXML(node);
            this.contactInformation.Add(contactinfotmp);
            break;
          case "ResourceInformation":
            if (this.resourceInformation == null)
            {
              this.resourceInformation = new List<ResourceInformationType>();
            }

            restmp = new ResourceInformationType();
            restmp.ReadXML(node, this.messageContentType);
            this.resourceInformation.Add(restmp);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ResourceMessageType");
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
      bool authorset = false, geoset = false;
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
      foreach (ContactInformationType ciq in this.contactInformation)
      {
        if (!authorset && ciq.ContactRole != null && !string.IsNullOrEmpty(ciq.ContactDescription))
        {
          myitem.Authors.Add(new SyndicationPerson(ciq.ContactDescription, ciq.ContactRole.ToString(), string.Empty));
          authorset = true;
        }

        if (!geoset && ciq.ContactLocation != null && ciq.ContactLocation.TargetArea != null)
        {
          ciq.ContactLocation.TargetArea.ToGeoRSS(myitem);
          geoset = true;
        }

        if (authorset && geoset)
        {
          break;
        }
      }

      if (!authorset)
      {
        myitem.Authors.Add(new SyndicationPerson("testrm@oasis-open.org", "AutoGenerated", string.Empty));
      }

      myitem.Categories.Add(new SyndicationCategory(EDXLConstants.RMSyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.sentDateTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "RM/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;
      myitem.Summary = new TextSyndicationContent("MessageID: " + this.messageID);
      myitem.Title = new TextSyndicationContent(this.messageContentType.ToString() + " (EDXL-RM)");
      contentstr.AppendLine("MessageID: " + this.messageID);
      contentstr.AppendLine("Sent: " + this.sentDateTime.ToString("o"));
      if (this.resourceInformation.Count > 0)
      {
        foreach (ResourceInformationType resx in this.resourceInformation)
        {
          resx.ToGeoRSS(myitem, contentstr);
        }
      }

      myitem.Content = new TextSyndicationContent(contentstr.ToString());
      items.Add(myitem);
    }

    /// <summary>
    /// Validates The Current RM Object Against The XSD Schema File
    /// </summary>
    public void ValidateToSchema()
    {
      schemaErrors = 0;
      XmlReader vr;
      XmlReaderSettings xs = new XmlReaderSettings();
      XmlSchemaSet coll = new XmlSchemaSet();
      StringReader xsdsr = new StringReader(string.Empty);
      switch (this.messageContentType)
      {
        case MessageType.CommitResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMCommitResource);
          break;
        case MessageType.OfferUnsolicitedResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMOfferUnsolicitedResource);
          break;
        case MessageType.ReleaseResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMReleaseResource);
          break;
        case MessageType.ReportResourceDeploymentStatus:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMReportResourceDeploymentStatus);
          break;
        case MessageType.RequestExtendedDeploymentDuration:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestExtendedDeploymentDuration);
          break;
        case MessageType.RequestInformation:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestInformation);
          break;
        case MessageType.RequestQuote:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestQuote);
          break;
        case MessageType.RequestResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestResource);
          break;
        case MessageType.RequestResourceDeploymentStatus:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestResourceDeploymentStatus);
          break;
        case MessageType.RequestReturn:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequestReturn);
          break;
        case MessageType.RequisitionResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMRequisitionResource);
          break;
        case MessageType.ResponseToRequestExtendedDeploymentDuration:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMResponseToRequestExtendedDeploymentDuration);
          break;
        case MessageType.ResponseToRequestInformation:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMResponseToRequestInformation);
          break;
        case MessageType.ResponseToRequestQuote:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMResponseToRequestQuote);
          break;
        case MessageType.ResponseToRequestResource:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMResponseToRequestResource);
          break;
        case MessageType.ResponseToRequestReturn:
          xsdsr = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMResponseToRequestReturn);
          break;
      }

      Stream xstream = new MemoryStream();
      XmlWriter xw = XmlWriter.Create(xstream);
      this.WriteXML(xw);
      XmlReader xsdread = XmlReader.Create(xsdsr);
      coll.Add(EDXLConstants.RM10MsgNamespace, xsdread);
      StringReader commontypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.CommonTypes);
      XmlReader commonxsd = XmlReader.Create(commontypesread);
      coll.Add(EDXLConstants.CIQCommonTypesNamespace, commonxsd);
      StringReader rmcommontypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.EDXL_RMCommonTypes);
      XmlReader rmcommonxsd = XmlReader.Create(rmcommontypesread);
      coll.Add(EDXLConstants.RM10Namespace, rmcommonxsd);
      StringReader geooasisread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.geo_oasis);
      XmlReader geooasisxsd = XmlReader.Create(geooasisread);
      coll.Add(EDXLConstants.GeoOASISWhereNamespace, geooasisxsd);
      StringReader gmlread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.gml_oasis);
      XmlReader gmlxsd = XmlReader.Create(gmlread);
      coll.Add(EDXLConstants.GMLNamespace, gmlxsd);
      StringReader xalread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xAL);
      XmlReader xalxsd = XmlReader.Create(xalread);
      coll.Add(EDXLConstants.XAL10Namespace, xalxsd);
      StringReader xaltypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xAL_types);
      XmlReader xaltypesxsd = XmlReader.Create(xaltypesread);
      coll.Add(EDXLConstants.XAL10Namespace, xaltypesxsd);
      StringReader xlink2read = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xlink_2003_12_31);
      XmlReader xlink2xsd = XmlReader.Create(xlink2read);
      coll.Add("http://www.w3.org/1999/xlink1", xlink2xsd);
      StringReader xlinksread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xlinks);
      XmlReader xlinksxsd = XmlReader.Create(xlinksread);
      coll.Add("http://www.w3.org/1999/xlink", xlinksxsd);
      StringReader xnalread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xNAL);
      XmlReader xnalxsd = XmlReader.Create(xnalread);
      coll.Add(EDXLConstants.XNALNamespace, xnalxsd);
      StringReader xnaltypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xNAL_types);
      XmlReader xnaltypesxsd = XmlReader.Create(xnaltypesread);
      coll.Add(EDXLConstants.XNALNamespace, xnaltypesxsd);
      StringReader xnlread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xNL);
      XmlReader xnlxsd = XmlReader.Create(xnlread);
      coll.Add(EDXLConstants.XNL10Namespace, xnlxsd);
      StringReader xnltypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xNL_types);
      XmlReader xnltypesxsd = XmlReader.Create(xnltypesread);
      coll.Add(EDXLConstants.XNL10Namespace, xnltypesxsd);
      StringReader xpilread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xPIL);
      XmlReader xpilxsd = XmlReader.Create(xpilread);
      coll.Add(EDXLConstants.XPIL10Namespace, xpilxsd);
      StringReader xpiltypesread = new StringReader(EDXLSharp.EDXLRMLib.Properties.Resources.xPIL_types);
      XmlReader xpiltypesxsd = XmlReader.Create(xpiltypesread);
      coll.Add(EDXLConstants.XPIL10Namespace, xpiltypesxsd);
      xs.Schemas.Add(coll);
      xs.ValidationType = ValidationType.Schema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      vr = XmlReader.Create(xstream, xs);
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
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.messageID))
      {
        throw new ArgumentNullException("MessageID is required and can't be null");
      }

      if (this.sentDateTime == DateTime.MinValue)
      {
        throw new ArgumentNullException("SentDateTime is required and can't be null");
      }

      if (this.messageContentType == null)
      {
        throw new ArgumentNullException("MessageContentType is required and can't be null");
      }
      else
      {
        switch (this.messageContentType)
        {
          case MessageType.RequestInformation:
            if (string.IsNullOrEmpty(this.messageDescription))
            {
              throw new ArgumentNullException("MessageDescription is required and can't be null if MessageContentType is RequestInformation");
            }

            break;
          case MessageType.RequisitionResource:
            if (this.funding.Count == 0)
            {
              throw new ArgumentNullException("Funding is required and can't be null if MessageContentType is RequisitionResource");
            }

            break;
          case MessageType.OfferUnsolicitedResource:
            if (this.funding.Count != 0)
            {
              throw new ArgumentNullException("Funding is not applicable if MessageContentType is OfferUnsolicitedResource");
            }

            break;
          default:
            break;
        }
      }

      if (string.IsNullOrEmpty(this.originatingMessageID))
      {
        throw new ArgumentNullException("OriginatingMessageID is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.precedingMessageID) && (this.messageContentType == MessageType.ResponseToRequestResource || this.messageContentType == MessageType.CommitResource || this.messageContentType == MessageType.ResponseToRequestInformation || this.messageContentType == MessageType.ResponseToRequestReturn || this.messageContentType == MessageType.ResponseToRequestQuote || this.messageContentType == MessageType.ResponseToRequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("PrecedingMessageID is required and can't be null if MessageContentType is a number of choices");
      }

      if (!string.IsNullOrEmpty(this.precedingMessageID) && (this.messageContentType == MessageType.RequestResource || this.messageContentType == MessageType.OfferUnsolicitedResource))
      {
        throw new ArgumentNullException("PrecedingMessageID is not applicable if MessageContentType is a number of choices");
      }

      if (this.contactInformation.Count == 0)
      {
        throw new ArgumentNullException("ContactInformation is required and can't be null");
      }

      if (this.resourceInformation.Count == 0 && (this.messageContentType != MessageType.RequestInformation || this.messageContentType != MessageType.ResponseToRequestInformation))
      {
        throw new ArgumentNullException("ResourceInformation is required and can't be null");
      }
    }
    #endregion

    #region Private Member Functions

    /// <summary>
    /// Callback Function For Schema Validation Delegate
    /// </summary>
    /// <param name="sender">Object Causing the Event Firing</param>
    /// <param name="args">Arguments that contain the schema validation errors</param>
    private static void SchemaErrorCallback(object sender, ValidationEventArgs args)
    {
      if (args.Severity == XmlSeverityType.Error)
      {
        schemaErrorString = schemaErrorString + args.Message + "\r\n";
        schemaErrors++;
      }
    }
    #endregion
  }
}
