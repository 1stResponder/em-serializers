// ———————————————————————–
// <copyright file="GeoOASISWhere.cs" company="EDXLSharp">
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
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// OASIS Profile of the GML 2.1 Standard
  /// </summary>
  [Serializable]
  public partial class GeoOASISWhere : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// Optional where attribute indicating the type of geographic entity is being referred to. Default is "location"
    /// </summary>
    private NCName featureType;

    /// <summary>
    /// Optional where attribute indicating how geotagged content is related to the represented location. Default is "isLocatedAt"
    /// </summary>
    private NCName relationship;

    /// <summary>
    /// Optional where attribute indicating a GPS-measured elevation in meters (e.g. WGS84 geoid height)
    /// </summary>
    private double? elevation;

    /// <summary>
    /// Optional where attribute indicating elevation by building floor
    /// </summary>
    private double? floor;

    /// <summary>
    /// Optional where attribute indicating size in meters of a radius or buffer being indicated around the geometry (e.g. radius of circular area around a point geometry
    /// </summary>
    private double? radius;

    /// <summary>
    /// The OASIS GML Location
    /// </summary>
    private GML location;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GeoOASISWhere class
    /// Default Constructor - Does Nothing
    /// </summary>
    public GeoOASISWhere()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Optional where attribute indicating size in meters of a radius or buffer being indicated around the geometry (e.g. radius of circular area around a point geometry
    /// </summary>
    public double? Radius
    {
      get { return this.radius; }
      set { this.radius = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Optional where attribute indicating elevation by building floor
    /// </summary>
    public double? Floor
    {
      get { return this.floor; }
      set { this.floor = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Optional where attribute indicating a GPS-measured elevation in meters (e.g. WGS84 geoid height)
    /// </summary>
    public double? Elevation
    {
      get { return this.elevation; }
      set { this.elevation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Optional where attribute indicating how geotagged content is related to the represented location. Default is "isLocatedAt"
    /// </summary>
    public NCName Relationship
    {
      get { return this.relationship; }
      set { this.relationship = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Optional where attribute indicating the type of geographic entity is being referred to. Default is "location"
    /// </summary>
    public NCName FeatureType
    {
      get { return this.featureType; }
      set { this.featureType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The OASIS GML Location
    /// </summary>
    public GML Location
    {
      get { return this.location; }
      set { this.location = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an Geo-OASIS Where From An Existing DOM - You Must Parse The Top Level Element Before Calling This!
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlAttribute attrib in rootnode.Attributes)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "relationshiptage":
            this.relationship = new NCName(attrib.InnerText);
            break;
          case "radius":
            this.radius = double.Parse(attrib.InnerText);
            break;
          case "featuretypetag":
            this.featureType = new NCName(attrib.InnerText);
            break;
          case "elev":
            this.elevation = double.Parse(attrib.InnerText);
            break;
          case "floor":
            this.floor = double.Parse(attrib.InnerText);
            break;
          case "interpolation":
          case "numArc":
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected Attribute: " + attrib.Name + " in GeoOASISWhere");
            }

            break;
        }
      }

      if (string.IsNullOrEmpty(rootnode.InnerText))
      {
        return;
      }

      switch (rootnode.LocalName)
      {
        case "Point":
          this.location = new GMLPoint();
          this.location.ReadXML(rootnode);
          break;
        case "LineString":
          this.location = new GMLLineString();
          this.location.ReadXML(rootnode);
          break;
        case "CircleByCenterPoint":
          this.location = new GMLCircleByCenterPoint();
          this.location.ReadXML(rootnode);
          break;
        case "Polygon":
          this.location = new GMLPolygon();
          this.location.ReadXML(rootnode);
          break;
        case "Envelope":
          this.location = new GMLEnvelope();
          this.location.ReadXML(rootnode);
          break;
        case "#comment":
          break;
        default:
          throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in GeoOASISWhere");
      }
    }

    /// <summary>
    /// Writes This Geo-OASIS Where to an Existing XML Document - You Must Write The Start and End Elements Before Calling this!!!
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (this.relationship != null)
      {
        xwriter.WriteAttributeString("relationshiptag", this.relationship.ToString());
      }

      if (this.radius != null)
      {
        xwriter.WriteAttributeString("radius", this.radius.ToString());
      }

      if (this.featureType != null)
      {
        xwriter.WriteAttributeString("featuretypetag", this.featureType.ToString());
      }

      if (this.elevation != null)
      {
        xwriter.WriteAttributeString("elev", this.elevation.ToString());
      }

      if (this.floor != null)
      {
        xwriter.WriteAttributeString("floor", this.floor.ToString());
      }

      if (this.location != null)
      {
        this.location.WriteXML(xwriter);
      }
    }

    /// <summary>
    /// Writes This Object To an XML String
    /// </summary>
    /// <returns>XML String</returns>
    public string ToXMLString()
    {
      this.Validate();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      xsettings.Encoding = Encoding.UTF8;
      StringBuilder output = new StringBuilder();
      using (XmlWriter xwriter = XmlWriter.Create(output, xsettings))
      {
        xwriter.WriteStartDocument(false);

        xwriter.WriteStartElement(EDXLConstants.GeoOASISWherePrefix, "where", EDXLConstants.GeoOASISWhereNamespace);
        xwriter.WriteAttributeString("xmlns", EDXLConstants.GMLPrefix, null, EDXLConstants.GMLNamespace);
        xwriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");

        if (this.relationship != null)
        {
          xwriter.WriteAttributeString("relationshiptag", this.relationship.ToString());
        }

        if (this.radius != null)
        {
          xwriter.WriteAttributeString("radius", this.radius.ToString());
        }

        if (this.featureType != null)
        {
          xwriter.WriteAttributeString("featuretypetag", this.featureType.ToString());
        }

        if (this.elevation != null)
        {
          xwriter.WriteAttributeString("elev", this.elevation.ToString());
        }

        if (this.floor != null)
        {
          xwriter.WriteAttributeString("floor", this.floor.ToString());
        }

        if (this.location != null)
        {
          this.location.WriteXML(xwriter);
        }

        xwriter.WriteEndElement();
        xwriter.Flush();
      }

      return output.ToString();
    }

    /// <summary>
    /// Reads This Object From an XML String
    /// </summary>
    /// <param name="xmldata">XML String Data</param>
    public void ReadFromXML(string xmldata)
    {
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(xmldata);
      XmlNodeList nodelist = doc.GetElementsByTagName("where");
      if (nodelist.Count == 0)
      {
        throw new FormatException("No Geo-OASIS Where Element found!");
      }
      else if (nodelist.Count > 1)
      {
        throw new FormatException("Multiple Geo-OASIS Where Elements found!");
      }

      XmlNode root = nodelist[0];

      foreach (XmlAttribute attrib in root.Attributes)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "relationshiptage":
            this.relationship = new NCName(attrib.InnerText);
            break;
          case "radius":
            this.radius = double.Parse(attrib.InnerText);
            break;
          case "featuretypetag":
            this.featureType = new NCName(attrib.InnerText);
            break;
          case "elev":
            this.elevation = double.Parse(attrib.InnerText);
            break;
          case "floor":
            this.floor = double.Parse(attrib.InnerText);
            break;
          case "#comment":
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected Attribute Name: " + attrib.LocalName + " in GeoOASISWhere");
            }

            break;
        }
      }

      foreach (XmlNode node in root.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Point":
            this.location = new GMLPoint();
            this.location.ReadXML(node);
            break;
          case "LineString":
            this.location = new GMLLineString();
            this.location.ReadXML(node);
            break;
          case "CircleByCenterPoint":
            this.location = new GMLCircleByCenterPoint();
            this.location.ReadXML(node);
            break;
          case "Polygon":
            this.location = new GMLPolygon();
            this.location.ReadXML(node);
            break;
          case "Envelope":
            this.location = new GMLEnvelope();
            this.location.ReadXML(node);
            break;
          default:
            throw new ArgumentException("Unexpected Node Name: " + node.LocalName + " in GeoOASISWhere");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    public void ToGeoRSS(SyndicationItem myitem)
    {
      StringBuilder output = new StringBuilder();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      xsettings.OmitXmlDeclaration = true;
      XmlWriter swriter = XmlWriter.Create(output, xsettings);
      swriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
      this.WriteXML(swriter);
      swriter.WriteEndElement();
      swriter.Flush();
      swriter.Close();
      MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
      myitem.ElementExtensions.Add(XmlReader.Create(ms));
    }

    /// <summary>
    /// Validates this object for required elements
    /// </summary>
    public void Validate()
    {
      if (this.location == null)
      {
        throw new ArgumentNullException("Location Can't Be Null!");
      }
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}
