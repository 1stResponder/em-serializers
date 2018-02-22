// ———————————————————————–
// <copyright file="CategoryType.cs" company="EDXLSharp">
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
  /// The code denoting the category of the subject event of the alert message 
  /// </summary>
  [Serializable]
  public enum CategoryType
  {
    /// <summary>
    /// Geophysical (including landslide)
    /// </summary>
    Geo,

    /// <summary>
    /// Meteorological (including flood)
    /// </summary>
    Met,

    /// <summary>
    /// General emergency and public safety
    /// </summary>
    Safety,

    /// <summary>
    /// Law enforcement, military, homeland and local/private security
    /// </summary>
    Security,

    /// <summary>
    /// Rescue and recovery
    /// </summary>
    Rescue,

    /// <summary>
    /// Fire suppression and rescue
    /// </summary>
    Fire,

    /// <summary>
    /// Medical and public health
    /// </summary>
    Health,

    /// <summary>
    /// Pollution and other environmental
    /// </summary>
    Env,

    /// <summary>
    /// Public and private transportation
    /// </summary>
    Transport,

    /// <summary>
    /// Utility, telecommunication, other non-transport infrastructure
    /// </summary>
    Infra,

    /// <summary>
    /// Chemical, Biological, Radiological, Nuclear or High-Yield Explosive threat or attack
    /// </summary>
    CBRNE,

    /// <summary>
    /// Other events
    /// </summary>
    Other
  }
}