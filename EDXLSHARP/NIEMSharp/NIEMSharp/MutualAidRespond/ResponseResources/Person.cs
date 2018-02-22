using System;
using System.Collections.Generic;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using NIEMSharp.MutualAidRespond.ResponseResources;

namespace NIEMSharp.MutualAidRespond
{
    // NOTE: The name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updates as well.   
    // Places to Update:
    //      SubsitutePropertyNameContractResolver (class)
    //      deserialRespondingResourceConvert (class)
    //      NIEMUtil.formatXML

    /// <summary>
    /// Represents a responding person
    /// </summary>
    [JsonObject]
    public class Person: ResponseResourceKind
    {

		/// <summary>
		/// Initializes a new instance of the Person class
		/// </summary>
        public Person()
        {
            SerialID = new IdentificationID();
            estimatedArrival = new DateTime();
            EstimatedAvailability = new DateTimeRange();
        }

        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="id">Person Human Resource ID as string</param>
        /// <param name="eta">Estimated date/time of arrival</param>
        public Person(string id, DateTime eta)
        {
            ID = id;
            estimatedArrival = eta;
            EstimatedAvailability = new DateTimeRange();
        }

        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="id">Person Human Resource ID as string</param>
        /// <param name="eta">Estimated date/time of arrival</param>
        /// <param name="etaRange">Estimated date/time availability as DateTime range</param>
        public Person(string id, DateTime eta, DateTimeRange etaRange)
        {
            ID = id;
            estimatedArrival = eta;
            EstimatedAvailability = etaRange;
        }

        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="id">Person Human Resource ID as string</param>
        /// <param name="eta">Estimated date/time of arrival</param>
        /// <param name="etaRange">Estimated date/time availability as DateTime range</param>
        /// <param name="ra">Rank of person</param>
        /// <param name="cr">List of credentials</param>
        public Person(string id, DateTime eta, DateTimeRange etaRange, Rank ra, List<Credential> cr)
        {
            ID = id;
            estimatedArrival = eta;
            Credentials = cr;
            Rank = ra;
            EstimatedAvailability = etaRange;
        }    

        /// <summary>
        /// Gets or sets the serialized Person's ID
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.NiemcorePrefix + "--PersonHumanResourceIdentification",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
         public IdentificationID SerialID { get; set; }

        [JsonIgnore]
        public string ID
        {
          get
          {
            return SerialID != null ? SerialID.ID : "";
          }
          set
          {
            if (this.SerialID == null)
            {
              this.SerialID = new IdentificationID(value);
            }
            else
            {
              this.SerialID.ID = value;
            }
          }
        }


        /// <summary>
        /// Gets or sets the Estimated Arrival Time in UTC
        /// </summary>
        [JsonIgnore]
        private DateTime estimatedArrival;

        [JsonIgnore]
        public DateTime EstimatedArrival { 
            get
            {
                return estimatedArrival.ToUniversalTime();
            } 
            set 
            {
                estimatedArrival = value.ToUniversalTime();
            } 
        }

        /// <summary>
        /// Gets or sets the serialized Estimated Arrival Time in UTC as a string
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--EstimatedArrivalDateTime",Required = Required.Always, Order = 2, NullValueHandling = NullValueHandling.Include)]
        public string SerialEstimatedArrival
        {
          get
          {
               NIEMDateTime t = new NIEMDateTime(this.EstimatedArrival);
               return t.DateTime.ToUniversalTime().ToString("o");
          }

          set
          {
            this.EstimatedArrival = Convert.ToDateTime(value);
          }
        }

        /// <summary>
        /// Gets or sets the Person's Rank
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--AidRespondingRank", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public Rank Rank { get; set; }


        // NOTE: The name of this member is hard coded in the JSON deserialization process.
        // Places to Update:
        // NIEMUtil.formatXML

        /// <summary>
        /// Gets or sets the list of Credentials
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--AidRespondingCredential", Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public List<Credential> Credentials { get; set; }

        /// <summary>
        /// Gets or sets the Estimated Availability as a DateTimeRange 
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--EstimatedAvailabilityDateTimeRange",Required = Required.Always, Order = 5, NullValueHandling = NullValueHandling.Include)]
        public DateTimeRange EstimatedAvailability { get; set; }

        /// <summary>
        /// If Credentials list is empty then it will not be serialized 
        /// </summary>
        /// <returns>true or false</returns>
        public bool ShouldSerializeCredentials()
        {
            if(Credentials == null)
            {
                return false;
            }
            return Credentials.Count > 0;
        }
        
    }
}
