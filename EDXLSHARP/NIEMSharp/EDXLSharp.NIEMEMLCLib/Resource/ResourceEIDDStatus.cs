using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Resource
{
  /// <summary>
  /// EIDD Resource Status Wrapper
  /// </summary>
  [Serializable]
  public class ResourceEIDDStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the resource type code
    /// </summary>
    [XmlElement(ElementName ="ResourceEIDDCode")]
    public ResourceEIDDStatusCodeList EIDDCode      
    {
      get; set;
    }
  }
}
