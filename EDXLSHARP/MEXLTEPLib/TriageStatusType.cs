// ———————————————————————–
// <copyright file="TriageStatusType.cs" company="EDXLSharp">
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
  /// Represents Possible Triage Status Codes for a Patient
  /// </summary>
  [Serializable]
  public enum TriageStatusType
  {
    /// <summary>
    /// Red / Highest Priority
    /// </summary>
    Priority1,

    /// <summary>
    /// Yellow / Medium Priority
    /// </summary>
    Priority2,
    
    /// <summary>
    /// Green / Walking Wounded
    /// </summary>
    Priority3,
    
    /// <summary>
    /// Patient is Deceased
    /// </summary>
    Dead,
    
    /// <summary>
    /// Non-Injured / Affected Person
    /// </summary>
    Priority4
  }
}
