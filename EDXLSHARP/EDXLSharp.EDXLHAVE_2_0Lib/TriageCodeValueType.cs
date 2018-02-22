// ———————————————————————–
// <copyright file="TriageCodeValueType.cs" company="EDXLSharp">
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
  /// The TriageCodeValue enum type 
  /// </summary>
  [Serializable]
  public enum TriageCodeValueType 
  { 
    /// <summary>
    /// Red Triage Code
    /// </summary>
    Red, 
    
    /// <summary>
    /// Yellow Triage Code
    /// </summary>
    Yellow, 
    
    /// <summary>
    /// Green Triage Code
    /// </summary>
    Green, 
    
    /// <summary>
    /// Black Triage Code
    /// </summary>
    Black 
  }
}
