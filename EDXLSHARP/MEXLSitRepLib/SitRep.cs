// ———————————————————————–
// <copyright file="SitRep.cs" company="EDXLSharp">
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
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Schema;
using EDXLSharp;
using EDXLSharp.CIQLib;
using GeoOASISWhereLib;
using MEXLSitRep;

namespace MEXLSitRepLib
{
  /// <summary>
  /// SitRep root element Class
  /// </summary>
  [Serializable]
  public partial class SitRep : IContentObject, IGeoRSS
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
    /// Unique ID for this message
    /// </summary>
    private string messageID;

    /// <summary>
    /// Date and Time this SitRep report was prepared
    /// </summary>
    private DateTime preparedDateTime;

    /// <summary>
    /// Who prepared this SitRep report
    /// </summary>
    private PersonDetails preparedBy;

    /// <summary>
    /// Who authorized generation and transmission of this SitRep report
    /// </summary>
    private PersonDetails authorizedBy;

    /// <summary>
    /// Simply states the purpose of this Situation Report.
    /// May contain description information regarding why the report is being sent
    /// and required response or action, if any.
    /// </summary>
    private string reportPurpose;

    /// <summary>
    /// A unique number for reporting an incident or event used to identify each
    /// unique or updated report instance.  Used to support report tracking.
    /// </summary>
    private string reportNumber;

    /// <summary>
    /// This indicates the current version of the SitRep report being submitted
    /// </summary>
    private string reportVersion;

    /// <summary>
    /// Location of the Observation
    /// </summary>
    private GeoOASISWhere reportLocation;

    /// <summary>
    /// Indicates Which Report Type is Carried within this SitRep Message
    /// </summary>
    private SitRepReportType? messageReportType;

    /// <summary>
    /// Time of Observation or Beginning of the Timespan of the Observation
    /// </summary>
    private DateTime fromDateTime;

    /// <summary>
    /// End of a TimeSpan of Observation
    /// </summary>
    private DateTime todateTime;

    /// <summary>
    /// The importance and necessity of the SitRep message.
    /// </summary>
    private UrgencyType? urgency;

    /// <summary>
    /// Observer's Certainty of their Observation
    /// </summary>
    private CertaintyType? certainty;

    /// <summary>
    /// Textual needs, expectations or description of what the “Prepared by”
    /// is planning to do next 
    /// </summary>
    private string actionPlan;

    /// <summary>
    /// The name, number or other identifier of the incident to which the current message refers,
    /// that has been assigned to the incident by an authorized agency based on current guidance,
    /// as the incident number may vary by jurisdiction and profession (e.g. law enforcement versus Fire).
    /// The incident number may be a computer aided dispatch number, an accounting number,
    /// a disaster declaration number, or a combination of the state, unit/agency, and dispatch system number.
    /// </summary>
    private string incidentID;

    /// <summary>
    ///  Specification of a specific title for the SitRep report other than or in addition to the “MessageReportType”.  
    /// </summary>
    private string reportTitle;

    /// <summary>
    /// Message ID of the Message That This Message Was Originally Developed From
    /// </summary>
    private string originatingMessageID;

    /// <summary>
    /// Message ID of the Message That Preceded This One
    /// </summary>
    private string precedingMessageID;

    /// <summary>
    /// Time and Method of next contact or report planned by the 
    /// “Prepared by” for the purpose of providing updated or additional information.
    /// </summary>
    private DateTime nextContact;

    /// <summary>
    /// Report Contained Within This SitRep Message
    /// </summary>
    private ISitRepReport report;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the SitRep class
    /// Default Constructor
    /// </summary>
    public SitRep()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Report Contained Within This SitRep Message
    /// </summary>
    public ISitRepReport Report
    {
      get { return this.report; }
      set { this.report = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Time and Method of next contact or report planned by the 
    /// “Prepared by” for the purpose of providing updated or additional information.
    /// </summary>
    public DateTime NextContact
    {
      get { return this.nextContact; }
      set { this.nextContact = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The name, number or other identifier of the incident to which the current message refers,
    /// that has been assigned to the incident by an authorized agency based on current guidance,
    /// as the incident number may vary by jurisdiction and profession (e.g. law enforcement versus Fire).
    /// The incident number may be a computer aided dispatch number, an accounting number,
    /// a disaster declaration number, or a combination of the state, unit/agency, and dispatch system number.
    /// </summary>
    public string IncidentID
    {
      get { return this.incidentID; }
      set { this.incidentID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Textual needs, expectations or description of what the “Prepared by”
    /// is planning to do next 
    /// </summary>
    public string ActionPlan
    {
      get { return this.actionPlan; }
      set { this.actionPlan = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The importance and necessity of the SitRep message.
    /// </summary>
    public UrgencyType? Urgency
    {
      get { return this.urgency; }
      set { this.urgency = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Indicates Which Report Type is Carried within this SitRep Message
    /// </summary>
    public SitRepReportType? MessageReportType
    {
      get { return this.messageReportType; }
      set { this.messageReportType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// This indicates the current version of the SitRep report being submitted
    /// </summary>
    public string ReportVersion
    {
      get { return this.reportVersion; }
      set { this.reportVersion = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string ReportTitle
    {
      get { return this.reportTitle; }
      set { this.reportTitle = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A unique number for reporting an incident or event used to identify each
    /// unique or updated report instance.  Used to support report tracking.
    /// </summary>
    public string ReportNumber
    {
      get { return this.reportNumber; }
      set { this.reportNumber = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Simply states the purpose of this Situation Report.
    /// May contain description information regarding why the report is being sent
    /// and required response or action, if any.
    /// </summary>
    public string ReportPurpose
    {
      get { return this.reportPurpose; }
      set { this.reportPurpose = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Who authorized generation and transmission of this SitRep report
    /// </summary>
    public PersonDetails AuthorizedBy
    {
      get { return this.authorizedBy; }
      set { this.authorizedBy = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Who prepared this SitRep report
    /// </summary>
    public PersonDetails PreparedBy
    {
      get { return this.preparedBy; }
      set { this.preparedBy = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Date and Time this SitRep report was prepared
    /// </summary>
    public DateTime PreparedDateTime
    {
      get { return this.preparedDateTime; }
      set { this.preparedDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Message ID of the Message That Preceded This One
    /// </summary>
    public string PrecedingMessageID
    {
      get { return this.precedingMessageID; }
      set { this.precedingMessageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Message ID of the Message That This Message Was Originally Developed From
    /// </summary>
    public string OriginatingMessageID
    {
      get { return this.originatingMessageID; }
      set { this.originatingMessageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Observer's Certainty of their Observation
    /// </summary>
    public CertaintyType? Certainty
    {
      get { return this.certainty; }
      set { this.certainty = value; }
    }

    /// <summary>
    /// Gets or sets
    /// End of a TimeSpan of Observation
    /// </summary>
    public DateTime ToDateTime
    {
      get
      {
        return this.todateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.todateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// Time of Observation or Beginning of the Timespan of the Observation
    /// </summary>
    public DateTime FromDateTime
    {
      get
      {
        return this.fromDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.fromDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets the date and time this message is no longer valid
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get { return this.ToDateTime; }
    }

    /// <summary>
    /// Gets or sets
    /// Unique ID for this message
    /// </summary>
    public string MessageID
    {
      get { return this.messageID; }
      set { this.messageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Location of the Observation
    /// </summary>
    public GeoOASISWhere ReportLocation
    {
      get { return this.reportLocation; }
      set { this.reportLocation = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    /// <returns>String to Process ContentKeyWord Value From</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("MEXL-SitRep");
      if (this.messageReportType != null)
      {
        ckw.Value.Add("MEXL-SitRep " + this.messageReportType.ToString());
        return "MEXL-SitRep " + this.messageReportType.ToString();
      }

      return "MEXL-SitRep";
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.SitRepPrefix, "SitRep", EDXLConstants.SitRep10Namespace);
      if (this.reportLocation != null)
      {
        xwriter.WriteStartElement("ObservationLocation");
        this.reportLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.messageID))
      {
        xwriter.WriteElementString("MessageID", this.messageID);
      }

      if (!string.IsNullOrEmpty(this.incidentID))
      {
        xwriter.WriteElementString("IncidentID", this.incidentID);
      }

      if (this.fromDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("FromDateTime", this.fromDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.todateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("ToDateTime", this.todateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.preparedDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("PreparedDateTime", this.preparedDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.nextContact != DateTime.MinValue)
      {
        xwriter.WriteElementString("NextContact", this.nextContact.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.certainty != null)
      {
        xwriter.WriteElementString("Certainty", this.certainty.ToString());
      }

      if (!string.IsNullOrEmpty(this.originatingMessageID))
      {
        xwriter.WriteElementString("OrginatingMessageID", this.originatingMessageID);
      }

      if (!string.IsNullOrEmpty(this.precedingMessageID))
      {
        xwriter.WriteElementString("PrecedingMessageID", this.precedingMessageID);
      }

      if (this.preparedBy != null)
      {
        xwriter.WriteStartElement("PreparedBy");
        this.preparedBy.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.authorizedBy != null)
      {
        xwriter.WriteStartElement("AuthorizedBy");
        this.authorizedBy.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.reportTitle))
      {
        xwriter.WriteElementString("ReportTitle", this.reportTitle);
      }

      if (!string.IsNullOrEmpty(this.reportPurpose))
      {
        xwriter.WriteElementString("ReportPurpose", this.reportPurpose);
      }

      if (!string.IsNullOrEmpty(this.reportNumber))
      {
        xwriter.WriteElementString("ReportNumber", this.reportNumber);
      }

      if (!string.IsNullOrEmpty(this.reportVersion))
      {
        xwriter.WriteElementString("ReportVersion", this.reportVersion);
      }

      if (this.messageReportType != null)
      {
        xwriter.WriteElementString("MessageReportType", this.messageReportType.ToString());
      }

      if (this.urgency != null)
      {
        xwriter.WriteElementString("Urgency", this.urgency.ToString());
      }

      if (!string.IsNullOrEmpty(this.actionPlan))
      {
        xwriter.WriteElementString("ActionPlan", this.actionPlan);
      }

      if (this.report != null)
      {
        this.report.WriteXML(xwriter);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "SitRep")
      {
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "ObservationLocation":
              if (childnode.ChildNodes.Count != 1)
              {
                throw new ArgumentException("Unexpected Number of Location Children in SitRep");
              }

              this.reportLocation = new GeoOASISWhere();
              this.reportLocation.ReadXML(childnode.ChildNodes[0]);
              break;
            case "MessageID":
              this.messageID = childnode.InnerText;
              break;
            case "IncidentID":
              this.incidentID = childnode.InnerText;
              break;
            case "FromDateTime":
              this.fromDateTime = DateTime.Parse(childnode.InnerText);
              if (this.fromDateTime.Kind == DateTimeKind.Unspecified)
              {
                this.fromDateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.fromDateTime = this.fromDateTime.ToUniversalTime();
              break;
            case "ToDateTime":
              this.todateTime = DateTime.Parse(childnode.InnerText);
              if (this.todateTime.Kind == DateTimeKind.Unspecified)
              {
                this.todateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.todateTime = this.todateTime.ToUniversalTime();
              break;
            case "PreparedDateTime":
              this.preparedDateTime = DateTime.Parse(childnode.InnerText);
              if (this.preparedDateTime.Kind == DateTimeKind.Unspecified)
              {
                this.preparedDateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.preparedDateTime = this.preparedDateTime.ToUniversalTime();
              break;
            case "NextContact":
              this.nextContact = DateTime.Parse(childnode.InnerText);
              if (this.nextContact.Kind == DateTimeKind.Unspecified)
              {
                this.nextContact = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.nextContact = this.nextContact.ToUniversalTime();
              break;
            case "Certainty":
              this.certainty = (CertaintyType)Enum.Parse(typeof(CertaintyType), childnode.InnerText);
              break;
            case "OrginatingMessageID":
              this.originatingMessageID = childnode.InnerText;
              break;
            case "PrecedingMessageID":
              this.precedingMessageID = childnode.InnerText;
              break;
            case "PreparedBy":
              this.preparedBy = new PersonDetails();
              this.preparedBy.ReadXML(childnode);
              break;
            case "AuthorizedBy":
              this.authorizedBy = new PersonDetails();
              this.authorizedBy.ReadXML(childnode);
              break;
            case "ReportTitle":
              this.reportTitle = childnode.InnerText;
              break;
            case "ReportPurpose":
              this.reportPurpose = childnode.InnerText;
              break;
            case "ReportNumber":
              this.reportNumber = childnode.InnerText;
              break;
            case "ReportVersion":
              this.reportVersion = childnode.InnerText;
              break;
            case "MessageReportType":
              this.messageReportType = (SitRepReportType)Enum.Parse(typeof(SitRepReportType), childnode.InnerText);
              break;
            case "Urgency":
              this.urgency = (UrgencyType)Enum.Parse(typeof(UrgencyType), childnode.InnerText);
              break;
            case "ActionPlan":
              this.actionPlan = childnode.InnerText;
              break;
            case "CasualtyandIllnessSummaryByPeriod":
              this.report = new CasualtyandIllnessSummaryByPeriod();
              this.report.ReadXML(childnode);
              break;
            case "ResponseResourcesTotals":
              this.report = new ResponseResourcesTotals();
              this.report.ReadXML(childnode);
              break;
            case "SituationInformation":
              this.report = new SituationInformation();
              this.report.ReadXML(childnode);
              break;
            case "ManagementReportingSummary":
              this.report = new ManagementReportingSummary();
              this.report.ReadXML(childnode);
              break;
            case "SituationObservation":
              this.report = new SituationObservation();
              this.report.ReadXML(childnode);
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in SitRep");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Root Node Name: " + rootnode.Name + " in SitRep");
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitems">Pointer to a Valid List of Syndication Items to Populate</param>
    /// <param name="linkUID">The ContentObject Guid To Link To</param>
    public void ToGeoRSS(List<SyndicationItem> myitems, Guid linkUID)
    {
      SyndicationItem myitem = new SyndicationItem();
      myitem.Authors.Add(new SyndicationPerson("admin@pscloud.org", this.preparedBy.PersonName[0].NameElement[0].Name, string.Empty));
      myitem.Categories.Add(new SyndicationCategory(EDXLConstants.SitRepSyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      myitem.Title = new TextSyndicationContent(EDXLConstants.SitRepSyndicationTitle + " " + linkUID.ToString());
      this.report.ToGeoRSS(myitem);
      this.reportLocation.ToGeoRSS(myitem);
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.fromDateTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "SitRep/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;
      myitem.Summary = new TextSyndicationContent("MessageID: " + this.messageID);

      myitem.ElementExtensions.Add("expire_time", string.Empty, this.ToDateTime.ToUniversalTime().ToString());

      myitems.Add(myitem);
    }

    /// <summary>
    /// Validates The Current DE Object Against The XSD Schema File
    /// </summary>
    public void ValidateToSchema()
    {
      return;
      /* XmlReader vr;
      XmlReaderSettings xs = new XmlReaderSettings();
      XmlSchemaSet coll = new XmlSchemaSet();
      StringReader xsdsr = new StringReader(string.Empty);
      StringReader xmlsr = new StringReader(xmldata);
      XmlReader xsdread = XmlReader.Create(xsdsr);
      coll.Add(EDXLConstants.EDXLDE10Namespace, xsdread);
      xs.Schemas.Add(coll);
      xs.ValidationType = ValidationType.Schema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      vr = XmlReader.Create(xmlsr, xs);
      while (vr.Read())
      {
      }

      vr.Close();
      xmlsr.Close();
      xsdread.Close();
      xsdsr.Close();
      if (schemaErrors > 0)
      {
        throw new ArgumentException("Schema Validation Error: " + schemaErrorString);
      }*/
    }

    #endregion

    #region Private Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.messageID))
      {
        throw new ArgumentNullException("Message ID is required and can't be null or empty!");
      }

      if (this.preparedDateTime == DateTime.MinValue)
      {
        throw new ArgumentNullException("Prepared Date Time is required and can't be null or empty!");
      }

      if (this.preparedBy == null)
      {
        throw new ArgumentNullException("Prepared By is required and can't be null or empty!");
      }

      if (this.messageReportType == null)
      {
        throw new ArgumentNullException("Message Report Type is required and can't be null or empty!");
      }

      if (this.fromDateTime == DateTime.MinValue)
      {
        throw new ArgumentNullException("From Date Time is required and can't be null or empty!");
      }

      if (this.todateTime == DateTime.MinValue)
      {
        throw new ArgumentNullException("To Date Time is required and can't be null or empty!");
      }

      if (this.certainty == null)
      {
        throw new ArgumentNullException("Certainty is required and can't be null or empty!");
      }

      if (string.IsNullOrEmpty(this.incidentID))
      {
        throw new ArgumentNullException("Incident ID is required and can't be null or empty!");
      }
    }

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

    #endregion
  }
}
