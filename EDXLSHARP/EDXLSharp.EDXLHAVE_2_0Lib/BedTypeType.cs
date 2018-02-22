// ———————————————————————–
// <copyright file="BedTypeType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The Bed Type enum type
  /// </summary>
  [Serializable]
  public enum BedTypeType 
  {
    /// <summary>
    /// AdultICU - Capacity status for adult ICU bed type. 
    /// • These can support critically ill or injured patients, including ventilator support.  
    /// • This category includes all major subtypes of ICU beds, including Neurological, cardiac, trauma, or medical, with the exception that this category does not include burn ICU beds. 
    /// </summary>
    AdultICU, 
    
    /// <summary>
    /// PediatricICU
    /// • Capacity status for pediatric ICU beds. This is similar to adult ICU beds, but for patients 17-years-old and younger.
    /// </summary>
    PediatricICU, 
    
    /// <summary>
    /// NeonatalICU
    /// • Capacity status for neonatal ICU beds. 
    /// </summary>
    NeonatalICU, 
    
    /// <summary>
    /// EmergencyDepartment
    /// • Capacity status for beds within the Emergency Department used for acute care. 
    /// </summary>
    EmergencyDepartment, 
    
    /// <summary>
    /// NurseryBeds
    /// • Capacity Status for Neonatal or newborn care beds including all bed types other than Neonatal ICU 
    /// </summary>
    NurseryBeds, 
    
    /// <summary>
    /// MedicalSurgical - Capacity status for medical-surgical beds. 
    /// • These are also thought of as ward beds.  
    /// • These beds may or may not include cardiac telemetry capability
    /// </summary>
    MedicalSurgical, 
    
    /// <summary>
    /// RehabLongTermCare – Capacity Status for Rehabilitation/Long term care beds. 
    /// • Beds designated as long term care rehabilitation. These do not include floor beds.
    /// </summary>
    RehabLongTermCare, 
    
    /// <summary>
    /// Burn - Capacity status for burn beds. 
    /// • These are thought of as burn ICU beds, either approved by the American Burn Association or self-designated. 
    /// • These beds are NOT to be included in other ICU bed counts.
    /// </summary>
    Burn, 
    
    /// <summary>
    /// Pediatrics
    /// • Capacity status for pediatrics beds. These are ward medical/surgical beds for patients 17-years-old and younger.
    /// </summary>
    Pediatrics, 
    
    /// <summary>
    /// AdultPsychiatric
    /// • Capacity status for adult psychiatric beds. These are ward beds on a closed/locked psychiatric unit or ward beds where a patient will be attended by a sitter.
    /// </summary>
    AdultPsychiatric, 
    
    /// <summary>
    /// PediatricPsychiatric
    /// • Capacity status for pediatric psychiatric beds. These are ward beds on a closed/locked psychiatric unit or ward beds where a patient will be attended by a sitter
    /// </summary>
    PediatricPsychiatric, 
    
    /// <summary>
    /// NegativeFlowIsolation
    /// • Capacity status for negative airflow isolation beds. These provide respiratory isolation. NOTE: This val may represent available beds included in the counts of other types.
    /// </summary>
    NegativeFlowIsolation, 
    
    /// <summary>
    /// OtherIsolation
    /// • Capacity status for other isolation beds. These provide isolation where airflow is not a concern.  NOTE: This val may represent available beds included in the counts of other types. 
    /// </summary>
    OtherIsolation, 
    
    /// <summary>
    /// OperatingRooms
    /// • Capacity status for operating rooms which are equipped staffed and could be made available for patient care in a short period of time.
    /// </summary>
    OperatingRooms 
  }
}
