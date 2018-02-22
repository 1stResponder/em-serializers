// ———————————————————————–
// <copyright file="EDXLDE.cs" company="EDXLSharp">
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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
//using System.Net.Mail;
//using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using EMS.EDXL.Utilities;
using EMS.EDXL.CT;

namespace EMS.EDXL.DE.v1_0
{
  /// <summary>
  /// Class To Represent an EDXL-DE Message.  
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  [XmlRoot(ElementName = "EDXLDistribution", IsNullable = false, Namespace = EDXLConstants.EDXLDE10Namespace)]
  public class DEv1_0
  {
    /// <summary>
    /// Regular expression representing valid values/formats for a language in the DE
    /// Uses RFC3066 specification
    /// </summary>
    /// <seealso cref="Language"/>
    private static Regex languageRegex = new Regex("^[A-Za-z]{1,8}(-[A-Za-z0-9]{1,8})*$", RegexOptions.None);

    /// <summary>
    /// Stores Concatenated Schema Validation Errors
    /// </summary>
    /// <seealso cref="ValidateToSchema"/>
    private string schemaErrorString = string.Empty;

   /* /// <summary>
    /// Stores Number of Schema Validation Errors
    /// </summary>
    /// <seealso cref="ValidateToSchema"/>
    private int schemaErrors = 0;*/

    /// <summary>
    /// The unique identifier of this distribution message
    /// Required Element
    /// </summary>
    /// <seealso cref="DistributionID"/>
    private string distributionID;

    /// <summary>
    /// The unique identifier of the sender. 
    /// Required element
    /// </summary>
    /// <seealso cref="SenderID"/>
    /// <seealso cref="CheckSenderID"/>
    private string senderID;

    /// <summary>
    /// The date and time the distribution message was sent in UTC.
    /// Required Element
    /// </summary>
    /// <seealso cref="DateTimeSent"/>
    /// <seealso cref="XmlDateTime"/>
    private EDXLDateTime? datetimeSent;

    /// <summary>
    /// How actionable is the message.  
    /// Required Element
    /// Describes the kind of information/purpose of the information that the message holds.
    /// e.g. Actual (real-world information that needs action) vs Exercise (simulated information for an exercise).
    /// </summary>
    /// <seealso cref="DistributionStatus"/>
    private StatusValue? distributionStatus;

    /// <summary>
    /// The function of the message. 
    /// Required Element
    /// </summary>
    /// <seealso cref="DistributionType"/>
    private TypeValue? distributionType;

    /// <summary>
    /// The confidentially of all the DE message's ContentObjects as a whole.
    /// </summary>
    /// <seealso cref="CombinedConfidentiality"/>
    private string combinedConfidentiality;

    /// <summary>
    /// The primary language (but not necessarily exclusive) used in the payloads.
    /// </summary>
    /// <seealso cref="Language"/>
    private string language;

    /// <summary>
    /// The functional role of the sender, as it may determine message routing decisions. 
    /// </summary>
    /// <seealso cref="SenderRole"/>
    private List<ValueList> senderRole;

    /// <summary>
    /// The functional role of the recipient, as it may determine message routing decisions. 
    /// </summary>
    /// <seealso cref="RecipientRole"/>
    private List<ValueList> recipientRole;

    /// <summary>
    /// The topic related to the distribution message, as it may determine message routing decisions. 
    /// </summary>
    /// <seealso cref="Keyword"/>
    private List<ValueList> keyword;

    /// <summary>
    /// A reference to a previous distribution message. 
    /// </summary>
    /// <seealso cref="DistributionReference"/>
    private List<string> distributionReference;

    /// <summary>
    /// The identifier of an explicit recipient. 
    /// </summary>
    /// <seealso cref="ExplicitAddress"/>    
    private List<ValueScheme> explicitAddress;

    /// <summary>
    /// The container element for location information. 
    /// </summary>
    /// <seealso cref="TargetArea"/>
    private List<TargetAreaType> targetArea;

    /// <summary>
    /// List of ContentObjects which represent the container element for message data and content
    /// </summary>
    /// <seealso cref="ContentObjects"/>
    /// <seealso cref="ContentObject"/>
    private List<ContentObject> contentObjects;

    /// <summary>
    /// Initializes a new instance of the EDXLDE class
    /// Default Constructor - Initializes Lists and Populates Xmlns with necessary namespace(s)
    /// </summary>
    public DEv1_0()
    {
      this.contentObjects = new List<ContentObject>();
      this.distributionReference = new List<string>();
      this.explicitAddress = new List<ValueScheme>();
      this.keyword = new List<ValueList>();
      this.recipientRole = new List<ValueList>();
      this.senderRole = new List<ValueList>();
      this.targetArea = new List<TargetAreaType>();
      //this.distributionReference.ListChanged += new ListChangedEventHandler(this.DistributionRefHandler);
      this.Xmlns = new XmlSerializerNamespaces();
    }

    /// <summary>
    /// Gets or Sets Namespace object
    /// Used during serialization to define prefixes for the namespace(s)
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is suppressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the id for this message 
    /// Required element
    /// </summary>
    /// <value>Unique identifier for this distribution message</value>
    /// <remarks>ID must be unique to the sender of the message</remarks>
    /// <seealso cref="distributionID"/>
    [XmlElement(ElementName = "distributionID", Order = 0)]
    [JsonProperty("distributionID", NullValueHandling = NullValueHandling.Ignore)]
    public string DistributionID
    {
      get { return this.distributionID; }
      set { this.distributionID = value; }
    }

    /// <summary>
    /// Gets or sets ID of the sender. 
    /// Required element
    /// </summary>
    /// <value>Unique value which identifies the sender</value>
    /// <remarks>Requirements:
    /// <list type="number">
    ///     <item>
    ///         <description>ID must uniquely identify human parties, systems, services, or devices that are potential
    /// senders of the distribution message.</description>
    ///     </item>
    ///     <item>
    ///         <description>ID must be in the form actor@domain-name.</description>
    ///     </item>
    /// </list>
    /// 
    /// Uniqueness of the domain-name is guaranteed through use of the Internet Domain Name
    /// System, and uniqueness of the actor name is enforced by the domain owner</remarks>
    /// <seealso cref="senderID"/>
    /// <seealso cref="CheckSenderID"/>
    /// <exception cref="FormatException">value is not in the form: actor@domain</exception>
    /// <exception cref="ArgumentNullException">value is null</exception>
    [XmlElement(ElementName = "senderID", Order = 1)]
    [JsonProperty("senderID", NullValueHandling = NullValueHandling.Ignore)]
    public string SenderID
    {
      get
      {
        return this.senderID;
      }

      set
      {
        this.CheckSenderID(value);
        this.senderID = value;
      }
    }

    /// <summary>
    /// Gets or sets the DateTime for when this message was sent in UTC.  
    /// Required Element
    /// </summary>
    /// <value>The UTC DateTime for when this message was sent</value>
    /// <remarks>
    /// If value is a DateTime with no timezone information then datetimeSent is set to DateTime's min value.  
    /// 
    /// For serialization/deserialization <see cref="XmlDateTime"/> </remarks>
    /// <exception cref="ArgumentException">value does not specify timezone information</exception>
    /// <seealso cref="datetimeSent"/>
    /// <seealso cref="XmlDateTime"/>
    [XmlIgnore]
    public DateTime DateTimeSent
    {
      get
      {
        return ((DateTime)this.datetimeSent).ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.datetimeSent = value.ToUniversalTime();
        }
        else
        {
          this.datetimeSent = DateTime.MinValue;
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets the expiration DateTime for this message.  Uses the earliest expiration time from <see cref="contentObjects"/> as the
    /// expiration.
    /// </summary>
    /// <value>The expiration DateTime for this message</value>
    /// <returns>If there are no content objects then null, otherwise the latest DateTime at which this message is
    /// considered invalid from contentObjects(which may also be null)</returns>
    /// <remarks>This is not serialized/deserialized</remarks>
    [XmlIgnore]
    public DateTime? ExpiresDateTime
    {
      get
      {
        DateTime? latestExpires = new DateTime?();

        if (this.contentObjects != null)
        {
          foreach (ContentObject cobject in this.contentObjects)
          {
            if (cobject.ExpiresTime != null)
            {
              if (latestExpires.HasValue)
              {
                if (latestExpires.Value < cobject.ExpiresTime)
                {
                  latestExpires = cobject.ExpiresTime;
                }
              }
              else
              {
                latestExpires = cobject.ExpiresTime;
              }
            }
          }
        }

        return latestExpires;
      }
    }

    /// <summary>
    /// Gets or sets the distribution status.
    /// Required Element
    /// </summary>
    /// <value>The status value which describes how actionable the message is.</value>
    /// <remarks>
    /// Describes the kind of information/purpose of the information that the message holds, the message's actionability.
    /// e.g. Actual (real-world information that needs action) vs Exercise (simulated information for an exercise).
    /// </remarks>
    /// <seealso cref="distributionStatus"/>
    /// <seealso cref="StatusValue"/>
    [XmlElement(ElementName = "distributionStatus", Order = 3)]
    [JsonProperty("distributionStatus", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StatusValue DistributionStatus
    {
      get
      {
        StatusValue tmp;

        if (this.distributionStatus.HasValue)
        {
          tmp = this.distributionStatus.Value;
        }
        else
        {
          tmp = StatusValue.Test;
        }

        return tmp;
      }
      set { this.distributionStatus = value; }
    }

    /// <summary>
    /// Gets or sets the distribution type.
    /// Required Element
    /// </summary>
    /// <value>The TypeValue which describes the function of the message</value>
    /// <seealso cref="distributionType"/>
    /// <seealso cref="TypeValue"/>
    [XmlElement(ElementName = "distributionType", Order = 4)]
    [JsonProperty("distributionType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TypeValue DistributionType
    {
      get
      {
        TypeValue tmp;

        if (this.distributionType.HasValue)
        {
          tmp = this.distributionType.Value;
        }
        else
        {
          tmp = TypeValue.NoAppropriateDefault;
        } 
        return tmp;
      }
      set { this.distributionType = value; }
    }

    /// <summary>
    /// Gets or sets the combined confidentiality of this message's ContentObjects
    /// </summary>
    /// <value>The confidentially of all the DE message's ContentObjects as a whole.</value>
    /// <remarks>
    /// In general (not always), the combined confidentiality of this DE is more restrictive then any of the 
    /// individual confidentialities found in this DE's content objects container.
    /// </remarks>
    /// <seealso cref="combinedConfidentiality"/>
    [XmlElement(ElementName = "combinedConfidentiality", Order = 5)]
    [JsonProperty("combinedConfidentiality", NullValueHandling = NullValueHandling.Ignore)]
    public string CombinedConfidentiality
    {
      get { return this.combinedConfidentiality; }
      set { this.combinedConfidentiality = value; }
    }

    /// <summary>
    /// Gets or sets the language
    /// </summary>
    /// <value> The primary language (but not necessarily exclusive) used in the payloads.</value>
    /// <remarks>Valid language values are supplied in the ISO standard [RFC3066].</remarks>
    /// <exception cref="ArgumentException">value is null or not in RFC3066 form: xx-xx</exception>
    /// <seealso cref="language"/>
    /// <seealso cref="CheckRFC3066"/>
    /// <seealso cref="languageRegex"/>
    [XmlElement(ElementName = "language", Order = 6)]
    [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
    public string Language
    {
      get
      {
        return this.language;
      }

      set
      {
        this.CheckRFC3066(value);
        this.language = value;
      }
    }

    /// <summary>
    /// Indicates whether or not the Language was specified
    /// </summary>
    [XmlIgnore]
    public bool LanguageSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.language); }
    }

    /// <summary>
    /// Gets or sets the sender role.
    /// Sender role may determine how message are routed.
    /// </summary>
    /// <value>The value list which represents the functional role of the sender</value>
    /// <remarks>
    /// The root name of this list is specified when the list is initialized.
    /// </remarks>
    /// <seealso cref="senderRole"/>
    [XmlElement(ElementName = "senderRole", Order = 7)]
    [JsonProperty("senderRole", NullValueHandling = NullValueHandling.Ignore)]
    public List<ValueList> SenderRole
    {
      get { return this.senderRole; }
      set { this.senderRole = value; }
    }

    /// <summary>
    /// Indicates whether or not the Sender Role was specified
    /// </summary>
    [XmlIgnore]
    public bool SenderRoleSpecified
    {
      get { return this.senderRole != null && this.senderRole.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the recipient role.
    /// May determine how message are routed 
    /// </summary>
    /// <value>The value list which represents the functional role of the recipient</value>
    /// <remarks>
    /// The root name of this list is specified when the list is initialized.
    /// </remarks>
    /// <seealso cref="recipientRole"/>
    [XmlElement(ElementName = "recipientRole", Order = 8)]
    [JsonProperty("recipientRole", NullValueHandling = NullValueHandling.Ignore)]
    public List<ValueList> RecipientRole
    {
      get { return this.recipientRole; }
      set { this.recipientRole = value; }
    }

    /// <summary>
    /// Indicates whether or not the Recipient Role was specified
    /// </summary>
    [XmlIgnore]
    public bool RecipientRoleSpecified
    {
      get { return this.recipientRole != null && this.recipientRole.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the keyword for this message.
    /// The keyword may determine message routing decisions
    /// </summary>
    /// <value>The value list which represents the topic related to the distribution message</value>
    /// <remarks>
    /// The root name of this list is specified when the list is initialized.
    /// </remarks>
    /// <seealso cref="keyword"/>
    [XmlElement(ElementName = "keyword", Order = 9)]
    [JsonProperty("keyword", NullValueHandling = NullValueHandling.Ignore)]
    public List<ValueList> Keyword
    {
      get { return this.keyword; }
      set { this.keyword = value; }
    }

    /// <summary>
    /// Indicates whether or not the Keyword was specified
    /// </summary>
    [XmlIgnore]
    public bool KeywordSpecified
    {
      get { return this.keyword != null && this.keyword.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the distribution reference. 
    /// </summary>
    /// <value>The list which represents a reference to a previous distribution message</value>
    /// <remarks>Must contain the distributionID, senderID, and dateTimeSent of the referenced 
    /// distribution message.
    /// </remarks>
    /// <seealso cref="CheckDistributionReference"/>
    /// <seealso cref="distributionReference"/>
    [XmlElement(ElementName = "distributionReference", Order = 10)]
    [JsonProperty("distributionReference", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> DistributionReference
    {
      get { return this.distributionReference; }
      set { this.distributionReference = value; }
    }

    /// <summary>
    /// Indicates whether or not the Distribution Reference was specified
    /// </summary>
    [XmlIgnore]
    public bool DistributionReferenceSpecified
    {
      get { return this.distributionReference != null && this.distributionReference.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the explicit address.
    /// </summary>
    /// <value>
    /// The ValueScheme list which represents the identifier of an explicit recipient.
    /// </value>
    /// <remarks>
    /// </remarks>
    /// <seealso cref="explicitAddress"/>
    [XmlElement(ElementName = "explicitAddress", Order = 11)]
    [JsonProperty("explicitAddress", NullValueHandling = NullValueHandling.Ignore)]
    public List<ValueScheme> ExplicitAddress
    {
      get { return this.explicitAddress; }
      set { this.explicitAddress = value; }
    }

    /// <summary>
    /// Indicates whether or not the Explicit Address was specified
    /// </summary>
    [XmlIgnore]
    public bool ExplicitAddressSpecified
    {
      get { return this.explicitAddress != null && this.explicitAddress.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the target Area
    /// </summary>
    /// <value>The List of TargetAreaTypes that represents the container for location information</value>
    /// <remarks> Multiple targetArea blocks may appear in a single EDXLDistribution element, in which
    /// case the target area for the current message is the union of all areas described in the
    /// various targetArea structures. 
    /// </remarks>
    /// <seealso cref="targetArea"/>
    [XmlElement(ElementName = "targetArea", Order = 12)]
    [JsonProperty("targetArea", NullValueHandling = NullValueHandling.Ignore)]
    public List<TargetAreaType> TargetArea
    {
      get { return this.targetArea; }
      set { this.targetArea = value; }
    }

    /// <summary>
    /// Indicates whether or not the Target Area was specified
    /// </summary>
    [XmlIgnore]
    public bool TargetAreaSpecified
    {
      get { return this.targetArea != null && this.targetArea.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the list of content objects
    /// May have an attribute that defines a namespace prefix which resolves ambiguous element names.
    /// </summary>
    /// <value>List of ContentObjects which represent the container element for message data and content</value>
    /// <remarks>
    /// The contentObject element MUST contain exactly one of the two content formats:
    /// <list type="number">
    ///     <item>
    ///         <term>xmlContent</term> <description>Valid namespace XML content. \(When creating an DE Event message this is where Event's content is stored\)</description>
    ///     </item>
    ///     <item>
    ///         <term>nonXMLContent</term> 
    ///         <description>Contains one or both of the elements URI, for reference to the content’s location, 
    ///         and contentData, for data encapsulated in the message.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    /// <seealso cref="contentObjects"/>
    [XmlElement(ElementName = "contentObject", Order = 13)]
    [JsonProperty("contentObject", NullValueHandling = NullValueHandling.Ignore)]
    public List<ContentObject> ContentObjects
    {
      get { return this.contentObjects; }
      set { this.contentObjects = value; }
    }

    /// <summary>
    /// Indicates whether or not the Content Object was specified
    /// </summary>
    [XmlIgnore]
    public bool ContentObjectsSpecified
    {
      get { return this.contentObjects != null && this.contentObjects.Count > 0; }
    }

    /// <summary>
    /// Gets or sets the XML object for <see cref="DateTimeSent"/> 
    /// </summary>
    /// <value>The XML Serialization Object for DateTimeSent</value>
    /// <remarks>The DateTime must include the time zone offset and be in W3C format</remarks>
    /// <example>Format of XML for DateTime: 
    /// 2004-08-01T16:49:00-07:00
    /// </example>
    /// <exception cref="ArgumentNullException">If value is null</exception>
    /// <exception cref="ArgumentException">If value is the incorrect format or does not specify timezone</exception>
    /// <seealso cref="DateTimeSent"/>
    [XmlElement(ElementName = "dateTimeSent", Order = 2)]
    [JsonProperty("dateTimeSent", NullValueHandling = NullValueHandling.Ignore)]
    public string XmlDateTime
    {
      get
      {
        return this.datetimeSent.Value.EDXLCustomFormat;
      }

      set
      {
        try
        {
          this.datetimeSent = DateTime.Parse(value);
        }
        catch (ArgumentNullException)
        {
          throw new ArgumentNullException("Input Value Can't Be Null!");
        }
        catch (FormatException)
        {
          throw new ArgumentException("Invalid Input String");
        }

        if (((DateTime)this.datetimeSent).Kind == DateTimeKind.Unspecified)
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    ///// <summary>
    ///// Gets or sets the XML object for <see cref="SenderRole"/> 
    ///// </summary>
    ///// <value>The XML Serialization Object for SenderRole</value>
    ///// <returns>If the senderRole list is not empty, then the XML Serialization Object for Sender Role.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the SenderRole.ValuesXML is not set</remarks>
    ///// <seealso cref="SenderRole"/>
    //[XmlElement(ElementName = "senderRole", Order = 7)]
    //[JsonProperty("senderRole", NullValueHandling = NullValueHandling.Ignore)]
    //public ValueList[] SenderRoleXML
    //{
    //  get
    //  {
    //    if (this.senderRole.Count() == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.senderRole.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.senderRole = value.ToList();
    //    }
    //  }
    //}

    ///// <summary>
    ///// Gets or sets XML object for <see cref="RecipientRole"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for RecipientRole</value>
    ///// <returns>If the RecipientRole list is not empty, then the XML Serialization Object for Recipient Role.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the RecipientRole.ValuesXML is not set</remarks>
    ///// <seealso cref="RecipientRole"/>
    //[XmlElement(ElementName = "recipientRole", Order = 8)]
    //[JsonProperty("recipientRole", NullValueHandling = NullValueHandling.Ignore)]
    //public ValueList[] RecipientRoleXML
    //{
    //  get
    //  {
    //    if (this.recipientRole.Count() == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.recipientRole.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.recipientRole = value.ToList();
    //    }
    //  }
    //}

    ///// <summary>
    ///// Gets or sets XML object for <see cref="Keyword"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for Keyword</value>
    ///// <returns>If the Keyword list is not empty then the XML Serialization Object for Keyword.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the Keyword.ValuesXML is not set</remarks>
    ///// <seealso cref="Keyword"/>
    //[XmlElement(ElementName = "keyword", Order = 9)]
    //[JsonProperty("keyword", NullValueHandling = NullValueHandling.Ignore)]
    //public ValueList[] KeywordXML
    //{
    //  get
    //  {
    //    if (this.keyword.Count() == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.keyword.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.keyword = value.ToList();
    //    }
    //  }
    //}

    ///// <summary>
    ///// Gets or sets the XML Serialization Object for Distribution Reference, <see cref="DistributionReference"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for DistributionReference</value>
    ///// <returns>If the DistributionReference list is not empty then the XML Serialization Object for DistributionReference.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the DistributionReference is not set
    ///// 
    ///// Serialized value must be distributionID, senderID, and then dateTimeSent concatenated with a comma delimiter.
    ///// </remarks>
    ///// <seealso cref="CheckDistributionReference"/>
    ///// <seealso cref="DistributionReference"/>
    //[XmlElement(ElementName = "distributionReference", Order = 10)]
    //[JsonProperty("distributionReference", NullValueHandling = NullValueHandling.Ignore)]
    //public string[] DistributionReferenceXML
    //{
    //  get
    //  {
    //    if (this.distributionReference.Count == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.distributionReference.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.distributionReference = new List<string>(value.ToList());
    //    }
    //  }
    //}


    ///// <summary>
    ///// Gets or sets the XML Object for Explicit Address, <see cref="ExplicitAddress"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for ExplicitAddress</value>
    ///// <returns>If the ExplicitAddress list is not empty then the XML Serialization Object for ExplicitAddress.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the ExplicitAddress is not set
    ///// The root name of this list is specified when the list is initialized.
    ///// </remarks>
    ///// <seealso cref="ExplicitAddress"/>
    //[XmlElement(ElementName = "explicitAddress", Order = 11)]
    //[JsonProperty("explicitAddress", NullValueHandling = NullValueHandling.Ignore)]
    //public ValueScheme[] ExplicitAddressXML
    //{
    //  get
    //  {
    //    if (this.explicitAddress.Count == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.explicitAddress.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.explicitAddress = value.ToList();
    //    }
    //  }
    //}


    ///// <summary>
    ///// Gets or sets the XML object for <see cref="TargetArea"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for TargetArea</value>
    ///// <returns>If the TargetArea list is not empty then the XML Serialization Object for TargetArea.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the TargetArea is not set</remarks>
    ///// <seealso cref="TargetArea"/> 
    //[XmlElement(ElementName = "targetArea", Order = 12)]
    //[JsonProperty("targetArea", NullValueHandling = NullValueHandling.Ignore)]
    //public TargetAreaType[] TargetAreaXML
    //{
    //  get
    //  {
    //    if (this.targetArea.Count == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.targetArea.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.targetArea = value.ToList();
    //    }
    //  }
    //}

    ///// <summary>
    ///// Gets or sets the XML object for <see cref="contentObjects"/> 
    ///// </summary>
    ///// <value> The XML Serialization Object for ContentObjects</value>
    ///// <returns>If the ContentObjects list is not empty then the XML Serialization Object for ContentObjects.  Otherwise, null</returns>
    ///// <remarks>If value given is null then the ContentObjects is not set</remarks>
    ///// <seealso cref="contentObjects"/> 
    //[XmlElement(ElementName = "contentObject", Order = 13)]
    //[JsonProperty("contentObject", NullValueHandling = NullValueHandling.Ignore)]
    //public ContentObject[] ContentObjectsXML
    //{
    //  get
    //  {
    //    if (this.contentObjects.Count == 0)
    //    {
    //      return null;
    //    }
    //    else
    //    {
    //      return this.contentObjects.ToArray();
    //    }
    //  }

    //  set
    //  {
    //    if (value != null)
    //    {
    //      this.contentObjects = value.ToList();
    //    }
    //  }
    //}

      /*
    /// <summary>
    /// Writes This DE Object to an XML String.
    /// If <see cref="EDXLConstants.SecondarySchemaValidation"/> is set to true then this will run secondary validation against the EDXLDE schema.
    /// Fails if the object is not valid for XML or if the object fails secondary validation.
    /// </summary>
    /// <returns>String of XML Data</returns>
    /// <exception cref="ArgumentNullException">A required element is missing or set to the default value.</exception>
    /// <exception cref="ArgumentException">The object will create invalid XML or has failed secondary schema validation.  
    /// It may not conform to the DE Standard or may contain an invalid property/value.</exception>
    /// <seealso cref="Validate"/>
    /// <seealso cref="CheckDistributionReference"/>
    /// <seealso cref="ValidateToSchema"/>
    /// <seealso cref="ValueScheme.WriteXML(XmlWriter)"/>
    /// <seealso cref="TargetAreaType.WriteXML(XmlWriter)"/>
    /// <seealso cref="ContentObject.WriteXML(XmlWriter)"/>
    /// <seealso cref="List<ValueList>.WriteXML(XmlWriter)"/>*/
    //public string WriteToXML()
    //{
    //  this.Validate();
    //  XmlWriterSettings xsettings = new XmlWriterSettings();
    //  xsettings.Indent = true;
    //  xsettings.IndentChars = "\t";
    //  xsettings.Encoding = Encoding.UTF8;
    //  StringBuilder output = new StringBuilder();
    //  using (XmlWriter xwriter = XmlWriter.Create(output, xsettings))
    //  {
    //    //TODO:fix
    //    //PropertyInfo innerWriterPropInfo = xwriter.GetType().GetProperty("InnerWriter", BindingFlags.NonPublic | BindingFlags.Instance);
    //    //XmlWriter innerWriter = (XmlWriter)innerWriterPropInfo.GetValue(xwriter, null);
    //    //FieldInfo encodingFieldInfo = innerWriter.GetType().GetField("encoding", BindingFlags.NonPublic | BindingFlags.Instance);
    //    //encodingFieldInfo.SetValue(innerWriter, Encoding.UTF8);
    //    xwriter.WriteStartDocument(false);
    //    xwriter.WriteStartElement("EDXLDistribution", EDXLConstants.EDXLDE10Namespace);
    //    xwriter.WriteElementString("distributionID", this.distributionID);
    //    xwriter.WriteElementString("senderID", this.senderID);
    //    xwriter.WriteElementString("dateTimeSent", this.datetimeSent.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
    //    xwriter.WriteElementString("distributionStatus", this.distributionStatus.ToString());
    //    xwriter.WriteElementString("distributionType", this.distributionType.ToString());
    //    xwriter.WriteElementString("combinedConfidentiality", this.combinedConfidentiality);
    //    if (!string.IsNullOrEmpty(this.language))
    //    {
    //      xwriter.WriteElementString("language", this.language);
    //    }

    //    this.senderRole.WriteXML(xwriter);
    //    this.recipientRole.WriteXML(xwriter);
    //    this.keyword.WriteXML(xwriter);

    //    foreach (string distribution in this.distributionReference)
    //    {
    //      if (string.IsNullOrEmpty(distribution))
    //      {
    //        continue;
    //      }

    //      this.CheckDistributionReference(distribution);
    //      xwriter.WriteElementString("distributionReference", distribution);
    //    }

    //    foreach (ValueScheme scheme in this.explicitAddress)
    //    {
    //      scheme.WriteXML(xwriter);
    //    }

    //    foreach (TargetAreaType target in this.targetArea)
    //    {
    //      target.WriteXML(xwriter);
    //    }

    //    foreach (ContentObject obj in this.contentObjects)
    //    {
    //      obj.WriteXML(xwriter);
    //    }

    //    xwriter.WriteEndElement();
    //    xwriter.Flush();
    //  }

    //  string strout = this.StripUnprintableCharacters(output.ToString());

    //  if (EDXLConstants.SecondarySchemaValidation)
    //  {
    //    this.ValidateToSchema(strout);
    //  }

    //  return strout;
    //}

    ///// <summary>
    ///// Writes This DE Object to a Stream
    ///// If <see cref="EDXLConstants.SecondarySchemaValidation"/> is set to true then this will run secondary validation against the EDXLDE schema.
    ///// Fails if the object is not valid for XML or if the object fails secondary validation.
    ///// </summary>
    ///// <param name="output">Stream to Write UTF8 Formatted XML Data To</param>
    ///// <exception cref="ArgumentNullException">A required element is missing or set to the default value.</exception>
    ///// <exception cref="ArgumentException">The object will create invalid XML or has failed secondary schema validation.  
    ///// It may not conform to the DE Standard or may contain an invalid property/value.</exception>
    ///// <seealso cref="Validate"/>
    ///// <seealso cref="CheckDistributionReference"/>
    ///// <seealso cref="ValidateToSchema"/>
    ///// <seealso cref="ValueScheme.WriteXML(XmlWriter)"/>
    ///// <seealso cref="TargetAreaType.WriteXML(XmlWriter)"/>
    ///// <seealso cref="ContentObject.WriteXML(XmlWriter)"/>
    ///// <seealso cref="List<ValueList>.WriteXML(XmlWriter)"/>
    //public void WriteXML(Stream output)
    //{
    //  this.Validate();
    //  XmlWriterSettings xsettings = new XmlWriterSettings();
    //  xsettings.Encoding = Encoding.UTF8;
    //  xsettings.Indent = true;
    //  xsettings.IndentChars = "\t";
      
    //  MemoryStream ms = new MemoryStream();
    //  StringBuilder outputStringBuilder = new StringBuilder();
    //  using (XmlWriter xwriter = XmlWriter.Create(outputStringBuilder, xsettings))
    //  {

    //    //PropertyInfo innerWriterPropInfo = xwriter.GetType().GetProperty("InnerWriter", BindingFlags.NonPublic | BindingFlags.Instance);
    //    //XmlWriter innerWriter = (XmlWriter)innerWriterPropInfo.GetValue(xwriter, null);
    //    //FieldInfo encodingFieldInfo = innerWriter.GetType().GetField("encoding", BindingFlags.NonPublic | BindingFlags.Instance);
    //    //encodingFieldInfo.SetValue(innerWriter, Encoding.UTF8);
    //    xwriter.WriteStartDocument(false);
    //    xwriter.WriteStartElement("EDXLDistribution", EDXLConstants.EDXLDE10Namespace);
    //    xwriter.WriteElementString("distributionID", this.distributionID);
    //    xwriter.WriteElementString("senderID", this.senderID);
    //    xwriter.WriteElementString("dateTimeSent", this.datetimeSent.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
    //    xwriter.WriteElementString("distributionStatus", this.distributionStatus.ToString());
    //    xwriter.WriteElementString("distributionType", this.distributionType.ToString());
    //    xwriter.WriteElementString("combinedConfidentiality", this.combinedConfidentiality);
    //    if (!string.IsNullOrEmpty(this.language))
    //    {
    //      xwriter.WriteElementString("language", this.language);
    //    }

    //    this.senderRole.WriteXML(xwriter);
    //    this.recipientRole.WriteXML(xwriter);
    //    this.keyword.WriteXML(xwriter);

    //    if (this.distributionReference.Count != 0)
    //    {
    //      foreach (string distribution in this.distributionReference)
    //      {
    //        if (string.IsNullOrEmpty(distribution))
    //        {
    //          continue;
    //        }

    //        this.CheckDistributionReference(distribution);
    //        xwriter.WriteElementString("distributionReference", distribution);
    //      }
    //    }

    //    if (this.explicitAddress.Count != 0)
    //    {
    //      foreach (ValueScheme scheme in this.explicitAddress)
    //      {
    //        xwriter.WriteStartElement("explicitAddress");
    //        scheme.WriteXML(xwriter);
    //        xwriter.WriteEndElement();
    //      }
    //    }

    //    if (this.targetArea.Count != 0)
    //    {
    //      foreach (TargetAreaType target in this.targetArea)
    //      {
    //        xwriter.WriteStartElement("targetArea");
    //        target.WriteXML(xwriter);
    //        xwriter.WriteEndElement();
    //      }
    //    }

    //    foreach (ContentObject obj in this.contentObjects)
    //    {
    //      obj.WriteXML(xwriter);
    //    }

    //    xwriter.WriteEndElement();
    //    xwriter.Flush();
    //  }

    //  byte[] a = System.Text.Encoding.UTF8.GetBytes(this.StripUnprintableCharacters(outputStringBuilder.ToString()));
    //  ms.Write(a, 0, a.Length);
    //  output.Write(a, 0, a.Length);

    //  if (EDXLConstants.SecondarySchemaValidation)
    //  {
    //    long pos = ms.Position;
    //    ms.Position = 0;

    //    StreamReader reader = new StreamReader(ms);

    //    string strout = reader.ReadToEnd();

    //    this.ValidateToSchema(strout);
    //    ms.Position = pos;
    //  }

    //  // ms.WriteTo(output);
    //  ms.Flush();
    //  //TODO: ms.Close();
    //}
    /*
    /// <summary>
    /// Reads This Object From an XML String
    /// </summary>
    /// <param name="xmlData">String of XML Data</param>
    /// <exception cref="ArgumentNullException">XML Data is null or missing a required element </exception>
    /// <exception cref="ArgumentException">xmlData is not valid XML or is not valid for this object.  
    /// It may have an unexpected node, be invalid to the schema, or have elements with invalid values</exception>
    /// <exception cref="FormatException">There is not exactly one EDXLDistribution Element</exception>
    /// <seealso cref="ValueScheme.ReadXML"/>
    /// <seealso cref="List<ValueList>.ReadXML"/>
    /// <seealso cref="TargetAreaType.ReadXML"/>
    /// <seealso cref="ContentObject.ReadXML"/>*/
    //public void ReadXML(string xmlData)
    //{
    //  if (string.IsNullOrEmpty(xmlData))
    //  {
    //    throw new ArgumentNullException("XMLData Can't Be Null!");
    //  }

    //  XmlDocument doc = new XmlDocument();
    //  try
    //  {
    //    doc.LoadXml(xmlData);
    //  }
    //  catch (XmlException)
    //  {
    //    throw new ArgumentException("Invalid XML String");
    //  }

    //  XmlNodeList denodelist = doc.GetElementsByTagName("EDXLDistribution", EDXLConstants.EDXLDE10Namespace);
    //  if (denodelist.Count == 0)
    //  {
    //    throw new FormatException("No EDXLDistribution Element found!");
    //  }
    //  else if (denodelist.Count > 1)
    //  {
    //    throw new FormatException("Multiple EDXLDistribution Elements found!");
    //  }

    //  XmlNode deroot = denodelist[0];
    //  ValueScheme schemetmp;
    //  TargetAreaType targettmp;
    //  ContentObject contenttmp;

    //  try
    //  {
    //    this.senderRole.ReadXML(deroot);
    //  } catch(Exception e)
    //  {
    //    throw new ArgumentException("senderRole element is invalid. " + e);                
    //  }

    //  try
    //  {
    //    this.recipientRole.ReadXML(deroot);
    //  } catch(Exception e)
    //  {
    //    throw new ArgumentException("recipientRole element is invalid. " + e);                
    //  }

    //  try
    //  {
    //    this.keyword.ReadXML(deroot);
    //  } catch(Exception e)
    //  {
    //    throw new ArgumentException("keyword element is invalid. " + e);                
    //  }

    //  foreach (XmlNode node in deroot.ChildNodes)
    //  {
    //    if (string.IsNullOrEmpty(node.InnerText))
    //    {
    //      continue;
    //    }

    //    switch (node.LocalName)
    //    {
    //      case "distributionID":
    //        this.distributionID = node.InnerText;
    //        break;
    //      case "senderID":
    //            try
    //            {
    //                this.CheckSenderID(node.InnerText);
    //                this.senderID = node.InnerText;
    //            } catch(Exception e)
    //            {
    //                throw new ArgumentException("senderID element is invalid." + e);
    //            }
    //        break;
    //      case "dateTimeSent":
    //            try
    //            {
    //                this.DateTimeSent = DateTime.Parse(node.InnerText);

    //            } catch(Exception e)
    //            {
    //                throw new ArgumentException("dateTimeSent element is invalid." + e);
    //            }
    //        break;
    //      case "distributionStatus":
    //        this.distributionStatus = (StatusValue)Enum.Parse(typeof(StatusValue), node.InnerText);
    //        break;
    //      case "distributionType":
    //        this.distributionType = (TypeValue)Enum.Parse(typeof(TypeValue), node.InnerText);
    //        break;
    //      case "combinedConfidentiality":
    //        this.combinedConfidentiality = node.InnerText;
    //        break;
    //      case "language":
    //            try
    //            {
    //                this.CheckRFC3066(node.InnerText);
    //                this.language = node.InnerText;
    //            } catch(Exception e)
    //            {
    //                throw new ArgumentException("language element is invalid. " + e);
    //            }
    //        break;
    //      case "senderRole":
    //        break;
    //      case "recipientRole":
    //        break;
    //      case "keyword":
    //        break;
    //      case "distributionReference":
    //        try
    //        {
    //            this.CheckDistributionReference(node.InnerText);
    //            this.distributionReference.Add(node.InnerText);
    //        } catch(Exception e)
    //        {
    //            throw new ArgumentException("distributionReference element is invalid. " + e);                
    //        }
    //        break;
    //      case "explicitAddress":
    //        try { 
    //            schemetmp = new ValueScheme();
    //            schemetmp.ReadXML(node);
    //            this.explicitAddress.Add(schemetmp);
    //            break;
    //        } catch(Exception e)
    //        {
    //            throw new ArgumentException("contentObject element is invalid. " + e);                
    //        }
    //      case "targetArea":
    //        try { 
    //            targettmp = new TargetAreaType();
    //            targettmp.ReadXML(node);
    //            this.targetArea.Add(targettmp);
    //            break;
    //        } catch(Exception e)
    //        {
    //            throw new ArgumentException("contentObject element is invalid. " + e);                
    //        }
    //      case "contentObject":
    //        try
    //        {
    //            contenttmp = new ContentObject();
    //            contenttmp.ReadXML(node);
    //            this.contentObjects.Add(contenttmp);
    //        } catch(Exception e)
    //        {
    //            throw new ArgumentException("contentObject element is invalid. " + e);                
    //        }
    //        break;
    //      case "#comment":
    //        break;
    //      default:
    //        throw new ArgumentException("Unexpected Node Name: " + node.Name + " in EDXLDE");
    //    }
    //  }

    //  this.Validate();
    //  if (EDXLConstants.SecondarySchemaValidation)
    //  {
    //    this.ValidateToSchema(xmlData);
    //  }
    //}

    ///// <summary>
    ///// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    ///// </summary>
    ///// <param name="items">Pointer to a Valid Syndication Item to Populate</param>
    ///// <exception cref=" ArgumentNullException">items cannot be null</exception>
    //public void ToGeoRSS(List<SyndicationItem> items)
    //{
    //  if (items == null)
    //  {
    //    throw new ArgumentNullException("items Can't Be Null");
    //  }

    //  SyndicationItem myitem;
    //  if (this.targetArea.Count == 0)
    //  {
    //    myitem = new SyndicationItem();
    //    //TODO: add to local syndication
    //    //myitem.Categories.Add(new SyndicationCategory(EDXLConstants.DESyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
    //    //myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
    //    //myitem.LastUpdatedTime = this.datetimeSent;
    //    //myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "DE/")));
    //    //myitem.PublishDate = DateTime.Now;
    //    //myitem.Summary = new TextSyndicationContent("MessageID: " + this.distributionID);
    //    //myitem.Title = new TextSyndicationContent(EDXLConstants.DESyndicationTitle);
    //    items.Add(myitem);
    //  }
    //  else
    //  {
    //    foreach (TargetAreaType mytargetarea in this.targetArea)
    //    {
    //      myitem = new SyndicationItem();
    //      //TODO: myitem.Categories.Add(new SyndicationCategory(EDXLConstants.DESyndicationCategoryName, EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));

    //      // Have to do this funky workaround due to the wacky structure of area here...
    //      StringBuilder output = new StringBuilder();
    //      XmlWriterSettings xsettings = new XmlWriterSettings();
    //      xsettings.Indent = true;
    //      xsettings.IndentChars = "\t";
    //      xsettings.OmitXmlDeclaration = true;
    //      XmlWriter xwriter = XmlWriter.Create(output, xsettings);
    //      xwriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
    //      mytargetarea.ToGeoRSS(xwriter);
    //      xwriter.WriteEndElement();
    //      xwriter.Flush();
    //      //TODO: xwriter.Close();
    //      MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
    //      //TODO: fix local syndication item
    //      //myitem.ElementExtensions.Add(XmlReader.Create(ms));
    //      //myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
    //      //myitem.LastUpdatedTime = this.datetimeSent;
    //      //myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "DE/")));
    //      //myitem.PublishDate = DateTime.Now;
    //      //myitem.Summary = new TextSyndicationContent("MessageID: " + this.distributionID);
    //      //myitem.Title = new TextSyndicationContent(EDXLConstants.DESyndicationTitle);
    //      items.Add(myitem);
    //    }
    //  }
    //}

    /// <summary>
    /// Gets All Validation Errors in this DE Message
    /// </summary>
    /// <returns>If there are no errors null. Otherwise, List of errors as strings</returns>
    public List<string> GetDEErrors()
    {
      List<string> errors = new List<string>();
      if (this.distributionStatus == null)
      {
        errors.Add("Status Value Must be set in EDXLDE");
      }

      if (this.distributionType == null)
      {
        errors.Add("Type Value Must be set in EDXLDE");
      }

      if (this.distributionID == null)
      {
        errors.Add("Distribution ID is required and can't be null");
      }

      if (this.senderID == null)
      {
        errors.Add("Sender ID is required and can't be null");
      }

      if (this.datetimeSent == null || this.datetimeSent == DateTime.MinValue)
      {
        errors.Add("Date Time Sent is required and can't be null");
      }

      if (errors.Count > 0)
      {
        return errors;
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Remove some "unprintable" characters from the message
    /// </summary>
    /// <param name="str">String of XML Data</param>
    /// <returns>Sanitized String of Printable Characters</returns>
    protected string StripUnprintableCharacters(string str)
    {
      str = str.Replace("�", " "); // U+FFFD
      str = str.Replace("￼", " "); // U+FFFC
      return str;
    }

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// The following are null or empty: 
    /// <list type="bullet">
    ///     <item>
    ///         <description>distributionStatus</description>
    ///     </item>
    ///     <item>
    ///         <description>distributionType</description>
    ///     </item>
    ///     <item>
    ///         <description>distributionID</description>
    ///     </item>
    ///     <item>
    ///         <description>senderID</description>
    ///     </item>
    ///     <item>
    ///         <description>datetimeSent</description>
    ///     </item>
    /// </list> or datetimeSent is DateTime.MinValue.  
    /// </exception>
    /// <seealso cref="CheckConformance"/>
    protected void Validate()
    {
      if (this.distributionStatus == null)
      {
        throw new ArgumentNullException("Status Value Must be set in EDXLDE");
      }

      if (this.distributionType == null)
      {
        throw new ArgumentNullException("Type Value Must be set in EDXLDE");
      }

      if (string.IsNullOrEmpty(this.distributionID))
      {
        throw new ArgumentNullException("Distribution ID is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.senderID))
      {
        throw new ArgumentNullException("Sender ID is required and can't be null");
      }

      if (this.datetimeSent == null || this.datetimeSent == DateTime.MinValue)
      {
        throw new ArgumentNullException("Date Time Sent is required and can't be null");
      }

      List<string> conformanceErrors;
      if ((conformanceErrors = this.CheckConformance()) != null)
      {
        throw new ArgumentException(conformanceErrors[0]);
      }
    }

    /// <summary>
    /// Checks This DE Object For Conformance to the DE Standard
    /// </summary>
    /// <returns>A List of Strings Containing Error Messages</returns>    
    private List<string> CheckConformance()
    {
      List<string> conformanceErrors = new List<string>();
      if (conformanceErrors.Count > 0)
      {
        return conformanceErrors;
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Checks SenderID to the Conformance of string@string.string
    /// </summary>
    /// <param name="s">Sender ID String</param>
    /// <exception cref="ArgumentNullException">Sender ID string is null</exception>
    /// <exception cref="FormatException">Sender ID is not in the form: actor@domain</exception>
    /// <seealso cref="SenderID"/>
    private void CheckSenderID(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        throw new ArgumentNullException("Input string can't be null");
      }

      try
      {
        //TODO: MailAddress temp = new MailAddress(s);
      }
      catch (Exception e)
      {
        throw new FormatException("SenderID must be in the form actor@domain\n" + e.ToString());
      }
    }

    /// <summary>
    /// Checks Input String For Compliance to RFC3066
    /// </summary>
    /// <param name="s">String in the form xx-xx</param>
    /// <remarks>Regex is stored in <see cref="languageRegex"/></remarks>
    /// <exception cref="ArgumentException">Language string is null or not in RFC3066 form: xx-xx</exception>
    /// <seealso cref="Language"/>
    /// <seealso cref="languageRegex"/>
    private void CheckRFC3066(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        throw new ArgumentException("Language string can't be null");
      }

      if (!languageRegex.IsMatch(s))
      {
        throw new ArgumentException("Language String Too Long.  Must be in the form RFC3066: xx-xx\n" + s);
      }
    }

    /// <summary>
    /// Checks if input string is a valid DistributionReference
    /// </summary>
    /// <remarks>
    /// The distribution reference string is not valid if it is not in the form: distribution id,sender id, date time sent. 
    /// Also, the senderID must be in the form: actor@domain and datetimesent must include timezone information. 
    /// </remarks>
    /// <param name="s">DistributionReference as string</param>
    /// <exception cref="ArgumentException">Distribution Reference String is not in form distID, senderID, dateTimeSent or is 
    /// missing the timezone value</exception>
    /// <seealso cref="DistributionReference"/>
    /// <seealso cref="CheckSenderID"/>
    private void CheckDistributionReference(string s)
    {
      char[] seperator = new char[1] { ',' };
      List<string> split = s.Split(seperator).ToList();
      if (split.Count != 3)
      {
        throw new ArgumentException("Distribution Reference String Incorrect.  Must be in the form <distID>,<senderID>,<dateTimeSent>\n" + s);
      }

      this.CheckSenderID(split[1]);
      if (DateTime.Parse(split[2]).Kind == DateTimeKind.Unspecified)
      {
        throw new ArgumentException("Distribution Reference String Incorrect.  Timezone value must be specified");
      }
    }

    
    /// <summary>
    /// Validates The Current DE Object Against The XSD Schema File
    /// </summary>
    /// <param name="xmldata">XML String To Parse and Validate</param>
    /// <exception cref="ArgumentException">xmldata is not valid to the schema</exception>
    /// <seealso cref="schemaErrorString"/>
   // /// <seealso cref="schemaErrors"/>
    private void ValidateToSchema(string xmldata)
    {
  
      //XmlReader vr;
      //XmlReaderSettings xs = new XmlReaderSettings();
      ////TODO: XmlSchemaSet coll = new XmlSchemaSet();
      //StringReader xsdsr = new StringReader(EMS.EDXL.DE.Properties.Resources.EDXL_DE_Schema_v1_0);
      //StringReader xmlsr = new StringReader(xmldata);
      //XmlReader xsdread = XmlReader.Create(xsdsr);
      ////TODO: fix
      ////coll.Add(EDXLConstants.EDXLDE10Namespace, xsdread);
      ////xs.Schemas.Add(coll);
      ////xs.ValidationType = ValidationType.Schema;
      ////xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      ////xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      ////xs.ValidationEventHandler += new ValidationEventHandler((object sender, ValidationEventArgs args) =>
      ////{
      ////    if (args.Severity == XmlSeverityType.Error)
      ////    {
      ////        schemaErrorString = schemaErrorString + args.Message + "\r\n";
      ////        schemaErrors++;
      ////    }
      ////});

      //vr = XmlReader.Create(xmlsr, xs);
      //while (vr.Read())
      //{
      //}

      //TODO: fix
      //vr.Close();
      //xmlsr.Close();
      //xsdread.Close();
      //xsdsr.Close();
      //if (this.schemaErrors > 0)
      //{
      //  throw new ArgumentException("Schema Validation Error: " + this.schemaErrorString);
      //}
    }

    //TODO:fix
    ///// <summary>
    ///// Handler Function For Distribution Reference List Changed Event
    ///// </summary>
    ///// <seealso cref="DistributionReference"/>
    ///// <param name="sender">Object That Is Firing The Event</param>
    ///// <param name="e">Event Arguments for the List Changed Event</param>
    //private void DistributionRefHandler(object sender, ListChangedEventArgs e)
    //{
    //  if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged)
    //  {
    //    this.CheckDistributionReference(this.distributionReference[e.NewIndex]);
    //  }
    //} 

        /// <summary>
        /// Converts this DE to a String
        /// </summary>
        /// <returns>The DE as a string</returns>
        public override string ToString()
        {
            XmlSerializer xs = new XmlSerializer(typeof(DEv1_0));  

            XmlWriterSettings xsettings = new XmlWriterSettings();
            xsettings.Indent = true;
            xsettings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, xsettings))
            {
                xs.Serialize(writer, this);
                return stream.ToString();
            }

        }
  }
}
