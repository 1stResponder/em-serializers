// ———————————————————————–
// <copyright file="Identifier.cs" company="EDXLSharp">
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
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Identifier to recognize the party such as customer identifier, social security number, National ID Card, 
  /// tax number, business number, company number, company registration, etc
  /// </summary>
  [Serializable]
  public class Identifier 
  {
    #region Private Member Variables

    /// <summary>
    /// Information about the identifier
    /// </summary>
    private List<IdentifierElement> identifierElements;

    /// <summary>
    /// Type of identifier. e.g. Tax Number
    /// </summary>
    private PartyIdentifierTypeList? partyIdentifierKind;

    /// <summary>
    /// Reference to a Party element that describes the issuing organization
    /// </summary>
    private OrganisationNameType issuerName;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the Identifier class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public Identifier()
    {
      this.identifierElements = new List<IdentifierElement>();
    }

    #endregion

    #region XML Elements

    /// <summary>
    /// Gets or sets
    /// Reference to a Party element that describes the issuing organization
    /// </summary>
    [XmlElement("issuerName", Namespace = CIQNamespaces.v10_xNL)]
    public OrganisationNameType IssuerName
    {
      get { return this.issuerName; }
      set { this.issuerName = value; }
    }

    public bool IssuerNameSpecified
    {
      get { return this.issuerName != null; }
    }

    /// <summary>
    /// Gets or sets
    /// Information about the identifier
    /// </summary>
    [XmlElement("identiferElement")]
    public List<IdentifierElement> IdentifierElements
    {
      get { return this.identifierElements; }
      set { this.identifierElements = value; }
    }

    public bool IdentifierElementsSpecified
    {
      get { return this.identifierElements != null && this.identifierElements.Count > 0; }
    }
    #endregion XML Elements

    #region XML Attributes
    /// <summary>
    /// Gets or sets
    /// Type of identifier. e.g. Tax Number
    /// </summary>
    [XmlAttribute("Kind")]
    public PartyIdentifierTypeList PartyIdentifierKind
    {
      get { return this.partyIdentifierKind.Value; }
      set { this.partyIdentifierKind = value; }
    }

    /// <summary>
    /// Set flag to determine if Kind attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool PartyIdentifierKindSpecified
    {
      get { return this.partyIdentifierKind.HasValue; }
    }
    #endregion XML Attributes
  }
}
