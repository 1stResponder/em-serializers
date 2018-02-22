// ———————————————————————–
// <copyright file="GMLMeasureType.cs" company="EDXLSharp">
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
using System.Text.RegularExpressions;
using System.Xml;
using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// MeasureType supports recording an amount encoded as a value of XML Schema double, together with a units of
  /// measure indicated by an attribute units Of measure. The value of the unit of measure attribute identifies
  /// a reference system for the amount, usually a ratio or interval scale.
  /// </summary>
  public abstract class GMLMeasureType : ComplexTypeBase
  {
    /// <summary>
    /// Gets or sets the Unit of Measure
    /// </summary>
    public string UnitOfMeasure
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the value of the measurement
    /// </summary>
    public double Value
    {
      get; set;
    }

    /// <summary>
    /// Writes this object to XML
    /// </summary>
    /// <param name="xwriter">XML Writer to use to write this object using</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      if (xwriter == null)
      {
        throw new ArgumentNullException("xwriter");
      }

      this.Validate();
      xwriter.WriteStartElement(this.ElementPrefix, this.ElementName, this.ElementNamespace);
      if (!string.IsNullOrEmpty(this.UnitOfMeasure))
      {
        xwriter.WriteAttributeString("uom", EDXLConstants.GMLNamespace, this.UnitOfMeasure);
      }

      xwriter.WriteString(this.Value.ToString());
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this object from a XML DOM
    /// </summary>
    /// <param name="rootnode">XML Root Node to read data from</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode == null)
      {
        throw new ArgumentNullException("rootnode");
      }

      if (rootnode.LocalName != this.ElementName)
      {
        throw new ArgumentException("Unexpected element " + rootnode.LocalName + " instead of " + this.ElementName);
      }

      if (rootnode.Attributes["uom"] != null)
      {
        this.UnitOfMeasure = rootnode.Attributes["uom"].InnerText;
      }

      try
      {
        this.Value = double.Parse(rootnode.InnerText);
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Failed to parse GMLMeasureType. See inner exception for details", ex);
      }

      this.Validate();
    }

    /// <summary>
    /// Validates this message 
    /// </summary>
    public override void Validate()
    {
      if (!string.IsNullOrEmpty(this.UnitOfMeasure))
      {
        if (!Regex.IsMatch(this.UnitOfMeasure, "[^: \n\r\t]+") && !Regex.IsMatch(this.UnitOfMeasure, @"([a-zA-Z][a-zA-Z0-9\-\+\.]*:|\.\./|\./|#).*"))
        {
          throw new ValidationException("Invalid format for Unit of Measure");
        }
      }
    }
  }
}