// ———————————————————————–
// <copyright file="HospitalType.cs" company="EDXLSharp">
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
using System.Text;
using System.Xml;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the Hospital sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class HospitalType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// REQUIRED, MUST be used once and only once.
    /// The container element for Organization information elements. 
    /// 1. The generic element Organization refers to the entity, the status and availability of which is being reflected in the status message. 
    /// Not really a string, just a place holder
    /// </summary>
    private OrganizationType organization;

    /// <summary>
    /// OPTIONAL 
    /// The container of all of the elements related to the emergency department status.  
    /// 1. It describes the ability of this emergency department to treat patients.
    /// </summary>
    private EmergencyDepartmentStatusType emergencyDepartmentStatus;

    /// <summary>
    /// OPTIONAL 
    /// The container of all of the elements related to the hospital bed capacity and status.  
    /// 1. For each of the bed types (AdultICU, MedicalSurgical, etc.), if needed, a collection of named sub-types MAY be provided.  
    /// 2. A hospital MAY specify the number of sub-categories without specifying all of the sub-categories.
    /// 3. The totals of sub-categories MAY equal the capacity data specified in the parent.  
    /// Example, a hospital may sub-categorize Adult ICU beds into Surgery, Cardiac, General and Neurological.  
    /// BedCapacity
    /// CONDITIONAL; May use multiple
    /// Container element to identify the number of available beds. 
    /// 1. Multiple instances of BedCapacity elements MAY be specified. 
    /// 2. Each parent BedType element and its associated sub-category bed types MUST be encapsulated with a BedCapacity element. 
    /// </summary>
    private List<BedCapacityType> hospitalBedCapacityStatus;

    /// <summary>
    /// OPTIONAL
    /// The container element of all the elements of service coverage. This includes both the necessary staff and facilities. Indicator of the availability of specialty service coverage.
    /// 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    /// 1. Some of the services capabilities are broken down into subtypes. This is to allow organizations to designate subtypes, if available. 
    /// 2. If not, only the higher level specialties are reported.
    /// 3. Organizations can either report the parent category or report the subcategories.
    /// </summary>
    private ServiceCoverageStatusType serviceCoverageStatus;

    /// <summary>
    /// OPTIONAL
    /// The container of all of the elements related to the status of the facility.  The elements in FacilityStatus provide a general status of the facility. 
    /// </summary>
    private HospitalFacilityStatusType hospitalFacilityStatus;

    /// <summary>
    /// OPTIONAL
    /// The container for all the elements related to the operations of the facility.
    /// </summary>
    private HospitalResourcesStatusType hospitalResourcesStatus;

    /// <summary>
    /// REQUIRED
    /// The last time the information was updated.
    /// Each hospital element MUST have a LastUpdateTime
    /// </summary>
    private DateTime lastUpdateTime;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the HospitalType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public HospitalType()
    {
      this.HospitalBedCapacityStatus = new List<BedCapacityType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// REQUIRED, MUST be used once and only once.
    /// The container element for Organization information elements. 
    /// 1. The generic element Organization refers to the entity, the status and availability of which is being reflected in the status message. 
    /// </summary>
    public OrganizationType Organization
    {
      get { return this.organization; }
      set { this.organization = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The container of all of the elements related to the emergency department status.  
    /// 1. It describes the ability of this emergency department to treat patients.
    /// </summary>
    public EmergencyDepartmentStatusType EmergencyDepartmentStatus
    {
      get { return this.emergencyDepartmentStatus; }
      set { this.emergencyDepartmentStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The container of all of the elements related to the hospital bed capacity and status.  
    /// 1. For each of the bed types (AdultICU, MedicalSurgical, etc.), if needed, a collection of named sub-types MAY be provided.  
    /// 2. A hospital MAY specify the number of sub-categories without specifying all of the sub-categories.
    /// 3. The totals of sub-categories MAY equal the capacity data specified in the parent.  
    /// Example, a hospital may sub-categorize Adult ICU beds into Surgery, Cardiac, General and Neurological.  
    /// BedCapacity
    /// CONDITIONAL; May use multiple
    /// Container element to identify the number of available beds. 
    /// 1. Multiple instances of BedCapacity elements MAY be specified. 
    /// 2. Each parent BedType element and its associated sub-category bed types MUST be encapsulated with a BedCapacity element. 
    /// </summary>
    public List<BedCapacityType> HospitalBedCapacityStatus
    {
      get { return this.hospitalBedCapacityStatus; }
      set { this.hospitalBedCapacityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container element of all the elements of service coverage. This includes both the necessary staff and facilities. Indicator of the availability of specialty service coverage.
    /// 1. Either one – the parent category or the subcategories - MUST be used. Both MUST not be used together.
    /// 1. Some of the services capabilities are broken down into subtypes. This is to allow organizations to designate subtypes, if available. 
    /// 2. If not, only the higher level specialties are reported.
    /// 3. Organizations can either report the parent category or report the subcategories.
    /// </summary>
    public ServiceCoverageStatusType ServiceCoverageStatus
    {
      get { return this.serviceCoverageStatus; }
      set { this.serviceCoverageStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container of all of the elements related to the status of the facility.  The elements in FacilityStatus provide a general status of the facility. 
    /// </summary>
    public HospitalFacilityStatusType HospitalFacilityStatus
    {
      get { return this.hospitalFacilityStatus; }
      set { this.hospitalFacilityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container for all the elements related to the operations of the facility.
    /// </summary>
    public HospitalResourcesStatusType HospitalResourcesStatus
    {
      get { return this.hospitalResourcesStatus; }
      set { this.hospitalResourcesStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// REQUIRED
    /// The last time the information was updated.
    /// Each hospital element MUST have a LastUpdateTime
    /// </summary>
    public DateTime LastUpdateTime
    {
      get
      {
        return this.lastUpdateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.lastUpdateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    /// <param name="linkUID">Pointer to a Valid Link UID</param>
    public void ToGeoRSS(SyndicationItem myitem, Guid linkUID)
    {
      StringBuilder contentstr = new StringBuilder();
      myitem.Categories.Add(new SyndicationCategory(EDXLConstants.HAVESyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      this.organization.ToGeoRSS(myitem);
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.lastUpdateTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "HAVE/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;
      if (this.emergencyDepartmentStatus != null)
      {
        this.emergencyDepartmentStatus.ToGeoRSS(myitem, contentstr);
      }

      myitem.Content = new TextSyndicationContent(contentstr.ToString());

      if (string.IsNullOrEmpty(myitem.Title.ToString()))
      {
        myitem.Title = new TextSyndicationContent(EDXLConstants.HAVESyndicationTitle + " " + linkUID.ToString());
      }

      if (myitem.Content == null)
      {
        myitem.Content = new TextSyndicationContent("We are a hospital");
      }

      if (myitem.Authors.Count == 0)
      {
        myitem.Authors.Add(new SyndicationPerson("foo@bar.com", "Overlord of Hospitals", string.Empty));
      }

      if (myitem.Summary == null)
      {
        myitem.Summary = new TextSyndicationContent("People get treated here");
      }
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

      if (this.organization != null)
      {
        xwriter.WriteStartElement("Organization");
        this.organization.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.emergencyDepartmentStatus != null)
      {
        xwriter.WriteStartElement("EmergencyDepartmentStatus");
        this.emergencyDepartmentStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.hospitalBedCapacityStatus.Count > 0)
      {
        xwriter.WriteStartElement("HospitalBedCapacityStatus");
        foreach (BedCapacityType bed_type in this.hospitalBedCapacityStatus)
        {
          xwriter.WriteStartElement("BedCapacity");
          bed_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.serviceCoverageStatus != null)
      {
        xwriter.WriteStartElement("ServiceCoverageStatus");
        this.serviceCoverageStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.hospitalFacilityStatus != null)
      {
        xwriter.WriteStartElement("HospitalFacilityStatus");
        this.hospitalFacilityStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.hospitalResourcesStatus != null)
      {
        xwriter.WriteStartElement("HospitalResourcesStatus");
        this.hospitalResourcesStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.lastUpdateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("LastUpdateTime", this.lastUpdateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      BedCapacityType bedcapacitytypetmp;

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Organization":
            this.organization = new OrganizationType();
            this.organization.ReadXML(node);
            break;
          case "EmergencyDepartmentStatus":
            this.emergencyDepartmentStatus = new EmergencyDepartmentStatusType();
            this.emergencyDepartmentStatus.ReadXML(node);
            break;
          case "HospitalBedCapacityStatus":
            if (this.hospitalBedCapacityStatus == null)
            {
              this.hospitalBedCapacityStatus = new List<BedCapacityType>();
            }

            // this loop is used to breakdown the element HospitalBedCapacityStatus to the BedCapacity node, which might have multiple
            foreach (XmlNode bc in node.ChildNodes)
            {
              bedcapacitytypetmp = new BedCapacityType();
              bedcapacitytypetmp.ReadXML(bc);
              this.hospitalBedCapacityStatus.Add(bedcapacitytypetmp);
            }

            break;
          case "ServiceCoverageStatus":
            this.serviceCoverageStatus = new ServiceCoverageStatusType();
            this.serviceCoverageStatus.ReadXML(node);
            break;
          case "HospitalFacilityStatus":
            this.hospitalFacilityStatus = new HospitalFacilityStatusType();
            this.hospitalFacilityStatus.ReadXML(node);
            break;
          case "HospitalResourcesStatus":
            this.hospitalResourcesStatus = new HospitalResourcesStatusType();
            this.hospitalResourcesStatus.ReadXML(node);
            break;
          case "LastUpdateTime":
            this.lastUpdateTime = DateTime.Parse(node.InnerText);
            if (this.lastUpdateTime.Kind == DateTimeKind.Unspecified)
            {
              this.lastUpdateTime = DateTime.MinValue;
              throw new ArgumentException("TimeZone Information Must Be Specified");
            }

            this.lastUpdateTime = this.lastUpdateTime.ToUniversalTime();
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in HospitalType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (this.organization == null)
      {
        throw new ArgumentNullException("Organization is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.lastUpdateTime.ToString()))
      {
        throw new ArgumentNullException("LastUpdateTime is required and can't be null");
      }
    }
    #endregion

    #region Protected Member Functions
    #endregion
  }
}
