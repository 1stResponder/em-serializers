//-----------------------------------------------------------------------
// <copyright file="LocationEllipse.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;
using EMS.NIEM.NIEMCommon.Geo4NIEM;
using System;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents an ellipse
  /// </summary>
  [Serializable]
  [XmlRoot(ElementName = "WGS84LocationEllipse", Namespace = Constants.MoNamespace)]
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