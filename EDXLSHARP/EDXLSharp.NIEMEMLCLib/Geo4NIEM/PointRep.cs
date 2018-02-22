using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
    /// <summary>
    /// Representation of a point
    /// </summary>
    public class PointRep: posKind
    {
        /// <summary>
        /// Initializes new instance of PointRep
        /// </summary>
        public PointRep()
        {
            point = new Point();
        }

        /// <summary>
        /// Gets or sets point for this point property
        /// Optional element
        /// </summary>
        [XmlElement("Point",Namespace = Constants.GmlNamespace)]
        public Point point
        {
            get; set;
        }



    }
}
