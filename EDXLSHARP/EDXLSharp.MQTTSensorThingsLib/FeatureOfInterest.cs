using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    FeatureOfInterest
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API FeatureOfInterest.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// An Observation results in a value being assigned to a phenomenon. The phenomenon is a property of a
  /// feature, the latter being the FeatureOfInterest of the Observation[OGC and ISO 19156:2001]. In the
  /// context of the Internet of Things, many Observations’ FeatureOfInterest can be the Location of the
  /// Thing.For example, the FeatureOfInterest of a wifi-connect thermostat can be the Location of the
  /// thermostat (i.e., the living room where the thermostat is located in). In the case of remote sensing, the
  /// FeatureOfInterest can be the geographical area or volume that is being sensed.
  /// 
  /// Updates:  none
  /// </summary>
  public class FeatureOfInterest
  {
    /// <summary>
    /// The system-generated identifier of this FeatureOfInterest.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this FeatureOfInterest. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// This is a short description of the FeatureOfInterest.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// The encoding type of the feature property.
    /// Its value is one of the ValueCode enumeration
    /// </summary>
    [JsonProperty("encodingtype")]
    public string EncodingType { get; set; }

    private JObject feature;

    /// <summary>
    /// The detailed description of the feature. The data type is defined by encodingType.
    /// </summary>
    [JsonProperty("feature")]
    [XmlIgnoreAttribute]
    public JObject Feature
    {
      get { return feature; }
      set
      {
        feature = value;
        FeatureString = value.ToString();
      }
    }

    /// <summary>
    /// The string representation of the feature information.
    /// The detailed description of the feature. The data type is defined by encodingType.
    /// </summary>
    public string FeatureString { get; set; }

    /// <summary>
    /// The related Datastreams for this FeatureOfInterest.
    /// </summary>
    [JsonProperty("Datastreams")]
    [XmlIgnoreAttribute]
    public List<Datastream> Datastreams { get; set; }

    /// <summary>
    /// The related Observations for this FeatureOfInterest.
    /// </summary>
    [JsonProperty("Observations")]
    [XmlIgnoreAttribute]
    public List<Observation> Observations { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Observations.
    /// </summary>
    [JsonProperty("Observations@iot.navigationLink")]
    public string ObservationsNavLink { get; set; }

  }
}
