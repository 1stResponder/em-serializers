//-----------------------------------------------------------------------
// <copyright file="ResourceOwningOrganization.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// Represents the organization who owns a resource
  /// </summary>
  [Serializable]
  public class ResourceOrganization
  {

    /// <summary>
    /// Initializes ResourceOrganization object 
    /// </summary>
    public ResourceOrganization()
    {
        OrgIDSerialized = new IdentificationID();
        ResourceIDSerialized = new IdentificationID();
    }

    /// <summary>
    /// Serializes or deserializes the organization's id
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "OrganizationIdentification", Namespace = Constants.NiemcoreNamespace)]
    public IdentificationID OrgIDSerialized
    {
      get; set;
    }

    /// <summary>
    /// Gets of sets the organization's id
    /// </summary>
    [XmlIgnore]
    public string OrgID
    {
      get
      {
        return OrgIDSerialized != null ? OrgIDSerialized.ID : "";
      }
      set
      {
        if (this.OrgIDSerialized == null)
        {
          this.OrgIDSerialized = new IdentificationID(value);
        }
        else
        {
          this.OrgIDSerialized.ID = value;
        }
      }
    }

    /// <summary>
    /// Gets or sets the organization's id for this resource
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "ResourceIdentifier")]
    public IdentificationID ResourceIDSerialized
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the organization's id for this resource
    /// </summary>
    [XmlIgnore]
    public string ResourceID
    {
      get
      {
        return ResourceIDSerialized != null ? ResourceIDSerialized.ID : "";
      }
      set
      {
        if (this.ResourceIDSerialized == null)
        {
          this.ResourceIDSerialized = new IdentificationID(value);
        }
        else
        {
          this.ResourceIDSerialized.ID = value;
        }
      }
    }
  }
}