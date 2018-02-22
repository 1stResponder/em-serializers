using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Details of the top-level area division in the country, such as state, district,
  /// province, island, region, etc.Note that some countries do not have this
  /// </summary>
  [Serializable]
  public class AdministrativeAreaType
  {
    /// <summary>
    /// Data associated with the Administrative Area.e.g.Full name of administrative
    /// area or part of it. eg.MI in USA, NSW in Australia, reference location to the
    /// administrative area
    /// </summary>
    public List<string> nameElement { get; set; }

    /// <summary>
    /// Gets/Sets the Sub Administrative Area
    /// </summary>
    public SubAdministrativeAreaType subAdministrativeArea { get; set; }

    /// <summary>
    /// Holds the Sub Administrative Area
    /// </summary>
    [XmlIgnore]
    public bool subAdministrativeAreaSpecified
    {
      get
      {
        return subAdministrativeArea != null;
      }
    }
  }
}
