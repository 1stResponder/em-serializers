// ———————————————————————–
// <copyright file="SitRepObservationType.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

using System;

namespace MEXLSitRepLib
{
  /// <summary>
  ///  Enumerated Type For The General Category of the Observation
  /// </summary>
  [Serializable]
  public enum SitRepObservationType
  {
    /// <summary>
    /// Observation Regarding Emergency Medical Needs
    /// </summary>
    EmergencyMedicalServices,

    /// <summary>
    /// Observation Regarding a Fire or HAZMAT
    /// </summary>
    FireandHazardousMaterials,

    /// <summary>
    /// Observation Used To Inform ICS of a General Observation
    /// </summary>
    IncidentManagement,

    /// <summary>
    /// Observation Regarding Crime or Need for Law Enforcement
    /// </summary>
    LawEnforcement,

    /// <summary>
    /// Observation for Mass Casualty or Evacuation Needs
    /// </summary>
    MassCare,

    /// <summary>
    /// Observation for Widespread Medical Conditions Affecting Public Health
    /// </summary>
    MedicalandPublicHealth,

    /// <summary>
    /// Observation Involving CI/KR
    /// </summary>
    PublicWorks,

    /// <summary>
    /// Observation regarding Search and Rescue
    /// </summary>
    SearchandRescue,

    /// <summary>
    /// Observation regarding a suspicious person
    /// </summary>
    SuspiciousPerson,

    /// <summary>
    /// Observation regarding a suspicious package
    /// </summary>
    SuspiciousPackage,

    /// <summary>
    /// Observation regarding a suspicious vehicle
    /// </summary>
    SuspiciousVehicles,

    /// <summary>
    /// Observation regarding weapons or threats
    /// </summary>
    WeaponsOrThreats,

    /// <summary>
    /// Observation regarding a large group of people
    /// </summary>
    LargeGroups,

    /// <summary>
    /// Observation regarding graffiti
    /// </summary>
    Graffiti,

    /// <summary>
    /// General Observation
    /// </summary>
    GeneralObservation
  }
}