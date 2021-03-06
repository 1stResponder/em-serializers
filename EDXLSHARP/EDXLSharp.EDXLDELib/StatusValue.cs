﻿// ———————————————————————–
// <copyright file="StatusValue.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLDELib
{
  /// <summary>
  /// The action ability of the message.  Describes the kind of information/purpose of the information. 
  /// </summary>
  [Serializable]
  public enum StatusValue
  {
    /// <summary>
    /// "Real-world" information for action
    /// </summary>
    Actual,

    /// <summary>
    /// Simulated information for exercise participants
    /// </summary>
    Exercise,

    /// <summary>
    /// Messages regarding or supporting network functions
    /// </summary>
    System,

    /// <summary>
    /// Discard messages for technical testing only
    /// </summary>
    Test
  }
}