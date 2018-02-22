// ———————————————————————–
// <copyright file="HospitalFacilityStatusType.cs" company="EDXLSharp">
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
using System.Xml;

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the HospitalFacilityStatus sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class HospitalFacilityStatusType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// Whether the Emergency Operations Center (EOC) is currently operating. 
    /// 1. Values: 
    /// • Active – Indicates that the EOC has been activated. An activated EOC is fully staffed and operational.   
    /// • Inactive – Indicates that the EOC is not activated. 
    /// 2. Default Value: Inactive
    /// Note: An EOC is a location that is activated in a disaster or emergency from which the overall command, control, communications and coordination are conducted. 
    /// Note: The EOC is typically activated in disasters or other special situations, and this term is NOT intended to indicate whether the clinical emergency department is open for patient care.
    /// </summary>
    private ActiveStatusType? hospitalEOCStatus;

    /// <summary>
    /// OPTIONAL 
    /// Whether the hospital has activated its Emergency Operations Plan (EOP) 
    /// Values: 
    /// 1. Active
    /// 2. Inactive
    /// Note: An EOC Plan documents operations during an emergency, including the process to activate or inactivate the EOC.
    /// </summary>
    private ActiveStatusType? hospitalEOCPlan;

    /// <summary>
    /// OPTIONAL 
    /// The clinical status of the facility. 
    /// Values: 
    /// 1. Normal - Hospital clinical resources are operating within normal conditions.
    /// 2. Full - Hospital clinical resources are exceeded and acceptable care cannot be provided to additional patients. Diversion or community surge response is required.
    /// </summary>
    private ClinicalStatusType? clinicalStatus;

    /// <summary>
    /// OPTIONAL
    /// The container element for Decon capacity.
    /// </summary>
    private DeconCapacityType deconCapacity;

    // MorgueCapacity
    // OPTIONAL 
    // The status of the morgue capacity.

    /// <summary>
    /// OPTIONAL 
    /// The status of the morgue capacity. 
    /// Values: 
    /// 1. Open - Space is available
    /// 2. Full - All normal space is in use
    /// 3. Exceeded - Storage needs exceed available space
    /// </summary>
    private MorgueCapacityStatusType? morgueCapacityStatus;

    /// <summary>
    /// OPTIONAL 
    /// The number of vacant/available units to which victims can be immediately transported. 
    /// </summary>
    private int? morgueCapacityUnits;

    /// <summary>
    /// OPTIONAL 
    /// The status of the facility. 
    /// Values: 
    /// 1. Normal - No conditions exist that adversely affect the general operations of the facility.
    /// 2. Compromised - General operations of the facility have been affected due to damage, operating on emergency backup systems, or facility contamination. 
    /// 3. Evacuating - Indicates that a hospital is in the process of a partial or full evacuation.  
    /// 4. Closed - Indicates that a hospital is no longer capable of providing services and only emergency services/restoration personnel may remain in the facility. 
    /// </summary>
    private FacilityStatusType? facilityStatus;

    /// <summary>
    /// OPTIONAL 
    /// The status of security procedures in the hospital. 
    /// Values: 
    /// 1. Normal - The hospital is operating under routine security procedures. 
    /// 2. Elevated - The hospital has activated increased security procedures (awareness, surveillance) due to a potential threat, or specific security related event i.e. increase in local threat level, VIP, bomb threat. 
    /// 3. RestrictedAccess - Based on security needs, the hospital has activated procedures to allow access to the facility through a reduced number of controlled entrances. 
    /// 4. Lockdown - Based on security needs, the hospital has activated procedures to control entry to the facility to authorized persons only.
    /// 5. Quarantine - Based on a public health emergency, the entry and exit of the facility is controlled by public health officials.
    /// </summary>
    private SecurityStatusType? securityStatus;

    /// <summary>
    /// OPTIONAL 
    /// The container element for reporting activities in the last 24 hours.  
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    private Activity24HrType activity24Hr;

    /// <summary>
    /// Comment Text
    /// </summary>
    private List<string> commentText;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the HospitalFacilityStatusType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public HospitalFacilityStatusType()
    {
      this.commentText = new List<string>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// Whether the Emergency Operations Center (EOC) is currently operating. 
    /// 1. Values: 
    /// • Active – Indicates that the EOC has been activated. An activated EOC is fully staffed and operational.   
    /// • Inactive – Indicates that the EOC is not activated. 
    /// 2. Default Value: Inactive
    /// Note: An EOC is a location that is activated in a disaster or emergency from which the overall command, control, communications and coordination are conducted. 
    /// Note: The EOC is typically activated in disasters or other special situations, and this term is NOT intended to indicate whether the clinical emergency department is open for patient care.
    /// </summary>
    public ActiveStatusType? HospitalEOCStatus
    {
      get { return this.hospitalEOCStatus; }
      set { this.hospitalEOCStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// Whether the hospital has activated its Emergency Operations Plan (EOP) 
    /// Values: 
    /// 1. Active
    /// 2. Inactive
    /// Note: An EOC Plan documents operations during an emergency, including the process to activate or inactivate the EOC.
    /// </summary>
    public ActiveStatusType? HospitalEOCPlan
    {
      get { return this.hospitalEOCPlan; }
      set { this.hospitalEOCPlan = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The clinical status of the facility. 
    /// Values: 
    /// 1. Normal - Hospital clinical resources are operating within normal conditions.
    /// 2. Full - Hospital clinical resources are exceeded and acceptable care cannot be provided to additional patients. Diversion or community surge response is required.
    /// </summary>
    public ClinicalStatusType? ClinicalStatus
    {
      get { return this.clinicalStatus; }
      set { this.clinicalStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container element for Decon capacity.
    /// </summary>
    public DeconCapacityType DeconCapacity
    {
      get { return this.deconCapacity; }
      set { this.deconCapacity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of the morgue capacity. 
    /// Values: 
    /// 1. Open - Space is available
    /// 2. Full - All normal space is in use
    /// 3. Exceeded - Storage needs exceed available space
    /// </summary>
    public MorgueCapacityStatusType? MorgueCapacityStatus
    {
      get { return this.morgueCapacityStatus; }
      set { this.morgueCapacityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of vacant/available units to which victims can be immediately transported. 
    /// </summary>
    public int? MorgueCapacityUnits
    {
      get { return this.morgueCapacityUnits; }
      set { this.morgueCapacityUnits = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of the facility. 
    /// Values: 
    /// 1. Normal - No conditions exist that adversely affect the general operations of the facility.
    /// 2. Compromised - General operations of the facility have been affected due to damage, operating on emergency backup systems, or facility contamination. 
    /// 3. Evacuating - Indicates that a hospital is in the process of a partial or full evacuation.  
    /// 4. Closed - Indicates that a hospital is no longer capable of providing services and only emergency services/restoration personnel may remain in the facility. 
    /// </summary>
    public FacilityStatusType? FacilityStatus
    {
      get { return this.facilityStatus; }
      set { this.facilityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of security procedures in the hospital. 
    /// Values: 
    /// 1. Normal - The hospital is operating under routine security procedures. 
    /// 2. Elevated - The hospital has activated increased security procedures (awareness, surveillance) due to a potential threat, or specific security related event i.e. increase in local threat level, VIP, bomb threat. 
    /// 3. RestrictedAccess - Based on security needs, the hospital has activated procedures to allow access to the facility through a reduced number of controlled entrances. 
    /// 4. Lockdown - Based on security needs, the hospital has activated procedures to control entry to the facility to authorized persons only.
    /// 5. Quarantine - Based on a public health emergency, the entry and exit of the facility is controlled by public health officials.
    /// </summary>
    public SecurityStatusType? SecurityStatus
    {
      get { return this.securityStatus; }
      set { this.securityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The container element for reporting activities in the last 24 hours.  
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    public Activity24HrType Activity24Hr
    {
      get { return this.activity24Hr; }
      set { this.activity24Hr = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment Text
    /// </summary>
    public List<string> CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
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

      if (this.hospitalEOCStatus != null)
      {
        xwriter.WriteElementString("HospitalEOCStatus", this.hospitalEOCStatus.ToString());
      }

      if (this.hospitalEOCPlan != null)
      {
        xwriter.WriteElementString("HospitalEOCPlan", this.hospitalEOCPlan.ToString());
      }

      if (this.clinicalStatus != null)
      {
        xwriter.WriteElementString("ClinicalStatus", this.clinicalStatus.ToString());
      }

      if (this.deconCapacity != null)
      {
        this.deconCapacity.WriteXML(xwriter);
      }

      if (this.morgueCapacityStatus != null || this.morgueCapacityUnits != null)
      {
        xwriter.WriteStartElement("MorgueCapacity");
        if (this.morgueCapacityStatus != null)
        {
          xwriter.WriteElementString("MorgueCapacityStatus", this.morgueCapacityStatus.ToString());
        }

        if (this.morgueCapacityUnits != null)
        {
          xwriter.WriteElementString("MorgueCapacityUnits", this.morgueCapacityUnits.ToString());
        }

        xwriter.WriteEndElement();
      }

      if (this.facilityStatus != null)
      {
        xwriter.WriteElementString("FacilityStatus", this.facilityStatus.ToString());
      }

      if (this.securityStatus != null)
      {
        xwriter.WriteElementString("SecurityStatus", this.securityStatus.ToString());
      }

      if (this.activity24Hr != null)
      {
        this.activity24Hr.WriteXML(xwriter);
      }

      if (this.commentText.Count > 0)
      {
        foreach (string commenttmp in this.commentText)
        {
          if (string.IsNullOrEmpty(commenttmp))
          {
            continue;
          }

          xwriter.WriteElementString("CommentText", commenttmp);
        }
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "HospitalEOCStatus":
            this.hospitalEOCStatus = (ActiveStatusType)Enum.Parse(typeof(ActiveStatusType), node.InnerText);
            break;
          case "HospitalEOCPlan":
            this.hospitalEOCPlan = (ActiveStatusType)Enum.Parse(typeof(ActiveStatusType), node.InnerText);
            break;
          case "ClinicalStatus":
            this.clinicalStatus = (ClinicalStatusType)Enum.Parse(typeof(ClinicalStatusType), node.InnerText);
            break;
          case "DeconCapacity":
            this.deconCapacity = new DeconCapacityType();
            this.deconCapacity.ReadXML(node);
            break;
          case "MorgueCapacity":
            foreach (XmlNode childNode in node.ChildNodes)
            {
              switch (childNode.LocalName)
              {
                case "MorgueCapacityStatus":
                  this.morgueCapacityStatus = (MorgueCapacityStatusType)Enum.Parse(typeof(MorgueCapacityStatusType), childNode.InnerText);
                  break;
                case "MorgueCapacityUnits":
                  this.morgueCapacityUnits = int.Parse(childNode.InnerText);
                  break;
              }
            }

            break;
          case "FacilityStatus":
            this.facilityStatus = (FacilityStatusType)Enum.Parse(typeof(FacilityStatusType), node.InnerText);
            break;
          case "SecurityStatus":
            this.securityStatus = (SecurityStatusType)Enum.Parse(typeof(SecurityStatusType), node.InnerText);
            break;
          case "Activity24Hr":
            this.activity24Hr = new Activity24HrType();
            this.activity24Hr.ReadXML(node);
            break;
          case "CommentText":
            this.commentText.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in HospitalFacilityStatusType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    #endregion
  }
}
