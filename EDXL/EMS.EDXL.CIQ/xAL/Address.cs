using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Represents an Address
  /// </summary>
  public class Address //: EDXLGeoPoliticalLocation
  {
    /// <summary>
    /// Gets/Sets the Address Type
    /// </summary>
    [XmlElement("address", Namespace = CIQNamespaces.v10_xAL)]
    public AddressType address { get; set; }
  }
}
