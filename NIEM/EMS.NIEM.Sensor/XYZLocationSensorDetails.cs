using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Base class for location sensor information
  /// </summary>
  public class XYZLocationSensorDetails : XYLocationSensorDetails
  {
    private string zCoordinate;
    private float? zAxisAcceleration;

    /// <summary>
    /// Z coordinate of an object 
    /// </summary>
    [XmlElement("ZCoordinate")]
    public string ZCoordinate
    {
      get { return zCoordinate; }
      set { zCoordinate = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeZCoordinate()
    {
      return !string.IsNullOrWhiteSpace(zCoordinate);
    }

    /// <summary>
    /// Acceleration in the range of +/- 8g’s on the Z axis
    /// </summary>
    [XmlElement("ZAxisAcceleration")]
    public float ZAxisAcceleration
    {
      get
      {
        if (zAxisAcceleration.HasValue)
        {
          return zAxisAcceleration.Value;
        }
        else
        {
          return -1;
        }
      }

      set { zAxisAcceleration = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeZAxisAcceleration()
    {
      return zAxisAcceleration.HasValue;
    }
  }
}
