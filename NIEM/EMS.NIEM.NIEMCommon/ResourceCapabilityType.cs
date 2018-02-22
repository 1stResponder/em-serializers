using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a Resource Capability Type
  /// </summary>
  [Serializable]
  public class ResourceCapabilityType
    {
    #region Constructor

    /// <summary>
    /// Initializes the ResourceCapabilityType object
    /// </summary>
    public ResourceCapabilityType()
    {
      Type = "";
      Attribute = "";
    }

    /// <summary>
    /// Initializes the ResourceCapabilityType object
    /// </summary>
    /// <param name="resType">Type</param>
    /// <param name="resAtt">(Optional) Attribute</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public ResourceCapabilityType(string resType, string resAtt = null, int? orderNum = null)
    {
      if (orderNum != null) Order = (int)orderNum;

      Attribute = (resAtt != null) ? resAtt : "";
      Type = (resType != null) ? resType : "";
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets/Sets the order number
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
    /// Gets/Sets the Type
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 2, IsNullable = true)]
    public string Type
    {
      get
      {
        return type;
      }

      set
      {
        type = value;
      }
    }

    /// <summary>
    /// Gets/Sets the Attribute
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(Namespace = Constants.TNSNamespace, Order = 3, IsNullable = true)]
    public string Attribute
    {
      get
      {
        return attribute;
      }

      set
      {
        attribute = value;
      }
    }


    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the order number
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private int order;

    /// <summary>
    /// Holds the Type
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string type;

    /// <summary>
    /// Holds the Attribute
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string attribute;

    #endregion
  }
}
