//-----------------------------------------------------------------------
// <copyright file="ResourceDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Resource
{
// NOTE: The xml name/namespace prefix of this class is hard coded in the JSON deserialization process.  
   // If the class name is changed then that must be updated as well.   
   // Places to Update:
   //      deSerialEventConverter


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
  [XmlRootAttribute("ResourceDetail", Namespace = Constants.EmlcNamespace)]
  public class ResourceDetail : EventDetails
  {
    /// <summary>
    /// Initializes a new instance of the ResourceDetail class
    /// </summary>
    public ResourceDetail()
    {
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.MofPrefix, Constants.MofNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
    }

    /// <summary>
    /// Gets or sets the status of this resource
    /// </summary>
    [XmlElement(ElementName = "ResourceStatus")]
    public ResourceStatus Status
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets Namespace object place for serializing prefixes for namespaces
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is supressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the owning organization for this resource
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceStatus"/>.
    /// <seealso cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourcePrimaryStatusCodeList"/>
    /// </summary>
    public void setPrimaryStatus(ResourcePrimaryStatusCodeList value)
    {
         Status.PrimaryStatus = value;
    }

    /// <summary>
    /// Adds a new text status to secondary status 
    /// <see cref="NIEMSHARP.NIEMEMLCLib.TextStatus"/>.
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceEIDDStatus"/>.
    /// <seealso cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceEIDDStatusCodeList"/>
    /// </summary>
    public void AddEIDDStatus(ResourceEIDDStatusCodeList value)
    {
        ResourceEIDDStatus status = new ResourceEIDDStatus();
        status.EIDDCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new UCAD status to secondary status 
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceUCADStatus"/>.
    /// <seealso cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceUCADStatusCodeList"/>
    /// </summary>
    public void AddUCADStatus(ResourceUCADStatusCodeList value)
    {
        ResourceUCADStatus status = new ResourceUCADStatus();
        status.UCADCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Sets the resource organization 
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Resource.ResourceOrganization"/>.
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
