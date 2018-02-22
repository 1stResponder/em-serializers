using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
  /// <summary>
  /// Representation of a point
  /// </summary>
  [Serializable]
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
