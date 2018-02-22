// ———————————————————————–
// <copyright file="ResponseType.cs" company="EDXLSharp">
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
  /// The code denoting the type of action recommended for the target audience 
  /// </summary>
  [Serializable]
  public enum ResponseType
  {
    /// <summary>
    /// Take shelter in place or per instruction
    /// </summary>
    Shelter,
    
    /// <summary>
    /// Relocate as instructed in the instruction
    /// </summary>
    Evacuate,
    
    /// <summary>
    /// Make preparations per the instruction
    /// </summary>
    Prepare,
    
    /// <summary>
    /// Execute a pre-planned activity identified in instruction
    /// </summary>
    Execute,
    
    /// <summary>
    /// Avoid the subject event as per the instruction
    /// </summary>
    Avoid,
    
    /// <summary>
    /// Attend to information sources as described in instruction
    /// </summary>
    Monitor,
    
    /// <summary>
    /// Evaluate the information in this message.  (This val SHOULD NOT be used in public warning applications.)
    /// </summary>
    Assess,
    
    /// <summary>
    /// The subject event no longer poses a threat or concern and any follow on action is described in instruction
    /// </summary>
    AllClear,
    
    /// <summary>
    /// No action recommended
    /// </summary>
    None
  }
}