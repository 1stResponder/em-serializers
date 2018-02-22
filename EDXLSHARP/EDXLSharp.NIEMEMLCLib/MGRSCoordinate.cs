using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
    /// <summary>
    /// Represents a MGRS Coordinate
    /// </summary>
    public class MGRSCoordinate
    {

        /// <summary>
        /// Gets or sets An identifier of a MGRS coordinate.
        /// </summary>
        [XmlElement("MGRSCoordinateID", Namespace = Constants.NiemcoreNamespace)]
        public string CoordinateID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance east within a MGRS zone.
        /// </summary>
        [XmlElement("MGRSEastingValue", Namespace = Constants.NiemcoreNamespace)]
        public int EastingValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance north within a MGRS zone.
        /// </summary>
        [XmlElement("MGRSNorthingValue", Namespace = Constants.NiemcoreNamespace)]
        public int NorthingValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A spatial reference system.
        /// </summary>
        /// geographic datum text
        [XmlElement("GeographicDatumText", Namespace = Constants.NiemcoreNamespace)]
        public string GeographicDatum
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets An identifier of a MGRS zone.
        /// </summary>
        [XmlElement("MGRSGridZoneID", Namespace = Constants.NiemcoreNamespace)]
        public string GridZoneID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets An identifier of a specific 100,000 meter squared region within a MGRS zone.
        /// </summary>
        [XmlElement("MGRSGridZoneSquareID", Namespace = Constants.NiemcoreNamespace)]
        public string GridZoneSquareId
        {
            get; set;
        }
    }
}

