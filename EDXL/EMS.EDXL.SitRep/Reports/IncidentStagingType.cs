using EMS.EDXL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class IncidentStagingType
  {
    private string incidentStagingArea;

    private EDXLLocationType incidentStagingAreaLocation;

    [XmlElement("incidentStagingArea")]
    public string IncidentStagingArea
    {
      get { return this.incidentStagingArea; }
      set { this.incidentStagingArea = value; }
    }

    [XmlElement("incidentStagingAreaLocation")]
    public EDXLLocationType IncidentStagingAreaLocation
    {
      get { return this.incidentStagingAreaLocation; }
      set { this.incidentStagingAreaLocation = value; }
    }
  }
}
