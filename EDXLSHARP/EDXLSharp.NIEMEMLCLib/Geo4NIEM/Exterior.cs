using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
    /// <summary>
    /// Represents outer ring
    /// </summary>
    public class Exterior
    {

        /// <summary>
        /// Initializes new Exterior Object
        /// </summary>
        public Exterior()
        {
        }

        /// <summary>
        /// Holds Exterior ring
        /// Required Element
        /// </summary>
        [XmlIgnore]
        private dynamic abstractRingType
        {
            get; set;
        }

        /// <summary>
        /// Holds ring type for the Exterior object
        /// </summary>
        [XmlElement("LinearRing", typeof(LinearRing), Namespace = Constants.GmlNamespace)]
        public dynamic AbstractRingType
        {
            get {
                return abstractRingType;
            }

            set {
                if(value is AbstractRingType)
                {
                    abstractRingType = value;
                } 
                else
                {
                    throw new InvalidOperationException("AbstractRingType must be of type AbstractRingType");
                }
            }
        }

    }
}
