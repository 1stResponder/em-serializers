using Newtonsoft.Json;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    HistoricalLocation
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API HistoricalLocation.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// 
  ///  Previous location of a Thing with their time.
  /// Updates:  none
  /// </summary>
  public class HistoricalLocation
  {
    /// <summary>
    /// The system-generated identifier of this HistoricalLocation.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this HistoricalLocation. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// The time when the Thing is known at the location.
    /// TM_Instant (ISO-8601 Time String)
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of the related Thing.
    /// </summary>
    [JsonProperty("Thing@iot.navigationLink")]
    public string ThingNavLink { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Locations.
    /// </summary>
    [JsonProperty("Locations@iot.navigationLink")]
    public string LocationsNavLink { get; set; }

  }
}
