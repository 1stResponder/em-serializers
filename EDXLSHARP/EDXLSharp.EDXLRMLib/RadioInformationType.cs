// ———————————————————————–
// <copyright file="RadioInformationType.cs" company="EDXLSharp">
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

using System;
using System.Xml;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the RadioInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class RadioInformationType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once
    ///  Definition 
    ///    Contact radio type of the person or organization referred to in ContactRole
    /// </summary>
    private EDXLSharp.ValueList radioType;

    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once
    ///  Definition 
    ///    Contact radio channel of the person or organization referred to in ContactRole
    ///  Comments 
    ///    • “Channel” and “Frequency” are synonyms for purposes of this standard
    /// </summary>
    private string radioChannel;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the RadioInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public RadioInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Contact radio type of the person or organization referred to in ContactRole
    /// </summary>
    public EDXLSharp.ValueList RadioType
    {
      get { return this.radioType; }
      set { this.radioType = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Contact radio channel of the person or organization referred to in ContactRole
    /// </summary>
    public string RadioChannel
    {
      get { return this.radioChannel; }
      set { this.radioChannel = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal void WriteToXML(XmlWriter xwriter)
    {
      this.Validate();

      if (this.radioType != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "RadioType", EDXLSharp.EDXLConstants.RM10Namespace);
        this.radioType.WriteXML(EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.radioChannel))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "RadioChannel", EDXLSharp.EDXLConstants.RM10Namespace, this.radioChannel);
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
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
          case "RadioType":
            this.radioType = new EDXLSharp.ValueList();
            this.radioType.ReadXML(node);
            break;
          case "RadioChannel":
            this.radioChannel = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in RadioInformationType");
        }
      }

      this.Validate();
    }

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    private void Validate()
    {
      if (this.radioType == null)
      {
        throw new ArgumentNullException("RadioType is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.radioChannel))
      {
        throw new ArgumentNullException("RadioChannel is required and can't be null");
      }
    }
    #endregion
  }
}
