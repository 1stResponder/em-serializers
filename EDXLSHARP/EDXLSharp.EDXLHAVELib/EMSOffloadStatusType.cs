﻿// ———————————————————————–
// <copyright file="EMSOffloadStatusType.cs" company="EDXLSharp">
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
  /// The EMS Offload Status enum type
  /// </summary>
  [Serializable]
  public enum EMSOffloadStatusType 
  { 
    /// <summary>
    /// Normal EMS Offload Status Type
    /// </summary>
    Normal, 
    
    /// <summary>
    /// Delayed EMS Offload Status Type
    /// </summary>
    Delayed 
  }
}
