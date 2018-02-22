// ———————————————————————–
// <copyright file="TEP.cs" company="EDXLSharp">
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

using EDXLSharp;
using GeoOASISWhereLib;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace MEXLTEPLib
{
  /// <summary>
  /// MEXL Tracking of Emergency Patients Message Type
  /// </summary>
  [Serializable]
  public partial class TEP : IGeoRSS, IContentObject
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
    /// Information About The Care Provider
    /// </summary>
    private ProviderInfoType providerInfo;

    /// <summary>
    /// Information About The Treatment Administered
    /// </summary>
    private TreatmentInfoType treatmentInfo;

    /// <summary>
    /// Information About The Patient
    /// </summary>
    private PatientInfoType patientInfo;

    /// <summary>
    /// Container For Transport Information
    /// </summary>
    private TransportInfoType transportInfo;

    /// <summary>
    /// Triage Priority of the Patient
    /// </summary>
    private TriageStatusType? triageStatus;

    /// <summary>
    /// Unique ID of the Provider Issuing this Report
    /// </summary>
    private string providerUID;

    /// <summary>
    /// Units That The Patient's Age is Measured In
    /// </summary>
    private AgeUnitsType? ageUnits;

    /// <summary>
    /// Patient's Age
    /// </summary>
    private int? patientAge;

    /// <summary>
    /// Patient's Gender
    /// </summary>
    private GenderType? patientGender;

    /// <summary>
    /// Patient's Unique ID
    /// </summary>
    private string patientUID;

    /// <summary>
    /// What Type of Incident Is This?  From Managed List...
    /// </summary>
    private VLList incidentType;

    /// <summary>
    /// Unique ID of this Incident
    /// </summary>
    private string incidentID;

    /// <summary>
    /// Unique ID of this Message
    /// </summary>
    private string messageID;

    /// <summary>
    /// Location of this Message
    /// </summary>
    private GeoOASISWhere location;

    /// <summary>
    /// DateTime of This TEP Report
    /// </summary>
    private DateTime reportTime;

    /// <summary>
    /// Byte Array To Store Image Data
    /// </summary>
    private byte[] imageData;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TEP class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public TEP()
    {
      this.reportTime = DateTime.MinValue;
      this.incidentType = new VLList("IncidentType");
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Container For Transport Information
    /// </summary>
    public TransportInfoType TransportInfo
    {
      get { return this.transportInfo; }
      set { this.transportInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Byte Array To Store Image Data
    /// </summary>
    public byte[] ImageData
    {
      get { return this.imageData; }
      set { this.imageData = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Base64 String Representation of Image Data
    /// </summary>
    public string Base64ImageData
    {
      get { return Convert.ToBase64String(this.imageData); }
      set { this.imageData = Convert.FromBase64String(value); }
    }

    /// <summary>
    /// Gets or sets
    /// DateTime of This TEP Report
    /// </summary>
    public DateTime ReportTime
    {
      get
      {
        return this.reportTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.reportTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets the date and time that this object expires
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get { return this.ReportTime.AddHours(24); }
    }

    /// <summary>
    /// Gets or sets
    /// Location of this Message
    /// </summary>
    public GeoOASISWhere Location
    {
      get { return this.location; }
      set { this.location = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Unique ID of this Message
    /// </summary>
    public string MessageID
    {
      get { return this.messageID; }
      set { this.messageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Unique ID of this Incident
    /// </summary>
    public string IncidentID
    {
      get { return this.incidentID; }
      set { this.incidentID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// What Type of Incident Is This?  From Managed List...
    /// </summary>
    public IList<ValueList> IncidentType
    {
      get { return this.incidentType.Values; }
      set { this.incidentType.Values = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Unique ID
    /// </summary>
    public string PatientUID
    {
      get { return this.patientUID; }
      set { this.patientUID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Gender
    /// </summary>
    public GenderType? PatientGender
    {
      get { return this.patientGender; }
      set { this.patientGender = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Age
    /// </summary>
    public int? PatientAge
    {
      get { return this.patientAge; }
      set { this.patientAge = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Units That The Patient's Age is Measured In
    /// </summary>
    public AgeUnitsType? Ageunits
    {
      get { return this.ageUnits; }
      set { this.ageUnits = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Unique ID of the Provider Issuing this Report
    /// </summary>
    public string ProviderUID
    {
      get { return this.providerUID; }
      set { this.providerUID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Triage Priority of the Patient
    /// </summary>
    public TriageStatusType? TriageStatus
    {
      get { return this.triageStatus; }
      set { this.triageStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// PatientInfoType
    /// </summary>
    public PatientInfoType PatientInfo
    {
      get { return this.patientInfo; }
      set { this.patientInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// TreatmentInfoType
    /// </summary>
    public TreatmentInfoType TreatmentInfo
    {
      get { return this.treatmentInfo; }
      set { this.treatmentInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// ProviderInfoType
    /// </summary>
    public ProviderInfoType ProviderInfo
    {
      get { return this.providerInfo; }
      set { this.providerInfo = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Public Interface Function to Set Content Keyword Information into a ValueList
    /// </summary>
    /// <param name="ckw">ValueList Object That Will Be Used in the ContentKeyword element of a Content Object</param>
    /// <returns>String Representing The Item for use elsewhere in processing</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("MEXL-TEP");
      return "Emergency eXchange Language Tracking of Emergency Patients";
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.MEXLTEPPrefix, "TEP", EDXLConstants.MEXLTEP10Namespace);
      xwriter.WriteElementString("ProviderUID", this.providerUID);
      xwriter.WriteElementString("PatientAge", this.patientAge.ToString());
      xwriter.WriteElementString("AgeUnits", this.ageUnits.ToString());
      xwriter.WriteElementString("PatientGender", this.patientGender.ToString());
      xwriter.WriteElementString("MessageID", this.messageID);
      xwriter.WriteElementString("ReportDT", this.reportTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      if (!string.IsNullOrEmpty(this.patientUID))
      {
        xwriter.WriteElementString("PatientUID", this.patientUID);
      }

      if (this.triageStatus != null)
      {
        xwriter.WriteElementString("TriageStatus", this.triageStatus.ToString());
      }

      this.incidentType.WriteXML(xwriter);

      /*if (this.incidentType.Count != 0)
      //{
      //  foreach (ValueList list in this.incidentType)
      //  {
      //    xwriter.WriteStartElement("IncidentType");
      //    list.WriteXML(xwriter);
      //    xwriter.WriteEndElement();
      //  }
      //}*/
      
      if (!string.IsNullOrEmpty(this.incidentID))
      {
        xwriter.WriteElementString("IncidentID", this.incidentID);
      }
      
      if (this.location != null)
      {
        xwriter.WriteStartElement("Location");
        this.location.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }
      
      if (this.patientInfo != null)
      {
        this.patientInfo.WriteXML(xwriter);
      }
      
      if (this.treatmentInfo != null)
      {
        this.treatmentInfo.WriteXML(xwriter);
      }
      
      if (this.providerInfo != null)
      {
        this.providerInfo.WriteXML(xwriter);
      }
      
      if (this.transportInfo != null)
      {
        this.transportInfo.WriteXML(xwriter);
      }
      
      if (this.imageData != null)
      {
        xwriter.WriteElementString("FormImage", this.Base64ImageData);
      }
      
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "TEP")
      {
        ////ValueList templist;

        this.incidentType.ReadXML(rootnode);

        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }
          
          switch (childnode.LocalName)
          {
            case "ProviderUID":
              this.providerUID = childnode.InnerText;
              break;
            case "PatientAge":
              this.patientAge = int.Parse(childnode.InnerText);
              break;
            case "AgeUnits":
              this.ageUnits = (AgeUnitsType)Enum.Parse(typeof(AgeUnitsType), childnode.InnerText);
              break;
            case "PatientGender":
              this.patientGender = (GenderType)Enum.Parse(typeof(GenderType), childnode.InnerText, true);
              break;
            case "MessageID":
              this.messageID = childnode.InnerText;
              break;
            case "ReportDT":
              this.reportTime = DateTime.Parse(childnode.InnerText);
              if (this.reportTime.Kind == DateTimeKind.Unspecified)
              {
                this.reportTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.reportTime = this.reportTime.ToUniversalTime();
              break;
            case "ProviderInfo":
              this.providerInfo = new ProviderInfoType();
              this.providerInfo.ReadXML(childnode);
              break;
            case "TreatmentInfo":
              this.treatmentInfo = new TreatmentInfoType();
              this.treatmentInfo.ReadXML(childnode);
              break;
            case "TriageStatus":
              this.triageStatus = (TriageStatusType)Enum.Parse(typeof(TriageStatusType), childnode.InnerText);
              break;
            case "PatientUID":
              this.patientUID = childnode.InnerText;
              break;
            case "IncidentType":
              /*if (childnode.ChildNodes.Count == 0)
              //{
              //  break;
              //}
              //else if (childnode.ChildNodes.Count == 1)
              //{
              //  templist = new ValueList();
              //  templist.ReadXML(childnode.FirstChild);
              //  this.incidentType.Add(templist);
              //}
              //else
              //{
              //  throw new ArgumentException("Unexpected Number of Child Nodes for ValueList in TEP");
              //}*/
              if (childnode.ChildNodes.Count > 1)
              {
                throw new ArgumentException("Unexpected Number of Child Nodes for ValueList in TEP");
              }

              break;
            case "IncidentID":
              this.incidentID = childnode.InnerText;
              break;
            case "Location":
              if (childnode.ChildNodes.Count == 0)
              {
                break;
              }
              else if (childnode.ChildNodes.Count == 1)
              {
                this.location = new GeoOASISWhere();
                this.location.ReadXML(childnode.FirstChild);
              }
              else
              {
                throw new ArgumentException("Unexpected Number of Child Nodes for GeoOASISWhere in TEP");
              }

              break;
            case "PatientInfo":
              this.patientInfo = new PatientInfoType();
              this.patientInfo.ReadXML(childnode);
              break;
            case "FormImage":
              this.Base64ImageData = childnode.InnerText;
              break;
            case "TransportInfo":
              this.transportInfo = new TransportInfoType();
              this.transportInfo.ReadXML(childnode);
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in TEP");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Root Node Name: " + rootnode.Name + " in TEP");
      }

      this.Validate();
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitems">Pointer to a Valid Syndication Item to Populate</param>
    /// <param name="linkuid">Unique Identifier to Link This Item To</param>
    public void ToGeoRSS(List<SyndicationItem> myitems, Guid linkuid)
    {
      SyndicationItem myitem = new SyndicationItem();
      myitem.Authors.Add(new SyndicationPerson(this.providerUID, "ProviderName", string.Empty));
      myitem.Categories.Add(new SyndicationCategory(EDXLConstants.MEXLTEPSyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      this.location.ToGeoRSS(myitem);
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.reportTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "TEP/" + linkuid.ToString())));
      myitem.PublishDate = DateTime.Now;
      myitem.Summary = new TextSyndicationContent("MessageID: " + this.messageID);
      myitem.Title = new TextSyndicationContent(this.triageStatus.ToString() + " " + this.patientAge.ToString() + this.ageUnits.ToString() + " " + this.patientGender.ToString() + " (EDXL-TEP)");
      StringBuilder contentstr = new StringBuilder();
      myitem.Content = new TextSyndicationContent(this.patientAge.ToString() + " " + this.ageUnits.ToString() + " " + this.patientGender.ToString());
      myitems.Add(myitem);
    }

    /// <summary>
    /// Validates The Current DE Object Against The XSD Schema File
    /// </summary>
    public void ValidateToSchema()
    {
      return;
      /*XmlReader vr;
      //XmlReaderSettings xs = new XmlReaderSettings();
      //XmlSchemaSet coll = new XmlSchemaSet();
      //StringReader xsdsr = new StringReader(string.Empty);
      //StringReader xmlsr = new StringReader(xmldata);
      //XmlReader xsdread = XmlReader.Create(xsdsr);
      //coll.Add(EDXLConstants.EDXLDE10Namespace, xsdread);
      //xs.Schemas.Add(coll);
      //xs.ValidationType = ValidationType.Schema;
      //xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      //xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      //xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      //vr = XmlReader.Create(xmlsr, xs);
      //while (vr.Read())
      //{
      //}

      //vr.Close();
      //xmlsr.Close();
      //xsdread.Close();
      //xsdsr.Close();
      //if (schemaErrors > 0)
      //{
      //  throw new ArgumentException("Schema Validation Error: " + schemaErrorString);
      //}*/
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
        throw new NullReferenceException("MessageID Can't Be null in TEP");
      }

      if (string.IsNullOrEmpty(this.patientUID))
      {
        throw new NullReferenceException("PatientUID Can't Be null in TEP");
      }

      if (this.ageUnits == null)
      {
        throw new NullReferenceException("AgeUnits Can't Be null in TEP");
      }

      if (this.patientAge == null)
      {
        throw new NullReferenceException("Age Must Be Set in TEP");
      }

      if (this.patientGender == null)
      {
        throw new NullReferenceException("Gender Must Be Set in TEP");
      }

      if (this.reportTime == DateTime.MinValue)
      {
        throw new NullReferenceException("ReportDateTime Can't Be null in TEP");
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
