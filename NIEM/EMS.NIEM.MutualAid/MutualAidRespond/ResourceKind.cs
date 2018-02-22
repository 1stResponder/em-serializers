using System;
//using Newtonsoft.Json;
using System.Collections.Generic;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a Resource kind
  /// </summary>
  [Serializable]
  public class ResourceKind
  {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ResourceKind class
    /// </summary>
    public ResourceKind()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ResourceKind class
    /// </summary>
    /// <param name="typeCode">Resource Type Code</param>
    /// <param name="desc">(Optional) The Resource Desc Ext List</param>
    /// <param name="def">(Optional) The Resource NIMS def</param>
    public ResourceKind(EventTypeCodeList typeCode, List<string> desc = null, ResourceNIMSDefinition def = null)
    {
      ResourceTypeCode = typeCode;
      ResourceTypeDescriptor = desc;
      ResourceNIMSDefinition = def;
    }

	/// <summary>
	/// Initializes a new instance of the ResourceKind class
	/// </summary>
	/// <param name="typeCode">Resource Type Code as string</param>
	/// <param name="desc">(Optional) The Resource Desc Ext List</param>
	/// <param name="def">(Optional) The Resource NIMS def</param>
	public ResourceKind(string typeCode, List<string> desc = null, ResourceNIMSDefinition def = null)
    {
      SerialResourceTypeCode = typeCode;
      ResourceTypeDescriptor = desc;
      ResourceNIMSDefinition = def;
    }
	
	#endregion

	#region Public Fields

	/// <summary>
	/// Gets/Sets the Resource Type Code
	/// </summary>
	/// <remarks>
	/// Required Element
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
    /// Gets/Sets the serialized Resource Type Code
    /// </summary>
    /// <remarks>
    /// Required Element
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
    /// Gets or sets the descriptor
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ResourceTypeDescriptorExtension", Namespace = Constants.MaidNamespace, Order = 2)]
    public List<String> ResourceTypeDescriptor
    {
      get
      {
        return resourceTypeDescriptor;
      }

      set
      {
        resourceTypeDescriptor = value;
      }

    }

    /// <summary>
    /// Gets or sets the NIMS Definition
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ResourceNIMSDefinition", Namespace = Constants.EmlcNamespace, Order = 3)]
    public ResourceNIMSDefinition ResourceNIMSDefinition
    {
      get
      {
        return resourceNIMSDefinition;
      }

      set
      {
        resourceNIMSDefinition = value;
      }

    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the Resource's Type Code
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private EventTypeCodeList resourceTypeCode;

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private List<String> resourceTypeDescriptor;

    /// <summary>
    /// Gets or sets the NIMS Definition
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private ResourceNIMSDefinition resourceNIMSDefinition;

    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the Resource type code
    /// </summary>
    /// <param name="code">The resource type code as a string</param>
    public void AddResourceTypeCode(string code)
    {
      SerialResourceTypeCode = code;
    }

    /// <summary>
    /// Sets the Resource type code
    /// </summary>
    /// <param name="code">The resource type code</param>
    public void AddResourceTypeCode(EventTypeCodeList code)
    {
      ResourceTypeCode = code;
    }

    #endregion

  }

}
