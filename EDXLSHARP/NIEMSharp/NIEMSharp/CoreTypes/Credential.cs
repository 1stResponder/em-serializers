using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using System.ComponentModel;

namespace NIEMSharp.MutualAidRespond
{
    /// <summary>
    /// Represents a credential for a person
    /// </summary>
    [JsonObject]
     public class Credential
    {

		/// <summary>
		/// Initializes a new instance of the Credential class
		/// </summary>
        public Credential() {  
            ValueText = "";
         }

        /// <summary>
        /// Initializes a new instance of the Credential class
        /// </summary>
        /// <param name="vt">Value Text</param>
        public Credential(string vt) 
        {
            ValueText = vt;
        }

        /// <summary>
        /// Initializes a new instance of the Credential class
        /// </summary>
        /// <param name="vt">Value Text</param>
        /// <param name="vListUrn">Value List URN Text</param>
        /// <param name="vAugmenPoint">Value Augmentation Point</param>
        public Credential(string vt, string vListUrn, string vAugmenPoint) 
        {
            ValueText = vt;
            ValueListURNText = vListUrn;
            ValueAugmentationPoint = ValueAugmentationPoint;
        }

        /// <summary>
        /// Gets or sets the value text
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ValueText", Order = 1, NullValueHandling = NullValueHandling.Include, Required = Required.Always)]       
        public string ValueText { get; set; }

        /// <summary>
        /// Gets or sets the value list URN text
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ValueListURNText", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueListURNText { get; set; }

        /// <summary>
        /// Gets or sets the Augmentation Point
        /// Optional Element
        /// </summary>
        // TODO: Get real type.  This is an abstract element 
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ValueAugmentationPoint", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueAugmentationPoint  { get; set; }
    }
}
