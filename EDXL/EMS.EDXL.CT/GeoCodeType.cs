using EMS.EDXL.Shared;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  public class GeoCodeType : EDXLGeoPoliticalLocation
  {
    [XmlElement("geoCode", Namespace = CTNamespaces.v10)]
    public ValueList geoCode { get; set; }
  }
}
