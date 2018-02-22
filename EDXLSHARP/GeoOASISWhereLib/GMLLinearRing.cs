// ———————————————————————–
// <copyright file="GMLLinearRing.cs" company="EDXLSharp">
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
using System.Xml;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// A LinearRing is defined by four or more coordinate tuples, with linear interpolation between them; the first and last coordinates must be coincident
  /// </summary>
  [Serializable]
  public partial class GMLLinearRing : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// List of GML positions for this Linear ring
    /// </summary>
    private GMLPosList posList;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLLinearRing class
    /// Default Constructor - Initializes Base
    /// </summary>
    public GMLLinearRing()
    {
      this.posList = new GMLPosList();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// List of GML positions for this Linear ring
    /// </summary>
    public GMLPosList PosList
    {
      get { return this.posList; }
      set { this.posList = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Adds positions To This Linear ring
    /// </summary>
    /// <param name="positions">Array of double indicating position pairs</param>
    public void AddPositions(double[] positions)
    {
      this.posList.AddPositions(positions);
    }

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "LinearRing")
      {
        this.ReadXMLBase(rootnode);
        this.posList.ReadXML(rootnode.ChildNodes[0]);
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in GMLLinearRing");
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "LinearRing", EDXLConstants.GMLNamespace);
      this.ToXMLStringBase(xwriter);
      this.posList.WriteXML(xwriter);
      xwriter.WriteEndElement();
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
