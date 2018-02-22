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

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// A container for all kinds of telecommunication lines of party used for contact purposes. e.g. phone, fax, mobile, pager, etc.
  /// </summary>
  [Serializable]
  public partial class ContactNumberElement : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Type of the ContactNumber element
    /// </summary>
    private ContactNumberElementType? elementType;

    /// <summary>
    /// Value of the ContactNumber element
    /// </summary>
    private string elementValue;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ContactNumberElement class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ContactNumberElement()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ContactNumberElement class
    /// Constructor to Initialize Type/Value Pair
    /// </summary>
    /// <param name="type">Value Type of the contact element</param>
    /// <param name="value">Value of the contact element string</param>
    public ContactNumberElement(ContactNumberElementType type, string value)
    {
      this.elementType = type;
      this.elementValue = value;
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Value of the ContactNumber element
    /// </summary>
    public string ElementValue
    {
      get { return this.elementValue; }
      set { this.elementValue = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type of the ContactNumber element
    /// </summary>
    public ContactNumberElementType? ElementType
    {
      get { return this.elementType; }
      set { this.elementType = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "ContactNumberElement")
      {
        if (string.IsNullOrEmpty(rootnode.InnerText))
        {
          return;
        }

        if (rootnode.Attributes.Count != 0 && rootnode.Attributes[0].LocalName == "Type")
        {
          this.elementType = (ContactNumberElementType)Enum.Parse(typeof(ContactNumberElementType), rootnode.Attributes[0].InnerText);
        }
        else
        {
          throw new ArgumentException("Contact Element Type Exception in ContactNumberElement");
        }

        this.elementValue = rootnode.InnerText;
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in ContactNumberElement");
      }

      this.Validate();
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      if (string.IsNullOrEmpty(this.elementValue))
      {
        return;
      }

      xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "ContactNumberElement", EDXLConstants.XPIL10Namespace);
      if (this.elementType != null)
      {
        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "Type", EDXLConstants.XPIL10Namespace, this.elementType.ToString());
      }

      xwriter.WriteString(this.elementValue);
      xwriter.WriteEndElement();
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
