//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

namespace EDXLSharp.NIEMEMLCLib
{
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.Xml;
    using System.Xml.Serialization;

  /// <summary>
  /// Street Address Description
  /// </summary>
  [JsonObject]
  public class Address
  {
    /// <summary>
    /// Initializes a new instance of the Address class
    /// All elements are optional
    /// </summary>
    public Address()
    {

    }

    /// <summary>
    /// Gets or sets the building name
    /// </summary>
    [XmlElement(ElementName = "AddressBuildingName", Namespace=Constants.NiemcoreNamespace)]
    public string AddressBuildingName
    {
      get; set;
    }


    /// <summary>
    /// Gets or sets the LocationStreet object
    /// </summary>
    [XmlElement(ElementName = "LocationStreet", Namespace=Constants.NiemcoreNamespace)]
    public LocationStreet LocationStreet
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Name of the city
    /// </summary>
    [XmlElement(ElementName = "LocationCityName", Namespace=Constants.NiemcoreNamespace)]
    public string LocationCityName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the county code
    /// </summary>
    [XmlElement(ElementName = "LocationCounty", Namespace = Constants.NiemcoreNamespace)]
    [DefaultValue(null)]
    public int? LocationCountyCode
    {
      get; set;
    }

    /// <summary>
    /// If LocationCountyCode is null do not serialize it 
    /// </summary>
    /// <returns></returns>
	public bool ShouldSerializeLocationCountyCode()
	{
	    return (LocationCountyCode != null);
	}

    /// <summary>
    /// Gets or sets the State code for the US
    /// </summary>
    [XmlElement(ElementName = "LocationStateFIPS5-2AlphaCode", Namespace=Constants.NiemcoreNamespace)]
    [JsonProperty("LocationStateFIPS5-2AlphaCode")]
    [DefaultValue(null)]
    public USStateCodeList? LocationState
    {
      get; set;
    }

    /// <summary>
    /// If LocationState is null do not serialize it  
    /// </summary>
    /// <returns></returns>
	public bool ShouldSerializeLocationState()
	{
	    return (LocationState != null);
	}

    /// <summary>
    /// Gets or sets the Country Code
    /// </summary>
    [XmlElement(ElementName = "LocationCountryFIPS10-4Code", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("LocationCountryFIPS10-4Code")]
    [DefaultValue(null)]
    public CountryCodeList? LocationCountry
    {
      get; set;
    }

    /// <summary>
    /// If LocationCountry is null do not serialize it 
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeLocationCountry()
    {
        return (LocationCountry != null);
    }


    /// <summary>
    /// Gets or sets the Zip Code
    /// </summary>
    [XmlElement(ElementName = "LocationPostalCode", Namespace = Constants.NiemcoreNamespace)]
    public string LocationPostalCode
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Zip extension code
    /// </summary>
    [XmlElement(ElementName = "LocationPostalExtensionCode", Namespace = Constants.NiemcoreNamespace)]
    public string LocationPostalExtensionCode
    {
      get; set;
    }
  }
}
