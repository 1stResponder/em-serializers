// ———————————————————————–
// <copyright file="NotifiableDiseaseNumbers.cs" company="EDXLSharp">
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

namespace MEXLSitRep
{
  /// <summary>
  /// Disease Numbers sub type of Casualty and Illness Summary By Period
  /// </summary>
  [Serializable]
  public partial class NotifiableDiseaseNumbers
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Pandemic identifier
    /// </summary>
    private int? pandemicSuspect;

    /// <summary>
    /// Probable Cause
    /// </summary>
    private string probableCause;

    /// <summary>
    /// Number of suspected cases
    /// </summary>
    private int? numberOfSuspectedCases;

    /// <summary>
    /// Number of confirmed cases
    /// </summary>
    private int? numberOfConfirmedCases;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the NotifiableDiseaseNumbers class
    /// Default Constructor - Does Nothing
    /// </summary>
    public NotifiableDiseaseNumbers()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? PandemicSuspect
    {
      get { return this.pandemicSuspect; }
      set { this.pandemicSuspect = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string ProbableCause
    {
      get { return this.probableCause; }
      set { this.probableCause = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? NumberOfSuspectedCases
    {
      get { return this.numberOfSuspectedCases; }
      set { this.numberOfSuspectedCases = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? NumberOfConfirmedCases
    {
      get { return this.numberOfConfirmedCases; }
      set { this.numberOfConfirmedCases = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("NotifiableDiseaseNumbers");

      if (this.pandemicSuspect != null)
      {
        xwriter.WriteElementString("PandemicSuspect", this.pandemicSuspect.ToString());
      }

      if (!string.IsNullOrEmpty(this.probableCause))
      {
        xwriter.WriteElementString("ProbableCause", this.probableCause);
      }

      if (this.numberOfSuspectedCases != null)
      {
        xwriter.WriteElementString("NumberofSuspectedCases", this.numberOfSuspectedCases.ToString());
      }

      if (this.numberOfConfirmedCases != null)
      {
        xwriter.WriteElementString("NumberofConfirmedCases", this.numberOfConfirmedCases.ToString());
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "PandemicSuspect":
            this.pandemicSuspect = Convert.ToInt32(childnode.InnerText);
            break;
          case "ProbableCause":
            this.probableCause = childnode.InnerText;
            break;
          case "NumberofSuspectedCases":
            this.numberOfSuspectedCases = Convert.ToInt32(childnode.InnerText);
            break;
          case "NumberofConfirmedCases":
            this.numberOfConfirmedCases = Convert.ToInt32(childnode.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in Notifiable Disease Numbers");
        }
      }
    }
    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected void Validate()
    {
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
