//-----------------------------------------------------------------------
// <copyright file="ResourceDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{

  /// <summary>
  /// Represents the type of organization
  /// </summary>
  public enum OrginizationType
  {
        /// <summary>
        /// Controlling organization
        /// </summary>
        [XmlEnum(Name = "CONTROLLING")]
        Controlling,

        /// <summary>
        /// Owning organization
        /// </summary>
        [XmlEnum(Name = "OWNING")]
        Owning,
  }

  /// <summary>
  /// Represents a single resource
  /// </summary>
  [Serializable]
  public class ResourceDetail : EventDetails
  {
    /// <summary>
    /// Initializes a new instance of the ResourceDetail class
    /// </summary>
    public ResourceDetail()
    {
        Status = new ResourceStatus();
        OwningOrg = new ResourceOrganization();

    }

    /// <summary>
    /// Gets or sets the status of this resource
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "ResourceStatus")]
    public ResourceStatus Status
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the owning organization for this resource
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "ResourceOwningOrganization")]
    public ResourceOrganization OwningOrg
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the controlling organization for this resource
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ResourceControllingOrganization")]
    public ResourceOrganization ControllingOrg
    {
      get; set;
    }

    /// <summary>
    /// Controls the serialization of the optional element "ResourceControllingOrganization"
    /// </summary>
    /// <returns>Whether or not to serialize the element</returns>
    public bool ShouldSerializeControllingOrg()
    {
      return ControllingOrg != null;
    }

    /// <summary>
    /// Gets or sets the National Incident Management System resource type for this resource
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ResourceNIMSDefinition")]
    public ResourceNIMSDefinition NIMSType
    {
      get; set;
    }

    /// <summary>
    /// Controls the serialization of the optional element "NIMSType"
    /// </summary>
    /// <returns>Whether or not to serialize the element</returns>
    public bool ShouldSerializeNIMSType()
    {
      return NIMSType != null;
    }

    /// <summary>
    /// Sets primary status code 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Resource.ResourcePrimaryStatusCodeList"/>
    /// </summary>
    public void setPrimaryStatus(ResourcePrimaryStatusCodeList value)
    {
         Status.PrimaryStatus = value;
    }

    /// <summary>
    /// Adds a new text status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.TextStatus"/>.
    /// </summary>
    public void AddSecondaryStatusText(string description, string sourceID)
    {
            TextStatus status = new TextStatus();
            status.Description = description;
            status.SourceID = sourceID;
            Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new EIDD status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceEIDDStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceEIDDStatusCodeList"/>
    /// </summary>
    public void AddEIDDStatus(ResourceEIDDStatusCodeList value)
    {
        ResourceEIDDStatus status = new ResourceEIDDStatus();
        status.EIDDCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new UCAD status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceUCADStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceUCADStatusCodeList"/>
    /// </summary>
    public void AddUCADStatus(ResourceUCADStatusCodeList value)
    {
        ResourceUCADStatus status = new ResourceUCADStatus();
        status.UCADCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Sets the resource organization 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Resource.ResourceOrganization"/>.
    /// </summary>
    public void setOrganization(OrginizationType type, string orgID, string resourceID)
    {

        if (type == OrginizationType.Owning)
        {
            OwningOrg.OrgID = orgID;
            OwningOrg.ResourceID = resourceID;

        } else if (type == OrginizationType.Controlling)
        {
            ControllingOrg.OrgID = orgID;
            ControllingOrg.ResourceID = resourceID;
        }
    }




    }

;}
