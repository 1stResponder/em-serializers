// ———————————————————————–
// <copyright file="TotalResources.cs" company="EDXLSharp">
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
  /// Total Resources sub class of Response Resources Totals
  /// </summary>
  [Serializable]
  public partial class TotalResources
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Personnel count
    /// </summary>
    private int? personnel;

    /// <summary>
    /// Resources count
    /// </summary>
    private int? resources;
    
    /// <summary>
    /// Additional assisting organizations count
    /// </summary>
    private string additionalAssistingOrganizations;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TotalResources class
    /// Default Constructor - Does Nothing
    /// </summary>
    public TotalResources()
    {
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Personnel
    {
      get { return this.personnel; }
      set { this.personnel = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public int? Resources
    {
      get { return this.resources; }
      set { this.resources = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public string AdditionalAssistingOrganizations
    {
      get { return this.additionalAssistingOrganizations; }
      set { this.additionalAssistingOrganizations = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      if (this.personnel != null)
      {
        xwriter.WriteElementString("Personnel", this.personnel.ToString());
      }

      if (this.resources != null)
      {
        xwriter.WriteElementString("Resources", this.resources.ToString());
      }

      if (!string.IsNullOrEmpty(this.additionalAssistingOrganizations))
      {
        xwriter.WriteElementString("AdditionalAssistingOrganizations", this.additionalAssistingOrganizations);
      }
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
          case "Personnel":
            this.personnel = Convert.ToInt32(childnode.InnerText);
            break;
          case "Resources":
            this.resources = Convert.ToInt32(childnode.InnerText);
            break;
          case "AdditionalAssistingOrganizations":
            this.additionalAssistingOrganizations = childnode.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ResponseResourcesTotals");
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