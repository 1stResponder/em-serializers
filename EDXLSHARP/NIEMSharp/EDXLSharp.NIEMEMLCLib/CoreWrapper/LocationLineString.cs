//-----------------------------------------------------------------------
// <copyright file="LocationLineString.cs" company="EDXLSharp">
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
  /// Represents a LineString
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
    /// </summary>
    [XmlElement(Namespace = Constants.NiemocgNamespace)]
    public LineString LineString
    {
      get; set;
    }
  }
}