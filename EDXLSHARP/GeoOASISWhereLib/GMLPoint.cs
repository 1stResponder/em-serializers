// ———————————————————————–
// <copyright file="GMLPoint.cs" company="EDXLSharp">
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
  /// A Point is defined by a single coordinate tuple
  /// </summary>
  [Serializable]
  public partial class GMLPoint : GML
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables

    /// <summary>
    /// GML Position
    /// </summary>
    private GMLPos pos;

    /// <summary>
    /// The namespace for the GMLPoint.
    /// </summary>
    private string gmlNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GMLPoint class with the specified namespace
    /// Default Constructor
    /// </summary>
    /// <param name="gmlNamespace">What namespace should be used for this object</param>
    public GMLPoint(string gmlNamespace) : base(gmlNamespace)
    {
      this.gmlNamespace = gmlNamespace;
      this.pos = new GMLPos(gmlNamespace);
    }

    /// <summary>
    /// Initializes a new instance of the GMLPoint class
    /// Default Constructor
    /// </summary>
    public GMLPoint() : this(EDXLConstants.GMLNamespace)
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// GML Position
    /// </summary>
    public GMLPos Pos
    {
      get { return this.pos; }
      set { this.pos = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Add positions To This Point
    /// </summary>
    /// <param name="positions">Double Precision positions</param>
    public void AddPositions(double[] positions)
    {
      foreach (double d in positions)
      {
        this.pos.Pos.Add(d);
      }
    }

    /// <summary>
    /// Converts This Point Into A Position String
    /// </summary>
    /// <returns>Point String</returns>
    public override string ToString()
    {
      return this.pos.ToString();
    }

    /// <summary>
    /// Reads this Object From XML
    /// </summary>
    /// <param name="rootnode">Root XML Node for this sub element</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "Point")
      {
        this.ReadXMLBase(rootnode);
        if (rootnode.ChildNodes.Count != 1)
        {
          throw new ArgumentException("Unexpected Number of Child Nodes in GMLPoint");
        }

        if (rootnode.FirstChild.LocalName != "pos")
        {
          throw new ArgumentException("Child node should be named 'pos', not '" + rootnode.FirstChild.LocalName + "'.");
        }

        this.pos.ReadXML(rootnode.FirstChild);
      }
    }

    /// <summary>
    /// Writes This Object to an XML Document
    /// </summary>
    /// <param name="xwriter">Existing XML Document Writer</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", this.gmlNamespace);
      this.ToXMLStringBase(xwriter);
      this.pos.WriteXML(xwriter);
      xwriter.WriteEndElement();
    }

    #endregion

    #region Protected Member Functions
    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      // TODO: GMLPoint.Validate - should there be more explicit validation here?
      if (this.Pos == null)
      {
        throw new ValidationException("there should be a pos internal element");
      }
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
