using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRespond
{
    /// <summary>
    /// Represents rank of person
    /// </summary>
    [JsonObject]
     public class Rank
    {

		/// <summary>
		/// Initializes a new instance of the Rank class
		/// </summary>        
        public Rank() { 
            ValueText = "";
        }

        /// <summary>
        /// Initializes a new instance of the Rank class
        /// </summary>
        /// <param name="vt">Value Text</param>
        public Rank(string vt) 
        {
            ValueText = vt;
        }

        /// <summary>
        /// Initializes a new instance of the Rank class
        /// </summary>
        /// <param name="vt">Value Text</param>
        /// <param name="vListUrn">Value List URN Text</param>
        /// <param name="vAugmenPoint">Value Augmentation Point</param>
        public Rank(string vt, string vListUrn, string vAugmenPoint) 
        {
            ValueText = vt;
            ValueListURNText = vListUrn;
            ValueAugmentationPoint = ValueAugmentationPoint;
        }


        /// <summary>
        /// Gets or sets the value text
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.EmeventPrefix + "--ValueText",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public string ValueText { get; set; }

        /// <summary>
        /// Gets or sets the value list URN text
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.EmeventPrefix + "--ValueListURNText", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueListURNText { get; set; }

        /// <summary>
        /// Gets or sets the Augmentation Point
        /// Optional Element
        /// </summary>
        // TODO: Get real type.  This is an abstract element 
        [JsonProperty(PropertyName =  Constants.EmeventPrefix + "--ValueAugmentationPoint", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueAugmentationPoint  { get; set; }

    }
}
