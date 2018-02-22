using System.Collections.Generic;
using Newtonsoft.Json;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    ObservedProperty
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API ObservedProperty.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// An ObservedProperty specifies the phenomenon of an Observation.
  /// Updates:  none
  /// </summary>
  public class ObservedProperty
  {
    /// <summary>
    /// The system-generated identifier of this ObservedProperty.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this ObservedProperty. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// This is a short description of the ObservedProperty.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// The Internationalized Resource Identifier (IRI) of the ObservedProperty.
    /// Dereferencing this IRI SHOULD result in a representation of the definition of the ObservedProperty.
    /// </summary>
    [JsonProperty("definition")]
    public string Definition { get; set; }

    /// <summary>
    /// The related Datastreams for this ObservedProperty.
    /// </summary>
    public List<Datastream> Datastreams { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Datastreams.
    /// </summary>
    [JsonProperty("Datastreams@iot.navigationLink")]
    public string DatastreamsNavLink { get; set; }

  }
}
