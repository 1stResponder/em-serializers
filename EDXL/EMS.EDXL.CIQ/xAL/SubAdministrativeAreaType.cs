using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// The next level down division of the area. E.g. state / county, province /
  /// reservation.Note that not all countries have a subadministrative area
  /// </summary>
  [Serializable]
  public class SubAdministrativeAreaType
  {
    /// <summary>
    /// Data associated with the SubAdministrative Area. 
    /// e.g. Full name of sub administrative area or part of it.
    /// </summary>
    public List<string> nameElement { get; set; }
  }
}
