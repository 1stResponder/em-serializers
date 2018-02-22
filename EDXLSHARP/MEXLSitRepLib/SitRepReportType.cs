// ———————————————————————–
// <copyright file="SitRepReportType.cs" company="EDXLSharp">
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

namespace MEXLSitRepLib
{
  /// <summary>
  /// Represents the Individual Report Types That Can Be Contained Within a SitRep Message
  /// </summary>
  [Serializable]
  public enum SitRepReportType
  {
    /// <summary>
    /// Report Containing Casualty and Illness Data
    /// </summary>
    CasualtyandIllnessSummary,

    /// <summary>
    /// Report Containing Resources Involved in this Response
    /// </summary>
    ResponseResourcesTotals,

    /// <summary>
    /// Report Containing Detailed Information About The Situation
    /// </summary>
    SituationInformation,

    /// <summary>
    /// High Level Report Containing Summary Values for Management
    /// </summary>
    ManagementReportingSummary,

    /// <summary>
    /// A Lightweight Field or Spot Report 
    /// </summary>
    FieldObservation
  }
}