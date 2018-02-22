//-----------------------------------------------------------------------
// <copyright file="Ellipse.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
  /// <summary>
  /// Represents an ellipse
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class Ellipse : GML
  {
    /// <summary>
    /// Initializes a new instance of the Ellipse class
    /// </summary>
    public Ellipse()
    {
      this.Positions = new List<double>();
    }

    /// <summary>
    /// Gets or sets the list of positions associated with this ellipse
    /// </summary>
    [XmlIgnore]
    public List<double> Positions
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the string position for this ellipse
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    [JsonProperty]
    public string Pos
    {
      get
      {
        StringBuilder sb = new StringBuilder();
        foreach (double d in this.Positions)
        {
          sb.Append(d.ToString());
          sb.Append(" ");
        }

        return sb.ToString();
      }

      set
      {
        this.Positions = new List<double>();
        string[] split = value.Split(' ');
        foreach (string s in split)
        {
          this.Positions.Add(double.Parse(s));
        }
      }
    }

    /// <summary>
    /// Gets or sets the major axis value
    /// </summary>
    [JsonProperty]
    public double MajorAxis
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the minor axis value
    /// </summary>
    [JsonProperty]
    public double MinorAxis
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the rotation value
    /// </summary>
    [JsonProperty]
    public double Rotation
    {
      get; set;
    }
  }
}