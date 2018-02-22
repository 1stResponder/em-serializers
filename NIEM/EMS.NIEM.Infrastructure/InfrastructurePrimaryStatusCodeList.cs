//-----------------------------------------------------------------------
// <copyright file="InfrastructurePrimaryStatusList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EMS.NIEM.Infrastructure
{
    /// <summary>
    /// Represents the primary status 
    /// </summary>
    [Serializable]
    public enum InfrastructurePrimaryStatusCodeList
  {
    /// <summary>
    /// Operating at full capacity
    /// </summary>
    [XmlEnum(Name= "FULLYOPERATIONAL")]
    FullyOperational,

    /// <summary>
    /// Operating at less than full capacity
    /// </summary>
    [XmlEnum(Name= "DEGRADED")]
    Degraded,

    /// <summary>
    /// Not operating at all
    /// </summary>
    [XmlEnum(Name= "NONOPERATIONAL")]
    NonOperational,

    /// <summary>
    /// Status is not known
    /// </summary>
    [XmlEnum(Name= "UNKNOWN")]
    Unknown
  }
}