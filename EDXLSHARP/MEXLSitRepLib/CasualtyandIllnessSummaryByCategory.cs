// ———————————————————————–
// <copyright file="CasualtyandIllnessSummaryByCategory.cs" company="EDXLSharp">
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
  /// Casualty and Illness Summary By Category sub type of Casualty and Illness Summary
  /// </summary>
  [Serializable]
  public partial class CasualtyandIllnessSummaryByCategory
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period”
    /// of confirmed non-responder/responder fatalities.
    /// </summary>
    private int? fatalities;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of confirmed non-responder/responder hospitalized.
    /// </summary>
    private int? hospitalized;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of non-responder/responder injuries or illnesses.  
    /// </summary>
    private int? withInjuryOrIllness;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of non-responders/responders who are in situations where they 
    /// are trapped or in need of rescue due to incident conditions.
    /// </summary>
    private int? trappedOrInNeedOfRescue;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of non-responders/responders who are missing due to incident 
    /// conditions.
    /// </summary>
    private int? missing;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of non-responders/responders who are evacuated due to incident 
    /// conditions.
    /// </summary>
    private int? evacuated;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period” 
    /// of non-responders/responders who are sheltering in place due to 
    /// incident conditions.
    /// </summary>
    private int? shelteringInPlace;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period”
    /// of of non-responders/responders who are in temporary shelters 
    /// as a direct result of incident conditions.
    /// </summary>
    private int? intemporaryShelters;

    /// <summary>
    /// The “Total Number to Date”, and “Number This Reporting Period”
    /// of non-responders/responders who are in quarantine as a direct 
    /// result of incident conditions and/or as part of incident operations.
    /// </summary>
    private int? inquarantine;

    /// <summary>
    /// ?? Remarks ??
    /// </summary>
    private string remarks;

    /// <summary>
    /// ?? Estimated ??
    /// </summary>
    private string estimated;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the CasualtyandIllnessSummaryByCategory class
    /// Default Constructor - Does Nothing
    /// </summary>
    public CasualtyandIllnessSummaryByCategory()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Fatalities
    {
      get { return this.fatalities; }
      set { this.fatalities = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Hospitalized
    {
      get { return this.hospitalized; }
      set { this.hospitalized = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? WithInjuryOrIllness
    {
      get { return this.withInjuryOrIllness; }
      set { this.withInjuryOrIllness = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? TrappedOrInNeedOfRescue
    {
      get { return this.trappedOrInNeedOfRescue; }
      set { this.trappedOrInNeedOfRescue = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Missing
    {
      get { return this.missing; }
      set { this.missing = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Evacuated
    {
      get { return this.evacuated; }
      set { this.evacuated = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? ShelteringInPlace
    {
      get { return this.shelteringInPlace; }
      set { this.shelteringInPlace = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? InTemporaryShelters
    {
      get { return this.intemporaryShelters; }
      set { this.intemporaryShelters = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? InQuarantine
    {
      get { return this.inquarantine; }
      set { this.inquarantine = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string Remarks
    {
      get { return this.remarks; }
      set { this.remarks = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string Estimated
    {
      get { return this.estimated; }
      set { this.estimated = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("CasualtyandIllnessSummaryByCategory");

      if (this.fatalities != null)
      {
        xwriter.WriteElementString("Fatalities", this.fatalities.ToString());
      }

      if (this.hospitalized != null)
      {
        xwriter.WriteElementString("Hospitalized", this.hospitalized.ToString());
      }

      if (this.withInjuryOrIllness != null)
      {
        xwriter.WriteElementString("WithInjuryOrIllness", this.withInjuryOrIllness.ToString());
      }

      if (this.trappedOrInNeedOfRescue != null)
      {
        xwriter.WriteElementString("TrappedOrInNeedOfRescue", this.trappedOrInNeedOfRescue.ToString());
      }

      if (this.missing != null)
      {
        xwriter.WriteElementString("Missing", this.missing.ToString());
      }

      if (this.evacuated != null)
      {
        xwriter.WriteElementString("Evacuated", this.evacuated.ToString());
      }

      if (this.shelteringInPlace != null)
      {
        xwriter.WriteElementString("ShelteringInPlace", this.shelteringInPlace.ToString());
      }

      if (this.intemporaryShelters != null)
      {
        xwriter.WriteElementString("InTemporaryShelters", this.intemporaryShelters.ToString());
      }

      if (this.inquarantine != null)
      {
        xwriter.WriteElementString("InQuarantine", this.fatalities.ToString());
      }

      if (!string.IsNullOrEmpty(this.remarks))
      {
        xwriter.WriteElementString("Remarks", this.remarks);
      }

      if (!string.IsNullOrEmpty(this.estimated))
      {
        xwriter.WriteElementString("Estimated", this.estimated);
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
          case "Fatalities":
            this.fatalities = Convert.ToInt32(childnode.InnerText);
            break;
          case "Hospitalized":
            this.hospitalized = Convert.ToInt32(childnode.InnerText);
            break;
          case "WithInjuryOrIllness":
            this.withInjuryOrIllness = Convert.ToInt32(childnode.InnerText);
            break;
          case "TrappedOrInNeedOfRescue":
            this.trappedOrInNeedOfRescue = Convert.ToInt32(childnode.InnerText);
            break;
          case "Missing":
            this.missing = Convert.ToInt32(childnode.InnerText);
            break;
          case "Evacuated":
            this.evacuated = Convert.ToInt32(childnode.InnerText);
            break;
          case "ShelteringInPlace":
            this.shelteringInPlace = Convert.ToInt32(childnode.InnerText);
            break;
          case "InTemporaryShelters":
            this.intemporaryShelters = Convert.ToInt32(childnode.InnerText);
            break;
          case "InQuarantine":
            this.inquarantine = Convert.ToInt32(childnode.InnerText);
            break;
          case "Remarks":
            this.remarks = childnode.InnerText;
            break;
          case "Estimated":
            this.estimated = childnode.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in CasualtyandIllnessSummarybyCategory");
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
