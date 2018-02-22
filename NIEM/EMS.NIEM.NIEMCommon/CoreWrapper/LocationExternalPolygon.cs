//-----------------------------------------------------------------------
// <copyright file="LocationExternalPolygon.cs" company="EDXLSharp">
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
  /// Represents an external perimeter polygon
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "WGS84LocationExternalPolygon", Namespace = Constants.MoNamespace)]
  public class LocationExternalPolygon : AreaRegion
    {
        /// <summary>
        /// Initializes a new instance of the LocationExternalPolygon class
        /// </summary>
        public LocationExternalPolygon()
        {
            this.Polygon = new Polygon();
        }

        /// <summary>
        /// Gets or sets the polygon
        /// Required
        /// </summary>
        [XmlElement(Namespace = Constants.GmlNamespace)]
        public Polygon Polygon
        {
            get; set;
        }
    }
}