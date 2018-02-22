// ———————————————————————–
// <copyright file="VitalSignsType.cs" company="EDXLSharp">
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
using System.Xml;
using EDXLSharp;

namespace MEXLTEPLib
{
  /// <summary>
  /// Represents Vital Signs Findings
  /// </summary>
  [Serializable]
  public partial class VitalSignsType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Systolic BP in mmHg
    /// </summary>
    private int? systolicBP;

    /// <summary>
    /// Diastolic BP in mmHg
    /// </summary>
    private int? diastolicBP;

    /// <summary>
    /// Pulse Rate in Beats/Min
    /// </summary>
    private int? pulseRate;

    /// <summary>
    /// Respiration Rate in Respirations/Min
    /// </summary>
    private int? respiratoryRate;

    /// <summary>
    /// Rhythm on the Monitor
    /// </summary>
    private string cardiacMonitorRhythm;

    /// <summary>
    /// Interpretation of the 12 Lead ECG
    /// </summary>
    private string twelveLeadECGInterprepation;

    /// <summary>
    /// Pulse Oximetry 0-100%
    /// </summary>
    private int? pulseOximetry;

    /// <summary>
    /// CO2 Level in Blood in ppm
    /// </summary>
    private int? carbondioxlevel;

    /// <summary>
    /// Blood Glucose Level in mg/dl
    /// </summary>
    private int? bloodGlucoseLevel;

    /// <summary>
    /// Temperature in Degrees Centigrade
    /// </summary>
    private double? temperature;

    /// <summary>
    /// Total Glasgow Coma Scale (3-15)
    /// </summary>
    private int? totalGCS;

    /// <summary>
    /// When Were These Vitals Taken?
    /// </summary>
    private DateTime encounterDateTime;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the VitalSignsType class
    /// Default Constructor - Does Nothing
    /// </summary>
    public VitalSignsType()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// When Were These Vitals Taken?
    /// </summary>
    public DateTime EncounterDateTime
    {
      get
      {
        return this.encounterDateTime;
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.encounterDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// Total Glasgow Coma Scale (3-15)
    /// </summary>
    public int? TotalGCS
    {
      get { return this.totalGCS; }
      set { this.totalGCS = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Temperature in Degrees Centigrade
    /// </summary>
    public double? Temperature
    {
      get { return this.temperature; }
      set { this.temperature = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Blood Glucose Level in mg/dl
    /// </summary>
    public int? BloodGlucoseLevel
    {
      get { return this.bloodGlucoseLevel; }
      set { this.bloodGlucoseLevel = value; }
    }

    /// <summary>
    /// Gets or sets
    /// CO2 Level in Blood in ppm
    /// </summary>
    public int? CO2Level
    {
      get { return this.carbondioxlevel; }
      set { this.carbondioxlevel = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Pulse Oximetry 0-100%
    /// </summary>
    public int? PulseOximetry
    {
      get { return this.pulseOximetry; }
      set { this.pulseOximetry = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Interpretation of the 12 Lead ECG
    /// </summary>
    public string TwelveLeadECGInterprepation
    {
      get { return this.twelveLeadECGInterprepation; }
      set { this.twelveLeadECGInterprepation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Rhythm on the Monitor
    /// </summary>
    public string CardiacMonitorRhythm
    {
      get { return this.cardiacMonitorRhythm; }
      set { this.cardiacMonitorRhythm = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Respiration Rate in Respirations/Min
    /// </summary>
    public int? RespiratoryRate
    {
      get { return this.respiratoryRate; }
      set { this.respiratoryRate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Pulse Rate in Beats/Min
    /// </summary>
    public int? PulseRate
    {
      get { return this.pulseRate; }
      set { this.pulseRate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Diastolic BP in mmHg
    /// </summary>
    public int? DiastolicBP
    {
      get { return this.diastolicBP; }
      set { this.diastolicBP = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Systolic BP in mmHg
    /// </summary>
    public int? SystolicBP
    {
      get { return this.systolicBP; }
      set { this.systolicBP = value; }
    }

    #endregion

    #region IComposable Interface Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.MEXLTEPPrefix, "VitalSigns", EDXLConstants.MEXLTEP10Namespace);
      if (this.systolicBP != null)
      {
        xwriter.WriteElementString("SystolicBloodPressure", this.systolicBP.ToString());
      }

      if (this.diastolicBP != null)
      {
        xwriter.WriteElementString("DiastolicBloodPressure", this.diastolicBP.ToString());
      }

      if (this.pulseRate != null)
      {
        xwriter.WriteElementString("PulseRate", this.pulseRate.ToString());
      }

      if (this.respiratoryRate != null)
      {
        xwriter.WriteElementString("RespiratoryRate", this.respiratoryRate.ToString());
      }

      if (!string.IsNullOrEmpty(this.cardiacMonitorRhythm))
      {
        xwriter.WriteElementString("CardiacMonitorRhythm", this.cardiacMonitorRhythm);
      }

      if (!string.IsNullOrEmpty(this.twelveLeadECGInterprepation))
      {
        xwriter.WriteElementString("TwelveLead", this.twelveLeadECGInterprepation);
      }

      if (this.pulseOximetry != null)
      {
        xwriter.WriteElementString("PulseOx", this.pulseOximetry.ToString());
      }

      if (this.carbondioxlevel != null)
      {
        xwriter.WriteElementString("CO2Level", this.carbondioxlevel.ToString());
      }

      if (this.bloodGlucoseLevel != null)
      {
        xwriter.WriteElementString("BGLevel", this.bloodGlucoseLevel.ToString());
      }

      if (this.temperature != null)
      {
        xwriter.WriteElementString("Temperature", this.temperature.ToString());
      }

      if (this.totalGCS != null)
      {
        xwriter.WriteElementString("TotalGCS", this.totalGCS.ToString());
      }

      if (this.encounterDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("EncounterDateTime", this.encounterDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "VitalSigns")
      {
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "SystolicBloodPressure":
              this.systolicBP = int.Parse(childnode.InnerText);
              break;
            case "DiastolicBloodPressure":
              this.diastolicBP = int.Parse(childnode.InnerText);
              break;
            case "PulseRate":
              this.pulseRate = int.Parse(childnode.InnerText);
              break;
            case "RespiratoryRate":
              this.respiratoryRate = int.Parse(childnode.InnerText);
              break;
            case "CardiacMonitorRhythm":
              this.cardiacMonitorRhythm = childnode.InnerText;
              break;
            case "TwelveLead":
              this.twelveLeadECGInterprepation = childnode.InnerText;
              break;
            case "PulseOx":
              this.pulseOximetry = int.Parse(childnode.InnerText);
              break;
            case "CO2Level":
              this.carbondioxlevel = int.Parse(childnode.InnerText);
              break;
            case "BGLevel":
              this.bloodGlucoseLevel = int.Parse(childnode.InnerText);
              break;
            case "Temperature":
              this.temperature = double.Parse(childnode.InnerText);
              break;
            case "TotalGCS":
              this.totalGCS = int.Parse(childnode.InnerText);
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
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in VitalSignsType");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexcepted Root Node Name: " + rootnode.Name + " in VitalSignsType");
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
