// ———————————————————————–
// <copyright file="IContentObject.cs" company="EDXLSharp">
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

using EMS.EDXL.CT;
using System;
using System.Collections.Generic;

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// 
  /// </summary>
  public interface IContentObject
  {
    /// <summary>
    /// Gets time that the information is no longer valid
    /// </summary>
    DateTime ExpiresDateTime { get; }

    /// <summary>
    /// Gets a string version of the content in XML format
    /// </summary>
    /// <returns>XML String</returns>
    string ToXmlString();

    /// <summary>
    /// Gets a description of the content
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Sets the Content Keyword ValueListName and Values
    /// </summary>
    List<ValueList> Keywords { get; }

    ///// <summary>
    ///// Validates The Current DE Object Against The XSD Schema File
    ///// </summary>
    //void ValidateToSchema();
  }
}
