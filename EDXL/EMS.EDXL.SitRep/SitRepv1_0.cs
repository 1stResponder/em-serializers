using EMS.EDXL.Utilities;
using EMS.EDXL.CT;
using EMS.EDXL.GSF;
using EMS.EDXL.Shared;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using System.Xml;
using System.IO;
using EMS.EDXL.SitRep.Reports;

namespace EMS.EDXL.SitRep
{
  /// <summary>
  /// Top level element type of all situation reports
  /// </summary>
  [XmlRoot(ElementName = "sitRep", IsNullable = false, Namespace = SitRepNamespaces.v10)]
  public class SitRepv1_0 : IContentObject
  {
    private EDXLString messageID;

    private PersonTimePairType preparedBy;

    private PersonTimePairType authorizedBy;

    private EDXLString reportPurpose;

    private uint reportNumber;

    private ReportVersionDefaultValues reportVersion;

    private TimePeriod forTimePeriod;

    private EDXLString reportTitle;

    private List<EDXLString> incidentID;

    private IReportType report;

    private List<IncidentLifecycleDefaultValues> incidentLifecyclePhase;

    private EDXLString originatingMessageID;

    private List<EDXLString> precedingMessageID;

    private UrgencyDefaultValues? urgency;
    
    private ConfidenceDefaultValues reportConfidence;

    private SeverityDefaultValues severity;

    private EDXLDateTime? nextContact;

    private EDXLLocationType reportingLocation;

    private EDXLString actionPlan;

    /// <summary>
    /// Each EDXL-SitRep contains an identifier that uniquely identifies the EDXL-SitRep message / Report.
    /// </summary>
    [XmlElement("messageID", Order = 1)]
    public EDXLString MessageID
    {
      get { return this.messageID; }
      set { this.messageID = value; }
    }

    /// <summary>
    /// The person name and/or PositionTitle (ICSPositionTitle when an Incident Management Organization
    /// is in place) of the person preparing the information that makes up the message / report and the 
    /// associated DateTime that this report was prepared   
    /// </summary>
    [XmlElement("preparedBy", Order = 2)]
    public PersonTimePairType PreparedBy
    {
      get { return this.preparedBy; }
      set { this.preparedBy = value; }
    }

    /// <summary>
    /// The person name and/or PositionTitle (ICSPositionTitle when an Incident Management Organziation 
    /// is in place) of the person formally authorizing the information that makes up the message / report 
    /// and the associated DateTime that this report was prepared   
    /// </summary>
    [XmlElement("authorizedBy", Order = 3)]
    public PersonTimePairType AuthorizedBy
    {
      get { return this.authorizedBy; }
      set { this.authorizedBy = value; }
    }

    /// <summary>
    /// States the purpose of this Situation Report. May contain description information regarding why 
    /// the report is being sent and required response or action, if any.
    /// </summary>
    [XmlElement("reportPurpose", Order = 4)]
    public EDXLString ReportPurpose
    {
      get { return this.reportPurpose; }
      set { this.reportPurpose = value; }
    }

    /// <summary>
    /// A unique number for reporting an incident or event, used to identify each new or updated 
    /// report instance. Used to support report tracking.
    /// </summary>
    [XmlElement("reportNumber", Order = 5)]
    public uint ReportNumber
    {
      get { return this.reportNumber; }
      set { this.reportNumber = value; }
    }

    /// <summary>
    /// This indicates the current version of the specific SitRep MessageReportType report being submitted 
    /// from the same source (“authorizedBy”) for the same incident or event.  If only one SitRep will be 
    /// submitted, indicate BOTH “Initial” and “Final”.  
    /// </summary>
    [XmlElement("reportVersion", Order = 6)]
    public ReportVersionDefaultValues ReportVersion
    {
      get { return this.reportVersion; }
      set { this.reportVersion = value; }
    }

    /// <summary>
    /// The time lapsed since the incident or event started.  
    /// </summary>
    [XmlElement("forTimePeriod", Order = 7)]
    public TimePeriod ForTimePeriod
    {
      get { return this.forTimePeriod; }
      set { this.forTimePeriod = value; }
    }

    /// <summary>
    /// reportTitle is the designation of a more specific title for the SitRep report other than or 
    /// in addition to the title given as the value of the sitRep element.
    /// </summary>
    [XmlElement("reportTitle", Order = 8)]
    public EDXLString ReportTitle
    {
      get { return this.reportTitle; }
      set { this.reportTitle = value; }
    }

    /// <summary>
    /// The name or other identifier of the incident to which the current message refers, that 
    /// has been assigned to the incident by an authorized agency based on current guidance.
    /// </summary>
    [XmlElement("incidentID", Order = 9)]
    public List<EDXLString> IncidentID
    {
      get { return this.incidentID; }
      set { this.incidentID = value; }
    }

    /// <summary>
    /// A code specifying the incident response lifecycle stage currently in effect
    /// </summary>
    [XmlElement("incidentLifecyclePhase", Order = 10)]
    public List<IncidentLifecycleDefaultValues> IncidentLifecyclePhase
    {
      get { return this.incidentLifecyclePhase; }
      set { this.incidentLifecyclePhase = value; }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool IncidentLifecyclePhaseSpecified
    {
      get { return this.incidentLifecyclePhase != null && this.incidentLifecyclePhase.Count > 0; }
    }

    /// <summary>
    /// Identifies the messageID of the first message in a message sequence to which the message belongs.
    /// </summary>
    [XmlElement("originatingMessageID", Order = 11)]
    public EDXLString OriginatingMessageID
    {
      get { return this.originatingMessageID; }
      set { this.originatingMessageID = value; }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool OriginatingMessageIDSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.originatingMessageID); }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlElement("precedingMessageID", Order = 12)]
    public List<EDXLString> PrecedingMessageID
    {
      get { return this.precedingMessageID; }
      set { this.precedingMessageID = value; }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool PrecedingMessageIDSpecified
    {
      get { return this.precedingMessageID != null && this.precedingMessageID.Count > 0; }
    }

    /// <summary>
    /// The code denoting the importance and necessity of the SitRep message
    /// </summary>
    [XmlElement("urgency", Order = 13)]
    public UrgencyDefaultValues Urgency
    {
      get { return this.urgency.Value; }
      set { this.urgency = value; }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool UrgencySpecified
    {
      get { return this.urgency.HasValue; }
    }

    /// <summary>
    /// The code denoting the level of confidence or sureness in the content of the EDXL-SitRep message, 
    /// endorsed by the officer in the“AuthorizedBy” role.
    /// </summary>
    [XmlElement("reportConfidence", Order = 14)]
    public ConfidenceDefaultValues ReportConfidence
    {
      get { return this.reportConfidence; }
      set { this.reportConfidence = value; }
    }

    /// <summary>
    /// The code denoting the severity of the subject incident or event.
    /// </summary>
    [XmlElement("severity", Order = 15)]
    public SeverityDefaultValues Severity
    {
      get { return this.severity; }
      set { this.severity = value; }
    }


    /// <summary>
    /// A structure representing the physical location and/or organization 
    /// associated with the role, or associated with the location 
    /// where the Field Observation is taking place, i.e. “where I am”.
    /// </summary>
    [XmlElement("reportingLocation", Type = typeof(EDXLGeoLocation), Order = 16)]
    [XmlElement("reportingLocation", Type = typeof(EDXLGeoPoliticalLocation), Order = 16)]
    public dynamic ReportingLocation { get; set; }

    /// <summary>
    /// General description of what the officer in the <seealso cref="preparedBy"/> role needs or 
    /// expects, or a description of intended next step(s) of Incident Command.  
    /// </summary>
    [XmlElement("actionPlan", Order = 17)]
    public EDXLString ActionPlan
    {
      get { return this.actionPlan; }
      set { this.actionPlan = value; }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool ActionPlanSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.actionPlan); }
    }

    /// <summary>
    /// DateTime of next contact or report planned by the <seealso cref="preparedBy"/> 
    /// role to set expectations for provision or receipt of updated or additional information.
    /// </summary>
    /// <seealso cref=""/>
    [XmlElement("nextContact", Order = 18)]
    public string NextContact
    {
      get
      {
        return this.nextContact.Value.EDXLCustomFormat;
      }
      set
      {
        this.nextContact = DateTime.Parse(value);
      }
    }

    /// <summary>
    /// XML Serializer flag to determine whether or not to serialize this field
    /// </summary>
    public bool NextContactSpecified
    {
      get { return this.nextContact.HasValue; }
    }

    /// <summary>
    /// The kind of details contained in this SitRep
    /// </summary>
    [XmlElement("report", Order = 19)]
    public IReportType Report
    {
      get { return this.report; }
      set { this.report = value; }
    }

    /// <summary>
    /// Time this SitRep is no longer valid
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get
      {
        return forTimePeriod.ToDateTime;
      }
    }

    /// <summary>
    /// Human readable description of the SitRep
    /// </summary>
    public string Description
    {
      get
      {
        return !string.IsNullOrWhiteSpace(reportPurpose) ? (string)reportPurpose : "SitRep Report";
      }
    }

    /// <summary>
    /// List of keywords for this SitRep
    /// </summary>
    public List<ValueList> Keywords
    {
      get
      {
        ValueList vl = new ValueList();
        vl.ValueListURI = EDXLConstants.ContentKeywordListName;
        vl.Value.Add("SitRep");
        vl.Value.Add(this.reportTitle);
        vl.Value.Add(this.reportNumber.ToString());

        if (report != null)
        {
          vl.Value.AddRange(report.iReport.Keywords);
        }

        List<ValueList> lVL = new List<ValueList>();
        lVL.Add(vl);

        return lVL;
      }
    }

    /// <summary>
    /// Outputs this SitRep as an XML string
    /// </summary>
    /// <returns>XML String</returns>
    public string ToXmlString()
    {
      StringWriter sw = new StringWriter();
      XmlSerializer xs = new XmlSerializer(typeof(SitRepv1_0));
      xs.Serialize(sw, this);
      return sw.ToString();
    }
  }
}
