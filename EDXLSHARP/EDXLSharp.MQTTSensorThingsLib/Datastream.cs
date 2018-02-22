
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    Datastream
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API Datastream.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// 
  /// A Datastream groups a collection of Observations and the Observations in a Datastream 
  /// measure the same ObservedProperty and are produced by the same Sensor.
  /// 
  /// Updates:  none
  /// </summary>
  public class Datastream
  {
    /// <summary>
    /// The system-generated identifier of this Datastream.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this Datastream. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// This is a short description of the Datastream.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// A JSON Object containing three keyvalue pairs. The name property
    /// presents the full name of the unitOfMeasurement; the symbol 
    /// property shows the textual form of the unit symbol; and the definition
    /// contains the IRI defining the unitOfMeasurement.
    /// The values of these properties SHOULD follow the Unified Code for Unit of Measure(UCUM).
    /// </summary>
    [JsonProperty("unitOfMeasurement")]
    public JObject UnitOfMeasurement { get; set; }

    /// <summary>
    /// The type of Observation (with unique result type), which is used 
    /// by the service to encode observations.
    /// </summary>
    [JsonProperty("observationType")]
    public string ObservationType { get; set; }

    /// <summary>
    /// Related Sensor for this Datastream.
    /// </summary>
    [JsonProperty("Sensor")]
    public Sensor Sensor { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of the related Sensor.
    /// </summary>
    [JsonProperty("Sensor@iot.navigationLink")]
    public string SensorNavLink { get; set; }

    /// <summary>
    /// Related ObservedProperty for this Datastream.
    /// </summary>
    [JsonProperty("ObservedProperty")]
    public ObservedProperty ObservedProperty { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of the related ObservedProperty.
    /// </summary>
    [JsonProperty("ObservedProperty@iot.navigationLink")]
    public string ObservedPropertyNavLink { get; set; }

    /// <summary>
    /// Related Thing for this Datastream.
    /// </summary>
    [JsonProperty("Thing@iot.navigationLink")]
    public string ThingNavLink { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of the related Observations.
    /// </summary>
    [JsonProperty("Observations@iot.navigationLink")]
    public string ObservationsNavLink { get; set; }

  }
}
