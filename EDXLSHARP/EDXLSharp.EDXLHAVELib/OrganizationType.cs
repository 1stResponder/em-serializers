// ———————————————————————–
// <copyright file="OrganizationType.cs" company="EDXLSharp">
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
using System.ServiceModel.Syndication;
using System.Xml;
using EDXLSharp.CIQLib;
using GeoOASISWhereLib;

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the OrganizationType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class OrganizationType : IComposable
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// xPIL Organization Information
    /// </summary>
    private OrganizationInformation organizationInformation;
    
    /// <summary>
    /// Geo-OASIS Where Location of the Organization
    /// </summary>
    private GeoOASISWhere organizationGeoLocation;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the OrganizationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public OrganizationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// xPIL Organization Information
    /// </summary>
    public OrganizationInformation OrganizationInformation
    {
      get { return this.organizationInformation; }
      set { this.organizationInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Geo-OASIS Where Location of the Organization
    /// </summary>
    public GeoOASISWhere OrganizationGeoLocation
    {
      get { return this.organizationGeoLocation; }
      set { this.organizationGeoLocation = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    public void ToGeoRSS(SyndicationItem myitem)
    {
      if (this.organizationInformation != null)
      {
        this.organizationInformation.ToGeoRSS(myitem);
      }

      if (this.organizationGeoLocation != null)
      {
        this.organizationGeoLocation.ToGeoRSS(myitem);
      }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "OrganizationInformation":
            this.organizationInformation = new OrganizationInformation();
            this.organizationInformation.ReadXML(childnode);
            break;
          case "OrganizationGeoLocation":
            this.organizationGeoLocation = new GeoOASISWhere();
            this.organizationGeoLocation.ReadXML(childnode.ChildNodes[0]);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in OrganizationType");
        }
      }
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (this.organizationInformation != null)
      {
        this.organizationInformation.WriteXML(xwriter);
      }

      if (this.organizationGeoLocation != null)
      {
        xwriter.WriteStartElement("OrganizationGeoLocation");
        this.organizationGeoLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    #endregion
  }
}