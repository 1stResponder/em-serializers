using System;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRespond
{
    /// <summary>
    /// Represents a DateTime Range
    /// </summary>
    [JsonObject]
    public class DateTimeRange
    {     

		/// <summary>
		/// Initializes a new instance of the DateTimeRange class
		/// </summary>
        public DateTimeRange()
        {
            StartDate = new DateTime();
            EndDate = new DateTime();
        }

        /// <summary>
        /// Initializes a new instance of the DateTimeRange class
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">end date</param>
        public DateTimeRange(DateTime start, DateTime end)
        {
            StartDate = start.ToUniversalTime();
            EndDate = end.ToUniversalTime();
        }

        /// <summary>
        /// Gets or sets the Start DateTime in UTC
        /// Required Element
        /// </summary>
        [JsonIgnore]
        private DateTime startDate;
        
        [JsonIgnore]
        public DateTime StartDate { 
            get
            {
                return startDate.ToUniversalTime();
            } 
            set 
            {
                startDate = value.ToUniversalTime();
            } 
        }

        /// <summary>
        /// Gets or sets the End DateTime in UTC
        /// Required Element
        /// </summary>
        [JsonIgnore]       
        private DateTime endDate;

        [JsonIgnore]  
        public DateTime EndDate { 
            get
            {
                return endDate.ToUniversalTime();
            } 
            set 
            {
                endDate = value.ToUniversalTime();
            } 
        }

        /// <summary>
        /// Gets or Sets End Date as string 
        /// </summary>
        [JsonProperty(PropertyName =  Constants.NiemcorePrefix + "--EndDate",Required = Required.Always, Order = 1, NullValueHandling = NullValueHandling.Include)]
        public string SerialEndDate
        {
          get
          {
               NIEMDateTime t = new NIEMDateTime(this.EndDate);
               return t.DateTime.ToUniversalTime().ToString("o");
          }

          set
          {
                this.EndDate = Convert.ToDateTime(value);
          }
        }

        /// <summary>
        /// Gets or Sets Start Date as string 
        /// </summary>
        [JsonProperty(PropertyName =  Constants.NiemcorePrefix + "--StartDate",Required = Required.Always, Order = 2, NullValueHandling = NullValueHandling.Include)]
        public string SerialStartDate
        {
          get
          {
            NIEMDateTime t = new NIEMDateTime(this.StartDate);
            return t.DateTime.ToUniversalTime().ToString("o");

          }

          set
          {
            this.StartDate = Convert.ToDateTime(value);
          }
        }
        


    }
}
