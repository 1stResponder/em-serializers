//-----------------------------------------------------------------------
// <copyright file="InfrastructureTrendList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EMS.NIEM.Infrastructure
{
    /// <summary>
    /// Represents the trend of the infrastructure status
    /// </summary>
    [Serializable]
    public enum InfrastructureTrendCodeList
  {
    /// <summary>
    /// Getting better over time
    /// </summary>
    [XmlEnum(Name = "IMPROVING")]
    Improving,

    /// <summary>
    /// Getting worse over time
    /// </summary>
    [XmlEnum(Name = "DEGRADING")]
    Degrading,

    /// <summary>
    /// Remaining the same over time
    /// </summary>
    [XmlEnum(Name = "STABLE")]
    Stable
  }
}