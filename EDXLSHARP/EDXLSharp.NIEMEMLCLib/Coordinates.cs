using EDXLSharp.NIEMEMLCLib.Geo4NIEM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
    /// <summary>
    /// Represents a coordinate object
    /// </summary>
    public class Coordinates: posKind
    {
        /// <summary>
        /// Creates instance of coordinate class 
        /// </summary>
        public Coordinates() { }

        /// <summary>
        /// Creates instance of coordinate class 
        /// </summary>
        /// <param name="cord">Coordinates as string</param>
        public Coordinates(string cord) 
        { 
            text = cord;
        }

        /// <summary>
        /// Holds Coordinates as string
        /// Required
        /// </summary>
        [XmlText]
        public string text {
            get; set;
        }

    }
}
