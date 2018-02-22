using EMS.EDXL.EXT;
using EMS.EDXL.SitRep.Reports;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  /// <summary>
  /// Base class for all reports
  /// </summary>
  public class IReportType
  {
    private List<extension> extensions;
    private IReport report;

    /// <summary>
    /// Community-defined sets of name/value pairs
    /// </summary>
    [XmlElement("extension")]
    public List<extension> Extensions
    {
      get { return this.extensions; }
      set { this.extensions = value; }
    }

    /// <summary>
    /// XML serialization flag
    /// </summary>
    [XmlIgnore]
    public bool ExtensionsSpecified
    {
      get { return this.extensions != null && this.extensions.Count > 0; }
    }

    /// <summary>
    /// The kind of details contained in this SitRep
    /// </summary>
    [XmlElement("fieldObservation", Type = typeof(FieldObservationReport))]
    [XmlElement("situationInformation", Type = typeof(SituationInformationReport))]
    public IReport iReport
    {
      get { return this.report; }
      set { this.report = value; }
    }
  }
}
