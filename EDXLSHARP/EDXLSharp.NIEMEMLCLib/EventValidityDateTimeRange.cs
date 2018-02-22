//-----------------------------------------------------------------------
// <copyright file="EventValidityDateTimeRange.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the range in which an event is valid
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class EventValidityDateTimeRange
  {
    /// <summary>
    /// Starting date and time of the interval
    /// </summary>
    private DateTime startDate;

    /// <summary>
    /// Ending date and time of the interval
    /// </summary>
    private DateTime endDate;

    /// <summary>
    /// Gets or sets the starting date and time of the interval
    /// </summary>
    [XmlIgnore]
    public DateTime StartDate
    {
      get
      {
        return this.startDate;
      }

      set
      {
        this.startDate = value;
      }
    }

    /// <summary>
    /// Gets or sets the ending date and time of the interval
    /// </summary>
    [XmlIgnore]
    public DateTime EndDate
    {
      get
      {
        return this.endDate;
      }

      set
      {
        this.endDate = value;
      }
    }

    /// <summary>
    /// Gets or sets the serialization value for the starting date and time
    /// </summary>
    [XmlElement(ElementName = "StartDate", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("StartDate")]
    public NIEMDateTime SerialStartDate
    {
      get
      {
        return new NIEMDateTime(this.startDate);
      }

      set
      {
        this.startDate = value.DateTime;
      }
    }

    /// <summary>
    /// Gets or sets the serialization value for the ending date and time
    /// </summary>
    [XmlElement(ElementName = "EndDate", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("EndDate")]
    public NIEMDateTime SerialEndDate
    {
      get
      {
        return new NIEMDateTime(this.endDate);
      }

      set
      {
        this.endDate = value.DateTime;
      }
    }
  }
}
