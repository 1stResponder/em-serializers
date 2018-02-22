using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Enumeration for status of sensor device
  /// </summary>
  public enum SensorStatusCodeList
  {
    /// <summary>
    /// Default - unknown status
    /// </summary>
    Unknown,

    /// <summary>
    /// Not connected
    /// </summary>
    NotConnected,

    /// <summary>
    /// [Connected] [Awake] Normal status 
    /// </summary>
    Normal,

    /// <summary>
    /// Sensor device settings are misconfigured
    /// </summary>
    Misconfigured,

    /// <summary>
    /// Sensor device is in Error state
    /// </summary>
    Error,

    /// <summary>
    /// Low power
    /// </summary>
    LowPower,

    /// <summary>
    /// Sensor device is in sleeping state
    /// </summary>
    Sleeping
  }
}
