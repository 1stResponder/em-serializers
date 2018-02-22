// ———————————————————————–
// <copyright file="Activity24HrType.cs" company="EDXLSharp">
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

using System;
using System.Xml;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the Activity24HourType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class Activity24HrType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// The number of admissions in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    private int? admissions;

    /// <summary>
    /// OPTIONAL 
    /// The number of discharges in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    private int? discharges;

    /// <summary>
    /// OPTIONAL 
    /// The number of deaths in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    private int? deaths;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the Activity24HrType class
    /// </summary>
    public Activity24HrType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of admissions in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    public int? Admissions
    {
      get { return this.admissions; }
      set { this.admissions = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of discharges in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    public int? Discharges
    {
      get { return this.discharges; }
      set { this.discharges = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of deaths in the last 24 hours. 
    /// 1. The time is relative to the timestamp of the LastUpdateTime of the Hospital element. 
    /// </summary>
    public int? Deaths
    {
      get { return this.deaths; }
      set { this.deaths = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement("Activity24Hr");
      if (this.admissions != null)
      {
        xwriter.WriteElementString("Admissions", this.admissions.ToString());
      }

      if (this.discharges != null)
      {
        xwriter.WriteElementString("Discharges", this.discharges.ToString());
      }

      if (this.deaths != null)
      {
        xwriter.WriteElementString("Deaths", this.deaths.ToString());
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Admissions":
            this.admissions = int.Parse(node.InnerText);
            break;
          case "Discharges":
            this.discharges = int.Parse(node.InnerText);
            break;
          case "Deaths":
            this.deaths = int.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in Activity24HrType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }

    #endregion

    #region Protected Member Functions
    #endregion
  }
}
