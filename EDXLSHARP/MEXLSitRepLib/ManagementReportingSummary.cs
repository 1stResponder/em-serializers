// ———————————————————————–
// <copyright file="ManagementReportingSummary.cs" company="EDXLSharp">
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
using GeoOASISWhereLib;

namespace MEXLSitRep
{
  /// <summary>
  /// Management Reporting Summary Sit Rep type
  /// </summary>
  [Serializable]
  public partial class ManagementReportingSummary : MEXLSitRepLib.ISitRepReport
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The Date and Time a formal disaster is declared by an authority
    /// </summary>
    private DateTime? disasterDeclarationDateTime;

    /// <summary>
    /// In context of emergency response to incidents, “jurisdiction” has two similar definitions:
    /// 1. Reference to a geo-political area or location. A jurisdiction is pre-defined physical 
    /// location or area over which legal authority extends. Though a jurisdiction itself is not 
    /// a person, role, or title, a jurisdiction has assigned to it one or more government personnel 
    /// with legal authority for certain types of decision-making such as allocation of emergency 
    /// resources and invocation of mutual aid agreements.  
    /// 2. Reference to an organization or agency that has “Authority” over something (such as an 
    /// incident, or a set of identified resources). Jurisdiction in this sense may be general, 
    /// such as “federal”, “city”, or “state”, or may be specific agency names such as “Warren County”, 
    /// “US Coast Guard”, “Panama City”, and “NYPD”.
    /// </summary>
    private GeoOASISWhere jurisdicition;

    /// <summary>
    /// General comments or remarks.
    /// </summary>
    private string remarks;

    /// <summary>
    /// Container for incident decision support information
    /// </summary>
    private IncidentDecisionSupportInformation supportInformation;

    /// <summary>
    /// Container for situation summary
    /// </summary>
    private SituationSummary sitSummary;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ManagementReportingSummary class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ManagementReportingSummary()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime? DisasterDeclarationDateTime
    {
      get { return this.disasterDeclarationDateTime; }
      set { this.disasterDeclarationDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public GeoOASISWhere Jurisdiction
    {
      get { return this.jurisdicition; }
      set { this.jurisdicition = value; }
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
    public IncidentDecisionSupportInformation SupportInformation
    {
      get { return this.supportInformation; }
      set { this.supportInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public SituationSummary SitSummary
    {
      get { return this.sitSummary; }
      set { this.sitSummary = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("ManagementReportingSummary");

      if (this.disasterDeclarationDateTime != null)
      {
        xwriter.WriteElementString("DisasterDeclarationDateTime", this.disasterDeclarationDateTime.ToString());
      }

      if (this.jurisdicition != null)
      {
        xwriter.WriteStartElement("Jurisdiction");
        this.jurisdicition.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.remarks))
      {
        xwriter.WriteElementString("Remarks", this.remarks.ToString());
      }

      if (this.supportInformation != null)
      {
        this.supportInformation.WriteXML(xwriter);
      }

      if (this.sitSummary != null)
      {
        this.sitSummary.WriteXML(xwriter);
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
          case "DisasterDeclarationDateTime":
            this.disasterDeclarationDateTime = Convert.ToDateTime(childnode.InnerText);
            break;
          case "Jurisdiction":
            this.jurisdicition = new GeoOASISWhere();
            this.jurisdicition.ReadXML(childnode.FirstChild);
            break;
          case "Remarks":
            this.remarks = childnode.InnerText;
            break;
          case "IncidentDecisionSupportInformation":
            this.supportInformation = new IncidentDecisionSupportInformation();
            this.supportInformation.ReadXML(childnode);
            break;
          case "SituationSummary":
            this.sitSummary = new SituationSummary();
            this.sitSummary.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ManagementReportingSummary");
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
      myitem.Title = new TextSyndicationContent("ManagementReportingSummary - " + " (EDXL-SitRep)");
      TextSyndicationContent content = new TextSyndicationContent("ManagementReportingSummary: " + "\nImmediate Needs: ");
      myitem.Content = content;
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal override void SetContentKeywords(ValueList ckw)
    {
      ckw.Value.Add("MEXL-SitRep ManagementReportingSummary");
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
