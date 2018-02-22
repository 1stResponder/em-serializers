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
using System.Xml;

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// Information about the identifier
  /// </summary>
  [Serializable]
  public partial class IdentifierElement : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Type of this Identifier element
    /// </summary>
    private PartyIdentifierElementType? type;

    /// <summary>
    /// Value of this Identifier element
    /// </summary>
    private string elementValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the IdentifierElement class
    /// Default Constructor - Does Nothing
    /// </summary>
    public IdentifierElement()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Value of this Identifier element
    /// </summary>
    public string ElementValue
    {
      get { return this.elementValue; }
      set { this.elementValue = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type of this Identifier element
    /// </summary>
    public PartyIdentifierElementType? Type
    {
      get { return this.type; }
      set { this.type = value; }
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
      xwriter.WriteStartElement("IdentifierElement", EDXLConstants.XPIL10Namespace);
      if (this.type != null)
      {
        xwriter.WriteAttributeString("Type", EDXLConstants.XPIL10Namespace, this.type.ToString());
      }

      if (!string.IsNullOrEmpty(this.elementValue))
      {
        xwriter.WriteString(this.elementValue);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "IdentifierElement")
      {
        if (!string.IsNullOrEmpty(rootnode.InnerText))
        {
          this.elementValue = rootnode.InnerText;
        }

        foreach (XmlAttribute attrib in rootnode.Attributes)
        {
          if (attrib.LocalName == "Type")
          {
            this.type = (PartyIdentifierElementType)Enum.Parse(typeof(PartyIdentifierElementType), attrib.InnerText);
          }
          else
          {
            throw new ArgumentException("Unexpected Attribute name: " + attrib.Name + " in IdentifierElement");
          }
        }

        this.Validate();
      }
      else
      {
        throw new ArgumentException("Unexpected node name: " + rootnode.Name + " in IdentifierElement");
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
