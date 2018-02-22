using System;
using EMS.EDXL.Shared;

namespace EMS.EDXL.SitRep
{
  [Serializable]
  public enum ReportVersionDefaultValues
  {
    /// <summary>
    /// Initial Report
    /// </summary>
    Initial,

    /// <summary>
    /// Updated Report
    /// </summary>
    Update,

    /// <summary>
    /// Final Report
    /// </summary>
    Final
  }
}
