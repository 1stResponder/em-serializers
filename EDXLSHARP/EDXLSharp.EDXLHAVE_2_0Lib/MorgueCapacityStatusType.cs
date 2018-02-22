// ———————————————————————–
// <copyright file="MorgueCapacityStatusType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The MorgueCapacityStatus enum type
  /// </summary>
  [Serializable]
  public enum MorgueCapacityStatusType 
  { 
    /// <summary>
    /// Open Morgue Capacity Status Type
    /// </summary>
    Open,
 
    /// <summary>
    /// Full Morgue Capacity Status Type
    /// </summary>
    Full, 

    /// <summary>
    /// Exceeded Morgue Capacity Status Type
    /// </summary>
    Exceeded 
  }
}
