using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Full telephone number with extension
  /// </summary>
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
