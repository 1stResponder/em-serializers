using System;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Holds the contact information for a response
  /// </summary>
  [Serializable]
  public class ContactInformation
    {
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the ContactInformation class
    /// </summary>
    public ContactInformation() { }

    /// <summary>
    /// Initializes a new instance of the ContactInformation class
    /// </summary>
    /// <param name="mean">The contact mean</param>
    /// <param name="entity">The contact entity</param>
    /// <param name="entityDesc">The contact entity's description</param>
    /// <param name="infoDesc">The contact information description</param>
    /// <param name="responder">The contact responder</param>
    /// <param name="augmentPoint">The contact augmentation point</param>
    public ContactInformation(string mean, string entity, string entityDesc, string infoDesc, string responder, string augmentPoint)
    {
      Mean = mean;
      Entity = entity;
      EntityDescription = entityDesc;
      InformationDescription = infoDesc;
      Responder = responder;
      InformationAugmentationPoint = augmentPoint;
    }

    #endregion

    #region Public Fields
  
    /// <summary>
    /// Gets or sets the Contact Means
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ContactMean", Namespace = Constants.EmeventNamespace, Order = 1)]
    public string Mean { get; set; }

    /// <summary>
    /// Gets or sets the Contact Entity
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ContactEntity", Namespace = Constants.EmeventNamespace, Order = 2)]
    public string Entity { get; set; }

    /// <summary>
    /// Gets or sets the information about this contact Entity 
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ContactEntityDescriptionText", Namespace = Constants.EmeventNamespace, Order = 3)]
    public string EntityDescription { get; set; }

    /// <summary>
    /// Gets or sets the information about this contact information 
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ContactInformationDescriptionText", Namespace = Constants.EmeventNamespace, Order = 4)]
    public string InformationDescription { get; set; }

    /// <summary>
    /// Gets or sets the Contact Responder.  A contact responder is a 3rd party who would direct
    /// the call to the intended entity
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "ContactResponder", Namespace = Constants.EmeventNamespace, Order = 5)]
    public string Responder { get; set; }

    /// <summary>
    /// Gets or sets the Contact Information Augmentation Point
    /// Optional Element
    /// </summary>
    /// TODO: Get real type.  This is an abstract element 
    [XmlElement(ElementName = "ContactInformationAugmentationPoint", Namespace = Constants.EmeventNamespace, Order = 6)]
    public string InformationAugmentationPoint { get; set; }

    #endregion


  }
}
