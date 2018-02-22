//-----------------------------------------------------------------------
// <copyright file="IdentificationID.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the identifier
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class IdentificationID
  {
    /// <summary>
    /// Initializes a new instance of the IdentificationID class
    /// </summary>
    public IdentificationID()
    {
    }

    /// <summary>
    /// Initializes a new instance of the IdentificationID class
    /// </summary>
    /// <param name="id">Identifier to initialize</param>
    public IdentificationID(string id)
    {
      this.ID = id;
    }

    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    [XmlElement(ElementName = "IdentificationID", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("IdentificationID")]
    public string ID
    {
      get; set;
    }
  }
}