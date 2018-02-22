// ———————————————————————–
// <copyright file="AgeUnitsType.cs" company="EDXLSharp">
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

namespace MEXLTEPLib
{
  /// <summary>
  /// Used to Denote the Units that the Age is Measured in
  /// </summary>
  [Serializable]
  public enum AgeUnitsType
  {
    /// <summary>
    /// Years of Age
    /// </summary>
    Year,

    /// <summary>
    /// Months of Age
    /// </summary>
    Month,

    /// <summary>
    /// Weeks of Age
    /// </summary>
    Week,

    /// <summary>
    /// Days of Age
    /// </summary>
    Day
  }
}
