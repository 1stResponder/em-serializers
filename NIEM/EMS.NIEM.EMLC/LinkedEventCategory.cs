//-----------------------------------------------------------------------
// <copyright file="LinkedEventCategory.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Represents the category of a linked event
  /// </summary>
  [Serializable]
  [JsonObject(MemberSerialization.OptIn)]
  public class LinkedEventCategory
  {
    List<string> eventTypeDescriptorExtension;
    EventTypeCodeList eventTypeCode;

    /// <summary>
    /// Initializes a new instance of the LinkedEventCategory class
    /// </summary>
    public LinkedEventCategory()
    {
    }

    /// <summary>
    /// Gets/sets eventTypeCode member
    /// </summary>
    [XmlIgnore]
    public EventTypeCodeList EventTypeCode
    {
      get { return eventTypeCode; }
      set { eventTypeCode = value; }
    }

    /// <summary>
    /// Gets or sets the serialization value for the event type code
    /// </summary>
    [XmlElement(ElementName = "EventTypeCode", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeCode")]
    public string EventTypeCodeString
    {
      get
      {
        return eventTypeCode.ToString().Replace('_', '.');
      }

      set
      {
        eventTypeCode = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
      }
    }

    /// <summary>
    /// Gets or sets the type code description extension
    /// </summary>
    [XmlElement(ElementName = "EventTypeDescriptorExtension", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeDescriptorExtension")]
    public List<string> EventTypeDescriptorExtension
    {
      get { return eventTypeDescriptorExtension; }
      set { eventTypeDescriptorExtension = value; }
    }

    /// <summary>
    /// Controls serialization of Event Type Descriptor Extension member
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeEventTypeDescriptorExtension()
    {
      return eventTypeDescriptorExtension != null && eventTypeDescriptorExtension.Count > 0;
    }
  }
}