using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.EDXL.SitRep
{
  [Serializable]
  public enum IncidentLifecycleDefaultValues
  {
    /// <summary>
    /// Preparedness Phase of an Incident
    /// </summary>
    Preparedness,

    /// <summary>
    /// Response Phase of an Incident
    /// </summary>
    Response,

    /// <summary>
    /// Mitigation Phase of an Incident
    /// </summary>
    Mitigation,

    /// <summary>
    /// Recovery Phase of an Incident
    /// </summary>
    Recovery
  }
}
