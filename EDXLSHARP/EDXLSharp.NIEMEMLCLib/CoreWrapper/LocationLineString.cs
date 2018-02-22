//-----------------------------------------------------------------------
// <copyright file="LocationLineString.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EDXLSharp.NIEMEMLCLib.Geo4NIEM;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.CoreWarpper
{
  /// <summary>
  /// Represents a Line string
  /// </summary>
  public class LocationLineString : AreaRegion
  {
    /// <summary>
    /// Initializes a new instance of the LocationLineString class
    /// </summary>
    public LocationLineString()
    {
      this.LineString = new LineString();
    }

    /// <summary>
    /// Gets or sets the LineString
    /// Required Element
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    public LineString LineString
    {
      get; set;
    }
  }
}