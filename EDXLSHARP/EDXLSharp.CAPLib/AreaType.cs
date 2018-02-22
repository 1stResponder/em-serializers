// ———————————————————————–
// <copyright file="AreaType.cs" company="EDXLSharp">
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
// ———————————————————————–

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The area segment describes a geographic area to which the info segment in which it appears applies.
  /// Textual and coded descriptions (such as postal codes) are supported, but the preferred representations
  /// use geospatial shapes (polygons and circles) and an altitude or altitude range,
  /// expressed in standard latitude / longitude / altitude terms in accordance with a specified geospatial datum.
  /// </summary>
  [Serializable]
  public partial class AreaType
  {
    #region Private Member Variables

    /// <summary>
    /// The text describing the affected area of the alert message (REQUIRED)
    /// </summary>
    private string areaDesc;

    /// <summary>
    /// The paired values of points defining a polygon that delineates the affected area of the alert message (OPTIONAL)
    /// </summary>
    private List<string> polygon;

    /// <summary>
    /// The paired values of a point and radius delineating the affected area of the alert message (OPTIONAL)
    /// </summary>
    private List<string> circle;

    /// <summary>
    /// The geographic code delineating the affected area of the alert message (OPTIONAL)
    /// </summary>
    private List<NameValueType> geoCode;

    /// <summary>
    /// The specific or minimum altitude of the affected area of the alert message (OPTIONAL)
    /// </summary>
    private decimal? altitude;

    /// <summary>
    /// The maximum altitude of the affected area of the alert message (CONDITIONAL)
    /// </summary>
    private decimal? ceiling;

    /// <summary>
    /// The namespace of the CAP element
    /// </summary>
    private string capNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the AreaType class Default Constructor - Initializes Lists
    /// </summary>
    public AreaType()
    {
      this.polygon = new List<string>();
      this.circle = new List<string>();
      this.geoCode = new List<NameValueType>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The text describing the affected area of the alert message
    /// </summary>
    public string AreaDesc
    {
      get { return this.areaDesc; }
      set { this.areaDesc = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The paired values of points defining a polygon that delineates the affected area of the alert message
    /// </summary>
    public List<string> Polygon
    {
      get { return this.polygon; }
      set { this.polygon = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The paired values of a point and radius delineating the affected area of the alert message
    /// </summary>
    public List<string> Circle
    {
      get { return this.circle; }
      set { this.circle = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The geographic code delineating the affected area of the alert message
    /// </summary>
    public List<NameValueType> GeoCode
    {
      get { return this.geoCode; }
      set { this.geoCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The specific or minimum altitude of the affected area of the alert message
    /// </summary>
    public decimal? Altitude
    {
      get 
      { 
        return this.altitude; 
      }

      set 
      {
        StringGeoTools.CheckDecimal(value);
        this.altitude = value;
      }
    }

    /// <summary>
    /// Gets or sets
    /// The maximum altitude of the affected area of the alert message
    /// </summary>
    public decimal? Ceiling
    {
      get 
      { 
        return this.ceiling; 
      }

      set 
      {
        StringGeoTools.CheckDecimal(value);
        this.ceiling = value; 
      }
    }

    /// <summary>
    /// Gets or sets
    /// The CAP namespace for serialization
    /// </summary>
    [XmlIgnore]
    public string CapNamespace
    {
      get { return this.capNamespace; }
      set { this.capNamespace = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Adds A Polygon To This AreaType
    /// </summary>
    /// <param name="polyin">Polygon String</param>
    public void AddPolygon(string polyin)
    {
      if (string.IsNullOrEmpty(polyin))
      {
        throw new ArgumentException("Input Value Can't Be Null or Empty!");
      }

      StringGeoTools.CheckPolygon(polyin);
      this.polygon.Add(polyin);
    }

    /// <summary>
    /// Adds a Circle To This AreaType
    /// </summary>
    /// <param name="circlein">Circle String</param>
    public void AddCircle(string circlein)
    {
      if (string.IsNullOrEmpty(circlein))
      {
        throw new ArgumentException("Input Value Can't Be Null or Empty!");
      }

      StringGeoTools.CheckCircle(circlein);
      this.circle.Add(circlein);
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      if (string.IsNullOrEmpty(this.capNamespace))
      {
        this.capNamespace = EDXLConstants.CAP12Namespace;
      }

      xwriter.WriteElementString("areaDesc", this.capNamespace, this.areaDesc);
      if (this.polygon.Count != 0)
      {
        foreach (string poly in this.polygon)
        {
            string fixedPoly = string.Empty;
            try
            {
                fixedPoly = StringGeoTools.ValidatePolygon(poly);
            }
            catch (FormatException fe)
            {
                if (fe.ToString().Contains("Needs Flipped"))
                {
                    string flipped = StringGeoTools.FlipPolygon(poly);
                    fixedPoly = StringGeoTools.ValidatePolygon(flipped);
                }
                else
                {
                    throw fe;
                }
            }

            StringGeoTools.CheckPolygon(fixedPoly); // redundant checks possibly, but not a big deal
            xwriter.WriteElementString("polygon", this.capNamespace, fixedPoly);
        }
      }

      if (this.circle.Count != 0)
      {
        foreach (string circ in this.circle)
        {
          StringGeoTools.CheckCircle(circ);
          xwriter.WriteElementString("circle", this.capNamespace, circ);
        }
      }

      if (this.geoCode.Count != 0)
      {
        foreach (NameValueType name_type in this.geoCode)
        {
          xwriter.WriteStartElement("geocode", this.capNamespace);
          name_type.CapNamespace = this.capNamespace;
          name_type.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      if (this.altitude != null)
      {
        StringGeoTools.CheckDecimal(this.altitude);
        xwriter.WriteElementString("altitude", this.capNamespace, this.altitude.ToString());
        if (this.ceiling != null)
        {
          StringGeoTools.CheckDecimal(this.ceiling);
          xwriter.WriteElementString("ceiling", this.capNamespace, this.ceiling.ToString());
        }
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the Root Object Element</param>
    internal void ReadXML(XmlNode rootNode)
    {
      NameValueType namevaluetmp;
      char[] delimSpace = { ' ' };
      char[] delimComma = { ',' };
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "areaDesc":
            this.areaDesc = node.InnerText;
            break;
          case "polygon":
            string polygonString = node.InnerText;
            StringGeoTools.CheckPolygon(polygonString);
            this.polygon.Add(polygonString);
            break;
          case "circle":
            string circlePt = node.InnerText;
            StringGeoTools.CheckCircle(circlePt);
            this.circle.Add(circlePt);
            break;
          case "geocode":
            namevaluetmp = new NameValueType();
            namevaluetmp.ReadXML(node);
            this.geoCode.Add(namevaluetmp);
            break;
          case "altitude":
            StringGeoTools.CheckDecimal(decimal.Parse(node.InnerText));
            this.altitude = decimal.Parse(node.InnerText);
            break;
          case "ceiling":
            StringGeoTools.CheckDecimal(decimal.Parse(node.InnerText));
            this.ceiling = decimal.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid value: " + node.InnerText + " found in Area Type");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="xwriter">Pointer To A Valid XMLWriter</param>
    internal void ToGeoRSS(XmlWriter xwriter)
    {
      char[] separator = { ' ' };
      string[] values;
      if (this.polygon.Count != 0)
      {
        string polydelta;
        foreach (string poly in this.polygon)
        {
          if (string.IsNullOrEmpty(poly))
          {
            continue;
          }

          polydelta = poly;
          polydelta = polydelta.Replace(",", " ");
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "exterior", EDXLConstants.GMLNamespace);
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "LinearRing", EDXLConstants.GMLNamespace);
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "posList", EDXLConstants.GMLNamespace);
          xwriter.WriteString(polydelta);
          xwriter.WriteEndElement();
          xwriter.WriteEndElement();
          xwriter.WriteEndElement();
          xwriter.WriteEndElement();
        }
      }

      if (this.circle.Count != 0)
      {
        foreach (string circ in this.circle)
        {
          if (string.IsNullOrEmpty(circ))
          {
            continue;
          }

          string test = circ.Substring(circ.LastIndexOf(" "));
          string circdelta = circ;

          // Treat as a Point
          if (test == " 0")
          {
            xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", EDXLConstants.GMLNamespace);
            circdelta = circdelta.Replace(",", " ");
            xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace, circdelta.Replace(" 0", string.Empty));
            xwriter.WriteEndElement();
          }
          else
          {
            circdelta = circdelta.Replace(",", " ");

            // Parse out the space sep
            values = circdelta.Split(separator);
            if (values.Count() != 3)
            {
              throw new FormatException("AreaTypes Circle Should be a space delimited string!");
            }

            xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "CircleByCenterPoint", EDXLConstants.GMLNamespace);
            xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace);
            xwriter.WriteString(values[0] + " " + values[1]);
            xwriter.WriteEndElement();
            xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "radius", EDXLConstants.GMLNamespace);
            double rad = double.Parse(values[2]);
            xwriter.WriteString(rad.ToString());
            xwriter.WriteEndElement();
            xwriter.WriteEndElement();
          }
        }
      }
    }

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    private void Validate()
    {
      if (string.IsNullOrEmpty(this.areaDesc))
      {
        throw new ArgumentNullException("Area Description is required and can't be null");
      }
    }

    #endregion
  }
}
