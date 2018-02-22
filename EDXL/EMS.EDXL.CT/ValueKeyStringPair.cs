using System.Xml.Serialization;

namespace EMS.EDXL.CT
{

  public class ValueKeyStringPair
  {
    [XmlElement("valueKeyURI")]
    public ValueKey valueKey { get; set; }


    [XmlElement("pairValue")]
    public string pairValue { get; set; }
  }
}
