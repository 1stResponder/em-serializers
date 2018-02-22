//-----------------------------------------------------------------------
// <copyright file="IncidentPulsePointStatusCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Incident
{
  /// <summary>
  /// Primary statuses based off PulsePoint API.
  /// </summary>
  [Serializable]
  public enum IncidentPulsePointStatusCodeList
  {
    /// <summary>
    /// A call for a paritcular incident has been received
    /// </summary>
    [XmlEnum(Name = "CALL RECEIVED")]
    CallReceived,

    /// <summary>
    /// An EMS determinate code has been assigned
    /// </summary>
    [XmlEnum(Name = "EMS DETERMINANT COMPLETE")]
    EmsDeterminantComplete,

    /// <summary>
    /// Units have been dispatched.
    /// </summary>
    [XmlEnum(Name = "DISPATCH")]
    Dispatch,

    /// <summary>
    /// Units are enroute
    /// </summary>
    [XmlEnum(Name = "ENROUTE")]
    Enroute,

    /// <summary>
    /// The first unit has arrived at the scene
    /// </summary>
    [XmlEnum(Name = "ON SCENE")]
    OnScene,

    /// <summary>
    /// The incident has been declared a "working fire"
    /// </summary>
    [XmlEnum(Name = "WORKING FIRE")]
    WorkingFire,

    /// <summary>
    /// The first ambulance has arrived
    /// </summary>
    [XmlEnum(Name = "AMBULANCE ARRIVED")]
    AmbulanceArrived,

    /// <summary>
    /// Agency personnel has arrived at the patient
    /// </summary>
    [XmlEnum(Name = "PATIENT SIDE")]
    PatientSide,

    /// <summary>
    /// The incident has been declared "under control"
    /// </summary>
    [XmlEnum(Name = "UNDER CONTROL")]
    UnderControl,

    /// <summary>
    /// The last unit assigned to the incident has been cleared from the incident.
    /// </summary>
    [XmlEnum(Name = "CLOSED")]
    Closed
  }
}
