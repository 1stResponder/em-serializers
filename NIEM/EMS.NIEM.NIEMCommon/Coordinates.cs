using EMS.NIEM.NIEMCommon.Geo4NIEM;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a coordinate object
  /// </summary>
  [Serializable]
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
