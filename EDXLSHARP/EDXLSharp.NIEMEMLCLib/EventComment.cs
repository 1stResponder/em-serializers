//-----------------------------------------------------------------------
// <copyright file="EventComment.cs" company="EDXLSharp">
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
  /// Represents a single comment for an event
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class EventComment
  {
    /// <summary>
    /// Gets or sets the date and time of the comment
    /// </summary>
    [XmlElement(Namespace = Constants.NiemcoreNamespace, Order = 0)]
    [JsonProperty]
    public DateTime DateTime
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the organization ID
    /// </summary>
    [XmlIgnore]
    public string OrganizationIdentification
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for the organization ID
    /// </summary>
    [XmlElement(ElementName = "OrganizationIdentification", Namespace = Constants.NiemcoreNamespace, Order = 1)]
    [JsonProperty("OrganizationIdentification")]
    public IdentificationID SerialOrganizationIdentification
    {
      get
      {
        return new EDXLSharp.NIEMEMLCLib.IdentificationID(this.OrganizationIdentification);
      }

      set
      {
        this.OrganizationIdentification = value.ID;
      }
    }

    /// <summary>
    /// Gets or sets the person identification of the person creating the comment
    /// </summary>
    [XmlIgnore]
    public string PersonHumanResourceIdentification
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization identification of the person creating the comment
    /// </summary>
    [XmlElement(ElementName = "PersonHumanResourceIdentification", Namespace = Constants.NiemcoreNamespace, Order = 2)]
    [JsonProperty("PersonHumanResourceIdentification")]
    public IdentificationID SerialPersonHumanResourceIdentification
    {
      get
      {
        return new IdentificationID(this.PersonHumanResourceIdentification);
      }

      set
      {
        this.PersonHumanResourceIdentification = value.ID;
      }
    }

    /// <summary>
    /// Gets or sets the text of the comment
    /// </summary>
    [XmlElement(Namespace = Constants.NiemcoreNamespace, Order = 3)]
    [JsonProperty]
    public string CommentText
    {
      get; set;
    }
  }
}
