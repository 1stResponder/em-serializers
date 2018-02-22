using System;

namespace EDXLSharp.MQTTSensorThingsLib
{
  /// <summary>
  /// Class:    DateTimeInterval
  /// Project:  EDXLSharp.MQTTSensorThingsLib
  /// Purpose:  Implementation of a flexible DateTime interval to support SensorThings API.
  /// See https://en.wikipedia.org/wiki/ISO_8601#Time_intervals
  /// We are only supporting begin and end not duration. 
  /// Created:  2016-05-31
  /// Author:   Marc Stogner - ArdentMC
  /// Parses some of the variable time interval strings used by the SensorThings API and turns them into more useful objects.
  /// Updates:  none
  /// </summary>
  public class DateTimeInterval
  {
    private string rawDateTime;

    /// <summary>
    /// Default constructor
    /// </summary>
    public DateTimeInterval() { }

    /// <summary>
    /// Constructor that takes a time interval string to process.
    /// </summary>
    /// <param name="interval"></param>
    public DateTimeInterval(string interval)
    {
      this.rawDateTime = interval;
      if (interval != null && interval.Length > 0)
      {
        if (interval.IndexOf('/') > 0)  // date range
        {
          // parse it
          string[] dates = interval.Split('/');
          BeginDateTime = DateTime.Parse(dates[0]);
          if (dates.Length == 2)
          {
            EndDateTime = DateTime.Parse(dates[1]);
          }
        }
        else // just the begin time
        {
          BeginDateTime = DateTime.Parse(interval);
        }
      }
    }

    /// <summary>
    /// The interval begin time found (if any)
    /// </summary>
    public DateTime? BeginDateTime { get; set; }

    /// <summary>
    /// The interval end time found (if any)
    /// </summary>
    public DateTime? EndDateTime { get; set; }

    /// <summary>
    /// The raw date time string that was parsed to create the interval data.
    /// </summary>
    public string RawDateTime
    {
      get { return rawDateTime; }
      set { rawDateTime = value; }
    }

  }
}
