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

namespace NIEMSHARP.NIEMEMLCLib
{
  /// <summary>
  /// Represents the category of a linked event
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class LinkedEventCategory
  {
    /// <summary>
    /// Initializes a new instance of the LinkedEventCategory class
    /// </summary>
    public LinkedEventCategory()
    {
    }

    /// <summary>
    /// Gets or sets the event type code for this link
    /// </summary>
    [XmlIgnore]
    public EventTypeCodeList EventTypeCode
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for the event type code
    /// </summary>
    [XmlElement(ElementName = "EventTypeCode", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventTypeCode")]
    public string SerialEventTypeCode
    {
      get
      {
        return this.EventTypeCode.ToString().Replace('_', '.');
      }

      set
      {
        this.EventTypeCode = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
      }
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