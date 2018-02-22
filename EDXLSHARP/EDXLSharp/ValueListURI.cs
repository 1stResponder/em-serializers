// ———————————————————————–
// <copyright file="ValueListURI.cs" company="EDXLSharp">
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
using System.Xml.Serialization;

namespace EDXLSharp
{
  /// <summary>
  /// Data Structure to Represent a Unique name and an associated list of values
  /// </summary>
  [Serializable]
  public abstract class ValueListURI : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    private Uri valueListURI;

    /// <summary>
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    private List<string> value;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ValueListURI class
    /// Default Constructor - Initializes List
    /// </summary>
    public ValueListURI()
    {
      this.value = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the ValueListURI class
    /// Constructor To Initialize Values - Performs Deep Copy on List of Strings
    /// </summary>
    /// <param name="valuelisturiin">Unique name of this list</param>
    /// <param name="valuesin">List of string values</param>
    public ValueListURI(Uri valuelisturiin, List<string> valuesin)
    {
      if (valuesin == (List<string>)null)
      {
        throw new ArgumentNullException("_Values");
      }

      if (valuelisturiin == null)
      {
        throw new ArgumentNullException("_ValueListURN");
      }

      this.value = new List<string>();
      this.ListURI = valuelisturiin;
      foreach (string s in valuesin)
      {
        this.value.Add(s);
      }
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    [XmlIgnore]
    public Uri ListURI
    {
      get { return this.valueListURI; }
      set { this.valueListURI = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Serializable string version of the ListURI element
    /// </summary>
    [XmlElement(ElementName = "ValueListURI", Order = 0)]
    public string ValueListURIxml
    {
      get { return this.valueListURI.ToString(); }
      set { this.valueListURI = new Uri(value); }
    }

    /// <summary>
    /// Gets or sets
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    [XmlIgnore]
    public List<string> Value
    {
      get { return this.value; }
      set { this.value = value; }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Value
    /// </summary>
    [XmlElement(ElementName = "Value", Order = 1)]
    public string[] ValueXML
    {
      get
      {
        if (this.value.Count == 0)
        {
          return null;
        }
        else
        {
          return this.value.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.value = value.ToList();
        }
      }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This IComposable Message To an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Writer for Current XML Document - Since the Root Element of ValueList is Determined by Implementation this only writes VLURN and Values</param>
    public void WriteXML(XmlWriter xwriter)
    {
      try
      {
        this.Validate();
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to validate the ValueList - " + ex.Message);
      }

      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      if (this.valueListURI == null)
      {
        throw new ArgumentNullException("ValueListURN Can't Be Null");
      }

      xwriter.WriteElementString("valueListUrn", this.valueListURI.ToString());
      foreach (string val in this.value)
      {
        if (string.IsNullOrEmpty(val))
        {
          continue;
        }

        xwriter.WriteElementString("value", val);
      }

      xwriter.Flush();
    }

    /// <summary>
    /// Writes This IComposable Message To an Existing XML Document
    /// </summary>
    /// <param name="prefix">Defines the prefix to use when writing this object</param>
    /// <param name="xmlns">Defines the namespace to use when writing this object</param>
    /// <param name="xwriter">Writer for Current XML Document - Since the Root Element of ValueList is Determined by Implementation this only writes VLURN and Values</param>
    public void WriteXML(string prefix, string xmlns, XmlWriter xwriter)
    {
      try
      {
        this.Validate();
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to validate the ValueList - " + ex.Message);
      }

      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      if (this.valueListURI == null)
      {
        throw new ArgumentNullException("ValueListURN Can't Be Null");
      }

      xwriter.WriteElementString(prefix, "ValueListURN", xmlns, this.valueListURI.ToString());
      foreach (string val in this.value)
      {
        if (string.IsNullOrEmpty(val))
        {
          continue;
        }

        xwriter.WriteElementString(prefix, "Value", xmlns, val);
      }

      xwriter.Flush();
    }

    /// <summary>
    /// Reads This IComposable Message From an Existing XML Document
    /// </summary>
    /// <param name="rootnode">XMLNode That Points to the VLURN or Values...Not the Root Element since that is standard specific</param>
    public void ReadXML(XmlNode rootnode)
    {
      if (rootnode == (XmlNode)null)
      {
        throw new ArgumentNullException("RootNode");
      }

      this.value = new List<string>();
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "valueListUrn":
          case "ValueListURN":
            this.valueListURI = new Uri(node.InnerText);
            break;
          case "value":
          case "Value":
            this.value.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new FormatException("Invalid value: " + node.Name + "found in ValueList Type");
        }
      }

      try
      {
        this.Validate();
      }
      catch (Exception ex)
      {
        throw new Exception("Unable to validate the ValueList - " + ex.Message);
      }
    }
    
    /// <summary>
    /// Determines whether or not the data in this object is valid
    /// </summary>
    public void Validate()
    {
      if (this.valueListURI == null)
      {
        throw new Exception("ValueList URN is null or empty.");
      }

      if (this.value == null)
      {
        throw new Exception("ValueList Value is null.");
      }

      if (this.value.Count < 1)
      {
        throw new Exception("ValueList Value is empty.");
      }
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}
