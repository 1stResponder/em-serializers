// ———————————————————————–
// <copyright file="ResponseResourcesDetail.cs" company="EDXLSharp">
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
using EDXLSharp.CIQLib;
using GeoOASISWhereLib;

namespace MEXLSitRep
{
  /// <summary>
  /// Response Resources Detail sub type of Response Resources Totals
  /// </summary>
  [Serializable]
  public partial class ResponseResourcesDetail
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// CIQ Organization Information container object
    /// </summary>
    private OrganizationInformation agencyOrganization;

    /// <summary>
    /// place holder - what should the type be?
    /// Name of an Incident Command Branch, Division, or Group, or their 
    /// leadership title or name, or the name of a location (such as a “staging 
    /// area”) of the work assignment for those resources (by “Type/Category/Kind”).
    /// </summary>
    private string branchDivisionGroupLocation;

    /// <summary>
    /// The work assignments given to each of the Divisions/Groups plus any special 
    /// assignment instructions.
    /// </summary>
    private string workAssignment;

    /// <summary>
    /// type, category or kind
    /// </summary>
    private string typeCategoryKind;

    /// <summary>
    /// For each Branch/Division/Group/Location” / “WorkAssignment/SpecialInstructions” combination, 
    /// a listing of the Supervisory and non-supervisory ICSPositions not directly assigned to a 
    /// previously identified resource (e.g. Division or Group Supervisor, Assistant Safety Officer, 
    /// Technical Specialist…)
    /// </summary>
    private string overheadPosition;

    /// <summary>
    /// For each Branch/Division/Group/Location” / “WorkAssignment/SpecialInstructions” combination, 
    /// a listing of special equipment or supplies needed.
    /// </summary>
    private string specialEquipment;

    /// <summary>
    /// The location where the “needed” resources are to report (e.g. “IncidentStagingArea”, 
    /// “IncidentLocation”)
    /// </summary>
    private GeoOASISWhere reportingLocation;

    /// <summary>
    /// The DateTime where the “needed” resources are requested to arrive at the “ReportingLocation”.
    /// </summary>
    private DateTime requestedArrival;

    /// <summary>
    /// Estimated time of arrival
    /// </summary>
    private DateTime eta;

    /// <summary>
    /// Incident command organization and assignments container object
    /// </summary>
    private IncidentCommandOrganizationandAssignments organizationAndAssignments;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ResponseResourcesDetail class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ResponseResourcesDetail()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public OrganizationInformation AgencyOrganization
    {
      get { return this.agencyOrganization; }
      set { this.agencyOrganization = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string BranchDivisionGroupLocation
    {
      get { return this.branchDivisionGroupLocation; }
      set { this.branchDivisionGroupLocation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string TypeCategoryKind
    {
      get { return this.typeCategoryKind; }
      set { this.typeCategoryKind = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string OverheadPosition
    {
      get { return this.overheadPosition; }
      set { this.overheadPosition = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string SpecialEquipment
    {
      get { return this.specialEquipment; }
      set { this.specialEquipment = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public GeoOASISWhere ReportingLocation
    {
      get { return this.reportingLocation; }
      set { this.reportingLocation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string WorkAssignment
    {
      get { return this.workAssignment; }
      set { this.workAssignment = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime RequestedArrival
    {
      get { return this.requestedArrival; }
      set { this.requestedArrival = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public DateTime ETA
    {
      get { return this.eta; }
      set { this.eta = value; }
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
      xwriter.WriteStartElement("ResponseResourcesDetail");

      if (this.agencyOrganization != null)
      {
        xwriter.WriteStartElement("AgencyOrganization");
        this.agencyOrganization.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.branchDivisionGroupLocation != null)
      {
        xwriter.WriteElementString("BranchDivisionGroupLocation", this.branchDivisionGroupLocation);
      }

      if (this.typeCategoryKind != null)
      {
        xwriter.WriteElementString("TypeCategoryKind", this.typeCategoryKind);
      }

      if (this.overheadPosition != null)
      {
        xwriter.WriteElementString("OverheadPosition", this.overheadPosition);
      }

      if (this.specialEquipment != null)
      {
        xwriter.WriteElementString("SpecialEquipment", this.specialEquipment);
      }

      if (this.reportingLocation != null)
      {
        xwriter.WriteStartElement("ReportingLocation");
        this.reportingLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.workAssignment != null)
      {
        xwriter.WriteElementString("WorkAssignment", this.workAssignment);
      }

      if (this.requestedArrival != null)
      {
        xwriter.WriteElementString("RequestedArrival", this.requestedArrival.ToString());
      }

      if (this.eta != null)
      {
        xwriter.WriteElementString("ETA", this.eta.ToString());
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
          case "AgencyOrganization":
            this.agencyOrganization = new OrganizationInformation();
            this.agencyOrganization.ReadXML(childnode.FirstChild);
            break;
          case "BranchDivisionGroupLocation":
            this.branchDivisionGroupLocation = childnode.InnerText;
            break;
          case "TypeCategoryKind":
            this.typeCategoryKind = childnode.InnerText;
            break;
          case "OverheadPosition":
            this.overheadPosition = childnode.InnerText;
            break;
          case "SpecialEquipment":
            this.specialEquipment = childnode.InnerText;
            break;
          case "ReportingLocation":
            this.reportingLocation = new GeoOASISWhere();
            this.reportingLocation.ReadXML(childnode.FirstChild);
            break;
          case "WorkAssignment":
            this.workAssignment = childnode.InnerText;
            break;
          case "RequestedArrival":
            this.requestedArrival = Convert.ToDateTime(childnode.InnerText);
            break;
          case "ETA":
            this.eta = Convert.ToDateTime(childnode.InnerText);
            break;
          case "IncidentCommandOrganizationandAssignments":
            this.organizationAndAssignments.ReadXML(childnode);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ResponseResourcesDetail");
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
      if (string.IsNullOrEmpty(this.typeCategoryKind))
      {
        throw new ArgumentNullException("TypeCategoryKind is required and can't be null or empty!");
      }
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
