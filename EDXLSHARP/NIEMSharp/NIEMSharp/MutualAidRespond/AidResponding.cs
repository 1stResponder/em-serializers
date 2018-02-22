using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRespond
{
    // NOTE: The name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updates as well.   
    // Places to Update:
    //      SubsitutePropertyNameContractResolver (class)
    //      deserialMAConvert (class)

    /// <summary>
    /// Represents a mutual aid response
    /// </summary>
     [JsonObject]
     public class AidResponding: MutualAidMessage
    {

		/// <summary>
		/// Initializes a new instance of the AidResponding class
		/// </summary>
        public AidResponding()
        {
            Resources = new RespondingResource();
            ContactInformation = new ContactInformation();
        }

        /// <summary>
        /// Initializes a new instance of the AidResponding class 
        /// </summary>
        /// <param name="ap">Approved Status</param>
        public AidResponding(bool ap)
        {
            Approved = ap;
            Resources = new RespondingResource();
            ContactInformation = new ContactInformation();
        }

        /// <summary>
        /// Initializes a new instance of the AidResponding class 
        /// </summary>
        /// <param name="ap">Approved Status</param>
        /// <param name="r">Responding Resource object</param>
        /// <param name="ci">Contact Information</param>
        public AidResponding(bool ap, RespondingResource r, ContactInformation ci)
        {
            Approved = ap;
            Resources = r;
            ContactInformation = ci;
        }


        /// <summary>
        /// Gets or sets Approved Status
        /// Required Element
        /// </summary>   
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--Approved",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public bool Approved { get; set; }

        // NOTE: The name of this member is hard coded in the JSON deserialization process.
        // Places to Update:
        // NIEMUtil.formatXML

        /// <summary>
        /// Gets or sets the resource
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--AidRespondingResources",Required = Required.Always, Order = 2, NullValueHandling = NullValueHandling.Include)]
        public RespondingResource Resources { get; set; }


        // NOTE: The name of this member is hard coded in the JSON deserialization process.
        // Places to Update:
        // NIEMUtil.formatXML

        /// <summary>
        /// Gets or sets the contact information
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--AidRespondingContactInformation",Required = Required.Always, Order = 3, NullValueHandling = NullValueHandling.Include)]
         public ContactInformation ContactInformation { get; set; }


    }
}
