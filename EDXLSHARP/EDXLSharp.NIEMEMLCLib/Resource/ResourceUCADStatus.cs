using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// UCAD Resource Status Wrapper
  /// </summary>
  [Serializable]
  public class ResourceUCADStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the resource type code
    /// Required
    /// </summary>
    [XmlElement(ElementName = "ResourceUCADCode")]
    public ResourceUCADStatusCodeList UCADCode
    {
      get; set;
    }
  }
}
