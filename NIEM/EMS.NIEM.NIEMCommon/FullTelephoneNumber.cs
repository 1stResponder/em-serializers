using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Full telephone number with extension
  /// </summary>
  [Serializable]
  public class FullTelephoneNumber : TelephoneNumberRepresentation
  {
    /// <summary>
    /// Full phone number
    /// </summary>
    [XmlElement(ElementName="TelephoneNumberFullID", Namespace = Constants.NiemcoreNamespace)]
    public string PhoneNumber
    {
      get; set;
    }

    /// <summary>
    /// Phone number extension
    /// </summary>
    [XmlElement(ElementName = "TelephoneSuffixID", Namespace = Constants.NiemcoreNamespace)]
    public string Extension
    {
      get; set;
    }
  }
}
