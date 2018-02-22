// ———————————————————————–
// <copyright file="IncidentCommandOrganizationandAssignments.cs" company="EDXLSharp">
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
using System.Collections.Generic;
using System.Xml;
using EDXLSharp.CIQLib;

namespace MEXLSitRep
{
  /// <summary>
  /// Incident Command Organization and Assignments that is called by Sit Rep ResponseResourcesTotals and SituationSummary
  /// </summary>
  [Serializable]
  public partial class IncidentCommandOrganizationandAssignments
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Incident Command Structure
    /// </summary>
    private List<OrganizationInformation> structure;

    /// <summary>
    /// Command Structure Graphic - place holder
    /// </summary>
    private byte[] structureGraphic;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the IncidentCommandOrganizationandAssignments class
    /// Default Constructor - Does Nothing
    /// </summary>
    public IncidentCommandOrganizationandAssignments()
    {
      this.structure = new List<OrganizationInformation>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public List<OrganizationInformation> Structure
    {
      get { return this.structure; }
      set { this.structure = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public byte[] StructureGraphic
    {
      get { return this.structureGraphic; }
      set { this.structureGraphic = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("IncidentCommandOrganizationandAssignments");

      if (this.structure != null)
      {
        foreach (OrganizationInformation info in this.structure)
        {
          xwriter.WriteStartElement("Structure");
          info.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      if (this.structureGraphic != null)
      {
        xwriter.WriteElementString("StructureGraphic", this.structureGraphic.ToString());
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal void ReadXML(XmlNode rootnode)
    {
      OrganizationInformation infoTemp = new OrganizationInformation();
      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "Structure":
            if (this.structure == null)
            {
              this.structure = new List<OrganizationInformation>();
            }
            
            infoTemp.ReadXML(childnode);
            this.structure.Add(infoTemp);
            break;
          case "StructureGraphic":
            // this.structureGraphic = Convert.ToByte(childnode.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in IncidentCommandOrganizationandAssignments");
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
