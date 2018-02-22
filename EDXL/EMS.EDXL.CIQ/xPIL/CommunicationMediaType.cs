// ———————————————————————–
// <copyright file="CommunicationMediaType.cs" company="EDXLSharp">
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

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// List of communication media types used for contact purposes
  /// </summary>
  [Serializable]
  public enum CommunicationMediaType
  {
    /// <summary>
    /// Cellular Telephone
    /// </summary>
    Cellphone,

    /// <summary>
    /// Fax Machine
    /// </summary>
    Fax,

    /// <summary>
    /// Alpha-Numeric Pager
    /// </summary>
    Pager,

    /// <summary>
    /// Plain Old Telephone Service
    /// </summary>
    Telephone,

    /// <summary>
    /// Voice over IP
    /// </summary>
    VOIP
  }
}