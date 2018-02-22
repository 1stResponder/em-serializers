//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
    /// <summary>
    /// Represents a single geospatial point
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
  [Serializable]
  public class Point
    {
        /// <summary>
        /// Initializes a new instance of the Point class
        /// </summary>
        public Point()
        {
            this.srsName = "http://metadata.ces.mil/mdr/ns/GSIP/crs/WGS84E_3D";
            this.id = "ID" + this.GetHashCode().ToString();

        }

        /// <summary>
        /// Initializes a new instance of the Point class
        /// </summary>
        /// <param name="id">Identifier to use for this point</param>
        public Point(string id)
        {
            this.srsName = "http://metadata.ces.mil/mdr/ns/GSIP/crs/WGS84E_3D";
            this.id = id;
        }

        /// <summary>
        /// Gets or sets the identifier of this point
        /// Must be unique value and start with letter (no other ids, even of other objects) can match
        /// </summary>
        [XmlAttribute(Namespace = Constants.GmlNamespace, Form = XmlSchemaForm.Qualified)]
        [JsonProperty(PropertyName = "@id")]
        public string id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the spatial reference system name
        /// </summary>
        [XmlAttribute]
        [JsonProperty(PropertyName = "@srsName")]
        public string srsName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the latitude 
        /// </summary>
        [XmlIgnore]
        public double? Lat
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        [XmlIgnore]
        public double? Lon
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        [XmlIgnore]
        public double? Height
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the GML string position
        /// </summary>
        [XmlElement(Namespace = Constants.GmlNamespace)]
        [JsonProperty]
        public string pos
        {
            get
            {
                if (this.Height != null)
                {
                    return this.Lat.ToString() + " " + this.Lon.ToString() + " " + this.Height.ToString();
                }
                else
                {
                    return this.Lat.ToString() + " " + this.Lon.ToString();
                }
            }

            set
            {
                string[] split = value.Trim().Split(' ');
                if (split.Count() == 2)
                {
                    this.Lat = double.Parse(split[0]);
                    this.Lon = double.Parse(split[1]);
                    this.Height = null;
                }
                else if (split.Count() == 3)
                {
                    this.Lat = double.Parse(split[0]);
                    this.Lon = double.Parse(split[1]);
                    this.Height = double.Parse(split[2]);
                }
            }
        }
    }
}