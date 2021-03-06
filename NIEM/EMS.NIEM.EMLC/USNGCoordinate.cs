﻿//-----------------------------------------------------------------------
// <copyright file="USNGCoordinate.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.NIEM.EMLC
{
    //TODO: Fix this for .NET Core. Should this class be located somewhere else?

    /// <summary>
    /// Represents a US National Grid Coordinate
    /// </summary>
    [Serializable]
    public class USNGCoordinate
    {
        /// <summary>
        /// Initializes a new instance of the USNGCoordinate class
        /// </summary>
        public USNGCoordinate()
        {
            this.GeographicDatum = "http://metadata.ces.mil/mdr/ns/GSIP/crs/WGS84E_3D";
        }

        /// <summary>
        /// Gets or sets An identifier of a USNG coordinate.
        /// </summary>
        [XmlElement("USNGCoordinateID", Namespace = Constants.EmeventNamespace)]
        public string CoordinateID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance east within a USNG zone.
        /// </summary>
        [XmlElement("USNGEastingValue", Namespace = Constants.EmeventNamespace)]
        public string EastingValue
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets A distance north within a USNG zone.
        /// </summary>
        [XmlElement("USNGNorthingValue", Namespace = Constants.EmeventNamespace)]
        public string NorthingValue
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets A spatial reference system.
        /// </summary>
        [XmlElement("GeographicDatumText", Namespace = Constants.NiemcoreNamespace)]
        public string GeographicDatum
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets An identifier of a USNG zone.
        /// </summary>
        [XmlElement("USNGGridZoneID", Namespace = Constants.EmeventNamespace)]
        public string GridZoneID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets An identifier of a specific 100,000 meter squared region within a USNG zone.
        /// </summary>
        [XmlElement("USNGGridZoneSquareID", Namespace = Constants.EmeventNamespace)]
        public string GridZoneSquareId
        {
            get; set;
        }
    }
}