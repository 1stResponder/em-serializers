// ———————————————————————–
// <copyright file="NonXMLContentType.cs" company="EDXLSharp">
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
using System;
using System.Collections.Generic;
using EMS.EDXL.Utilities;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// Container for content provided in a non-XML MIME type. 
  /// </summary>
  [Serializable]
  [JsonObject(MemberSerialization.OptIn)]
  public partial class NonXMLContentType : IGeoRSS
  {
    #region Private Member Variables
    /// <summary>
    /// The format of the payload. 
    /// Required Element
    /// </summary>
    /// <seealso cref="MIMEType"/>
    private string mimeType;

    /// <summary>
    /// The file size of the payload . 
    /// </summary>
    /// <seealso cref="Size"/>
    private int? size;

    /// <summary>
    /// The digest value for the payload. 
    /// </summary>
    /// <seealso cref="Digest"/>
    /// <seealso cref="CheckDigest"/>
    /// <seealso cref="CalculateDigest"/>
    private string digest;

    /// <summary>
    /// A Uniform Resource Identifier that can be used to retrieve the identified resource. 
    /// </summary>
    /// <seealso cref="Uri"/>
    /// <seealso cref="XmlUri"/>
    private Uri uri;

    /// <summary>
    /// The base-64 encoded data content. 
    /// </summary>
    /// <seealso cref="ContentData"/>
    private byte[] binaryContentData;

    /// <summary>
    /// Non-Base 64 string data (e.g. JSON)
    /// </summary>
    /// <seealso cref="ContentData"/>
    private string stringContentData;

    /// <summary>
    /// The geographic information for this non XML content
    /// </summary>
    /// <seealso cref="GeoLocationInfo"/>
    //TODO: fix public SyndicationElementExtension GeoLocationInfo
    private string geoInfo;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the NonXMLContentType class
    /// Default Constructor - Does Nothing
    /// </summary>
    public NonXMLContentType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets the MIME content type and sub-type as described in [RFC 2046].
    /// Required Element
    /// </summary>
    /// <value>The format of the payload</value>
    /// <seealso cref="mimeType"/>
    [XmlElement(ElementName = "mimeType", Order = 0)]
    [JsonProperty("mimeType", NullValueHandling = NullValueHandling.Ignore)]
    public string MIMEType
    {
      get { return this.mimeType; }
      set { this.mimeType = value; }
    }

    /// <summary>
    /// Gets or sets the Size.
    /// </summary>
    /// <value>The file size of the payload </value>
    /// <remarks>Value must be in bytes and represent the raw file size (not encoded or encrypted).</remarks>
    /// <seealso cref="size"/>
    [XmlElement(ElementName = "size", Order = 1)]
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public int Size
    {
      get { return this.size.Value; }
      set { this.size = value; }
    }

    /// <summary>
    /// Indicates whether or not the Size was specified
    /// </summary>
    [XmlIgnore]
    public bool SizeSpecified
    {
      get { return this.size.HasValue;  }
    }
    /// <summary>
    /// Gets or sets the Digest. 
    /// Used to ensure the integrity of the payload.
    /// </summary>
    /// <value> The digest value for the payload.  The digest should be the secure hash of the binaryContentData</value>
    /// <remarks> 
    /// The value must be base 64 and calculated using the Secure Hash Algorithm (SHA-1). 
    /// Requires BinaryContentData to be defined. </remarks>
    /// <exception cref="ArgumentNullException">BinaryContentData is null</exception>
    /// <exception cref="ArgumentException">value is incorrect</exception>
    /// <seealso cref="digest"/>
    /// <seealso cref="CheckDigest"/>
    /// <seealso cref="CalculateDigest"/>
    [XmlElement(ElementName = "digest", Order = 2)]
    [JsonProperty("digest", NullValueHandling = NullValueHandling.Ignore)]
    public string Digest
    {
      get
      {
        return this.digest;
      }

      set
      {
        this.CheckDigest(value);
        this.digest = value;
      }
    }

    /// <summary>
    /// Indicates whether or not the Digest was specified
    /// </summary>
    [XmlIgnore]
    public bool DigestSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.digest); }
    }

    /// <summary>
    /// Gets or sets the URI used to retrieve the resource.  
    /// </summary>
    /// <value> A relative or absolute Uniform Resource Identifier that can be used to retrieve the identified resource.</value>
    /// <remarks>
    /// For serialization/deserialization <see cref="XmlUri"/> or if serializing as attribute</remarks>
    /// <seealso cref="uri"/>
    /// <seealso cref="XmlUri"/>
    [XmlIgnore]
    public Uri URI
    {
      get { return this.uri; }
      set { this.uri = value; }
    }

    /// <summary>
    /// Gets or sets the XmlUri
    /// </summary>
    /// <value>XML Serialization Object for <see cref="URI"/></value>
    /// <exception cref="ArgumentNullException">value is null</exception>
    /// <exception cref="ArgumentException">value is invalid Uri</exception>
    [XmlElement(ElementName = "uri", Order = 3)]
    [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
    public string XmlUri
    {
      get { return this.uri == null ? null : this.uri.ToString(); }

      set
      {
        try
        {
          this.URI = new Uri(value);
        }
        catch (ArgumentNullException e)
        {
          throw e;
        }
        catch (FormatException)
        {
          throw new ArgumentException("Invalid Uri Format");
        }
      }
    }

    /// <summary>
    /// Indicates whether or not the Xml Uri was specified
    /// </summary>
    [XmlIgnore]
    public bool XmlUriSpecified
    {
      get { return this.uri != null && !string.IsNullOrWhiteSpace(this.uri.ToString()); }
    }

    /// <summary>
    /// Gets or sets the Content Data.  Depending on the input it will set the stringContentData or the binaryContentData
    /// </summary>
    /// <value> The base-64 encoded data content or a Non-Base 64 string data</value>
    /// <remarks>
    /// May be used either with or instead of the URI element in contexts where retrieval of a
    /// resource via a URI is not feasible.
    /// </remarks>
    /// <exception cref="FormatException">value is in an invalid format</exception>
    /// <exception cref="ArgumentNullException">value is null</exception>
    [XmlElement(ElementName = "contentData", Order = 4)]
    [JsonProperty("contentData", NullValueHandling = NullValueHandling.Ignore)]
    public string ContentData
    {
      get
      {
        if (this.binaryContentData != null)
        {
          return Convert.ToBase64String(this.binaryContentData);
        }
        else
        {
          return this.stringContentData;
        }
      }

      set
      {
        try
        {
          if (this.IsStringData)
          {
            this.stringContentData = value;
          }
          else
          {
            this.binaryContentData = Convert.FromBase64String(value);
          }
        }
        catch (ArgumentNullException e)
        {
          throw e;
        }
        catch (FormatException)
        {
          throw new ArgumentException("Invalid Input String");
        }
      }
    }

    /// <summary>
    /// Indicates whether or not the Content Data was specified
    /// </summary>
    [XmlIgnore]
    public bool ContentDataSpecified
    {
      get { return this.binaryContentData.Length > 0; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this is string data or binary data
    /// </summary>
    /// <value>Boolean indicating whether this is string data</value>
    [XmlIgnore]
    public bool IsStringData { get; set; }

    /// <summary>
    /// Gets or sets the GeoLocation Information.
    /// Extension for Syndication Items for GeoLocation Information
    /// </summary>
    /// <value>The geographic information for this non XML content</value>
    /// <remarks>Not currently serialized/deserialized</remarks>
    /// <seealso cref="geoInfo"/>
    //TODO: fix
    [XmlIgnore]
    public string GeoLocationInfo
    //public SyndicationElementExtension GeoLocationInfo
    {
      get
      {
        return this.geoInfo;
      }

      set
      {
        this.geoInfo = value;
      }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Automatically Calculates the SHA-1 Hash of the Content Data and Stores it in the Digest as a Base64 String
    /// Requires that binaryContentData be defined
    /// </summary>
    /// <exception cref="ArgumentNullException">BinaryContentData is null</exception>
    /// <seealso cref="Digest"/>
    /// <seealso cref="CheckDigest"/>
    public void CalculateDigest()
    {
      if (this.binaryContentData == null)
      {
        throw new ArgumentNullException("BinaryContentData Can't Be Null to Compute The Hash");
      }
      //TODO: fix
      //SHA1 sha = new SHA1CryptoServiceProvider();
      //byte[] result = sha.ComputeHash(this.binaryContentData);
      //this.digest = Convert.ToBase64String(result);
    }

    /// <summary>
    /// Converts This Object To One or More Syndication Items
    /// </summary>
    /// <param name="items">Syndication Items with Associated GeoRSS Content</param>
    /// <param name="linkUID">Provides Capability to Link The ContentKey or UID with the SyndicationLink</param>
    /// <exception cref="ArgumentNullException">Input SyndicationItem List  is null</exception>
    public void ToGeoRSS(List<SyndicationItem> items, Guid linkUID)
    {
      //TODO: fix
      //if (items == (List<SyndicationItem>)null)
      //{
      //  throw new ArgumentNullException("Input SyndicationItem List Can't Be Null");
      //}

      //SyndicationItem myitem = new SyndicationItem();
      //if (items.Count == 0)
      //{
      //  myitem.Authors.Add(new SyndicationPerson("admin@edxlsharp.codeplex.com", "Admin", string.Empty));
      //  myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      //  myitem.Content = new TextSyndicationContent(this.mimeType);
      //  myitem.LastUpdatedTime = DateTime.UtcNow;
      //}
      //else if (items[0] != (SyndicationItem)null)
      //{
      //  foreach (SyndicationPerson author in items[0].Authors)
      //  {
      //    myitem.Authors.Add(author);
      //  }

      //  foreach (SyndicationCategory cat in items[0].Categories)
      //  {
      //    myitem.Categories.Add(cat);
      //  }

      //  myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      //  myitem.Content = new TextSyndicationContent(this.mimeType);
      //  myitem.LastUpdatedTime = items[0].LastUpdatedTime;
      //}

      //////if the non XML content has a URI, use that for the syndication link
      //if (this.uri != null)
      //{
      //  myitem.Links.Add(new SyndicationLink(this.uri));
      //}
      //else
      //{
      //  myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "MIME/" + linkUID.ToString())));
      //}

      //if (this.geoInfo != null)
      //{
      //  myitem.ElementExtensions.Add(this.geoInfo);
      //}
      //else
      //{
      //  TargetAreaType tatype = new TargetAreaType();
      //  tatype.AddCircle("0,0 0");

      //  StringBuilder output = new StringBuilder();
      //  XmlWriterSettings xsettings = new XmlWriterSettings();
      //  xsettings.Indent = true;
      //  xsettings.IndentChars = "\t";
      //  xsettings.OmitXmlDeclaration = true;
      //  XmlWriter xwriter = XmlWriter.Create(output, xsettings);
      //  xwriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
      //  tatype.ToGeoRSS(xwriter);
      //  xwriter.WriteEndElement();
      //  xwriter.Flush();
      //  //TODO: xwriter.Close();
      //  MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
      //  myitem.ElementExtensions.Add(XmlReader.Create(ms));
      //}

      //myitem.PublishDate = DateTime.Now;
      //myitem.Summary = new TextSyndicationContent("NonXMLContent");
      //myitem.Title = new TextSyndicationContent(linkUID.ToString());
      //items.Add(myitem);
    }

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    /// <exception cref="ArgumentNullException">MIME type is null</exception>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.mimeType))
      {
        throw new ArgumentNullException("MIME type is required and can't be null");
      }
    }
    #endregion

    #region Private Member Functions

    /// <summary>
    /// Calculates and Verifies the SHA-1 Hash of the Binary Data
    /// </summary>
    /// <param name="s">Input Hash String to Validate</param>
    /// <exception cref="ArgumentNullException">BinaryContentData is null</exception>
    /// <exception cref="ArgumentException">s is not a base 64 string that holds the SHA1 hash of binaryContentData</exception>
    /// <seealso cref="Digest"/>
    private void CheckDigest(string s)
    {
      if (this.binaryContentData == null)
      {
        throw new ArgumentNullException("BinaryContentData Can't Be Null to Compute The Hash");
      }
      //TODO: fix
      //SHA1 sha = new SHA1CryptoServiceProvider();
      //byte[] result = sha.ComputeHash(this.binaryContentData);
      //string temp = Convert.ToBase64String(result);
      //if (temp != s)
      //{
      //  throw new ArgumentException("Digest Value is incorrect");
      //}
    }

    #endregion
  }
}
