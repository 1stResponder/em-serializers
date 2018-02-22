// ———————————————————————–
// <copyright file="TreatmentInfoType.cs" company="EDXLSharp">
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
using System.Text;
using System.Xml;
using EDXLSharp;
using GeoOASISWhereLib;

namespace MEXLTEPLib
{
  /// <summary>
  /// Represents Treatment Information
  /// </summary>
  [Serializable]
  public partial class TreatmentInfoType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// UID of Encounter
    /// </summary>
    private string encounterID;
    
    /// <summary>
    /// DateTime of Patient Encounter
    /// </summary>
    private DateTime encounterDateTime;

    /// <summary>
    /// The Location Where Treatment Occurred
    /// </summary>
    private GeoOASISWhere treatmentLocation;

    /// <summary>
    /// Hazard Information
    /// </summary>
    private string hazardInfo;

    /// <summary>
    /// Patient's Current Disposition
    /// </summary>
    private string currentDisposition;

    /// <summary>
    /// DateTime of Treatment Performed
    /// </summary>
    private DateTime treatmentDateTime;

    /// <summary>
    /// Patient's Chief Complaint
    /// </summary>
    private string chiefComplaint;

    /// <summary>
    /// Medications Administered to Patient
    /// </summary>
    private List<string> medicationsAdministered;

    /// <summary>
    /// Procedures Performed on Patient
    /// </summary>
    private List<string> procedurePerformed;

    /// <summary>
    /// Field Trauma Triage Criteria
    /// </summary>
    private List<string> fieldTraumaCriteria;

    /// <summary>
    /// Patient Vital Signs
    /// </summary>
    private List<VitalSignsType> vitalSigns;

    /// <summary>
    /// Patient's Presenting Problem
    /// </summary>
    private string presentingProblem;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TreatmentInfoType class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public TreatmentInfoType()
    {
      this.medicationsAdministered = new List<string>();
      this.procedurePerformed = new List<string>();
      this.fieldTraumaCriteria = new List<string>();
      this.vitalSigns = new List<VitalSignsType>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Patient's Presenting Problem
    /// </summary>
    public string PresentingProblem
    {
      get { return this.presentingProblem; }
      set { this.presentingProblem = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Location Where Treatment Occurred
    /// </summary>
    public GeoOASISWhere TreatmentLocation
    {
      get { return this.treatmentLocation; }
      set { this.treatmentLocation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient Vital Signs
    /// </summary>
    public List<VitalSignsType> VitalSigns
    {
      get { return this.vitalSigns; }
      set { this.vitalSigns = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Field Trauma Triage Criteria
    /// </summary>
    public List<string> FieldTraumaCriteria
    {
      get { return this.fieldTraumaCriteria; }
      set { this.fieldTraumaCriteria = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Procedures Performed on Patient
    /// </summary>
    public List<string> ProcedurePerformed
    {
      get { return this.procedurePerformed; }
      set { this.procedurePerformed = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Medications Administered to Patient
    /// </summary>
    public List<string> MedicationsAdministered
    {
      get { return this.medicationsAdministered; }
      set { this.medicationsAdministered = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Chief Complaint
    /// </summary>
    public string ChiefComplaint
    {
      get { return this.chiefComplaint; }
      set { this.chiefComplaint = value; }
    }

    /// <summary>
    /// Gets or sets
    /// DateTime of Treatment Performed
    /// </summary>
    public DateTime TreatmentDateTime
    {
      get 
      { 
        return this.treatmentDateTime.ToUniversalTime(); 
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.treatmentDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Current Disposition
    /// </summary>
    public string CurrentDisposition
    {
      get { return this.currentDisposition; }
      set { this.currentDisposition = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Hazard Information
    /// </summary>
    public string HazardInfo
    {
      get { return this.hazardInfo; }
      set { this.hazardInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// DateTime of Patient Encounter
    /// </summary>
    public DateTime EncounterDateTime
    {
      get { return this.encounterDateTime; }
      set { this.encounterDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// UID of Encounter
    /// </summary>
    public string EncounterID
    {
      get { return this.encounterID; }
      set { this.encounterID = value; }
    }

    #endregion

    #region IComposable Interface Functions

    /// <summary>
    /// Writes this portion of the object to a GeoRSS Item
    /// </summary>
    /// <param name="myitem">Syndication Item to Fill</param>
    /// <param name="contentstr">Build String of the content portion of the syndication item</param>
    internal void ToGeoRSS(SyndicationItem myitem, StringBuilder contentstr)
    {
      contentstr.AppendLine("Encouter Time: " + this.encounterDateTime.ToString("o"));
      contentstr.AppendLine("Chief Complaint: " + this.chiefComplaint);
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.MEXLTEPPrefix, "TreatmentInfo", EDXLConstants.MEXLTEP10Namespace);
      if (!string.IsNullOrEmpty(this.encounterID))
      {
        xwriter.WriteElementString("EncounterID", this.encounterID);
      }

      if (this.encounterDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("EncounterDateTime", this.encounterDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.treatmentLocation != null)
      {
        xwriter.WriteStartElement("TreatmentLocation");
        this.treatmentLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.hazardInfo))
      {
        xwriter.WriteElementString("HazardInfo", this.hazardInfo);
      }

      if (!string.IsNullOrEmpty(this.currentDisposition))
      {
        xwriter.WriteElementString("CurrentDisposition", this.currentDisposition);
      }

      if (this.treatmentDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("TreatmentDateTime", this.treatmentDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (!string.IsNullOrEmpty(this.chiefComplaint))
      {
        xwriter.WriteElementString("ChiefComplaint", this.chiefComplaint);
      }

      if (this.medicationsAdministered.Count > 0)
      {
        xwriter.WriteStartElement("MedicationsAdministered");
        foreach (string med in this.medicationsAdministered)
        {
          if (string.IsNullOrEmpty(med))
          {
            continue;
          }

          xwriter.WriteElementString("Medication", med);
        }

        xwriter.WriteEndElement();
      }

      if (this.procedurePerformed.Count > 0)
      {
        xwriter.WriteStartElement("ProcedurePerformed");
        foreach (string procedure in this.procedurePerformed)
        {
          if (string.IsNullOrEmpty(procedure))
          {
            continue;
          }

          xwriter.WriteElementString("Procedure", procedure);
        }

        xwriter.WriteEndElement();
      }

      if (this.fieldTraumaCriteria.Count > 0)
      {
        xwriter.WriteStartElement("FieldTraumaCriteria");
        foreach (string criteria in this.fieldTraumaCriteria)
        {
          if (string.IsNullOrEmpty(criteria))
          {
            continue;
          }

          xwriter.WriteElementString("Criteria", criteria);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.presentingProblem))
      {
        xwriter.WriteElementString("PresentingProblem", this.presentingProblem);
      }

      if (this.vitalSigns.Count > 0)
      {
        foreach (VitalSignsType vitals in this.vitalSigns)
        {
          vitals.WriteXML(xwriter);
        }
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      VitalSignsType vitals;
      if (rootnode.LocalName == "TreatmentInfo")
      {
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "EncounterID":
              this.encounterID = childnode.InnerText;
              break;
            case "EncounterDateTime":
              this.encounterDateTime = DateTime.Parse(childnode.InnerText);
              if (this.encounterDateTime.Kind == DateTimeKind.Unspecified)
              {
                this.encounterDateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.encounterDateTime = this.encounterDateTime.ToUniversalTime();
              break;
            case "TreatmentLocation":
              this.treatmentLocation = new GeoOASISWhere();
              this.treatmentLocation.ReadXML(childnode.ChildNodes[0]);
              break;
            case "HazardInfo":
              this.hazardInfo = childnode.InnerText;
              break;
            case "CurrentDisposition":
              this.currentDisposition = childnode.InnerText;
              break;
            case "TreatmentDateTime":
              this.treatmentDateTime = DateTime.Parse(childnode.InnerText);
              break;
            case "ChiefComplaint":
              this.chiefComplaint = childnode.InnerText;
              break;
            case "MedicationsAdministered":
              foreach (XmlNode node in childnode.ChildNodes)
              {
                this.medicationsAdministered.Add(node.InnerText);
              }

              break;
            case "ProcedurePerformed":
              foreach (XmlNode node in childnode.ChildNodes)
              {
                this.procedurePerformed.Add(node.InnerText);
              }

              break;
            case "FieldTraumaCriteria":
              foreach (XmlNode node in childnode.ChildNodes)
              {
                this.fieldTraumaCriteria.Add(node.InnerText);
              }
              
              break;
            case "PresentingProblem":
              this.presentingProblem = childnode.InnerText;
              break;
            case "VitalSigns":
              vitals = new VitalSignsType();
              vitals.ReadXML(childnode);
              this.vitalSigns.Add(vitals);
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in TreatmentInfoType");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexcepted Root Node Name: " + rootnode.Name + " in TreatmentInfoType");
      }
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
    }

    #endregion
  }
}
