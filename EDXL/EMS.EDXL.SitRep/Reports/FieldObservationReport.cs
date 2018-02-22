using EMS.EDXL.CT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep.Reports
{
  public class FieldObservationReport : IReport
  {
    private EDXLString observationLocation;
    private EDXLString immediateNeeds;
    private List<ImmediateNeedsCategoryDefaultValues> immediateNeedsCategories;
    private string observationText;

    public FieldObservationReport()
    {
      this.immediateNeedsCategories = new List<ImmediateNeedsCategoryDefaultValues>();
    }
  
    [XmlElement("observationLocation")]
    public string ObservationLocation
    {
      get { return this.observationLocation.EDXLCustomFormat; }
      set { this.observationLocation = value; }
    }

    [XmlElement("immediateNeeds")]
    public string ImmediateNeeds
    {
      get { return this.immediateNeeds.EDXLCustomFormat; }
      set { this.immediateNeeds = value; }
    }

    [XmlElement("immediateNeedsCategory")]
    public List<ImmediateNeedsCategoryDefaultValues> ImmediateNeedsCategories
    {
      get { return this.immediateNeedsCategories; }
      set { this.immediateNeedsCategories = value; }
    }

    public bool ImmediateNeedsCategoriesSpecified
    {
      get { return this.immediateNeedsCategories != null && this.immediateNeedsCategories.Count > 1; }
    }

    [XmlElement("observationText")]
    public string ObservationText
    {
      get { return this.observationText; }
      set { this.observationText = value; }
    }

    [XmlIgnore]
    public override List<string> Keywords
    {
      get
      {
        List<string> tmp = new List<string>();

        tmp.Add("Field Observation");

        return tmp;
      }
    }
  }
}
