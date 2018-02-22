// ———————————————————————–
// <copyright file="EvacuationStatusType.cs" company="EDXLSharp">
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

namespace MEXLTEPLib
{
  /// <summary>
  /// A client(patient) status used in hospital, nursing home or other evacuations, to indicate current care requirement, to ensure transfer to an appropriate receiving facility with the same or similar care environment or capability
  /// </summary>
  [Serializable]
  public enum EvacuationStatusType
  {
    /// <summary>
    /// Intensive Care Unit
    /// </summary>
    ICU,

    /// <summary>
    /// Hospital Floor
    /// </summary>
    Floor,

    /// <summary>
    /// Discharged from Facility
    /// </summary>
    Discharge,

    /// <summary>
    /// Ready To Leave
    /// </summary>
    Ready
  }
}