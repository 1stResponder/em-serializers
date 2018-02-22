using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Name of an Organization
  /// </summary>
  [Serializable]
  public class OrganisationNameType 
  {
    #region Private Member Variables

    /// <summary>
    /// A unique identifier for the Organization
    /// </summary>
    private string organizationID;

    /// <summary>
    /// The name of the provider that has provided the identification scheme. This could also be the name a particular identification list.
    /// </summary>
    private string organizationIDKind;

    /// <summary>
    /// Name of the Organization.
    /// </summary>
    private List<string> nameElements;

    /// <summary>
    /// The name of the sub division Organization.
    /// </summary>
    private List<string> subDivisionNames;

    #endregion Private Member Variables

    #region XML Elements
    /// <summary>
    /// Gets or sets
    /// Name of the Organization.
    /// </summary>
    [XmlElement("nameElement", Order = 1)]
    public List<string> NameElements
    {
      get { return this.nameElements; }
      set { this.nameElements = value; }
    }

    [XmlIgnore]
    public bool NameElementsSpecified
    {
      get { return this.nameElements != null && this.nameElements.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// The name of the sub division Organization.
    /// </summary>
    [XmlElement("subDivisionName", Order = 2)]
    public List<string> SubDivisionNames
    {
      get { return this.subDivisionNames; }
      set { this.subDivisionNames = value; }
    }

    [XmlIgnore]
    public bool SubDivisionNamesSpecified
    {
      get { return this.subDivisionNames != null && this.subDivisionNames.Count > 0; }
    }
    #endregion XML Elements

    #region XML Attributes
    /// <summary>
    /// Gets or sets
    /// A unique identifier for the Organization
    /// </summary>
    [XmlAttribute("OrganisationID")]
    public string OrganizationID
    {
      get { return this.organizationID; }
      set { this.organizationID = value; }
    }

    [XmlIgnore]
    public bool OrganizationIDSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.organizationID); }
    }

    /// <summary>
    /// Gets or sets
    /// The name of the provider that has provided the identification scheme. This could also be the name a particular identification list.
    /// </summary>
    [XmlAttribute("OrganisationIDKind")]
    public string OrganizationIDKind
    {
      get { return this.organizationIDKind; }
      set { this.organizationIDKind = value; }
    }

    [XmlIgnore]
    public bool OrganizationIDKindSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.organizationIDKind); }
    }
    #endregion XML Attributes
  }
}