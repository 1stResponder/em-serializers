using System.Xml.Serialization;

namespace EMS.EDXL.Shared
{
  /// <summary>
  /// Abstract class for EDXL location types
  /// </summary>
  [XmlInclude(typeof(EDXLGeoPoliticalLocation))]
  public abstract class EDXLLocationType
  {
  }
}
