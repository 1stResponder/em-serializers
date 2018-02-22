//-----------------------------------------------------------------------
// <copyright file="LinkedEventCategory.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the category of a linked event
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class LinkedEventCategory
  {
        //private EventTypeSerial _eventTypeSerial;

        /// <summary>
        /// Initializes a new instance of the LinkedEventCategory class
        /// </summary>
        public LinkedEventCategory()
    {
      this.EventTypeDescriptorExtension = new List<string>();
    }

    /// <summary>
    /// Gets or sets the event type code for this link
    /// </summary>
    //[XmlIgnore]
    //public ValueList EventTypeCode //EventTypeCodeList
    //    {
    //        get;set;
    //        //get { return _eventTypeSerial.Value; }
    //        //set { this._eventTypeSerial = new EventTypeSerial(value); }
    //    }

    /// <summary>
    /// Gets or sets the serialization value for the event type code
    /// </summary>
    [XmlElement(ElementName = "EventTypeCode", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeCode")]
    public ValueList EventTypeCode//SerialEventTypeCode
        {
            get; set;
        //get
        //{
        //        return this._eventTypeSerial.SerialValue;
        //    }

        //set
        //{
        //        this._eventTypeSerial = new EventTypeSerial(value);//(EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
        //    }
    }

    /// <summary>
    /// Gets or sets the type code description extension
    /// </summary>
    [XmlIgnore]
    public List<string> EventTypeDescriptorExtension
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for the type code description extension
    /// </summary>
    [XmlElement(ElementName = "EventTypeDescriptorExtension", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeDescriptorExtension")]
    public string[] SerialEventTypeDescriptorExtension
    {
      get
      {
        return this.EventTypeDescriptorExtension.ToArray();
      }

      set
      {
        this.EventTypeDescriptorExtension = new List<string>(value);
      }
    }
  }
}