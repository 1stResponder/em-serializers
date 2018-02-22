using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// EIDD Status Code List
  /// </summary>
  [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "This enumeration contains lots of short summaries")]
  [Serializable]
  public enum ResourceEIDDStatusCodeList
  {
    /// <summary>
    /// Emergency unit acknowledged receipt of a dispatch/assignment
    /// </summary>
    [XmlEnum(Name ="ACKNOWLEDGED TRANSMISSION")]
    AcknowledgedTransmission,

    /// <summary>
    /// Emergency unit is at an alternate location when used as a standalone secondary status 
    /// or is en route to, transporting to, arrived at, etc. when used in combination with 
    /// another secondary unit status-common 
    /// </summary>
    [XmlEnum(Name = "ALTERNATE LOCATION")]
    AlternateLocation,

    /// <summary>
    /// Emergency unit arrived at the incident location or at some other location 
    /// </summary>
    [XmlEnum(Name = "ARRIVED")]
    Arrived,

    /// <summary>
    /// Emergency unit has been assigned to an incident or to some other event
    /// </summary>
    [XmlEnum(Name = "ASSIGNED")]
    Assigned,

    /// <summary>
    /// Emergency unit's assignment to an activity has been cancelled. 
    /// This is an observation useful for tracking unit history and incident progress 
    /// </summary>
    [XmlEnum(Name = "ASSIGNMENT CANCELED")]
    AssignmentCanceled,

    /// <summary>
    /// Emergency unit is back to patrolling or covering its assigned area, beat, or district. 
    /// This is an observation useful for tracking unit history
    /// </summary>
    [XmlEnum(Name = "BACK TO ASSIGNED AREA")]
    BackToAssignedArea,

    /// <summary>
    /// Emergency unit is backing up another emergency unit on an incident 
    /// </summary>
    [XmlEnum(Name = "BACK UP")]
    BackUp,

    /// <summary>
    /// Emergency unit is on a break 
    /// </summary>
    [XmlEnum(Name = "BREAK")]
    Break,

    /// <summary>
    /// Emergency unit checked in with its dispatcher. This is an observation useful for tracking unit history and incident progress 
    /// </summary>
    [XmlEnum(Name = "CHECKED IN")]
    CheckedIn,

    /// <summary>
    /// Emergency unit cleared the incident location or some other location  
    /// </summary>
    [XmlEnum(Name = "CLEARED")]
    Cleared,

    /// <summary>
    /// Emergency unit is involved in Community Oriented Policing or Problem Oriented Policing activities
    /// </summary>
    [XmlEnum(Name = "COP/POP")]
    CopPop,

    /// <summary>
    /// Emergency unit is assigned to Court 
    /// </summary>
    [XmlEnum(Name = "COURT")]
    Court,

    /// <summary>
    /// Emergency unit is patrolling, has moved up, or is covering an alternate area, beat, station, 
    /// or district when used as a standalone secondary status or is
    /// </summary>
    [XmlEnum(Name = "COVERING ALTERNATE AREA")]
    CoveringAlternateArea,

    /// <summary>
    /// Emergency Unit is off duty
    /// </summary>
    [XmlEnum(Name = "OFF DUTY")]
    OffDuty,

    /// <summary>
    /// Emergency unit is on duty
    /// </summary>
    [XmlEnum(Name = "ON DUTY")]
    OnDuty,

    /// <summary>
    /// Emergency Unit is located at the scene (location) of the incident 
    /// </summary>
    [XmlEnum(Name = "ON SCENE")]
    OnScene,

    /// <summary>
    /// Emergency unit is out of service 
    /// </summary>
    [XmlEnum(Name = "OUT OF SERVICE")]
    OutOfService,

    /// <summary>
    /// Emergency responders made contact with a patient involved in the incident. 
    /// This is an observation useful for tracking unit history and incident progress
    /// </summary>
    [XmlEnum(Name = "PATIENT CONTACT")]
    PatientContact,

    /// <summary>
    /// Emergency unit is at a post when used as a standalone secondary unit status-common 
    /// or is en route to, arrived at, etc. when used in combination with another secondary unit status-common
    /// </summary>
    [XmlEnum(Name = "POST")]
    Post,

    /// <summary>
    /// Emergency unit is on a self initiated event that is not a traffic stop
    /// </summary>
    [XmlEnum(Name = "RESPONDER INITIATED EVENT")]
    ResponderInitiatedEvent,

    /// <summary>
    /// Emergency unit is at Roll Call when used as a standalone secondary unit status-common 
    /// or is en route to, arrived at, etc. when used in combination with another secondary unit status common
    /// </summary>
    [XmlEnum(Name = "ROLL CALL")]
    RollCall,

    /// <summary>
    /// Emergency unit has automatically been activated, but is not yet available and has not checked in
    /// </summary>
    [XmlEnum(Name = "ROSTER")]
    Roster,

    /// <summary>
    /// Emergency unit’s end of shift is pending 
    /// </summary>
    [XmlEnum(Name = "SHIFT PENDING")]
    ShiftPending,

    /// <summary>
    /// Emergency unit is at an incident's staging location when used as a standalone secondary unit status common 
    /// or is en route to, arrived at, etc. when used in combination with another secondary unit status-common
    /// </summary>
    [XmlEnum(Name = "STAGING")]
    Staging,

    /// <summary>
    /// Emergency unit is at its headquarters, station, or substation when used as a standalone secondary unit status-common 
    /// or is en route to, transporting to, arrived at, etc. when used in combination with another secondary unit status-common
    /// </summary>
    [XmlEnum(Name = "STATION")]
    Station,

    /// <summary>
    /// Emergency unit is on scene at a self initiated traffic stop
    /// </summary>
    [XmlEnum(Name = "TRAFFIC STOP")]
    TrafficStop,

    /// <summary>
    /// Emergency unit and responders are participating in a training activity 
    /// </summary>
    [XmlEnum(Name = "TRAINING")]
    Training,

    /// <summary>
    /// Emergency unit is transporting or escorting a person or equipment to a location or destination
    /// </summary>
    [XmlEnum(Name = "TRANSPORTING")]
    Transporting,

    /// <summary>
    /// Emergency unit is not adequately staffed 
    /// </summary>
    [XmlEnum(Name = "UNMANNED")]
    Unmanned
  }
}
