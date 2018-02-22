//-----------------------------------------------------------------------
// <copyright file="IncidentEIDDStatusCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Incident
{
  /// <summary>
  /// EIDD Status Code List
  /// </summary>
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "This enumeration contains lots of short summaries")]
  [Serializable]
  public enum IncidentEIDDStatusCodeList
  {
    /// <summary>
    /// Incident cancelled
    /// </summary>
    [XmlEnum(Name = "CANCELLED")]
    Cancelled,

    /// <summary>
    /// Emergency responder has declared that a fire is under control
    /// </summary>
    [XmlEnum(Name = "FIRE UNDER CONTROL")]
    FireUnderControl,

    /// <summary>
    /// The incident's location has changed
    /// </summary>
    [XmlEnum(Name = "NEW LOCATION")]
    NewLocation,

    /// <summary>
    /// The incident has been re-opened
    /// </summary>
    [XmlEnum(Name = "REOPENED")]
    Reopened,

    /// <summary>
    /// The incident has had at least one emergency resource assigned to it 
    /// </summary>
    [XmlEnum(Name = "RESOURCES ASSIGNED")]
    ResourcesAssigned,

    /// <summary>
    /// At least one emergency resource is en route to the incident
    /// </summary>
    [XmlEnum(Name = "RESOURCES ENROUTE")]
    ResourcesEnroute,

    /// <summary>
    ///  At least one emergency resource has arrived at the location (on scene) of the incident 
    /// </summary>
    [XmlEnum(Name = "RESOURCES ON SCENE")]
    ResourcesOnScene,

    /// <summary>
    /// Emergency responder has declared that the structure has been cleared. 
    /// </summary>
    [XmlEnum(Name = "STRUCTURE CLEARED")]
    StructureCleared

  }
}
