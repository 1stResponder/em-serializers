//-----------------------------------------------------------------------
// <copyright file="IncidentLocationExtension.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EDXLSharp.NIEMEMLCLib.CoreWarpper;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the extension for an incident's location
  /// </summary>
  public class IncidentLocationExtension
  {
    /// <summary>
    /// Initializes a new instance of the IncidentLocationExtension class
    /// </summary>
    public IncidentLocationExtension()
    {
      
    }

    /// <summary>
    /// Gets or sets the address of the incident
    /// Optional Element 
    /// </summary>
    [XmlElement("Address", typeof(Address), Namespace = Constants.EmeventNamespace)]
    public Address Address
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the cross street of the incident
    /// </summary>
    [XmlElement("AddressCrossStreet", typeof(AddressCrossStreet), Namespace = Constants.NiemcoreNamespace)]
    public AddressCrossStreet AddressCrossStreet
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the area or region of the incident
    /// </summary>
    [XmlElement("LocationEllipse", typeof(LocationEllipse), Namespace = Constants.MofNamespace)]
    [XmlElement("LocationExternalPolygon", typeof(LocationExternalPolygon), Namespace = Constants.MofNamespace)]
    [XmlElement("LocationLineString", typeof(LocationLineString), Namespace = Constants.MofNamespace)]
    public AreaRegion AreaRegion
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this location represents an intersection
    /// </summary>
    [DefaultValue(null)]
    public bool? AddressIntersectionIndicator
    {
      get; set;
    }

    /// <summary>
    /// If the address intersection is null, do not serialize it 
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeAddressIntersectionIndicator()
    {
        return (AddressIntersectionIndicator != null);
    }

  }
}
