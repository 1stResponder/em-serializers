// ———————————————————————–
// <copyright file="AssignmentInformationType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the AssignmentInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class AssignmentInformationType 
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Description of amount of resource needed in both quantity and units of measure (if
    ///    applicable).
    ///  Comments 
    ///    • This element carries quantity information expressed in one of two ways:
    ///      o informally, as one or more lines of text (the QuantityText element); or
    ///      o formally, as an element (the MeasuredQuantity element) containing
    ///      an amount (required) and a unit of measure (optional).
    ///      The unit of measure is expressed, in turn, as a uniform resource name
    ///      (ListURI) identifying a managed code list of units of measure, paired
    ///      with a code from that list (identifying a particular unit of measure).
    ///      The use of the first alternative (the QuantityText element) is not recommended
    ///      when the second alternative (the MeasuredQuantity element) can be used. For
    ///      example, in a RequestResource message requesting 10000 liters of water, the
    ///      second alternative (the MeasuredQuantity element) is the preferred one.
    ///      A Community of Interest can either use an existing managed code list of units
    ///      of measure, or define its own code list and use it.
    ///      One possibility is to use one of the two lists specified in the Unified Code for
    ///      Units of Measure [UCUM]: case-sensitive codes (“c/s”) and case-insensitive
    ///      codes (“c/i”). It is recommended that the two following URNs be used within
    ///      EDXL-RM messages to identify those two code lists (respectively):
    ///      EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///      Copyright © OASIS® 1993–2008 Page 118 of 174
    ///  Constraints 
    ///    • Value MUST be non-negative.
    ///    • Conditional Usage:
    ///      o Required
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestResource” and
    ///        ResponseInformation:responseType = “Accept”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestResource” and
    ///        ResponseInformation:responseType = “Conditional”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequisitionResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “CommitResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ReleaseResource”
    ///      o Optional, otherwise.
    /// </summary>
    private QuantityType quantity;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    Description of a condition governing the availability of resources. E.g. condition for
    ///    number of beds available may be "if patients have insurance". This may be thought of
    ///    as a term/condition or a restriction on availability.
    /// </summary>
    private string restrictions;

    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    Anticipated function, task, job, or role to be provided by the requested resource.
    /// </summary>
    private string anticipatedFunction;

    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once
    ///  Definition 
    ///    Description of quoted cost to acquire desired resource including currency, if the
    ///    distinction is appropriate.
    ///  Comments 
    ///    • This element carries price information expressed in one of two ways:
    ///      o informally, as one or more lines of text (element QuantityText); or
    ///      o formally, as an element (element MeasuredQuantity) containing an
    ///      amount (required) and a unit of measure (optional).
    ///      The unit of measure is expressed, in turn, as a uniform resource name
    ///      (ListURI) identifying a managed code list of units of measure, paired
    ///      with a code from that list (identifying a particular unit of measure–usually a
    ///      currency).
    ///      The use of the first alternative (the QuantityText element) is not recommended
    ///      when the second alternative (the MeasuredQuantity element) can be used.
    ///      A Community of Interest can either use an existing managed code list of units
    ///      of measure, or define its own code list and use it.
    ///      Usually, the unit of measure is a currency and the code list consists of the
    ///      alphabetic currency codes specified in [ISO 4217] and summarized in [ISO
    ///      4217 codes]. It is recommended that the following URN be used within EDXLRM
    ///      messages to identify the alphabetic currency code list specified in [ISO
    ///      4217]:
    ///    • Completed in response to a “RequestQuote”
    ///    • Conditional Usage:
    ///      o Required
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “ResponseToRequestQuote”
    ///        􀂃 May be indeterminate, i.e. “current market val.”
    ///      o Not Applicable
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestResource”
    ///        􀂃 EDXLResourceMessage:messageContentType =
    ///        “RequestQuote”
    ///      o Optional, otherwise
    /// </summary>
    private QuantityType priceQuote;

    /// <summary>
    /// Reference to the external system number or ID assigned by the ordering system or
    /// personnel meeting the request for resources that has been made.
    /// </summary>
    private string orderID;

    /// <summary>
    /// specifying ModeOfTransportation, NavigationInstructions and ReportingInstructions
    /// </summary>
    private AssignmentInstructionsType assignmentInstructions;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the AssignmentInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public AssignmentInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Description of amount of resource needed in both quantity and units of measure (if
    /// applicable).
    /// </summary>
    public QuantityType Quantity
    {
      get { return this.quantity; }
      set { this.quantity = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Description of a condition governing the availability of resources. E.g. condition for
    /// number of beds available may be "if patients have insurance". This may be thought of
    /// as a term/condition or a restriction on availability.
    /// </summary>
    public string Restrictions
    {
      get { return this.restrictions; }
      set { this.restrictions = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Anticipated function, task, job, or role to be provided by the requested resource
    /// </summary>
    public string AnticipatedFunction
    {
      get { return this.anticipatedFunction; }
      set { this.anticipatedFunction = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Description of quoted cost to acquire desired resource including currency, if the
    /// distinction is appropriate
    /// </summary>
    public QuantityType PriceQuote
    {
      get { return this.priceQuote; }
      set { this.priceQuote = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Reference to the external system number or ID assigned by the ordering system or
    /// personnel meeting the request for resources that has been made.
    /// </summary>
    public string OrderID
    {
      get { return this.orderID; }
      set { this.orderID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// specifying ModeOfTransportation, NavigationInstructions and ReportingInstructions
    /// </summary>
    public AssignmentInstructionsType AssignmentInstructions
    {
      get { return this.assignmentInstructions; }
      set { this.assignmentInstructions = value; }
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
      this.Validate(messageContent, null);
      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "AssignmentInformation", EDXLConstants.RM10MsgNamespace);
      if (this.quantity != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "Quantity", EDXLConstants.RM10MsgNamespace);
        this.quantity.WriteToXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.restrictions))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Restrictions", EDXLConstants.RM10MsgNamespace, this.restrictions);
      }

      if (!string.IsNullOrEmpty(this.anticipatedFunction))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "AnticipatedFunction", EDXLConstants.RM10MsgNamespace, this.anticipatedFunction);
      }

      if (this.priceQuote != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "PriceQuote", EDXLConstants.RM10MsgNamespace);
        this.priceQuote.WriteToXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.orderID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "OrderID", EDXLConstants.RM10MsgNamespace, this.orderID);
      }

      if (this.assignmentInstructions != null)
      {
        this.assignmentInstructions.WriteToXML(xwriter, messageContent);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="messageContent">Pointer to messageContent which represents the resource type of Resource Message sent</param>
    /// <param name="responseType">Pointer to responseType represents the response type of Resource Message sent</param>
    internal void WriteToXML(XmlWriter xwriter, MessageType? messageContent, ResponseTypeType? responseType)
    {
      this.Validate(messageContent, responseType);
      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "AssignmentInformation", EDXLConstants.RM10MsgNamespace);
      if (this.quantity != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "Quantity", EDXLConstants.RM10MsgNamespace);
        this.quantity.WriteToXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.restrictions))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "Restrictions", EDXLConstants.RM10MsgNamespace, this.restrictions);
      }

      if (!string.IsNullOrEmpty(this.anticipatedFunction))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "AnticipatedFunction", EDXLConstants.RM10MsgNamespace, this.anticipatedFunction);
      }

      if (this.priceQuote != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "PriceQuote", EDXLConstants.RM10MsgNamespace);
        this.priceQuote.WriteToXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.orderID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "OrderID", EDXLConstants.RM10MsgNamespace, this.orderID);
      }

      if (this.assignmentInstructions != null)
      {
        this.assignmentInstructions.WriteToXML(xwriter, messageContent);
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
          case "Quantity":
            this.quantity = new QuantityType();
            this.quantity.ReadXML(node);
            break;
          case "Restrictions":
            this.restrictions = node.InnerText;
            break;
          case "AnticipatedFunction":
            this.anticipatedFunction = node.InnerText;
            break;
          case "PriceQuote":
            this.priceQuote = new QuantityType();
            this.priceQuote.ReadXML(node);
            break;
          case "OrderID":
            this.orderID = node.InnerText;
            break;
          case "AssignmentInstructions":
            this.assignmentInstructions = new AssignmentInstructionsType();
            this.assignmentInstructions.ReadXML(node, messageContent);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in AssignmentInformationType");
        }
      }

      this.Validate(messageContent, null);
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
    /// <param name="messageContent">MessageType of this RM Message</param>
    /// <param name="responseType">The Response Type of this RM Message</param>
    internal void ReadXML(XmlNode rootNode, MessageType? messageContent, ResponseTypeType? responseType)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Quantity":
            this.quantity = new QuantityType();
            this.quantity.ReadXML(node);
            break;
          case "Restrictions":
            this.restrictions = node.InnerText;
            break;
          case "AnticipatedFunction":
            this.anticipatedFunction = node.InnerText;
            break;
          case "PriceQuote":
            this.priceQuote = new QuantityType();
            this.priceQuote.ReadXML(node);
            break;
          case "OrderID":
            this.orderID = node.InnerText;
            break;
          case "AssignmentInstructions":
            this.assignmentInstructions = new AssignmentInstructionsType();
            this.assignmentInstructions.ReadXML(node, messageContent);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in AssignmentInformationType");
        }
      }

      this.Validate(messageContent, responseType);
    }

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    /// <param name="messageContent">Pointer to messageContent which represents the resource type of Resource Message sent</param>
    /// <param name="responseType">Pointer to responseType represents the response type of Resource Message sent</param>
    private void Validate(MessageType? messageContent, ResponseTypeType? responseType)
    {
      if (this.quantity != null && this.quantity.Amount < 0)
      {
        throw new ArgumentNullException("Quantity value must be non-negative");
      }

      if ((messageContent == MessageType.RequisitionResource || messageContent == MessageType.CommitResource || messageContent == MessageType.ReleaseResource) && this.quantity == null)
      { 
        throw new ArgumentNullException("Quantity is required under restraints MessageContent: " + messageContent); 
      }

      if (this.quantity == null && (responseType == ResponseTypeType.Accept || responseType == ResponseTypeType.Provisional) && messageContent == MessageType.ResponseToRequestResource)
      {
        throw new ArgumentNullException("Quantity is required under restraints MessageContent: " + messageContent + "and ResponseType: " + responseType);
      }

      if ((messageContent == MessageType.ResponseToRequestQuote) && this.priceQuote == null)
      {
        throw new ArgumentNullException("PriceQuote is required under restraints MessageContent: " + messageContent);
      }

      if (this.priceQuote != null && (messageContent == MessageType.RequestResource && messageContent == MessageType.RequestQuote))
      {
        throw new ArgumentNullException("PriceQuote is not applicable under restraints MessageContent: " + messageContent);
      }

      if (!string.IsNullOrEmpty(this.orderID) && (messageContent == MessageType.RequestResource || messageContent == MessageType.ResponseToRequestResource || messageContent == MessageType.RequisitionResource || messageContent == MessageType.OfferUnsolicitedResource || messageContent == MessageType.RequestQuote || messageContent == MessageType.ResponseToRequestQuote))
      {
        throw new ArgumentNullException("OrderID is not applicable under restraints MessageContent: " + messageContent);
      }

      if (this.assignmentInstructions != null && (messageContent == MessageType.RequestResource || messageContent == MessageType.RequestExtendedDeploymentDuration))
      {
        throw new ArgumentNullException("AssignmentInstructions is not applicable under restraints MessageContent: " + messageContent);
      }
    }
    #endregion
  }
}
