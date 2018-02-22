using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
    ///TODO: Add properties for UTMHemisphereCode  & UTMZoneNumericType 

    /// <summary>
    /// Represents a UTM Coordinate
    /// </summary>
    public class UTMCoordinate
    {

    /// <summary>
    /// Gets or sets An identifier of a UTM coordinate.
    /// </summary>
    [XmlElement("UTMCoordinateID", Namespace = Constants.NiemcoreNamespace)]
    public string CoordinateID
    {
      get; set;
    }
    
    /// <summary>
    /// Gets or sets A distance east within a UTM zone.
    /// </summary>
    [XmlElement("UTMEastingValue", Namespace = Constants.NiemcoreNamespace)]
    public int EastingValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets A distance north within a UTM zone.
    /// </summary>
    [XmlElement("UTMNorthingValue", Namespace = Constants.NiemcoreNamespace)]
    public int NorthingValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets A spatial reference system.
    /// </summary>
    /// geographic datum text
    [XmlElement("GeographicDatumText", Namespace = Constants.NiemcoreNamespace)]
    public string GeographicDatum
    {
      get; set;
    }


    }
}
