﻿// ———————————————————————–
// <copyright file="ContactRoleType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The enumeration of ContactRoleType for the Resource Message
  /// </summary>
  [Serializable]
  public enum ContactRoleType 
  { 
    /// <summary>
    /// "Sender" (who sent the message)
    /// </summary>
    Sender,
    
    /// <summary>
    /// ”Requester" (authorization for the message / request)
    /// </summary>
    Requester, 
    
    /// <summary>
    /// "SubjectMatterExpert" (answer questions or provide details)
    /// </summary>
    SubjectMatterExepert, 
    
    /// <summary>
    /// "Approver" ()
    /// </summary>
    Approver, 
    
    /// <summary>
    /// "RespondingOrg" (who responded to the message)
    /// </summary>
    RespondingOrg, 
    
    /// <summary>
    /// “Owner” ()
    /// </summary>
    Owner
  }
}
