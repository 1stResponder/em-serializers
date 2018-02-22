// ———————————————————————–
// <copyright file="TargetAreaType.cs" company="EDXLSharp">
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

namespace EDXLSharp
{
  /// <summary>
  /// Data Structure to Represent an Area
  /// </summary>
  [Serializable]
  public partial class TargetAreaType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Represented in the form "latitude, longitude, radius". (See Geospatial Note above)
    /// </summary>
    private List<string> circle;

    /// <summary>
    /// Represented by a space-delimited series of latitude, longitude pairs, with the last pair
    /// identical to the first. 
    /// </summary>
    private List<string> polygon;

    /// <summary>
    /// The two-character ISO 3166-1 Country Code for the country concerned.
    /// </summary>
    private List<string> country;

    /// <summary>
    /// The ISO 3166-2 designator for the administrative subdivision concerned.
    /// </summary>
    private List<string> subdivision;

    /// <summary>
    /// The UN/LOCODE designator for the location concerned.
    /// </summary>
    private List<string> loccodeUN;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the TargetAreaType class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public TargetAreaType()
    {
      this.circle = new List<string>();
      this.polygon = new List<string>();
      this.country = new List<string>();
      this.subdivision = new List<string>();
      this.loccodeUN = new List<string>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Represented in the form "latitude,longitude radius"
    /// </summary>
    [XmlIgnore]
    public List<string> Circle
    {
      get { return this.circle; }
      set { this.circle = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Represented by a space-delimited series of latitude, longitude pairs, with the last pair identical to the first
    /// </summary>
    [XmlIgnore]
    public List<string> Polygon
    {
      get { return this.polygon; }
      set { this.polygon = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The two-character ISO 3166-1 Country Code for the country concerned.
    /// </summary>
    [XmlIgnore]
    public List<string> Country
    {
      get { return this.country; }
      set { this.country = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The ISO 3166-2 designator for the administrative subdivision concerned.
    /// </summary>
    [XmlIgnore]
    public List<string> SubDivision
    {
      get { return this.subdivision; }
      set { this.subdivision = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The two first digits are the two character ISO3166-1 Country Code for the country in which the place is located.
    /// </summary>
    [XmlIgnore]
    public List<string> LocCodeUN
    {
      get { return this.loccodeUN; }
      set { this.loccodeUN = value; }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Circle
    /// </summary>
    [XmlElement(ElementName = "circle", Order = 0)]
    public string[] CircleXML
    {
      get
      {
        if (this.circle.Count == 0)
        {
          return null;
        }
        else
        {
          return this.circle.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.circle = value.ToList();
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Polygon
    /// </summary>
    [XmlElement(ElementName = "polygon", Order = 1)]
    public string[] PolygonXML
    {
      get
      {
        if (this.polygon.Count == 0)
        {
          return null;
        }
        else
        {
          return this.polygon.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.polygon = value.ToList();
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Country
    /// </summary>
    [XmlElement(ElementName = "country", Order = 2)]
    private string[] CountryXML
    {
      get
      {
        if (this.country.Count == 0)
        {
          return null;
        }
        else
        {
          return this.country.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.country = value.ToList();
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Subdivision
    /// </summary>
    [XmlElement(ElementName = "subdivision", Order = 3)]
    private string[] SubDivisionXML
    {
      get
      {
        if (this.subdivision.Count == 0)
        {
          return null;
        }
        else
        {
          return this.subdivision.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.subdivision = value.ToList();
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for UN Location Code 
    /// </summary>
    [XmlElement(ElementName = "locCodeUN", Order = 4)]
    private string[] LocCodeUNXML
    {
      get
      {
        if (this.loccodeUN.Count == 0)
        {
          return null;
        }
        else
        {
          return this.loccodeUN.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.loccodeUN = value.ToList();
        }
      }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Adds a Circle To The List
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
    /// Adds a Polygon To The List
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
    /// Adds a Country To The List
    /// </summary>
    /// <param name="countryin">Country String</param>
    public void AddCountry(string countryin)
    {
      if (string.IsNullOrEmpty(countryin))
      {
        throw new ArgumentException("Input Value Can't Be Null or Empty!");
      }

      StringGeoTools.CheckCountry(countryin);
      this.country.Add(countryin);
    }

    /// <summary>
    /// Adds a SubDivision To The List
    /// </summary>
    /// <param name="subdivisionin">SubDivision String</param>
    public void AddSubDivision(string subdivisionin)
    {
      if (string.IsNullOrEmpty(subdivisionin))
      {
        throw new ArgumentException("Input Value Can't Be Null or Empty!");
      }

      StringGeoTools.CheckSubdivision(subdivisionin);
      this.subdivision.Add(subdivisionin);
    }

    /// <summary>
    /// Adds a UN Location Code To The List
    /// </summary>
    /// <param name="unloccode">UN Location Code String</param>
    public void AddLocCodeUN(string unloccode)
    {
      if (string.IsNullOrEmpty(unloccode))
      {
        throw new ArgumentNullException("Value Must Not Be Null or Empty");
      }

      StringGeoTools.CheckLocCodeUN(unloccode);
      this.loccodeUN.Add(unloccode);
    }

    /// <summary>
    /// Writes This IComposable Message Into An Existing XML Document
    /// </summary>
    /// <param name="xwriter">Existing XML Document Writer</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (this.circle.Count == 0 && this.polygon.Count == 0 && this.country.Count == 0 && this.subdivision.Count == 0 && this.loccodeUN.Count == 0)
      {
        throw new ArgumentNullException("All Elements can't be null");
      }

      xwriter.WriteStartElement("targetArea");

      foreach (string circle in this.circle)
      {
        StringGeoTools.CheckCircle(circle);
        xwriter.WriteElementString("circle", circle);
      }

      foreach (string polygon in this.polygon)
      {
        StringGeoTools.CheckPolygon(polygon);
        xwriter.WriteElementString("polygon", polygon);
      }

      foreach (string country in this.country)
      {
        StringGeoTools.CheckCountry(country);
        xwriter.WriteElementString("country", country);
      }

      foreach (string subdivision in this.subdivision)
      {
        StringGeoTools.CheckSubdivision(subdivision);
        xwriter.WriteElementString("subdivision", subdivision);
      }

      foreach (string loccodeun in this.loccodeUN)
      {
        StringGeoTools.CheckLocCodeUN(loccodeun);
        xwriter.WriteElementString("locCodeUN", loccodeun);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads This IComposable Message From An Existing XML Document
    /// </summary>
    /// <param name="rootnode">Node That Points to the TargetArea Element</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode == (XmlNode)null)
      {
        throw new ArgumentNullException("RootNode");
      }

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "circle":
            StringGeoTools.CheckCircle(node.InnerText);
            this.circle.Add(node.InnerText);
            break;
          case "polygon":
            StringGeoTools.CheckPolygon(node.InnerText);
            this.polygon.Add(node.InnerText);
            break;
          case "country":
            StringGeoTools.CheckCountry(node.InnerText);
            this.country.Add(node.InnerText);
            break;
          case "subdivision":
            StringGeoTools.CheckSubdivision(node.InnerText);
            this.subdivision.Add(node.InnerText);
            break;
          case "locCodeUN":
            StringGeoTools.CheckLocCodeUN(node.InnerText);
            this.loccodeUN.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid value: " + node.InnerText + " found in TargetArea Type");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="xwriter">Pointer to a Valid XMLWriter to Write Extension Data To</param>
    public void ToGeoRSS(XmlWriter xwriter)
    {
      char[] separator = { ' ' };
      string[] values;

      // We Need To Convert The Generic Area Type Into Standard GML here...
      foreach (string poly in this.polygon)
      {
        xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
        xwriter.WriteString(poly);
        xwriter.WriteEndElement();
      }

      foreach (string circ in this.circle)
      {
        // Treat as a Point - This is Somewhat of a HACK until OASIS switches this to GeoOASIS Where
        if (circ.Contains(" 0"))
        {
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", EDXLConstants.GMLNamespace);
          xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace, circ);
          xwriter.WriteEndElement();
        }
        else
        {
          // Parse out the space sep
          values = circ.Split(separator);
          if (values.Count() != 3)
          {
            throw new FormatException("AreaTypes Circle Should be a space delimited string!");
          }

          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "CircleByCenterPoint", EDXLConstants.GMLNamespace);
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
          xwriter.WriteString(values[0] + " " + values[1]);
          xwriter.WriteEndElement();
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "radius", EDXLConstants.GMLNamespace);
          xwriter.WriteString(values[2]);
          xwriter.WriteEndElement();
          xwriter.WriteEndElement();
        }
      }
    }

    /// <summary>
    /// Validates the current data and values
    /// </summary>
    public virtual void Validate()
    {
      // TODO: TargetAreaType.Validate()
    }
    #endregion

    #region Private Member Functions

    #endregion
  }
}
