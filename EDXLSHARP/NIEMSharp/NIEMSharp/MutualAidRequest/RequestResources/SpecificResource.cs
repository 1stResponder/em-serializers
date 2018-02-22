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
    /// Represents a specific resource
    /// </summary>
    [JsonObject]
    public class SpecificResource: RequestResourceKind
    {

		/// <summary>
		/// Initializes a new instance of the SpecificResource class
		/// </summary>
        public SpecificResource()
         {
            SerialResourceIdentifier = new IdentificationID(); 
         }

         /// <summary>
         /// Initializes a new instance of the SpecificResource class
         /// </summary>
         /// <param name="id">Resource ID as string</param>
         public SpecificResource(string id)
         {
            ResourceIdentifier = id;
         }

        /// <summary>
        /// Gets or sets the serial id for this resource
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmlcPrefix + "--ResourceIdentifier",Required = Required.Always, NullValueHandling = NullValueHandling.Include)]
        public IdentificationID SerialResourceIdentifier { get; set; }

        [JsonIgnore]
        public string ResourceIdentifier
        {
          get
          {
            return SerialResourceIdentifier != null ? SerialResourceIdentifier.ID : "";
          }
          set
          {
            if (this.SerialResourceIdentifier== null)
            {
              this.SerialResourceIdentifier = new IdentificationID(value);
            }
            else
            {
              this.SerialResourceIdentifier.ID = value;
            }
          }
        }

    }
}
 