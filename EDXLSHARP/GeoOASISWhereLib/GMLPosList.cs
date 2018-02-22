// ———————————————————————–
// <copyright file="GMLPosList.cs" company="EDXLSharp">
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
  /// Container Object for a List of positions
  /// </summary>
  [Serializable]
  public partial class GMLPosList : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// In general this reference points to a CRS instance
    /// </summary>
    [XmlIgnore]
    private Uri srsNameURI;

    /// <summary>
    /// The "srsDimension" is the length of coordinate sequence (the number of entries in the list). This dimension is specified by the coordinate reference system. When the srsName attribute is omitted, this attribute shall be omitted
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
    /// List of positions
    /// </summary>
    private List<double> posList;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLPosList class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public GMLPosList()
    {
      this.axisLabels = new List<NCName>();
      this.uomLabels = new List<NCName>();
      this.posList = new List<double>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// The Serializable string version of the srsNameURI URI
    /// </summary>
    [XmlAttribute("srsName2")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string SrsNameString
    {
      get { return this.srsNameURI == null ? null : this.srsNameURI.ToString(); }
      set { this.srsNameURI = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// List of positions
    /// </summary>
    public List<double> PosList
    {
      get { return this.posList; }
      set { this.posList = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Ordered list of unit of measure labels for all the axes of this CRS.
    /// </summary>
    public new List<NCName> UomLabels
    {
      get { return this.uomLabels; }
      set { this.uomLabels = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Ordered list of labels for all the axes of this CRS.
    /// </summary>
    public new List<NCName> AxisLabels
    {
      get { return this.axisLabels; }
      set { this.axisLabels = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The "srsDimension" is the length of coordinate sequence (the number of entries in the list). This dimension is specified by the coordinate reference system. When the srsName attribute is omitted, this attribute shall be omitted
    /// </summary>
    public new uint? SrsDimension
    {
      get { return this.srsDimension; }
      set { this.srsDimension = value; }
    }

    /// <summary>
    /// Gets or sets
    /// In general this reference points to a CRS instance
    /// </summary>
    [XmlIgnore]
    public new Uri SrsName
    {
      get { return this.srsNameURI; }
      set { this.srsNameURI = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Adds positions To This Position List
    /// </summary>
    /// <param name="positions">Double Precision positions</param>
    public void AddPositions(double[] positions)
    {
      foreach (double d in positions)
      {
        this.posList.Add(d);
      }
    }

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      XmlAttributeCollection attribs = rootnode.Attributes;
      string temp;
      char[] separators = { ' ' };
      string[] values;
      int counttmp;
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
          case "count":
            counttmp = int.Parse(attrib.InnerText);
            break;
          case "srsName":
            this.srsNameURI = new Uri(attrib.InnerText);
            break;
          case "srsDimension":
            this.srsDimension = uint.Parse(attrib.InnerText);
            break;
          case "#comment":
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected GML Attribute: " + attrib.Name + " in GMLPosList");
            }

            break;
        }
      }

      if (rootnode.LocalName == "posList")
      {
        temp = rootnode.InnerText;
        values = temp.Split(separators);
        this.posList = new List<double>();
        foreach (string value in values)
        {
          this.posList.Add(double.Parse(value));
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in GMLPosList");
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "posList", EDXLConstants.GMLNamespace);

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
        constructstring = new StringBuilder();
      }

      if (this.srsDimension != null)
      {
        xwriter.WriteAttributeString("srsDimension", this.srsDimension.ToString());
      }

      if (this.srsNameURI != null)
      {
        xwriter.WriteAttributeString("srsName", this.srsNameURI.ToString());
      }

      if (this.posList.Count != 0)
      {
        foreach (double d in this.posList)
        {
          constructstring.Append(d.ToString());
          constructstring.Append(' ');
        }

        xwriter.WriteString(constructstring.ToString().Trim());
        constructstring = null;
      }

      xwriter.WriteEndElement();
    }

    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
