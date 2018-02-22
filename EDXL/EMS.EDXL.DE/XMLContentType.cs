// ———————————————————————–
// <copyright file="XMLContentType.cs" company="EDXLSharp">
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

using EMS.EDXL.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// Container for valid namespace XML data
  /// </summary>
  [Serializable]
  [JsonObject(MemberSerialization.OptIn)]
  public partial class XMLContentType
  {
    #region Private Member Variables
    /// <summary>
    /// A container element for collected fragments of valid XML. 
    /// </summary>
    /// <seealso cref="KeyXMLContent"/>
    private List<XElement> keyXMLContent;

    /// <summary>
    /// The embeddedXMLContent element is an open container for valid XML from an explicit namespace XML Schema. 
    /// </summary>
    /// <seealso cref="EmbeddedXMLContent"/>
    private List<XElement> embeddedXMLContent;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the XMLContentType class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public XMLContentType()
    {
      this.keyXMLContent = new List<XElement>();
      this.embeddedXMLContent = new List<XElement>();
    }

    /// <summary>
    /// Initializes a new instance of the XMLContentType class by converting a content type into an XML Content Object
    /// </summary>
    /// <param name="content">XML Content Object with data</param>
    public XMLContentType(XElement content) : this()
    {
      /* We need to convert the given content to an XElement
       * The given element can write itself using an XmlWriter,
       * and an XElement can provide an XmlWriter to write to
       * itself. However, there's no constructor for a blank
       * XElement, so we do the same thing with an XDocument
       * and just take the root element */
      this.embeddedXMLContent.Add(content);
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets the XML object for <see cref="KeyXMLContent"/>.
    /// </summary> 
    /// <value>XML Serialization Object for key XML Content</value>
    /// <returns>If the keyXMLContent list is not empty then the XML Serialization Object for key XML Content.  Otherwise, null</returns>
    /// <remarks>If value given is null then keyXMLContent is not set</remarks>
    [XmlElement(ElementName = "keyXMLContent", Order = 0)]
    [JsonProperty("keyXMLContent", NullValueHandling = NullValueHandling.Ignore)]
    public List<XElement> KeyXMLContent
    {
      get
      {
        return this.keyXMLContent;
      }

      set
      {
        if (value != null)
        {
          this.keyXMLContent = value;
        }
      }
    }

    /// <summary>
    /// Specifies whether not the required element key is specified
    /// </summary>
    [XmlIgnore]
    public bool KeyXMLContentSpecified
    {
      get { return this.keyXMLContent != null && this.keyXMLContent.Count > 0;  }
    }
    /// <summary>
    /// Gets or sets the XML object for <see cref="EmbeddedXMLContent"/>.
    /// </summary> 
    /// <value>XML Serialization Object for embedded XML Content</value>
    /// <returns>If the embeddedXMLContent list is not empty then the XML Serialization Object for Embedded XML Content.  Otherwise, null</returns>
    /// <remarks>If value given is null then embeddedXMLConten is not set</remarks>
    [XmlElement(ElementName = "embeddedXMLContent", Order = 1)]
    [JsonProperty("embeddedXMLContent", NullValueHandling = NullValueHandling.Ignore)]
    public List<XElement> EmbeddedXMLContent
    {
      get
      {
        return this.embeddedXMLContent;
      }

      set
      {
          this.embeddedXMLContent = value;
      }
    }
    /// <summary>
    /// Indicated whether the EmbeddedXMLContent has been specified
    /// </summary>
    [XmlIgnore]
    public bool EmbeddedXMLContentSpecified
    {
      get { return this.embeddedXMLContent != null && this.embeddedXMLContent.Count > 0; }
    }

    #endregion

    /// <summary>
    /// Adds Key XML Content To The keyXMLContent List
    /// </summary>
    /// <param name="keyXML">Valid XML Element That Is Outside the DE Namespace</param>
    /// <remarks>keyXML must be outside this namespace</remarks>
    /// <exception cref="ArgumentNullException">keyXML is null</exception>
    /// <exception cref="ArgumentException">keyXML is not explicitly namespaced or is in an invalid namespace</exception>
    public void AddKeyXML(XElement keyXML)
    {
      this.CheckNameSpace(keyXML);
      this.keyXMLContent.Add(keyXML);
    }

    /// <summary>
    /// Adds Embedded XML Content To The embeddedXMLContent  List
    /// </summary>
    /// <param name="embeddedXML">Valid XML Element That Is Outside the DE Namespace</param>
    /// <remarks>embeddedXML must be outside this namespace</remarks>
    /// <exception cref="ArgumentNullException">embeddedXML is null</exception>
    /// <exception cref="ArgumentException">embeddedXML is not explicitly namespaced or is in an invalid namespace</exception>
    public void AddEmbeddedXML(XElement embeddedXML)
    {
      this.CheckNameSpace(embeddedXML);
      this.embeddedXMLContent.Add(embeddedXML);
    }

    /// <summary>
    /// Checks Whether The Input XElement is in the DE 1.0 Namespace
    /// </summary>
    /// <param name="xe">XML Element or Document Object</param>
    /// <exception cref="ArgumentNullException">xe is null</exception>
    /// <exception cref="ArgumentException">xe is not explicitly name-spaced or is in an invalid namespace</exception>
    private void CheckNameSpace(XElement xe)
    {
      if (xe == null)
      {
        throw new ArgumentNullException("Input XElement can't be null");
      }

      XNamespace name = xe.Name.Namespace;
      if (name.NamespaceName == EDXLConstants.EDXLDE10Namespace)
      {
        throw new ArgumentException("Embedded and Key XML Content Must Be Outside the " + EDXLConstants.EDXLDE10Namespace + " Namespace");
      }
      else if (name.NamespaceName == string.Empty)
      {
        throw new ArgumentException("Embedded and Key XML Content Must Be Explicitly Name-spaced");
      }
    }
  }
}
