// ———————————————————————–
// <copyright file="HospitalResourcesStatusType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the HospitalResourceStatus sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class HospitalResourcesStatusType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// The status of general staffing in the organization.  
    /// Values: 
    /// 1. Adequate – Meets the current needs. 
    /// 2. Insufficient – Current need is not being met and impacts the operations of the hospital. 
    /// Note: Specific shortage in one or more departments should be noted in the comments. 
    /// </summary>
    private AdequecyType? staffing;

    /// <summary>
    /// OPTIONAL 
    /// The status of supplies necessary for facility operations. 
    /// Values: 
    /// 1. Adequate – Meets the current needs. 
    /// 2. Insufficient – Current needs are not being met. 
    /// </summary>
    private AdequecyType? facilityOperations;

    /// <summary>
    /// OPTIONAL 
    /// The status of supplies necessary for clinical operations. 
    /// Values: 
    /// 1. Adequate – Meets the current needs
    /// 2. Insufficient – Current needs are not being met
    /// </summary>
    private AdequecyType? clinicalOperations;

    /// <summary>
    /// OPTIONAL
    /// The type of resources and their status or count.
    /// 1. Multiple values are allowed and each resource type SHOULD be enclosed with a ResourcesInformationText element.
    /// 2. This is an open format text field. 
    /// </summary>
    private List<string> resourcesInformationText;

    /// <summary>
    /// Comment Text
    /// </summary>
    private List<string> commentText;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the HospitalResourcesStatusType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public HospitalResourcesStatusType()
    {
      this.resourcesInformationText = new List<string>();
      this.commentText = new List<string>();
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of general staffing in the organization.  
    /// Values: 
    /// 1. Adequate – Meets the current needs. 
    /// 2. Insufficient – Current need is not being met and impacts the operations of the hospital. 
    /// Note: Specific shortage in one or more departments should be noted in the comments. 
    /// </summary>
    public AdequecyType? Staffing
    {
      get { return this.staffing; }
      set { this.staffing = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of supplies necessary for facility operations. 
    /// Values: 
    /// 1. Adequate – Meets the current needs. 
    /// 2. Insufficient – Current needs are not being met. 
    /// </summary>
    public AdequecyType? FacilityOperations
    {
      get { return this.facilityOperations; }
      set { this.facilityOperations = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The status of supplies necessary for clinical operations. 
    /// Values: 
    /// 1. Adequate – Meets the current needs
    /// 2. Insufficient – Current needs are not being met
    /// </summary>
    public AdequecyType? ClinicalOperations
    {
      get { return this.clinicalOperations; }
      set { this.clinicalOperations = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The type of resources and their status or count.
    /// 1. Multiple values are allowed and each resource type SHOULD be enclosed with a ResourcesInformationText element.
    /// 2. This is an open format text field. 
    /// </summary>
    public List<string> ResourcesInformationText
    {
      get { return this.resourcesInformationText; }
      set { this.resourcesInformationText = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment Text
    /// </summary>
    public List<string> CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
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

      if (this.staffing != null)
      {
        xwriter.WriteElementString("Staffing", this.staffing.ToString());
      }

      if (this.facilityOperations != null)
      {
        xwriter.WriteElementString("FacilityOperations", this.facilityOperations.ToString());
      }

      if (this.clinicalOperations != null)
      {
        xwriter.WriteElementString("ClinicalOperations", this.clinicalOperations.ToString());
      }

      if (this.resourcesInformationText.Count > 0)
      {
        foreach (string resourcetmp in this.resourcesInformationText)
        {
          if (string.IsNullOrEmpty(resourcetmp))
          {
            continue;
          }

          xwriter.WriteElementString("ResourcesInformationText", resourcetmp);
        }
      }

      if (this.commentText.Count > 0)
      {
        foreach (string comment in this.commentText)
        {
          if (string.IsNullOrEmpty(comment))
          {
            continue;
          }

          xwriter.WriteElementString("CommentText", comment);
        }
      }
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
          case "Staffing":
            this.staffing = (AdequecyType)Enum.Parse(typeof(AdequecyType), node.InnerText);
            break;
          case "FacilityOperations":
            this.facilityOperations = (AdequecyType)Enum.Parse(typeof(AdequecyType), node.InnerText);
            break;
          case "ClinicalOperations":
            this.clinicalOperations = (AdequecyType)Enum.Parse(typeof(AdequecyType), node.InnerText);
            break;
          case "ResourcesInformationText":
            this.resourcesInformationText.Add(node.InnerText);
            break;
          case "CommentText":
            this.commentText.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in HospitalResourcesStatusType");
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
