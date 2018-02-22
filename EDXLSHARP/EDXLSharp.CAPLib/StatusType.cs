// ———————————————————————–
// <copyright file="StatusType.cs" company="EDXLSharp">
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
/*
 * Operations:
 * ------------------
 * Enumerates the types of status available
 * 
*/

using System;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The code denoting the appropriate handling of the alert message 
  /// </summary>
  [Serializable]
  public enum StatusType
  {
    /// <summary>
    /// Actionable by all targeted recipients
    /// </summary>
    Actual,
    
    /// <summary>
    /// Actionable only by designated exercise participants; exercise identifier SHOULD appear in note
    /// </summary>
    Exercise,
    
    /// <summary>
    /// For messages that support alert network internal functions
    /// </summary>
    System,
    
    /// <summary>
    /// Technical testing only, all recipients disregard
    /// </summary>
    Test,
    
    /// <summary>
    /// A preliminary template or draft, not actionable in its current form
    /// </summary>
    Draft
  }
}