using System;
using System.Collections.Generic;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using System.Collections;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace NIEMSharp.MutualAidRequest
{
    /// <summary>
    /// Represents a Requested Resource 
    /// </summary>
    [JsonObject]  
    public class RequestedResources
    {
  
		/// <summary>
		/// Initializes a new instance of the RequestedResources class
		/// </summary>    
        public RequestedResources() {}

        /// <summary>
        /// Initializes a new instance of the RequestedResources class with the given resource list
        /// </summary>
        /// <param name="res">List of ResourceKind Resources</param>
        public RequestedResources(IList res)
        {
            ResourceList = res;
        }      

        /// <summary>
        /// Initializes a new instance of the RequestedResources class and adds the given resource to resource list
        /// </summary>
        /// <param name="res">Generic Resource</param>
        public RequestedResources(GenericResource res)
        {
            ResourceList = new List<GenericResource>();
            ResourceList.Add(res);
        }    
        
        /// <summary>
        /// Initializes a new instance of the RequestedResources class and adds the given resource to resource list
        /// </summary>
        /// <param name="res">Specific Resource</param>
        public RequestedResources(SpecificResource res)
        {
            ResourceList = new List<SpecificResource>();
            ResourceList.Add(res);
        }  
        
        /// <summary>
        /// Initializes a new instance of the RequestedResources class and adds the given resource to resource list
        /// </summary>
        /// <param name="res">MissionNeed Resource</param>
        public RequestedResources(MissionNeed res)
        {
            ResourceList = new List<MissionNeed>();
            ResourceList.Add(res);
        }    



        // NOTE: The name of this member is hard coded in the JSON serialization/deserialization process.
        // Places to Update:
        // SubsitutePropertyNameContractResolver (class) 
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        private IList resource{ get; set; }
        
        /// <summary>
        /// Gets or sets the Request type
        /// Optional Element
        /// </summary>    
        [JsonIgnore]
        public IList ResourceList{ 
        
            get {

                return resource;
            } 
            
            set {
                
                // Making sure this is a valid list type
                Type ty = value.GetType().GenericTypeArguments[0];

                // Restricting to base class to prevent mixed list
                if(ty.GetTypeInfo().IsSubclassOf(typeof(RequestResourceKind)))
                {
                    resource = value;

                } else
                {
                    throw new InvalidOperationException("ResourceList must be a List of Generic, Specific, or MissionNeed Resources"); 
                }
                
            }           
        }
        
        /// <summary>
        /// If Resource list is null or empty then it will not be serialized 
        /// </summary>
        /// <returns>true or false</returns>
        public bool ShouldSerializeresource()
        {
            if(ResourceList == null)
            {
                return false;
            }
            return (ResourceList.Count > 0);
        }
    }       

    }

