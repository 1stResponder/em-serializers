// ———————————————————————–
// <copyright file="AssignmentInstructionsType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the AssignmentInstructionsType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class AssignmentInstructionsType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Method or mode used to transport the resource to or from the incident.
    ///  Comments 
    ///    • Conditional Usage:
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 121 of 174
    ///      o Not Applicable
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestExtendedDeploymentDuration”
    ///      o Optional, otherwise
    /// </summary>
    private string modeOfTransportation;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Instructions that define how to get to the “ReportTo” location.
    ///  Comments 
    ///    • Conditional Usage:
    ///      o Not Applicable
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestExtendedDeploymentDuration”
    ///      o Optional, otherwise
    /// </summary>
    private string navigationInstructions;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    A text description which explains to whom or where the resource should report upon
    ///    arrival. This could include a name for a person, place or functional role.
    ///  Comments 
    ///    • Conditional Usage:
    ///      o Not Applicable
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestResource”
    ///        EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///        Copyright © OASIS® 1993–2008 Page 122 of 174
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestExtendedDeploymentDuration”
    ///      o Optional, otherwise
    /// </summary>
    private string reportingInstructions;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the AssignmentInstructionsType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public AssignmentInstructionsType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Method or mode used to transport the resource to or from the incident
    /// </summary>
    public string ModeOfTransportation
    {
      get { return this.modeOfTransportation; }
      set { this.modeOfTransportation = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Instructions that define how to get to the “ReportTo” location
    /// </summary>
    public string NavigationInstructions
    {
      get { return this.navigationInstructions; }
      set { this.navigationInstructions = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// A text description which explains to whom or where the resource should report upon
    /// arrival. This could include a name for a person, place or functional role
    /// </summary>
    public string ReportingInstructions
    {
      get { return this.reportingInstructions; }
      set { this.reportingInstructions = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="messageContent">Pointer to messageContent which represents the resource type of Resource Message sent</param>
    internal void WriteToXML(XmlWriter xwriter, MessageType? messageContent)
    {
      this.Validate(messageContent);

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "AssignmentInstructions", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.modeOfTransportation))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ModeOfTransportation", EDXLConstants.RM10Namespace, this.modeOfTransportation);
      }

      if (!string.IsNullOrEmpty(this.navigationInstructions))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "NavigationInstructions", EDXLConstants.RM10Namespace, this.navigationInstructions);
      }

      if (!string.IsNullOrEmpty(this.reportingInstructions))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ReportingInstructions", EDXLConstants.RM10Namespace, this.reportingInstructions);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
    /// <param name="messageContent">MessageType of this RM Message</param>
    internal void ReadXML(XmlNode rootNode, MessageType? messageContent)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ModeOfTransportation":
            this.modeOfTransportation = node.InnerText;
            break;
          case "NavigationInstructions":
            this.navigationInstructions = node.InnerText;
            break;
          case "ReportingInstructions":
            this.reportingInstructions = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in AssignmentInstructionsType");
        }
      }

      this.Validate(messageContent);
    }
    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    /// <param name="messageContent">Pointer to messageContent which represents the resource type of Resource Message sent</param>
    private void Validate(MessageType? messageContent)
    {
      if ((messageContent == MessageType.RequestResource || messageContent == MessageType.RequestExtendedDeploymentDuration) && string.IsNullOrEmpty(this.modeOfTransportation))
      {
        throw new ArgumentNullException("Mode Of Transportation must be null");
      }

      if ((messageContent == MessageType.RequestResource || messageContent == MessageType.RequestExtendedDeploymentDuration) && string.IsNullOrEmpty(this.navigationInstructions))
      {
        throw new ArgumentNullException("Navigation Instruction must be null");
      }

      if ((messageContent == MessageType.RequestResource || messageContent == MessageType.RequestExtendedDeploymentDuration) && string.IsNullOrEmpty(this.reportingInstructions))
      {
        throw new ArgumentNullException("Reporting Instruction must be null");
      }
    }
    #endregion
  }
}
