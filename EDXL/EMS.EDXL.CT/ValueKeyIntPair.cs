using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  public class ValueKeyIntPair
  {
    [XmlElement("valueKeyURI")]
    public ValueKey valueKey { get; set; }


    [XmlElement("pairValue")]
    public int pairValue { get; set; }
  }
}
