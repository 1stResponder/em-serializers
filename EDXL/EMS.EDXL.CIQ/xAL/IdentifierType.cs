using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  public class IdentifierType
  {
    [XmlText]
    public string Value { get; set; }

    [XmlAttribute]
    public bool Abbreviation { get; set; }

    [XmlAttribute]
    public IdentifierElementTypeList Kind { get; set; }
  }
}
