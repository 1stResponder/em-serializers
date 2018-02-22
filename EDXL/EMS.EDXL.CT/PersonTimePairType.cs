using System.Xml.Serialization;
using EMS.EDXL.CIQ;

namespace EMS.EDXL.CT
{
  public class PersonTimePairType
  {
    [XmlElement("personDetails")]
    public PersonDetailsType personDetails { get; set; }


    [XmlElement("timeValue")]
    public EDXLDateTime timeValue { get; set; }
  }
}
