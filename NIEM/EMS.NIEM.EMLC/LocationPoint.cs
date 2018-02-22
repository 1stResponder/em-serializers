//-----------------------------------------------------------------------
// <copyright file="LocationPoint.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Represents a point location
  /// </summary>
  [Serializable]
  public class LocationPoint
  {
    /// <summary>
    /// Initializes a new instance of the LocationPoint class
    /// </summary>
    public LocationPoint()
    {
      Point = new Point();
    }

    /// <summary>
    /// Gets or sets the point value
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    public Point Point
    {
      get; set;
    }
  }
}