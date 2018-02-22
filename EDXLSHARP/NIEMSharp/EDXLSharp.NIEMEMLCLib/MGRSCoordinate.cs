using System;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
    /// <summary>
    /// Represents a MGRS Coordinate
    /// </summary>
    public class MGRSCoordinate
    {
        
        /// <summary>
        /// Initializes a new instance of the MGRSCoordinate class
        /// </summary>
        public MGRSCoordinate() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cordID">Coordinate ID</param>
        /// <param name="eastValue">Easting Value</param>
        /// <param name="northValue">Northing Value</param>
        /// <param name="geoDatum">Geographic datum</param>
        /// <param name="zoneID">Zone ID</param>
        /// <param name="squaredID">ID of squared region</param>
        public MGRSCoordinate(string cordID, int eastValue, int northValue,string geoDatum, 
            string zoneID, string squaredID) {

            CoordinateID = cordID;
            EastingValue = eastValue;
            NorthingValue = northValue;
            GeographicDatumText = geoDatum;
            GridZoneID = zoneID;
            GridZoneSquareId = squaredID;           
        }


        /// <summary>
        /// Gets or sets An identifier of a MGRS coordinate.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName = "MGRSCoordinateID", Namespace = Constants.NiemcoreNamespace, Order = 1)]
        public string CoordinateID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance east within a MGRS zone.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName = "MGRSEastingValue", Namespace = Constants.NiemcoreNamespace, Order = 2)]
        public int EastingValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance north within a MGRS zone.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName = "MGRSNorthingValue", Namespace = Constants.NiemcoreNamespace, Order = 3)]
        public int NorthingValue
        {
            get; set;
        }

        
        /// <summary>
        /// Gets or sets A spatial reference system.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName =  "GeographicDatumText", Namespace = Constants.NiemcoreNamespace, Order = 4)]
        public string GeographicDatumText
        {
            get; set;
        }      
      
        /// <summary>
        /// Gets or sets An identifier of a zone.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName = "MGRSGridZoneID", Namespace = Constants.NiemcoreNamespace, Order = 5)]
        public string GridZoneID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets An identifier of a specific 100,000 meter squared region within a zone.
        /// Required Element
        /// </summary>
        [XmlElement(ElementName = "MGRSGridZoneSquareID", Namespace = Constants.NiemcoreNamespace, Order = 6)]
        public string GridZoneSquareId
        {
            get; set;
        }
    }
}

