using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.Resource
{
    /// <summary>
    /// Primary status of this resource, based off of the NENA/APCO EIDD.
    /// </summary>
    [Serializable]
    public enum ResourcePrimaryStatusCodeList
  {
    /// <summary>
    /// Emergency Unit is available for Dispatch 
    /// </summary>
    [XmlEnum(Name = "AVAILABLE")]
    Available,

    /// <summary>
    /// Emergency Unit is assigned to an activity, but is available for dispatch or reassignment  
    /// </summary>
    [XmlEnum(Name = "CONDITIONALLY AVAILABLE")]
    ConditionallyAvailable,

    /// <summary>
    /// Emergency Unit is not available for Dispatch and cannot be assigned to a call 
    /// </summary>
    [XmlEnum(Name = "NOT AVAILABLE")]
    NotAvailable,

    /// <summary>
    /// This status should only be used by a processing application when it receives a status from a jurisdiction
    /// that has not been mapped to one of the other primary status codes. No codes should be explicitely mapped to this value. 
    /// A good faith attempt should be to map all codes in use within a jurisdiction one of the other primary status codes.
    /// </summary>
    [XmlEnum(Name = "UNKNOWN")]
    Unknown
  }
}
