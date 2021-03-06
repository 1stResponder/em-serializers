﻿// ———————————————————————–
// <copyright file="TriageCodeType.cs" company="EDXLSharp">
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
using System.Xml;

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the TriageCode sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class TriageCodeType : IComposable
  {
    #region Private Member Variables
    // To May use multiple - list is defined in parent type that creates the TriageCodeType subclass. A list of this type
    // generates multiple

    /// <summary>
    /// CONDITIONAL, MAY use multiple
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element. 
    /// 1. The list of values SHOULD be from the list identified in TriageCodeListURN 
    /// 2. If a TriageCodeValue is specified, a TriageCountQuantity element MUST be specified.
    /// Default Code List Values: 
    /// • Red – Number of victims with immediate needs.
    /// • Yellow - Number of victims with delayed needs
    /// • Green - Number of victims with minor needs
    /// • Black - Number of deceased victims
    /// </summary>
    private List<TriageCodeValueType> triageCodeValue;

    /// <summary>
    /// CONDITIONAL, MAY use multiple
    /// The integer val associated with the Triage Code val.  
    /// 1. If a TriageCodeValue is specified, a TriageCountQuantity element MUST be specified.
    /// </summary>
    private List<int> triageCountQuantity;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TriageCodeType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public TriageCodeType()
    {
      this.triageCodeValue = new List<TriageCodeValueType>();
      this.triageCountQuantity = new List<int>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// CONDITIONAL, MAY use multiple
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element. 
    /// 1. The list of values SHOULD be from the list identified in TriageCodeListURN 
    /// 2. If a TriageCodeValue is specified, a TriageCountQuantity element MUST be specified.
    /// Default Code List Values: 
    /// • Red – Number of victims with immediate needs.
    /// • Yellow - Number of victims with delayed needs
    /// • Green - Number of victims with minor needs
    /// • Black - Number of deceased victims
    /// </summary>
    public List<TriageCodeValueType> TriageCodeValue
    {
      get { return this.triageCodeValue; }
      set { this.triageCodeValue = value; }
    }

    /// <summary>
    /// Gets or sets
    /// CONDITIONAL, MAY use multiple
    /// The integer val associated with the Triage Code val.  
    /// 1. If a TriageCodeValue is specified, a TriageCountQuantity element MUST be specified.
    /// </summary>
    public List<int> TriageCountQuantity
    {
      get { return this.triageCountQuantity; }
      set { this.triageCountQuantity = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      foreach (TriageCodeValueType triagevalue in this.triageCodeValue)
      {
        xwriter.WriteElementString("TriageCodeValue", triagevalue.ToString());
      }

      foreach (int triagequantity in this.triageCountQuantity)
      {
        xwriter.WriteElementString("TriageCountQuantity", triagequantity.ToString());
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "TriageCodeValue":
            this.triageCodeValue.Add((TriageCodeValueType)Enum.Parse(typeof(TriageCodeValueType), node.InnerText));
            break;
          case "TriageCountQuantity":
            this.triageCountQuantity.Add(int.Parse(node.InnerText));
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in TriageCodeType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (this.triageCodeValue == null && this.triageCountQuantity == null)
      {
        throw new ArgumentNullException("TriageCountQuantity must be defined if TriageCodeValue is used");
      }
    }

    #endregion

    #region Protected Member Functions
    #endregion
  }
}
