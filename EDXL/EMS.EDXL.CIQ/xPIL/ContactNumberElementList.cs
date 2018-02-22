// ———————————————————————–
// <copyright file="ContactNumberElementType.cs" company="EDXLSharp">
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
  /// List of information types used for phone number details
  /// </summary>
  [Serializable]
  public enum ContactNumberElementList
  {
    /// <summary>
    /// Code to dial to a country. E.g. 1 for US, 44 for UK
    /// </summary>
    CountryCode,

    /// <summary>
    /// Code to dial an area within a country. For example: "02" for Sydney, "03" for Melbourne
    /// </summary>
    AreaCode,

    /// <summary>
    /// Local number as would be used by others within the same dialing area
    /// </summary>
    LocalNumber,

    /// <summary>
    /// An extension to the number that is usually handled by some PABX
    /// </summary>
    Extension,

    /// <summary>
    /// E.g. special access code
    /// </summary>
    Pin,

    /// <summary>
    /// Any text that is not part of the phone number, but has some informational content, e.g. Ext.
    /// </summary>
    Separator,

    /// <summary>
    /// Area code with local number if one line. May include national access numbers.
    /// </summary>
    NationalNumber,

    /// <summary>
    /// Full international number in one line. May include international access numbers.
    /// </summary>
    InternationalNumber
  }
}