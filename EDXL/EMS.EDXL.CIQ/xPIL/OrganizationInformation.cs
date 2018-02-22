//// ———————————————————————–
//// <copyright file="OrganizationInformation.cs" company="EDXLSharp">
////    Licensed under the Apache License, Version 2.0 (the "License");
////    you may not use this file except in compliance with the License.
////    You may obtain a copy of the License at
////    http://www.apache.org/licenses/LICENSE-2.0
////    Unless required by applicable law or agreed to in writing, software
////    distributed under the License is distributed on an "AS IS" BASIS,
////    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
////    See the License for the specific language governing permissions and
////    limitations under the License.
//// </copyright>
//// ———————————————————————–
                
//using System;
//using System.Collections.Generic;
//using System.ServiceModel.Syndication;
//using System.Xml;

//namespace EMS.EDXL.CIQ
//{
//  /// <summary>
//  /// Information Class About an Organization including Name, Info, Addresses, and Contact Numbers
//  /// </summary>
//  [Serializable]
//  public class OrganizationInformation 
//  {
//    #region Private Member Variables
//    /// <summary>
//    /// Name Information For the Organization
//    /// </summary>
//    private OrganisationNameType orgName;

//    /// <summary>
//    /// List of Organization Information
//    /// </summary>
//    private OrganizationInfo orgInfo;

//    /// <summary>
//    /// List of Addresses
//    /// </summary>
//    private List<AddressType> addresses;

//    /// <summary>
//    /// List of Contact Numbers
//    /// </summary>
//    private List<ContactNumber> contactNumbers;

//    /// <summary>
//    /// A container of different types of electronic addresses of party (e.g. email, chat, skype, etc)
//    /// </summary>
//    private List<ElectronicAddressIdentifier> electronicAddressIdentifiers;

//    /// <summary>
//    /// Free Text Region to Represent Comments
//    /// </summary>
//    private string commentText;

//    #endregion

//    #region Constructors

//    /// <summary>
//    /// Initializes a new instance of the OrganizationInformation class
//    /// Default Constructor - Lists
//    /// </summary>
//    public OrganizationInformation()
//    {
//      this.addresses = new List<AddressType>();
//      this.contactNumbers = new List<ContactNumber>();
//      this.electronicAddressIdentifiers = new List<ElectronicAddressIdentifier>();
//    }

//    #endregion

//    #region Public Accessors

//    /// <summary>
//    /// Gets or sets
//    /// A container of different types of electronic addresses of party (e.g. email, chat, skype, etc)
//    /// </summary>
//    public List<ElectronicAddressIdentifier> ElectronicAddressIdentifiers
//    {
//      get { return this.electronicAddressIdentifiers; }
//      set { this.electronicAddressIdentifiers = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// Free Text Region to Represent Comments
//    /// </summary>
//    public string CommentText
//    {
//      get { return this.commentText; }
//      set { this.commentText = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// List of Contact Numbers
//    /// </summary>
//    public List<ContactNumber> ContactNumbers
//    {
//      get { return this.contactNumbers; }
//      set { this.contactNumbers = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// List of Addresses
//    /// </summary>
//    public List<AddressType> Addresses
//    {
//      get { return this.addresses; }
//      set { this.addresses = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// List of Organization Information
//    /// </summary>
//    public OrganizationInfo OrgInfo
//    {
//      get { return this.orgInfo; }
//      set { this.orgInfo = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// Name Information For the Organization
//    /// </summary>
//    public OrganisationNameType OrgName
//    {
//      get { return this.orgName; }
//      set { this.orgName = value; }
//    }

//    #endregion

//    #region Public Member Functions
//    /// <summary>
//    /// Reads an XML Position From An Existing DOM
//    /// </summary>
//    /// <param name="rootnode">Node Containing the GML Position</param>
//    public void ReadXML(XmlNode rootnode)
//    {
//      AddressType addrtemp;
//      ContactNumber contacttemp;
//      ElectronicAddressIdentifier eletemp;
//      if (rootnode.LocalName == "OrganizationInformation")
//      {
//        foreach (XmlNode childnode in rootnode.ChildNodes)
//        {
//          if (string.IsNullOrEmpty(childnode.InnerText))
//          {
//            continue;
//          }

//          switch (childnode.LocalName)
//          {
//            case "OrganisationName":
//              this.orgName = new OrganisationNameType();
//              this.orgName.ReadXML(childnode);
//              break;
//            case "Addresses":
//              foreach (XmlNode addressnode in childnode.ChildNodes)
//              {
//                addrtemp = new AddressType();
//                addrtemp.ReadXML(addressnode);
//                this.addresses.Add(addrtemp);
//              }

//              break;
//            case "ContactNumbers":
//              foreach (XmlNode contactnode in childnode.ChildNodes)
//              {
//                contacttemp = new ContactNumber();
//                contacttemp.ReadXML(contactnode);
//                this.contactNumbers.Add(contacttemp);
//              }

//              break;
//            case "ElectronicAddressIdentifiers":
//              foreach (XmlNode subnode in childnode.ChildNodes)
//              {
//                eletemp = new ElectronicAddressIdentifier();
//                eletemp.ReadXML(subnode);
//                this.electronicAddressIdentifiers.Add(eletemp);
//              }

//              break;
//            case "OrganisationInformation":
//              this.orgInfo = new OrganizationInfo();
//              this.orgInfo.ReadXML(childnode);
//              break;
//            case "#comment":
//              break;
//            default:
//              throw new ArgumentException("Invalid Child Node Name: " + childnode.Name + " in OrganizationInformation");
//          }
//        }
//      }
//      else
//      {
//        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in OrganizationInformation");
//      }
//    }

//    /// <summary>
//    /// Writes This GML Position to an Existing XML Document
//    /// </summary>
//    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
//    public void WriteXML(XmlWriter xwriter)
//    {
//      xwriter.WriteStartElement("OrganizationInformation");
//      if (this.orgName != null)
//      {
//        xwriter.WriteStartElement(EDXLConstants.XNLPrefix, "OrganisationName", EDXLConstants.XNL10Namespace);
//        this.orgName.WriteXML(xwriter);
//        xwriter.WriteEndElement();
//      }

//      if (this.addresses.Count != 0)
//      {
//        xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "Addresses", EDXLConstants.XPIL10Namespace);
//        foreach (AddressType myaddress in this.addresses)
//        {
//          myaddress.WriteXML(xwriter);
//        }

//        xwriter.WriteEndElement();
//      }

//      if (this.contactNumbers.Count != 0)
//      {
//        xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "ContactNumbers", EDXLConstants.XPIL10Namespace);
//        foreach (ContactNumber contact in this.contactNumbers)
//        {
//          contact.WriteXML(xwriter);
//        }

//        xwriter.WriteEndElement();
//      }

//      if (this.electronicAddressIdentifiers.Count > 0)
//      {
//        xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "ElectronicAddressIdentifiers", EDXLConstants.XPIL10Namespace);
//        foreach (ElectronicAddressIdentifier ele in this.electronicAddressIdentifiers)
//        {
//          ele.WriteXML(xwriter);
//        }

//        xwriter.WriteEndElement();
//      }

//      if (this.orgInfo != null)
//      {
//        this.orgInfo.WriteXML(xwriter);
//      }

//      xwriter.WriteEndElement();
//    }

//    /// <summary>
//    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
//    /// </summary>
//    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
//    public void ToGeoRSS(SyndicationItem myitem)
//    {
//      if (this.orgName != null)
//      {
//        if (!string.IsNullOrEmpty(this.orgName.NameElement))
//        {
//          myitem.Authors.Add(new SyndicationPerson("foo@bar.com", this.orgName.NameElement, string.Empty));
//          myitem.Title = new TextSyndicationContent(this.orgName.NameElement);
//        }
//      }
//    }

//    /// <summary>
//    /// Validates this message
//    /// </summary>
//    public void Validate()
//    {
//    }

//    #endregion

//    #region Protected Member Functions

//    #endregion

//    #region Private Member Functions

//    #endregion
//  }
//}
