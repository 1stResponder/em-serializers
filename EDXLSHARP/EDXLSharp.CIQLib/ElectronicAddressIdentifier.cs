// ———————————————————————–
// <copyright file="ElectronicAddressIdentifier.cs" company="EDXLSharp">
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
  /// A container of different types of electronic addresses of party (e.g. email, chat, skype, etc)
  /// </summary>
  [Serializable]
  public partial class ElectronicAddressIdentifier : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Type of the electronic Address
    /// </summary>
    private ElectronicAddressIdentifierType? type;

    /// <summary>
    /// Usage of electronic address identifier. e.g. business, personal
    /// </summary>
    private string usage;

    /// <summary>
    /// The Free-Text Address
    /// </summary>
    private string electronicAddress;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ElectronicAddressIdentifier class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ElectronicAddressIdentifier()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// The Free-Text Address
    /// </summary>
    public string ElectronicAddress
    {
      get { return this.electronicAddress; }
      set { this.electronicAddress = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Usage of electronic address identifier. e.g. business, personal
    /// </summary>
    public string Usage
    {
      get { return this.usage; }
      set { this.usage = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type of the electronic Address
    /// </summary>
    public ElectronicAddressIdentifierType? Type
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
      xwriter.WriteStartElement("ElectronicAddressIdentifier", EDXLConstants.XPIL10Namespace);
      if (this.type != null)
      {
        xwriter.WriteAttributeString("Type", EDXLConstants.XPIL10Namespace, this.type.ToString());
      }

      if (!string.IsNullOrEmpty(this.usage))
      {
        xwriter.WriteAttributeString("Usage", EDXLConstants.XPIL10Namespace, this.usage);
      }

      xwriter.WriteString(this.electronicAddress);
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "ElectronicAddressIdentifier")
      {
        this.electronicAddress = rootnode.InnerText;
        foreach (XmlAttribute attrib in rootnode.Attributes)
        {
          if (attrib.LocalName == "Type")
          {
            this.type = (ElectronicAddressIdentifierType)Enum.Parse(typeof(ElectronicAddressIdentifierType), attrib.InnerText);
          }
          else if (attrib.LocalName == "Usage")
          {
            this.usage = attrib.InnerText;
          }
          else
          {
            throw new ArgumentException("Invalid Attribute Name: " + attrib.Name + " in ElectronicAddressIdentifier");
          }
        }
      }
      else
      {
        throw new ArgumentException("Invalid Node Name: " + rootnode.Name + " in ElectronicAddressIdentifier");
      }

      this.Validate();
    }

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.electronicAddress))
      {
        throw new ArgumentException("Electronic Address is required and can't be null!");
      }
    }
    #endregion

    #region Protected Member Functions
    #endregion

    #region Private Member Functions

    #endregion
  }
}