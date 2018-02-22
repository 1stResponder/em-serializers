using System;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents rank of person
  /// </summary>
  [Serializable]
  public class Rank
  {
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the Rank class
    /// </summary>
    public Rank()
    {
      ValueText = "";
    }

    /// <summary>
    /// Initializes a new instance of the Rank class
    /// </summary>
    /// <param name="vt">Value Text</param>
    /// <param name="vListUrn">(Optional) Value List URN Text</param>
    /// <param name="vAugmenPoint">(Optional) Value Augmentation Point</param>
    public Rank(string vt, string vListUrn = null, string vAugmenPoint = null)
    {
      ValueText = (vt != null) ? vt : "";

      ValueListURNText = vListUrn;
      ValueAugmentationPoint = ValueAugmentationPoint;
    }
    #endregion
    #region Public Field

    /// <summary>
    /// Gets or sets the value text
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "ValueText", Namespace = Constants.EmeventNamespace, Order = 1)]
    public string ValueText { get; set; }

    /// <summary>
    /// Gets or sets the value list URN text
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "ValueListURNText", Namespace = Constants.EmeventNamespace, Order = 2)]
    public string ValueListURNText { get; set; }

    /// <summary>
    /// Gets or sets the Augmentation Point
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    // TODO: Get real type.  This is an abstract element 
    [XmlElement(ElementName = "ValueAugmentationPoint", Namespace = Constants.EmeventNamespace, Order = 3)]
    public string ValueAugmentationPoint { get; set; }

    #endregion

  }
}
