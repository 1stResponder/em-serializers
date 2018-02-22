using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// A simple type for unit statuses based off of recommendations from UCAD. 
  /// </summary>
  [Serializable]
  public enum ResourceUCADStatusCodeList
  {
    /// <summary>
    /// Assigned to an incident.
    /// </summary>
    [XmlEnum(Name="ASSIGNED")]
    Assigned,

    /// <summary>
    /// Enroute to an incident.
    /// </summary>
    [XmlEnum(Name = "ENROUTE")]
    Enroute,

    /// <summary>
    /// At an incident.
    /// </summary>
    [XmlEnum(Name = "AT SCENE")]
    AtScene,

    /// <summary>
    /// Transporting patient (or other) to a destination such as a hospital.
    /// </summary>
    [XmlEnum(Name = "TRANSPORT")]
    Transport,

    /// <summary>
    /// Completed transport. 
    /// </summary>
    [XmlEnum(Name = "TRANSPORT COMPLETE")]
    TransportComplete,

    /// <summary>
    /// Completed transport. Leaving destination of transport..
    /// </summary>
    [XmlEnum(Name = "CLEARED")]
    Cleared,

    /// <summary>
    /// Assigned to a designated stand-by location either predetermined 
    /// or dynamic and based on incident activity and better readiness for response. 
    /// </summary>
    [XmlEnum(Name = "ASSIGNED TO POST")]
    AssignedToPost,

    /// <summary>
    /// Enroute to a designated stand-by location either predetermined 
    /// or dynamic and based on incident activity and better readiness for response. 
    /// </summary>
    [XmlEnum(Name = "ENROUTE TO POST")]
    EnrouteToPost,

    /// <summary>
    /// At a designated stand-by location either predetermined or 
    /// dynamic and based on incident activity and better readiness for response. 
    /// </summary>
    [XmlEnum(Name = "AT POST")]
    AtPost,

    /// <summary>
    /// Available in the area of a designated stand-by location either predetermined 
    /// or dynamic and based on incident activity and better readiness for response. 
    /// </summary>
    [XmlEnum(Name = "AVAILABLE IN AREA OF ASSIGNED POST")]
    AvailableInAreaOfAssignedPost,

    /// <summary>
    /// A resource is available onfor for emergency incidents, for example, a unit has 
    /// released the patient and can respond, but is working on paperwork, stocking supplies.
    /// </summary>
    [XmlEnum(Name = "AVAILABLE FOR EMERGENCY INCIDENTS ONLY")]
    AvailableForEmergencyIncidentsOnly,

    /// <summary>
    /// In the area of the incident and waiting for approval to proceed to the scene of the incident. 
    /// </summary>
    [XmlEnum(Name = "STAGED")]
    Staged,

    /// <summary>
    /// A secondary on scene time that tracks when stand-by stops and contact is made on the incident. 
    /// </summary>
    [XmlEnum(Name = "PATIENT/INCIDENT CONTACT")]
    PatientIncidentContact,
  }
}
