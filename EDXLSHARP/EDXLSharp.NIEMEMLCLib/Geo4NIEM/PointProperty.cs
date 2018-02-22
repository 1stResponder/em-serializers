using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
    /// <summary>
    /// Point which references another point or contains a point
    /// </summary>
    public class PointProperty: posKind
    {
        /// <summary>
        /// Initializes new instance of PointProperty
        /// </summary>
        public PointProperty()
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
