//-----------------------------------------------------------------------
// <copyright file="EventLocation.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Location of an event
  /// </summary>
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
    [XmlElement(Namespace = Constants.MofNamespace)]
    public LocationCylinder LocationCylinder
    {
      get; set;
    }
  }
}