//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

namespace NIEMSHARP.NIEMEMLCLib
{
  using Newtonsoft.Json;
  using System.Xml;
  using System.Xml.Serialization;
  using System.Runtime.Serialization;

  /// <summary>
  /// Street Address Description
  /// </summary>
  [JsonObject]
  public class Address
  {
    /// <summary>
    /// Initializes a new instance of the Address class
    /// </summary>
    public Address()
    {
    }

    /// <summary>
    /// Initializes a new instance of the Address class
    /// </summary>
    /// <param name="ls">Location Street of the address</param>
    public Address(LocationStreet ls)
    {
        LocationStreet = ls;
    }

    /// <summary>
    /// Gets or sets the Street location
    /// </summary>
    [XmlElement(ElementName = "LocationStreet")]
    public LocationStreet LocationStreet
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the building name of the address
    /// </summary>
    public string AddressBuildingName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Name of the city
    /// </summary>
    /// 
    [XmlElement(ElementName = "LocationCityName")]
    public string LocationCityName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Code for the county
    /// </summary>
    public int LocationCountyCode
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the State code for the US
    /// </summary>
    [XmlElement(ElementName = "LocationStateFIPS5-2AlphaCode")]
    [JsonProperty("LocationStateFIPS5-2AlphaCode")]
    public USStateCodeList LocationState
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Country Code
    /// </summary>
    [XmlElement(ElementName = "LocationCountryFIPS10-4Code")]
    [JsonProperty("LocationCountryFIPS10-4Code")]
    public CountryCodeList LocationCountry
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Zip Code
    /// </summary>
    public string LocationPostalCode
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Zip extension code
    /// </summary>
    public string LocationPostalExtensionCode
    {
      get; set;
    }
  }
}
