//-----------------------------------------------------------------------
// <copyright file="EventLink.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
  /// <summary>
  /// Allows for two or more events to be associated
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class EventLink
  {
    /// <summary>
    /// Initializes a new instance of the EventLink class
    /// </summary>
    public EventLink()
    {
      this.SerialLinkedEventID = new IdentificationID();
      this.LinkedEventCategory = new LinkedEventCategory();
    }

    /// <summary>
    /// Gets or sets Unique ID of the linked event
    /// </summary>
    [XmlIgnore]
    public string LinkedEventID
    {
      get
      {
        return this.SerialLinkedEventID.ID;
      }

      set
      {
        this.SerialLinkedEventID = new IdentificationID(value);
      }
    }

    /// <summary>
    /// Gets or sets the serialization value for the linked ID
    /// </summary>
    [XmlElement(ElementName = "LinkedEventID", Namespace = Constants.EmeventNamespace, Order = 0)]
    [JsonProperty("LinkedEventID")]
    public IdentificationID SerialLinkedEventID
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the category of the linked event
    /// </summary>
    [XmlElement(Namespace = Constants.EmeventNamespace, Order = 1)]
    [JsonProperty]
    public LinkedEventCategory LinkedEventCategory
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the code for the link relation or type
    /// </summary>
    [XmlIgnore]
    public EventLinkRelationCodeList EventLinkRelationCode
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for the link type
    /// </summary>
    [XmlElement(ElementName = "EventLinkRelationCode", Namespace = Constants.EmeventNamespace, Order = 2)]
    [JsonProperty("EventLinkRelationCode")]
    public string SerialEventLinkRelationCode
    {
      get
      {
        return this.EventLinkRelationCode.ToString().Replace('_', '.');
      }

      set
      {
        this.EventLinkRelationCode = (EventLinkRelationCodeList)Enum.Parse(typeof(EventLinkRelationCodeList), value.Replace('.', '_'));
      }
    }
  }
}
