using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Details of Locality which is a named densely populated area  (a place) such as town,
  /// village, suburb, etc.A locality composes of many individual addresses.Many localities
  /// exist in an administrative area or a sub administrative area.A locality can also have sub
  /// localities. For example, a municipality locality can have many villages associated with
  /// it which are sub localities. Example: Tamil Nadu State, Erode District, Bhavani Taluk,
  /// Paruvachi Village is a valid address in India.Tamil Nadu is the Administrative Area,
  /// Erode is the sub admin area, Bhavani is the locality, and Paruvachi is the sub locality
  /// </summary>
  [Serializable]
  public class LocalityType
  {
    /// <summary>
    /// Data associated with the locality. e.g. Full name of the locality or part
    /// of it, reference location to the locality
    /// </summary>
    public List<string> nameElement { get; set; }

    public SubLocalityType subLocality { get; set; }

    [XmlIgnore]
    public bool subLocalitySpecified
    {
      get
      {
        return subLocality != null;
      }
    }
  }
}
