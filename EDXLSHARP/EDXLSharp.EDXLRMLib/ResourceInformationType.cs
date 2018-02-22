// ———————————————————————–
// <copyright file="ResourceInformationType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the ResourceInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ResourceInformationType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once.
    ///  Definition 
    ///    This element identifies the instance of ResourceInformation within the message. It
    ///    does not identify the Resource.
    ///  Comments 
    ///    • The purpose of this element is to uniquely identify the ResourceInformation
    ///    element in future messages that refer to this message.
    ///    • The Resource is identified by a combination of one or more of ResourceID,
    ///    Name and/or ResourceTypeStructure.
    /// </summary>
    private string resourceInfoElementID;

    /// <summary>
    /// ResponseInformationType Object
    /// </summary>
    private ResponseInformationType responseInformation;

    /// <summary>
    /// Resource Object
    /// </summary>
    private ResourceType resource;
    
    /// <summary>
    /// AssignmentInformation Object
    /// </summary>
    private AssignmentInformationType assignmentInformation;
    
    /// <summary>
    /// ScheduleInformation Object
    /// </summary>
    private List<ScheduleInformationType> scheduleInformation;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResourceInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ResourceInformationType()
    {
      this.scheduleInformation = new List<ScheduleInformationType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// This element identifies the instance of ResourceInformation within the message. It
    /// does not identify the Resource.
    /// </summary>
    public string ResourceInfoElementID
    {
      get { return this.resourceInfoElementID; }
      set { this.resourceInfoElementID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// ResponseInformationType Object
    /// </summary>
    public ResponseInformationType ResponseInformation
    {
      get { return this.responseInformation; }
      set { this.responseInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Resource Object
    /// </summary>
    public ResourceType Resource
    {
      get { return this.resource; }
      set { this.resource = value; }
    }

    /// <summary>
    /// Gets or sets
    /// AssignmentInformationType Object
    /// </summary>
    public AssignmentInformationType AssignmentInformation
    {
      get { return this.assignmentInformation; }
      set { this.assignmentInformation = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// ScheduleInformationType Object
    /// </summary>
    public List<ScheduleInformationType> ScheduleInformation
    {
      get { return this.scheduleInformation; }
      set { this.scheduleInformation = value; }
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
      if (this.resource != null)
      {
        this.resource.ToGeoRSS(myitem, contentstr);
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "ResourceInformation", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.resourceInfoElementID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "ResourceInfoElementID", EDXLConstants.RM10MsgNamespace, this.resourceInfoElementID);
      }

      if (this.responseInformation != null)
      {
        this.responseInformation.WriteToXML(xwriter);
      }

      if (this.resource != null)
      {
        this.resource.WriteToXML(xwriter, messageContent);
      }

      if (this.assignmentInformation != null)
      {
        if (this.responseInformation == null)
        {
          this.assignmentInformation.WriteToXML(xwriter, messageContent);
        }
        else
        {
          this.assignmentInformation.WriteToXML(xwriter, messageContent, this.ResponseInformation.ResponseType);
        }
      }

      if (this.scheduleInformation.Count != 0)
      {
        foreach (ScheduleInformationType si in this.scheduleInformation)
        {
          xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "ScheduleInformation", EDXLConstants.RM10MsgNamespace);
          si.WriteToXML(xwriter, messageContent);
          xwriter.WriteEndElement();
        }
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
      ScheduleInformationType scheduleInformationTmp;

      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ResourceInfoElementID":
            this.resourceInfoElementID = node.InnerText;
            break;
          case "ResponseInformation":
            this.responseInformation = new ResponseInformationType();
            this.responseInformation.ReadXML(node);
            break;
          case "Resource":
            this.resource = new ResourceType();
            this.resource.ReadXML(node, messageContent);
            break;
          case "AssignmentInformation":
            this.assignmentInformation = new AssignmentInformationType();
            if (this.ResponseInformation != null)
            {
              this.assignmentInformation.ReadXML(node, messageContent, this.responseInformation.ResponseType);
            }
            else
              this.assignmentInformation.ReadXML(node, messageContent);
            break;
          case "ScheduleInformation":
            if (this.scheduleInformation == null)
            {
              this.scheduleInformation = new List<ScheduleInformationType>();
            }

            scheduleInformationTmp = new ScheduleInformationType();
            scheduleInformationTmp.ReadXML(node, messageContent);
            this.scheduleInformation.Add(scheduleInformationTmp);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ResourceInformationType");
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
      if (string.IsNullOrEmpty(this.resourceInfoElementID))
      {
        throw new ArgumentNullException("ResourceInfoElementID is required and can't be null");
      }

      if (this.responseInformation != null && (messageContent == MessageType.RequestResource || messageContent == MessageType.RequisitionResource || messageContent == MessageType.RequestInformation || messageContent == MessageType.OfferUnsolicitedResource || messageContent == MessageType.RequestReturn || messageContent == MessageType.RequestResourceDeploymentStatus || messageContent == MessageType.RequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("ResponseInformation is not applicable for the MessageContentType: " + messageContent);
      }

      if (this.responseInformation == null && (messageContent == MessageType.ResponseToRequestResource || messageContent == MessageType.CommitResource || messageContent == MessageType.ResponseToRequestReturn || messageContent == MessageType.ResponseToRequestQuote || messageContent == MessageType.ResponseToRequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("ResponseInformation is required for the MessageContentType: " + messageContent);
      }

      if (this.resource == null && (messageContent == MessageType.RequestResource || messageContent == MessageType.RequisitionResource || messageContent == MessageType.OfferUnsolicitedResource || messageContent == MessageType.ReleaseResource || messageContent == MessageType.RequestReturn || messageContent == MessageType.RequestQuote || messageContent == MessageType.RequestResourceDeploymentStatus || messageContent == MessageType.RequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("Resource is required for the MessageContentType: " + messageContent);
      }

      if (this.resource == null && (messageContent == MessageType.CommitResource || messageContent == MessageType.ResponseToRequestQuote || messageContent == MessageType.ResponseToRequestExtendedDeploymentDuration) && (this.responseInformation.ResponseType == ResponseTypeType.Accept || this.responseInformation.ResponseType == ResponseTypeType.Provisional))
      {
        throw new ArgumentNullException("Resource is required for the MessageContentType: " + messageContent + "ResponseType: " + this.responseInformation.ResponseType.ToString());
      }

      if (this.assignmentInformation == null && messageContent == MessageType.RequisitionResource)
      {
        throw new ArgumentNullException("AssignmentInformation is required for the MessageContentType: " + messageContent);
      }

      if (this.assignmentInformation == null && (messageContent == MessageType.CommitResource) && (this.responseInformation.ResponseType == ResponseTypeType.Accept || this.responseInformation.ResponseType == ResponseTypeType.Provisional))
      {
        throw new ArgumentNullException("AssignmentInformation is required for the MessageContentType: " + messageContent + "ResponseType: " + this.responseInformation.ResponseType.ToString());
      }

      if (this.assignmentInformation != null && (messageContent == MessageType.CommitResource) && (this.responseInformation.ResponseType == ResponseTypeType.Decline))
      {
        throw new ArgumentNullException("AssignmentInformation is not applicable for the MessageContentType: " + messageContent + "ResponseType: " + this.responseInformation.ResponseType.ToString());
      }

      if (this.scheduleInformation.Count == 0 && (messageContent == MessageType.CommitResource) && (this.responseInformation.ResponseType == ResponseTypeType.Accept || this.responseInformation.ResponseType == ResponseTypeType.Provisional))
      {
        throw new ArgumentNullException("ScheduleInformation is required for the MessageContentType: " + messageContent + "ResponseType: " + this.responseInformation.ResponseType.ToString());
      }

      if (this.scheduleInformation.Count > 0 && (messageContent == MessageType.CommitResource) && (this.responseInformation.ResponseType == ResponseTypeType.Decline))
      {
        throw new ArgumentNullException("ScheduleInformation is not applicable for the MessageContentType: " + messageContent + "ResponseType: " + this.responseInformation.ResponseType.ToString());
      }
    }
    #endregion
  }
}
