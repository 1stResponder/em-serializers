// ———————————————————————–
// <copyright file="ContentObject.cs" company="EDXLSharp">
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

using EMS.EDXL.Utilities;
using EMS.EDXL.CT;
using EMS.EDXL.SitRep;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// The contentObject is a container element for specific messages.
  /// Additional elements (metadata) used for specific distribution of the contentObject payload
  /// or hints for processing the payload are also present in the contentObject container element.
  /// </summary>
  /// <remarks>
  /// The object MUST contain exactly one of the two content formats:
  /// <list type="number">
  ///     <item>
  ///         <term>xmlContent</term> <description>Valid namespace XML content.  When creating an DE Event message this is where Event's content is stored</description>
  ///     </item>
  ///     <item>
  ///         <term>nonXMLContent</term> 
  ///         <description>Contains one or both of the elements uri, for reference to the content’s location, 
  ///         and contentData, for data encapsulated in the message.</description>
  ///     </item>
  /// </list>
  /// </remarks>
  [Serializable]
  [JsonObject(MemberSerialization.OptIn)]
  public partial class ContentObject
  {
    #region Private Member Variables
    /// <summary>
    /// The human-readable text describing the content object. 
    /// </summary>
    /// <seealso cref="ContentDescription"/>
    private string contentDescription;

    /// <summary>
    /// The topic related to the message data and content
    /// </summary>
    /// <seealso cref="ContentKeyword"/>
    private List<DE.ValueList> contentKeyword;

    /// <summary>
    /// The human-readable text uniquely identifying the incident/event/situation associated with the contentObject. 
    /// </summary>
    /// <seealso cref="IncidentID"/>
    private string incidentID;

    /// <summary>
    /// The human-readable text describing the incident/event/situation associated with the contentObject. 
    /// </summary>
    /// <seealso cref="IncidentDescription"/>
    private string incidentDescription;

    /// <summary>
    /// The functional role of the message originator
    /// </summary>
    /// <seealso cref="OriginatorRole"/>
    private List<DE.ValueList> originatorRole;

    /// <summary>
    /// The functional role of the message consumer 
    /// </summary>
    /// <seealso cref="ConsumerRole"/>
    private List<DE.ValueList> consumerRole;

    /// <summary>
    /// Special requirements regarding confidentiality of the content of this contentObject. 
    /// </summary>
    /// <seealso cref="Confidentiality"/>
    private string confidentiality;

    /// <summary>
    /// Container for content provided in a non-XML MIME type. 
    /// </summary>
    /// <seealso cref="NonXMLContent"/>
    /// <seealso cref="NonXMLContentType"/>
    private NonXMLContentType nonXMLContent;

    /// <summary>
    /// Container for valid, namespace XML data. 
    /// </summary>
    /// <seealso cref="XMLContent"/>
    /// <seealso cref="XMLContentType"/>
    private XMLContentType xmlContent;

    /// <summary>
    /// Custom Data or Key/Signature information for this content object.
    /// </summary>
    /// <seealso cref="Other"/>
    /// <seealso cref="AddOther"/>
    private List<XElement> other;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ContentObject class
    /// Default Constructor - Initializes Lists
    /// </summary>
    public ContentObject()
    {
      this.contentKeyword = new List<DE.ValueList>();
      this.consumerRole = new List<DE.ValueList>();
      this.originatorRole = new List<DE.ValueList>();
      this.other = new List<XElement>();
    }

    /// <summary>
    /// Initializes a new instance of the ContentObject class
    /// Constructor To Initialize The Content Keyword Value List
    /// </summary>
    /// <param name="contentkeywordURN">Name of the ContentKeyword List</param>
    /// <param name="contentkeywordsin">List of Keywords</param>
    public ContentObject(string contentkeywordURN, List<string> contentkeywordsin)
    {
      this.contentKeyword = new List<DE.ValueList>();
      this.contentKeyword.Add(new DE.ValueList(contentkeywordURN, contentkeywordsin));
      this.consumerRole = new List<DE.ValueList>();
      this.originatorRole = new List<DE.ValueList>();
      this.other = new List<XElement>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets the description of the content object.
    /// </summary>
    /// <value>The human-readable text describing the content object.</value>
    /// <seealso cref="contentDescription"/>
    [XmlElement(ElementName = "contentDescription", Order = 0)]
    [JsonProperty("contentDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string ContentDescription
    {
      get { return this.contentDescription; }
      set { this.contentDescription = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool ContentDescriptionSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.ContentDescription); }
    }

    /// <summary>
    /// Gets or sets the content keyword list.
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The ValueList that holds the topics related to the message data and content</value>
    /// <remarks>
    /// The root of the list is defined when initialized.  
    /// </remarks>
    /// <seealso cref="contentKeyword"/>
    [XmlElement("contentKeyword", Order = 1)]
    [JsonProperty("contentKeyword", NullValueHandling = NullValueHandling.Ignore)]
    public List<DE.ValueList> ContentKeyword
    {
      get { return this.contentKeyword; }
      set { this.contentKeyword = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool ContentKeywordSpecified
    {
      get { return this.contentKeyword != null && this.contentKeyword.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the ID For This Incident
    /// </summary>
    /// <value>The human-readable text uniquely identifying the incident/event/situation associated with the contentObject.</value>
    /// <seealso cref="incidentID"/>
    [XmlElement(ElementName = "incidentID", Order = 2)]
    [JsonProperty("incidentID", NullValueHandling = NullValueHandling.Ignore)]
    public string IncidentID
    {
      get { return this.incidentID; }
      set { this.incidentID = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool IncidentIDSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.incidentID); }
    }

    /// <summary>
    /// Gets or sets Free Text Area Describing the Incident
    /// </summary>
    /// <value>The human-readable text describing the incident/event/situation associated with the contentObject.</value>
    /// <seealso cref="incidentDescription"/>
    [XmlElement(ElementName = "incidentDescription", Order = 3)]
    [JsonProperty("incidentDescription", NullValueHandling = NullValueHandling.Ignore)]
    public string IncidentDescription
    {
      get { return this.incidentDescription; }
      set { this.incidentDescription = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool IncidentDescriptionSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.incidentDescription); }
    }

    /// <summary>
    /// Gets or sets The list and associated val(s).
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The functional role of the message originator.</value>
    /// <remarks>The root of the list is defined when initialized.
    /// </remarks>
    /// <seealso cref="originatorRole"/>
    [XmlElement(ElementName = "originatorRole", Order = 4)]
    [JsonProperty("originatorRole", NullValueHandling = NullValueHandling.Ignore)]
    public List<DE.ValueList> OriginatorRole
    {
      get { return this.originatorRole; }
      set { this.originatorRole = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool OriginatorRoleSpecified
    {
      get { return this.originatorRole != null && this.originatorRole.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the list and associated val(s).
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The functional role of the message consumer</value>
    /// <remarks>
    /// The root of the list is defined when initialized.  
    /// </remarks>
    /// <seealso cref="consumerRole"/>
    [XmlElement(ElementName = "consumerRole", Order = 5)]
    [JsonProperty("consumerRole", NullValueHandling = NullValueHandling.Ignore)]
    public List<DE.ValueList> ConsumerRole
    {
      get { return this.consumerRole; }
      set { this.consumerRole = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool ConsumerRoleSpecified
    {
      get { return this.consumerRole != null && this.consumerRole.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the confidentiality Descriptor of the Content
    /// </summary>
    /// <value>Special requirements regarding confidentiality of the content of this contentObject.</value>
    /// <seealso cref="confidentiality"/>
    [XmlElement(ElementName = "confidentiality", Order = 6)]
    [JsonProperty("confidentiality", NullValueHandling = NullValueHandling.Ignore)]
    public string Confidentiality
    {
      get { return this.confidentiality; }
      set { this.confidentiality = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool ConfidentialitySpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.confidentiality); }
    }

    /// <summary>
    /// Gets or sets the payload of MIME Content
    /// </summary>
    /// <value>Container for content provided in a non-XML MIME type.</value>
    /// <seealso cref="nonXMLContent"/>
    /// <seealso cref="NonXMLContentType"/>
    [XmlElement(ElementName = "nonXMLContent", Order = 7)]
    [JsonProperty("nonXMLContent", NullValueHandling = NullValueHandling.Ignore)]
    public NonXMLContentType NonXMLContent
    {
      get { return this.nonXMLContent; }
      set { this.nonXMLContent = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool NonXMLContentSpecified
    {
      get { return this.nonXMLContent != null; }
    }

    /// <summary>
    /// Gets or sets the payload of XML Content
    /// </summary>
    /// <value>Container for valid, namespace XML data.</value>
    /// <remarks>When creating an DE Event message this is where Event's content would be stored</remarks>
    /// <seealso cref="xmlContent"/>
    /// <seealso cref="XMLContentType"/>
    [XmlElement(ElementName = "xmlContent", Order = 8)]
    [JsonProperty("xmlContent", NullValueHandling = NullValueHandling.Ignore)]
    public XMLContentType XMLContent
    {
      get { return this.xmlContent; }
      set { this.xmlContent = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool XMLContentSpecified
    {
      get { return this.xmlContent != null; }
    }

    /// <summary>
    /// Gets or sets custom data or Key/Signature information.
    /// Allows for signature of the content of a contentObject.
    /// </summary>
    /// <value>Custom Data or Key/Signature information for this content object.</value>
    /// <seealso cref="other"/>
    /// <seealso cref="AddOther"/>
    [XmlElement(ElementName = "other", Order = 9)]
    [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
    public List<XElement> Other
    {
      get { return this.other; }
      set { this.other = value; }
    }

    /// <summary>
    /// XMLSerializer flag to determine whether or not to serialize this field
    /// </summary>
    [XmlIgnore]
    public bool OtherSpecified
    {
      get { return this.other != null; }
    }

    //TODO: Should this be using EMLC namespaces as well to get the actual expires time? 
    /// <summary>
    /// Gets Expires time for this CO.  Uses the latest expiration time from <see cref="XMLContent"/>' EmbeddedXMLContent as the
    /// expiration.
    /// </summary>
    /// <value>Expiration time for this ContentObject</value>
    /// <returns>If XMLContent is null or if the embeddedXMLContent is not of the listed namespaces, then this returns null.  Otherwise, the latest DateTime from all of the XMLContentObjects' EmbeddedXMl</returns>
    /// <remarks>This is never serialized/deserialized</remarks>
    [XmlIgnore]
    public DateTime? ExpiresTime
    {
      get
      {
        DateTime? latestExpires = new DateTime?();
        if (this.XMLContent != null)
        {
          foreach (XElement doc in this.XMLContent.EmbeddedXMLContent)
          {
            XDocument xdoc = new XDocument();
            using (XmlReader xr = doc.CreateReader())
            {
              XDocument.Load(xr);
            }

            IContentObject icont = null;

            switch (doc.Name.NamespaceName)
            {
              //TODO: FIX Refs
              case EDXLConstants.CAP11Namespace:
              case EDXLConstants.CAP12Namespace:
                //icont = new CAP();
                break;
              case EDXLConstants.HAVE10Namespace:
                //icont = new EDXLHAVE();
                break;
              case SitRepNamespaces.v10:
                //XmlSerializer xs = new XmlSerializer(typeof(SitRepv1_0));
                //using (XmlReader reader = XmlReader.Create(new StringReader(xdoc.InnerXml)))
                //{
                  //sitRepTmp = (SitRepv1_0)xs.Deserialize(reader);
                //}
                //icont = sitRepTmp;
                break;
              case EDXLConstants.EDXLCoTNamespace:
                //icont = new CoTWrapper();
                break;
              case EDXLConstants.RM10Namespace:
                //icont = new ResourceMessageType();
                break;
              case "":  //TODO: add NIEM Namespace
                break;
              /*case EDXLConstants.MEXLTEP10Namespace:
                icont = new TEP();
                break;*/
              default:
                continue;
            }

            //icont.ReadXML(xdoc.FirstChild);
            if (latestExpires.HasValue)
            {
              if (latestExpires.Value < icont.ExpiresDateTime)
              {
                latestExpires = icont.ExpiresDateTime;
              }
            }
            else
            {
              latestExpires = icont.ExpiresDateTime;
            }
          }
        }

        return latestExpires;
      }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Adds Any other XML Content To other
    /// </summary>
    /// <param name="otherxmlin">Valid XML Element</param>
    /// <seealso cref="other"/>
    public void AddOther(XElement otherxmlin)
    {
      this.other.Add(otherxmlin);
    }

    /// <summary>
    /// Searches the Keyword Value Lists for the list with the specified name (ValueListURN).
    /// </summary>
    /// <param name="valuelisturnin">Unique Name of the List To Search For</param>
    /// <returns>Index of the Named List or -1 if not found</returns>
    public int IndexOfNamedKeywordList(string valuelisturnin)
    {
      int index = this.contentKeyword.FindIndex(delegate(DE.ValueList vl) { return vl.ValueListURN == valuelisturnin; });
      return index;
    }

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// Fails if Content Object is not valid
    /// </summary>
    /// <remarks>
    /// A Content Object is considered invalid if does not contain exactly one of the two content formats:
    /// <list type="number">
    ///     <item>
    ///         <term>xmlContent</term> <description>Valid namespace XML content.</description>
    ///     </item>
    ///     <item>
    ///         <term>nonXMLContent</term> 
    ///         <description>Contains one or both of the elements uri, for reference to the content’s location, 
    ///         and contentData, for data encapsulated in the message.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    /// <exception cref="ArgumentNullException">This Content Object Has No Content</exception>
    /// <exception cref="ArgumentException">Content Objects Can't Carry Both XML and Non-XML Content</exception>
    public void Validate()
    {
      if (this.xmlContent == null && this.nonXMLContent == null)
      {
        throw new ArgumentNullException("This Content Object Has No Content");
      }

      if (this.xmlContent != null && this.nonXMLContent != null)
      {
        throw new ArgumentException("Content Objects Can't Carry Both XML and Non-XML Content");
      }
    }
    #endregion
  }
}