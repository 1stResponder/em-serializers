//-----------------------------------------------------------------------
// <copyright file="Ellipse.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
  /// <summary>
  /// Represents an ellipse
  /// </summary>
  [Serializable]
  [JsonObject(MemberSerialization.OptIn)]
    public class Ellipse : GML
    {
        /// <summary>
        /// Initializes a new instance of the Ellipse class
        /// </summary>
        public Ellipse()
        {
            this.Positions = new List<double>();
            this.MajorAxis = new Axis();
            this.MinorAxis = new Axis();
            this.Rotation = new Rotation();
        }

        /// <summary>
        /// Gets or sets the list of positions associated with this ellipse
        /// Positions must use the WGS84 coordinate reference system. 
        /// </summary>
        [XmlIgnore]
        public List<double> Positions
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the string position for this ellipse
        /// Positions must use the WGS84 coordinate reference system. 
        /// </summary>
        [XmlElement(ElementName = "pos", Namespace = Constants.GmlNamespace)]
        //[JsonProperty]
        public string Pos
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (double d in this.Positions)
                {
                    sb.Append(d.ToString());
                    sb.Append(" ");
                }

                return sb.ToString();
            }

            set
            {
                this.Positions = new List<double>();
                string[] split = value.Split(' ');
                foreach (string s in split)
                {
                    this.Positions.Add(double.Parse(s));
                }
            }
        }

        /// <summary>
        /// Gets or sets the major axis value
        /// Must use meters 
        /// Required Element 
        /// </summary>
        //[JsonProperty]
        [XmlElement(ElementName = "majorAxis")]
        public Axis MajorAxis
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the minor axis value
        /// Must use meters 
        /// Requird Element 
        /// </summary>
        //[JsonProperty]
        [XmlElement(ElementName = "minorAxis")]
        public Axis MinorAxis
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the rotation value
        /// Must use degrees
        /// Required Element 
        /// </summary>
        //[JsonProperty]
        [XmlElement(ElementName = "rotation")]
        public Rotation Rotation
        {
            get; set;
        }
    }
}
