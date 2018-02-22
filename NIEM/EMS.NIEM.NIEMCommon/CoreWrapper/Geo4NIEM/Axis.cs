using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
  /// <summary>
  /// Represents an axis of a geometric shape
  /// </summary>
  [Serializable]
  public class Axis : UOM_SerializedNumber
    {
        /// <summary>
        /// Initializes the Axis Object
        /// </summary>
        public Axis()
        {
            base.UnitOfMeasure = "meters";
        }
    }
}
