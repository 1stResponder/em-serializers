using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a Resource Capability
  /// </summary>
  [Serializable]
  public class ResourceCapability
    {
    #region Constructor

    /// <summary>
    /// Initializes the ResourceCapability object
    /// </summary>
    public ResourceCapability()
    { }

	/// <summary>
	/// Initializes the ResourceCapability object
	/// </summary>
	/// <param name="resComponent">Component</param>
	/// <param name="resMetric">(Optional) Metric</param>
	/// <param name="resAbility">(Optional) Ability</param>
	/// <param name="resNote">(Optional) Notes</param>
	/// <param name="resOrder">(Optional) Order Number</param>
	/// <param name="resTypes">(Optional) List of Resource Types</param>
	public ResourceCapability(string resComponent, string resMetric = null, string resAbility = null, string resNote = null, int? resOrder = null, List<ResourceCapabilityType> resTypes = null)
    {
      Component = resComponent;
      Metric = resMetric;
      Ability = resAbility;
      Notes = resNote;
      Types = resTypes;
      Order = (int) resOrder;
    }

	#endregion

	#region Public Fields

	/// <summary>
	/// Gets/Sets the Order Number
	/// </summary>
	/// <remarks>
	/// Optional Element
	/// </remarks>
	[XmlElement(Namespace = Constants.TNSNamespace, Order = 1)]
    public int Order
    {
      get
      {
        return order;
      }

      set
      {
        order = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Component
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 2, IsNullable = true)]
    public string Component
    {
      get
      {
        return component;
      }

      set
      {
        component = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Metric
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 3, IsNullable = true)]
    public string Metric
    {
      get
      {
        return metric;
      }

      set
      {
        metric = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Ability 
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 4, IsNullable = true)]
    public string Ability
    {
      get
      {
        return ability;
      }

      set
      {
        ability = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Notes
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 5, IsNullable = true)]
    public string Notes
    {
      get
      {
        return note;
      }

      set
      {
        note = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Capability Types
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlArray("Types", Namespace = Constants.TNSNamespace, Order = 6, IsNullable = true)]
    [XmlArrayItem("ResourceCapabilityType", typeof(ResourceCapabilityType), Namespace = Constants.TNSNamespace)]
    public List<ResourceCapabilityType> Types
    {
      get
      {
        return types;
      }

      set
      {
        types = value;
      }
    }


    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the Order Number
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private int order;

    /// <summary>
    /// Holds the Component
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string component;

    /// <summary>
    /// Holds the Metric
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string metric;

    /// <summary>
    /// Holds the Ability 
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string ability;

    /// <summary>
    /// Holds the Notes
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string note;

    /// <summary>
    /// Holds the Capability Types
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private List<ResourceCapabilityType> types;
	#endregion

	#region Helper Methods

	/// <summary>
	/// Adds the given ResourceCapabilityType to the Type list
	/// Value can not be null
	/// </summary>
	/// <param name="t">ResourceCapabilityType object</param>
	public void AddResourceCapabilityType(ResourceCapabilityType t)
    {
      AddResourceCapabilityType(new List<ResourceCapabilityType> { t });
    }

	/// <summary>
	/// Adds the given ResourceCapabilityTypes to the Type list
	/// Value can not be null
	/// </summary>
	/// <param name="t">List of ResourceCapabilityType object</param>
	public void AddResourceCapabilityType(List<ResourceCapabilityType> t)
    {
      if (Types == null) Types = new List<ResourceCapabilityType>();
      Types.AddRange(t);
    }

	/// <summary>
	/// Adds the given ResourceCapabilityTypes to the Type list
	/// Value can not be null
	/// </summary>
	/// <param name="t">Array of ResourceCapabilityType object</param>
	public void AddResourceCapabilityType(ResourceCapabilityType[] t)
    {
      AddResourceCapabilityType(t.ToList());
    }

    /// <summary>
    /// Creates a ResourceCapabilityType with the given values and adds it to the Type list
    /// </summary>
    /// <param name="resType">Type</param>
    /// <param name="resAtt">(Optional) Attribute</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public void AddResourceCapabilityType(string resType, string resAtt = null, int? orderNum = null)
    {
	  AddResourceCapabilityType(new ResourceCapabilityType(resType, resAtt, orderNum));
    }

    #endregion
  }
}
