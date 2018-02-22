// ———————————————————————–
// <copyright file="PersonNameType.cs" company="EDXLSharp">
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
  /// Container to Represent an Individual's Name
  /// </summary>
  [Serializable]
  public partial class PersonNameType : IComposable
  {
    #region Private Member Variables
    
    /// <summary>
    /// Container for Individual Elements of a Name
    /// </summary>
    private List<NameElementType> nameElement;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the PersonNameType class
    /// Default Constructor - Initializes List
    /// </summary>
    public PersonNameType()
    {
      this.nameElement = new List<NameElementType>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Container for Individual Elements of a Name
    /// </summary>
    public List<NameElementType> NameElement
    {
      get { return this.nameElement; }
      set { this.nameElement = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.XNLPrefix, "PersonName", EDXLConstants.XNL10Namespace);
      if (this.nameElement.Count > 0)
      {
        foreach (NameElementType name in this.nameElement)
        {
          name.WriteXML(xwriter);
        }
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    public void ReadXML(XmlNode rootnode)
    {
      NameElementType nametemp;
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "NameElement":
            nametemp = new NameElementType();
            nametemp.ReadXML(node);
            this.nameElement.Add(nametemp);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Node Name: " + node.Name + " in PersonNameType");
        }
      }

      this.Validate();
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
