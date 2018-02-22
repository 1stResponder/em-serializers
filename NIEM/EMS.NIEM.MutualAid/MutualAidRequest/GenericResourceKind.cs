using System;
//using Newtonsoft.Json;
using System.Collections.Generic;
using EMS.NIEM.NIEMCommon;
using EMS.NIEM.Resource;
using System.Xml.Serialization;
using System.Linq;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a resource type
  /// </summary>
  [Serializable]
  public class GenericResourceKind
  {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the GenericResourceKind class
    /// </summary>
    public GenericResourceKind()
    {
    }

    /// <summary>
    /// Initializes a new instance of the GenericResourceKind class
    /// </summary>
    /// <param name="typeCode">Resource Type Code</param>
    /// <param name="description">(Optional) List of Resource Type Descriptions</param>
    /// <param name="def">(Optional) Resource NIMS definition</param>
    public GenericResourceKind(EventTypeCodeList typeCode, List<string> description = null, ResourceNIMSDefinition def = null)
    {
      ResourceTypeCode = typeCode;

      ResourceTypeDescriptor = description;
      ResourceNIMSDefinition = def;
    }

    /// <summary>
    /// Initializes a new instance of the GenericResourceKind class
    /// </summary>
    /// <param name="typeCode">Resource Type Code as string</param>
    /// <param name="description">(Optional) List of Resource Type Descriptions</param>
    /// <param name="def">(Optional) Resource NIMS definition</param>
    public GenericResourceKind(string typeCode, List<string> description = null, ResourceNIMSDefinition def = null)
    {
      SerialResourceTypeCode = typeCode;

      ResourceTypeDescriptor = description;
      ResourceNIMSDefinition = def;
    }
    #endregion
    #region Public Fields

    /// <summary>
    /// Gets or sets the Resource's Type Code Value
    /// </summary>
    /// <remarks>
    /// Required Element
    /// Defaults to ATOM
    /// </remarks>
    [XmlIgnore]
    public EventTypeCodeList ResourceTypeCode
    {
      get
      {
        return resourceTypeCode;
      }

      set
      {
        resourceTypeCode = value;
      }
    }

    /// <summary>
    /// Gets or sets the Resource's Event Type Code as/from string.  The string must be a valid resource type code
    /// Defaults to ATOM
    /// Used for Serialization
    /// </summary>
    /// <remarks>
    /// Required Element
    /// Defaults to ATOM
    /// </remarks>
    /// <exception cref="ArgumentNullException">Value was null</exception>
    /// <exception cref="ArgumentException">The value is not a valid Resource Type Code</exception>
    [XmlElement(ElementName = "ResourceTypeCode", Namespace = Constants.MaidNamespace, Order = 1)]
    public string SerialResourceTypeCode
    {
      get
      {
        return ResourceTypeCode.ToString().Replace('_', '.');
      }

      set
      {
        ResourceTypeCode = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
      }
    }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ResourceTypeDescriptorExtension", Namespace = Constants.MaidNamespace, Order = 2)]
    public List<String> ResourceTypeDescriptor { get; set; }

    /// <summary>
    /// Gets or sets the NIMS Definition
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ResourceNIMSDefinition", Namespace = Constants.EmlcNamespace, Order = 3)]
    public ResourceNIMSDefinition ResourceNIMSDefinition { get; set; }
    #endregion

    #region ShouldSerialMethods
    /// <summary>
    /// If ResourceTypeDescription list is null or empty then it will not be serialized
    /// It is an optional field
    /// </summary>
    /// <returns>true or false</returns>
    public bool ShouldSerializeResourceTypeDescriptor()
    {
      return (this.ResourceTypeDescriptor != null)
                  && (this.ResourceTypeDescriptor.Count > 0);
    }
    #endregion

    #region Private Field

    /// <summary>
    /// Holds the Resource Type Code
    /// </summary>
    /// <remarks>
    /// Required Element
    /// Defaults to ATOM
    /// </remarks>
    [XmlIgnore]
    private EventTypeCodeList resourceTypeCode;

    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the resouece type code
    /// </summary>
    /// <param name="typeCode">The resource type code</param>
    public void SetResourceTypeCode(EventTypeCodeList typeCode)
    {
      ResourceTypeCode = typeCode;
    }

    /// <summary>
    /// Sets the resouece type code
    /// </summary>
    /// <param name="typeCode">The resource type code as a string</param>
    public void SetResourceTypeCode(string typeCode)
    {
      SerialResourceTypeCode = typeCode;
    }

    /// <summary>
    /// Adds the given Resource Descriptor(s)
	/// Value can not be null
    /// </summary>
    /// <param name="desc">The List of Resource Descriptors</param>
    public void AddResourceDescriptor(List<string> desc)
    {
      if (ResourceTypeDescriptor == null) ResourceTypeDescriptor = new List<string>();

      ResourceTypeDescriptor.AddRange(desc);
    }

	/// <summary>
	/// Adds the given Resource Descriptor(s)
	/// Value can not be null
	/// </summary>
	/// <param name="desc">The List of Resource Descriptors as Array</param>
	public void AddResourceDescriptor(string[] desc)
    {
      AddResourceDescriptor(desc.ToList());
    }

	/// <summary>
	/// Adds the given Resource Descriptor(s)
	/// Value can not be null
	/// </summary>
	/// <param name="desc">The Resource Descriptor</param>
	public void AddResourceDescriptor(string desc)
    {
      if (ResourceTypeDescriptor == null) ResourceTypeDescriptor = new List<string>();

      ResourceTypeDescriptor.Add(desc);
    }

    #endregion



  }

}
