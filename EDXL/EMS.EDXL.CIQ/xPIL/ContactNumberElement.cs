// ———————————————————————–
// <copyright file="ContactNumberElement.cs" company="EDXLSharp">
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
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// A container for all kinds of telecommunication lines of party used for contact purposes. e.g. phone, fax, mobile, pager, etc.
  /// </summary>
  [Serializable]
  public class ContactNumberElement 
  {
    #region Private Member Variables

    /// <summary>
    /// If present, specifies type of the information 
    /// provided as text value of the element.
    /// </summary>
    private ContactNumberElementList? contactNumberKind;

    /// <summary>
    /// Full contact number or part of it
    /// </summary>
    private string contactNumberValue;

    #endregion

    #region XML Elements

    /// <summary>
    /// Gets or sets
    /// Full contact number or part of it
    /// </summary>
    [XmlText]
    public string Value
    {
      get { return this.contactNumberValue; }
      set { this.contactNumberValue = value; }
    }

    #endregion XML Elements

    #region XML Attributes
    /// <summary>
    /// Gets or sets
    /// Kind of the contact number
    /// </summary>
    [XmlAttribute("Kind")]
    public ContactNumberElementList Kind
    {
      get { return this.contactNumberKind.Value; }
      set { this.contactNumberKind = value; }
    }

    /// <summary>
    /// Set flag to determine if Kind attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool KindSpecified
    {
      get
      {
        return this.contactNumberKind.HasValue;
      }
    }
    #endregion XML Attributes
  }
}
