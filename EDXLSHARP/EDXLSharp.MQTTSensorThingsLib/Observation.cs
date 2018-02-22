using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    Observation
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a SensorThings API Observation.
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// 
  /// An Observation in SensorThings represents a single Sensor reading of an ObservedProperty. 
  /// A physical device, a Sensor, sends Observations to a specified Datastream. An Observation requires a FeatureOfInterest entity, 
  /// if none is provided in the request, the Location of the Thing associated with the Datastream, 
  /// will be assigned to the new Observation as the FeatureOfInterest
  /// 
  /// Updates:  none
  /// </summary>
  [XmlRootAttribute("Observation", Namespace = Constants.STApiNamespace,IsNullable = false)]
  public class Observation
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Observation()
    {
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.STApiPrefix, Constants.STApiNamespace);
    }

    /// <summary>
    /// The system-generated identifier of this Observation.
    /// The Id is unique among the entities of the same entity type in a SensorThings service.
    /// </summary>
    [JsonProperty("@iot.id")]
    public long Id { get; set; }

    /// <summary>
    /// The absolute URL of this Observation. 
    /// </summary>
    [JsonProperty("@iot.selfLink")]
    public string SelfLink { get; set; }

    /// <summary>
    /// The estimated value of an ObservedProperty from the Observation.
    /// </summary>
    [JsonProperty("result")]
    public string Result { get; set; }

    /// <summary>
    /// Describes the quality of the result
    /// </summary>
    [JsonProperty("resultQuality")]
    public string ResultQuality { get; set; }

    /// <summary>
    /// Key-value pairs showing the environmental conditions during measurement.
    /// </summary>
    [JsonProperty("parameters")]
    public string Parameters { get; set; }
    
    /// <summary>
    /// The time of the Observation's result was generated. (might be null)
    /// TM_Instant(ISO 8601 Time string) (e.g.,2010-12-23T10:20:00.00-07:00)
    /// </summary>
    [JsonProperty("resultTime")]
    public DateTime? ResultTime { get; set; }

    private string phenomenonTime;

    /// <summary>
    /// The time instant or period of when the Observation happens. (mandatory)
    /// TM_Object(ISO 8601 Time string or Time Interval string
    /// (e.g.,2010-12-23T10:20:00.00-07:00 or 2010-12-23T10:20:00.00-07:00/2010-12-23T12:20:00.00-07:00))
    /// </summary>
    [JsonProperty("phenomenonTime")]
    public string PhenomenonTime
    {
      get { return phenomenonTime; }
      set
      {
        this.phenomenonTime = value;
        
        if (phenomenonTime != null && phenomenonTime.Length > 0)
        {
          this.PhenomenonInterval = new DateTimeInterval(value);
        }
      }
    }

    /// <summary>
    /// The optional time the Observation started.
    /// </summary>
    public DateTime? PhenomenonTimeStart { get; set; }

    /// <summary>
    /// The optional time the Observation ended.
    /// </summary>
    public DateTime? PhenomenonTimeEnd { get; set; }
    
    /// <summary>
    /// The time interval when the Observation happens.
    /// </summary>
    public DateTimeInterval PhenomenonInterval { get; set; }

    private  string validTime;

    /// <summary>
    /// The time period during which the result may be used. 
    /// TM_Period(ISO 8601 Time Interval string)
    /// </summary>
    [JsonProperty("validTime")]
    public string ValidTime
    {
      get { return validTime; }
      set
      {
        this.validTime = value;
        if (validTime != null && validTime.Length > 0)
        {
          this.ValidTimeInterval = new DateTimeInterval(value);
        }
      }
    }

    /// <summary>
    /// The optional time the data starts to be valid.
    /// </summary>
    public DateTime? ValidTimeStart { get; set; }

    /// <summary>
    /// The optional time the data ends being valid.
    /// </summary>
    public DateTime? ValidTimeEnd { get; set; }

    /// <summary>
    /// The interval that the data is valid.
    /// </summary>
    public DateTimeInterval ValidTimeInterval { get; set; }

    /// <summary>
    /// The related Datastream of this Observation.
    /// </summary>
    [JsonProperty("Datastream")]
    [XmlIgnoreAttribute]
    public List<Datastream> Datastream { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related Datastream.
    /// </summary>
    [JsonProperty("Datastream@iot.navigationLink")]
    public string DatastreamNavLink { get; set; }

    /// <summary>
    /// An Observation observes on one-and-only-one FeatureOfInterest.
    /// </summary>
    [JsonProperty("FeatureOfInterest")]
    public FeatureOfInterest FeatureOfInterest { get; set; }

    /// <summary>
    /// The relative URL that retrieves content of related FeatureOfInterest. 
    /// </summary>
    [JsonProperty("FeatureOfInterest@iot.navigationLink")]
    public string FeatureOfInterestNavLink { get; set; }


    /// <summary>
    /// Gets or sets Namespace object place for serializing prefixes for namespaces
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is supressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

  }
}
