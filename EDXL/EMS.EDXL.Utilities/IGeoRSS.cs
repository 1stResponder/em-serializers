// ———————————————————————–
// <copyright file="IGeoRSS.cs" company="EDXLSharp">
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
using System.Collections.Generic;

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// Interface to Allow Object to be Serialized to Geo-RSS
  /// </summary>
  public interface IGeoRSS 
  {
    /// <summary>
    /// Converts This Object To One or More Syndication Items
    /// </summary>
    /// <param name="items">Syndication Items with Associated GeoRSS Content</param>
    /// <param name="linkUID">Provides Capability to Link The ContentKey or UID with the SyndicationLink</param>
    void ToGeoRSS(List<SyndicationItem> items, Guid linkUID);
  }
}
