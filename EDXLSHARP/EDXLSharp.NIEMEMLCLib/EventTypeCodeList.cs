//-----------------------------------------------------------------------
// <copyright file="EventTypeCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace EDXLSharp.NIEMEMLCLib
{
    //public enum EventTypeCodeList
    //{
    //    ATOM_AIRTRK
    //}

  /// <summary>
  /// List of event type codes
  /// </summary>
    //[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1630:DocumentationTextMustContainWhitespace", Justification = "This enumeration contains lots of short summaries")]
    //public enum EventTypeCodeList
    //{
    //  /// <summary>
    //  /// ATOM
    //  /// </summary>
    //  ATOM,

    //  /// <summary>
    //  /// AIR TRACK
    //  /// </summary>
    //  ATOM_AIRTRK,

    //  /// <summary>
    //  /// CIVIL AIRCRAFT
    //  /// </summary>
    //  ATOM_AIRTRK_CVL,

    //  /// <summary>
    //  /// FIXED WING
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_FIXD,

    //  /// <summary>
    //  /// Emergency Fixed Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_FIXD_EM,

    //  /// <summary>
    //  /// Fire Fixed Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_FIXD_EM_FIRE,

    //  /// <summary>
    //  /// Fire Rescue Fixed Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_FIXD_EM_FIRE_RESCUE,

    //  /// <summary>
    //  /// ROTARY WING
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_ROT,

    //  /// <summary>
    //  /// Emergency Rotary Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_ROT_EM,

    //  /// <summary>
    //  /// Fire Rotary Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_ROT_EM_FIRE,

    //  /// <summary>
    //  /// Fire Rescue Rotary Wing
    //  /// </summary>
    //  ATOM_AIRTRK_CVL_ROT_EM_FIRE_RESCUE,

    //  /// <summary>
    //  /// GROUND TRACK
    //  /// </summary>
    //  ATOM_GRDTRK,

    //  /// <summary>
    //  /// GROUND TRACK EQUIPMENT
    //  /// </summary>
    //  ATOM_GRDTRK_EQT,

    //  /// <summary>
    //  /// GROUND VEHICLE
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH,

    //  /// <summary>
    //  /// CIVILIAN VEHICLE
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH,

    //  /// <summary>
    //  /// Emergency Management Vehicle
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM,

    //  /// <summary>
    //  /// Communications Vehicle
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_COMMUNICATIONS,

    //  /// <summary>
    //  /// Emergency Medical Services
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS,

    //  /// <summary>
    //  /// Ambulance
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_AMBULANCE,

    //  /// <summary>
    //  /// Advanced Life Support Ambulance
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_AMBULANCE_ALS,

    //  /// <summary>
    //  /// Basic Life Support Ambulance
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_AMBULANCE_BLS,

    //  /// <summary>
    //  /// Ems Cycle Team
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_BICYCLETEAM,

    //  /// <summary>
    //  /// Ems Squad
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_SQUAD,

    //  /// <summary>
    //  /// Ems Supervisor
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_SUPERVISOR,

    //  /// <summary>
    //  /// Fire Services
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE,

    //  /// <summary>
    //  /// Fire Services Air Support
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_AIRSUPPORT,

    //  /// <summary>
    //  /// Fire Services Helicopter Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_AIRSUPPORT_HELICOPTERTENDER,

    //  /// <summary>
    //  /// Fire Bicycle
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_BICYCLE,

    //  /// <summary>
    //  /// Brushfire Utility  
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_BRUSHFIRE,

    //  /// <summary>
    //  /// Brushfire Patrol  
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_BRUSHFIRE_PATROL,

    //  /// <summary>
    //  /// Fire Chief
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_CHIEF,

    //  /// <summary>
    //  /// Fire Assistant Chief
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_CHIEF_ASSISTANT,

    //  /// <summary>
    //  /// Fire Battalion Chief
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_CHIEF_BATTALLION,

    //  /// <summary>
    //  /// Fire Deputy Chief
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_CHIEF_DEPUTY,

    //  /// <summary>
    //  /// Fire Division Chief
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_CHIEF_DIVISION,

    //  /// <summary>
    //  /// Fire Command Post  
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_COMMANDPOST,

    //  /// <summary>
    //  /// Fire Engine
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_ENGINE,

    //  /// <summary>
    //  /// Fire Engine Assessment (Ems Provider)
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_ENGINE_ASSESSMENT,

    //  /// <summary>
    //  /// Fire Engine (Initial Attack)
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_ENGINE_INITIALATTACK,

    //  /// <summary>
    //  /// Fire Engine (Pumper)
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_ENGINE_PUMPER,

    //  /// <summary>
    //  /// Fire Engine Quint
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_ENGINE_QUINT,

    //  /// <summary>
    //  /// Fire Foam 
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_FOAM,

    //  /// <summary>
    //  /// Fire Foam Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_FOAM_TENDER,

    //  /// <summary>
    //  /// Fire Hazmat
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_HAZMAT,

    //  /// <summary>
    //  /// Fire Hazmat (Decontamination Unit)
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_HAZMAT_DECON,

    //  /// <summary>
    //  /// Fire Hazmat Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_HAZMAT_TENDER,

    //  /// <summary>
    //  /// Fire Hose Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_HOSETENDER,

    //  /// <summary>
    //  /// Fire Rehab Utility
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_REHAB,

    //  /// <summary>
    //  /// Fire Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_RESCUE,

    //  /// <summary>
    //  /// Fire Aircraft Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_RESCUE_AIRCRAFTRESCUE,

    //  /// <summary>
    //  /// Heavy Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_RESCUE_HEAVY,

    //  /// <summary>
    //  /// Swift Water Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_RESCUE_SWIFTWATER,

    //  /// <summary>
    //  /// Fire Squad
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_SQUAD,

    //  /// <summary>
    //  /// Fire Transport
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TRANSPORT,

    //  /// <summary>
    //  /// Fire Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TRUCK,

    //  /// <summary>
    //  /// Fire Truck W/ Platform
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TRUCK_PLATFORM,

    //  /// <summary>
    //  /// Fire Truck Quint
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TRUCK_QUINT,

    //  /// <summary>
    //  /// Fire Tunnel Utility
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TUNNEL,

    //  /// <summary>
    //  /// Fire Utility
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_UTILITY,

    //  /// <summary>
    //  /// Air Supply
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_UTILITY_AIR,

    //  /// <summary>
    //  /// Arson
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_UTILITY_ARSON,

    //  /// <summary>
    //  /// Foam Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_UTILITY_FOAM,

    //  /// <summary>
    //  /// SwiftWater
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_UTILITY_SWIFTWATER,

    //  /// <summary>
    //  /// Fire Water Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_WATER,

    //  /// <summary>
    //  /// Law Enforcement
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_LAWENFORCEMENT,

    //  /// <summary>
    //  /// Law Enforcement Car
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_LAWENFORCEMENT_CAR,

    //  /// <summary>
    //  /// Public Works
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS,

    //  /// <summary>
    //  /// Aerial Lift
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_AERIALLIFT,

    //  /// <summary>
    //  /// Bus
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_BUS,

    //  /// <summary>
    //  /// Cement Mixer
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_CEMENTMIXER,

    //  /// <summary>
    //  /// Crane
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_CRANE,

    //  /// <summary>
    //  /// Dozer
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_DOZER,

    //  /// <summary>
    //  /// Dozer Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_DOZER_TENDER,

    //  /// <summary>
    //  /// Food Service
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_FOODSERVICE,

    //  /// <summary>
    //  /// Fuel Service
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_FUELSERVICE,

    //  /// <summary>
    //  /// Diesel Fuel Tender
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_FUELSERVICE_DIESEL,

    //  /// <summary>
    //  /// Lighting
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_LIGHTING,

    //  /// <summary>
    //  /// Loader
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_LOADER,

    //  /// <summary>
    //  /// Wheel Loader
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_LOADER_WHEELED,

    //  /// <summary>
    //  /// Skid Loader
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_LOADER_WHEELED_SKID,

    //  /// <summary>
    //  /// Road Grader
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_ROADGRADER,

    //  /// <summary>
    //  /// Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK,

    //  /// <summary>
    //  /// Dump Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK_DUMP,

    //  /// <summary>
    //  /// Dump Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK_FLATBED,

    //  /// <summary>
    //  /// Stair Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK_STAIR,

    //  /// <summary>
    //  /// Tow Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK_TOW,

    //  /// <summary>
    //  /// Water Truck
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_PUBLICWORKS_TRUCK_WATER,

    //  /// <summary>
    //  /// Search And Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_SEARCHANDRESCUE,

    //  /// <summary>
    //  /// Urban Search and rescue
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_SEARCHANDRESCUE_URBAN,

    //  /// <summary>
    //  /// Public Utilities
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_UTILITIES,

    //  /// <summary>
    //  /// Water Utility
    //  /// </summary>
    //  ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_UTILITIES_WATER,

    //  /// <summary>
    //  /// UNIT
    //  /// </summary>
    //  ATOM_GRDTRK_UNT,

    //  /// <summary>
    //  /// Emergency Management Unit (Other)
    //  /// </summary>
    //  ATOM_GRDTRK_UNT_EM,

    //  /// <summary>
    //  /// Swift Water Rescue
    //  /// </summary>
    //  ATOM_GRDTRK_UNT_EM_FIRE_RESCUE_SWIFTWATER,

    //  /// <summary>
    //  /// Swift Water Coordinator
    //  /// </summary>
    //  ATOM_GRDTRK_UNT_EM_FIRE_RESCUE_SWIFTWATER_COORDINATOR,

    //  /// <summary>
    //  /// Fire Arson Unit
    //  /// </summary>
    //  ATOM_GRDTRK_UNT_EM_OPERATIONS_FIREFIGHTING_ARSON,

    //  /// <summary>
    //  /// Fire Decontamination Unit
    //  /// </summary>
    //  ATOM_GRDTRK_UNT_EM_OPERATIONS_FIREFIGHTING_DECONTAMINATION,

    //  /// <summary>
    //  /// SEA SURFACE TRACK
    //  /// </summary>
    //  ATOM_SSUF,

    //  /// <summary>
    //  /// NON-MILITARY
    //  /// </summary>
    //  ATOM_SSUF_NMIL,

    //  /// <summary>
    //  /// Emergency Management
    //  /// </summary>
    //  ATOM_SSUF_NMIL_EM,

    //  /// <summary>
    //  /// Fire Boat
    //  /// </summary>
    //  ATOM_SSUF_NMIL_EM_FIRE,

    //  /// <summary>
    //  /// BITS
    //  /// </summary>
    //  BITS,

    //  /// <summary>
    //  /// A report
    //  /// </summary>
    //  BITS_REPORT,

    //  /// <summary>
    //  /// An emergency management report
    //  /// </summary>
    //  BITS_REPORT_EM,

    //  /// <summary>
    //  /// An emergency management report that may require dispatched resources
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH,

    //  /// <summary>
    //  /// 911 Hang Up - 911 Hang-Ups
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_911H,

    //  /// <summary>
    //  /// 911 Open Line - 911 Open Line
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_911OPN,

    //  /// <summary>
    //  /// Investigation - General
    //  /// </summary>
    //  BIT_REPORT_EM_DISPATCH_FIRE_INVEST,

    //  /// <summary>
    //  /// Aircraft - Aircraft Related Incidents Including Reported Hijacking
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_AIR,

    //  /// <summary>
    //  /// Fire Alarm - Co - Carbon Monoxide
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRCO,

    //  /// <summary>
    //  /// Fire Alarm - Co2 - Carbon Dioxide
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRCO2,

    //  /// <summary>
    //  /// Fire Alarm - Generic Fire Alarm
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRF,

    //  /// <summary>
    //  /// Fire Alarm - Smoke
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRSMOKE,

    //  /// <summary>
    //  /// Fire Alarm - Gas
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRGAS,

    //  /// <summary>
    //  /// Fire Alarm - Heat
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRHEAT,

    //  /// <summary>
    //  /// Fire Alarm - Keypad
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRKPAD,

    //  /// <summary>
    //  /// Fire Alarm - Nat Gas - Natural Gas
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRNGAS,

    //  /// <summary>
    //  /// Fire Alarm - Propane
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRPROPN,

    //  /// <summary>
    //  /// Alarm Unknown - Audible Alarm Unknown Type
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRU,

    //  /// <summary>
    //  /// Fire Alarm - Water Flow - Includes Sprinkler Alarms
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_ALRWTR,

    //  /// <summary>
    //  /// Box Alarm - Pull Box Alarm For Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_PULL_ALRBOX,

    //  /// <summary>
    //  /// Fire Alarm - Pull Station
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ALARM_PULL_ALRPULL,

    //  /// <summary>
    //  /// Animal Bite - Animal Bites Or Attack By An Animal
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ANIMAL_BITE,

    //  /// <summary>
    //  /// Assist - Assist To Other Agency Or Request For Manpower
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ASSIST,

    //  /// <summary>
    //  /// Hazmat - Hazardous Materials Incident Can Include Fuel Spill
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_CBRE_HAZMAT,

    //  /// <summary>
    //  /// Hazmat involving Train
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_CBRE_HAZMAT_TRAIN,

    //  /// <summary>
    //  /// Building Collapse - Collapsed Building Includes Technical Rescue Incidents
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_COLLAPSE_BLDCLPSE,

    //  /// <summary>
    //  /// Bridge Collapse
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_COLLAPSE_BRGCLPSE,

    //  /// <summary>
    //  /// Entrapment - Includes Accidental Entrapments
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_ENTRAP,

    //  /// <summary>
    //  /// Explosion
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_EXPLOS,

    //  /// <summary>
    //  /// Bomb - Bomb Threat Or Investigation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_EXPLOS_BOMB,

    //  /// <summary>
    //  /// Fireworks - Illegal Use Of Fireworks
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_EXPLOS_FIREWRKS,

    //  /// <summary>
    //  /// Vehicle Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE,

    //  /// <summary>
    //  /// Train Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE_TRAIN,

    //  /// <summary>
    //  /// Train Derailment
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE_TRAIN_DERAIL,

    //  /// <summary>
    //  /// Bus Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE_BUS,

    //  /// <summary>
    //  /// Vessel Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE_VESSEL,

    //  /// <summary>
    //  /// Aircraft Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_VEHICLE_AIRCRAFT,

    //  /// <summary>
    //  /// Fire Aircraft
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FAIRC,

    //  /// <summary>
    //  /// Fire Arson
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FARSON,

    //  /// <summary>
    //  /// Fire Electrical - Includes Arcing Wires
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FELEC,

    //  /// <summary>
    //  /// Fire Fuel Facility - Includes Gas Stations
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FFUEL,

    //  /// <summary>
    //  /// Fire Marine - Includes Marine Vessels and Boats On Waterways (For Boats On Land Use Fire Vehicle)
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FMARINE,

    //  /// <summary>
    //  /// Fire Other - Includes Other Types Not Listed
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FOTHER,

    //  /// <summary>
    //  /// Vehicle Fire
    //  /// </summary>
    //  BIT_REPORT_EM_DISPATCH_FIRE_FIRE_VEHICLE,

    //  /// <summary>
    //  /// Fire Report - Response To Take Fire Report Only No Active Fire
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FREPORT,

    //  /// <summary>
    //  /// Fire Smoke - Includes Fire Investigations
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSMOKE,

    //  /// <summary>
    //  /// Fire Apartment - Multi-Family Dwelling
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FAPT,

    //  /// <summary>
    //  /// Fire Building
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FBLDG,

    //  /// <summary>
    //  /// Fire Hi Rise - 6 Or More Floors
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FHIRIS,

    //  /// <summary>
    //  /// Fire Hospital
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FHOSP,

    //  /// <summary>
    //  /// Fire House - Single Family Detached
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FHOUS,

    //  /// <summary>
    //  /// Fire Jail
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FJAIL,

    //  /// <summary>
    //  /// Fire Nursing Home
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FNH,

    //  /// <summary>
    //  /// Fire Townhouse / Row House
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FSTRU_FTH,

    //  /// <summary>
    //  /// Inaccessible Incident - Includes Breech
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FORCENTR,

    //  /// <summary>
    //  /// Fire Structure - Includes Sheds
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FSTRU,

    //  /// <summary>
    //  /// Fire Unknown
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FUNK,

    //  /// <summary>
    //  /// Fire Vehicle - Includes Small Or Medium Size Vehicles
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FVEH,

    //  /// <summary>
    //  /// Fire Trailer - Single Wide Mobile Home Fires-Double Wide Should Use Fire Structure
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FVEH_FTRAILER,

    //  /// <summary>
    //  /// Fire Train - Any Type Of Railway Fire
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FVEH_FTRAIN,

    //  /// <summary>
    //  /// Fire Truck - Includes Large Vehicles Such As Recreational Vehicle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_FVEH_FTRUCK,

    //  /// <summary>
    //  /// ANIMAL Hazard
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_ANIMAL,

    //  /// <summary>
    //  /// Biological - Biological Threat
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_CBRE_BIO,

    //  /// <summary>
    //  /// Chemical - Includes Chemical And Environmental Incidents
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_CBRE_CHEMICAL,

    //  /// <summary>
    //  /// Environmental Hazard
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_ENVIRO,

    //  /// <summary>
    //  /// Radiation Incident - Includes Nuclear Incidents
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_CBRE_RADIAT,

    //  /// <summary>
    //  /// Electrical Hazard - Includes All Electrical Problems
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_ELECHZD,

    //  /// <summary>
    //  /// Gas Leak - Includes Natural Gas
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_GASLEAK,

    //  /// <summary>
    //  /// Odor - Odor Investigation Any Type
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_ODOR,

    //  /// <summary>
    //  /// Public Works / Utilities - Public Works
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_PUBWKS,

    //  /// <summary>
    //  /// Rescue - Includes Lock-Ins
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_RESCUE,

    //  /// <summary>
    //  /// Water Rescue - All Water Incidents
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_WATER,

    //  /// <summary>
    //  /// Wires Down
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_HAZARD_WIRES,

    //  /// <summary>
    //  /// Fire Department Major Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_MAJORINC,

    //  /// <summary>
    //  /// Fire Department - Mayday
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_MAYDAY,

    //  /// <summary>
    //  /// Outside Fire
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_OUTSIDE,

    //  /// <summary>
    //  /// Fire Brush - Includes Tress
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_OUTSIDE_FBRUSH,

    //  /// <summary>
    //  /// Fire Trash - Refuse Fires
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_FIRE_OUTSIDE_FTRASH,

    //  /// <summary>
    //  /// Public Assistance
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_PSERV,

    //  /// <summary>
    //  /// Citizen Assist - Public Assistance
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_PSERV_CITASST,

    //  /// <summary>
    //  /// Emotionally Disturbed Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_PSERV_EDP,

    //  /// <summary>
    //  /// Vehicle Lock Out
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_PSERV_VEHLOCK,

    //  /// <summary>
    //  /// Public Service - Welfare Check
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_PSERV_WELFARE,

    //  /// <summary>
    //  /// Train - Incidents Other Than Fires Or Derailments Related To Trains
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_RAIL_TRAIN,

    //  /// <summary>
    //  /// Train Derail
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_RAIL_TRAINDRL,

    //  /// <summary>
    //  /// Industrial Accident - Includes Entrapment In Major Machinery
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_ACCIND,

    //  /// <summary>
    //  /// Inhalation Hazard - CO, Inhalation, Hazmat
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_INHALATION,

    //  /// <summary>
    //  /// Search And Rescue
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_SAR,

    //  /// <summary>
    //  /// Incident involving Terrorism
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_TERR,

    //  /// <summary>
    //  /// Search And Rescue
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_SAR_WILDERNESS_HIKER,

    //  /// <summary>
    //  /// Search And Rescue
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_SAR_WILDERNESS,

    //  /// <summary>
    //  /// Extrication - Confined Space Rescue
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_SPECIAL_XTRACATE,

    //  /// <summary>
    //  /// Agency Standby - Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_STDBY,

    //  /// <summary>
    //  /// Trouble - Unknown Type Trouble
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_FIRE_TROUBLE,

    //  /// <summary>
    //  /// Medical Investigation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_INVEST,

    //  /// <summary>
    //  /// Medical Investigation for AED
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_INVEST_AED,

    //  /// <summary>
    //  /// Medical Alarm - General
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALARM,

    //  /// <summary>
    //  /// Defibrillator Alarm - Automated Implantable Cardiac Defibrillator Alarm Or Event
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALARM_ALRDEFIB,

    //  /// <summary>
    //  /// Medical Alarm
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALARM_ALRMED,

    //  /// <summary>
    //  /// Box Alarm - Pull Box Alarm For Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALARM_PULL_ALRBOX,

    //  /// <summary>
    //  /// Allergic - Allergic Reaction
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALLERGIC,

    //  /// <summary>
    //  /// Alarm Unknown - Audible Alarm Unknown Type
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALRU,

    //  /// <summary>
    //  /// Advanced Life Support
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ALS,

    //  /// <summary>
    //  /// Assist - Assist To Other Agency Or Request For Manpower
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ASSIST,

    //  /// <summary>
    //  /// Basic Life Support Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_BLS,

    //  /// <summary>
    //  /// Cardiac - Cardiac Related Event
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_CARDIAC,

    //  /// <summary>
    //  /// CPR"
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_CARDIAC_CPR,

    //  /// <summary>
    //  /// Death - Obvious Death
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_DEATH,

    //  /// <summary>
    //  /// Diabetic
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_DIABETIC,

    //  /// <summary>
    //  /// Intoxicated - Intoxicated Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_INTOX,

    //  /// <summary>
    //  /// Ems - Major Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_MAJORINC,

    //  /// <summary>
    //  /// Mass Casualty Incident - Typically Used As A Code Declared By Incident Command
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_MAJORINC_MCI,

    //  /// <summary>
    //  /// Ems - Mayday
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_MAYDAY,

    //  /// <summary>
    //  /// Palliative Transport
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRANSPORT,

    //  /// <summary>
    //  /// Od - Overdose Accidental
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_OD,

    //  /// <summary>
    //  /// Abdominal - Abdominal Pain Or Problems
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PAIN_ABDOM,

    //  /// <summary>
    //  /// Back Pain - Non Traumatic
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PAIN_BACK,

    //  /// <summary>
    //  /// Chest Pain - Chest Pain Non Cardiac
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PAIN_CHESPAIN,

    //  /// <summary>
    //  /// Headache
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PAIN_HEADACHE,

    //  /// <summary>
    //  /// Person Down
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PERDOWN,

    //  /// <summary>
    //  /// Unconscious - Unconscious Person Includes Fainting And Near Fainting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PERUNCON,

    //  /// <summary>
    //  /// Pregnancy - Pregnancy Problems
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PREG,

    //  /// <summary>
    //  /// Citizen Assist - Public Assistance
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PSERV_CITASST,

    //  /// <summary>
    //  /// Emotionally Disturbed Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_PSERV_EDP,

    //  /// <summary>
    //  /// Respiratory - Difficulty Breathing
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_RESP,

    //  /// <summary>
    //  /// Respiratory Arrest
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_RESP_RESPARR,

    //  /// <summary>
    //  /// Seizure - Includes Convulsions
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_SEIZURE,

    //  /// <summary>
    //  /// Sick - Sick Person Non Specific
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_SICK,

    //  /// <summary>
    //  /// Pandemic - Pandemic Flu Or Illness Outbreak
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_SICK_PANDEMIC,

    //  /// <summary>
    //  /// Agency Standby - Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_STDBY,

    //  /// <summary>
    //  /// Stroke
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_STROKE,

    //  /// <summary>
    //  /// Transfer - Inter-Facility Transfer
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRANSFER,

    //  /// <summary>
    //  /// Trauma - Traumatic Injury Including Head Injury
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA,

    //  /// <summary>
    //  /// Traumatic Injury By An Animal
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_ANIMAL,

    //  /// <summary>
    //  /// Animal Bite - Animal Bites Or Attack By An Animal
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_ANIMAL_BITE,

    //  /// <summary>
    //  /// Animal/Insect Sting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_ANIMAL_STING,

    //  /// <summary>
    //  /// Bleeding - Includes Rectal
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_BLEEDING,

    //  /// <summary>
    //  /// Burns
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_BURN,

    //  /// <summary>
    //  /// Choking
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_CHOKE,

    //  /// <summary>
    //  /// Drowning
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_DROWN,

    //  /// <summary>
    //  /// Poisoning
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_POISONING,

    //  /// <summary>
    //  /// Electrocution - Includes Struck By Lightning
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_ELEC,

    //  /// <summary>
    //  /// Exposure - Heat Or Cold Exposure
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_EXPOSURE,

    //  /// <summary>
    //  /// Eye - Eye Problems Or Injury
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_EYE,

    //  /// <summary>
    //  /// Fall - Non Traumatic Fall
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_FALL,

    //  /// <summary>
    //  /// Hemorrhage - Severe Bleeding
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_HEMRG,

    //  /// <summary>
    //  /// Motor Vehicle Accident No Injury Can Be Received As Automated Crash Notification
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA,

    //  /// <summary>
    //  /// Motor Vehicle Accident With Injury Can Be Received As Automated Crash Notification
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_MVAINJY,

    //  /// <summary>
    //  /// Motor vehicle accident versus Bi-Wheeled
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_BIWHEELED,

    //  /// <summary>
    //  /// Motor vehicle accident versus Bicycle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_BIWHEELED_BICYCLE,

    //  /// <summary>
    //  /// Motor vehicle accident versus Motorcycle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_BIWHEELED_MOTORCYCLE,

    //  /// <summary>
    //  /// Motor vehicle accident - Multiple Cars
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_MULTI,

    //  /// <summary>
    //  /// Motor vehicle accident versus Pedestrian
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_PED,

    //  /// <summary>
    //  /// Motor vehicle accident Unknown - Motor Vehicle Accident Unknown Injury Can Be Received As Automated Crash Notification Crash Notification
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_MVA_UNK,

    //  /// <summary>
    //  /// Shooting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_SHOOT,

    //  /// <summary>
    //  /// Stabbing
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_STABBING,

    //  /// <summary>
    //  /// Suicide
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_SUICIDE,

    //  /// <summary>
    //  /// Suicide Threats - Attempt Or Threatening Suicide
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_SUICTHRT,

    //  /// <summary>
    //  /// Penetrating Trauma - Other Than Shooting Or Stabbing
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TRAUMA_TRAUMAP,

    //  /// <summary>
    //  /// Trouble - Unknown Type Trouble
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_TROUBLE,

    //  /// <summary>
    //  /// Abduction Family - Abduction/Kidnapping By Family Member
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ABDUCTION_ABDUCTF,

    //  /// <summary>
    //  /// Abduction Non-Family - Abduction/Kidnapping By Non-Family Member
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ABDUCTION_ABDUCTNF,

    //  /// <summary>
    //  /// Abuse - Child Or Elder
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ABUSE,

    //  /// <summary>
    //  /// Hit and Run - Vehicle Accident Hit and Run
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ACCIDENT_MVAHR,

    //  /// <summary>
    //  /// Administrative - Includes Follow-Ups
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ADMIN,

    //  /// <summary>
    //  /// Burglar Alarm- Audible - Includes Audible Intrusion Alarms
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRBA,

    //  /// <summary>
    //  /// Burglar Alarm - Silent - Includes Silent Intrusion Alarms
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRBS,

    //  /// <summary>
    //  /// Panic Alarm Audible - Includes Audible Duress Alarm
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRPANA,

    //  /// <summary>
    //  /// Panic Alarm Silent - Includes Silent Duress Alarm
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRPANS,

    //  /// <summary>
    //  /// Robbery Alarm Audible - Includes Hold Up Alarms
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRROBA,

    //  /// <summary>
    //  /// Robbery Alarm Silent - Includes Hold Up Alarms
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRROBS,

    //  /// <summary>
    //  /// Vehicle Alarm
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_ALRVEH,

    //  /// <summary>
    //  /// Box Alarm - Pull Box Alarm For Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALARM_PULL_ALRBOX,

    //  /// <summary>
    //  /// Immigration - Immigration Violation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALIEN,

    //  /// <summary>
    //  /// Alarm Unknown - Audible Alarm Unknown Type
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ALRU,

    //  /// <summary>
    //  /// Animal - Animal Complaints Including Animal Rescue
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ANIMAL,

    //  /// <summary>
    //  /// Assault - With Or Without Injury
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ASSAULT,

    //  /// <summary>
    //  /// Assault - With Or Without Injury
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ASSAULT,

    //  /// <summary>
    //  /// Assault - With Or Without Injury
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_MEDICAL_ASSAULT_SEXUAL,

    //  /// <summary>
    //  /// Assist - Assist To Other Agency Or Request For Manpower
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ASSIST,

    //  /// <summary>
    //  /// Attempt To Locate
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ATL,

    //  /// <summary>
    //  /// Barricaded - Barricaded Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_BARICADE,

    //  /// <summary>
    //  /// Burglary - Includes Breaking And Entering Incidents
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_BURGLARY,

    //  /// <summary>
    //  /// Civil - Civil Matters
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL,

    //  /// <summary>
    //  /// Civil Disobedience - Riot
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_CIVDIS,

    //  /// <summary>
    //  /// Disorderly - Disorderly Conduct Or Disturbance
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_DISORD,

    //  /// <summary>
    //  /// Domestic Non-Violent - Domestic Dispute Non-Violent
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_DVNA,

    //  /// <summary>
    //  /// Emotionally Disturbed Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_EDP,

    //  /// <summary>
    //  /// Fight - Includes Verbal And Physical Disputes
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_FIGHT,

    //  /// <summary>
    //  /// Harassment - Includes Intimidation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_HARR,

    //  /// <summary>
    //  /// Indecent - Includes Indecent Exposure
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_INDECENT,

    //  /// <summary>
    //  /// Intoxicated - Intoxicated Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_INTOX,

    //  /// <summary>
    //  /// Neglect
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_NEGLECT,

    //  /// <summary>
    //  /// Noise - Loud Noise Or Music
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_NOISE,

    //  /// <summary>
    //  /// Order Violation - Domestic Violence Writ Violation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_ORDERV,

    //  /// <summary>
    //  /// Parking - Parking Problems/Complaints
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PARKING,

    //  /// <summary>
    //  /// Found Person - Adults and Children
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PERFND,

    //  /// <summary>
    //  /// Missing Person
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PERMISS,

    //  /// <summary>
    //  /// Suspicious Person - Includes Prowler
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PERSUSP,

    //  /// <summary>
    //  /// Wanted Person - Arrest Warrant
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PERWANT,

    //  /// <summary>
    //  /// Panhandling
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PHANDLE,

    //  /// <summary>
    //  /// Found Property - Includes Abandoned Bicycles
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PROPERTY_PROPFND,

    //  /// <summary>
    //  /// Lost Property
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PROPERTY_PROPLOST,

    //  /// <summary>
    //  /// Stolen Property - Includes Retention Of
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_PROPERTY_PROPSTLN,

    //  /// <summary>
    //  /// Runaway - Includes Thrown Away Children
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_RUNAWAY,

    //  /// <summary>
    //  /// Smoking - Smoking Violation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_SMOKING,

    //  /// <summary>
    //  /// Suicide Threats - Attempt Or Threatening Suicide
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_SUICTHRT,

    //  /// <summary>
    //  /// Suspicious - Suspicious Incident
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_SUSP,

    //  /// <summary>
    //  /// Traffic Hazard - Includes Debris In Roadway
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_THAZ,

    //  /// <summary>
    //  /// Threats
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_THREATS,

    //  /// <summary>
    //  /// Trespass
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_TRESPASS,

    //  /// <summary>
    //  /// Truant
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_TRUANT,

    //  /// <summary>
    //  /// Abandoned Vehicle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHABND,

    //  /// <summary>
    //  /// Motorist Assist - Assist To Motorist Includes Vehicle Lock Outs
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHASST,

    //  /// <summary>
    //  /// Vehicle Lock Out
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHLOCK,

    //  /// <summary>
    //  /// Recovered Vehicle - Recovered Stolen Vehicle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHREC,

    //  /// <summary>
    //  /// Stolen Vehicle - Includes Lo-Jack Alerts
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHSTLN,

    //  /// <summary>
    //  /// Suspicious Vehicle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_VEHICLE_VEHSUSP,

    //  /// <summary>
    //  /// Welfare Check - Man Down Check
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_WELFARE,

    //  /// <summary>
    //  /// Wildlife Violations - Illegal Hunting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CIVIL_WILDLIFE,

    //  /// <summary>
    //  /// Carjack
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_CARJACK,

    //  /// <summary>
    //  /// Counterfeit Money
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_CNTRFT,

    //  /// <summary>
    //  /// Impersonation - Criminal Impersonation Of Officer Or Public Official
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_CRIMPS,

    //  /// <summary>
    //  /// Criminal Traffic - Driving With Suspended License
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_CRIMTRAF,

    //  /// <summary>
    //  /// Curfew Violation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_CURFEW,

    //  /// <summary>
    //  /// Drug Paraphernalia - Possession Of Drug Paraphernalia
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_DRUGPAR,

    //  /// <summary>
    //  /// Drugs
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_DRUGS,

    //  /// <summary>
    //  /// Dui - Driving While Intoxicated
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_DUI,

    //  /// <summary>
    //  /// Domestic Violent - Domestic Dispute With Violence
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_DVA,

    //  /// <summary>
    //  /// Escape - Escaped Prisoner
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_ESCAPE,

    //  /// <summary>
    //  /// Extort - Includes Blackmail
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_EXTORT,

    //  /// <summary>
    //  /// Fraud - Includes Forgery
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_FRAUD,

    //  /// <summary>
    //  /// Homicide - Includes Murder
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_HOMICIDE,

    //  /// <summary>
    //  /// Hostage
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_HOSTAGE,

    //  /// <summary>
    //  /// Larceny - Includes Larceny Attempt
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_LARCENY,

    //  /// <summary>
    //  /// Liquor Violation - Includes Selling To Minors
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_LIQUOR,

    //  /// <summary>
    //  /// Pursuit - Includes Vehicle Or Foot Pursuits
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_PURSUIT,

    //  /// <summary>
    //  /// Reckless Driver - Careless Driving And Other Driving Offenses
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_RECKDRV,

    //  /// <summary>
    //  /// Resisting Arrest
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_RESIST,

    //  /// <summary>
    //  /// Robbery - Includes Strong Arm And Attempted Robbery Excludes Car Jacking
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_ROBBERY,

    //  /// <summary>
    //  /// Sex Offense - Sexual Offenses
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_SEXOFFNS,

    //  /// <summary>
    //  /// Shooting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_SHOOT,

    //  /// <summary>
    //  /// Shoplifting
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_SHOPLIFT,

    //  /// <summary>
    //  /// Subject Stop
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_SUBJSTP,

    //  /// <summary>
    //  /// Terrorist Activity
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_TERROR,

    //  /// <summary>
    //  /// Traffic Stop
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_TSTOP,

    //  /// <summary>
    //  /// Vandalism - Vehicle Tampering
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_VANDAL,

    //  /// <summary>
    //  /// Search Warrant
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_WARRANT,

    //  /// <summary>
    //  /// Weapon Violation - Brandishing A Weapon
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_CRIME_WEAPON,

    //  /// <summary>
    //  /// Death Notification
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_DEATHNTF,

    //  /// <summary>
    //  /// Eluding - Eluding Law Enforcement
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_ELUDING,

    //  /// <summary>
    //  /// Info - Informational Calls
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_INFO,

    //  /// <summary>
    //  /// Internet Crimes - Obscene Material
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_INTERNET,

    //  /// <summary>
    //  /// Investigation
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_INVEST,

    //  /// <summary>
    //  /// Major Incident - Includes Large Scale Weather Related Event
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_MAJORINC,

    //  /// <summary>
    //  /// Mayday - Immediate Assistance Request
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_MAYDAY,

    //  /// <summary>
    //  /// Missing Boater - Missing Person(S) Last Seen On Boat Out On A Waterway
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_MISBOATR,

    //  /// <summary>
    //  /// Misconduct - Includes Conspiracy
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_MISCON,

    //  /// <summary>
    //  /// Unsecure Building - Includes Open Door
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_OPEN,

    //  /// <summary>
    //  /// Citizen Assist - Public Assistance
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_PSERV_CITASST,

    //  /// <summary>
    //  /// Disabled Vehicle
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_PSERV_DISVEH,

    //  /// <summary>
    //  /// Repo - Vehicle Repossession
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_REPO,

    //  /// <summary>
    //  /// Vice - Prostitution
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_SPECIAL_VICE,

    //  /// <summary>
    //  /// Agency Standby - Police
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_STDBY,

    //  /// <summary>
    //  /// Tow
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_TOW,

    //  /// <summary>
    //  /// Trouble - Unknown Type Trouble
    //  /// </summary>
    //  BITS_REPORT_EM_DISPATCH_POLICE_TROUBLE
    //}
    }
