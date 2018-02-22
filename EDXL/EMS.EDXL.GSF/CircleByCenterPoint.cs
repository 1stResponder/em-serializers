using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class CircleByCenterPoint : GMLShape
  {
    [XmlElement("circleByCenterPoint", Namespace = GSFNamespaces.v10_GML)]
    public CircleByCenterPointType circleByCenterPoint { get; set; }
  }
}
