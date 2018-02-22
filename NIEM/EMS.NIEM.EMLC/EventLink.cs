//-----------------------------------------------------------------------
// <copyright file="EventLink.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Allows for two or more events to be associated
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  [Serializable]
  public class EventLink
  {
    IdentificationID linkedID;
    LinkedEventCategory linkedCategory;
    EventLinkRelationCodeList linkedEventRelationToMe;

    /// <summary>
    /// Initializes a new instance of the EventLink class
    /// </summary>
    public EventLink()
    {
      this.linkedID = new IdentificationID();
    }

    /// <summary>
    /// Gets or sets ID of the linkedID member
    /// </summary>
    [XmlIgnore]
    public string LinkedEventID
    {
      get { return linkedID.ID; }
      set { this.linkedID = new IdentificationID(value); }
    }

    //TODO: collapse these methods into one
    /// <summary>
    /// Gets or sets the linkedID member
    /// </summary>
    [XmlElement(ElementName = "LinkedEventID", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("LinkedEventID")]
    public IdentificationID SerialLinkedEventID
    {
      get { return linkedID; }
      set { linkedID = value; }
    }

    /// <summary>
    /// Gets or sets the code for the link relation to Me
    /// </summary>
    [XmlIgnore]
    public EventLinkRelationCodeList EventLinkRelationCode
    {
      get { return linkedEventRelationToMe; }
      set { linkedEventRelationToMe = value; }
    }

    /// <summary>
    /// Gets or sets the serialization value for the link type
    /// </summary>
    [XmlElement(ElementName = "EventLinkRelationCode", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("EventLinkRelationCode")]
    public string SerialEventLinkRelationCode
    {
      get
      {
        return linkedEventRelationToMe.ToString().Replace('_', '.');
      }

      set
      {
        linkedEventRelationToMe = (EventLinkRelationCodeList)Enum.Parse(typeof(EventLinkRelationCodeList), value.Replace('.', '_'));
      }
    }

    /// <summary>
    /// Gets or sets the category of the linked event
    /// </summary>
    [XmlElement(ElementName = "LinkedEventCategory", Namespace = Constants.EmeventNamespace)]
    [JsonProperty("LinkedEventCategory")]
    public LinkedEventCategory LinkedEventCategory
    {
      get { return linkedCategory; }
      set { linkedCategory = value; }
    }

    /// <summary>
    /// Controls serialization of linkedCategory member
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeLinkedEventCategory()
    {
      return linkedCategory != null;
    }
  }
}
