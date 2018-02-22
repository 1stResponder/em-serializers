// ———————————————————————–
// <copyright file="GMLPos.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
                                
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// DirectPosition instances hold the coordinates for a position within some coordinate reference system (CRS)
  /// </summary>
  [Serializable]
  public partial class GMLPos : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// List of positions
    /// </summary>
    private List<double> pos;

    /// <summary>
    /// The namespace for the GML Position.
    /// </summary>
    private string gmlNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLPos class with the specified namespace
    /// Default Constructor - Initializes List
    /// </summary>
    /// ///<param name="gmlNamespace">Name space to use with the element</param>
    public GMLPos(string gmlNamespace) : base(gmlNamespace)
    {
      this.gmlNamespace = gmlNamespace;
      this.pos = new List<double>();
    }

    /// <summary>
    /// Initializes a new instance of the GMLPos class
    /// Default Constructor
    /// </summary>
    public GMLPos() : this(EDXLConstants.GMLNamespace)
    {
      this.pos = new List<double>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// List of positions
    /// </summary>
    public List<double> Pos
    {
      get { return this.pos; }
      set { this.pos = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Adds The Position Points to this Position
    /// </summary>
    /// <param name="positions">Array of double indicating position pairs</param>
    public void AddPositions(double[] positions)
    {
      foreach (double d in positions)
      {
        this.pos.Add(d);
      }
    }

    /// <summary>
    /// Converts This GML Position Into A Space Delimited String
    /// </summary>
    /// <returns>Space Delimited String of Points</returns>
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < this.pos.Count; i++)
      {
        sb.Append(this.pos[i]);
        if (i != (this.pos.Count - 1))
        {
          sb.Append(' ');
        }
      }

      return sb.ToString();
    }

    /// <summary>
    /// Parses A Position From An Input String
    /// </summary>
    /// <param name="instr">Space Delimited Position String</param>
    public void FromString(string instr)
    {
      char[] separators = { ' ' };
      string[] values;
      values = instr.Split(separators);
      foreach (string s in values)
      {
        bool canParse = false;
        double dval;

        canParse = double.TryParse(s, out dval);

        if (canParse)
        {
          this.pos.Add(dval);
        }
      }
    }

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      this.ReadXMLBase(rootnode);
      string temp;
      char[] separators = { ' ' };
      string[] values;
      this.pos = new List<double>();
      if (rootnode.LocalName == "pos")
      {
        temp = rootnode.InnerText;
        values = temp.Split(separators);
        foreach (string s in values)
        {
          bool canParse = false;
          double val;

          canParse = double.TryParse(s, out val);

          if (canParse)
          {
            this.pos.Add(val);
          }
        }
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < this.pos.Count; i++)
      {
        sb.Append(this.pos[i]);
        if (i != (this.pos.Count - 1))
        {
          sb.Append(' ');
        }
      }

      this.ToXMLStringBase(xwriter);
      xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", this.gmlNamespace, sb.ToString().Trim());
    }

    #endregion

    #region Protected Member Functions
    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
