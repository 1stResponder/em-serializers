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
  public class XYLocationSensorDetails
  {
    private string xCoordinate;
    private string yCoordinate;
    private float? accuracy;
    private float? heading;
    private int? velocity;
    private float? xAxisAcceleration;
    private float? yAxisAcceleration;

    /// <summary>
    /// X coordinate of an object
    /// </summary>
    [XmlElement("XCoordinate")]
    public string XCoordinate
    {
      get { return xCoordinate; }
      set { xCoordinate = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeXCoordinate()
    {
      return !string.IsNullOrWhiteSpace(xCoordinate);
    }

    /// <summary>
    /// Y coordinate of an object
    /// </summary>
    [XmlElement("YCoordinate")]
    public string YCoordinate
    {
      get { return yCoordinate; }
      set { yCoordinate = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeYCoordinate()
    {
      return !string.IsNullOrWhiteSpace(yCoordinate);
    }

    /// <summary>
    /// Estimated accuracy of the X and Y coordinates as a percentage
    /// </summary>
    [XmlElement("Accuracy")]
    public float Accuracy
    {
      get
      {
        if (accuracy.HasValue)
        {
          return accuracy.Value;
        }
        else
        {
          return -1;
        }
      }

      set { accuracy = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeAccuracy()
    {
      return accuracy.HasValue;
    }

    /// <summary>
    /// Heading of an object in decimal degree format 
    /// </summary>
    [XmlElement("Heading")]
    public float Heading
    {
      get
      {
        if (heading.HasValue)
        {
          return heading.Value;
        }
        else
        {
          return -1;
        }
      }

      set { heading = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeHeading()
    {
      return heading.HasValue;
    }

    /// <summary>
    /// Calculated velocity of an object in feet per second (f/s)
    /// </summary>
    [XmlElement("Velocity")]
    public int Velocity
    {
      get
      {
        if (velocity.HasValue)
        {
          return velocity.Value;
        }
        else
        {
          return -1;
        }
      }

      set { velocity = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeVelocity()
    {
      return velocity.HasValue;
    }

    /// <summary>
    /// Acceleration in the range of +/- 8g’s on the X axis
    /// </summary>
    [XmlElement("XAxisAcceleration")]
    public float XAxisAcceleration
    {
      get
      {
        if (xAxisAcceleration.HasValue)
        {
          return xAxisAcceleration.Value;
        }
        else
        {
          return -1;
        }
      }

      set { xAxisAcceleration = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeXAxisAcceleration()
    {
      return xAxisAcceleration.HasValue;
    }

    /// <summary>
    /// Acceleration in the range of +/- 8g’s on the Y axis
    /// </summary>
    [XmlElement("YAxisAcceleration")]
    public float YAxisAcceleration
    {
      get
      {
        if (yAxisAcceleration.HasValue)
        {
          return yAxisAcceleration.Value;
        }
        else
        {
          return -1;
        }
      }

      set { yAxisAcceleration = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeYAxisAcceleration()
    {
      return yAxisAcceleration.HasValue;
    }
  }
}
