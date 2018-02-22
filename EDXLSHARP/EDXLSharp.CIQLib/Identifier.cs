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

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// Identifier to recognize the party such as customer identifier, social security number, National ID Card, 
  /// tax number, business number, company number, company registration, etc
  /// </summary>
  [Serializable]
  public partial class Identifier : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Information about the identifier
    /// </summary>
    private List<IdentifierElement> identifierElements;

    /// <summary>
    /// Type of identifier. e.g. Tax Number
    /// </summary>
    private PartyIdentifierType? type;

    /// <summary>
    /// Reference to a Party element that describes the issuing organization
    /// </summary>
    private OrganizationName issuerName;

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

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Reference to a Party element that describes the issuing organization
    /// </summary>
    public OrganizationName IssuerName
    {
      get { return this.issuerName; }
      set { this.issuerName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type of identifier. e.g. Tax Number
    /// </summary>
    public PartyIdentifierType? Type
    {
      get { return this.type; }
      set { this.type = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Information about the identifier
    /// </summary>
    public List<IdentifierElement> IdentifierElements
    {
      get { return this.identifierElements; }
      set { this.identifierElements = value; }
    }

    #endregion

    #region Internal Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement("Identifier", EDXLConstants.XPIL10Namespace);
      if (this.type != null)
      {
        xwriter.WriteAttributeString("Type", EDXLConstants.XPIL10Namespace, this.type.ToString());
      }

      foreach (IdentifierElement idelement in this.identifierElements)
      {
        idelement.WriteXML(xwriter);
      }

      if (this.issuerName != null)
      {
        xwriter.WriteStartElement("IssuerName", EDXLConstants.XPIL10Namespace);
        this.issuerName.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      xwriter.WriteEndElement();
    }
    
    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      IdentifierElement tempidele;
      if (rootnode.LocalName == "Identifier")
      {
        foreach (XmlAttribute attrib in rootnode.Attributes)
        {
          if (attrib.LocalName == "Type")
          {
            this.type = (PartyIdentifierType)Enum.Parse(typeof(PartyIdentifierType), attrib.InnerText);
          }
          else
          {
            throw new ArgumentException("Invalid Attribute Name: " + attrib.Name + " in Identifier");
          }
        }

        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          if (childnode.LocalName == "IdentifierElement")
          {
            tempidele = new IdentifierElement();
            tempidele.ReadXML(childnode);
            this.identifierElements.Add(tempidele);
          }
          else if (childnode.LocalName == "IssuerName")
          {
            this.issuerName.ReadXML(childnode);
          }
          else
          {
            throw new ArgumentException("Unexpected node name: " + childnode.Name + " in Identifier");
          }
        }

        this.Validate();
      }
      else
      {
        throw new ArgumentException("Unexpected node name: " + rootnode.Name + " in Identifier");
      }
    }

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    #endregion

    #region Private Member Functions

    #endregion
  }
}
