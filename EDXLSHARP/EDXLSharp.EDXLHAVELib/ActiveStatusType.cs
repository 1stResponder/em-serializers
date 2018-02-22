// ———————————————————————–
// <copyright file="ActiveStatusType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The Active Status Enum Type
  /// </summary>
  [Serializable]
  public enum ActiveStatusType 
  { 
    /// <summary>
    /// Active Status
    /// </summary>
    Active, 
    
    /// <summary>
    /// Inactive Status
    /// </summary>
    Inactive 
  }
}
