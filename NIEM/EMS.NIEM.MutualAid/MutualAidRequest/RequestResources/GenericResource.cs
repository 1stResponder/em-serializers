using System;
using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a generic resource
  /// </summary>
  [Serializable]
  public class GenericResource : RequestResourceKind
  {

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the GenericResource class
    /// </summary>        
    public GenericResource()
    {
      ResourceKind = new GenericResourceKind();
    }

    /// <summary>
    /// Initializes a new instance of the GenericResource class
    /// </summary>
    /// <param name="qu">Quantity</param>
    /// <param name="res">Resource Kind</param>
    public GenericResource(int qu, GenericResourceKind res)
    {
      Quantity = qu;
      ResourceKind = (res != null) ? res : new GenericResourceKind();
    }

	/// <summary>
	/// Initializes a new instance of the GenericResource class
	/// </summary>
	/// <param name="qu">Quantity</param>
	/// <param name="typeCode">Type code for Generic Resource Kind</param>
	/// <param name="def">(Optional) NIMS Definition for Generic Resource Kind</param>
	/// <param name="description">(Optional) Descriptor List for Generic Resource Kind</param>
	public GenericResource(int qu, EventTypeCodeList typeCode, ResourceNIMSDefinition def = null, List <string> description = null)
    {
      Quantity = qu;
      ResourceKind = new GenericResourceKind(typeCode, description, def);
    }
    #endregion
    #region Public Fields

    /// <summary>
    /// Gets or sets the quantity for this resource
    /// Must be a positive value
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "Quantity", Namespace = Constants.MaidNamespace, Order = 1)]
    public int Quantity
    {
      get
      {
        return quantity;
      }

      set
      {

        if (value < 0)
        {
          throw new ArgumentOutOfRangeException("value", "Quantity must be positive value.");
        }

        quantity = value;
      }
    }

    /// <summary>
    /// Gets or sets the resource type
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "AidRequestedGenericResourceKind", Namespace = Constants.MaidNamespace, Order = 2)]
    public GenericResourceKind ResourceKind { get; set; }

    #endregion
    #region Private Fields
    /// <summary>
    /// Gets or sets the quantity for this resource
    /// Must be a positive value
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    private int quantity;
    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the ResourceKind
    /// </summary>
    /// <param name="kind">The GenericResourceKind</param>
    public void SetResourceKind(GenericResourceKind kind)
    {
      ResourceKind = kind;
    }

    /// <summary>
    /// Sets the ResourceKind
    /// </summary>
    /// <param name="typeCode">Resource Type Code</param>
    /// <param name="description">(Optional) List of Resource Type Descriptions</param>
    /// <param name="def">(Optional) Resource NIMS definition</param>
    public void SetResourceKind(EventTypeCodeList typeCode, List<string> description = null, ResourceNIMSDefinition def = null)
    {
      ResourceKind = new GenericResourceKind(typeCode, description, def);
    }

    /// <summary>
    /// Sets the ResourceKind
    /// </summary>
    /// <param name="typeCode">Resource Type Code as string</param>
    /// <param name="description">(Optional) List of Resource Type Descriptions</param>
    /// <param name="def">(Optional) Resource NIMS definition</param>
    public void SetResourceKind(string typeCode, List<string> description = null, ResourceNIMSDefinition def = null)
    {
      ResourceKind = new GenericResourceKind(typeCode, description, def);
    }

    #endregion

  }
}
