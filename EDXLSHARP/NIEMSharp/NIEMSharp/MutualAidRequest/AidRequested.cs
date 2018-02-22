using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRequest
{
    // NOTE: The name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updates as well.   
    // Places to Update:
    //      SubsitutePropertyNameContractResolver (class)
    //      deserialMAConvert (class)
    //      NIEMUtil.formatXML

    /// <summary>
    /// Represents a mutual aid request
    /// </summary>
    [JsonObject]  
    public class AidRequested: MutualAidMessage
    {

        /// <summary>
        /// Initializes a new instance of the AidRequested class
        /// </summary>
        public AidRequested()
        {
            Resource = new RequestedResources();
        }

        /// <summary>
        /// Initializes a new instance of the AidRequested class
        /// </summary>
        /// <param name="res">Requested Resource</param>
        /// <param name="loc">Location Extension (optional)</param>
        public AidRequested(RequestedResources res, LocationExtension loc = null)
        {
            bool hasLocation = loc != null;

            Resource = res;

            if (hasLocation)
            {
                location = loc;
            } 
        }

        // NOTE: The name of this member is hard coded in the JSON deserialization process.
            // Places to Update:
            // NIEMUtil.formatXML
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--AidRequestedResources", Order = 1, Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        private RequestedResources resource { get; set;}

        /// <summary>
        /// Gets or sets the requested resource
        /// Required Element
        /// </summary>
        [JsonIgnore]
        public RequestedResources Resource
        {
            get
            {
                return resource;
            }

            set
            {
                resource = value;
            }
        }

        // NOTE: The JSON name of this member is hard coded in the JSON deserialization process.
        // Places to Update:
        // NIEMUtil.formatXML

        /// <summary>
        /// Gets or sets the request location
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--AidRequestedLocationExtension", NullValueHandling=NullValueHandling.Ignore, Order = 2)]
        public LocationExtension location { get; set; }

    }
}
