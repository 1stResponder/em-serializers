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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using EDXLCoT;
using EDXLSharp.CAPLib;
using EDXLSharp.EDXLHAVELib;
using EDXLSharp.EDXLRMLib;
using Newtonsoft.Json;

namespace EDXLSharp.EDXLDELib
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
  public partial class ContentObject : IComposable
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
    /// <seealso cref="ContentKeywordXML"/>
    private VLList contentKeyword;

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
    /// <seealso cref="OriginatorRoleXML"/>
    private VLList originatorRole;

    /// <summary>
    /// The functional role of the message consumer 
    /// </summary>
    /// <seealso cref="ConsumerRole"/>
    /// <seealso cref="ConsumerRoleXML"/>
    private VLList consumerRole;

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
    /// <seealso cref="OtherXML"/>
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
      this.contentKeyword = new VLList("contentKeyword");
      this.consumerRole = new VLList("consumerRole");
      this.originatorRole = new VLList("originatorRole");
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
      this.contentKeyword = new VLList("contentKeyword");
      this.contentKeyword.Add(new ValueList(contentkeywordURN, contentkeywordsin));
      this.consumerRole = new VLList("consumerRole");
      this.originatorRole = new VLList("originatorRole");
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
            XmlDocument xdoc = new XmlDocument();
            using (XmlReader xr = doc.CreateReader())
            {
              xdoc.Load(xr);
            }

            IContentObject icont;

            switch (doc.Name.NamespaceName)
            {
              case EDXLConstants.CAP11Namespace:
              case EDXLConstants.CAP12Namespace:
                icont = new CAP();
                break;
              case EDXLConstants.HAVE10Namespace:
                icont = new EDXLHAVE();
                break;
              /*case EDXLConstants.SitRep10Namespace:
                icont = new SitRep();
                break;*/
              case EDXLConstants.EDXLCoTNamespace:
                icont = new CoTWrapper();
                break;
              case EDXLConstants.RM10Namespace:
                icont = new ResourceMessageType();
                break;
              /*case EDXLConstants.MEXLTEP10Namespace:
                icont = new TEP();
                break;*/
              default:
                continue;
            }

            icont.ReadXML(xdoc.FirstChild);
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

    /// <summary>
    /// Gets or sets the content keyword list.
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The ValueList that holds the topics related to the message data and content</value>
    /// <remarks>
    /// The root of the list is defined when initialized.  
    /// 
    /// For serialization/deserialization <see cref="ContentKeywordXML"/>
    /// </remarks>
    /// <seealso cref="contentKeyword"/>
    /// <seealso cref="ContentKeywordXML"/>
    [XmlIgnore]
    public IList<ValueList> ContentKeyword
    {
      get { return this.contentKeyword; }
      set { this.contentKeyword.Values = value; }
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
    /// Gets or sets The list and associated val(s).
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The functional role of the message originator.</value>
    /// <remarks>The root of the list is defined when initialized.  
    /// 
    /// For serialization/deserialization <see cref="OriginatorRoleXML"/>
    /// </remarks>
    /// <seealso cref="originatorRole"/>
    /// <seealso cref="OriginatorRoleXML"/>
    [XmlIgnore]
    public IList<ValueList> OriginatorRole
    {
      get { return this.originatorRole; }
      set { this.originatorRole.Values = value; }
    }

    /// <summary>
    /// Gets or sets the list and associated val(s).
    /// May determine message distribution and presentation decisions.
    /// </summary>
    /// <value>The functional role of the message consumer</value>
    /// <remarks>
    /// The root of the list is defined when initialized.  
    /// 
    /// 
    /// For serialization/deserialization <see cref="ConsumerRoleXML"/>
    /// </remarks>
    /// <seealso cref="consumerRole"/>
    /// <seealso cref="ConsumerRoleXML"/>
    [XmlIgnore]
    public IList<ValueList> ConsumerRole
    {
      get { return this.consumerRole; }
      set { this.consumerRole.Values = value; }
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
    /// Gets or sets custom data or Key/Signature information.
    /// Allows for signature of the content of a contentObject.
    /// </summary>
    /// <value>Custom Data or Key/Signature information for this content object.</value>
    /// <remarks>
    /// For serialization/deserialization <see cref="OtherXML"/>.
    /// </remarks>
    /// <seealso cref="other"/>
    /// <seealso cref="OtherXML"/>
    /// <seealso cref="AddOther"/>
    [XmlIgnore]
    public List<XElement> Other
    {
      get { return this.other; }
      set { this.other = value; }
    }

    
    /// <summary>
    /// Gets or sets the XML object for <see cref="ContentKeyword"/> 
    /// </summary>
    /// <value>The XML Serialization Object for Content Keyword</value>
    /// <returns>If the ContentKeyword list is not empty then the XML Serialization Object for ContentKeyword.  Otherwise, null</returns>
    /// <remarks>If value given is null then the ContentKeyword.ValuesXML is not set</remarks>
    /// <seealso cref="ContentKeyword"/>
    public ValueList[] ContentKeywordXML
    {
      get
      {
        if (this.contentKeyword.Count() == 0)
        {
          return null;
        }
        else
        {
          return this.contentKeyword.ValuesXML;
        }
      }

      set
      {
        if (value != null)
        {
          this.contentKeyword.ValuesXML = value;
        }
      }
    }

    /// <summary>
    /// Gets or sets the XML object for <see cref="OriginatorRole"/> 
    /// </summary>
    /// <value>The XML Serialization Object for OriginatorRole</value>
    /// <returns>If the OriginatorRole list is not empty then the XML Serialization Object for OriginatorRole.  Otherwise, null</returns>
    /// <remarks>If value given is null then the OriginatorRole.ValuesXML is not set</remarks>
    /// <seealso cref="OriginatorRole"/>
    public ValueList[] OriginatorRoleXML
    {
      get
      {
        if (this.originatorRole.Count() == 0)
        {
          return null;
        }
        else
        {
          return this.originatorRole.ValuesXML;
        }
      }

      set
      {
        if (value != null)
        {
          this.originatorRole.ValuesXML = value;
        }
      }
    }

    /// <summary>
    /// Gets or sets the XML object for <see cref="ConsumerRole"/> 
    /// </summary>
    /// <value>The XML Serialization Object for ConsumerRole</value>
    /// <returns>If the ConsumerRole list is not empty then the XML Serialization Object for ConsumerRole.  Otherwise, null</returns>
    /// <remarks>If value given is null then the ConsumerRole.ValuesXML is not set</remarks>
    /// <seealso cref="ConsumerRole"/>
    public ValueList[] ConsumerRoleXML
    {
      get
      {
        if (this.consumerRole.Count() == 0)
        {
          return null;
        }
        else
        {
          return this.consumerRole.ValuesXML;
        }
      }

      set
      {
        if (value != null)
        {
          this.consumerRole.ValuesXML = value;
        }
      }
    }

    /// <summary>
    /// Gets or sets the XML object for <see cref="Other"/> 
    /// </summary>
    /// <value>The XML Serialization Object for Other</value>
    /// <returns>If the Other list is not empty then the XML Serialization Object for Other.  Otherwise, null</returns>
    /// <remarks>If value given is null then the Other is not set</remarks>
    /// <seealso cref="Other"/>
    public XElement[] OtherXML
    {
      get
      {
        if (this.other.Count == 0)
        {
          return null;
        }
        else
        {
          return this.other.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.other = value.ToList();
        }
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
      int index = this.contentKeyword.FindIndex(delegate(ValueList vl) { return vl.ValueListURN == valuelisturnin; });
      return index;
    }

    /// <summary>
    /// Writes This ContentObject Into An Existing XML Document
    /// Fails if Content Object is not valid
    /// </summary>
    /// <remarks>
    /// The object MUST contain exactly one of the two content formats:
    /// <list type="number">
    ///     <item>
    ///         <term>xmlContent</term> <description>Valid namespace XML content.</description>
    ///     </item>
    ///     <item>
    ///         <term>nonXMLContent</term> 
    ///         <description>Contains one or both of the elements URI, for reference to the content’s location, 
    ///         and contentData, for data encapsulated in the message.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    /// <param name="xwriter">Existing XML Document Writer</param>
    /// <exception cref="ArgumentNullException">Content Object has no content or is missing required elements</exception>
    /// <exception cref="ArgumentException">Content Objects is carrying Both XML and Non-XML Content or has elements with invalid elements</exception>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      xwriter.WriteStartElement("contentObject");

      if (!string.IsNullOrEmpty(this.contentDescription))
      {
        xwriter.WriteElementString("contentDescription", this.contentDescription);
      }

      this.contentKeyword.WriteXML(xwriter);
      if (!string.IsNullOrEmpty(this.incidentID))
      {
        xwriter.WriteElementString("incidentID", this.incidentID);
      }

      if (!string.IsNullOrEmpty(this.incidentDescription))
      {
        xwriter.WriteElementString("incidentDescription", this.incidentDescription);
      }

      this.originatorRole.WriteXML(xwriter);
      this.consumerRole.WriteXML(xwriter);
      if (!string.IsNullOrEmpty(this.confidentiality))
      {
        xwriter.WriteElementString("confidentiality", this.confidentiality);
      }

      if (this.nonXMLContent != null)
      {
        this.nonXMLContent.WriteXML(xwriter);
      }

      if (this.xmlContent != null)
      {
        xwriter.WriteStartElement("xmlContent");
        this.xmlContent.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      foreach (XElement xe in this.other)
      {
        xe.WriteTo(xwriter);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads This ContentObject From An Existing XML Document
    /// Fails if XML Document is not a valid Content Object
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
    /// <param name="rootnode">Node That Points to the Element</param>
    /// <exception cref="ArgumentNullException">Content Object has no content or is missing required element</exception>
    /// <exception cref="ArgumentException">Content Object has both xmlContent AND nonxmlContent or there are nodes with invalid values</exception>
    /// <exception cref="FormatException">An invalid node was found</exception>
    public void ReadXML(XmlNode rootnode)
    {
      this.contentKeyword.ReadXML(rootnode);
      this.consumerRole.ReadXML(rootnode);
      this.originatorRole.ReadXML(rootnode);

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        ////This check is for xml objects that have attribs only (no innertext) like CoT
        if (node.LocalName == "xmlContent" && string.IsNullOrEmpty(node.InnerXml))
        {
          continue;
        }
        else if (node.LocalName != "xmlContent" && string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "contentDescription":
            this.contentDescription = node.InnerText;
            break;
          case "contentKeyword":
            break;
          case "incidentID":
            this.incidentID = node.InnerText;
            break;
          case "incidentDescription":
            this.incidentDescription = node.InnerText;
            break;
          case "originatorRole":
            break;
          case "consumerRole":
            break;
          case "confidentiality":
            this.confidentiality = node.InnerText;
            break;
          case "nonXMLContent":
            this.nonXMLContent = new NonXMLContentType();
            this.nonXMLContent.ReadXML(node);
            break;
          case "xmlContent":
            this.xmlContent = new XMLContentType();
            this.xmlContent.ReadXML(node);
            break;
          case "#comment":
            break;
          default:
            XElement xe = XElement.Load(new XmlNodeReader(node));
            this.other.Add(xe);
            break;
        }
      }

      this.Validate();
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