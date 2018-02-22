using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  public class ThoroughfareName : ThoroughfareDetail
  {
    [XmlText]
    public string Value { get; set; }

    [XmlAttribute]
    public bool Abbreviation { get; set; }

    [XmlAttribute]
    public ThoroughfareNameTypeList NameKind { get; set; }
  }
}
