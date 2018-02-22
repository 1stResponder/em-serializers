using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using NIEMSharp.MutualAidRespond.ResponseResources;
using System.Reflection;

namespace NIEMSharp.MutualAidRespond
{
    /// <summary>
    /// Represents the responding resources 
    /// </summary>
    [JsonObject]
    public class RespondingResource
    {

        /// <summary>
        /// Initializes a new instance of the RespondingResource class
        /// </summary>
        public RespondingResource(){}

        /// <summary>
        /// Initializes a new instance of the RespondingResource class
        /// </summary>
        /// <param name="res">List of Responding Person(s) or Equipment</param>
        public RespondingResource(IList res)
        {
            ResourceList = res;
        }

        /// <summary>
        /// Initializes a new instance of the RespondingResource class and adds the given resource to resource list
        /// </summary>
        /// <param name="res">Person</param>
        public RespondingResource(Person res)
        {
            ResourceList = new List<Person>();
            ResourceList.Add(res);
        }

        /// <summary>
        /// Initializes a new instance of the RespondingResource class and adds the given resource to resource list
        /// </summary>
        /// <param name="res">Equipment</param>
        public RespondingResource(Equipment res)
        {
            ResourceList = new List<Equipment>();
            ResourceList.Add(res);
        }


        // NOTE: The name of this member is hard coded in the JSON serialization/deserialization process.
        // Places to Update:
        // SubsitutePropertyNameContractResolver (class) 
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        private IList resource{ get; set; }
        
        /// <summary>
        /// Gets or sets the Resource type (Person or equipment)
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
                if(ty.GetTypeInfo().IsSubclassOf(typeof(ResponseResourceKind)))
                {
                    resource = value;

                } else
                {
                    throw new InvalidOperationException("ResourceList must be a List of Person(s) or Equipment"); 
                }
            }           
        }

        /// <summary>
        /// If Resource list is null or empty then it will not be serialized 
        /// </summary>
        /// <returns>true or false</returns>
        public bool ShouldSerializeResourceList()
        {
            if(ResourceList == null)
            {
                return false;
            }
            return (ResourceList.Count > 0);
        }
        
    }
}
