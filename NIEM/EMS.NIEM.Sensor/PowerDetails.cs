using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EMS.NIEM.NIEMCommon;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Base class for serializing sensor power information
  /// </summary>
  [Serializable]
  public class PowerDetails
  {
    private int? batteryLevel;

    /// <summary>
    /// Battery level in percentage from 0% to 100%. It is 
    ///  represented as 0 to 100.
    /// </summary>
    [XmlElement("BatteryLevel")]
    public int BatteryLevel
    {
      get
      {
        if (batteryLevel.HasValue)
        {
          return batteryLevel.Value;
        }
        else
        {
          return -1;
        }
      }

      set
      {
        batteryLevel = value;
      }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeBatteryLevel()
    {
      return batteryLevel.HasValue;
    }
  }
}
