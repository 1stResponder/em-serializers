//-----------------------------------------------------------------------
// <copyright file="ResourceNIMSDefinition.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents the NIMS typing of a resource
  /// </summary>
  [Serializable]
  public class ResourceNIMSDefinition
  {
    #region Constructor

    /// <summary>
    /// Initializes the ResourceNIMSDefinition Object
    /// </summary>
    public ResourceNIMSDefinition()
    {
    }

    /// <summary>
    /// Initializes the ResourceNIMSDefinition Object
    /// </summary>
    /// <param name="resourceDef">List of ResourceDefinitions</param>
    public ResourceNIMSDefinition(List<ResourceDefinition> resourceDef)
    {
      Definition = resourceDef;
    }

    #endregion
    #region Public Fields
    /// <summary>
    /// Gets/Sets the List of Resource Definitions
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName= "ResourceDefinition", Namespace = Constants.FEMARTLTNamespace, Order = 1)]
    public List<ResourceDefinition> Definition
    {
      get
      {
        return definition;
      }

      set
      {
        definition = value;
      }
    }  
    #endregion

    #region Private Fields
    /// <summary>
    /// Holds the List of Resource Definitions
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private List<ResourceDefinition> definition;

    #endregion

    #region Helper Methods

    /// <summary>
    /// Adds the Resource Definition to the Definition list
	/// Value can not be null
    /// </summary>
    /// <param name="def">The Resource Definition</param>
    public void AddResourceDefinition(ResourceDefinition def)
    {
      AddResourceDefinition(new List<ResourceDefinition> { def });
    }

	/// <summary>
	/// Adds the Resource Definitions to the Definition list
	/// Value can not be null
	/// </summary>
	/// <param name="def">List of Resource Definitions</param>
	public void AddResourceDefinition(List<ResourceDefinition> def)
    {
      if (Definition == null) Definition = new List<ResourceDefinition>();
      Definition.AddRange(def);
    }

	/// <summary>
	/// Adds the Resource Definitions to the Definition list
	/// Value can not be null
	/// </summary>
	/// <param name="def">Array of Resource Definitions</param>
	public void AddResourceDefinition(ResourceDefinition[] def)
    {
      AddResourceDefinition(def.ToList());
    }

    #endregion

  }
}
