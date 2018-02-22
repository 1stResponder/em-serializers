// ———————————————————————–
// <copyright file="MessageRecallType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the MessageRecallType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class MessageRecallType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once.
    ///  Definition 
    ///    The identifier of the previously sent message that is to be recalled. MessageRecall is
    ///    used to replace a previously sent message by updating or canceling it.
    ///  Comments 
    ///    • The MessageRecall element is Optional.
    /// </summary>
    private string recallMessageID;
    
    /// <summary>
    /// Usage 
    ///    REQUIRED, MUST be used once and only once.
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 106 of 174
    ///  Definition 
    ///    Specifies the recall type as either an update or a cancel of the previously sent
    ///    message. MessageRecall is used to replace a previously sent message which is then
    ///    updated or cancelled.
    ///  Constraints 
    ///    􀂃 Value MUST be one of the following:
    ///      1. Update
    ///      2. Cancel
    ///  Comments 
    ///    • The MessageRecall element is Optional.
    /// </summary>
    private RecallTypeType? recallType;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the MessageRecallType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public MessageRecallType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The identifier of the previously sent message that is to be recalled. MessageRecall is
    /// used to replace a previously sent message by updating or canceling it.
    /// </summary>
    public string RecallMessageID
    {
      get { return this.recallMessageID; }
      set { this.recallMessageID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Specifies the recall type as either an update or a cancel of the previously sent
    /// message. MessageRecall is used to replace a previously sent message which is then
    /// updated or cancelled.
    /// </summary>
    public RecallTypeType? RecallType
    {
      get { return this.recallType; }
      set { this.recallType = value; }
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "MessageRecall", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.recallMessageID))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "RecallMessageID", EDXLSharp.EDXLConstants.RM10Namespace, this.recallMessageID);
      }

      if (this.recallType != null)
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "RecallType", EDXLSharp.EDXLConstants.RM10Namespace, this.recallType.ToString());
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
          case "RecallMessageID":
            this.recallMessageID = node.InnerText;
            break;
          case "RecallType":
            this.recallType = (RecallTypeType)Enum.Parse(typeof(RecallTypeType), node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in MessageRecallType");
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
      if (string.IsNullOrEmpty(this.recallMessageID))
      {
        throw new ArgumentNullException("RecallMessageID is required and can't be null");
      }

      if (this.recallType == null)
      {
        throw new ArgumentNullException("RecallType is required and can't be null");
      }
    }
    #endregion
  }
}
