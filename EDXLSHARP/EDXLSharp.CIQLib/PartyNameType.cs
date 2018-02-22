// ———————————————————————–
// <copyright file="PartyNameType.cs" company="EDXLSharp">
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
using System.Collections.Generic;
using System.Xml;

namespace EDXLSharp.CIQLib
{
  /// <summary>
  /// A container to represent an individual's or organization's name
  /// </summary>
  [Serializable]
  public partial class PartyNameType
  {
    #region Private Member Variables

    /// <summary>
    /// Person Name
    /// </summary>
    private List<PersonNameType> personName;

    /// <summary>
    /// Organization Name
    /// </summary>
    private List<OrganizationName> orgName;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the PartyNameType class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public PartyNameType()
    {
      ////freeTextLines = new List<string>();
      this.personName = new List<PersonNameType>();
      this.orgName = new List<OrganizationName>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Organization Name
    /// </summary>
    public List<OrganizationName> OrganizationName
    {
      get { return this.orgName; }
      set { this.orgName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Person Name
    /// </summary>
    public List<PersonNameType> PersonName
    {
      get { return this.personName; }
      set { this.personName = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      PersonNameType persontemp;
      OrganizationName orgtemp;

      foreach (XmlNode childNode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childNode.InnerText))
        {
          continue;
        }

        switch (childNode.LocalName)
        {
          case "PersonName":
            persontemp = new PersonNameType();
            persontemp.ReadXML(childNode);
            this.personName.Add(persontemp);
            break;
          case "OrganisationName":
            orgtemp = new OrganizationName();
            orgtemp.ReadXML(childNode);
            this.orgName.Add(orgtemp);
            break;
          default:
            throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in PartyNameType");
        }
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (this.personName.Count > 0)
      {
        foreach (PersonNameType person in this.personName)
        {
          person.WriteXML(xwriter);
        }
      }

      if (this.orgName.Count > 0)
      {
        foreach (OrganizationName org in this.orgName)
        {
          org.WriteXML(xwriter);
        }
      }
    }

    #endregion

    #region Protected Member Functions

    #endregion

    #region Private Member Functions

    #endregion
  }
}