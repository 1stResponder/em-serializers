using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    Thing
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API Thing.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  ///
  /// A Thing in SensorThings represents a physical object in the real world. 
  /// A Thing has a Location and one or more Datastreams to collect Observations.
  /// 
  /// Updates:  none
  /// </summary>
  public class Thing
  {
    /// <summary>
    /// The system-generated identifier of this Thing.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this Thing. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// This is a short description of the Thing.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// A JSON Object containing user-annotated properties as key-value pairs.
    /// </summary>
    [JsonProperty("properties")]
    public JObject Properties { get; set; }

    /// <summary>
    /// Related Locations for this Thing.
    /// </summary>
    public List<Location> Locations { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Locations.
    /// </summary>
    [JsonProperty("Locations@iot.navigationLink")]
    public string LocationsNavLink { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related HistoricalLocations.
    /// </summary>
    [JsonProperty("HistoricalLocations@iot.navigationLink")]
    public string HistoricalLocationsNavLink { get; set; }

    /// <summary>
    /// The related Datastreams for this Thing.
    /// </summary>
    public List<Datastream> Datastreams { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Datastreams.
    /// </summary>
    [JsonProperty("Datastreams@iot.navigationLink")]
    public string DatastreamsNavLink { get; set; }

  }
}
