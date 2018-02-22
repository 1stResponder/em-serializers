using System;
//using Newtonsoft.Json;
using System.ComponentModel;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{

  /// <summary>
  /// Represents a Mission Need resource
  /// </summary> 
  [Serializable]
  public class MissionNeed: RequestResourceKind
    {
    #region Constructor

        /// <summary>
        /// Initializes a new instance of the MissionNeed class
        /// </summary>
        public MissionNeed() { 
            ValueText = "";           
        }

        /// <summary>
        /// Initializes a new instance of the MissionNeed class
        /// </summary>
        /// <param name="qu">Quantity</param>
        /// <param name="vt">Value Text</param>
        /// <param name="vListUrn">(Optional) Value List URN Text</param>
        /// <param name="augmen">(Optional) Value Augmentation Point</param>
        public MissionNeed(int qu, string vt, string vListUrn = null, string augmen = null)
        {
            Quantity = qu;
            ValueText = (vt != null) ? vt : "";
            ValueListURNText = vListUrn;
            ValueAugmentationPoint = augmen;
      }

    #endregion

    #region Public Fields
    /// <summary>
    /// Gets or sets the quantity
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
    /// Gets or sets the value text
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>     
    [XmlElement(ElementName = "ValueText", Namespace = Constants.EmeventNamespace, Order = 2)]
    public string ValueText { get; set; }

    /// <summary>
    /// Gets or sets the value list URN text
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ValueListURNText", Namespace = Constants.EmeventNamespace, Order = 3)]
    public string ValueListURNText { get; set; }

    /// <summary>
    /// Gets or sets the Augmentation Point for ValueType
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ValueAugmentationPoint", Namespace = Constants.EmeventNamespace, Order = 4)]
    public string ValueAugmentationPoint { get; set; }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the quantity
    /// Must be a positive value
    /// Required Element
    /// </summary>
    [XmlIgnore]
    private int quantity;
    #endregion

    }
}
