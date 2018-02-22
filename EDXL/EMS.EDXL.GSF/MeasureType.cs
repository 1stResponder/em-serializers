using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class MeasureType
  {
    [XmlText]
    public double Value { get; set; }

    [XmlAttribute("Uom")]
    public string Uom { get; set; }
  }
}
