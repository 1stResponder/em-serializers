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

using EMS.EDXL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// Data Structure to Represent an Area
  /// </summary>
  [Serializable]
  public partial class TargetAreaType
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
    [XmlElement(ElementName = "circle", Order = 0)]
    public List<string> Circle
    {
      get { return this.circle; }
      set { this.circle = value; }
    }

    /// <summary>
    /// Indicates whether or not the Circle was specified
    /// </summary>
    [XmlIgnore]
    public bool CircleSpecified
    {
      get { return this.circle != null && this.circle.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// Represented by a space-delimited series of latitude, longitude pairs, with the last pair identical to the first
    /// </summary>
    [XmlElement(ElementName = "polygon", Order = 1)]
    public List<string> Polygon
    {
      get { return this.polygon; }
      set { this.polygon = value; }
    }

    /// <summary>
    /// Indicates whether or not the Polygon was specified
    /// </summary>
    [XmlIgnore]
    public bool PolygonSpecified
    {
      get { return this.polygon != null && this.polygon.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// The two-character ISO 3166-1 Country Code for the country concerned.
    /// </summary>
    [XmlElement(ElementName = "country", Order = 2)]
    public List<string> Country
    {
      get { return this.country; }
      set { this.country = value; }
    }

    /// <summary>
    /// Indicates whether or not the Country was specified
    /// </summary>
    [XmlIgnore]
    public bool CountrySpecified
    {
      get { return this.country != null && this.country.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// The ISO 3166-2 designator for the administrative subdivision concerned.
    /// </summary>
    [XmlElement(ElementName = "subdivision", Order = 3)]
    public List<string> SubDivision
    {
      get { return this.subdivision; }
      set { this.subdivision = value; }
    }

    /// <summary>
    /// Indicates whether or not the SubDivision was specified
    /// </summary>
    [XmlIgnore]
    public bool SubDivisionSpecified
    {
      get { return this.subdivision != null && this.subdivision.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// The two first digits are the two character ISO3166-1 Country Code for the country in which the place is located.
    /// </summary>
    [XmlElement(ElementName = "locCodeUN", Order = 4)]
    public List<string> LocCodeUN
    {
      get { return this.loccodeUN; }
      set { this.loccodeUN = value; }
    }

    /// <summary>
    /// Indicates whether or not the LocCodeUN was specified
    /// </summary>
    [XmlIgnore]
    public bool LocCodeUNSpecified
    {
      get { return this.loccodeUN != null && this.loccodeUN.Count > 0; }
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
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="xwriter">Pointer to a Valid XMLWriter to Write Extension Data To</param>
    public void ToGeoRSS(XmlWriter xwriter)
    {
      //char[] separator = { ' ' };
      //string[] values;

      //// We Need To Convert The Generic Area Type Into Standard GML here...
      //foreach (string poly in this.polygon)
      //{
      //  xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
      //  xwriter.WriteString(poly);
      //  xwriter.WriteEndElement();
      //}

      //foreach (string circ in this.circle)
      //{
      //  // Treat as a Point - This is Somewhat of a HACK until OASIS switches this to GeoOASIS Where
      //  if (circ.Contains(" 0"))
      //  {
      //    xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", EDXLConstants.GMLNamespace);
      //    xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace, circ);
      //    xwriter.WriteEndElement();
      //  }
      //  else
      //  {
      //    // Parse out the space sep
      //    values = circ.Split(separator);
      //    if (values.Count() != 3)
      //    {
      //      throw new FormatException("AreaTypes Circle Should be a space delimited string!");
      //    }

      //    xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "CircleByCenterPoint", EDXLConstants.GMLNamespace);
      //    xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
      //    xwriter.WriteString(values[0] + " " + values[1]);
      //    xwriter.WriteEndElement();
      //    xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "radius", EDXLConstants.GMLNamespace);
      //    xwriter.WriteString(values[2]);
      //    xwriter.WriteEndElement();
      //    xwriter.WriteEndElement();
      //  }
      //}
    }

    /// <summary>
    /// Validates the current data and values
    /// </summary>
    public virtual void Validate()
    {
      // TODO: TargetAreaType.Validate()
    }
    #endregion
  }
}
