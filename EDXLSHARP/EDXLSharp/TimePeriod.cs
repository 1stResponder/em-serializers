// ———————————————————————–
// <copyright file="TimePeriod.cs" company="EDXLSharp">
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
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp
{
  /// <summary>
  /// Data Structure to Represent a Unique name and an associated list of values
  /// </summary>
  [Serializable]
  public partial class TimePeriod : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// The Beginning DateTime in the Period
    /// </summary>
    private DateTime fromDateTime;

    /// <summary>
    /// The Ending DateTime in the Period
    /// </summary>
    private DateTime tointDateTime;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the TimePeriod class
    /// Default Constructor - Does Nothing
    /// </summary>
    public TimePeriod()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The Ending DateTime in the Period
    /// </summary>
    [XmlElement(ElementName = "ToDateTime", Order = 0)]
    public DateTime ToDateTime
    {
      get { return this.tointDateTime; }
      set { this.tointDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Beginning DateTime in the Period
    /// </summary>
    [XmlElement(ElementName = "FromDateTime", Order = 1)]
    public DateTime FromDateTime
    {
      get { return this.fromDateTime; }
      set { this.fromDateTime = value; }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This IComposable Message To an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Writer for Current XML Document - Since the Root Element of ValueList is Determined by Implementation this only writes VLURN and Values</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      xwriter.WriteElementString("ToDateTime", this.tointDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
      xwriter.WriteElementString("FromDateTime", this.fromDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
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
      this.Validate();
      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      xwriter.WriteElementString("ToDateTime", xmlns, this.tointDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
      xwriter.WriteElementString("FromDateTime", xmlns, this.fromDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz"));
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

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ToDateTime":
            this.tointDateTime = DateTime.Parse(node.InnerText);
            break;
          case "FromDateTime":
            this.fromDateTime = DateTime.Parse(node.InnerText);
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
      if (this.tointDateTime == DateTime.MinValue)
      {
        throw new Exception("ToDateTime is mandatory");
      }

      if (this.fromDateTime == DateTime.MinValue)
      {
        throw new Exception("FromDateTime is mandatory");
      }
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}
