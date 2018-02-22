using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  /// <summary>
  /// Base class for reports
  /// </summary>
  public abstract class IReport
  {
    /// <summary>
    /// Read-only property to return a set of keywords from a given report
    /// </summary>
    [XmlIgnore]
    public abstract List<string> Keywords { get; }
  }
}
