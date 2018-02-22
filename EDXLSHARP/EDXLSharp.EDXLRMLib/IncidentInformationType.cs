// ———————————————————————–
// <copyright file="IncidentInformationType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the IncidentInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class IncidentInformationType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    The name or other identifier of the incident to which the current message refers.
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 105 of 174
    ///  Constraints 
    ///    • If an IncidentInformation element is present, then at least one of
    ///    IncidentInformation:IncidentID or IncidentInformation:IncidentDescription
    ///    MUST be present
    /// </summary>
    private string incidentID;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    A free form description of the incident to which the current message refers.
    ///  Constraints 
    ///    • If an IncidentInformation element is present, then at least one of
    ///    IncidentInformation:IncidentID or IncidentInformation:IncidentDescription
    ///    MUST be present
    /// </summary>
    private string incidentDescription;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the IncidentInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public IncidentInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The name or other identifier of the incident to which the current message refers.
    /// </summary>
    public string IncidentID
    {
      get { return this.incidentID; }
      set { this.incidentID = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// A free form description of the incident to which the current message refers.
    /// </summary>
    public string IncidentDescription
    {
      get { return this.incidentDescription; }
      set { this.incidentDescription = value; }
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "IncidentInformation", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.incidentID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "IncidentID", EDXLSharp.EDXLConstants.RM10Namespace, this.incidentID);
      }

      if (!string.IsNullOrEmpty(this.incidentDescription))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "IncidentDescription", EDXLSharp.EDXLConstants.RM10Namespace, this.incidentDescription);
      }

      xwriter.WriteEndElement();
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
          case "IncidentID":
            this.incidentID = node.InnerText;
            break;
          case "IncidentDescription":
            this.incidentDescription = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in IncidentInformationType");
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
      if (string.IsNullOrEmpty(this.incidentDescription) && string.IsNullOrEmpty(this.incidentID))
      {
        throw new ArgumentNullException("IncidentDescription or IncidentID must be used");
      }
    }
    #endregion
  }
}
