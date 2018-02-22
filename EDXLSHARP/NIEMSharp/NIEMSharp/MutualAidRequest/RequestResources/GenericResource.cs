using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRequest
{
    // NOTE: The name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updates as well.   
    // Places to Update:
    //      SubsitutePropertyNameContractResolver (class)
    //      deserialRequestedResourceConvert (class)
    //      NIEMUtil.formatXML

    /// <summary>
    /// Represents a generic resource
    /// </summary>
    [JsonObject]  
    public class GenericResource: RequestResourceKind
    {

		/// <summary>
		/// Initializes a new instance of the GenericResource class
		/// </summary>        
        public GenericResource()
        {
            ResourceKind = new GenericResourceKind();
        }

        /// <summary>
        /// Initializes a new instance of the GenericResource class
        /// </summary>
        /// <param name="qu">Quantity</param>
        /// <param name="res">Resource (optional)</param>
        public GenericResource(int qu, GenericResourceKind res = null)
        {
            bool hasResourceType = res != null;

            Quantity = qu;

            if (hasResourceType)
            {
                ResourceKind = res;
            }
        }

        /// <summary>
        /// Gets or sets the quantity for this resource
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
        /// Gets or sets the resource type
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--AidRequestedGenericResourceKind",Required = Required.Always, Order = 2, NullValueHandling = NullValueHandling.Include)]
        public GenericResourceKind ResourceKind { get; set; }


       
    }
}
