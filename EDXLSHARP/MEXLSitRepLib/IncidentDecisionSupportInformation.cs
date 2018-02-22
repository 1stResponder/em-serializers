// ———————————————————————–
// <copyright file="IncidentDecisionSupportInformation.cs" company="EDXLSharp">
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

namespace MEXLSitRep
{
  /// <summary>
  /// Incident Decision Support Information sub type of Management Reporting Summary
  /// </summary>
  [Serializable]
  public partial class IncidentDecisionSupportInformation
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// A code indicating the current state of the threat and actions taken to manage it.
    /// </summary>
    private ValueList lifeandSafetyThreatManagement;

    /// <summary>
    /// Text indicating Current and predicted weather and related factors that may cause 
    /// concern in the form of a short synopsis on weather factors that could cause 
    /// concerns for the incident when relevant.
    /// </summary>
    private string weatherConcerns;

    /// <summary>
    /// An estimate when it is appropriate to do so of the projected incident activity, 
    /// potential, movement, escalation, or spread and influencing factors during the 
    /// next operational period.  Direction/scope in which the incident is expected to 
    /// spread, migrates, or expands during the next operational period, or other factors 
    /// that may cause activity changes.
    /// </summary>
    private string projectedIncidentActivity;

    /// <summary>
    /// A summary of the current threat and risk potential, movement, escalation, or 
    /// spread over 12-, 24-, 48- and 72-hour time frames, and any threat or risk anticipated 
    /// after 72-hours.
    /// </summary>
    private string currentIncidentThreatSummary;

    /// <summary>
    /// The projected number of people sheltered
    /// </summary>
    private int? projectedPeopleSheltered;

    /// <summary>
    /// A summary of the overall resource needs required over 12-, 24-, 48- and 72-hour time 
    /// frames, and anticipated after 72-hours.
    /// </summary>
    private string criticalResourceNeeds;

    /// <summary>
    /// An estimate of the total physical area likely to be involved or affected over the course
    /// of the incident. 
    /// </summary>
    private double? projectedFinalIncidentSize;

    /// <summary>
    /// The location size unit of measure
    /// </summary>
    private string locationSizeUOM;

    /// <summary>
    /// The date at which incident containment or control is expected, or at which time the incident 
    /// is expected to be closed or when significant incident support will be discontinued.
    /// </summary>
    private DateTime? anticipatedCompletionDate;

    /// <summary>
    /// Projected Start Date of the demobilization
    /// </summary>
    private DateTime? projectedDemobilizationStartDate;

    /// <summary>
    /// The estimated total incident costs to date for the entire incident based on currently available 
    /// information.
    /// </summary>
    private double? estimatedCostsToDate;

    /// <summary>
    /// An estimate of the total costs for the incident once all financial costs have been processed based 
    /// on current spending and projected incident activity levels.
    /// </summary>
    private double? projectedFinalCosts;

    /// <summary>
    /// Brief overview of current and critical response activities, and initiatives for each Emergency 
    /// Support Function (ESF) as applicable.  Identify any new mission assignments.  If not activated, 
    /// so indicate.  If deactivated, indicate deactivation date.  Overview should be provided for each 
    /// standard ESF as appropriate.  
    /// </summary>
    private ValueList emergencyResponseIssues;

    /// <summary>
    /// Discussion of planned activities over the next operational period, explaining the relation of 
    /// overall strategy, constraints, and current available information to: 
    /// 1) Critical resource needs identified.
    /// 2) The Incident Action Plan and management objectives and targets,
    /// 3) Anticipated results.
    /// Explain major problems and concerns such as operational challenges, incident management problems, 
    /// and social, political, economic, or environmental concerns or impacts.
    /// </summary>
    private string strategicDiscussion;

    /// <summary>
    /// Discussion of planned actions over the next operational period.
    /// </summary>
    private string plannedActions;

    /// <summary>
    /// Standardized list of time-frames used in conjunction with projected or predicted activities related to an incident.  
    /// </summary>
    private ValueList standardTimeFrames;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the IncidentDecisionSupportInformation class
    /// Default Constructor - Does Nothing
    /// </summary>
    public IncidentDecisionSupportInformation()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public ValueList LifeandSafetyThreatManagement
    {
      get { return this.lifeandSafetyThreatManagement; }
      set { this.lifeandSafetyThreatManagement = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string WeatherConcerns
    {
      get { return this.weatherConcerns; }
      set { this.weatherConcerns = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string ProjectedIncidentActivity
    {
      get { return this.projectedIncidentActivity; }
      set { this.projectedIncidentActivity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string CurrentIncidentThreatSummary
    {
      get { return this.currentIncidentThreatSummary; }
      set { this.currentIncidentThreatSummary = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? ProjectedNumberSheltered
    {
      get { return this.projectedPeopleSheltered; }
      set { this.projectedPeopleSheltered = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string CriticalResourceNeeds
    {
      get { return this.criticalResourceNeeds; }
      set { this.criticalResourceNeeds = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? ProjectedFinalIncidentSize
    {
      get { return this.projectedFinalIncidentSize; }
      set { this.projectedFinalIncidentSize = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string LocationSizeUOM
    {
      get { return this.locationSizeUOM; }
      set { this.locationSizeUOM = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime? AnticipatedCompletionDate
    {
      get { return this.anticipatedCompletionDate; }
      set { this.anticipatedCompletionDate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime? ProjectedDemobilizationStartDate
    {
      get { return this.projectedDemobilizationStartDate; }
      set { this.projectedDemobilizationStartDate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? EstimatedCostsToDate
    {
      get { return this.estimatedCostsToDate; }
      set { this.estimatedCostsToDate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? ProjectedFinalCosts
    {
      get { return this.projectedFinalCosts; }
      set { this.projectedFinalCosts = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public ValueList EmergencyResponseIssues
    {
      get { return this.emergencyResponseIssues; }
      set { this.emergencyResponseIssues = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string StrategicDiscussion
    {
      get { return this.strategicDiscussion; }
      set { this.strategicDiscussion = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string PlannedActions
    {
      get { return this.plannedActions; }
      set { this.plannedActions = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public ValueList StandardTimeFrames
    {
      get { return this.standardTimeFrames; }
      set { this.standardTimeFrames = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("IncidentDecisionSupportInformation");

      if (this.lifeandSafetyThreatManagement != null)
      {
        xwriter.WriteStartElement("LifeandSafetyThreatManagement");
        this.lifeandSafetyThreatManagement.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.weatherConcerns))
      {
        xwriter.WriteElementString("WeatherConcerns", this.weatherConcerns);
      }

      if (!string.IsNullOrEmpty(this.projectedIncidentActivity))
      {
        xwriter.WriteElementString("ProjectedIncidentActivity", this.projectedIncidentActivity);
      }

      if (!string.IsNullOrEmpty(this.currentIncidentThreatSummary))
      {
        xwriter.WriteElementString("CurrentIncidentThreatSummary", this.currentIncidentThreatSummary);
      }

      if (this.projectedPeopleSheltered != null)
      {
        xwriter.WriteElementString("ProjectedPeopleSheltered", this.projectedPeopleSheltered.ToString());
      }

      if (!string.IsNullOrEmpty(this.criticalResourceNeeds))
      {
        xwriter.WriteElementString("CriticalResourceNeeds", this.criticalResourceNeeds);
      }

      if (this.projectedFinalIncidentSize != null)
      {
        xwriter.WriteElementString("ProjectedFinalIncidentSize", this.projectedFinalIncidentSize.ToString());
      }

      if (!string.IsNullOrEmpty(this.locationSizeUOM))
      {
        xwriter.WriteElementString("LocationSizeUOM", this.locationSizeUOM);
      }

      if (this.anticipatedCompletionDate != null)
      {
        xwriter.WriteElementString("AnticipatedCompletionDate", this.anticipatedCompletionDate.ToString());
      }

      if (this.projectedDemobilizationStartDate != null)
      {
        xwriter.WriteElementString("ProjectedDemobilizationStartDate", this.projectedDemobilizationStartDate.ToString());
      }

      if (this.projectedPeopleSheltered != null)
      {
        xwriter.WriteElementString("ProjectedPeopleSheltered", this.projectedPeopleSheltered.ToString());
      }

      if (this.estimatedCostsToDate != null)
      {
        xwriter.WriteElementString("EstimatedCostsToDate", this.estimatedCostsToDate.ToString());
      }

      if (this.projectedFinalCosts != null)
      {
        xwriter.WriteElementString("ProjectedFinalCosts", this.projectedFinalCosts.ToString());
      }

      if (this.emergencyResponseIssues != null)
      {
        xwriter.WriteStartElement("EmergencyResponseIssues");
        this.emergencyResponseIssues.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.strategicDiscussion))
      {
        xwriter.WriteElementString("StrategicDiscussion", this.strategicDiscussion);
      }

      if (!string.IsNullOrEmpty(this.plannedActions))
      {
        xwriter.WriteElementString("PlannedActions", this.plannedActions);
      }

      if (this.standardTimeFrames != null)
      {
        xwriter.WriteStartElement("StandardTimeFrames");
        this.standardTimeFrames.WriteXML(xwriter);
        xwriter.WriteEndElement();
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
          case "LifeandSafetyThreatManagement":
            this.lifeandSafetyThreatManagement = new ValueList();
            this.lifeandSafetyThreatManagement.ReadXML(childnode);
            break;
          case "WeatherConcerns":
            this.weatherConcerns = childnode.InnerText;
            break;
          case "ProjectedIncidentActivity":
            this.projectedIncidentActivity = childnode.InnerText;
            break;
          case "CurrentIncidentThreatSummary":
            this.currentIncidentThreatSummary = childnode.InnerText;
            break;
          case "ProjectedPeopleSheltered":
            this.projectedPeopleSheltered = Convert.ToInt32(childnode.InnerText);
            break;
          case "CriticalResourceNeeds":
            this.criticalResourceNeeds = childnode.InnerText;
            break;
          case "ProjectedFinalIncidentSize":
            this.projectedFinalIncidentSize = Convert.ToDouble(childnode.InnerText);
            break;
          case "LocationSizeUOM":
            this.locationSizeUOM = childnode.InnerText;
            break;
          case "AnticipatedCompletionDate":
            this.anticipatedCompletionDate = Convert.ToDateTime(childnode.InnerText);
            break;
          case "ProjectedDemobilizationStartDate":
            this.projectedDemobilizationStartDate = Convert.ToDateTime(childnode.InnerText);
            break;
          case "EstimatedCostsToDate":
            this.estimatedCostsToDate = Convert.ToDouble(childnode.InnerText);
            break;
          case "ProjectedFinalCosts":
            this.projectedFinalCosts = Convert.ToDouble(childnode.InnerText);
            break;
          case "EmergencyResponseIssues":
            this.emergencyResponseIssues = new ValueList();
            this.emergencyResponseIssues.ReadXML(childnode);
            break;
          case "StrategicDiscussion":
            this.strategicDiscussion = childnode.InnerText;
            break;
          case "PlannedActions":
            this.plannedActions = childnode.InnerText;
            break;
          case "StandardTimeFrames":
            this.standardTimeFrames = new ValueList();
            this.standardTimeFrames.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in IncidentDecisionSupportInformation");
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
