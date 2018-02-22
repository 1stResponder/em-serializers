// ———————————————————————–
// <copyright file="CasualtyandIllnessSummary.cs" company="EDXLSharp">
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
  /// Casualty and Illness Summary sub type of Casualty and Illness Summary By Period
  /// </summary>
  [Serializable]
  public partial class CasualtyandIllnessSummary
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The number of “Responders” for each Casualty and Illness Summary category.  Figures may also be 
    /// reported as the “NumberThisReportingPeriod” and the “TotalNumberToDate”.
    /// </summary>
    private int? responderSummaryCount;

    /// <summary>
    /// Proposed % of total responders
    /// </summary>
    private double? totalResponders;

    /// <summary>
    /// The number of “Non-Responders” for each Casualty and Illness Summary category.  Figures may also be
    /// reported as the “NumberThisReportingPeriod” and the “TotalNumberToDate”.  
    /// </summary>
    private int? nonResponderSummaryCount;

    /// <summary>
    /// Proposed % of total population
    /// </summary>
    private double? totalPopulation;

    /// <summary>
    /// Casualty and Illness Summary By Category container object
    /// </summary>
    private CasualtyandIllnessSummaryByCategory casualtyCategory;

    /// <summary>
    /// Immunization container object
    /// </summary>
    private ImmunizationSummary immunization;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the CasualtyandIllnessSummary class
    /// Default Constructor - Does Nothing
    /// </summary>
    public CasualtyandIllnessSummary()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? ResponderSummaryCount
    {
      get { return this.responderSummaryCount; }
      set { this.responderSummaryCount = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? TotalResponders
    {
      get { return this.totalResponders; }
      set { this.totalResponders = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? NonResponderSummaryCount
    {
      get { return this.nonResponderSummaryCount; }
      set { this.nonResponderSummaryCount = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? TotalPopulation
    {
      get { return this.totalPopulation; }
      set { this.totalPopulation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public CasualtyandIllnessSummaryByCategory CasualtyCategory
    {
      get { return this.casualtyCategory; }
      set { this.casualtyCategory = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>  
    public ImmunizationSummary Immunization
    {
      get { return this.immunization; }
      set { this.immunization = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("CasualtyandIllnessSummary");

      if (this.responderSummaryCount != null)
      {
        xwriter.WriteElementString("ResponderSummaryCount", this.responderSummaryCount.ToString());
      }

      if (this.totalResponders != null)
      {
        xwriter.WriteElementString("TotalResponders", this.totalResponders.ToString());
      }

      if (this.nonResponderSummaryCount != null)
      {
        xwriter.WriteElementString("Non-ResponderSummaryCount", this.nonResponderSummaryCount.ToString());
      }

      if (this.totalPopulation != null)
      {
        xwriter.WriteElementString("TotalPopulation", this.totalPopulation.ToString());
      }

      if (this.casualtyCategory != null)
      {
        this.casualtyCategory.WriteXML(xwriter);
      }

      if (this.immunization != null)
      {
        this.immunization.WriteXML(xwriter);
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
          case "ResponderSummaryCount":
            this.responderSummaryCount = Convert.ToInt32(childnode.InnerText);
            break;
          case "TotalResponders":
            this.totalResponders = Convert.ToDouble(childnode.InnerText);
            break;
          case "Non-ResponderSummaryCount":
            this.nonResponderSummaryCount = Convert.ToInt32(childnode.InnerText);
            break;
          case "TotalPopulation":
            this.totalPopulation = Convert.ToDouble(childnode.InnerText);
            break;
          case "CasualtyandIllnessSummaryByCategory":
            this.casualtyCategory = new CasualtyandIllnessSummaryByCategory();
            this.casualtyCategory.ReadXML(childnode);
            break;
          case "ImmunizationSummary":
            this.immunization = new ImmunizationSummary();
            this.immunization.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in CasualtyAndIllnessSummary");
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
