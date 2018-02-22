using System;
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
    /// Represents a piece of equipment 
    /// </summary>
    [JsonObject]
    public class Equipment: ResponseResourceKind
    {

		/// <summary>
		/// Initializes a new instance of the Equipment class
		/// </summary>
        public Equipment()
        {
            SerialID = new IdentificationID();
            estimatedArrival = new DateTime();
            ResourceKind = new ResourceKind();
            EstimatedAvailability = new DateTimeRange();
        }

        /// <summary>
        /// Initializes a new instance of the Equipment class
        /// </summary>
        /// <param name="id">Equipment ID as string</param>
        /// <param name="arrival">Estimated Arrival DateTime</param>
        public Equipment(string id, DateTime arrival)
        {
            ID = id;
            estimatedArrival = arrival.ToUniversalTime();
            ResourceKind = new ResourceKind();
            EstimatedAvailability = new DateTimeRange();
        }

        /// <summary>
        /// Initializes a new instance of the Equipment class
        /// </summary>
        /// <param name="id">Equipment ID as string</param>
        /// <param name="arrival">Estimated Arrival DateTime</param>
        /// <param name="res">Resource Type</param>
        /// <param name="estAvail">Estimated Availability, as a DateTime Range</param>
        public Equipment(string id, DateTime arrival, ResourceKind res, DateTimeRange estAvail)
        {
            ID = id;
            estimatedArrival = arrival.ToUniversalTime();
            ResourceKind = res;
            EstimatedAvailability = estAvail;
        }

        /// <summary>
        /// Gets or sets the Equipment ID
        /// </summary>
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
        /// Gets or sets the serialized Equipment ID
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.EmlcPrefix + "--ResourceIdentifier",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public IdentificationID SerialID { get; set; }

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
        /// Gets or sets the serialized Estimated Arrival Time in UTC as string
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
        /// Gets or sets the resource kind
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--AidRespondingResourceType",Required = Required.Always, Order = 3, NullValueHandling = NullValueHandling.Include)]
        public ResourceKind ResourceKind { get; set; }

        /// <summary>
        /// Gets or sets the Estimated Availability as a DateTimeRange 
        /// Required Element
        /// </summary>
        [JsonProperty(PropertyName =  Constants.MaidPrefix + "--EstimatedAvailabilityDateTimeRange",Required = Required.Always, Order = 4, NullValueHandling = NullValueHandling.Include)]
        public DateTimeRange EstimatedAvailability { get; set; }




    }
}
