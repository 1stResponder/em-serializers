using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
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
