// ———————————————————————–
// <copyright file="ComplexityType.cs" company="EDXLSharp">
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

namespace MEXLSitRep
{
  /// <summary>
  ///  Enumerated Type For The Complexity Type of the Situation Information
  /// </summary>
  [Serializable]
  public enum ComplexityType
  {
    /// <summary>
    /// “Complex” – Public / Professional preparedness is low, Coordination Complexity and involvement is high (local, regional, state and national)
    /// </summary>
    Complex,

    /// <summary>
    /// “Moderate-Complex” – Public / Professional preparedness is moderate-high, Coordination Complexity and involvement is high (local, regional, state, possibly national).
    /// </summary>
    ModerateComplex,

    /// <summary>
    /// “Moderate” – Public / Professional preparedness is high, Coordination Complexity and involvement is moderate (local, regional)
    /// </summary>
    Moderate,

    /// <summary>
    /// “Low” - Public / Professional preparedness is high, Coordination Complexity and involvement is low (local only)
    /// </summary>
    Low
  }
}
