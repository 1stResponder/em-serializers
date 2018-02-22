using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRespond
{
    /// <summary>
    /// Holds the contact information for a response
    /// </summary>
    [JsonObject]
     public class ContactInformation
    {

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

        // TODO: Flesh this out once schema is updated (niemcore defines this as an abstract element while our schema as text)   
        /// <summary>
        /// Gets or sets the Contact Means
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ContactMean", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string Mean { get; set; }

        /// <summary>
        /// Gets or sets the Contact Entity
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ContactEntity", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets the information about this contact Entity 
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ContactEntityDescriptionText", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string EntityDescription { get; set; }

        /// <summary>
        /// Gets or sets the information about this contact information 
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix+ "--ContactInformationDescriptionText", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public string InformationDescription { get; set; }

        /// <summary>
        /// Gets or sets the Contact Responder.  A contact responder is a 3rd party who would direct
        /// the call to the intended entity
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ContactResponder", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
        public string Responder { get; set; }

        /// <summary>
        /// Gets or sets the Contact Information Augmentation Point
        /// Optional Element
        /// </summary>
        /// TODO: Get real type.  This is an abstract element 
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ContactInformationAugmentationPoint", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
        public string InformationAugmentationPoint { get; set; }


    }
}
