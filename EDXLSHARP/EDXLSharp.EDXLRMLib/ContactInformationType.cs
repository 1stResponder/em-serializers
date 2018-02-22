// ———————————————————————–
// <copyright file="ContactInformationType.cs" company="EDXLSharp">
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

using EDXLSharp.CIQLib;
using System;
using System.Collections.Generic;
using System.Xml;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// Stores Contact Information
  /// </summary>
  [Serializable]
  public partial class ContactInformationType
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Free text Description of the Contact
    /// </summary>
    private string contactDescription;

    /// <summary>
    /// Role Information for the Contact
    /// </summary>
    private ContactRoleType? contactRole;

    /// <summary>
    /// Any other contact information including name and other Party information.
    /// </summary>
    private Party additionalContactInformation;

    /// <summary>
    /// List of Radio Information Objects To Contact This Resource
    /// </summary>
    private List<RadioInformationType> radioInformation;

    /// <summary>
    /// Location Information for the Contact
    /// </summary>
    private LocationType contactLocation;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ContactInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ContactInformationType()
    {
      this.radioInformation = new List<RadioInformationType>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Any other contact information including name and other Party information.
    /// </summary>
    public Party AdditionalContactInformation
    {
      get { return this.additionalContactInformation; }
      set { this.additionalContactInformation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Location Information for the Contact
    /// </summary>
    public LocationType ContactLocation
    {
      get { return this.contactLocation; }
      set { this.contactLocation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Role Information for the Contact
    /// </summary>
    public ContactRoleType? ContactRole
    {
      get { return this.contactRole; }
      set { this.contactRole = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free text Description of the Contact
    /// </summary>
    public string ContactDescription
    {
      get { return this.contactDescription; }
      set { this.contactDescription = value; }
    }

    /// <summary>
    /// Gets or sets
    /// List of Radio Information Objects To Contact This Resource
    /// </summary>
    public List<RadioInformationType> RadioInformation
    {
      get { return this.radioInformation; }
      set { this.radioInformation = value; }
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Protected Member Functions

    #endregion

    #region Internal Member Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="rootname">root element Name To Use</param>
    internal void WriteXML(XmlWriter xwriter, string rootname)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, rootname, EDXLConstants.RM10MsgNamespace);
      if (!string.IsNullOrEmpty(this.contactDescription))
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ContactDescription", EDXLConstants.RM10Namespace, this.contactDescription);
      }

      if (this.contactRole != null)
      {
        xwriter.WriteElementString(EDXLConstants.RM10Prefix, "ContactRole", EDXLConstants.RM10Namespace, this.contactRole.ToString());
      }

      foreach (RadioInformationType radio in this.radioInformation)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "Radio", EDXLConstants.RM10Namespace);
        radio.WriteToXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.contactLocation != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "ContactLocation", EDXLSharp.EDXLConstants.RM10Namespace);
        this.contactLocation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.additionalContactInformation != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10Prefix, "AdditionalContactInformation", EDXLConstants.RM10Namespace);
        this.additionalContactInformation.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal void ReadXML(XmlNode rootnode)
    {
      RadioInformationType radiotmp;
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ContactDescription":
            this.contactDescription = node.InnerText;
            break;
          case "ContactRole":
            this.contactRole = (ContactRoleType)Enum.Parse(typeof(ContactRoleType), node.InnerText);
            break;
          case "Radio":
            if (this.radioInformation == null)
            {
              this.radioInformation = new List<RadioInformationType>();
            }

            radiotmp = new RadioInformationType();
            radiotmp.ReadXML(node);
            this.radioInformation.Add(radiotmp);
            break;
          case "ContactLocation":
            this.contactLocation = new LocationType();
            this.contactLocation.ReadXML(node);
            break;
          case "AdditionalContactInformation":
            this.additionalContactInformation = new Party();
            this.additionalContactInformation.ReadXML(node);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ContactInformationType");
        }
      }

      this.Validate();
    }
    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    private void Validate()
    {
      if (string.IsNullOrEmpty(this.contactDescription) && this.contactRole == null)
      {
        throw new ArgumentNullException("Contact Description and Contact Role Can't Both Be NULL in ContactInformationType!");
      }
    }

    #endregion
  }
}