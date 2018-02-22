using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a Resource Reference
  /// </summary>
  [Serializable]
  public class ResourceReference
    {
    #region Constructor

    /// <summary>
    /// Initializes the ResourceReference object
    /// </summary>
    public ResourceReference()
    {
    }

    /// <summary>
    /// Initializes the ResourceReference object
    /// </summary>
    /// <param name="resRef">Reference</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public ResourceReference(string resRef, int? orderNum = null)
    {
      if (orderNum != null) Order = (int) orderNum;
      Reference = resRef;
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets/Sets the order number
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "Order", Namespace = Constants.TNSNamespace, Order = 1)]
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
    /// Gets/Sets the Reference
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "Reference", Namespace = Constants.TNSNamespace, Order = 2, IsNullable = true)]
    public string Reference
    {
      get
      {
        return reference;
      }

      set
      {
        reference = value;
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
    /// Holds the Reference
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string reference;
    
    #endregion
  }
}
