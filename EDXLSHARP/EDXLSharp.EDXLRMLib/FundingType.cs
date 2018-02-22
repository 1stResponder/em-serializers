// ———————————————————————–
// <copyright file="FundingType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the FundingType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class FundingType
  {
    #region Private Member Variables
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    Identifies the funds that will pay for the resource
    ///  Constraints 
    ///    • The Funding element MUST be present in a Requisition Resource message.
    ///    • If a Funding element is present, then at least one of Funding:FundCode or
    ///    Funding:FundingInfo MUST be present
    ///  Comments 
    ///    • Identified in support of NIMS Resource Management Guide NIC-GDL0004
    ///    • This field may be used as a comma separated list of fund codes (e.g.
    ///    “HP4347,RT45S”
    /// </summary>
    private string fundingCodeType;
    
    /// <summary>
    /// Usage 
    ///    CONDITIONAL, MAY be used once and only once.
    ///  Definition 
    ///    Provides additional information on the funds that will pay for the resource
    ///  Constraints 
    ///    • A textual description of funding sources or distribution
    ///    • The Funding element MUST be present in a Requisition Resource message.
    ///    EDXL-RM 1.0 Public Review Draft 02 31 January 2008
    ///    Copyright © OASIS® 1993–2008 Page 107 of 174
    ///    • If a Funding element is present, then at least one of Funding:FundCode or
    ///    Funding:FundingInfo MUST be present
    /// </summary>
    private string fundingInfoType;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the FundingType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public FundingType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Identifies the funds that will pay for the resource
    /// </summary>
    public string FundingCodeType
    {
      get { return this.fundingCodeType; }
      set { this.fundingCodeType = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// Provides additional information on the funds that will pay for the resource
    /// </summary>
    public string FundingInfoType
    {
      get { return this.fundingInfoType; }
      set { this.fundingInfoType = value; }
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

      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "Funding", EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.fundingCodeType))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "FundCode", EDXLSharp.EDXLConstants.RM10Namespace, this.fundingCodeType);
      }

      if (!string.IsNullOrEmpty(this.fundingInfoType))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "FundingInfo", EDXLSharp.EDXLConstants.RM10Namespace, this.fundingInfoType);
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
          case "FundCode":
            this.fundingCodeType = node.InnerText;
            break;
          case "FundingInfo":
            this.fundingInfoType = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in FundingType");
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
      if (string.IsNullOrEmpty(this.fundingCodeType) && string.IsNullOrEmpty(this.fundingInfoType))
      {
        throw new ArgumentNullException("If a Funding element is present, then at least one of Funding:FundCode or Funding:FundingInfo MUST be present");
      }
    }
    #endregion
  }
}
