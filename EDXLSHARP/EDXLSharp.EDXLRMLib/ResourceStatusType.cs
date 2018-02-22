// ———————————————————————–
// <copyright file="ResourceStatusType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the ResourceStatusType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ResourceStatusType
  {
    #region Private Member Variables
    /// <summary>
    /// Date and time that resource inventory counts were last updated
    /// </summary>
    private DateTime inventoryRefreshDateTime;

    /// <summary>
    /// Any val from a discrete managed list, used to specify the general state of a resource
    /// if known.
    /// </summary>
    private EDXLSharp.ValueList deploymentStatus;
    
    /// <summary>
    /// Text to describe availability and limitations on availability. Resource availability refers
    /// to resource that it is present or ready for immediate use, or otherwise accessible or
    /// obtainable, or is qualified or willing to do something or to assume a responsibility.
    /// </summary>
    private string availability;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResourceStatusType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ResourceStatusType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Date and time that resource inventory counts were last updated
    /// </summary>
    public DateTime InventoryRefreshDateTime
    {
      get
      {
        return this.inventoryRefreshDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.inventoryRefreshDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }
    
    /// <summary>
    /// Gets or sets
    /// Any val from a discrete managed list, used to specify the general state of a resource
    /// if known.
    /// </summary>
    public EDXLSharp.ValueList DeploymentStatus
    {
      get { return this.deploymentStatus; }
      set { this.deploymentStatus = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Text to describe availability and limitations on availability. Resource availability refers
    /// to resource that it is present or ready for immediate use, or otherwise accessible or
    /// obtainable, or is qualified or willing to do something or to assume a responsibility.
    /// </summary>
    public string Availability
    {
      get { return this.availability; }
      set { this.availability = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="messageContentType">Pointer to messageContentType which represents the resource type of Resource Message sent</param>
    internal void WriteToXML(XmlWriter xwriter, MessageType? messageContentType)
    {
      this.Validate(messageContentType);

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "ResourceStatus", EDXLConstants.RM10MsgNamespace);
      if (this.inventoryRefreshDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "InventoryRefreshDateTime", EDXLConstants.RM10MsgNamespace, this.inventoryRefreshDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.deploymentStatus != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "DeploymentStatus", EDXLConstants.RM10MsgNamespace);
        this.deploymentStatus.WriteXML(EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.availability))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Availability", EDXLConstants.RM10MsgNamespace, this.availability);
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
          case "InventoryRefreshDateTime":
            this.inventoryRefreshDateTime = DateTime.Parse(node.InnerText);
            if (this.inventoryRefreshDateTime.Kind == DateTimeKind.Unspecified)
            {
              this.inventoryRefreshDateTime = DateTime.MinValue;
              throw new ArgumentException("TimeZone Information Must Be Specified");
            }

            this.inventoryRefreshDateTime = this.inventoryRefreshDateTime.ToUniversalTime();
            break;
          case "DeploymentStatus":
            this.deploymentStatus = new EDXLSharp.ValueList();
            this.deploymentStatus.ReadXML(node);
            break;
          case "Availability":
            this.availability = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ResourceStatusType");
        }
      }

      this.Validate(messageContent);
    }

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    /// <param name="messageContentType">Pointer to messageContentType which represents the resource type of Resource Message sent</param>
    private void Validate(MessageType? messageContentType)
    {
      if ((this.inventoryRefreshDateTime != DateTime.MinValue) && (messageContentType == MessageType.RequestResource || messageContentType == MessageType.RequisitionResource || messageContentType == MessageType.ReleaseResource || messageContentType == MessageType.RequestReturn || messageContentType == MessageType.ResponseToRequestReturn || messageContentType == MessageType.RequestQuote || messageContentType == MessageType.RequestResourceDeploymentStatus || messageContentType == MessageType.RequestExtendedDeploymentDuration || messageContentType == MessageType.ResponseToRequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("InventoryRefreshDateTime is not applicable if MessageContentType is: " + messageContentType);
      }

      if (this.deploymentStatus != null && (messageContentType == MessageType.RequestResource || messageContentType == MessageType.RequisitionResource || messageContentType == MessageType.RequestQuote || messageContentType == MessageType.RequestResourceDeploymentStatus))
      {
        throw new ArgumentNullException("DeploymentStatus is not applicable if MessageContentType is: " + messageContentType);
      }

      if (this.deploymentStatus == null && messageContentType == MessageType.ResponseToRequestReturn)
      {
        throw new ArgumentNullException("DeploymentStatus is required if MessageContentType is: " + messageContentType);
      }

      if (!string.IsNullOrEmpty(this.availability) && (messageContentType == MessageType.RequestResource || messageContentType == MessageType.RequisitionResource || messageContentType == MessageType.CommitResource || messageContentType == MessageType.RequestQuote || messageContentType == MessageType.RequestResourceDeploymentStatus))
      {
        throw new ArgumentNullException("Availability is not applicable if MessageContentType is: " + messageContentType);
      }

      if (string.IsNullOrEmpty(this.availability) && messageContentType == MessageType.ResponseToRequestReturn)
      {
        throw new ArgumentNullException("Availability is required if MessageContentType is: " + messageContentType);
      }
    }
    #endregion
  }
}
