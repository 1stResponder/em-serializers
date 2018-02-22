using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class Point : GMLShape
  {
    [XmlElement("point", Namespace = GSFNamespaces.v10_GML)]
    public PointType point { get; set; }
  }
}
