// ———————————————————————–
// <copyright file="PatientInfoType.cs" company="EDXLSharp">
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
using System.Xml;
using System.Xml.Linq;
using EDXLSharp.CIQLib;

namespace MEXLTEPLib
{
  /// <summary>
  /// Represents the Client (Patients) Personal and Contact Information
  /// </summary>
  [Serializable]
  public partial class PatientInfoType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// The client(patient) race/ethnicity as defined by the OMB (US Office of Management and Budget)
    /// </summary>
    private string raceEthnicity;

    /// <summary>
    /// The client(patient)s date of birth
    /// </summary>
    private DateTime dateOfBirth;

    /// <summary>
    /// Type and form of personal Identification.  
    /// </summary>
    private IdentificationType? personalIdentificationType;

    /// <summary>
    /// Unique  number or alpha-numeric sequence contained on client(patient) Personal Identification.  
    /// </summary>
    private string personalIdentificationNumber;

    /// <summary>
    /// The state that issued the client(patient) driver's license
    /// </summary>
    private char[] stateIssuingDriversLicense;

    /// <summary>
    /// The client(patient) hair color
    /// </summary>
    private HairColorType? hairColor;

    /// <summary>
    /// The client(patient) eye color
    /// </summary>
    private EyeColorType? eyeColor;

    /// <summary>
    /// Distinguishing marks on the client(patient)
    /// </summary>
    private List<string> distinguishingMarks;

    /// <summary>
    /// A notation of client(patient) transportation needs based on  client(patient) condition 
    /// or other special needs, to assure safe transport.
    /// </summary>
    private string specialTransportationNeeds;

    /// <summary>
    /// A notation of special communication needs to help arrange for translator services
    /// or services for hearing or vision impaired persons.
    /// </summary>
    private string specialCommunicationNeeds;

    /// <summary>
    /// Indication that a Client(patient) may require special security for their own 
    /// protection or that of others, such as prisoners, psychiatric patients, domestic abuse victims 
    /// </summary>
    private bool? securitySupervisionNeeds;

    /// <summary>
    /// A unique code that is assigned and tracked to individuals believed to 
    /// be part of the same family unit, designed to link family members to each other
    /// </summary>
    private string familyUnificationCode;

    /// <summary>
    /// A client(patient) status used in hospital, nursing home or other evacuations, 
    /// to indicate current care requirement, to ensure transfer to an appropriate 
    /// receiving facility with the same or similar care environment or capability
    /// </summary>
    private EvacuationStatusType? clientEvacuationStatus;

    /// <summary>
    /// Patient's Contact Information
    /// </summary>
    private PersonDetails clientContactInformation;

    /// <summary>
    /// Patient closest Relative/Guardian contact info, 
    /// </summary>
    private PersonDetails closestRelativeContactInformation;
    
    /// <summary>
    /// Free XML Region to Carry Insurance Information
    /// </summary>
    private XElement insuranceInfo;

    /// <summary>
    /// List of Patient's Allergies
    /// </summary>
    private List<string> allergies;

    /// <summary>
    /// List of Patient's Current Medications
    /// </summary>
    private List<string> medications;

    /// <summary>
    /// List of Patient's Medical Conditions
    /// </summary>
    private List<string> medicalHistory;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the PatientInfoType class
    /// Default Constructor - Initializes List and Sets Char Array Length to 2
    /// </summary>
    public PatientInfoType()
    {
      this.distinguishingMarks = new List<string>();
      this.stateIssuingDriversLicense = new char[2];
      this.allergies = new List<string>();
      this.medications = new List<string>();
      this.medicalHistory = new List<string>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// List of Patient's Medical Conditions
    /// </summary>
    public List<string> MedicalHistory
    {
      get { return this.medicalHistory; }
      set { this.medicalHistory = value; }
    }

    /// <summary>
    /// Gets or sets
    /// List of Patient's Current Medications
    /// </summary>
    public List<string> Medications
    {
      get { return this.medications; }
      set { this.medications = value; }
    }

    /// <summary>
    /// Gets or sets
    /// List of Patient's Allergies
    /// </summary>
    public List<string> Allergies
    {
      get { return this.allergies; }
      set { this.allergies = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free XML Region to Carry Insurance Information
    /// </summary>
    public XElement InsuranceInfo
    {
      get { return this.insuranceInfo; }
      set { this.insuranceInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient closest Relative/Guardian contact info, 
    /// </summary>
    public PersonDetails ClosestRelativeContactInformation
    {
      get { return this.closestRelativeContactInformation; }
      set { this.closestRelativeContactInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Patient's Contact Information
    /// </summary>
    public PersonDetails ClientContactInformation
    {
      get { return this.clientContactInformation; }
      set { this.clientContactInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A client(patient) status used in hospital, nursing home or other evacuations, 
    /// to indicate current care requirement, to ensure transfer to an appropriate 
    /// receiving facility with the same or similar care environment or capability
    /// </summary>
    public EvacuationStatusType? ClientEvacuationStatus
    {
      get { return this.clientEvacuationStatus; }
      set { this.clientEvacuationStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A unique code that is assigned and tracked to individuals believed to be 
    /// part of the same family unit, designed to link family members to each other
    /// </summary>
    public string FamilyUnificationCode
    {
      get { return this.familyUnificationCode; }
      set { this.familyUnificationCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Indication that a Client(patient) may require special security for their own 
    /// protection or that of others, such as prisoners, psychiatric patients, domestic abuse victims 
    /// </summary>
    public bool? SecuritySupervisionNeeds
    {
      get { return this.securitySupervisionNeeds; }
      set { this.securitySupervisionNeeds = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A notation of special communication needs to help arrange for translator services 
    /// or services for hearing or vision impaired persons.
    /// </summary>
    public string SpecialCommunicationNeeds
    {
      get { return this.specialCommunicationNeeds; }
      set { this.specialCommunicationNeeds = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A notation of client(patient) transportation needs based on  client(patient) condition 
    /// or other special needs, to assure safe transport.
    /// </summary>
    public string SpecialTransportationNeeds
    {
      get { return this.specialTransportationNeeds; }
      set { this.specialTransportationNeeds = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Distinguishing marks on the client(patient)
    /// </summary>
    public List<string> DistinguishingMarks
    {
      get { return this.distinguishingMarks; }
      set { this.distinguishingMarks = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The client(patient) eye color
    /// </summary>
    public EyeColorType? EyeColor
    {
      get { return this.eyeColor; }
      set { this.eyeColor = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The client(patient) hair color
    /// </summary>
    public HairColorType? HairColor
    {
      get { return this.hairColor; }
      set { this.hairColor = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The state that issued the client(patient) driver's license
    /// </summary>
    public char[] StateIssuingDriversLicense
    {
      get { return this.stateIssuingDriversLicense; }
      set { this.stateIssuingDriversLicense = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Unique  number or alpha-numeric sequence contained on client(patient) Personal Identification.  
    /// </summary>
    public string PersonalIdentificationNumber
    {
      get { return this.personalIdentificationNumber; }
      set { this.personalIdentificationNumber = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type and form of personal Identification.  
    /// </summary>
    public IdentificationType? PersonalIdentificationType
    {
      get { return this.personalIdentificationType; }
      set { this.personalIdentificationType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The client(patient)s date of birth
    /// </summary>
    public DateTime DateOfBirth
    {
      get { return this.dateOfBirth; }
      set { this.dateOfBirth = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The client(patient) race/ethnicity as defined by the OMB (US Office of Management and Budget)
    /// </summary>
    public string RaceEthnicity
    {
      get { return this.raceEthnicity; }
      set { this.raceEthnicity = value; }
    }
    #endregion

    #region IComposable Override Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement("PatientInfo");
      if (!string.IsNullOrEmpty(this.raceEthnicity))
      {
        xwriter.WriteElementString("this.raceEthnicity", this.raceEthnicity);
      }

      if (this.dateOfBirth != DateTime.MinValue)
      {
        xwriter.WriteElementString("this.dateOfBirth", this.dateOfBirth.ToString("d"));
      }

      if (this.personalIdentificationType != null)
      {
        xwriter.WriteElementString("PersonalIdentificationType", this.personalIdentificationType.ToString());
      }

      if (!string.IsNullOrEmpty(this.personalIdentificationNumber))
      {
        xwriter.WriteElementString("PersonalIdentificationNumber", this.personalIdentificationNumber);
      }

      if (new string(this.stateIssuingDriversLicense) != "\0\0")
      {
        string s = new string(this.stateIssuingDriversLicense);
        xwriter.WriteElementString("StateIssuingDriversLicense", s);
      }

      if (this.hairColor != null)
      {
        xwriter.WriteElementString("HairColor", this.hairColor.ToString());
      }

      if (this.eyeColor != null)
      {
        xwriter.WriteElementString("EyeColor", this.eyeColor.ToString());
      }

      if (this.distinguishingMarks.Count != 0)
      {
        xwriter.WriteStartElement("DistinguishingMarks");
        foreach (string s in this.distinguishingMarks)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }

          xwriter.WriteElementString("Mark", s);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.specialCommunicationNeeds))
      {
        xwriter.WriteElementString("SpecialCommunicationNeeds", this.specialCommunicationNeeds);
      }

      if (!string.IsNullOrEmpty(this.specialTransportationNeeds))
      {
        xwriter.WriteElementString("SpecialTransportationNeeds", this.specialTransportationNeeds);
      }

      if (this.securitySupervisionNeeds != null)
      {
        xwriter.WriteElementString("SecuritySupervisionNeeds", this.securitySupervisionNeeds.ToString());
      }

      if (!string.IsNullOrEmpty(this.familyUnificationCode))
      {
        xwriter.WriteElementString("FamilyUnificationCode", this.familyUnificationCode);
      }

      if (this.clientEvacuationStatus != null)
      {
        xwriter.WriteElementString("ClientEvacuationStatus", this.clientEvacuationStatus.ToString());
      }
      
      if (this.clientContactInformation != null)
      {
        xwriter.WriteStartElement("ContactInformationClient");
        this.clientContactInformation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }
      
      if (this.closestRelativeContactInformation != null)
      {
        xwriter.WriteStartElement("ContactInformationClosestRelative");
        this.closestRelativeContactInformation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }
      
      if (this.insuranceInfo != null)
      {
        this.insuranceInfo.WriteTo(xwriter);
      }
      
      if (this.allergies.Count > 0)
      {
        xwriter.WriteStartElement("Allergies");
        foreach (string s in this.allergies)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }
      
          xwriter.WriteElementString("Allergy", s);
        }
        
        xwriter.WriteEndElement();
      }

      if (this.medications.Count > 0)
      {
        xwriter.WriteStartElement("Medications");
        foreach (string s in this.medications)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }
      
          xwriter.WriteElementString("Medication", s);
        }
        
        xwriter.WriteEndElement();
      }
      
      if (this.medicalHistory.Count > 0)
      {
        xwriter.WriteStartElement("MedicalHistory");
        foreach (string s in this.medications)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }
      
          xwriter.WriteElementString("Issue", s);
        }
        
        xwriter.WriteEndElement();
      }
      
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }
      
        switch (node.LocalName)
        {
          case "this.raceEthnicity":
            this.raceEthnicity = node.InnerText;
            break;
          case "this.dateOfBirth":
            this.dateOfBirth = DateTime.Parse(node.InnerText);
            break;
          case "PersonalIdentificationType":
            this.personalIdentificationType = (IdentificationType)Enum.Parse(typeof(IdentificationType), node.InnerText);
            break;
          case "PersonalIdentificationNumber":
            this.personalIdentificationNumber = node.InnerText;
            break;
          case "StateIssuingDriversLicense":
            this.stateIssuingDriversLicense = node.InnerText.ToCharArray();
            break;
          case "HairColor":
            this.hairColor = (HairColorType)Enum.Parse(typeof(HairColorType), node.InnerText);
            break;
          case "EyeColor":
            this.eyeColor = (EyeColorType)Enum.Parse(typeof(EyeColorType), node.InnerText);
            break;
          case "DistinguishingMarks":
            foreach (XmlNode child in node.ChildNodes)
            {
              if (child.LocalName == "Mark")
              {
                this.distinguishingMarks.Add(child.InnerText);
              }
              else
              {
                throw new ArgumentException("Unexpected node name: " + child.LocalName + " in PatientInfoType/this.distinguishingMarks");
              }
            }
        
            break;
          case "SpecialTransportationNeeds":
            this.specialTransportationNeeds = node.InnerText;
            break;
          case "SpecialCommunicationNeeds":
            this.specialCommunicationNeeds = node.InnerText;
            break;
          case "SecuritySupervisionNeeds":
            this.securitySupervisionNeeds = bool.Parse(node.InnerText);
            break;
          case "FamilyUnificationCode":
            this.familyUnificationCode = node.InnerText;
            break;
          case "ClientEvacuationStatus":
            this.clientEvacuationStatus = (EvacuationStatusType)Enum.Parse(typeof(EvacuationStatusType), node.InnerText);
            break;
          case "ContactInformationClient":
            this.clientContactInformation = new PersonDetails();
            this.clientContactInformation.ReadXML(node);
            break;
          case "ContactInformationClosestRelative":
            this.closestRelativeContactInformation = new PersonDetails();
            this.closestRelativeContactInformation.ReadXML(node);
            break;
          case "InsuranceInfo":
            this.insuranceInfo = XElement.Parse(node.OuterXml);
            break;
          case "Allergies":
            foreach (XmlNode child in node.ChildNodes)
            {
              if (child.LocalName == "Allergy")
              {
                this.allergies.Add(child.InnerText);
              }
              else
              {
                throw new ArgumentException("Unexpected node name: " + child.LocalName + " in PatientInfoType/Allergies");
              }
            }
            
            break;
          case "Medications":
            foreach (XmlNode child in node.ChildNodes)
            {
              if (child.LocalName == "Medication")
              {
                this.medications.Add(child.InnerText);
              }
              else
              {
                throw new ArgumentException("Unexpected node name: " + child.LocalName + " in PatientInfoType/Allergies");
              }
            }
            
            break;
          case "MedicalHistory":
            foreach (XmlNode child in node.ChildNodes)
            {
              if (child.LocalName == "Issue")
              {
                this.medicalHistory.Add(child.InnerText);
              }
              else
              {
                throw new ArgumentException("Unexpected node name: " + child.LocalName + " in PatientInfoType/Allergies");
              }
            }
            
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid node name: " + node.Name + " in PatientInfo Type");
        }
      }
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Validates This TEP Sub-Message Elements
    /// </summary>
    protected override void Validate()
    {
    }
    #endregion
  }
}
