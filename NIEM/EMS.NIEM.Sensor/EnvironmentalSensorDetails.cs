using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Base class for serializing environmental sensor information
  /// </summary>
  [Serializable]
  public class EnvironmentalSensorDetails
  {
    private int? temperature;
    private int? pressure;
    private int? humidity;

    /// <summary>
    /// Environmental temperature in Fahrenheit multiplied by 10 
    /// (for single digit decimal precision)
    /// </summary>
    [XmlElement("Temperature")]
    public int Temperature
    {
      get
      {
        if (temperature.HasValue)
        {
          return temperature.Value;
        }
        else
        {
          return -1;
        }
      }

      set { temperature = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeTemperature()
    {
      return temperature.HasValue;
    }

    /// <summary>
    /// Environmental pressure in PSI multiplied by 10 
    /// (for single digit decimal precision)
    /// </summary>
    [XmlElement("Pressure")]
    public int Pressure
    {
      get
      {
        if (pressure.HasValue)
        {
          return pressure.Value;
        }
        else
        {
          return -1;
        }
      }


      set { pressure = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializePressure()
    {
      return pressure.HasValue;
    }

    /// <summary>
    /// Environmental humidity percentage
    /// </summary>
    [XmlElement("Humidity")]
    public int Humidity
    {
      get
      {
        if (humidity.HasValue)
        {
          return humidity.Value;
        }
        else
        {
          return -1;
        }
      }


      set { humidity = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeHumidity()
    {
      return humidity.HasValue;
    }
  }
}
