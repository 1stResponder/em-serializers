//-----------------------------------------------------------------------
// <copyright file="LineString.cs" company="EDXLSharp">
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
  /// Represents a line of points
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class LineString : GML
  {
    /// <summary>
    /// Initializes a new instance of the LineString class
    /// </summary>
    public LineString()
    {
      this.Positions = new List<List<double>>();
    }

    /// <summary>
    /// Gets or sets the list of positions in this line
    /// </summary>
    [XmlIgnore]
    public List<List<double>> Positions
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value of the list of positions
    /// </summary>
    [XmlElement(Namespace = Constants.GmlNamespace)]
    [JsonProperty]
    public string[] Pos
    {
      get
      {
        StringBuilder sb;
        List<string> elements = new List<string>();
        foreach (List<double> ld in this.Positions)
        {
          sb = new StringBuilder();
          foreach (double d in ld)
          {
            sb.Append(d.ToString());
            sb.Append(" ");
          }

          elements.Add(sb.ToString());
        }

        return elements.ToArray();
      }

      set
      {
        this.Positions = new List<List<double>>();
        List<double> point;
        foreach (string s in value)
        {
          point = new List<double>();
          string[] split = s.Split(' ');
          foreach (string spl in split)
          {
            point.Add(double.Parse(s));
          }

          this.Positions.Add(point);
        }
      }
    }
  }
}