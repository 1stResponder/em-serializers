using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents the TextStatus
  /// </summary>
  [Serializable]
  public class TextStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the source identifier for this text status, if there is one
    /// </summary>
    [XmlAttribute(AttributeName = "codespaceID", Namespace = Constants.MoNamespace)]
    [JsonProperty(PropertyName = "@codespaceID")]
    public string SourceID
    {
      get; set;
    }

    /// <summary>
    /// Controls the serialization of the optional attribute "SourceID"
    /// </summary>
    /// <returns>Whether or not to serialize the attribute</returns>
    public bool SourceIDSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.SourceID); }
    }

    /// <summary>
    /// Gets or sets the source identifier for this text status
    /// </summary>
    [XmlText]
    public string Description
    {
      get; set;
    }

    public override string GetSecondaryStatusText()
    {
      string sSecondaryText = String.Empty;

      if(!String.IsNullOrWhiteSpace(SourceID))
      {
        sSecondaryText += $"SourceID: {SourceID}, ";
      }

      sSecondaryText += $"Description: {Description}";

      return sSecondaryText;
    }
  }
}
