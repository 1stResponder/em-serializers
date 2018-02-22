//-----------------------------------------------------------------------
// <copyright file="LocationLineString.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using EMS.NIEM.NIEMCommon.Geo4NIEM;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a LineString
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "WGS84LocationLineString", Namespace = Constants.MoNamespace)]
  public class LocationLineString : AreaRegion
    {
        /// <summary>
        /// Initializes a new instance of the LocationLineString class
        /// </summary>
        public LocationLineString()
        {
            this.LineString = new LineString();
        }

        /// <summary>
        /// Gets or sets the LineString
        /// Required Element
        /// </summary>
        [XmlElement(Namespace = Constants.GmlNamespace)]
        public LineString LineString
        {
            get; set;
        }
    }
}