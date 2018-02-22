using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class CircleByCenterPointType
  {
    [XmlElement("pos")]
    public PosType pos { get; set; }

    [XmlElement("radius")]
    public MeasureType radius { get; set; }
  }
}
