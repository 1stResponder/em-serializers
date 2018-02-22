// ———————————————————————–
// <copyright file="OwnershipInformationType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the OwnershipInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class OwnershipInformationType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    The name of an agency or supplier that owns the resource (which may not be the
    ///    home unit or dispatch). Also referred to as home agency.
    ///  Constraints 
    ///    􀂃 At least one of OwnershipInformation:Owner or
    ///    OwnershipInformation:OwningJurisdiction MUST be present for each
    ///    OwnershipInformation element.
    /// </summary>
    private string owner;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    A geopolitical area in which an organization, person, or object has a specific range of
    ///    authority for specified resources.
    ///  Constraints 
    ///    • At least one of OwnershipInformation:Owner or
    ///    OwnershipInformation:OwningJurisdiction MUST be present for each
    ///    OwnershipInformation element.
    ///  Comments 
    ///    • Can be a code
    /// </summary>
    private string owningJurisdiction;
    
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Resource home agency dispatch center name. This identifies the dispatch unit that
    ///    has primary responsibility for maintaining information on the resource (e.g., Ft. Collins
    ///    Dispatch Center, Rocky Mountain Area Coordination Center).
    ///  Comments 
    ///    􀂃 Conditional Usage:
    ///      o Not Applicable:
    ///    􀂃 EDXLResourceMessage:messageContentType =
    ///    “RequestResource”
    ///      o Optional, otherwise
    /// </summary>
    private string homeDispatch;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    The unit (office, district, organization, etc.) from which the resource typically works or is
    ///    used (e.g., Manti-LaSalle National Forest/Sanpete District). When released from an
    ///    assignment, the location to which the resource is released will usually be determined
    ///    by the home unit.
    ///  Comments 
    ///    􀂃 Conditional Usage:
    ///      o Not Applicable:
    ///    􀂃 EDXLResourceMessage:messageContentType =
    ///    “RequestResource”
    ///      o Optional, otherwise
    /// </summary>
    private string homeUnit;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the OwnershipInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public OwnershipInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The name of an agency or supplier that owns the resource (which may not be the
    /// home unit or dispatch). Also referred to as home agency.
    /// </summary>
    public string Owner
    {
      get { return this.owner; }
      set { this.owner = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A geopolitical area in which an organization, person, or object has a specific range of
    /// authority for specified resources.
    /// </summary>
    public string OwnerJurisdiction
    {
      get { return this.owningJurisdiction; }
      set { this.owningJurisdiction = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Resource home agency dispatch center name. This identifies the dispatch unit that
    /// has primary responsibility for maintaining information on the resource (e.g., Ft. Collins
    /// Dispatch Center, Rocky Mountain Area Coordination Center).
    /// </summary>
    public string HomeDispatch
    {
      get { return this.homeDispatch; }
      set { this.homeDispatch = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The unit (office, district, organization, etc.) from which the resource typically works or is
    /// used (e.g., Manti-LaSalle National Forest/Sanpete District). When released from an
    /// assignment, the location to which the resource is released will usually be determined
    /// by the home unit.
    /// </summary>
    public string HomeUnit
    {
      get { return this.homeUnit; }
      set { this.homeUnit = value; }
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "OwnershipInformation", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.owner))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "Owner", EDXLConstants.RM10Namespace, this.owner);
      }

      if (!string.IsNullOrEmpty(this.owningJurisdiction))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "OwningJurisdiction", EDXLConstants.RM10Namespace, this.owningJurisdiction);
      }

      if (!string.IsNullOrEmpty(this.homeDispatch))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "HomeDispatch", EDXLConstants.RM10Namespace, this.homeDispatch);
      }

      if (!string.IsNullOrEmpty(this.homeUnit))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "HomeUnit", EDXLConstants.RM10Namespace, this.homeUnit);
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
          case "Owner":
            this.owner = node.InnerText;
            break;
          case "OwningJurisdiction":
            this.owningJurisdiction = node.InnerText;
            break;
          case "HomeDispatch":
            this.homeDispatch = node.InnerText;
            break;
          case "HomeUnit":
            this.homeUnit = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in OwnershipInformationType");
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
      if (string.IsNullOrEmpty(this.owner) && string.IsNullOrEmpty(this.owningJurisdiction))
      {
        throw new ArgumentNullException("Need an Owner or OwningJurisdiction");
      }

      if (messageContent == MessageType.RequestResource && string.IsNullOrEmpty(this.owner))
      {
        throw new ArgumentNullException("Owner is not applicable if MessageContent is RequestResource");
      }

      if (messageContent == MessageType.RequestResource && string.IsNullOrEmpty(this.owningJurisdiction))
      {
        throw new ArgumentNullException("OwningJurisdiction is not applicable if MessageContent is RequestResource");
      }

      if (messageContent == MessageType.RequestResource && string.IsNullOrEmpty(this.homeDispatch))
      {
        throw new ArgumentNullException("HomeDispatch is not applicable if MessageContent is RequestResource");
      }

      if (messageContent == MessageType.RequestResource && string.IsNullOrEmpty(this.homeUnit))
      {
        throw new ArgumentNullException("HomeUnit is not applicable if MessageContent is RequestResource");
      }
    }
    #endregion
  }
}
