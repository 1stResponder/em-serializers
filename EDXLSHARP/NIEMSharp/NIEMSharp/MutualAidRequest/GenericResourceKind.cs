using System;
using NIEMSHARP.NIEMEMLCLib;
using NIEMSHARP.NIEMEMLCLib.Resource;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NIEMSharp
{
    /// <summary>
    /// Represents a resource type
    /// </summary>
    [JsonObject]
    public class GenericResourceKind
    {

		/// <summary>
		/// Initializes a new instance of the GenericResourceKind class
		/// </summary>
        public GenericResourceKind()
        {
            ResourceTypeDescriptor = new List<string>();   
        }

        /// <summary>
        /// Initializes a new instance of the GenericResourceKind class
        /// </summary>
        /// <param name="typeCode">Resource Type Code</param>
        public GenericResourceKind(EventTypeCodeList typeCode)
        {
            ResourceTypeCodeValue = typeCode;
            ResourceTypeDescriptor = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the GenericResourceKind class
        /// </summary>
        /// <param name="typeCode">Resource Type Code as string</param>
        public GenericResourceKind(string typeCode)
        {
            SerialResourceTypeCode= typeCode;
            ResourceTypeDescriptor = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the GenericResourceKind class
        /// </summary>
        /// <param name="typeCode">Resource Type Code</param>
        /// <param name="description">List of Resource Type Descriptions</param>
        /// <param name="def">Resource NIMS definition (optional)</param>
        public GenericResourceKind(EventTypeCodeList typeCode, List<string> description, ResourceNIMSDefinition def = null)
        {
            bool hasNIMS = def != null;

            ResourceTypeCodeValue = typeCode;
            ResourceTypeDescriptor = description;

            if (hasNIMS)
            {
                ResourceNIMSDefinition = def;
            }
        }

        /// <summary>
        /// Initializes a new instance of the GenericResourceKind class
        /// </summary>
        /// <param name="typeCode">Resource Type Code as string</param>
        /// <param name="description">List of Resource Type Descriptions</param>
        /// <param name="def">Resource NIMS definition (optional)</param>
        public GenericResourceKind(string typeCode, List<string> description, ResourceNIMSDefinition def = null)
        {
            bool hasNIMS = def != null;

            SerialResourceTypeCode = typeCode;
            ResourceTypeDescriptor = description;

            if (hasNIMS)
            {
                ResourceNIMSDefinition = def;
            }
        }

        /// <summary>
        /// Gets or sets the Resource's Type Code Value
        /// Required Element
        /// </summary>
        [JsonIgnore]
        public EventTypeCodeList ResourceTypeCodeValue { get; set;}
    

        /// <summary>
        /// Gets or sets the Resource's Event Type Code as/from string
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.MaidPrefix + "--ResourceTypeCode",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public string SerialResourceTypeCode{
          get
          {
            return ResourceTypeCodeValue.ToString().Replace('_', '.');
          }

          set
          {
            ResourceTypeCodeValue  = (EventTypeCodeList)Enum.Parse(typeof(EventTypeCodeList), value.Replace('.', '_'));
          }
        }


        // NOTE: The name of this member is hard coded in the JSON deserialization process.
        // Places to Update:
        // NIEMUtil.formatXML

        /// <summary>
        /// Gets or sets the description
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--ResourceTypeDescriptorExtension", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public List<String> ResourceTypeDescriptor { get; set;}

        /// <summary>
        /// Gets or sets the NIMS Definition
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.EmlcPrefix + "--ResourceNIMSDefinition", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public ResourceNIMSDefinition ResourceNIMSDefinition { get; set;}

        /// <summary>
        /// If ResourceTypeDescription list is null or empty then it will not be serialized 
        /// </summary>
        /// <returns>true or false</returns>
        public bool ShouldSerializeResourceTypeDescriptor()
        {
            if(ResourceTypeDescriptor == null)
            {
                return false;
            }
            return ResourceTypeDescriptor .Count > 0;
        }
    }

}
