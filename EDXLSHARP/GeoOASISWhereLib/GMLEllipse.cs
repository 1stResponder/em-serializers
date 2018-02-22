// ———————————————————————–
// <copyright file="GMLEllipse.cs" company="EDXLSharp">
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
  /// GML Ellipse Type
  /// </summary>
  public class GMLEllipse : GML
  {
    /// <summary>
    /// Gets or sets the position of this ellipse
    /// </summary>
    public GMLPos Pos
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Major Axis of this ellipse
    /// </summary>
    public GMLMajorAxis MajorAxis
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Minor Axis of this ellipse
    /// </summary>
    public GMLMinorAxis MinorAxis
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Rotation of this ellipse
    /// </summary>
    public GMLRotation Rotation
    {
      get; set;
    }

    /// <summary>
    /// Reads this Object From XML
    /// </summary>
    /// <param name="rootnode">Root XML Node for this sub element</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode == null)
      {
        throw new ArgumentNullException("rootnode");
      }

      if (rootnode.LocalName != "Ellipse")
      {
        throw new ArgumentException("Unexpected element " + rootnode.LocalName + " instead of Ellipse");
      }

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        switch (node.LocalName)
        {
          case "pos":
            this.Pos = new GMLPos();
            this.Pos.ReadXML(node);
            break;
          case "majorAxis":
            this.MajorAxis = new GMLMajorAxis();
            this.MajorAxis.ReadXML(node);
            break;
          case "minorAxis":
            this.MinorAxis = new GMLMinorAxis();
            this.MinorAxis.ReadXML(node);
            break;
          case "rotation":
            this.Rotation = new GMLRotation();
            this.Rotation.ReadXML(node);
            break;
          default:
            throw new ArgumentException("Unexpected element " + node.LocalName + " in Ellipse");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Writes This Object to an XML Document
    /// </summary>
    /// <param name="xwriter">Existing XML Document Writer</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      if (xwriter == null)
      {
        throw new ArgumentNullException("xwriter");
      }

      this.Validate();

      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Ellipse", EDXLConstants.GMLNamespace);
      this.ToXMLStringBase(xwriter);
      this.Pos.WriteXML(xwriter);
      this.MajorAxis.WriteXML(xwriter);
      this.MinorAxis.WriteXML(xwriter);
      this.Rotation.WriteXML(xwriter);
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      if (this.Pos == null)
      {
        throw new ValidationException("Missing required field Pos");
      }

      // Pos.Validate?
      if (this.MajorAxis == null)
      {
        throw new ValidationException("Missing required field MajorAxis");
      }

      this.MajorAxis.Validate();

      if (this.MinorAxis == null)
      {
        throw new ValidationException("Missing required field MinorAxis");
      }

      this.MinorAxis.Validate();

      if (this.Rotation == null)
      {
        throw new ValidationException("Missing required field Rotation");
      }

      this.Rotation.Validate();
    }
  }
}