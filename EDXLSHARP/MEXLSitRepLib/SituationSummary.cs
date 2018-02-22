// ———————————————————————–
// <copyright file="SituationSummary.cs" company="EDXLSharp">
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

namespace MEXLSitRep
{
  /// <summary>
  /// Situation Summary sub type of Management Reporting Summary
  /// </summary>
  [Serializable]
  public partial class SituationSummary
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Textual description summarizing significant progress, evacuations, incident growth, etc. during
    /// the period being reported (“ForTimePeriod”).  For example, road closures, evacuations, progress 
    /// made, accomplishments, incident command transitions, re-population of formerly evacuated areas, 
    /// etc.  Includes specifics, for example road closures include road number and duration of closure.
    /// </summary>
    private string significantEvents;

    /// <summary>
    /// Textual description summarizing damage and/or restriction of use/availability to residential or 
    /// commercial property, natural resources, critical infrastructure and key resources, etc.  
    /// Includes a short summary of damage or use or access restrictions caused by the incident.
    /// </summary>
    private string damageAssessmentInformation;

    /// <summary>
    /// Textual description summarizing hazardous chemicals, fuel types, infectious agents, radiation, 
    /// etc.  When relevant includes the appropriate primary materials, fuels or other hazards involved
    /// in the incident that are leaking, burning, infecting or otherwise causing major problems.  
    /// Examples include hazardous chemicals, wild land fuel models, biohazards, explosive materials, 
    /// oil, gas etc.
    /// </summary>
    private string primaryHazards;

    /// <summary>
    /// Geographical Extent of the Contamination
    /// </summary>
    private string extentOfContamination;

    /// <summary>
    /// Status of the general population in designated counties during emergencies or disasters.
    /// </summary>
    private string generalPopulationStatus;

    /// <summary>
    /// Hazards which are potentially dangerous and cause a threat to human life and safety
    /// </summary>
    private string threatHumanLifeSafety;

    /// <summary>
    /// Indications of follow on incidents
    /// </summary>
    private string followOnIndications;

    /// <summary>
    /// Infrastructure and/or operational systems actually or most likely affected by disaster.
    /// </summary>
    private string infrastructureAffected;

    /// <summary>
    /// Resources immediately available for response. on-scene or enroute
    /// </summary>
    private string availableCapabilities;

    /// <summary>
    /// Any possible cascading “ripple” impact of disaster.
    /// </summary>
    private string possibleCascadingEffects;

    /// <summary>
    /// The properties that have been damaged or affected by disaster or incident.
    /// </summary>
    private string propertyDamage;

    /// <summary>
    /// Estimated percentage of the incident that has been contained, or where work to complete 
    /// response to the incident has been completed.
    /// </summary>
    private double? percentContained;

    /// <summary>
    /// General description or summary of requests for additional resources or personnel.
    /// </summary>
    private string requestsForAdditionalSupport;

    /// <summary>
    /// What, if any, connections to Terrorist acts may be connected with this incident?
    /// </summary>
    private string terrorismNexus;

    /// <summary>
    /// Effects weather may have on areas impacted.
    /// </summary>
    private string weatherEffects;

    /// <summary>
    /// Effects WMD may have on areas impacted. 
    /// </summary>
    private string wmdEffects;

    /// <summary>
    /// Transportation Status Information
    /// </summary>
    private string transportationStatusInfo;

    /// <summary>
    /// Container for the Incident Command Organization and Assignments structure
    /// </summary>
    private IncidentCommandOrganizationandAssignments organizationAndAssignments;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the SituationSummary class
    /// Default Constructor - Does Nothing
    /// </summary>
    public SituationSummary()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public string SignificantEvents
    {
      get { return this.significantEvents; }
      set { this.significantEvents = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string DamageAssessmentInformation
    {
      get { return this.damageAssessmentInformation; }
      set { this.damageAssessmentInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string PrimaryHazards
    {
      get { return this.primaryHazards; }
      set { this.primaryHazards = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string ExtentOfContamination
    {
      get { return this.extentOfContamination; }
      set { this.extentOfContamination = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string GeneralPopulationStatus
    {
      get { return this.generalPopulationStatus; }
      set { this.generalPopulationStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string ThreatHumanLifeSafety
    {
      get { return this.threatHumanLifeSafety; }
      set { this.threatHumanLifeSafety = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string FollowOnIndications
    {
      get { return this.followOnIndications; }
      set { this.followOnIndications = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string InfrastructureAffected
    {
      get { return this.infrastructureAffected; }
      set { this.infrastructureAffected = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string AvailableCapabilities
    {
      get { return this.availableCapabilities; }
      set { this.availableCapabilities = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string PossibleCascadingEffects
    {
      get { return this.possibleCascadingEffects; }
      set { this.possibleCascadingEffects = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string PropertyDamage
    {
      get { return this.propertyDamage; }
      set { this.propertyDamage = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? PercentContained
    {
      get { return this.percentContained; }
      set { this.percentContained = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string RequestsForAdditionalSupport
    {
      get { return this.requestsForAdditionalSupport; }
      set { this.requestsForAdditionalSupport = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string TerrorismNexus
    {
      get { return this.terrorismNexus; }
      set { this.terrorismNexus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string WeatherEffects
    {
      get { return this.weatherEffects; }
      set { this.weatherEffects = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string WMDEffects
    {
      get { return this.wmdEffects; }
      set { this.wmdEffects = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string TransportationStatusInfo
    {
      get { return this.transportationStatusInfo; }
      set { this.transportationStatusInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public IncidentCommandOrganizationandAssignments OrganizationAndAssignments
    {
      get { return this.organizationAndAssignments; }
      set { this.organizationAndAssignments = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("SituationSummary");

      if (!string.IsNullOrEmpty(this.significantEvents))
      {
        xwriter.WriteElementString("SignificantEvents", this.significantEvents);
      }

      if (!string.IsNullOrEmpty(this.damageAssessmentInformation))
      {
        xwriter.WriteElementString("DamageAssessmentInformation", this.damageAssessmentInformation);
      }

      if (!string.IsNullOrEmpty(this.primaryHazards))
      {
        xwriter.WriteElementString("PrimaryHazards", this.primaryHazards);
      }

      if (!string.IsNullOrEmpty(this.extentOfContamination))
      {
        xwriter.WriteElementString("ExtentOfContamination", this.extentOfContamination);
      }

      if (!string.IsNullOrEmpty(this.generalPopulationStatus))
      {
        xwriter.WriteElementString("GeneralPopulationStatus", this.generalPopulationStatus);
      }

      if (!string.IsNullOrEmpty(this.threatHumanLifeSafety))
      {
        xwriter.WriteElementString("ThreatHumanLifeSafety", this.threatHumanLifeSafety);
      }

      if (!string.IsNullOrEmpty(this.followOnIndications))
      {
        xwriter.WriteElementString("FollowOnIndications", this.followOnIndications);
      }

      if (!string.IsNullOrEmpty(this.infrastructureAffected))
      {
        xwriter.WriteElementString("InfrastructureAffected", this.infrastructureAffected);
      }

      if (!string.IsNullOrEmpty(this.availableCapabilities))
      {
        xwriter.WriteElementString("AvailableCapabilities", this.availableCapabilities);
      }

      if (!string.IsNullOrEmpty(this.possibleCascadingEffects))
      {
        xwriter.WriteElementString("PossibleCascadingEffects", this.possibleCascadingEffects);
      }

      if (!string.IsNullOrEmpty(this.propertyDamage))
      {
        xwriter.WriteElementString("PropertyDamage", this.propertyDamage);
      }

      if (this.percentContained != null)
      {
        xwriter.WriteElementString("PercentContained", this.percentContained.ToString());
      }

      if (!string.IsNullOrEmpty(this.requestsForAdditionalSupport))
      {
        xwriter.WriteElementString("RequestsForAdditionalSupport", this.requestsForAdditionalSupport);
      }

      if (!string.IsNullOrEmpty(this.terrorismNexus))
      {
        xwriter.WriteElementString("TerrorismNexus", this.terrorismNexus);
      }

      if (!string.IsNullOrEmpty(this.weatherEffects))
      {
        xwriter.WriteElementString("WeatherEffects", this.weatherEffects);
      }

      if (!string.IsNullOrEmpty(this.wmdEffects))
      {
        xwriter.WriteElementString("WMDEffects", this.wmdEffects);
      }

      if (!string.IsNullOrEmpty(this.transportationStatusInfo))
      {
        xwriter.WriteElementString("TransportationStatusInfo", this.transportationStatusInfo);
      }

      if (this.organizationAndAssignments != null)
      {
        this.organizationAndAssignments.WriteXML(xwriter);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "SignificantEvents":
            this.significantEvents = childnode.InnerText;
            break;
          case "DamageAssessmentInformation":
            this.damageAssessmentInformation = childnode.InnerText;
            break;
          case "PrimaryHazards":
            this.primaryHazards = childnode.InnerText;
            break;
          case "ExtentOfContamination":
            this.extentOfContamination = childnode.InnerText;
            break;
          case "GeneralPopulationStatus":
            this.generalPopulationStatus = childnode.InnerText;
            break;
          case "ThreatHumanLifeSafety":
            this.threatHumanLifeSafety = childnode.InnerText;
            break;
          case "FollowOnIndications":
            this.followOnIndications = childnode.InnerText;
            break;
          case "InfrastructureAffected":
            this.infrastructureAffected = childnode.InnerText;
            break;
          case "AvailableCapabilities":
            this.availableCapabilities = childnode.InnerText;
            break;
          case "PossibleCascadingEffects":
            this.possibleCascadingEffects = childnode.InnerText;
            break;
          case "PropertyDamage":
            this.propertyDamage = childnode.InnerText;
            break;
          case "PercentContained":
            this.percentContained = Convert.ToDouble(childnode.InnerText);
            break;
          case "RequestsForAdditionalSupport":
            this.requestsForAdditionalSupport = childnode.InnerText;
            break;
          case "TerrorismNexus":
            this.terrorismNexus = childnode.InnerText;
            break;
          case "WeatherEffects":
            this.weatherEffects = childnode.InnerText;
            break;
          case "WMDEffects":
            this.wmdEffects = childnode.InnerText;
            break;
          case "TransportationStatusInfo":
            this.transportationStatusInfo = childnode.InnerText;
            break;
          case "IncidentCommandOrganizationandAssignments":
            this.organizationAndAssignments.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in SituationSummary");
        }
      }
    }
    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected void Validate()
    {
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
