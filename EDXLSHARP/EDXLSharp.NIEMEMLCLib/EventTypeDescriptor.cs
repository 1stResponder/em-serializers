//-----------------------------------------------------------------------
// <copyright file="EventTypeDescriptor.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Description of an event
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class EventTypeDescriptor
  {
        //private EventTypeSerial _eventTypeSerial;

    /// <summary>
    /// Initializes a new instance of the EventTypeDescriptor class
    /// </summary>
    public EventTypeDescriptor()
    {
      this.EventTypeDescriptorExtension = new List<string>();
    }

        /// <summary>
        /// Gets or sets the event type code
        /// </summary>
        //[XmlIgnore]
        //public ValueList CodeValue // CodeValue
        //{
        //    get; set;
        //}

        // This returns a string that is the concatenation of all strings
        // in EventTypeDescriptorExtension
        private string GetSummaryBasedOnEventTypeDescriptorExtension()
        {
            if (this.EventTypeDescriptorExtension != null
                && this.EventTypeDescriptorExtension.Count > 0)
                return this.EventTypeDescriptorExtension[0];

            return "";

            //StringBuilder sb = new StringBuilder();

            //foreach (string s in this.EventTypeDescriptorExtension)
            //{
            //    sb.Append(s);
            //    sb.Append(", ");
            //}

            //if (sb.Length > 0)
            //    sb.Length -= 2; // remove last ", "

            //return sb.ToString();
        }

        /// <summary>
        /// Returns a string that is a summary of all associated underlying event types
        /// </summary>
        [XmlIgnore]
        public string EventTypeSummary // what should this be for
        {
            get
            {
                //if (this.EventTypeDescriptorExtension != null
                //    && this.EventTypeDescriptorExtension.Count > 0)
                    return GetSummaryBasedOnEventTypeDescriptorExtension();

                // otherwise return the summary as composed from the EventTypeCode object (not from the EventTypeDescriptorExtension)
                //return this.EventTypeCode.ValueSummary;
            }
        }

    /// <summary>
    /// Gets or sets the serialization value of the event type code
    /// </summary>
    [XmlElement(Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeCode")]
    public ValueList EventTypeCode // was EventTypeCode - but inconsistent with LinkedEventCategory
        {
            get;set;
      //get
      //{
      //          return this._eventTypeSerial.SerialValue; //CodeValue.ToString().Replace('_', '.');
      //}

      //set
      //{
      //          this._eventTypeSerial = new EventTypeSerial(value);  // (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
      //}
    }

    /// <summary>
    /// Gets or sets the description extension
    /// </summary>
    [XmlIgnore]
    public List<string> EventTypeDescriptorExtension
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value of the event extension
    /// </summary>
    [XmlElement(ElementName = "EventTypeDescriptorExtension", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeDescriptorExtension")]
    public string[] SerialEventTypeDescriptorExtension
    {
      get
      {
        if (this.EventTypeDescriptorExtension == null)
        {
          return null;
        }
        else
        {
          return this.EventTypeDescriptorExtension.ToArray();
        }
      }

      set
      {
        if (value == null)
        {
        }
        else
        {
          this.EventTypeDescriptorExtension = new List<string>(value);
        }
      }
    }
  }
}