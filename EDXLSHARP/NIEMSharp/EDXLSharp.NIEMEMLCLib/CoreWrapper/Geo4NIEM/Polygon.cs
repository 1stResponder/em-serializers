//-----------------------------------------------------------------------
// <copyright file="Polygon.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Geo4NIEM
{
  /// <summary>
  /// Represents a polygon
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class Polygon : GML
  {
    /// <summary>
    /// Initializes a new instance of the Polygon class
    /// </summary>
    public Polygon()
    {
      this.Exterior = new LinearRing();
    }

    /// <summary>
    /// Gets or sets the list of positions in this polygon
    /// </summary>
    [XmlIgnore]
    public List<List<double>> Positions
    {
      get
      {
        return this.Exterior.Positions;
      }

      set
      {
        this.Exterior.Positions = new List<List<double>>(value);
      }
    }

    /// <summary>
    /// Gets or sets the exterior ring of this polygon
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    [JsonProperty]
    public LinearRing Exterior
    {
      get; set;
    }
  }
}