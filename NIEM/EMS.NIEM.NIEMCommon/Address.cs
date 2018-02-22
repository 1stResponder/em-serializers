//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

namespace EMS.NIEM.NIEMCommon
{
  using Newtonsoft.Json;
  using System;
  using System.ComponentModel;
  using System.Xml;
  using System.Xml.Serialization;

  /// <summary>
  /// Street Address Description
  /// </summary>
  [JsonObject]
  [Serializable]
  public class Address
  {
    #region Constructor
    /// <summary>
    /// Initializes a new instance of the Address class
    /// All elements are optional
    /// </summary>
    public Address()
    {

    }

    /// <summary>
    /// Initializes a new instance of the Address class
    /// </summary>
    /// <remarks>
    /// If a state is provided without a country, the country is assumed to the United States
    /// </remarks>
    /// <param name="ls">The Associated Location Street Object</param>
    /// <param name="city">(Optional) The city</param>
    /// <param name="state">(Optional) The State</param>
    /// <param name="country">(Optional) The country</param>
    /// <param name="postCode">(Optional) The Postal Code</param>
    /// <see cref="Initialize(LocationStreet, string, USStateCodeList?, CountryCodeList?, string, string, int?, string)"/>
    public Address(LocationStreet ls, string city = null, USStateCodeList? state = null, CountryCodeList? country = null, string postCode = null)
    {
      Initialize(ls, city, state, country, postCode);
    }

    /// <summary>
    /// Initializes a new instance of the Address class
    /// </summary>
    /// <remarks>
    /// If a state is provided without a country, the country is assumed to the United States
    /// </remarks>
    /// <param name="city">The city</param>
    /// <param name="state">(Optional) The State</param>
    /// <param name="country">(Optional) The country</param>
    /// <param name="postCode">(Optional) The Postal Code</param>
    /// <see cref="Initialize(LocationStreet, string, USStateCodeList?, CountryCodeList?, string, string, int?, string)"/>
    public Address(string city, USStateCodeList? state = null, CountryCodeList? country = null, string postCode = null)
    {
      Initialize(null, city, state, country, postCode);
    }

    #endregion
    #region Public Fields

    /// <summary>
    /// Gets or sets the building name
    /// </summary>
    [XmlElement(ElementName = "AddressBuildingName", Namespace = Constants.NiemcoreNamespace)]
    public string AddressBuildingName
    {
      get; set;
    }


    /// <summary>
    /// Gets or sets the LocationStreet object
    /// </summary>
    [XmlElement(ElementName = "LocationStreet", Namespace = Constants.NiemcoreNamespace)]
    public LocationStreet LocationStreet
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Name of the city
    /// </summary>
    [XmlElement(ElementName = "LocationCityName", Namespace = Constants.NiemcoreNamespace)]
    public string LocationCityName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the county code
    /// </summary>
    [XmlElement(ElementName = "LocationCountyCode", Namespace = Constants.NiemcoreNamespace)]
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
    [XmlElement(ElementName = "LocationStateFIPS5-2AlphaCode", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("LocationStateFIPS5-2AlphaCode")]
    [DefaultValue(USStateCodeList.NONE)]
    public USStateCodeList LocationState
    {
      get; set;
    }

    /// <summary>
    /// If LocationState is null do not serialize it  
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeLocationState()
    {
      return (LocationState != USStateCodeList.NONE);
    }

    /// <summary>
    /// Gets or sets the Country Code
    /// </summary>
    [XmlElement(ElementName = "LocationCountryFIPS10-4Code", Namespace = Constants.NiemcoreNamespace)]
    [JsonProperty("LocationCountryFIPS10-4Code")]
    [DefaultValue(CountryCodeList.NONE)]
    public CountryCodeList LocationCountry
    {
      get; set;
    }

    /// <summary>
    /// If LocationCountry is null do not serialize it 
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeLocationCountry()
    {
      return (LocationCountry != CountryCodeList.NONE);
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
    #endregion

    #region Helper Methods
    /// <summary>
    ///  Initializes the Address object
    /// </summary>
    /// <remarks>
    /// If a state is provided without a country, the country is assumed to the United States
    /// </remarks>
    /// <param name="ls">The Associated Location Street Object</param>
    /// <param name="city">The City</param>
    /// <param name="state">The State</param>
    /// <param name="country">(Optional) The Country.</param>
    /// <param name="postCode">(Optional) The Postal Code</param>
    /// <param name="buildingName">(Optional) The name of the building</param>
    /// <param name="countyCode">(Optional) The County Code</param>
    /// <param name="postExt">(Optional) The Postal Code Extension</param>
    private void Initialize(LocationStreet ls, string city, USStateCodeList? state, CountryCodeList? country = null, string postCode = null, string buildingName = null, int? countyCode = null, string postExt = null)
    {
      if (ls != null) LocationStreet = ls;
      if (!string.IsNullOrWhiteSpace(city)) LocationCityName = city;
      if (state != null) LocationState = (USStateCodeList) state;
      if (country != null) LocationCountry = (CountryCodeList) country;
      if (!string.IsNullOrWhiteSpace(postCode)) LocationPostalCode = postCode;
      if (!string.IsNullOrWhiteSpace(buildingName)) AddressBuildingName = buildingName;
      if (countyCode != null) LocationCountyCode = countyCode;
      if (!string.IsNullOrWhiteSpace(postExt)) LocationPostalExtensionCode = postExt;

      if(state != null && country == null)
      {
        LocationCountry = CountryCodeList.US;
      }

    }

	/// <summary>
	/// Sets the street for this address
	/// </summary>
	/// <param name="ls"></param>
	public void SetStreet(LocationStreet ls)
	{
	  LocationStreet = ls;
	}

	/// <summary>
	/// Creates a street to set for the address
	/// </summary>
	/// <param name="streetNum">The Street number text</param>
	/// <param name="streetName">The Street name</param>
	/// <param name="streetCat">The Street category (i.e rd, ave, ln)</param>
	/// <param name="postdirection">(Optional) The post-direction text for this street</param>
	/// <param name="predirection">(Optional) The pre-direction text for this street</param>
	/// <param name="ext">(Optional) The extension text for this street</param>
	public void SetStreet(string streetNum, string streetName, string streetCat, string postdirection = null, string predirection = null, string ext = null)
	{
	  SetStreet(new LocationStreet(streetNum, streetName, streetCat, postdirection, predirection, ext));
	}

	/// <summary>
	/// Creates a street to set for the address
	/// </summary>
	/// <param name="streetName">The Street name</param>
	/// <param name="streetCat">The Street category (i.e rd, ave, ln)</param>
	public void SetStreet(string streetName, string streetCat)
	{
	  SetStreet(new LocationStreet(streetName, streetCat));
	}




	#endregion
	#region Override 
	/// <summary>
	/// To String Override to return address text
	/// </summary>
	/// <returns>address</returns>
	public override string ToString()
    {
      string temp = this.AddressBuildingName;
      temp += " " + this.LocationStreet.ToString();
      temp += " " + this.LocationCityName;
      temp += " " + this.LocationState.ToString();
      temp += " " + this.LocationPostalCode + (!string.IsNullOrWhiteSpace(this.LocationPostalExtensionCode) ? "-" + this.LocationPostalExtensionCode : "");
      temp.TrimStart();

      return temp;
    }
    #endregion
  }
}
