using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    Location
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API Location.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// 
  /// The location of the Thing.
  /// Updates:  none
  /// </summary>
  public class Location
  {
    /// <summary>
    /// The system-generated identifier of this Location.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this Location. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// The description about the Location.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// The encoding type of the location property.
    /// </summary>
    [JsonProperty("encodingtype")]
    public string EncodingType { get; set; }

    /// <summary>
    /// The location information.
    /// </summary>
    [JsonProperty("location")]
    public JObject LocationJson { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Thing or Things.
    /// </summary>
    [JsonProperty("Things@iot.navigationLink")]
    public string ThingsNavLink { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related HistoricalLocations.
    /// </summary>
    [JsonProperty("HistoricalLocations@iot.navigationLink")]
    public string HistoricalLocationsNavLink { get; set; }

  }
}
