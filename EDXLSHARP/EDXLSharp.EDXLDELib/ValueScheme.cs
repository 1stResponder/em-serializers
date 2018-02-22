// ———————————————————————–
// <copyright file="ValueScheme.cs" company="EDXLSharp">
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.EDXLDELib
{
  /// <summary>
  /// The identifier of an explicit recipient
  /// </summary>
  [Serializable]
  public partial class ValueScheme : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// Identifies the distribution addressing scheme used. 
    /// Required Element
    /// </summary>
    /// <seealso cref="ExplicitAddressScheme"/>
    private string explicitAddressScheme;

    /// <summary>
    /// A properly formed -escaped if necessary- XML string denoting the addressees value. 
    /// </summary>
    /// <seealso cref="ExplicitAddressValue"/>
    /// <seealso cref="ExplicitAddressValueXML"/>
    private List<string> explicitAddressValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ValueScheme class
    /// Default Constructor - Initializes List
    /// </summary>
    public ValueScheme()
    {
      this.explicitAddressValue = new List<string>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets ExplicitAddressScheme
    /// Required Element
    /// </summary>
    /// <value>Identifies the distribution addressing scheme used.</value>
    /// <remarks>Examples for this type of distribution includes - email, military USMTF, etc. . .</remarks>
    /// <seealso cref="explicitAddressScheme"/>
    [XmlElement(ElementName = "explicitAddressScheme", Order = 0)]
    [JsonProperty("explicitAddressScheme", NullValueHandling = NullValueHandling.Ignore)]
    public string ExplicitAddressScheme
    {
      get { return this.explicitAddressScheme; }
      set { this.explicitAddressScheme = value; }
    }

    /// <summary>
    /// Gets or sets the ExplicitAddressValue
    /// </summary>
    /// <value>A properly formed -escaped if necessary- XML string denoting the addressees value. </value>
    /// <remarks>For serialization/deserialization <see cref="ExplicitAddressValueXML"/></remarks>
    /// <seealso cref="explicitAddressValue"/>
    [XmlIgnore]
    public List<string> ExplicitAddressValue
    {
      get { return this.explicitAddressValue; }
      set { this.explicitAddressValue = value; }
    }

    /// <summary>
    /// Gets or sets the XML object for <see cref="ExplicitAddressValue"/>
    /// </summary>
    /// <value>XML Serialization Object for Explicit Address Value</value>
    /// <returns>If the explicitAddressValue list is not empty, then the XML Serialization Object for Explicit Address Value.  Otherwise, null</returns>
    /// <remarks>If value given is null then the ExplicitAddressValueXML is not set</remarks>
    [XmlElement(ElementName = "explicitAddressValue", Order = 1)]
    [JsonProperty("explicitAddressValue", NullValueHandling = NullValueHandling.Ignore)]
    public string[] ExplicitAddressValueXML
    {
      get
      {
        if (this.explicitAddressValue.Count == 0)
        {
          return null;
        }
        else
        {
          return this.explicitAddressValue.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.explicitAddressValue = value.ToList();
        }
      }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes This Object into an XML Document
    /// </summary>
    /// <remarks>Requires ExplicitAddressScheme to be defined and not empty</remarks>
    /// <param name="xwriter">Xml Writer for an Existing XML Document</param>
    /// <exception cref="ArgumentException">ExplicitAddressScheme is null or empty</exception>
    /// <seealso cref="Validate"/>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement("explicitAddress");
      xwriter.WriteElementString("explicitAddressScheme", this.explicitAddressScheme);
      foreach (string value in this.explicitAddressValue)
      {
        if (string.IsNullOrEmpty(value))
        {
          continue;
        }

        xwriter.WriteElementString("explicitAddressValue", value);
      }

      xwriter.WriteEndElement();
      xwriter.Flush();
    }

    /// <summary>
    /// Reads this Object from XML
    /// </summary>
    /// <remarks>The XML must have an ExplicitAddressScheme element with a value</remarks>
    /// <param name="rootnode">Existing XML Node</param>
    /// <exception cref="FormatException">Unexpected node found in XML</exception>
    /// <exception cref="ArgumentException">ExplicitAddressScheme is null or empty</exception>
    /// <seealso cref="Validate"/>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "explicitAddressScheme":
            this.explicitAddressScheme = node.InnerText;
            break;
          case "explicitAddressValue":
            this.explicitAddressValue.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid node: " + node.Name + "found in ValueScheme Type");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    /// <exception cref="ArgumentException">ExplicitAddressScheme is null or empty</exception>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.explicitAddressScheme))
      {
        throw new ArgumentException("ExplicitAddressScheme Can't Be Null or Empty!");
      }
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}
