//-----------------------------------------------------------------------
// <copyright file="EventLocation.cs" company="EDXLSharp">
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
  /// Location of an event
  /// </summary>
  [Serializable]
  public class EventLocation
  {
    /// <summary>
    /// Initializes a new instance of the EventLocation class
    /// </summary>
    public EventLocation()
    {
      LocationCylinder = new LocationCylinder();
    }

    /// <summary>
    /// Gets or sets the location cylinder
    /// </summary>
    [XmlElement(ElementName = "WGS84LocationCylinder", Namespace = Constants.MoNamespace)]

	public LocationCylinder LocationCylinder
    {
      get; set;
    }
  }
}