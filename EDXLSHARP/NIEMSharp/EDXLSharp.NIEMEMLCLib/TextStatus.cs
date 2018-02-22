using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class TextStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the source identifier for this text status, if there is one
    /// </summary>
    [XmlAttribute(AttributeName ="SourceID")]
    [JsonProperty(PropertyName ="@SourceID")]
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
    [XmlElement(ElementName = "Description")]
    public string Description
    {
      get; set;
    }

  }
}
