using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// EIDD Resource Status Wrapper
  /// </summary>
  [Serializable]
  public class ResourceEIDDStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the resource type code
    /// Required Element
    /// </summary>
    [XmlElement(ElementName ="ResourceEIDDCode")]
    public ResourceEIDDStatusCodeList EIDDCode      
    {
      get; set;
    }
  }
}
