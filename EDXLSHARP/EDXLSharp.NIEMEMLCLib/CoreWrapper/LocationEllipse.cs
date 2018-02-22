//-----------------------------------------------------------------------
// <copyright file="LocationEllipse.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EDXLSharp.NIEMEMLCLib.Geo4NIEM;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.CoreWarpper
{
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
    /// Required Element
    /// </summary>
    [XmlElement(Namespace = Constants.NiemocgNamespace)]
    public Ellipse Ellipse
    {
      get; set;
    }
  }
}