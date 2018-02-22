// ———————————————————————–
// <copyright file="GML.cs" company="EDXLSharp">
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
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// Abstract Base Class Defining Internal Interfaces for GML Objects
  /// </summary>
  [Serializable]
  public abstract partial class GML
  {
    #region Private Member Variables

    /// <summary>
    /// Database handle for the object.  It is of XML type ID, so is constrained to be unique in the XML document within which it occurs.  An external identifier for the object in the form of a URI may be constructed using standard XML and XPointer methods.  This is done by concatenating the URI for the document, a fragment separator, and the val of the id attribute.  
    /// </summary>
    private string id;

    /// <summary>
    /// In general this reference points to a CRS instance
    /// </summary>
    [XmlIgnore]
    private Uri srsName;

    /// <summary>
    /// The Spatial Reference System Dimension is the length of coordinate sequence 
    /// </summary>
    private uint? srsDimension;

    /// <summary>
    /// Ordered list of labels for all the axes of this CRS.
    /// </summary>
    private List<NCName> axisLabels;

    /// <summary>
    /// Ordered list of unit of measure labels for all the axes of this CRS.
    /// </summary>
    private List<NCName> uomLabels;

    /// <summary>
    /// The namespace for the GML Object.
    /// </summary>
    private string gmlNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GML class.
    /// Base Class Default Constructor
    /// </summary>
    public GML() : this(EDXLConstants.GMLNamespace)
    {
    }

    // TODO: GeoOASISWhereLib GML add capability to identify own namespace throughout the code

    /// <summary>
    /// Initializes a new instance of the GML class
    /// </summary>
    /// <param name="gmlNamespace">The namespace to use</param>
    public GML(string gmlNamespace)
    {
      this.gmlNamespace = gmlNamespace;
      this.axisLabels = new List<NCName>();
      this.uomLabels = new List<NCName>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Ordered list of unit of measure labels for all the axes of this CRS.
    /// </summary>
    public List<NCName> UomLabels
    {
      get { return this.uomLabels; }
      set { this.uomLabels = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Ordered list of labels for all the axes of this CRS.
    /// </summary>
    public List<NCName> AxisLabels
    {
      get { return this.axisLabels; }
      set { this.axisLabels = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Spatial Reference System Dimension is the length of coordinate sequence (the number of entries in the list).
    /// </summary>
    public uint? SrsDimension
    {
      get { return this.srsDimension; }
      set { this.srsDimension = value; }
    }

    /// <summary>
    /// Gets or sets
    /// In general this reference points to a CRS instance
    /// </summary>
    [XmlIgnore]
    public Uri SrsName
    {
      get { return this.srsName; }
      set { this.srsName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable string version of the Spatial Reference System Name URI
    /// </summary>
    [XmlAttribute("srsName")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string SrsString
    {
      get { return this.srsName == null ? null : this.srsName.ToString(); }
      set { this.srsName = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// Database handle for the object.  It is of XML type ID, so is constrained to be unique in the XML document within which it occurs.  An external identifier for the object in the form of a URI may be constructed using standard XML and XPointer methods.  This is done by concatenating the URI for the document, a fragment separator, and the val of the id attribute.  
    /// </summary>
    public string ID
    {
      get { return this.id; }
      set { this.id = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Public Function to Write This GML Object Standalone
    /// </summary>
    /// <param name="xwriter">XMLWriter to Write this Object</param>
    public void WriteXMLForPublicUse(XmlWriter xwriter)
    {
      this.WriteXML(xwriter);
    }

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    public abstract void WriteXML(XmlWriter xwriter);

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object Element</param>
    public abstract void ReadXML(XmlNode rootnode);

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected abstract void Validate();

    /// <summary>
    /// Writes Base Class Attributes to a GML XML Document
    /// </summary>
    /// <param name="xwriter">XML Writer </param>
    protected void ToXMLStringBase(XmlWriter xwriter)
    {
      StringBuilder constructstring = new StringBuilder();
      if (this.uomLabels.Count != 0)
      {
        foreach (NCName name in this.uomLabels)
        {
          constructstring.Append(name.ToString());
          constructstring.Append(' ');
        }

        xwriter.WriteAttributeString("uomLabels", constructstring.ToString());
        constructstring = new StringBuilder();
      }

      if (this.axisLabels.Count != 0)
      {
        foreach (NCName name in this.axisLabels)
        {
          constructstring.Append(name.ToString());
          constructstring.Append(' ');
        }

        xwriter.WriteAttributeString("axisLabels", constructstring.ToString());
      }

      if (this.srsDimension != null)
      {
        xwriter.WriteAttributeString("srsDimension", this.srsDimension.ToString());
      }

      if (this.srsName != null)
      {
        xwriter.WriteAttributeString("srsName", this.srsName.ToString());
      }

      if (this.id != null && this.id != string.Empty)
      {
        xwriter.WriteAttributeString("id", this.gmlNamespace, this.id);
      }
    }

    /// <summary>
    /// Reads Base Object Attributes from a GML Object
    /// </summary>
    /// <param name="rootnode">Root node of this sub element</param>
    protected void ReadXMLBase(XmlNode rootnode)
    {
      XmlAttributeCollection attribs = rootnode.Attributes;
      string temp;
      char[] separators = { ' ' };
      string[] values;
      foreach (XmlAttribute attrib in attribs)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "uomLabels":
            temp = attrib.InnerText;
            values = temp.Split(separators);
            this.uomLabels = new List<NCName>();
            foreach (string value in values)
            {
              this.uomLabels.Add(new NCName(value));
            }

            break;
          case "axisLabels":
            temp = attrib.InnerText;
            values = temp.Split(separators);
            this.axisLabels = new List<NCName>();
            foreach (string value in values)
            {
              this.axisLabels.Add(new NCName(value));
            }

            break;
          case "id":
            this.id = attrib.InnerText;
            break;
          case "srsName":
            this.srsName = new Uri(attrib.InnerText);
            break;
          case "srsDimension":
            this.srsDimension = uint.Parse(attrib.InnerText);
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected GML Attribute: " + attrib.Name);
            }

            break;
        }
      }
    }

    #endregion
  }
}
