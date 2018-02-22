// ———————————————————————–
// <copyright file="IdentifierElement.cs" company="EDXLSharp">
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
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Information about the identifier
  /// </summary>
  [Serializable]
  public class IdentifierElement 
  {
    #region Private Member Variables

    /// <summary>
    /// Type of this Identifier element
    /// </summary>
    private PartyIdentifierElementList? identifierKind;

    /// <summary>
    /// Value of this Identifier element
    /// </summary>
    private string identifierValue;

    #endregion Private Member Variables

    #region XML Elements
    /// <summary>
    /// Gets or sets
    /// Value of this Identifier element
    /// </summary>
    [XmlText]
    public string Value
    {
      get { return this.identifierValue; }
      set { this.identifierValue = value; }
    }
    #endregion XML Elements

    #region XML Attributes
    /// <summary>
    /// Gets or sets
    /// Type of this Identifier element
    /// </summary>
    [XmlAttribute("Kind")]
    public PartyIdentifierElementList Kind
    {
      get { return this.identifierKind.Value; }
      set { this.identifierKind = value; }
    }

    /// <summary>
    /// Set flag to determine if Kind attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool KindSpecified
    {
      get { return this.identifierKind.HasValue; }
    }
    #endregion XML Attributes
  }
}
