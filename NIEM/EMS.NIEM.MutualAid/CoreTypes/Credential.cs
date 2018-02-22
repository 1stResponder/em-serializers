using System;
//using Newtonsoft.Json;
using System.ComponentModel;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a credential for a person
  /// </summary>
  [Serializable]
  public class Credential
  {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the Credential class
    /// </summary>
    public Credential()
    {
      // init value text since its a required element
      ValueText = "";
    }

    /// <summary>
    /// Initializes a new instance of the Credential class
    /// </summary>
    /// <param name="vt">Value Text</param>
    /// <param name="vListUrn">(Optional) Value List URN Text</param>
    /// <param name="vAugmenPoint">(Optional) Value Augmentation Point</param>
    public Credential(string vt, string vListUrn = null, string vAugmenPoint = null)
    {
      ValueText = (vt != null) ? vt : "";

      ValueListURNText = vListUrn;
      ValueAugmentationPoint = ValueAugmentationPoint;
    }

    #endregion
    #region Public Fields

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
