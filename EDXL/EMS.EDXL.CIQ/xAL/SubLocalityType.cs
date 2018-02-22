using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// A locality that is smaller and is contained within the boundaries of its
  /// parent locality.Note that not all localities have sub locality.For example,
  /// many areas within a locality where each area is a sub locality
  /// </summary>
  [Serializable]
  public class SubLocalityType
  {
    /// <summary>
    /// Data associated with the sub locality. e.g. Full name of the
    /// locality or part of it, reference location to the locality
    /// </summary>
    public List<string> nameElement { get; set; }
  }
}
