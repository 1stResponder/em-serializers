// ———————————————————————–
// <copyright file="ResponseInformationType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the ResponseInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ResponseInformationType
  {
    #region Private Member Variables
    /// <summary>
    /// This element identifies the instance of ResourceInformation within the message 
    /// specified in the EDXLResourceMessage:PrecedingMessageID element.
    /// </summary>
    private string precedingResourceInfoElementID;
    
    /// <summary>
    /// Used to accept, decline, or provisionally accept a Request or Unsolicited Offer.
    /// </summary>
    private ResponseTypeType? responseType;
    
    /// <summary>
    /// Code from a managed list that offers an explanation for a declined or provisional
    /// response to a Request or Unsolicited Offer.
    /// </summary>
    private EDXLSharp.ValueList reasonCode;
    
    /// <summary>
    /// Explanation for a declined or provisional response to a Request, Response,
    /// Unsolicited Offer, or a Request Return.
    /// </summary>
    private string responseReason;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResponseInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ResponseInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// This element identifies the instance of ResourceInformation within the message 
    /// specified in the EDXLResourceMessage:PrecedingMessageID element.
    /// </summary>
    public string PrecedingResourceInfoElementID
    {
      get { return this.precedingResourceInfoElementID; }
      set { this.precedingResourceInfoElementID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Used to accept, decline, or provisionally accept a Request or Unsolicited Offer.
    /// </summary>
    public ResponseTypeType? ResponseType
    {
      get { return this.responseType; }
      set { this.responseType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Code from a managed list that offers an explanation for a declined or provisional
    /// response to a Request or Unsolicited Offer.
    /// </summary>
    public EDXLSharp.ValueList ReasonCode
    {
      get { return this.reasonCode; }
      set { this.reasonCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Explanation for a declined or provisional response to a Request, Response,
    /// Unsolicited Offer, or a Request Return.
    /// </summary>
    public string ResponseReason
    {
      get { return this.responseReason; }
      set { this.responseReason = value; }
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "ResponseInformation", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.precedingResourceInfoElementID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "PrecedingResourceInfoElementID", EDXLConstants.RM10Namespace, this.precedingResourceInfoElementID);
      }

      if (this.responseType != null)
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ResponseType", EDXLConstants.RM10Namespace, this.responseType.ToString());
      }

      if (this.reasonCode != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "ReasonCode", EDXLConstants.RM10Namespace);
        this.reasonCode.WriteXML(EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.responseReason))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ResponseReason", EDXLConstants.RM10Namespace, this.responseReason);
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
          case "PrecedingResourceInfoElementID":
            this.precedingResourceInfoElementID = node.InnerText;
            break;
          case "ResponseType":
            this.responseType = (ResponseTypeType)Enum.Parse(typeof(ResponseTypeType), node.InnerText);
            break;
          case "ReasonCode":
            this.reasonCode = new EDXLSharp.ValueList();
            this.reasonCode.ReadXML(node);
            break;
          case "ResponseReason":
            this.responseReason = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ResponseInformationType");
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
      if (string.IsNullOrEmpty(this.precedingResourceInfoElementID))
      {
        throw new ArgumentNullException("PrecedingResourceInfoElementID is required and can't be null");
      }

      if (this.responseType == null)
      {
        throw new ArgumentNullException("ResponseType is required and can't be null");
      }

      if (this.responseType == ResponseTypeType.Provisional && (this.reasonCode == null && this.responseReason == null))
      {
        throw new ArgumentNullException("ReasonCode and ResponseReason cannot both be null if ResponseType is Provisional");
      }
    }
    #endregion
  }
}
