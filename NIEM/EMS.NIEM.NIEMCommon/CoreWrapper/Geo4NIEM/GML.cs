//-----------------------------------------------------------------------
// <copyright file="GML.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
    /// <summary>
    /// Abstract Base Class Defining Internal Interfaces for GML Objects
    /// </summary>
    public abstract partial class GML
    {
        #region Private Member Variables

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GML class.
        /// Base Class Default Constructor
        /// </summary>
        public GML()
        {
        }

        #endregion

        /// <summary>
        /// Gets or sets Database handle for the object
        /// </summary>    [XmlAttribute(Namespace = Constants.GmlNamespace)]
        [JsonProperty(PropertyName = "@ID")]
        [XmlAttribute("id", Namespace = Constants.GmlNamespace, Form = XmlSchemaForm.Qualified)]
        public string ID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets Coordinate Reference System Type
        /// </summary>
        [JsonProperty(PropertyName = "@SRSName")]
        [XmlAttribute(Namespace = Constants.GmlNamespace, Form = XmlSchemaForm.Qualified)]
        public string SRSName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the the length of coordinate sequence (the number of entries in the list).
        /// </summary>
        [JsonProperty(PropertyName = "@SRSDimension")]
        [XmlAttribute("srsDimension", Namespace = Constants.GmlNamespace)]
        public uint SRSDimension
        {
            get; set;
        }

        /// <summary>
        /// If the SRSDimension is equal to or less then 0, do not serialize 
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeSRSDimension()
        {
            return (SRSDimension > 0);
        }


        /// <summary>
        /// Gets or sets the Ordered list of labels for all the axes of this coordinate reference system
        /// </summary>
        [JsonProperty(PropertyName = "@AxisLabels")]
        [XmlAttribute(Namespace = Constants.GmlNamespace, Form = XmlSchemaForm.Qualified)]
        public string AxisLabels
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Ordered list of unit of measure labels for all the axes 
        /// </summary>
        [JsonProperty(PropertyName = "@UOMLabels")]
        [XmlAttribute(Namespace = Constants.GmlNamespace, Form = XmlSchemaForm.Qualified)]
        public string UOMLabels
        {
            get; set;
        }

        #endregion
    }
}