// ———————————————————————–
// <copyright file="SituationInformation.cs" company="EDXLSharp">
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
using System.ServiceModel.Syndication;
using System.Xml;
using EDXLSharp;
using GeoOASISWhereLib;
using MEXLSitRep;

namespace MEXLSitRepLib
{
  /// <summary>
  /// Situation Information Sit Rep type
  /// </summary>
  [Serializable]
  public partial class SituationInformation : MEXLSitRepLib.ISitRepReport
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The name assigned to the incident (often by the Incident Commander or lead Agency).  
    /// </summary>
    private List<string> incidentName;

    /// <summary>
    /// In Visio, not document
    /// </summary>
    private string incidentCause;

    /// <summary>
    /// Information indicating the complexity, complications, level of difficulty or 
    /// cross-profession / jurisdiction / organization aspects involved in addressing
    /// or responding to the incident.
    /// </summary>
    private ComplexityType? incidentComplexity;

    /// <summary>
    /// Overall size of the incident in terms of geographic description or area 
    /// utilizing measures such as  as acres, square miles, hectares, square 
    /// kilometers, etc. (using the element “LocationSizeUOM”).
    /// </summary>
    private string incidentSize;

    /// <summary>
    /// The code denoting the severity of the subject incident or event.
    /// </summary>
    private ValueList severity;

    /// <summary>
    /// Same as incident complexity?
    /// </summary>
    private string incidentType;

    /// <summary>
    /// The Date and Time the Incident started or was first observed. 
    /// </summary>
    private DateTime? incidentStartDateTime;

    /// <summary>
    /// The physical location of the incident.  Capability is required to express and
    /// capture location information in a variety of options including geopolitical 
    /// (e.g. addresses) and geospatial (e.g. latitude/longitude).  
    /// </summary>
    private GeoOASISWhere incidentLocation;

    /// <summary>
    /// A temporary location / site typically assigned by an Incident 
    /// Commander, where Incident Response Resources initially report 
    /// to receive instructions.  May also be a patient triage or other
    /// type of staging area.
    /// </summary>
    private List<string> incidentStagingArea;

    /// <summary>
    /// Map or sketch, in the form of an object, image or geospatial coordinates, showing
    /// the total incident area and total area of operations:  The incident site/area, 
    /// Operations area(s), impacted and threatened areas, over flight results, trajectories, 
    /// impacted shorelines, or other graphics depicting situational status and resource 
    /// deployment. 
    /// </summary>
    private string mapSketch;

    /// <summary>
    ///  The Date and Time a formal disaster is declared by an authority
    /// </summary>
    private DateTime? disasterDeclarationDateTime;

    /// <summary>
    /// The organization, agency or authority that officially declared the disaster.  
    /// </summary>
    private string disasterDeclarationAuthority;

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
    private List<GeoOASISWhere> jurisdicition;

    /// <summary>
    /// ?? remarks ??
    /// </summary>
    private string remarks;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the SituationInformation class
    /// </summary>
    public SituationInformation()
    {
      this.incidentName = new List<string>();
      this.incidentStagingArea = new List<string>();
      this.jurisdicition = new List<GeoOASISWhere>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public List<string> IncidentName
    {
      get { return this.incidentName; }
      set { this.incidentName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string IncidentCause
    {
      get { return this.incidentCause; }
      set { this.incidentCause = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public ComplexityType? IncidentComplexity
    {
      get { return this.incidentComplexity; }
      set { this.incidentComplexity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string IncidentSize
    {
      get { return this.incidentSize; }
      set { this.incidentSize = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public ValueList Severity
    {
      get { return this.severity; }
      set { this.severity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string IncidentType
    {
      get { return this.incidentType; }
      set { this.incidentType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime? IncidentStartDateTime
    {
      get { return this.incidentStartDateTime; }
      set { this.incidentStartDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public GeoOASISWhere IncidentLocation
    {
      get { return this.incidentLocation; }
      set { this.incidentLocation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public List<string> IncidentStagingArea
    {
      get { return this.incidentStagingArea; }
      set { this.incidentStagingArea = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string MapSketch
    {
      get { return this.mapSketch; }
      set { this.mapSketch = value; }
    }

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
    public string DisasterDeclarationAuthority
    {
      get { return this.disasterDeclarationAuthority; }
      set { this.disasterDeclarationAuthority = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public List<GeoOASISWhere> Jurisdiction
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
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      // xwriter.WriteStartElement(EDXLConstants.SitRepPrefix, "SituationInformation", EDXLConstants.SitRep10Namespace);
      xwriter.WriteStartElement("SituationInformation");

      if (this.incidentName != null)
      {
        foreach (string incident in this.incidentName)
        {
          xwriter.WriteElementString("IncidentName", incident);
        }
      }

      if (!string.IsNullOrEmpty(this.incidentCause))
      {
        xwriter.WriteElementString("IncidentCause", this.incidentCause);
      }

      if (this.incidentComplexity != null)
      {
        xwriter.WriteElementString("IncidentComplexity", this.incidentComplexity.ToString());
      }

      if (!string.IsNullOrEmpty(this.incidentSize))
      {
        xwriter.WriteElementString("IncidentSize", this.incidentSize);
      }

      if (this.severity != null)
      {
        xwriter.WriteStartElement("Severity");
        this.severity.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.incidentType))
      {
        xwriter.WriteElementString("IncidentType", this.incidentType);
      }

      if (this.incidentStartDateTime != null)
      {
        xwriter.WriteElementString("IncidentStartDateTime", this.incidentStartDateTime.ToString());
      }

      if (this.incidentLocation != null)
      {
        xwriter.WriteStartElement("IncidentLocation");
        this.incidentLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.incidentStagingArea != null)
      {
        foreach (string area in this.incidentStagingArea)
        {
          xwriter.WriteElementString("IncidentStagingArea", area);
        }
      }

      if (!string.IsNullOrEmpty(this.mapSketch))
      {
        xwriter.WriteElementString("MapSketch", this.mapSketch);
      }

      if (this.disasterDeclarationDateTime != null)
      {
        xwriter.WriteElementString("DisasterDeclarationDateTime", this.disasterDeclarationDateTime.ToString());
      }

      if (!string.IsNullOrEmpty(this.disasterDeclarationAuthority))
      {
        xwriter.WriteElementString("DisasterDeclarationAuthority", this.disasterDeclarationAuthority);
      }

      if (this.jurisdicition != null)
      {
        foreach (GeoOASISWhere where in this.jurisdicition)
        {
          xwriter.WriteStartElement("Jurisdiction");
          where.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      if (!string.IsNullOrEmpty(this.remarks))
      {
        xwriter.WriteElementString("Remarks", this.remarks);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the Situation Information</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      GeoOASISWhere whereTemp = new GeoOASISWhere();
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "IncidentName":
            if (this.incidentName == null)
            {
              this.incidentName = new List<string>();
            }

            this.incidentName.Add(childnode.InnerText);
            break;
          case "IncidentCause":
            this.incidentCause = childnode.InnerText;
            break;
          case "IncidentComplexity":
            this.incidentComplexity = (ComplexityType)Enum.Parse(typeof(ComplexityType), childnode.InnerText);
            break;
          case "IncidentSize":
            this.incidentSize = childnode.InnerText;
            break;
          case "Severity":
            this.severity = new ValueList();
            this.severity.ReadXML(childnode);
            break;
          case "IncidentType":
            this.incidentType = childnode.InnerText;
            break;
          case "IncidentStartDateTime":
            this.incidentStartDateTime = Convert.ToDateTime(childnode.InnerText);
            break;
          case "IncidentLocation":
            this.incidentLocation = new GeoOASISWhere();
            this.incidentLocation.ReadXML(childnode.FirstChild);
            break;
          case "IncidentStagingArea":
            if (this.incidentStagingArea == null)
            {
              this.incidentStagingArea = new List<string>();
            }

            this.incidentStagingArea.Add(childnode.InnerText);
            break;
          case "MapSketch":
            this.mapSketch = childnode.InnerText;
            break;
          case "DisasterDeclarationDateTime":
            this.disasterDeclarationDateTime = Convert.ToDateTime(childnode.InnerText);
            break;
          case "DisasterDeclarationAuthority":
            this.disasterDeclarationAuthority = childnode.InnerText;
            break;
          case "Jurisdiction":
            if (this.jurisdicition == null)
            {
              this.jurisdicition = new List<GeoOASISWhere>();
            }

            whereTemp.ReadXML(childnode.FirstChild);
            this.jurisdicition.Add(whereTemp);
            break;
          case "Remarks":
            this.remarks = childnode.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in SituationInformation");
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
      myitem.Title = new TextSyndicationContent("SituationInformation - " + " (EDXL-SitRep)");
      TextSyndicationContent content = new TextSyndicationContent("Information: " + "\nImmediate Needs: ");
      myitem.Content = content;
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal override void SetContentKeywords(ValueList ckw)
    {
      ckw.Value.Add("MEXL-SitRep SituationInformation");
    }

    #endregion

    #region Protected Member Functions
    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      if (this.incidentName == null)
      {
        throw new ArgumentNullException("Incident Name is required and can't be null");
      }

      if (this.incidentStartDateTime == null)
      {
        throw new ArgumentNullException("Incident Start Date Time is required and can't be null");
      }

      if (this.incidentLocation == null)
      {
        throw new ArgumentNullException("Incident Location is required and can't be null");
      }
    }
    #endregion

    #region Private Member Functions

    #endregion
  }
}
