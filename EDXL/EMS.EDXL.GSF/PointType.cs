using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class PointType
  {
    [XmlElement("pos")]
    public PosType pos { get; set; }
  }
}
