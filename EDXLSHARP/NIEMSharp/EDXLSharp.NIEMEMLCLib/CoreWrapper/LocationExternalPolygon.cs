//-----------------------------------------------------------------------
// <copyright file="LocationExternalPolygon.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using NIEMSHARP.NIEMEMLCLib.Geo4NIEM;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.CoreWarpper
{
 // NOTE: The name/namespace of this class is hard coded for the Mutual Aid library's 
 // JSON serialization/deserialization process.  
 // If the class name is changed then that must be updated as well.   
 // Places to Update:
 //      NIEMSHARP.SubsitutePropertyNameContractResolver (class)


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
    /// </summary>
    [XmlElement(Namespace = Constants.NiemocgNamespace)]
    public Polygon Polygon
    {
      get; set;
    }
  }
}