#define PORTABLE
using System;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents the location extension for a mutual aid request
  /// </summary>
  [Serializable]
  public class LocationExtension
  {
    #region Constructor

    /// <summary>
    /// Initializes a new instance of the LocationExtension class
    /// </summary>
    public LocationExtension() { }

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
    /// <param name="ls">The Location Street for the address</param>
    public LocationExtension(LocationStreet ls)
    {
        Address = new Address(ls);
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

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets or sets the area or region 
    /// Optional Element
    /// Abstract Type
    /// </summary>
    [XmlElement("WGS84LocationEllipse", Type = typeof(LocationEllipse), Namespace = Constants.MoNamespace, Order = 6)]
    [XmlElement("WGS84LocationExternalPolygon", typeof(LocationExternalPolygon), Namespace = Constants.MoNamespace, Order = 6)]
    [XmlElement("WGS84LocationLineString", typeof(LocationLineString), Namespace = Constants.MoNamespace, Order = 6)]
    public dynamic AreaRegion
    {
      get
      {
        return areaRegion;
      }
      set
      {
        if (value is AreaRegion)
        {
          areaRegion = value;

        }
        else
        {
          throw new ArgumentException("value", "AreaRegion must be an AreaRegion derived type");
        }
      }
    }

    /// <summary>
    /// Gets or sets the address object
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "Address", Namespace = Constants.EmeventNamespace, Order = 1)]
    public Address Address { get; set; }

    /// <summary>
    /// Gets or sets the cross street 
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "AddressCrossStreet", Namespace = Constants.NiemcoreNamespace, Order = 2)]
    public AddressCrossStreet AddressCrossStreet { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this location represents an intersection
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "AddressIntersectionIndicator", Namespace = Constants.EmlcNamespace, Order = 7)]
    public bool? AddressIntersectionIndicator { get; set; }

    /// <summary>
    /// Gets or sets the MGRS Coordinate 
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "MGRSCoordinate", Namespace = Constants.NiemcoreNamespace, Order = 4)]
    public MGRSCoordinate MGRSCoordinate { get; set; }

    /// <summary>
    /// Gets or sets the UTM Coordinate 
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "UTMCoordinate", Namespace = Constants.NiemcoreNamespace, Order = 5)]
    public UTMCoordinate UTMCoordinate { get; set; }

    /// <summary>
    /// Gets or sets the Address Grid
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "AddressGrid", Namespace = Constants.NiemcoreNamespace, Order = 3)]
    public AddressGrid AddressGrid { get; set; }

    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the area or region 
    /// Optional Element
    /// Abstract Type
    /// </summary>
    [XmlIgnore]
    private dynamic areaRegion { get; set; }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the address to the given value
    /// </summary>
    /// <param name="a">Address</param>
    public void setAddress(Address a)
    {
      Address = a;
    }

    /// <summary>
    /// Creates an address with the given value and sets it
    /// </summary>
    /// <param name="ls">The Associated Location Street Object</param>
    /// <param name="city">(Optional) The city</param>
    /// <param name="state">(Optional) The State</param>
    /// <param name="country">(Optional) The country</param>
    /// <param name="postCode">(Optional) The Postal Code</param>
    public void setAddress(LocationStreet ls, string city = null, USStateCodeList? state = null, CountryCodeList? country = null, string postCode = null)
    {
      Address a = new Address(ls, city, state, country, postCode);
      setAddress(a);
    }

    /// <summary>
    /// Creates an address with the given value and sets it
    /// </summary>
    /// <param name="city">The city</param>
    /// <param name="state">(Optional) The State</param>
    /// <param name="country">(Optional) The country</param>
    /// <param name="postCode">(Optional) The Postal Code</param>
    public void setAddress(string city, USStateCodeList? state = null, CountryCodeList? country = null, string postCode = null)
    {
      Address a = new Address(null, city, state, country, postCode);
      setAddress(a);
    }



    #endregion

  }

}
