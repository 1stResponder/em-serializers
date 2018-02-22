// ———————————————————————–
// <copyright file="SeverityType.cs" company="EDXLSharp">
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
// ———————————————————————–

using System;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The code denoting the severity of the subject event of the alert message 
  /// </summary>
  [Serializable]
  public enum SeverityType
  {
    /// <summary>
    /// Extraordinary threat to life or property
    /// </summary>
    Extreme,
    
    /// <summary>
    /// Significant threat to life or property
    /// </summary>
    Severe,
    
    /// <summary>
    /// Possible threat to life or property
    /// </summary>
    Moderate,
    
    /// <summary>
    /// Minimal to no known threat to life or property
    /// </summary>
    Minor,
    
    /// <summary>
    /// Severity unknown
    /// </summary>
    Unknown
  }
}