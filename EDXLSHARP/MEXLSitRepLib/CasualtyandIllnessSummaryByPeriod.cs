// ———————————————————————–
// <copyright file="CasualtyandIllnessSummaryByPeriod.cs" company="EDXLSharp">
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
using System.ServiceModel.Syndication;
using System.Xml;
using EDXLSharp;

namespace MEXLSitRep
{
  /// <summary>
  /// Casualty and Illness Summary By Period Sit Rep type
  /// </summary>
  [Serializable]
  public partial class CasualtyandIllnessSummaryByPeriod : MEXLSitRepLib.ISitRepReport
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The total number of individuals impacted in each category for this reporting 
    /// period (i.e. since the previous SitRep (e.g. ICS 209) was submitted).  
    /// </summary>
    private int? numberThisReportingPeriod;

    /// <summary>
    /// The total number of individuals impacted in each category for the entire duration 
    /// of the incident.  This is a cumulative total number that should be adjusted each reporting period.  
    /// </summary>
    private int? totalNumberToDate;

    /// <summary>
    /// The combined “Total Number to Date”, and “Number This Reporting Period” for all categories.  
    /// </summary>
    private int? totalAffected;

    /// <summary>
    /// Casualty and Illness Summary container object
    /// </summary>
    private CasualtyandIllnessSummary casualtySummary;

    /// <summary>
    /// Disease Numbers container object
    /// </summary>
    private NotifiableDiseaseNumbers diseaseNumbers;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the CasualtyandIllnessSummaryByPeriod class
    /// Default Constructor - Does Nothing
    /// </summary>
    public CasualtyandIllnessSummaryByPeriod()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? NumberThisReportingPeriod
    {
      get { return this.numberThisReportingPeriod; }
      set { this.numberThisReportingPeriod = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? TotalNumberToDate
    {
      get { return this.totalNumberToDate; }
      set { this.totalNumberToDate = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? TotalAffected
    {
      get { return this.totalAffected; }
      set { this.totalAffected = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public CasualtyandIllnessSummary CasualtySummary
    {
      get { return this.casualtySummary; }
      set { this.casualtySummary = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public NotifiableDiseaseNumbers DiseaseNumbers
    {
      get { return this.diseaseNumbers; }
      set { this.diseaseNumbers = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("CasualtyandIllnessSummaryByPeriod");
      if (this.numberThisReportingPeriod != null)
      {
        xwriter.WriteElementString("NumberThisReportingPeriod", this.numberThisReportingPeriod.ToString());
      }

      if (this.totalNumberToDate != null)
      {
        xwriter.WriteElementString("TotalNumberToDate", this.totalNumberToDate.ToString());
      }

      if (this.totalAffected != null)
      {
        xwriter.WriteElementString("TotalAffected", this.totalAffected.ToString());
      }

      if (this.casualtySummary != null)
      {
        this.casualtySummary.WriteXML(xwriter);
      }

      if (this.diseaseNumbers != null)
      {
        this.diseaseNumbers.WriteXML(xwriter);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "NumberThisReportingPeriod":
            this.numberThisReportingPeriod = Convert.ToInt32(childnode.InnerText);
            break;
          case "TotalNumberToDate":
            this.totalNumberToDate = Convert.ToInt32(childnode.InnerText);
            break;
          case "TotalAffected":
            this.totalAffected = Convert.ToInt32(childnode.InnerText);
            break;
          case "NotifiableDiseaseNumbers":
            this.diseaseNumbers = new NotifiableDiseaseNumbers();
            this.diseaseNumbers.ReadXML(childnode);
            break;
          case "CasualtyandIllnessSummary":
            this.casualtySummary = new CasualtyandIllnessSummary();
            this.casualtySummary.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in Casualty and Illness Summary By Period");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Syndication Item to Populate</param>
    internal override void ToGeoRSS(System.ServiceModel.Syndication.SyndicationItem myitem)
    {
      // myitem.Title = new TextSyndicationContent("Field Observation - " + observationType.ToString() + " (EDXL-SitRep)");
      // TextSyndicationContent content = new TextSyndicationContent("Observation: " + this.observationText + "\nImmediate Needs: " + this.immediateNeeds);
      myitem.Title = new TextSyndicationContent("Casualty and Illness Summary By Period - " + " (EDXL-SitRep)");
      TextSyndicationContent content = new TextSyndicationContent("CasualtyandIllnessSummaryByPeriod: " + "\nImmediate Needs: ");
      myitem.Content = content;
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal override void SetContentKeywords(ValueList ckw)
    {
      ckw.Value.Add("MEXL-SitRep CasualtyandIllnessSummaryByPeriod");
    }
    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
