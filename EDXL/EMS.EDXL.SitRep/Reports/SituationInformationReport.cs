using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class SituationInformationReport : IReport
  {

    private IncidentInformationType primaryIncidentInformation;
    private List<SubIncidentInformationType> subIncidentInformation;

    [XmlElement("primaryIncidentInformation")]
    public IncidentInformationType PrimaryIncidentInformation
    {
      get { return this.primaryIncidentInformation; }
      set { this.primaryIncidentInformation = value; }
    }

    [XmlIgnore]
    public bool PrimaryIncidentInformationSpecified
    {
      get { return this.primaryIncidentInformation != null; }
    }

    [XmlElement("subIncidentInformation")]
    public List<SubIncidentInformationType> SubIncidentInformation
    {
      get { return this.subIncidentInformation; }
      set { this.subIncidentInformation = value; }
    }

    [XmlIgnore]
    public bool SubIncidentInformationSpecified
    {
      get { return this.SubIncidentInformation != null && this.subIncidentInformation.Count > 0; }
    }

    public override List<string> Keywords
    {
      get
      {
        return new List<string>() { "Situation Information Report" };
      }
    }
  }
}
