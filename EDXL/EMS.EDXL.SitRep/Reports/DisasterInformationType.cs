using EMS.EDXL.CT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class DisasterInformationType
  {
    private string disasterName;

    private string disasterDeclarationAuthority;

    private EDXLDateTime disasterDeclarationDateTime;

    [XmlElement("disasterName")]
    public string DisasterName
    {
      get { return this.disasterName; }
      set { this.disasterName = value; }
    }

    [XmlElement("disasterDeclarationAuthority")]
    public string DisasterDeclarationAuthority
    {
      get { return this.disasterDeclarationAuthority; }
      set { this.disasterDeclarationAuthority = value; }
    }

    [XmlElement("disasterDeclarationDateTime")]
    public string DisasterDeclarationDateTime
    {
      get { return this.disasterDeclarationDateTime.EDXLCustomFormat; }
      set { this.disasterDeclarationDateTime = DateTime.Parse(value); }
    }
  }
}
