// ———————————————————————–
// <copyright file="GMLLinestring.cs" company="EDXLSharp">
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

using EDXLSharp;
using System;
using System.Xml;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// >A LineString is a special curve that consists of a single segment with linear interpolation
  /// </summary>
  [Serializable]
  public partial class GMLLineString : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// List of GML positions for this Line String
    /// </summary>
    private GMLPosList posList;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLLineString class
    /// Default Constructor - Initializes List
    /// </summary>
    public GMLLineString()
    {
      this.posList = new GMLPosList();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The GML Position List Representing The Line String
    /// </summary>
    public GMLPosList PosList
    {
      get { return this.posList; }
      set { this.posList = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "LineString")
      {
        this.ReadXMLBase(rootnode);
        if (rootnode.ChildNodes.Count != 1)
        {
          throw new ArgumentException("Too Many Child Nodes in LineString");
        }
        else
        {
          this.posList.ReadXML(rootnode.ChildNodes[0]);
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in GMLLineString");
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "LineString", EDXLConstants.GMLNamespace);
      this.ToXMLStringBase(xwriter);
      if (this.posList != null)
      {
        this.posList.WriteXML(xwriter);
      }

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
