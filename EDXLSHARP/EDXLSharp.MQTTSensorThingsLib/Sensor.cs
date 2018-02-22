using System.Collections.Generic;
using Newtonsoft.Json;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    Sensor
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API Sensor.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// A Sensor is an instrument that observes a property or phenomenon with the goal of producing 
  /// an estimate of the value of the property.
  /// 
  /// Updates:  none
  /// </summary>
  public class Sensor
  {
    /// <summary>
    /// The system-generated identifier of this Sensor.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this Sensor. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// This is a short description of the Sensor.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// The encoding type of the metadata property.
    /// Its value is one of the ValueCode enumeration.
    /// </summary>
    [JsonProperty("encodingtype")]
    public string EncodingType { get; set; }

    /// <summary>
    /// The detailed description of the Sensor  or system.
    /// The metadata type is defined by encodingType.
    /// </summary>
    [JsonProperty("metadata")]
    public string Metadata { get; set; }

    /// <summary>
    /// The related Datastreams for this Sensor.
    /// </summary>
    public List<Datastream> Datastreams { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Datastreams.
    /// </summary>
    [JsonProperty("Datastreams@iot.navigationLink")]
    public string DatastreamsNavLink { get; set; }

  }
}
