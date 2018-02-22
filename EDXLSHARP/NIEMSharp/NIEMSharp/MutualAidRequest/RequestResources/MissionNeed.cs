using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using System.ComponentModel;

namespace NIEMSharp.MutualAidRequest
{
    // NOTE: The name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updates as well.   
    // Places to Update:
    //      SubsitutePropertyNameContractResolver (class)
    //      deserialRequestedResourceConvert (class)
    //      NIEMUtil.formatXML


    /// <summary>
    /// Represents a mission need resource
    /// </summary>
    [JsonObject]  
    public class MissionNeed: RequestResourceKind
    {

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
        public MissionNeed(int qu, string vt)
        {
            Quantity = qu;
            ValueText = vt;
        }

        /// <summary>
        /// Initializes a new instance of the MissionNeed class
        /// </summary>
        /// <param name="qu">Quantity</param>
        /// <param name="vt">Value Text</param>
        /// <param name="vListUrn">Value List URN Text</param>
        /// <param name="augmen">Value Augmentation Point</param>
        public MissionNeed(int qu, string vt, string vListUrn, string augmen)
        {
            Quantity = qu;
            ValueText = vt;
            ValueListURNText = vListUrn;
            ValueAugmentationPoint = augmen;
        }


        /// <summary>
        /// Gets or sets the quantity
        /// Must be a positive value
        /// Required Element
        /// </summary>
        [JsonIgnore()]
        private int quantity;
       
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--Quantity",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public int Quantity
        {
            get {
                return quantity;
            }

            set {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Quantity must be positive value.");
                }
                
                quantity = value;
            }
            
        }

        /// <summary>
        /// Gets or sets the value text
        /// Required Element
        /// </summary>       
        [JsonProperty(PropertyName = Constants.EmeventPrefix + "--ValueText",Required = Required.Always, Order = 2, NullValueHandling = NullValueHandling.Include)]
        public string ValueText { get; set; }

        /// <summary>
        /// Gets or sets the value list URN text
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.EmeventPrefix + "--ValueListURNText", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueListURNText { get; set; }


        /// <summary>
        /// Gets or sets the Augmentation Point for ValueType
        /// Optional Element
        /// </summary>
        // TODO: Get real type.  This is an abstract element 
        [JsonProperty(PropertyName =  Constants.EmeventPrefix + "--ValueAugmentationPoint", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
         public string ValueAugmentationPoint  { get; set; }

        
    }
}
