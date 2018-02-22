// ———————————————————————–
// <copyright file="NameElementType.cs" company="EDXLSharp">
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
  /// Class to Represent the xNL Name element
  /// </summary>
  [Serializable]
  public partial class NameElementType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Clarifies the meaning of the element.  Could be first name, middle name, etc.
    /// </summary>
    private string elementType;

    /// <summary>
    /// Indicates if This is an Abbreviation
    /// </summary>
    private bool? abbreviation;

    /// <summary>
    /// The Name element String
    /// </summary>
    private string name;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the NameElementType class
    /// Default Constructor - Does Nothing
    /// </summary>
    public NameElementType()
    {
    }

    /// <summary>
    /// Initializes a new instance of the NameElementType class
    /// Constructor That Initializes Required Elements Type and Name
    /// </summary>
    /// <param name="type">Free text type of this name element</param>
    /// <param name="name">The String representing the name element</param>
    public NameElementType(string type, string name)
    {
      this.elementType = type;
      this.name = name;
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The Name element String
    /// </summary>
    public string Name
    {
      get { return this.name; }
      set { this.name = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Indicates if This is an Abbreviation
    /// </summary>
    public bool? Abbreviation
    {
      get { return this.abbreviation; }
      set { this.abbreviation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Clarifies the meaning of the element.  Could be first name, middle name, etc.
    /// </summary>
    public string ElementType
    {
      get { return this.elementType; }
      set { this.elementType = value; }
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.XNLPrefix, "NameElement", EDXLConstants.XNL10Namespace);
      if (!string.IsNullOrEmpty(this.elementType))
      {
        xwriter.WriteAttributeString(EDXLConstants.XNLPrefix, "ElementType", EDXLConstants.XNL10Namespace, this.elementType);
      }

      if (this.abbreviation != null)
      {
        xwriter.WriteAttributeString(EDXLConstants.XNLPrefix, "Abbreviation", EDXLConstants.XNL10Namespace, this.abbreviation.ToString());
      }

      if (!string.IsNullOrEmpty(this.name))
      {
        xwriter.WriteString(this.name);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (string.IsNullOrEmpty(rootnode.InnerText))
      {
        return;
      }

      foreach (XmlAttribute attrib in rootnode.Attributes)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "ElementType":
            this.elementType = attrib.InnerText;
            break;
          case "Abbreviation":
            this.abbreviation = bool.Parse(attrib.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected attribute name: " + attrib.Name + " in NameElementType");
        }
      }

      this.name = rootnode.InnerText;
      this.Validate();
    }

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}