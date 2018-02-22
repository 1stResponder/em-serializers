//-----------------------------------------------------------------------
// <copyright file="Polygon.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using System.Xml.Schema;
using System.ComponentModel;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
  /// <summary>
  /// Represents a polygon
  /// </summary>
  [Serializable]
  public class Polygon : GML
    {
        /// <summary>
        /// Initializes a new instance of the Polygon class
        /// </summary>
        public Polygon()
        {
            this.id = "ID1";
            Interior = new List<Interior>();
        }

        /// <summary>
        /// Holds identifier for this polygon
        /// Must be unique value and start with letter (no other ids, even of other objects can match)
        /// </summary>
        [XmlIgnore]
        public string id
        {
            get
            {
                return this.ID;
            }

            set
            {
                this.ID = value;
            }
        }


        /// <summary>
        /// Gets or sets the interior ring of this polygon
        /// Optional Element
        /// </summary>
        [XmlElement("interior", Namespace = Constants.GmlNamespace, Order = 2)]
        [JsonProperty]
        public List<Interior> Interior
        {
            get; set;
        }

        /// <summary>
        /// If Interior list is null or empty do not serialize it 
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeInterior()
        {
            if (Interior != null && Interior.Count > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Gets or sets the exterior ring of this polygon
        /// Optional Element
        /// </summary>
        [XmlElement("exterior", Namespace = Constants.GmlNamespace, Order = 1)]
        [JsonProperty]
        public Exterior Exterior
        {
            get; set;
        }
    }
}