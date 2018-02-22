#define PORTABLE
using System;
using NIEMSHARP.NIEMEMLCLib;
using NIEMSHARP.NIEMEMLCLib.CoreWarpper;
using Newtonsoft.Json;

namespace NIEMSharp.MutualAidRequest
{
    /// <summary>
    /// Represents the location extension for a mutual aid request
    /// </summary>
    /// [Namespace(Prefix = "wm", Uri = "http://schemas.datacontract.org/2004/07/System.Windows.Media")]  
    public class LocationExtension
    {

		/// <summary>
		/// Initializes a new instance of the LocationExtension class
		/// </summary>
        public LocationExtension(){ }

        /// <summary>
        /// Initializes a new instance of the LocationExtension class
        /// </summary>
        /// <param name="ad">Address</param>
        public LocationExtension(Address ad)
        { 
            Address = ad;
        }

        /// <summary>
        /// Initializes a new instance of the LocationExtension class
        /// </summary>
        /// <param name="ac">Address Cross Street</param>
        public LocationExtension(AddressCrossStreet ac)
        { 
            AddressCrossStreet = ac;
        }

        /// <summary>
        /// Initializes a new instance of the LocationExtension class
        /// </summary>
        /// <param name="ad">Address</param>
        /// <param name="ac">Address Cross Street</param>
        public LocationExtension(Address ad, AddressCrossStreet ac)
        { 
            Address = ad;
            AddressCrossStreet = ac;
        }


        /// <summary>
        /// Initializes a new instance of the LocationExtension class
        /// </summary>
        /// <param name="ad">Address object</param>
        /// <param name="cross">AddressCrossStreet Object</param>
        /// <param name="grid">AddressGrid</param>
        /// <param name="mgrs">MGRS Coordinate</param>
        /// <param name="utm">UTM Coordinate</param>
        /// <param name="ar">Area Region</param>
        /// <param name="intersect">Intersection Boolean</param>
        public LocationExtension(Address ad, AddressCrossStreet cross, AddressGrid grid, MGRSCoordinate mgrs, UTMCoordinate utm, 
            AreaRegion ar, bool intersect)
        {
            this.Address = ad;
            this.AddressCrossStreet = cross;
            this.AreaRegion = ar; 
            this.MGRSCoordinate = mgrs;
            this.UTMCoordinate = utm;
            AddressGrid = grid;
        }

        /// <summary>
        /// Gets or sets the address object
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.NiemcorePrefix + "--Address", NullValueHandling=NullValueHandling.Ignore, Order = 1)]    
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the cross street 
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.NiemcorePrefix + "--AddressCrossStreet", NullValueHandling=NullValueHandling.Ignore, Order = 2)]   
        public AddressCrossStreet AddressCrossStreet { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this location represents an intersection
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.EmlcPrefix+ "--AddressIntersectionIndicator",DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling=NullValueHandling.Ignore, Order = 7)]   
        public bool AddressIntersectionIndicator { get; set;}
        

        /// <summary>
        /// Gets or sets the MGRS Coordinate 
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.NiemcorePrefix + "--MGRSCoordinate", NullValueHandling=NullValueHandling.Ignore, Order = 4)]   
        public MGRSCoordinate MGRSCoordinate { get; set;}

        
        /// <summary>
        /// Gets or sets the UTM Coordinate 
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.NiemcorePrefix + "--UTMCoordinate", NullValueHandling=NullValueHandling.Ignore, Order = 5)]   
        public UTMCoordinate UTMCoordinate { get; set;}

        /// <summary>
        /// Gets or sets the Address Grid
        /// Optional Element
        /// </summary>
        [JsonProperty(PropertyName = Constants.NiemcorePrefix + "--AddressGrid", NullValueHandling=NullValueHandling.Ignore, Order = 3)]   
        public AddressGrid AddressGrid { get; set;}             
        
        // NOTE: The name of this member is hard coded in the JSON serialization/deserialization process.
        // Places to Update:
        // SubsitutePropertyNameContractResolver (class) 
        private dynamic areaRegion { get; set; }

        /// <summary>
        /// Gets or sets the area or region 
        /// Optional Element
        /// Abstract Type
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore, Order = 6)] /// Defined in ShouldSerializeContractResolver
        public dynamic AreaRegion 
        { 
            get 
            { 
                return areaRegion;
            } 
            set 
            {
                if(value is AreaRegion)
                {
                    areaRegion = value;

                } else
                {
                    throw new ArgumentException("value","AreaRegion must be an AreaRegion derived type");
                }
            } 
        }


    }



    
}
