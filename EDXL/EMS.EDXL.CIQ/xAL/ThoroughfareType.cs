using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  public class ThoroughfareType
  {
    [XmlElement("nameElement", typeof(ThoroughfareName))]
    [XmlElement("number", typeof(ThoroughfareNumber))]
    public List<ThoroughfareDetail> details { get; set; }

    [XmlAttribute]
    public string Kind { get; set; }
  }
}
