using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class SubIncidentInformationType
  {
    private List<IncidentInformationType> subIncidents;

    [XmlElement("subIncident")]
    public List<IncidentInformationType> SubIncidents
    {
      get { return this.subIncidents; }
      set { this.subIncidents = value; }
    }

    [XmlIgnore]
    public bool SubIncidentSpecified
    {
      get { return this.subIncidents != null && this.subIncidents.Count > 0; }
    }
  }
}
