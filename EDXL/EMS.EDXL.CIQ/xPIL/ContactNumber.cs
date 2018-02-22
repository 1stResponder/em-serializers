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
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// A container for identification document and cards of the party that are unique to the party. e.g. license, identification card, credit card, etc
  /// </summary>
  [Serializable]
  public class ContactNumber
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
    /// ContactNumberUsageList Enumeration is EMPTY!
    /// </summary>
    private string usage;

    #endregion Private Member Variables

    #region XML Attributes

    /// <summary>
    /// Gets or sets
    /// Nature of contact. Example: business, personal, free call, toll free, after hours, etc
    /// </summary>
    [XmlAttribute("Usage")]
    public string Usage
    {
      get { return this.usage; }
      set { this.usage = value; }
    }

    /// <summary>
    /// Set flag to determine if Usage attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool UsageSpecified
    {
      get
      {
        return !string.IsNullOrWhiteSpace(this.usage);
      }
    }

    /// <summary>
    /// Gets or sets
    /// Free text expression of contact hours. e.g. 9:00AM-5:00PM
    /// </summary>
    [XmlAttribute("ContactHours")]
    public string ContactHours
    {
      get { return this.contactHours; }
      set { this.contactHours = value; }
    }

    /// <summary>
    /// Set flag to determine if MediaType attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool ContactHoursSpecified
    {
      get
      {
        return !string.IsNullOrWhiteSpace(this.contactHours);
      }
    }

    /// <summary>
    /// Gets or sets
    /// Media Type of the Contact
    /// </summary>
    [XmlAttribute("CommunicationMediaKind")]
    public CommunicationMediaType MediaType
    {
      get { return this.mediaType.Value; }
      set { this.mediaType = value; }
    }

    /// <summary>
    /// Set flag to determine if MediaType attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool MediaTypeSpecified
    {
      get
      {
        return this.mediaType.HasValue;
      }
    }
    #endregion XML Attributes

    #region XML Elements

    /// <summary>
    /// Gets or sets
    /// List of the Contact Elements
    /// </summary>
    /* 
     Using an XMLElement attribute for a List creates a "rootless" list where each
     List item uses the element name

     It is used here because the PersonDetailsType already wraps these items in an 
     XMLArray and XMLArrayItem since contactNumbers is a list of lists
     
     <contactNumbers>
       <contactNumber>
         <contactNumberElement />
         <contactNumberElement />
       </contactNumber>
       <contactNumber>
         <contactNumberElement />
       ...  
     </contactNumbers>  
    */
    [XmlElement("contactNumberElement")]
    public List<ContactNumberElement> ContactElements
    {
      get { return this.contactElements; }
      set { this.contactElements = value; }
    }

    /// <summary>
    /// Set flag to determine if contactNumberElement elements are serialized or not
    /// </summary>
    [XmlIgnore]
    public bool ContactElementsSpecified
    {
      get
      {
        return this.contactElements != null && this.contactElements.Count > 0;
      }
    }

    #endregion XML Elements
  }
}