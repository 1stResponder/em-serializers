// ———————————————————————–
// <copyright file="ResourceType.cs" company="EDXLSharp">
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
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the ResourceType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ResourceType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    This identifier (if available) is used to identify and track a resource.
    ///  Constraints
    ///    • At least one of Resource:ResourceID, Resource:Name or
    ///    Resource:TypeStructure MUST be present to identify a specific resource and
    ///    the same element and val MUST be used consistently within a sequence
    ///    from a common Originating Message.
    /// </summary>
    private string resourceID;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition
    ///    A name or title of the resource used for identification and tracking.
    ///  Constraints 
    ///    • At least one of Resource:ResourceID, Resource:Name or
    ///    Resource:TypeStructure MUST be present to identify a specific resource and
    ///    the same element and val MUST be used consistently within a sequence
    ///    from a common Originating Message.
    /// </summary>
    private string name;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    Uniform Resource Name (URN) paired with a string “keyword” val 
    ///    for a certified list of resources maintained by the Community of Interest (for the val
    ///    referenced.)
    ///  Constraints 
    ///    • At least one of Resource:ResourceID, Resource:Name or
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 110 of 174
    ///    Resource:TypeStructure MUST be present to identify a specific resource and
    ///    the same element and val MUST be used consistently within a sequence
    ///    from a common Originating Message for each Resource element present.
    /// </summary>
    private EDXLSharp.ValueList typeStructure;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    The resource type as defined by either a Keyword structure or a valid schema.
    ///  Comments 
    ///    • This element contains one or more child elements whose names and types
    ///    depend on the val of the TypeStructure element.
    /// </summary>
    private XElement typeInfo;

    /// <summary>
    ///    Any value from a discrete managed list, used to specify a keyword.
    /// </summary>
    private EDXLSharp.VLList keyword;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition
    ///    Free Text description of resource or resource characteristics, situation requiring
    ///    resource assistance, or statement of mission the resource satisfies.
    /// </summary>
    private string description;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    Statements of resource qualifications showing that a person or role has a right to
    ///    exercise official power
    ///  Comments 
    ///    • Multiple credentials may be included as a comma-separated list.
    ///    Example 1: “Splinting, bandaging, oxygen administration”
    ///    Example 2: “A practitioner credentialed by a State to function as an EMT by a
    ///    State Emergency Medical Services (EMS) system.”
    /// </summary>
    private string credentials;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    /// Definition 
    ///    Statements of recognition that a resource has met special requirements or
    ///    qualifications within a field
    /// Comments 
    ///   Multiple certifications may be included as a comma-separated list.
    ///   Example 1 "ALS; Advanced First Aid and CPR, BLS; Advanced First Aid and CPR"
    ///   Example 2 "Pilot – Commercial (instrument) or higher certificate and
    ///   complete unit certification program", "Pilot – Private Pilot (instrument) or
    ///   higher certificate and complete unit certification program"
    ///   Example 3 "Trained to the First Responder Operational Level (NFPA
    ///   472); Comply with organization; Operations Level for support personnel as
    ///   outlined in NFPA 1670"
    /// </summary>
    private string certifications;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    A description of any special needs related to the requested resource (e.g. must carry
    ///    protective equipment)
    ///  Comments 
    ///    • Not intended to carry certifications or capabilities.
    /// </summary>
    private string specialRequirements;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Contact Info for person currently responsible for resource
    ///  Comments 
    ///    􀂃 Conditional Usage:
    ///      o Not Applicable:
    ///    􀂃 EDXLResourceMessage:messageContentType =
    ///    “RequestResource”
    ///      o Optional, otherwise
    /// </summary>
    private ContactInformationType responsibleParty;

    /// <summary>
    /// OwnershipInformation Object
    /// </summary>
    private OwnershipInformationType ownershipInformation;

    /// <summary>
    /// ResourceStatus Object
    /// </summary>
    private ResourceStatusType resourceStatus;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResourceType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ResourceType()
    {
      this.keyword = new EDXLSharp.VLList("Keyword");
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// This identifier (if available) is used to identify and track a resource.
    /// </summary>
    public string ResourceID
    {
      get { return this.resourceID; }
      set { this.resourceID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A name or title of the resource used for identification and tracking.
    /// </summary>
    public string Name
    {
      get { return this.name; }
      set { this.name = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Uniform Resource Name (URN) paired with a string “keyword” val
    /// </summary>
    public EDXLSharp.ValueList TypeStructure
    {
      get { return this.typeStructure; }
      set { this.typeStructure = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The resource type as defined by either a Keyword structure or a valid schema
    /// </summary>
    public XElement TypeInfo
    {
      get { return this.typeInfo; }
      set { this.typeInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Any val from a discrete managed list, used to specify a keyword.
    /// </summary>
    public IList<EDXLSharp.ValueList> Keyword
    {
      get { return this.keyword.Values; }
      set { this.keyword.Values = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free Text description of resource or resource characteristics, situation requiring
    /// resource assistance, or statement of mission the resource satisfies.
    /// </summary>
    public string Description
    {
      get { return this.description; }
      set { this.description = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Statements of resource qualifications showing that a person or role has a right to
    /// exercise official power
    /// </summary>
    public string Credentials
    {
      get { return this.credentials; }
      set { this.credentials = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Statements of recognition that a resource has met special requirements or
    /// qualifications within a field
    /// </summary>
    public string Certifications
    {
      get { return this.certifications; }
      set { this.certifications = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A description of any special needs related to the requested resource (e.g. must carry
    /// protective equipment)
    /// </summary>
    public string SpecialRequirements
    {
      get { return this.specialRequirements; }
      set { this.specialRequirements = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Contact Info for person currently responsible for resource
    /// </summary>
    public ContactInformationType ResponsibleParty
    {
      get { return this.responsibleParty; }
      set { this.responsibleParty = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OwnershipInformation Object
    /// </summary>
    public OwnershipInformationType OwnershipInformation
    {
      get { return this.ownershipInformation; }
      set { this.ownershipInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// ResourceStatus Object
    /// </summary>
    public ResourceStatusType ResourceStatus
    {
      get { return this.resourceStatus; }
      set { this.resourceStatus = value; }
    }
    #endregion

    #region Internal Member Functions

    /// <summary>
    /// Converts This Object To One or More Syndication Items
    /// </summary>
    /// <param name="myitem">Syndication Item with Associated GeoRSS Content</param>
    /// <param name="contentstr">Constructed string for syndication item content</param>
    internal void ToGeoRSS(SyndicationItem myitem, StringBuilder contentstr)
    {
      if (!string.IsNullOrEmpty(this.resourceID))
      {
        contentstr.AppendLine("ResourceID: " + this.resourceID);
      }

      if (!string.IsNullOrEmpty(this.name))
      {
        string temp = myitem.Title.Text;
        myitem.Title = new TextSyndicationContent(this.name + " " + temp);
        contentstr.AppendLine("Name: " + this.name);
      }

      if (!string.IsNullOrEmpty(this.description))
      {
        contentstr.AppendLine("Description: " + this.description);
      }
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="messageContent">Pointer to messageContent which represents the resource type of Resource Message sent</param>
    internal void WriteToXML(XmlWriter xwriter, MessageType? messageContent)
    {
      this.Validate(messageContent);

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "Resource", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.resourceID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "ResourceID", EDXLConstants.RM10MsgNamespace, this.resourceID);
      }

      if (!string.IsNullOrEmpty(this.name))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Name", EDXLConstants.RM10MsgNamespace, this.name);
      }

      if (this.typeStructure != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "TypeStructure", EDXLConstants.RM10MsgNamespace);
        this.typeStructure.WriteXML(EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);
        xwriter.WriteEndElement();
      }

      if (this.typeInfo != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "TypeInfo", EDXLConstants.RM10MsgNamespace);
        this.typeInfo.WriteTo(xwriter);
        xwriter.WriteEndElement();
      }

      this.keyword.WriteXML(EDXLConstants.RM10MsgPrefix, EDXLConstants.RM10MsgNamespace, EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);

      if (!string.IsNullOrEmpty(this.description))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Description", EDXLConstants.RM10MsgNamespace, this.description);
      }

      if (!string.IsNullOrEmpty(this.credentials))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Credentials", EDXLConstants.RM10MsgNamespace, this.credentials);
      }

      if (!string.IsNullOrEmpty(this.certifications))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Certifications", EDXLConstants.RM10MsgNamespace, this.certifications);
      }

      if (!string.IsNullOrEmpty(this.specialRequirements))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "SpecialRequirements", EDXLConstants.RM10MsgNamespace, this.specialRequirements);
      }

      if (this.responsibleParty != null)
      {
        this.responsibleParty.WriteXML(xwriter, "ResponsibleParty");
      }

      if (this.ownershipInformation != null)
      {
        this.ownershipInformation.WriteToXML(xwriter, messageContent);
      }

      if (this.resourceStatus != null)
      {
        this.resourceStatus.WriteToXML(xwriter, messageContent);
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
      if (this.keyword == null)
      {
        this.keyword = new EDXLSharp.VLList("Keyword");
      }

      this.keyword.ReadXML(rootNode);

      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ResourceID":
            this.resourceID = node.InnerText;
            break;
          case "Name":
            this.name = node.InnerText;
            break;
          case "TypeStructure":
            this.typeStructure = new EDXLSharp.ValueList();
            this.typeStructure.ReadXML(node);
            break;
          case "TypeInfo":
            this.typeInfo = XElement.Load(new XmlNodeReader(node));
            break;
          case "Keyword":
            break;
          case "Description":
            this.description = node.InnerText;
            break;
          case "Credentials":
            this.credentials = node.InnerText;
            break;
          case "Certifications":
            this.certifications = node.InnerText;
            break;
          case "SpecialRequirements":
            this.specialRequirements = node.InnerText;
            break;
          case "ResponsibleParty":
            this.responsibleParty = new ContactInformationType();
            this.responsibleParty.ReadXML(node);
            break;
          case "OwnershipInformation":
            this.ownershipInformation = new OwnershipInformationType();
            this.ownershipInformation.ReadXML(node, messageContent);
            break;
          case "ResourceStatus":
            this.resourceStatus = new ResourceStatusType();
            this.resourceStatus.ReadXML(node, messageContent);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ResourceType");
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
      if (string.IsNullOrEmpty(this.resourceID) && string.IsNullOrEmpty(this.name) && this.typeStructure == null)
      {
        throw new ArgumentNullException("Need a ResourceID, Name or TypeStructure");
      }

      if (messageContent == MessageType.RequestResource && this.responsibleParty != null)
      {
        throw new ArgumentNullException("ResponsibleParty is not applicable for Message Content of RequestResource");
      }

      if (messageContent == MessageType.RequestResource && this.ownershipInformation != null)
      {
        throw new ArgumentNullException("OwndershipInformation is not applicable for Message Content of RequestResource");
      }

      if (this.resourceStatus != null && (messageContent == MessageType.RequestResource || messageContent == MessageType.RequisitionResource || messageContent == MessageType.RequestQuote || messageContent == MessageType.RequestResourceDeploymentStatus))
      {
        throw new ArgumentNullException("ResourceStatus is not applicable for Message Content of: " + messageContent);
      }

      if (this.resourceStatus == null && messageContent == MessageType.ResponseToRequestReturn)
      {
        throw new ArgumentNullException("ResourceStatus is required for Message Content of: " + messageContent);
      }
    }
    #endregion
  }
}
