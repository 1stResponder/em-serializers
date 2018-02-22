// ———————————————————————–
// <copyright file="TypeValue.cs" company="EDXLSharp">
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
  /// The function of the message
  /// </summary>
  [Serializable]
  public enum TypeValue
  {
    /// <summary>
    /// New information regarding an incident or activity
    /// </summary>
    Report,

    /// <summary>
    /// Updated information superseding a previous message
    /// </summary>
    Update,

    /// <summary>
    /// A cancellation or revocation of a previous message
    /// </summary>
    Cancel,

    /// <summary>
    /// A request for resources, information or action
    /// </summary>
    Request,

    /// <summary>
    /// A response to a previous request
    /// </summary>
    Response,

    /// <summary>
    /// A commitment of resources or assistance
    /// </summary>
    Dispatch,

    /// <summary>
    /// Acknowledgment of receipt of an earlier message
    /// </summary>
    Ack,

    /// <summary>
    /// Rejection of an earlier message (for technical reasons)
    /// </summary>
    Error,

    /// <summary>
    /// These messages are for reporting configuration during power up or after Installation or Maintenance
    /// </summary>
    SensorConfiguration,

    /// <summary>
    /// These are messages used to control sensors/sensor concentrator components behavior
    /// </summary>
    SensorControl,

    /// <summary>
    /// These are concise messages which report sensors/sensor concentrator component status or state of health
    /// </summary>
    SensorStatus,

    /// <summary>
    /// These are high priority messages which report sensor detections
    /// </summary>
    SensorDetection,

    /// <summary>
    /// The distributionStatus is not known
    /// </summary>
    Unknown,

    /// <summary>
    /// The distributionStatus is known but the provided default values are so inappropriate that to choose one would be entirely misleading
    /// </summary>
    NoAppropriateDefault
  }
}