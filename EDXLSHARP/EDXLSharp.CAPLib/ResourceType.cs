// ———————————————————————-
// <copyright file="ResourceType.cs" company="EDXLSharp">
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
using System.ComponentModel;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.CAPLib
{
  /// <summary>
  /// The resource segment provides an optional reference to additional information related to the info
  /// segment within which it appears in the form of a digital asset such as an image or audio file.
  /// </summary>
  [Serializable]
  public partial class ResourceType
  {
    #region Private Member Variables

    /// <summary>
    /// The text describing the type and content of the resource file (REQUIRED)
    /// </summary>
    private string resourceDesc;

    /// <summary>
    /// The identifier of the MIME content type and sub-type describing the resource file (REQUIRED)
    /// </summary>
    private string mimeType;

    /// <summary>
    /// The integer indicating the size of the resource file (OPTIONAL)
    /// </summary>
    private int? size;

    /// <summary>
    /// The identifier of the hyperlink for the resource file (OPTIONAL)
    /// </summary>
    private Uri uri;

    /// <summary>
    /// The base-64 encoded data content of the resource file (CONDITIONAL) 
    /// </summary>
    private byte[] derefUri;

    /// <summary>
    /// The code representing the digital digest (“hash”) computed from the resource file (OPTIONAL)
    /// </summary>
    private string digest;

    /// <summary>
    /// The namespace of the CAP element
    /// </summary>
    private string capNamespace;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ResourceType class 
    /// Default Constructor - Does Nothing
    /// </summary>
    public ResourceType()
    {
    }
    #endregion

    #region Public Accessors
    
    /// <summary>
    /// Gets or sets
    /// The text describing the type and content of the resource file
    /// </summary>
    public string ResourceDesc
    {
      get { return this.resourceDesc; }
      set { this.resourceDesc = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// The identifier of the MIME content type and sub-type describing the resource file
    /// </summary>
    public string MimeType
    {
      get { return this.mimeType; }
      set { this.mimeType = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// The integer indicating the size of the resource file
    /// </summary>
    public int? Size
    {
      get { return this.size; }
      set { this.size = value; }
    }
    
    /// <summary>
    /// Gets or sets
    /// The identifier of the hyperlink for the resource file
    /// </summary>
    [XmlIgnore]
    public Uri Uri_var
    {
        get { return this.uri; }
        set { this.uri = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable String Version of the URI
    /// </summary>
    [XmlAttribute("uri")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string UriString
    {
        get { return this.uri == null ? null : this.uri.ToString(); }
        set { this.uri = value == null ? null : new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// The base-64 encoded data content of the resource file
    /// </summary>
    public string DerefUri
    {
      get 
      {
        if (this.derefUri == null)
        {
          return null;
        }
        else
        {
          return Convert.ToBase64String(this.derefUri);
        }
      }

      set
      {
        try
        {
          this.derefUri = Convert.FromBase64String(value);
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
    /// Gets or sets
    /// The code representing the digital digest (“hash”) computed from the resource file
    /// </summary>
    public string Digest
    {
      get
      {
        return this.digest;
      }

      set
      {
        // this.CheckDigest(value);
        this.digest = value;
      }
    }

    /// <summary>
    /// Gets or sets
    /// The CAP namespace for serialization
    /// </summary>
    [XmlIgnore]
    public string CapNamespace
    {
      get { return this.capNamespace; }
      set { this.capNamespace = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Automatically Calculates the SHA-1 Hash of the Content Data and Stores it in the Digest as a Base64 String
    /// </summary>
    public void CalculateDigest()
    {
      if (this.derefUri == null)
      {
        throw new ArgumentNullException("BinaryContentData Can't Be Null to Compute The Hash");
      }

      SHA1 sha = new SHA1CryptoServiceProvider();
      byte[] result = sha.ComputeHash(this.derefUri);
      this.digest = Convert.ToBase64String(result);
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      if (string.IsNullOrEmpty(this.capNamespace))
      {
        this.capNamespace = EDXLConstants.CAP12Namespace;
      }

      xwriter.WriteElementString("resourceDesc", this.capNamespace, this.resourceDesc);
      xwriter.WriteElementString("mimeType", this.capNamespace, this.mimeType);
      if (this.size != null)
      {
        xwriter.WriteElementString("size", this.capNamespace, this.size.ToString());
      }

      if (this.uri != null)
      {
        xwriter.WriteElementString("uri", this.capNamespace, this.uri.ToString());
      }

      if (this.derefUri != null)
      {
        xwriter.WriteElementString("derefUri", this.capNamespace, Convert.ToBase64String(this.derefUri));
      }

      if (!string.IsNullOrEmpty(this.digest))
      {
        xwriter.WriteElementString("digest", this.capNamespace, this.digest);
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the Root Object Element</param>
    internal void ReadXML(XmlNode rootNode)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "resourceDesc":
            this.resourceDesc = node.InnerText;
            break;
          case "mimeType":
            this.mimeType = node.InnerText;
            break;
          case "size":
            this.size = int.Parse(node.InnerText);
            break;
          case "uri":
            this.uri = new Uri(node.InnerText);
            break;
          case "derefUri":
            this.derefUri = Convert.FromBase64String(node.InnerText);
            break;
          case "digest":
            this.digest = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid value: " + node.InnerText + " found in Resource Type");
        }
      }

      if (this.digest != null)
      {
        // this.CheckDigest(this.digest);
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
      if (string.IsNullOrEmpty(this.resourceDesc))
      {
        throw new ArgumentNullException("Resource Description is required and can't be null");
      }

      if (string.IsNullOrEmpty(this.mimeType))
      {
        throw new ArgumentNullException("MIME Type is required and can't be null");
      }
    }

    /// <summary>
    /// Calculates and Verifies the SHA-1 Hash of the Binary Data
    /// </summary>
    /// <param name="s">Input Hash String to Validate</param>
    private void CheckDigest(string s)
    {
      if (this.derefUri == null)
      {
        throw new ArgumentNullException("BinaryContentData Can't Be Null to Compute The Hash");
      }

      SHA1 sha = new SHA1CryptoServiceProvider();
      byte[] result = sha.ComputeHash(this.derefUri);
      string temp = Convert.ToBase64String(result);
      if (temp != s)
      {
        throw new ArgumentException("Digest Value is incorrect");
      }
    }

    #endregion
  }
}
