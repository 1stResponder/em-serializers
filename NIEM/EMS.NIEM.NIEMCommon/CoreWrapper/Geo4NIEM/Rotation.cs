using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{
  /// <summary>
  /// Represents degrees of rotation
  /// </summary>
  [Serializable]
  public class Rotation : UOM_SerializedNumber
    {
        /// <summary>
        /// Initializes the Rotation Object
        /// </summary>
        public Rotation()
        {
            base.UnitOfMeasure = "degrees";
        }
    }
}
