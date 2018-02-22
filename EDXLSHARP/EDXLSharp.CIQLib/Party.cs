// ———————————————————————–
// <copyright file="Party.cs" company="EDXLSharp">
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
  /// A container for defining the unique characteristics of a person or organization
  /// </summary>
  [Serializable]
  public partial class Party
  {
    #region Private Member Variables

    ////private List<string> freeTextLines;

    /// <summary>
    /// Person Name
    /// </summary>
    private PartyNameType partyName;

    /// <summary>
    /// A Container for all party Addresses
    /// </summary>
    private List<AddressType> addresses;

    /// <summary>
    /// A container for all kinds of telecommunication lines of party used for contact purposes
    /// </summary>
    private List<ContactNumber> contactNumbers;

    /// <summary>
    /// A container for defining the unique characteristics of a person only
    /// </summary>
    private List<ElectronicAddressIdentifier> electronicAddressIdentifiers;

    /// <summary>
    /// A container for a list of Identifiers to recognize the party such as customer identifier, social security number, tax number, etc
    /// </summary>
    private List<Identifier> identifiers;

    /// <summary>
    /// List of Organization Information
    /// </summary>
    private OrganizationInfo orgInfo;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the Party class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public Party()
    {
      ////freeTextLines = new List<string>();
      this.partyName = new PartyNameType();
      this.addresses = new List<AddressType>();
      this.contactNumbers = new List<ContactNumber>();
      this.electronicAddressIdentifiers = new List<ElectronicAddressIdentifier>();
      this.identifiers = new List<Identifier>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// List of Organization Information
    /// </summary>
    public OrganizationInfo OrgInfo
    {
      get { return this.orgInfo; }
      set { this.orgInfo = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for a list of Identifiers to recognize the party such as customer identifier, social security number, tax number, etc
    /// </summary>
    public List<Identifier> Identifiers
    {
      get { return this.identifiers; }
      set { this.identifiers = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for defining the unique characteristics of a person only
    /// </summary>
    public List<ElectronicAddressIdentifier> ElectronicAddressIdentifiers
    {
      get { return this.electronicAddressIdentifiers; }
      set { this.electronicAddressIdentifiers = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for all kinds of telecommunication lines of party used for contact purposes
    /// </summary>
    public List<ContactNumber> ContactNumbers
    {
      get { return this.contactNumbers; }
      set { this.contactNumbers = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A Container for all party Addresses
    /// </summary>
    public List<AddressType> Addresses
    {
      get { return this.addresses; }
      set { this.addresses = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Person Name
    /// </summary>
    public PartyNameType PartyName
    {
      get { return this.partyName; }
      set { this.partyName = value; }
    }

    /*
    /// <summary>
    /// Free text description of the party as line 1, line 2, line n. 
    /// </summary>
    public List<string> FreeTextLines
    {
      get { return freeTextLines; }
      set { freeTextLines = value; }
    }*/

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      PartyNameType partytemp;
      AddressType addresstemp;
      ContactNumber contacttemp;
      ElectronicAddressIdentifier eletemp;
      Identifier idtemp;
      foreach (XmlNode childNode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childNode.InnerText))
        {
          continue;
        }

        switch (childNode.LocalName)
        {
          case "PartyName":
            partytemp = new PartyNameType();
            partytemp.ReadXML(childNode);
            break;
          case "Addresses":
            foreach (XmlNode addressNode in childNode.ChildNodes)
            {
              if (addressNode.LocalName == "Address")
              {
                addresstemp = new AddressType();
                addresstemp.ReadXML(addressNode);
                this.addresses.Add(addresstemp);
              }
              else
              {
                throw new ArgumentException("Unexpected Node Name: " + addressNode.Name + " in PersonDetails");
              }
            }

            break;
          case "ContactNumbers":
            foreach (XmlNode contactNode in childNode.ChildNodes)
            {
              if (contactNode.LocalName == "ContactNumber")
              {
                contacttemp = new ContactNumber();
                contacttemp.ReadXML(contactNode);
                this.contactNumbers.Add(contacttemp);
              }
              else
              {
                throw new ArgumentException("Unexpected Node Name: " + contactNode.Name + " in PersonDetails");
              }
            }

            break;
          case "ElectronicAddressIdentifiers":
            foreach (XmlNode subnode in childNode.ChildNodes)
            {
              eletemp = new ElectronicAddressIdentifier();
              eletemp.ReadXML(subnode);
              this.electronicAddressIdentifiers.Add(eletemp);
            }

            break;
          case "Identifiers":
            foreach (XmlNode subnode in childNode.ChildNodes)
            {
              idtemp = new Identifier();
              idtemp.ReadXML(subnode);
              this.identifiers.Add(idtemp);
            }

            break;

          case "OrganisationInformation":
            this.orgInfo = new OrganizationInfo();
            this.orgInfo.ReadXML(childNode);
            break;

          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in PersonDetails");
        }
      }
    }

    /// <summary>
    /// Writes This GML Position to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      if (this.partyName != null)
      {
        this.partyName.WriteXML(xwriter);
      }

      if (this.addresses.Count > 0)
      {
        xwriter.WriteStartElement("Addresses", EDXLConstants.XPIL10Namespace);
        foreach (AddressType address in this.addresses)
        {
          address.WriteXML(xwriter);
        }

        xwriter.WriteEndElement();
      }

      if (this.contactNumbers.Count > 0)
      {
        xwriter.WriteStartElement("ContactNumbers", EDXLConstants.XPIL10Namespace);
        foreach (ContactNumber contact in this.contactNumbers)
        {
          contact.WriteXML(xwriter);
        }

        xwriter.WriteEndElement();
      }

      if (this.electronicAddressIdentifiers.Count > 0)
      {
        xwriter.WriteStartElement("ElectronicAddressIdentifiers", EDXLConstants.XPIL10Namespace);
        foreach (ElectronicAddressIdentifier ele in this.electronicAddressIdentifiers)
        {
          ele.WriteXML(xwriter);
        }

        xwriter.WriteEndElement();
      }

      if (this.identifiers.Count > 0)
      {
        xwriter.WriteStartElement("Identifiers", EDXLConstants.XPIL10Namespace);
        foreach (Identifier id in this.identifiers)
        {
          id.WriteXML(xwriter);
        }

        xwriter.WriteEndElement();
      }

      if (this.orgInfo != null)
      {
        this.orgInfo.WriteXML(xwriter);
      }
      ////xwriter.WriteEndElement();
    }

    #endregion

    #region Protected Member Functions

    #endregion

    #region Private Member Functions

    #endregion
  }
}