// ———————————————————————–
// <copyright file="ServiceCoverageStatusType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the ServiceCoverageStatus sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class ServiceCoverageStatusType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// The availability of burn center services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? burn;

    // CardiologyIndicator
    // OPTIONAL
    // The container element for specifying the availability of Cardiology services.
    // 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow organizations to designate subcategories, if available. 
    // 2. Organizations can either report the parent category or report the subcategories. 

    /// <summary>
    /// OPTIONAL
    /// The availability of cardiology services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? cardiology;

    // CardiologySubType
    // OPTIONAL
    // The container element for specifying the availability of Cardiology services that are broken down into sub-types.
    // Choices: 
    // • CardiologyInvasive
    // • CardiologyNonInvasive

    /// <summary>
    /// OPTIONAL 
    /// The availability of cardiology-invasive services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? cardiologyInvasive;

    /// <summary>
    /// OPTIONAL 
    /// The availability of cardiology-non-invasive services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? cardiologyNonInvasive;

    /// <summary>
    /// OPTIONAL 
    /// The availability of dialysis services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? dialysis;

    /// <summary>
    /// OPTIONAL 
    /// The availability of Emergency Department services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? emergencyDepartment;

    /// <summary>
    /// OPTIONAL 
    /// The availability of hyperbaric chamber services for decompression and/or wound care. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? hyperbaricChamber;

    /// <summary>
    /// OPTIONAL 
    /// The availability of infectious diseases services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? infectiousDisease;

    /// <summary>
    /// OPTIONAL 
    /// The availability of neonatology services.
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? neonatology;

    // NeurologyIndicator
    // OPTIONAL
    // The container element for specifying the availability of Neurology services.
    // 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations can either report the parent category or report the subcategories. 

    /// <summary>
    /// OPTIONAL 
    /// The availability of neurology services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0”- This type of services is not available.
    /// </summary>
    private bool? neurology;

    // NeurologySubType
    // OPTIONAL
    // The container element for specifying the availability of Neurology services that are broken down into sub-types.

    /// <summary>
    /// OPTIONAL 
    /// The availability of Neurology-Invasive services, including invasive catheterization. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0”- This type of services is not available.
    /// </summary>
    private bool? neurologyInvasive;

    /// <summary>
    /// OPTIONAL
    /// The availability of Neurology-Non-Invasive services with no invasive catheterization capability.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false“ or “0” - This type of services is not available. 
    /// </summary>
    private bool? neurologyNonInvasive;

    // OBGYNIndicator
    // OPTIONAL
    // The container element for specifying the availability of OBGYN services.
    // 1. Either one – the parent category or the subcategories - must be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations can either report the parent category or report the subcategories.

    /// <summary>
    /// OPTIONAL 
    /// The availability of OBGYN services with labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? obgyn;

    // OBGYNSubType
    // OPTIONAL
    // The container element for specifying the availability of OBGYN services that are broken down into sub-types.

    /// <summary>
    /// OPTIONAL 
    /// The availability of OBGYN services with labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? obgynWithLaborDelivery;

    /// <summary>
    /// The availability of OBGYN services without labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? obgynWithoutLaborDelivery;

    /// <summary>
    /// OPTIONAL 
    /// The availability of Ophthalmology services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? ophthalmology;

    /// <summary>
    /// OPTIONAL 
    /// The availability of orthopedic services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? orthropedic;

    /// <summary>
    /// OPTIONAL 
    /// The availability of pediatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? pediatrics;

    // PsychiatricIndicator
    // OPTIONAL
    // The container element for specifying the availability of Psychiatric services.
    // 1. Either one – the parent category or the subcategories - must be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations can either report the parent category or report the subcategories.

    /// <summary>
    /// OPTIONAL 
    /// The availability of psychiatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? psychiatric;

    // PsychiatricSubType
    // OPTIONAL
    // The container element for specifying the availability of Psychiatric services that are broken down into sub-types.

    /// <summary>
    /// OPTIONAL 
    /// Availability of Adult General Psychiatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? psychiatricAdultGeneral;

    /// <summary>
    /// OPTIONAL 
    /// Availability of Pediatric Psychiatric services. 
    /// 1. Sub-type element of the psychiatric services.
    /// 2. Values: 
    /// • “true” or “1” - This type of services is available. 
    /// • “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? psychiatricPediatric;

    // SurgeryIndicator
    // OPTIONAL
    // The container element for specifying the availability of Surgery services.
    // 1. Either one – the parent category or the subcategories - must be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations can either report the parent category or report the subcategories.

    /// <summary>
    /// OPTIONAL 
    /// The availability of surgery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? surgery;

    /// <summary>
    /// OPTIONAL
    /// The container element for specifying the availability of surgery services that are broken down into sub-types.
    /// </summary>
    private SurgerySubType surgeryType;

    // TransportServicesIndicator
    // OPTIONAL
    // The container element for specifying the availability of Transport services.
    // 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations MAY either report the parent category or report the subcategories. 

    /// <summary>
    /// OPTIONAL 
    /// The availability of transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? transportServices;

    // TransportSubType
    // OPTIONAL
    // The container element for specifying the availability of Transport Services that are broken down into sub-types.

    /// <summary>
    /// OPTIONAL 
    /// The availability of transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? ambulanceServices;

    /// <summary>
    /// OPTIONAL 
    /// The availability of air-transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? airTransportServices;

    // TraumaCenterServicesIndicator
    // CONDITIONAL; MUST be used once, if any sub-elements are used
    // The container element for specifying the availability of Trauma center services.
    // 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    // 1. This service capability is broken down into the below subcategories. This is to allow Organizations to designate subcategories, if available. 
    // 2. Organizations MAY either report the parent category or report the subcategories.

    /// <summary>
    /// OPTIONAL 
    /// The availability of trauma center services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    private bool? traumaCenterServices;

    /// <summary>
    /// OPTIONAL 
    /// The service level of the trauma center. 
    /// 1. Values: 
    /// • Level1 
    /// • Level2
    /// • Level3
    /// • Level4
    /// </summary>
    private TraumaCenterServicesLevelType? traumaCenterServicesLevel;

    /// <summary>
    /// Extension for additional items
    /// </summary>
    private SerializableDictionary<string, bool> additionalStatus;

    /// <summary>
    /// Comment Text
    /// </summary>
    private List<string> commentText;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ServiceCoverageStatusType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ServiceCoverageStatusType()
    {
      this.additionalStatus = new SerializableDictionary<string, bool>();
      this.commentText = new List<string>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Addition To Allow Additional Status Reporting
    /// </summary>
    public SerializableDictionary<string, bool> AdditionalStatus
    {
      get { return this.additionalStatus; }
      set { this.additionalStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of burn center services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Burn
    {
      get { return this.burn; }
      set { this.burn = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The availability of cardiology services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Cardiology
    {
      get { return this.cardiology; }
      set { this.cardiology = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of cardiology-invasive services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? CardiologyInvasive
    {
      get { return this.cardiologyInvasive; }
      set { this.cardiologyInvasive = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of cardiology-non-invasive services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? CardiologyNonInvasive
    {
      get { return this.cardiologyNonInvasive; }
      set { this.cardiologyNonInvasive = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of dialysis services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Dialysis
    {
      get { return this.dialysis; }
      set { this.dialysis = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of Emergency Department services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? EmergencyDepartment
    {
      get { return this.emergencyDepartment; }
      set { this.emergencyDepartment = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of hyperbaric chamber services for decompression and/or wound care. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? HyperbaricChamber
    {
      get { return this.hyperbaricChamber; }
      set { this.hyperbaricChamber = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of infectious diseases services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? InfectiousDisease
    {
      get { return this.infectiousDisease; }
      set { this.infectiousDisease = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of neonatology services.
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>    
    public bool? Neonatology
    {
      get { return this.neonatology; }
      set { this.neonatology = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of neurology services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0”- This type of services is not available.
    /// </summary>
    public bool? Neurology
    {
      get { return this.neurology; }
      set { this.neurology = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of Neurology-Invasive services, including invasive catheterization. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0”- This type of services is not available.
    /// </summary>
    public bool? NeurologyInvasive
    {
      get { return this.neurologyInvasive; }
      set { this.neurologyInvasive = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The availability of Neurology-Non-Invasive services with no invasive catheterization capability.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false“ or “0” - This type of services is not available. 
    /// </summary>
    public bool? NeurologyNonInvasive
    {
      get { return this.neurologyNonInvasive; }
      set { this.neurologyNonInvasive = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of OBGYN services with labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? OGBYN
    {
      get { return this.obgyn; }
      set { this.obgyn = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of OBGYN services with labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? OGBYNWithLaborDelivery
    {
      get { return this.obgynWithLaborDelivery; }
      set { this.obgynWithLaborDelivery = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of OBGYN services without labor delivery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? OGBYNWithoutLaborDelivery
    {
      get { return this.obgynWithoutLaborDelivery; }
      set { this.obgynWithoutLaborDelivery = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of Ophthalmology services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Ophthalmology
    {
      get { return this.ophthalmology; }
      set { this.ophthalmology = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of orthopedic services.  
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Orthropedic
    {
      get { return this.orthropedic; }
      set { this.orthropedic = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of pediatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Pediatrics
    {
      get { return this.pediatrics; }
      set { this.pediatrics = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of psychiatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Psychiatric
    {
      get { return this.psychiatric; }
      set { this.psychiatric = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// Availability of Adult General Psychiatric services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? PsychiatricAdultGeneral
    {
      get { return this.psychiatricAdultGeneral; }
      set { this.psychiatricAdultGeneral = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// Availability of Pediatric Psychiatric services. 
    /// 1. Sub-type element of the psychiatric services.
    /// 2. Values: 
    /// • “true” or “1” - This type of services is available. 
    /// • “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? PsychiatricPediatric
    {
      get { return this.psychiatricPediatric; }
      set { this.psychiatricPediatric = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of surgery services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? Surgery
    {
      get { return this.surgery; }
      set { this.surgery = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container element for specifying the availability of surgery services that are broken down into sub-types.
    /// </summary>
    public SurgerySubType SurgeryType
    {
      get { return this.surgeryType; }
      set { this.surgeryType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? TransportServices
    {
      get { return this.transportServices; }
      set { this.transportServices = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? AmbulanceServices
    {
      get { return this.ambulanceServices; }
      set { this.ambulanceServices = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of air-transport services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? AirTransportServices
    {
      get { return this.airTransportServices; }
      set { this.airTransportServices = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The availability of trauma center services. 
    /// Values: 
    /// 1. “true” or “1” - This type of services is available. 
    /// 2. “false” or “0” - This type of services is not available.
    /// </summary>
    public bool? TraumaCenterServices
    {
      get { return this.traumaCenterServices; }
      set { this.traumaCenterServices = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The service level of the trauma center. 
    /// 1. Values: 
    /// • Level1 
    /// • Level2
    /// • Level3
    /// • Level4
    /// </summary>
    public TraumaCenterServicesLevelType? TraumaCenterServicesLevel
    {
      get { return this.traumaCenterServicesLevel; }
      set { this.traumaCenterServicesLevel = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment Text
    /// </summary>
    public List<string> CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      if (this.burn != null)
      {
        xwriter.WriteElementString("Burn", this.burn.ToString().ToLower());
      }

      if (this.cardiology != null || this.cardiologyInvasive != null || this.cardiologyNonInvasive != null)
      {
        xwriter.WriteStartElement("CardiologyIndicator");
        if (this.cardiology != null)
        {
          xwriter.WriteElementString("Cardiology", this.cardiology.ToString().ToLower());
        }
        else if (this.cardiologyInvasive != null || this.cardiologyNonInvasive != null)
        {
          xwriter.WriteStartElement("CardiologySubType");
          if (this.cardiologyInvasive != null)
          {
            xwriter.WriteElementString("CardiologyInvasive", this.cardiologyInvasive.ToString().ToLower());
          }

          if (this.cardiologyNonInvasive != null)
          {
            xwriter.WriteElementString("CardiologyNonInvasive", this.cardiologyNonInvasive.ToString().ToLower());
          }

          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.dialysis != null)
      {
        xwriter.WriteElementString("Dialysis", this.dialysis.ToString().ToLower());
      }

      if (this.emergencyDepartment != null)
      {
        xwriter.WriteElementString("EmergencyDepartment", this.emergencyDepartment.ToString().ToLower());
      }

      if (this.hyperbaricChamber != null)
      {
        xwriter.WriteElementString("HyperbaricChamber", this.hyperbaricChamber.ToString().ToLower());
      }

      if (this.infectiousDisease != null)
      {
        xwriter.WriteElementString("InfectiousDisease", this.infectiousDisease.ToString().ToLower());
      }

      if (this.neonatology != null)
      {
        xwriter.WriteElementString("Neonatology", this.neonatology.ToString().ToLower());
      }

      if (this.neurology != null || this.neurologyInvasive != null || this.neurologyNonInvasive != null)
      {
        xwriter.WriteStartElement("NeurologyIndicator");
        if (this.neurology != null)
        {
          xwriter.WriteElementString("Neurology", this.neurology.ToString().ToLower());
        }
        else if (this.neurologyInvasive != null || this.neurologyNonInvasive != null)
        {
          xwriter.WriteStartElement("NeurologySubType");
          if (this.neurologyInvasive != null)
          {
            xwriter.WriteElementString("NeurologyInvasive", this.neurologyInvasive.ToString().ToLower());
          }

          if (this.neurologyNonInvasive != null)
          {
            xwriter.WriteElementString("NeurologyNonInvasive", this.neurologyNonInvasive.ToString().ToLower());
          }

          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.obgyn != null || this.obgynWithLaborDelivery != null || this.obgynWithoutLaborDelivery != null)
      {
        xwriter.WriteStartElement("OBGYNIndicator");
        if (this.obgyn != null)
        {
          xwriter.WriteElementString("OBGYN", this.obgyn.ToString().ToLower());
        }
        else if (this.obgynWithLaborDelivery != null || this.obgynWithoutLaborDelivery != null)
        {
          xwriter.WriteStartElement("OBGYNSubType");
          if (this.obgynWithLaborDelivery != null)
          {
            xwriter.WriteElementString("OBGYNWithLaborDelivery", this.obgynWithLaborDelivery.ToString().ToLower());
          }

          if (this.obgynWithoutLaborDelivery != null)
          {
            xwriter.WriteElementString("OBGYNWithoutLaborDelivery", this.obgynWithoutLaborDelivery.ToString().ToLower());
          }

          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.ophthalmology != null)
      {
        xwriter.WriteElementString("Ophthalmology", this.ophthalmology.ToString().ToLower());
      }

      if (this.orthropedic != null)
      {
        xwriter.WriteElementString("Orthopedic", this.orthropedic.ToString().ToLower());
      }

      if (this.pediatrics != null)
      {
        xwriter.WriteElementString("Pediatrics", this.pediatrics.ToString().ToLower());
      }

      if (this.psychiatric != null || this.psychiatricAdultGeneral != null || this.psychiatricPediatric != null)
      {
        xwriter.WriteStartElement("PsychiatricIndicator");
        if (this.psychiatric != null)
        {
          xwriter.WriteElementString("Psychiatric", this.psychiatric.ToString().ToLower());
        }
        else if (this.psychiatricAdultGeneral != null || this.psychiatricPediatric != null)
        {
          xwriter.WriteStartElement("PsychiatricSubType");
          if (this.psychiatricAdultGeneral != null)
          {
            xwriter.WriteElementString("PsychiatricAdultGeneral", this.psychiatricAdultGeneral.ToString().ToLower());
          }

          if (this.psychiatricPediatric != null)
          {
            xwriter.WriteElementString("PsychiatricPediatric", this.psychiatricPediatric.ToString().ToLower());
          }

          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.surgery != null || this.surgeryType != null)
      {
        xwriter.WriteStartElement("SurgeryIndicator");
        if (this.surgery != null)
        {
          xwriter.WriteElementString("Surgery", this.surgery.ToString().ToLower());
        }
        else if (this.surgeryType != null)
        {
          xwriter.WriteStartElement("SurgerySubType");
          this.surgeryType.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.transportServices != null || this.ambulanceServices != null || this.airTransportServices != null)
      {
        xwriter.WriteStartElement("TransportServicesIndicator");
        if (this.transportServices != null)
        {
          xwriter.WriteElementString("TransportServices", this.transportServices.ToString().ToLower());
        }
        else if (this.ambulanceServices != null || this.airTransportServices != null)
        {
          xwriter.WriteStartElement("TransportServicesSubType");
          if (this.ambulanceServices != null)
          {
            xwriter.WriteElementString("AmbulanceServices", this.ambulanceServices.ToString().ToLower());
          }

          if (this.airTransportServices != null)
          {
            xwriter.WriteElementString("AirTransportServices", this.airTransportServices.ToString().ToLower());
          }

          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.traumaCenterServices != null)
      {
        xwriter.WriteStartElement("TraumaCenterServicesIndicator");
        xwriter.WriteElementString("TraumaCenterServices", this.traumaCenterServices.ToString().ToLower());
        if (this.traumaCenterServices != null)
        {
          xwriter.WriteElementString("TraumaCenterServicesLevel", this.traumaCenterServicesLevel.ToString());
        }

        xwriter.WriteEndElement();
      }

      if (this.additionalStatus.Count > 0)
      {
        xwriter.WriteStartElement("AdditionalStatus");
        foreach (KeyValuePair<string, bool> pair in this.additionalStatus)
        {
          xwriter.WriteStartElement("Service");
          xwriter.WriteElementString("Name", pair.Key);
          xwriter.WriteElementString("Status", pair.Value.ToString());
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.commentText.Count > 0)
      {
        foreach (string commenttmp in this.commentText)
        {
          if (string.IsNullOrEmpty(commenttmp))
          {
            continue;
          }

          xwriter.WriteElementString("CommentText", commenttmp);
        }
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Burn":
            this.burn = this.ParseBoolean(node.InnerText);
            break;

          case "CardiologyIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "Cardiology":
                  this.cardiology = this.ParseBoolean(childNode.InnerText);
                  break;
                case "CardiologySubType":
                  foreach (XmlNode subChildNode in childNode.ChildNodes)
                  {
                    if (string.IsNullOrEmpty(subChildNode.InnerText))
                    {
                      continue;
                    }

                    switch (subChildNode.LocalName)
                    {
                      case "CardiologyInvasive":
                        this.cardiologyInvasive = this.ParseBoolean(subChildNode.InnerText);
                        break;
                      case "CardiologyNonInvasive":
                        this.cardiologyNonInvasive = this.ParseBoolean(subChildNode.InnerText);
                        break;
                    }
                  }

                  break;
              }
            }

            break;
          case "Dialysis":
            this.dialysis = this.ParseBoolean(node.InnerText);
            break;
          case "EmergencyDepartment":
            this.emergencyDepartment = this.ParseBoolean(node.InnerText);
            break;
          case "HyperbaricChamber":
            this.hyperbaricChamber = this.ParseBoolean(node.InnerText);
            break;
          case "InfectiousDisease":
            this.infectiousDisease = this.ParseBoolean(node.InnerText);
            break;
          case "Neonatology":
            this.neonatology = this.ParseBoolean(node.InnerText);
            break;
          case "NeurologyIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "Neurology":
                  this.neurology = this.ParseBoolean(childNode.InnerText);
                  break;
                case "NeurologySubType":
                  foreach (XmlNode subChildNode in childNode.ChildNodes)
                  {
                    if (string.IsNullOrEmpty(subChildNode.InnerText))
                    {
                      continue;
                    }

                    switch (subChildNode.LocalName)
                    {
                      case "NeurologyInvasive":
                        this.neurologyInvasive = this.ParseBoolean(subChildNode.InnerText);
                        break;
                      case "NeurologyNonInvasive":
                        this.neurologyNonInvasive = this.ParseBoolean(subChildNode.InnerText);
                        break;
                    }
                  }

                  break;
              }
            }

            break;
          case "OBGYNIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "OGBYN":
                  this.obgyn = this.ParseBoolean(childNode.InnerText);
                  break;
                case "OGBYNSubType":
                  foreach (XmlNode subChildNode in childNode.ChildNodes)
                  {
                    if (string.IsNullOrEmpty(subChildNode.InnerText))
                    {
                      continue;
                    }

                    switch (subChildNode.LocalName)
                    {
                      case "OBGYNWithLaborDelivery":
                        this.obgynWithLaborDelivery = this.ParseBoolean(subChildNode.InnerText);
                        break;
                      case "OBGYNWithoutLaborDelivery":
                        this.obgynWithoutLaborDelivery = this.ParseBoolean(subChildNode.InnerText);
                        break;
                    }
                  }

                  break;
              }
            }

            break;
          case "Ophthalmology":
            this.ophthalmology = this.ParseBoolean(node.InnerText);
            break;
          case "Orthopedic":
            this.orthropedic = this.ParseBoolean(node.InnerText);
            break;
          case "Pediatrics":
            this.pediatrics = this.ParseBoolean(node.InnerText);
            break;
          case "PsychiatricIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "Psychiatric":
                  this.psychiatric = this.ParseBoolean(childNode.InnerText);
                  break;
                case "PsychiatricSubType":
                  foreach (XmlNode subChildNode in childNode.ChildNodes)
                  {
                    if (string.IsNullOrEmpty(subChildNode.InnerText))
                    {
                      continue;
                    }

                    switch (subChildNode.LocalName)
                    {
                      case "PsychiatricAdultGeneral":
                        this.psychiatricAdultGeneral = this.ParseBoolean(subChildNode.InnerText);
                        break;
                      case "PsychiatricPediatric":
                        this.psychiatricPediatric = this.ParseBoolean(subChildNode.InnerText);
                        break;
                    }
                  }

                  break;
              }
            }

            break;
          case "SurgeryIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "Surgery":
                  this.surgery = this.ParseBoolean(childNode.InnerText);
                  break;
                case "SurgerySubType":
                  this.surgeryType = new SurgerySubType();
                  this.surgeryType.ReadXML(childNode);
                  break;
              }
            }

            break;
          case "TransportServicesIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "TransportServices":
                  this.transportServices = this.ParseBoolean(childNode.InnerText);
                  break;
                case "TransportServicesSubType":
                  foreach (XmlNode subChildNode in childNode.ChildNodes)
                  {
                    if (string.IsNullOrEmpty(subChildNode.InnerText))
                    {
                      continue;
                    }

                    switch (subChildNode.LocalName)
                    {
                      case "AmbulanceServices":
                        this.ambulanceServices = this.ParseBoolean(subChildNode.InnerText);
                        break;
                      case "AirTransportServices":
                        this.airTransportServices = this.ParseBoolean(subChildNode.InnerText);
                        break;
                    }
                  }

                  break;
              }
            }

            break;
          case "TraumaCenterServicesIndicator":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (string.IsNullOrEmpty(childNode.InnerText))
              {
                continue;
              }

              switch (childNode.LocalName)
              {
                case "TraumaCenterServices":
                  this.traumaCenterServices = this.ParseBoolean(childNode.InnerText);
                  break;
                case "TraumaCenterServicesLevel":
                  this.traumaCenterServicesLevel = (TraumaCenterServicesLevelType)Enum.Parse(typeof(TraumaCenterServicesLevelType), childNode.InnerText);
                  break;
              }
            }

            break;
          case "AdditionalStatus":
            string key;
            bool value;
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (childNode.ChildNodes[0].LocalName == "Name")
              {
                key = childNode.ChildNodes[0].InnerText;
                value = this.ParseBoolean(childNode.ChildNodes[1].InnerText);
              }
              else if (childNode.ChildNodes[1].LocalName == "Name")
              {
                key = childNode.ChildNodes[1].InnerText;
                value = this.ParseBoolean(childNode.ChildNodes[0].InnerText);
              }
              else
              {
                throw new ArgumentException("Bad things with the extension");
              }
            }

            break;
          case "CommentText":
            if (this.commentText == null)
            {
              this.commentText = new List<string>();
            }

            this.commentText.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ServiceCoverageStatusType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Private Member Functions
    /// <summary>
    /// Parses literal boolean strings, 1, or 0 as booleans
    /// </summary>
    /// <param name="value">The string to be parsed</param>
    /// <returns>The boolean value that was parsed</returns>
    private bool ParseBoolean(string value)
    {
      bool result;

      if (!bool.TryParse(value, out result))
      {
        if (value == "1" || value == "0")
        {
          result = value == "1" ? true : false;
        }
        else
        {
          throw new FormatException("'" + value + "' is not a valid boolean value");
        }
      }

      return result;
    }
    #endregion
  }
}