// ———————————————————————–
// <copyright file="ElectronicAddressIdentifierType.cs" company="EDXLSharp">
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
  /// Type of electronic address identifier
  /// </summary>
  [Serializable]
  public enum ElectronicAddressIdentifierTypeList
  {
    /// <summary>
    /// AOL Instant Messenger
    /// </summary>
    AIM,

    /// <summary>
    /// E-Mail Address
    /// </summary>
    EMAIL,

    /// <summary>
    /// Google Talk
    /// </summary>
    GOOGLE,

    /// <summary>
    /// Gizmo Chat Service
    /// </summary>
    GIZMO,

    /// <summary>
    /// ICQ Chat Service
    /// </summary>
    ICQ,
    
    /// <summary>
    /// XMPP Chat Server
    /// </summary>
    JABBER,

    /// <summary>
    /// MSN Messenger
    /// </summary>
    MSN,

    /// <summary>
    /// Session Initiated Protocol URI
    /// </summary>
    SIP,

    /// <summary>
    /// Skype Address
    /// </summary>
    SKYPE,

    /// <summary>
    /// Uniform Resource Locater
    /// </summary>
    URL,

    /// <summary>
    /// XRI Chat Service
    /// </summary>
    XRI,

    /// <summary>
    /// Yahoo Chat
    /// </summary>
    YAHOO
  }
}
