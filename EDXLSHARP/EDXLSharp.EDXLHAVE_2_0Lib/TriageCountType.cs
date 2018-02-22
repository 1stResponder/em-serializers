// ———————————————————————–
// <copyright file="TriageCountType.cs" company="EDXLSharp">
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
using System.ComponentModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the TriageCount sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class TriageCountType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// CONDITIONAL 
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced. The list identifies the triage codes used by the particular community. 
    /// 1. Hospital element MAY contain a TriageCodeListURN element as specified in the schema, but MUST NOT contain more than one such element.
    /// 2. If a TriageCodeListURN> element is present within a Hospital element, it MUST precede the first TriageCode element within that Hospital element.
    /// 3. If a TriageCodeListURN> element is present within a Hospital element and is not empty, then the values of all the TriageCodeValue elements within that Hospital element MUST be interpreted according to the URN in the TriageCodeListURN element.
    /// </summary>
    private Uri triageCodeListURN;

    /// <summary>
    /// OPTIONAL, May use Multiple
    /// The container element to specify the triage values and their quantity. 
    /// 1. Multiple instances of the TriageCodeValue MAY occur with a single TriageCodeListURN
    /// 2. Each TriageCodeValue and its associated TriageCountQuantity MUST be enclosed in TriageCode
    /// </summary>
    private List<TriageCodeType> triageCode;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TriageCountType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public TriageCountType()
    {
      this.triageCode = new List<TriageCodeType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// CONDITIONAL 
    /// The list identifies the triage codes used by the particular community. 
    /// </summary>
    [XmlIgnore]
    public Uri TriageCodeListURN
    {
        get { return this.triageCodeListURN; }
        set { this.triageCodeListURN = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable string of the triageCodeListURN URI
    /// </summary>
    [XmlAttribute("triageCodeListURN")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string TriageCodeListURNString
    {
        get { return this.triageCodeListURN == null ? null : this.triageCodeListURN.ToString(); }
        set { this.triageCodeListURN = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL, May use Multiple
    /// The container element to specify the triage values and their quantity. 
    /// 1. Multiple instances of the TriageCodeValue MAY occur with a single TriageCodeListURN
    /// 2. Each TriageCodeValue and its associated TriageCountQuantity MUST be enclosed in TriageCode
    /// </summary>
    public List<TriageCodeType> TriageCode
    {
      get { return this.triageCode; }
      set { this.triageCode = value; }
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

      if (this.triageCodeListURN != null)
      {
        xwriter.WriteElementString("TriageCodeListURN", this.triageCodeListURN.ToString());
      }
      
      xwriter.WriteStartElement("TriageCode");
      foreach (TriageCodeType triagecodetypetmp in this.triageCode)
      {
        triagecodetypetmp.WriteXML(xwriter);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      TriageCodeType triagecodetypetmp;
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "TriageCodeListURN":
            this.triageCodeListURN = new Uri(node.InnerText);
            break;
          case "TriageCode":
            if (this.triageCode == null)
            {
              this.triageCode = new List<TriageCodeType>();
            }
            
            triagecodetypetmp = new TriageCodeType();
            triagecodetypetmp.ReadXML(node);
            this.triageCode.Add(triagecodetypetmp);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in TriageCountType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    /// <summary>
    /// Fills IGeoRSS Object With Syndication Content
    /// </summary>
    /// <param name="myitem">Syndication Item Object To Fill</param>
    /// <param name="contentstr">Constructed String of the Content of the Syndication Item</param>
    internal void ToGeoRSS(SyndicationItem myitem, StringBuilder contentstr)
    {
      foreach (TriageCodeType triage in this.triageCode)
      {
        triage.ToGeoRSS(myitem, contentstr);
      }
    }
    #endregion
  }
}
