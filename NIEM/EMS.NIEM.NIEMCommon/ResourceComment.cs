using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a Resource Comment
  /// </summary>
  [Serializable]
  public class ResourceComment
    {
    #region Constructor

    /// <summary>
    /// Initializes the ResourceComment object
    /// </summary>
    public ResourceComment()
    {
    }

    /// <summary>
    /// Initializes the ResourceComment object
    /// </summary>
    /// <param name="resComment">Comment</param>
    /// <param name="orderNum">(Optional) Order Number</param>
    public ResourceComment(string resComment, int? orderNum = null)
    {
      if (orderNum != null) Order = (int)orderNum;
      Comment = resComment;
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
    /// Gets/Sets the note
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "Comment", Namespace = Constants.TNSNamespace, Order = 2, IsNullable = true)]
    public string Comment
    {
      get
      {
        return comment;
      }

      set
      {
        comment = value;
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
    /// Holds the Comment
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private string comment;

    #endregion
  }
}
