// ———————————————————————–
// <copyright file="SituationObservation.cs" company="EDXLSharp">
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

namespace MEXLSitRepLib
{
  /// <summary>
  /// A Lightweight Field or Spot Report 
  /// </summary>
  [Serializable]
  public partial class SituationObservation : ISitRepReport
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// The Geo-Location This Observation Applies To
    /// </summary>
    private GeoOASISWhere reportLocation;

    /// <summary>
    /// Free Text String to Communicate Immediate Needs
    /// </summary>
    private string immediateNeeds;

    /// <summary>
    /// Represents The General Type of Observation
    /// </summary>
    private SitRepObservationType? observationType;

    /// <summary>
    /// Free Text of the Observation
    /// </summary>
    private string observationText;

    /// <summary>
    /// Unique Identifier for This Observation
    /// </summary>
    private string observationID;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the SituationObservation class
    /// Default Constructor - Does Nothing
    /// </summary>
    public SituationObservation()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Unique Identifier for This Observation
    /// </summary>
    public string ObservationID
    {
      get { return this.observationID; }
      set { this.observationID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free Text of the Observation
    /// </summary>
    public string ObservationText
    {
      get { return this.observationText; }
      set { this.observationText = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Represents The General Type of Observation
    /// </summary>
    public SitRepObservationType? ObservationType
    {
      get { return this.observationType; }
      set { this.observationType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free Text String to Communicate Immediate Needs
    /// </summary>
    public string ImmediateNeeds
    {
      get { return this.immediateNeeds; }
      set { this.immediateNeeds = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Geo-Location This Observation Applies To
    /// </summary>
    public GeoOASISWhere ReportLocation
    {
      get { return this.reportLocation; }
      set { this.reportLocation = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("SituationObservation");
      if (!string.IsNullOrEmpty(this.observationID))
      {
        xwriter.WriteElementString("ObservationID", this.observationID);
      }

      if (this.observationType != null)
      {
        xwriter.WriteElementString("ObservationType", this.observationType.ToString());
      }

      if (!string.IsNullOrEmpty(this.observationText))
      {
        xwriter.WriteElementString("ObservationText", this.observationText);
      }

      if (!string.IsNullOrEmpty(this.immediateNeeds))
      {
        xwriter.WriteElementString("ImmediateNeeds", this.immediateNeeds);
      }

      if (this.reportLocation != null)
      {
        xwriter.WriteStartElement("ReportLocation");
        this.reportLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
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
          case "ObservationID":
            this.observationID = childnode.InnerText;
            break;
          case "ObservationType":
            this.observationType = (SitRepObservationType)Enum.Parse(typeof(SitRepObservationType), childnode.InnerText);
            break;
          case "ObservationText":
            this.observationText = childnode.InnerText;
            break;
          case "ImmediateNeeds":
            this.immediateNeeds = childnode.InnerText;
            break;
          case "ReportLocation":
            this.reportLocation = new GeoOASISWhere();
            this.reportLocation.ReadXML(childnode.FirstChild);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in SituationObservation");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Syndication Item to Populate</param>
    internal override void ToGeoRSS(System.ServiceModel.Syndication.SyndicationItem myitem)
    {
      myitem.Title = new TextSyndicationContent("Field Observation - " + this.observationType.ToString() + " (EDXL-SitRep)");
      TextSyndicationContent content = new TextSyndicationContent("Observation: " + this.observationText + "\nImmediate Needs: " + this.immediateNeeds);
      myitem.Content = content;
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal override void SetContentKeywords(ValueList ckw)
    {
      ckw.Value.Add("MEXL-SitRep SituationObservation");
    }

    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      if (this.observationType == null)
      {
        throw new ArgumentNullException("Observation Type is required and can't be null or empty!");
      }
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
