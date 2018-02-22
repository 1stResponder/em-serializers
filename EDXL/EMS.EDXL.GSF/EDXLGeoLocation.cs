using EMS.EDXL.Shared;
using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class EDXLGeoLocation : EDXLLocationType
  {
    [XmlElement("EDXLGeoLocation")]
    GMLShape shape { get; set; }
  }
}
