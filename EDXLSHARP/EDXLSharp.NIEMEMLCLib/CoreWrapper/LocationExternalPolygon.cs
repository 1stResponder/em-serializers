//-----------------------------------------------------------------------
// <copyright file="LocationExternalPolygon.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EDXLSharp.NIEMEMLCLib.Geo4NIEM;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.CoreWarpper
{
  /// <summary>
  /// Represents an external perimeter polygon
  /// </summary>
  public class LocationExternalPolygon : AreaRegion
  {
    /// <summary>
    /// Initializes a new instance of the LocationExternalPolygon class
    /// </summary>
    public LocationExternalPolygon()
    {
      this.Polygon = new Polygon();
    }

    /// <summary>
    /// Gets or sets the polygon
    /// Required
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    public Polygon Polygon
    {
      get; set;
    }
  }
}