using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
  /// <summary>
  /// Phone Number
  /// </summary>
  [Serializable]
  public class TelephoneNumber
  {
    /// <summary>
    /// Phone Number
    /// </summary>
    [XmlElement("FullTelephoneNumber", typeof(FullTelephoneNumber), Namespace = Constants.NiemcoreNamespace)]
    public TelephoneNumberRepresentation FullNumber
    {
      get; set;
    }

  }
}
