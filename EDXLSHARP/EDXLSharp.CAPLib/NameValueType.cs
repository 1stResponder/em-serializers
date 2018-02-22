// ———————————————————————–
// <copyright file="NameValueType.cs" company="EDXLSharp">
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

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// Object Representing a Name Value Pair
  /// </summary>
  [Serializable]
  public partial class NameValueType
  {
    #region Private Member Variables
    /// <summary>
    /// The name associated with the pair
    /// </summary>
    private string name;

    /// <summary>
    /// The Value associated with the pair
    /// </summary>
    private string value;

    /// <summary>
    /// The namespace of the CAP element
    /// </summary>
    private string capNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the NameValueType class 
    /// Default Constructor - Does Nothing
    /// </summary>
    public NameValueType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The Name Associated with the Pair
    /// </summary>
    public string Name
    {
      get { return this.name; }
      set { this.name = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// The String Value
    /// </summary>
    public string Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The CAP namespace for serialization
    /// </summary>
    [XmlIgnore]
    public string CapNamespace
    {
      get { return this.capNamespace; }
      set { this.capNamespace = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      if (string.IsNullOrEmpty(this.capNamespace))
      {
        this.capNamespace = EDXLConstants.CAP12Namespace;
      }

      if (!string.IsNullOrEmpty(this.name))
      {
        xwriter.WriteElementString("valueName", this.capNamespace, this.name);
      }

      if (!string.IsNullOrEmpty(this.value))
      {
        xwriter.WriteElementString("value", this.capNamespace, this.value);
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the Root Object Element</param>
    internal void ReadXML(XmlNode rootNode)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "valueName":
            this.name = node.InnerText;
            break;
          case "value":
            this.value = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid value: " + node.InnerText + " found in Area Type");
        }
      }
    }
    #endregion
  }
}
