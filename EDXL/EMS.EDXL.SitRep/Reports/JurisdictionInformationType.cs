using EMS.EDXL.CT;
using EMS.EDXL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class JurisdictionInformationType
  {
    private string name;

    private GeographicSizeType geographicSize;

    private EDXLLocationType location;

    private string description;

    [XmlElement("name")]
    public string Name
    {
      get { return this.name; }
      set { this.name = value; }
    }

    [XmlElement("geographicSize")]
    public GeographicSizeType GeographicSize
    {
      get { return this.geographicSize; }
      set { this.geographicSize = value; }
    }

    [XmlElement("location")]
    public EDXLLocationType Location
    {
      get { return this.location; }
      set { this.location = value; }
    }

    [XmlElement("description")]
    public string Description
    {
      get { return this.description; }
      set { this.description = value; }
    }
  }
}
