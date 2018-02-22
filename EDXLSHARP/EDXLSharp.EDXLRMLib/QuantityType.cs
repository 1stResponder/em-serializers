// ———————————————————————–
// <copyright file="QuantityType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the QuantityType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class QuantityType
  {
    #region Private Member Variables
    /// <summary>
    /// Text based representation of Description of amount of resource needed
    /// </summary>
    private List<string> quantityText;

    /// <summary>
    /// Formal Description of amount of resource needed by defining the amount required
    /// </summary>
    private double? amount;

    /// <summary>
    /// Formal Description of amount of resource needed by defining an optional units of measure
    /// </summary>
    private EDXLSharp.ValueList unitOfMeasure;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the QuantityType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public QuantityType()
    {
      this.quantityText = new List<string>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Text based representation of Description of amount of resource needed
    /// </summary>
    public List<string> QuantityText
    {
      get { return this.quantityText; }
      set { this.quantityText = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Formal Description of amount of resource needed by defining the amount required
    /// </summary>
    public double? Amount
    {
      get { return this.amount; }
      set { this.amount = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Formal Description of amount of resource needed by defining an optional units of measure
    /// </summary>
    public EDXLSharp.ValueList UnitOfMeasure
    {
      get { return this.unitOfMeasure; }
      set { this.unitOfMeasure = value; }
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

      if (this.quantityText.Count != 0)
      {
        foreach (string qt in this.quantityText)
        {
          xwriter.WriteElementString(EDXLConstants.RM10Prefix, "QuantityText", EDXLConstants.RM10Namespace, qt);
        }
      }

      if (this.amount != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "MeasuredQuantity", EDXLConstants.RM10Namespace);
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "Amount", EDXLConstants.RM10Namespace, this.amount.ToString());
        if (this.unitOfMeasure != null)
        {
          xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "UnitOfMeasure", EDXLConstants.RM10Namespace);
          this.unitOfMeasure.WriteXML(EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace, xwriter);
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
    internal void ReadXML(XmlNode rootNode)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        string tmpQuantityText;

        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "QuantityText":
            if (this.quantityText == null)
            {
              this.quantityText = new List<string>();
            }

            tmpQuantityText = node.InnerText;
            this.quantityText.Add(tmpQuantityText);
            break;
          case "MeasuredQuantity":
            foreach (XmlNode subnode in node.ChildNodes)
            {
              switch (subnode.LocalName)
              {
                case "Amount":
                  this.amount = double.Parse(subnode.InnerText);
                  break;
                case "UnitOfMeasure":
                  this.unitOfMeasure = new EDXLSharp.ValueList();
                  this.unitOfMeasure.ReadXML(subnode);
                  break;
                default:
                  throw new ArgumentException("Unexpected subnode name: " + subnode.Name + " in QuantityType");
              }
            }

            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in QuantityType");
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
      if (this.quantityText.Count == 0 && this.amount == null)
      {
        throw new ArgumentNullException("You must use Quantity Text OR Measured Quantity.");
      }
      else if (this.quantityText.Count > 0 && this.amount != null)
      {
        throw new ArgumentException("You must use either Quantity Text OR Measured Quantity...Not Both!");
      }
    }
    #endregion
  }
}
