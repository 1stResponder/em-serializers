using EMS.NIEM.NIEMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.Resource
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

    public override string GetSecondaryStatusText()
    {
      return $"UCADCode:  {UCADCode.ToString()}";
    }
  }
}