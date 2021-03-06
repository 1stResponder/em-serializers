﻿// ———————————————————————–
// <copyright file="PartyIdentifierElementType.cs" company="EDXLSharp">
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

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// List of information types used for describing party identifiers
  /// </summary>
  [Serializable]
  public enum PartyIdentifierElementType
  {
    /// <summary>
    /// The Actual ID, Number, or UID
    /// </summary>
    Identifier,

    /// <summary>
    /// The Country or Org who Issued It
    /// </summary>
    IssuingCountryName
  }
}