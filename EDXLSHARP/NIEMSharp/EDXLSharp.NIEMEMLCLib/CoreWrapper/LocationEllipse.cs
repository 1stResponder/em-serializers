//-----------------------------------------------------------------------
// <copyright file="LocationEllipse.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
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
  /// Represents an ellipse
  /// </summary>
  public class LocationEllipse : AreaRegion
  {
    /// <summary>
    /// Initializes a new instance of the LocationEllipse class
    /// </summary>
    public LocationEllipse()
    {
      this.Ellipse = new Ellipse();
    }

    /// <summary>
    /// Gets or sets the ellipse
    /// </summary>
    [XmlElement(Namespace = Constants.NiemocgNamespace)]
    public Ellipse Ellipse
    {
      get; set;
    }
  }
}