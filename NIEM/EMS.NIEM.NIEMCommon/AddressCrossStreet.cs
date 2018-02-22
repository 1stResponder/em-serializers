//-----------------------------------------------------------------------
// <copyright file="AddressCrossStreet.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;


namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Cross street for an address
  /// </summary>
  [Serializable]
  public class AddressCrossStreet
    {
        /// <summary>
        /// Initializes a new instance of the AddressCrossStreet class
        /// </summary>
        public AddressCrossStreet()
        {
            LocationStreet = new LocationStreet();
        }

        /// <summary>
        /// Gets or sets the descriptive text of the cross street
        /// Optional Element
        /// </summary>
        [XmlElement("CrossStreetDescriptionText", Namespace = Constants.NiemcoreNamespace)]
        public string CrossStreetDescriptionText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the street address of the cross street
        /// Required Element 
        /// </summary>
        [XmlElement("LocationStreet", typeof(LocationStreet), Namespace = Constants.NiemcoreNamespace)]
        public LocationStreet LocationStreet
        {
            get; set;
        }
    }
}
