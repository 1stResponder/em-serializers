// ———————————————————————–
// <copyright file="LocationType.cs" company="EDXLSharp">
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
using EDXLSharp.CIQLib;
using GeoOASISWhereLib;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// Describes a Location
  /// </summary>
  [Serializable]
  public partial class LocationType
  {
    #region Private Member Variables
    /// <summary>
    /// Description of the Location
    /// </summary>
    private string locationDescription;

    /// <summary>
    /// Address for a Location
    /// </summary>
    private AddressType address;

    /// <summary>
    /// Geo-Coordinates for a Location
    /// </summary>
    private GeoOASISWhere targetArea;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the LocationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public LocationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// Geo-Coordinates for a Location
    /// </summary>
    public GeoOASISWhere TargetArea
    {
      get { return this.targetArea; }
      set { this.targetArea = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Address for a Location
    /// </summary>
    public AddressType Address
    {
      get { return this.address; }
      set { this.address = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Description of the Location
    /// </summary>
    public string LocationDescription
    {
      get { return this.locationDescription; }
      set { this.locationDescription = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      if (!string.IsNullOrEmpty(this.locationDescription))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "LocationDescription", EDXLSharp.EDXLConstants.RM10Namespace, this.locationDescription.ToString());
      }

      if (this.address != null)
      {
        this.address.WriteXML(xwriter, EDXLConstants.RM10Prefix, EDXLConstants.RM10Namespace);
      }

      if (this.targetArea != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "TargetArea", EDXLSharp.EDXLConstants.RM10Namespace);
        this.targetArea.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "LocationDescription":
            this.locationDescription = node.InnerText;
            break;
          case "Address":
            this.address = new AddressType();
            this.address.ReadXML(node);
            break;
          case "TargetArea":
            this.targetArea = new GeoOASISWhere();
            this.targetArea.ReadXML(node.FirstChild);
            break;
        }
      }
    }
    #endregion
  }
}
