// ———————————————————————–
// <copyright file="Address.cs" company="EDXLSharp">
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
  /// Complex type that defines the structure of an address with geocode details for reuse
  /// </summary>
  [Serializable]
  public partial class AddressType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// One of the lines of the address of the Organization. If the address of the Organization
    /// consists of a single line, this element contains the entire address. If the address consists
    /// of multiple lines, this element contains one of those lines.
    /// </summary>
    private List<string> addressLine;

    /// <summary>
    /// The details of the country.
    /// </summary>
    private string country;

    /// <summary>
    /// Details of the top level area division in the country. ex: State, District, Province etc.
    /// </summary>
    private string adminArea;

    /// <summary>
    /// The next level of sub-division of the area. ex: county etc.
    /// </summary>
    private string subAdminArea;

    /// <summary>
    /// A container for a single free text or structured post code.
    /// </summary>
    private string postCode;

    /// <summary>
    /// Details of a locality, which is a named densely populated area, such as a town, village, suburb, etc.
    /// </summary>
    private string locality;

    /// <summary>
    /// A name of a thoroughfare
    /// </summary>
    private string thoroughfareName;

    /// <summary>
    /// A number on a thoroughfare
    /// </summary>
    private string thoroughfareNumber;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the AddressType class
    /// Default Constructor - Initializes List
    /// </summary>
    public AddressType()
    {
      this.addressLine = new List<string>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Details of a locality, which is a named densely populated area, such as a town, village, suburb, etc.
    /// </summary>
    public string Locality
    {
      get { return this.locality; }
      set { this.locality = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A name of a thoroughfare.
    /// </summary>
    public string ThoroughfareName
    {
      get { return this.thoroughfareName; }
      set { this.thoroughfareName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A number on a thoroughfare.
    /// </summary>
    public string ThoroughfareNumber
    {
      get { return this.thoroughfareNumber; }
      set { this.thoroughfareNumber = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for a single free text or structured post code.
    /// </summary>
    public string PostCode
    {
      get { return this.postCode; }
      set { this.postCode = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The next level of sub-division of the area. ex: county etc.
    /// </summary>
    public string SubAdminArea
    {
      get { return this.subAdminArea; }
      set { this.subAdminArea = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Details of the top level area division in the country. ex: State, District, Province etc.
    /// </summary>
    public string AdminArea
    {
      get { return this.adminArea; }
      set { this.adminArea = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The details of the country.
    /// </summary>
    public string Country
    {
      get { return this.country; }
      set { this.country = value; }
    }

    /// <summary>
    /// Gets or sets
    /// One of the lines of the address of the Organization. If the address of the Organization
    /// consists of a single line, this element contains the entire address. If the address consists
    /// of multiple lines, this element contains one of those lines.
    /// </summary>
    public List<string> AddressLine
    {
      get { return this.addressLine; }
      set { this.addressLine = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode.LocalName == "Address")
      {
        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }

          switch (childnode.LocalName)
          {
            case "FreeTextAddress":
              foreach (XmlNode addressLineNode in childnode.ChildNodes)
              {
                if (addressLineNode.LocalName == "AddressLine")
                {
                  this.addressLine.Add(addressLineNode.InnerText);
                }
                else
                {
                  throw new ArgumentException("Unexpected Child Node Name: " + addressLineNode.Name + " in AddressLineNode");
                }
              }

              break;
            case "Country":
              if (childnode.HasChildNodes && childnode.ChildNodes[0].LocalName == "NameElement")
              {
                this.country = childnode.InnerText;
              }
              else
              {
                throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in Country");
              }

              break;
            case "Locality":
              if (childnode.HasChildNodes && childnode.ChildNodes[0].LocalName == "NameElement")
              {
                this.locality = childnode.InnerText;
              }

              /*//else
              //{
              //  throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in Locality");
              //}*/

              break;
            case "PostCode":
              if (childnode.HasChildNodes && childnode.ChildNodes[0].LocalName == "Identifier")
              {
                this.postCode = childnode.ChildNodes[0].InnerText;
              }
              else
              {
                throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in PostCode");
              }

              break;
            case "AdministrativeArea":
              foreach (XmlNode adminNode in childnode.ChildNodes)
              {
                if (adminNode.LocalName == "NameElement")
                {
                  this.adminArea = adminNode.InnerText;
                }
                else if (adminNode.LocalName == "SubAdministrativeArea")
                {
                  this.subAdminArea = adminNode.InnerText;
                }
                else
                {
                  throw new ArgumentException("Unexpected Child Node Name: " + adminNode.Name + " in AdminArea");
                }
              }

              break;
            case "Thoroughfare":
              foreach (XmlNode thoroughfareNode in childnode.ChildNodes)
              {
                if (thoroughfareNode.LocalName == "NameElement")
                {
                  this.thoroughfareName = thoroughfareNode.InnerText;
                }
                else if (thoroughfareNode.LocalName == "Number")
                {
                  this.thoroughfareNumber = thoroughfareNode.InnerText;
                }
                
                /*//else
                //{
                //  throw new ArgumentException("Unexpected Child Node Name: " + thoroughfareNode.Name + " in Thoroughfare");
                //}*/
              }

              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in Address");
          }
        }
      }
      else
      {
        throw new ArgumentException("Invalid Node Name: " + rootnode.Name + " in Address");
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "Address", EDXLConstants.XPIL10Namespace);
      if (this.addressLine.Count != 0)
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "FreeTextAddress", EDXLConstants.XAL10Namespace);
        foreach (string s in this.addressLine)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }

          xwriter.WriteElementString(EDXLConstants.XALPrefix, "AddressLine", EDXLConstants.XAL10Namespace, s);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.country))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Country", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.country);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.adminArea))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "AdministrativeArea", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.adminArea);
        if (!string.IsNullOrEmpty(this.subAdminArea))
        {
          xwriter.WriteStartElement(EDXLConstants.XALPrefix, "SubAdministrativeArea", EDXLConstants.XAL10Namespace);
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.subAdminArea);
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.locality))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Locality", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.locality);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.thoroughfareName) || !string.IsNullOrEmpty(this.thoroughfareNumber))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Thoroughfare", EDXLConstants.XAL10Namespace);

        if (!string.IsNullOrEmpty(this.thoroughfareName))
        {
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.thoroughfareName);
        }

        if (!string.IsNullOrEmpty(this.thoroughfareNumber))
        {
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "Number", EDXLConstants.XAL10Namespace, this.thoroughfareNumber);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.postCode))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "PostCode", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "Identifier", EDXLConstants.XAL10Namespace, this.postCode);
        xwriter.WriteEndElement();
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Writes This Address to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="prefix">Prefix to Use For The root element</param>
    /// <param name="xmlns">Namespace to Use For The root element</param>
    public void WriteXML(XmlWriter xwriter, string prefix, string xmlns)
    {
      xwriter.WriteStartElement(prefix, "Address", xmlns);
      if (this.addressLine.Count != 0)
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "FreeTextAddress", EDXLConstants.XAL10Namespace);
        foreach (string s in this.addressLine)
        {
          if (string.IsNullOrEmpty(s))
          {
            continue;
          }

          xwriter.WriteElementString(EDXLConstants.XALPrefix, "AddressLine", EDXLConstants.XAL10Namespace, s);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.country))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Country", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.country);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.adminArea))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "AdministrativeArea", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.adminArea);
        if (!string.IsNullOrEmpty(this.subAdminArea))
        {
          xwriter.WriteStartElement(EDXLConstants.XALPrefix, "SubAdministrativeArea", EDXLConstants.XAL10Namespace);
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.subAdminArea);
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.locality))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Locality", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.locality);
        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.thoroughfareName) || !string.IsNullOrEmpty(this.thoroughfareNumber))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "Thoroughfare", EDXLConstants.XAL10Namespace);

        if (!string.IsNullOrEmpty(this.thoroughfareName))
        {
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "NameElement", EDXLConstants.XAL10Namespace, this.thoroughfareName);
        }

        if (!string.IsNullOrEmpty(this.thoroughfareNumber))
        {
          xwriter.WriteElementString(EDXLConstants.XALPrefix, "Number", EDXLConstants.XAL10Namespace, this.thoroughfareNumber);
        }

        xwriter.WriteEndElement();
      }

      if (!string.IsNullOrEmpty(this.postCode))
      {
        xwriter.WriteStartElement(EDXLConstants.XALPrefix, "PostCode", EDXLConstants.XAL10Namespace);
        xwriter.WriteElementString(EDXLConstants.XALPrefix, "Identifier", EDXLConstants.XAL10Namespace, this.postCode);
        xwriter.WriteEndElement();
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Validates this to the schema
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