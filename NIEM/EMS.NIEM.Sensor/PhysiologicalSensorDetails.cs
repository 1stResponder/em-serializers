using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Base class for physiological sensor information
  /// </summary>
  [Serializable]
  public class PhysiologicalSensorDetails
  {
    private int? heartRate;
    private int? skinTemperature;
    private int? respirationRate;
    private int? spO2;
    private int? psi;

    /// <summary>
    /// Number of cardiac cycles (beats) per minute
    /// </summary>
    [XmlElement("HeartRate")]
    public int HeartRate
    {
      get
      {
        if (heartRate.HasValue)
        {
          return heartRate.Value;
        }
        else
        {
          return -1;
        }
      }

      set { heartRate = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeHeartRate()
    {
      return heartRate.HasValue;
    }

    /// <summary>
    /// Skin temperature in Fahrenheit multiplied by 10
    /// (for single digit decimal precision).
    /// </summary>
    [XmlElement("SkinTemperature")]
    public int SkinTemperature
    {
      get
      {
        if (skinTemperature.HasValue)
        {
          return skinTemperature.Value;
        }
        else
        {
          return -1;
        }
      }

      set { skinTemperature = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeSkinTemperature()
    {
      return skinTemperature.HasValue;
    }

    /// <summary>
    /// Number of respiration cycles (breaths) per minute
    /// </summary>
    [XmlElement("RespirationRate")]
    public int RespirationRate
    {
      get
      {
        if (respirationRate.HasValue)
        {
          return respirationRate.Value;
        }
        else
        {
          return -1;
        }
      }

      set { respirationRate = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeRespirationRate()
    {
      return respirationRate.HasValue;
    }

    /// <summary>
    /// Blood oxygenation percentage.
    /// </summary>
    [XmlElement("SPO2")]
    public int SPO2
    {
      get
      {
        if (spO2.HasValue)
        {
          return spO2.Value;
        }
        else
        {
          return -1;
        }
      }

      set { spO2 = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeSPO2()
    {
      return spO2.HasValue;
    }

    /// <summary>
    /// Physical Strain Index value multiplied by 10 
    /// (for single digit decimal precision)
    /// </summary>
    [XmlElement("PSI")]
    public int PSI
    {
      get
      {
        if (psi.HasValue)
        {
          return psi.Value;
        }
        else
        {
          return -1;
        }
      }

      set { psi = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializePSI()
    {
      return psi.HasValue;
    }
  }
}
