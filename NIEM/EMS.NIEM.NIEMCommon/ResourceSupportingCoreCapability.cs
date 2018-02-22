using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a Resource Support Core Capability 
  /// </summary>
  [Serializable]
  public class ResourceSupportingCoreCapability
    {
    #region Constructor

    /// <summary>
    /// Initializes the Supporting Core Capability
    /// </summary>
    public ResourceSupportingCoreCapability()
    {
      Name = "";
    }

    /// <summary>
    /// Initializes the Supporting Core Capability
    /// </summary>
    /// <param name="capName">Name</param>
    public ResourceSupportingCoreCapability(string capName)
    {
      Name = capName;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets/Sets the name for this Core Capability
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "Name", Namespace = Constants.TNSNamespace, Order = 1, IsNullable = true)]
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
      }
    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the name for this Core Capability
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string name;

    #endregion
  }
}
