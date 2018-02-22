// ———————————————————————–
// <copyright file="OrganizationName.cs" company="EDXLSharp">
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
// ———————————————————————–

using System;
using System.Xml;

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// Name of an Organization
  /// </summary>
  [Serializable]
  public partial class OrganizationName : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// A unique identifier for the Organization
    /// </summary>
    private string organizationID;

    /// <summary>
    /// The name of the provider that has provided the identification scheme. This could also be the name a particular identification list.
    /// </summary>
    private string organizationIDType;

    /// <summary>
    /// Name of the Organization.
    /// </summary>
    private string nameElement;

    /// <summary>
    /// The name of the sub division Organization.
    /// </summary>
    private string subDivisionName;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the OrganizationName class
    /// Default Constructor - Does Nothing
    /// </summary>
    public OrganizationName()
    {
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// The name of the sub division Organization.
    /// </summary>
    public string SubDivisionName
    {
      get { return this.subDivisionName; }
      set { this.subDivisionName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Name of the Organization.
    /// </summary>
    public string NameElement
    {
      get { return this.nameElement; }
      set { this.nameElement = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A unique identifier for the Organization
    /// </summary>
    public string OrganizationID
    {
      get { return this.organizationID; }
      set { this.organizationID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The name of the provider that has provided the identification scheme. This could also be the name a particular identification list.
    /// </summary>
    public string OrganizationIDType
    {
      get { return this.organizationIDType; }
      set { this.organizationIDType = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlAttribute attrib in rootnode.Attributes)
      {
        if (string.IsNullOrEmpty(attrib.InnerText))
        {
          continue;
        }

        switch (attrib.LocalName)
        {
          case "OrganisationID":
            this.organizationID = attrib.InnerText;
            break;
          case "OrganisationIDType":
            this.organizationIDType = attrib.InnerText;
            break;
          case "#comment":
            break;
          default:
            if (attrib.Prefix != "xmlns")
            {
              throw new ArgumentException("Unexpected Child Attribute Name: " + attrib.Name + " in OrganizationName");
            }

            break;
        }
      }

      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "NameElement":
            this.nameElement = childnode.InnerText;
            break;
          case "SubDivisionName":
            this.subDivisionName = childnode.InnerText;
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in OrganizationName");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      if (!string.IsNullOrEmpty(this.organizationID))
      {
        xwriter.WriteAttributeString(EDXLConstants.XNLPrefix, "OrganisationID", EDXLConstants.XNL10Namespace, this.organizationID);
      }

      if (!string.IsNullOrEmpty(this.organizationIDType))
      {
        xwriter.WriteAttributeString(EDXLConstants.XNLPrefix, "OrganisationIDType", EDXLConstants.XNL10Namespace, this.organizationIDType);
      }

      if (!string.IsNullOrEmpty(this.nameElement))
      {
        xwriter.WriteElementString(EDXLConstants.XNLPrefix, "NameElement", EDXLConstants.XNL10Namespace, this.nameElement);
      }

      if (!string.IsNullOrEmpty(this.subDivisionName))
      {
        xwriter.WriteElementString(EDXLConstants.XNLPrefix, "SubDivisionName", EDXLConstants.XNL10Namespace, this.subDivisionName);
      }
    }

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    #endregion

    #region Private Member Functions

    #endregion
  }
}