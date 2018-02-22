// ———————————————————————–
// <copyright file="ProviderInfoType.cs" company="EDXLSharp">
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
using System.ServiceModel.Syndication;
using System.Xml;
using EDXLSharp;

namespace MEXLTEPLib
{
  /// <summary>
  /// Represents Contact and Personal Information About the Care Provider
  /// </summary>
  [Serializable]
  public partial class ProviderInfoType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// The state assigned provider number of the responding agency or hospital
    /// </summary>
    private string agencyHospitalNumber;

    /// <summary>
    /// The formal name of the agency or hospital associated with the care provider
    /// </summary>
    private string hospitalName;

    /// <summary>
    /// The state in which the Agency or Hospital associated with the care provider provides services
    /// </summary>
    private string agencyHospitalState;

    /// <summary>
    /// The type of service provided by the care provider agency
    /// </summary>
    private VLList providerType;

    /// <summary>
    /// State or local Agency / Hospital ID number for the EMS-Care Provider 
    /// </summary>
    private string personnelIDNumber;

    /// <summary>
    /// EMS-Care Provider's State of certification
    /// </summary>
    private string personnelState;

    /// <summary>
    /// The medical certification level of the responding care provider
    /// </summary>
    private string personnelLevelofCertification;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ProviderInfoType class
    /// Default Constructor - Initializes ValueList
    /// </summary>
    public ProviderInfoType()
    {
      this.providerType = new VLList("ProviderType");
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The medical certification level of the responding care provider
    /// </summary>
    public string PersonnelLevelofCertification
    {
      get { return this.personnelLevelofCertification; }
      set { this.personnelLevelofCertification = value; }
    }

    /// <summary>
    /// Gets or sets
    /// EMS-Care Provider's State of certification
    /// </summary>
    public string PersonnelState
    {
      get { return this.personnelState; }
      set { this.personnelState = value; }
    }

    /// <summary>
    /// Gets or sets
    /// State or local Agency / Hospital ID number for the EMS-Care Provider 
    /// </summary>
    public string PersonnelIDNumber
    {
      get { return this.personnelIDNumber; }
      set { this.personnelIDNumber = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The type of service provided by the care provider agency
    /// </summary>
    public IList<ValueList> ProviderType
    {
      get { return this.providerType.Values; }
      set { this.providerType.Values = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The state in which the Agency or Hospital associated with the care provider provides services
    /// </summary>
    public string AgencyHospitalState
    {
      get { return this.agencyHospitalState; }
      set { this.agencyHospitalState = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The formal name of the agency or hospital associated with the care provider
    /// </summary>
    public string HospitalName
    {
      get { return this.hospitalName; }
      set { this.hospitalName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The state assigned provider number of the responding agency or hospital
    /// </summary>
    public string AgencyHospitalNumber
    {
      get { return this.agencyHospitalNumber; }
      set { this.agencyHospitalNumber = value; }
    }

    #endregion

    #region IComposable Interface Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.MEXLTEPPrefix, "ProviderInfo", "http://edxlsharp.codeplex.com/mEXL/TEP");
      xwriter.WriteElementString("AgencyHospitalNumber", this.agencyHospitalNumber);
      xwriter.WriteElementString("AgencyHospitalState", this.agencyHospitalState);
      xwriter.WriteElementString("PersonnelIDNumber", this.personnelIDNumber);
      xwriter.WriteElementString("PersonnelIDState", this.personnelState);
      if (!string.IsNullOrEmpty(this.hospitalName))
      {
        xwriter.WriteElementString("HospitalName", this.hospitalName);
      }

      this.providerType.WriteXML(xwriter);

      /*if (this.providerType.Count != 0)
      //{
      //  foreach (ValueList list in this.providerType)
      //  {
      //    xwriter.WriteStartElement("ProviderType");
      //    list.WriteXML(xwriter);
      //    xwriter.WriteEndElement();
      //  }
      //}*/
      
      if (!string.IsNullOrEmpty(this.personnelLevelofCertification))
      {
        xwriter.WriteElementString("PersonnelLevelofCertification", this.personnelLevelofCertification);
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      ////ValueList templist;
      if (rootnode.LocalName == "ProviderInfo")
      {
        this.providerType.ReadXML(rootnode);

        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }
      
          switch (childnode.LocalName)
          {
            case "AgencyHospitalNumber":
              this.agencyHospitalNumber = childnode.InnerText;
              break;
            case "AgencyHospitalState":
              this.agencyHospitalState = childnode.InnerText;
              break;
            case "PersonnelIDNumber":
              this.personnelIDNumber = childnode.InnerText;
              break;
            case "PersonnelIDState":
              this.personnelState = childnode.InnerText;
              break;
            case "HospitalName":
              this.hospitalName = childnode.InnerText;
              break;
            case "ProviderType":
              /*templist = new ValueList();
              //templist.ReadXML(childnode);
              //this.providerType.Add(templist);*/
              break;
            case "PersonnelLevelofCertification":
              this.personnelLevelofCertification = childnode.InnerText;
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ProviderInfoType");
          }
        }
      }
      else
      {
        throw new ArgumentException("Unexcepted Root Node Name: " + rootnode.Name + " in ProviderInfoType");
      }

      this.Validate();
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    internal void ToGeoRSS(SyndicationItem myitem)
    {
      myitem.Authors.Add(new SyndicationPerson(this.agencyHospitalNumber + " " + this.agencyHospitalState, this.personnelIDNumber + " " + this.personnelState, string.Empty));
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
      if (string.IsNullOrEmpty(this.agencyHospitalNumber))
      {
        throw new NullReferenceException("AgencyHospitalNumber can't be null in ProviderInfoType");
      }

      if (string.IsNullOrEmpty(this.agencyHospitalState))
      {
        throw new NullReferenceException("AgencyHospitalState can't be null in ProviderInfoType");
      }
      
      if (string.IsNullOrEmpty(this.personnelIDNumber))
      {
        throw new NullReferenceException("PersonnelIDNumber can't be null in ProviderInfoType");
      }
      
      if (string.IsNullOrEmpty(this.personnelState))
      {
        throw new NullReferenceException("PersonnelState can't be null in ProviderInfoType");
      }
    }

    #endregion
  }
}
