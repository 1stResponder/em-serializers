// ———————————————————————–
// <copyright file="ImmunizationSummary.cs" company="EDXLSharp">
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
  /// Immunization Summary sub type of Casualty and Illness Summary By Period
  /// </summary>
  [Serializable]
  public partial class ImmunizationSummary
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// The number of non-responders/responders who have received mass immunizations relevant
    /// specifically to incident conditions and/or as part of incident operations.
    /// </summary>
    private int? haveReceivedMassImmunizations;

    /// <summary>
    /// Proposed % of people who have received mass immunization 
    /// </summary>
    private double? percentReceived;

    /// <summary>
    /// The number of non-responders/responders who require mass 
    /// immunizations relevant to incident conditions and/or as part of incident 
    /// operations.
    /// </summary>
    private int? requireMassImmunizations;

    /// <summary>
    /// Proposed % of people who require mass immunization 
    /// </summary>
    private double? percentRequire;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ImmunizationSummary class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ImmunizationSummary()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? HaveReceivedMassImmunizations
    {
      get { return this.haveReceivedMassImmunizations; }
      set { this.haveReceivedMassImmunizations = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? PercentReceived
    {
      get { return this.percentReceived; }
      set { this.percentReceived = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? RequireMasImmunizations
    {
      get { return this.requireMassImmunizations; }
      set { this.requireMassImmunizations = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public double? PercentRequire
    {
      get { return this.percentRequire; }
      set { this.percentRequire = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("ImmunizationSummary");

      if (this.haveReceivedMassImmunizations != null)
      {
        xwriter.WriteElementString("HaveReceivedMassImmunizations", this.haveReceivedMassImmunizations.ToString());
      }

      if (this.percentReceived != null)
      {
        xwriter.WriteElementString("PercentRecieved", this.percentReceived.ToString());
      }

      if (this.requireMassImmunizations != null)
      {
        xwriter.WriteElementString("RequireMassImmunizations", this.requireMassImmunizations.ToString());
      }

      if (this.percentRequire != null)
      {
        xwriter.WriteElementString("PercentRequire", this.percentRequire.ToString());
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
          case "HaveReceivedMassImmunizations":
            this.haveReceivedMassImmunizations = Convert.ToInt32(childnode.InnerText);
            break;
          case "PercentRecieved":
            this.PercentReceived = Convert.ToDouble(childnode.InnerText);
            break;
          case "RequireMassImmunizations":
            this.requireMassImmunizations = Convert.ToInt32(childnode.InnerText);
            break;
          case "PercentRequire":
            this.percentRequire = Convert.ToDouble(childnode.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in CasualtyAndIllnessSummary");
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
