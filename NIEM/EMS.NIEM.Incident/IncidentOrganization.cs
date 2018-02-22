//-----------------------------------------------------------------------
// <copyright file="IncidentOrganization.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.Incident
{
    /// <summary>
    /// Represents the organization who owns an incident
    /// </summary>
    [Serializable]
    public class IncidentOrganization
    {

        /// <summary>
        /// Initializes instance of the Incident Organization class
        /// </summary>
        public IncidentOrganization()
        {
            OrgIDSerialized = new IdentificationID();
            IncidentIDSerialized = new IdentificationID();
        }

        /// <summary>
        /// Gets or sets the status of this incident
        /// </summary>
        [XmlElement(ElementName = "OrganizationIdentification", Namespace = Constants.NiemcoreNamespace)]
        public IdentificationID OrgIDSerialized
        {
            get; set;
        }

        /// <summary>
        /// Gets of sets the organization's id
        /// </summary>
        [XmlIgnore]
        public string OrgID
        {
            get
            {
                return OrgIDSerialized != null ? OrgIDSerialized.ID : "";
            }
            set
            {
                if (this.OrgIDSerialized == null)
                {
                    this.OrgIDSerialized = new IdentificationID(value);
                }
                else
                {
                    this.OrgIDSerialized.ID = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the owning organization for this incident
        /// Optional Element
        /// </summary>
        [XmlElement(ElementName = "IncidentIdentifier")]
        public IdentificationID IncidentIDSerialized
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the organization's id for this resource
        /// </summary>
        [XmlIgnore]
        public string IncidentID
        {
            get
            {
                return IncidentIDSerialized != null ? IncidentIDSerialized.ID : "";
            }
            set
            {
                if (this.IncidentIDSerialized == null)
                {
                    this.IncidentIDSerialized = new IdentificationID(value);
                }
                else
                {
                    this.IncidentIDSerialized.ID = value;
                }
            }
        }

    }
}