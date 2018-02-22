//-----------------------------------------------------------------------
// <copyright file="IncidentPrimaryStatusCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.Incident
{
    /// <summary>
    /// Primary status of this incident based off LA and Fairfax data.
    /// </summary>
    [Serializable]
    public enum IncidentPrimaryStatusCodeList
  {
    /// <summary>
    /// A call has been received about an incident, but no resources are enroute.
    /// </summary>
    [XmlEnum(Name = "PENDING")]
    Pending,

    /// <summary>
    /// At least one resource is/has been enroute to the incident.
    /// </summary>
    [XmlEnum(Name = "ACTIVE")]
    Active,

    /// <summary>
    /// All resources assigned to the incident are cleared.
    /// </summary>
    [XmlEnum(Name = "CLOSED")]
    Closed,

    /// <summary>
    /// This status should only be used by a processing application when it receives a status from a jurisdiction
    /// that has not been mapped to one of the other primary status codes. No codes should be explicitely mapped to this value. 
    /// A good faith attempt should be to map all codes in use within a jurisdiction one of the other primary status codes.
    /// </summary>
    [XmlEnum(Name = "UNKNOWN")]
    Unknown
  }
}
