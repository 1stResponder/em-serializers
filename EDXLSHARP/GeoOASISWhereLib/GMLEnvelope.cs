// ———————————————————————–
// <copyright file="GMLEnvelope.cs" company="EDXLSharp">
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
  /// Envelope defines an extent using a pair of positions defining opposite corners in arbitrary dimensions
  /// </summary>
  [Serializable]
  public partial class GMLEnvelope : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// Point Representing The Corners of the Box
    /// </summary>
    private GMLPoint lowercorner, uppercorner;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLEnvelope class
    /// Default Constructor - Initializes Both Points
    /// </summary>
    public GMLEnvelope()
    {
      this.lowercorner = new GMLPoint();
      this.uppercorner = new GMLPoint();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Point Representing The Lower Corner of the Box
    /// </summary>
    public GMLPoint Lowercorner
    {
      get { return this.lowercorner; }
      set { this.lowercorner = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Point Representing the Upper Corner of the Box
    /// </summary>
    public GMLPoint Uppercorner
    {
      get { return this.uppercorner; }
      set { this.uppercorner = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public override void ReadXML(XmlNode rootnode)
    {
      GMLPos postmp;

      if (rootnode.LocalName == "Envelope")
      {
        this.ReadXMLBase(rootnode);
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "lowerCorner":
              postmp = new GMLPos();
              postmp.FromString(childnode.InnerText);
              this.lowercorner.Pos = postmp;
              break;
            case "upperCorner":
              postmp = new GMLPos();
              postmp.FromString(childnode.InnerText);
              this.uppercorner.Pos = postmp;
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in GMLEnvelope");
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
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Envelope", EDXLConstants.GMLNamespace);
      this.ToXMLStringBase(xwriter);
      if (this.lowercorner != null)
      {
        xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "lowerCorner", EDXLConstants.GMLNamespace);
        xwriter.WriteString(this.lowercorner.ToString());
        xwriter.WriteEndElement();
      }

      if (this.uppercorner != null)
      {
        xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "upperCorner", EDXLConstants.GMLNamespace);
        xwriter.WriteString(this.uppercorner.ToString());
        xwriter.WriteEndElement();
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
