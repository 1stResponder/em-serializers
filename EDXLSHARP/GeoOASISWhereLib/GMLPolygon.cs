// ———————————————————————–
// <copyright file="GMLPolygon.cs" company="EDXLSharp">
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
using System.Xml;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// A Polygon is a special surface that is defined by a single surface patch. The boundary of this patch is coplanar and the polygon uses planar interpolation in its interior. 
  /// </summary>
  [Serializable]
  public partial class GMLPolygon : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// The Linear ring Denoting The Exterior of the Polygon
    /// </summary>
    private GMLLinearRing exterior;

    /// <summary>
    /// A Set Of Linear Rings Defining the Interior of the Polygon
    /// </summary>
    private List<GMLLinearRing> interior;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLPolygon class
    /// Default Constructor - Initializes Objects
    /// </summary>
    public GMLPolygon()
    {
      this.exterior = new GMLLinearRing();
      this.interior = new List<GMLLinearRing>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The Linear ring Denoting The Exterior of the Polygon
    /// </summary>
    public GMLLinearRing Exterior
    {
      get { return this.exterior; }
      set { this.exterior = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A Set Of Linear Rings Defining the Interior of the Polygon
    /// </summary>
    public List<GMLLinearRing> Interior
    {
      get { return this.interior; }
      set { this.interior = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "Polygon")
      {
        GMLLinearRing tempring;
        this.ReadXMLBase(rootnode);
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "exterior":
              if (childnode.ChildNodes.Count != 1)
              {
                throw new ArgumentException("Unexpected Number of gml:exterior child nodes in GMLPolygon");
              }

              this.exterior.ReadXML(childnode.FirstChild);
              break;
            case "interior":
              if (childnode.ChildNodes.Count != 1)
              {
                throw new ArgumentException("Unexpected Number of gml:interior child nodes in GMLPolygon");
              }

              tempring = new GMLLinearRing();
              tempring.ReadXML(childnode.FirstChild);
              this.interior.Add(tempring);
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in GMLPolygon");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in GMLPolycon");
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Polygon", EDXLConstants.GMLNamespace);
      this.ToXMLStringBase(xwriter);
      if (this.exterior != null)
      {
        xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "exterior", EDXLConstants.GMLNamespace);
        this.exterior.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.interior.Count != 0)
      {
        foreach (GMLLinearRing ring in this.interior)
        {
          xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "interior", EDXLConstants.GMLNamespace);
          ring.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
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
