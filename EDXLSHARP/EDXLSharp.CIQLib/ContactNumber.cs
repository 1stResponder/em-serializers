// ———————————————————————–
// <copyright file="ContactNumber.cs" company="EDXLSharp">
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
  /// A container for identification document and cards of the party that are unique to the party. e.g. license, identification card, credit card, etc
  /// </summary>
  [Serializable]
  public partial class ContactNumber : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Media Type of the Contact
    /// </summary>
    private CommunicationMediaType? mediaType;

    /// <summary>
    /// Free Text expression of contact hours
    /// </summary>
    private string contactHours;

    /// <summary>
    /// List of the Contact Elements
    /// </summary>
    private List<ContactNumberElement> contactElements;

    /// <summary>
    /// Nature of contact. Example: business, personal, free call, toll free, after hours, etc
    /// </summary>
    private string usage;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ContactNumber class
    /// Default Constructor - Initializes List
    /// </summary>
    public ContactNumber()
    {
      this.contactElements = new List<ContactNumberElement>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Nature of contact. Example: business, personal, free call, toll free, after hours, etc
    /// </summary>
    public string Usage
    {
      get { return this.usage; }
      set { this.usage = value; }
    }

    /// <summary>
    /// Gets or sets
    /// List of the Contact Elements
    /// </summary>
    public List<ContactNumberElement> ContactElements
    {
      get { return this.contactElements; }
      set { this.contactElements = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Free Text expression of contact hours
    /// </summary>
    public string ContactHours
    {
      get { return this.contactHours; }
      set { this.contactHours = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Media Type of the Contact
    /// </summary>
    public CommunicationMediaType? MediaType
    {
      get { return this.mediaType; }
      set { this.mediaType = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Reads an XML Position From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the GML Position</param>
    public void ReadXML(XmlNode rootnode)
    {
      ContactNumberElement tempElement;
      if (rootnode.LocalName == "ContactNumber")
      {
        foreach (XmlAttribute attrib in rootnode.Attributes)
        {
          if (string.IsNullOrEmpty(attrib.InnerText))
          {
            continue;
          }

          switch (attrib.LocalName)
          {
            case "CommunicationMediaType":
              this.mediaType = (CommunicationMediaType)Enum.Parse(typeof(CommunicationMediaType), attrib.InnerText);
              break;
            case "ContactHours":
              this.contactHours = attrib.InnerText;
              break;
            case "Usage":
              this.usage = attrib.InnerText;
              break;
            case "#comment":
              break;
            default:
              if (attrib.Prefix != "xmlns")
              {
                throw new ArgumentException("Unexpected Attribute Name: " + attrib.Name + " in ContactNumber");
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

          if (childnode.LocalName == "ContactNumberElement")
          {
            tempElement = new ContactNumberElement();
            tempElement.ReadXML(childnode);
            this.contactElements.Add(tempElement);
          }
          else
          {
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ContactNumber");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexpected Node Name: " + rootnode.Name + " in ContactNumber");
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
      xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "ContactNumber", EDXLConstants.XPIL10Namespace);
      if (!string.IsNullOrEmpty(this.contactHours))
      {
        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "ContactHours", EDXLConstants.XPIL10Namespace, this.contactHours);
      }

      if (this.mediaType != null)
      {
        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "CommunicationMediaType", EDXLConstants.XPIL10Namespace, this.mediaType.ToString());
      }

      if (!string.IsNullOrEmpty(this.usage))
      {
        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "Usage", EDXLConstants.XPIL10Namespace, this.usage);
      }

      foreach (ContactNumberElement element in this.contactElements)
      {
        element.WriteXML(xwriter);
      }

      xwriter.WriteEndElement();
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
  }
}