// ———————————————————————–
// <copyright file="GMLCircleByCenterPoint.cs" company="EDXLSharp">
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
using System.ComponentModel;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// A Circle as Defined by it's Center and Radius
  /// </summary>
  [Serializable]
  public partial class GMLCircleByCenterPoint : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// CurveInterpolationType is a list of codes that may be used to identify the interpolation mechanisms specified by an application schema.
    /// </summary>
    private string interpolation;

    /// <summary>
    /// Point Indicating the Center of the Circle
    /// </summary>
    private GMLPos point;

    /// <summary>
    /// Value To Indicate The Radius
    /// </summary>
    private double? radius;

    /// <summary>
    /// String Indicating the Units of Measure
    /// </summary>
    private Uri uom;

    /// <summary>
    /// Number of Arcs
    /// </summary>
    private int? numArc;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLCircleByCenterPoint class
    /// Default Constructor - Sets Fixed Values
    /// </summary>
    public GMLCircleByCenterPoint()
    {
      this.point = new GMLPos();
      this.interpolation = "circularArcCenterPointWithRadius";
      this.numArc = 1;
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// String Indicating the Units of Measure
    /// </summary>
    [XmlIgnore]
    public Uri Uom
    {
      get { return this.uom; }
      set { this.uom = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable string version of the Unit of Measure URI
    /// </summary>
    [XmlAttribute("uom")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string UomString
    {
      get { return this.uom == null ? null : this.uom.ToString(); }
      set { this.uom = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// Value To Indicate The Radius
    /// </summary>
    public double? Radius
    {
      get { return this.radius; }
      set { this.radius = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Point Indicating the Center of the Circle
    /// </summary>
    public GMLPos Point
    {
      get { return this.point; }
      set { this.point = value; }
    }

    /// <summary>
    /// Gets or sets
    /// CurveInterpolationType is a list of codes that may be used to identify the interpolation mechanisms specified by an application schema.
    /// </summary>
    public string Interpolation
    {
      get { return this.interpolation; }
      set { this.interpolation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Number of Arcs
    /// </summary>
    public int? NumArc
    {
      get { return this.numArc; }
      set { this.numArc = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      foreach (XmlAttribute attrib in rootnode.Attributes)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "interpolation":
            this.interpolation = attrib.InnerText;
            break;
          case "numArc":
            this.numArc = int.Parse(attrib.InnerText);
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected attribute " + attrib.Name + " in cirlebycenterpoint");
            }

            break;
        }
      }

      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(rootnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "pos":
          case "gml:pos":
            this.point = new GMLPos();
            this.point.ReadXML(childnode);
            break;
          case "radius":
          case "gml:radius":
            if (childnode.Attributes.Count > 0)
            {
              this.uom = new Uri(childnode.Attributes[0].InnerText);
            }

            this.radius = double.Parse(childnode.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected child node " + childnode.Name + " in cirlebycenterpoint");
        }
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "CircleByCenterPoint", EDXLConstants.GMLNamespace);
      xwriter.WriteAttributeString("interpolation", this.interpolation);
      xwriter.WriteAttributeString("numArc", this.numArc.ToString());
      this.point.WriteXML(xwriter);
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "radius", EDXLConstants.GMLNamespace);
      if (this.uom != null)
      {
        xwriter.WriteAttributeString("uom", this.uom.ToString());
      }
      else
      {
        xwriter.WriteAttributeString("uom", EDXLConstants.UomUri);
      }

      xwriter.WriteString(this.radius.ToString());
      xwriter.WriteEndElement();
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    internal void ToGeoRSS(SyndicationItem myitem)
    {
      StringBuilder output = new StringBuilder();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      xsettings.OmitXmlDeclaration = true;
      XmlWriter xwriter = XmlWriter.Create(output, xsettings);
      this.WriteXML(xwriter);
      xwriter.Flush();
      xwriter.Close();
      MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
      myitem.ElementExtensions.Add(XmlReader.Create(ms));
    }

    #endregion

    #region Protected Member Functions

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      throw new NotImplementedException();
    }
    #endregion
  }
}
