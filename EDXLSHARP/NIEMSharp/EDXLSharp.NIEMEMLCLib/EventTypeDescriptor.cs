//-----------------------------------------------------------------------
// <copyright file="EventTypeDescriptor.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
  /// <summary>
  /// Description of an event
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class EventTypeDescriptor
  {
    /// <summary>
    /// Initializes a new instance of the EventTypeDescriptor class
    /// </summary>
    public EventTypeDescriptor()
    {
    }

    /// <summary>
    /// Gets or sets the event type code
    /// </summary>
    [XmlIgnore]
    public EventTypeCodeList CodeValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value of the event type code
    /// </summary>
    [XmlElement(Namespace = Constants.EmeventNamespace)]
    [JsonProperty]
    public string EventTypeCode
    {
      get
      {
        return this.CodeValue.ToString().Replace('_', '.');
      }

      set
      {
        this.CodeValue = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
      }
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