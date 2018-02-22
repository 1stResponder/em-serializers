using System;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
    /// <summary>
    /// Represents a UTM Coordinate
    /// </summary>
    public class UTMCoordinate
    {

    
    /// <summary>
    /// Initializes a new instance of the UTMCoordinate class
    /// </summary>
    public UTMCoordinate(){ }
    

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cordID">Coordinate ID</param>
    /// <param name="eastValue">Easting Value</param>
    /// <param name="northValue">Northing Value</param>
    /// <param name="geoDatum">Geographic datum</param>
    /// <param name="hemisphre">Hemispheric Code</param>
    /// <param name="zone">Zone number</param>
    public UTMCoordinate(string cordID, int eastValue, int northValue,string geoDatum, 
        UTMHemisphereCodeType hemisphre, int zone) {

        CoordinateID = cordID;
        EastingValue = eastValue;
        NorthingValue = northValue;
        GeographicDatumText = geoDatum;
        UTMHemisphereCode = hemisphre;
        UTMZoneNumeric = zone;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cordID">Coordinate ID</param>
    /// <param name="eastValue">Easting Value</param>
    /// <param name="northValue">Northing Value</param>
    /// <param name="geoDatum">Geographic datum</param>
    /// <param name="hemisphre">Hemispheric Code as string</param>
    /// <param name="zone">Zone number</param>
    public UTMCoordinate(string cordID, int eastValue, int northValue,string geoDatum, 
        string hemisphre, int zone) {

        CoordinateID = cordID;
        EastingValue = eastValue;
        NorthingValue = northValue;
        GeographicDatumText = geoDatum;
        UTMHemisphere = hemisphre;
        UTMZoneNumeric = zone;
    }
    
    /// <summary>
    /// Gets or sets An identifier of a UTM coordinate.
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "UTMCoordinateID", Namespace = Constants.NiemcoreNamespace, Order = 1)]
    public string CoordinateID
    {
      get; set;
    }
    
    /// <summary>
    /// Gets or sets A distance east within a UTM zone.
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "UTMEastingValue", Namespace = Constants.NiemcoreNamespace, Order = 2)]
    public int EastingValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets A distance north within a UTM zone.
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "UTMNorthingValue", Namespace = Constants.NiemcoreNamespace, Order = 3)]
    public int NorthingValue
    {
      get; set;
    }
    
    /// <summary>
    /// Gets or sets A spatial reference system.
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "GeographicDatumText", Namespace = Constants.NiemcoreNamespace, Order = 6)]
    public string GeographicDatumText
    {
        get; set;
    }  
    

    /// <summary>
    /// Gets or sets the Hemisphere code 
    /// Required Element
    /// </summary>
    [XmlIgnore]
    public UTMHemisphereCodeType UTMHemisphereCode
    {
      get; set;
    }
    
    [XmlElement(ElementName = "UTMHemisphereCode", Namespace = Constants.NiemcoreNamespace, Order = 5)]
    public string UTMHemisphere
    {
        get
        {
             return UTMHemisphereCode.ToString();   
        } 
        set
        {
            UTMHemisphereCode = (UTMHemisphereCodeType)Enum.Parse(typeof(UTMHemisphereCodeType),value);
        }
    }

    
    /// <summary>
    /// Gets or sets the zone number (out of the 60)
    /// Required Element
    /// </summary>
    [XmlIgnore]
    private int utmZoneNumeric { get; set;}
    
    [XmlElement(ElementName = "UTMZoneNumeric", Namespace = Constants.NiemcoreNamespace, Order = 4)]
    public int UTMZoneNumeric
    {
        get
            {
                return utmZoneNumeric;
            } 
        set
        {
            if (value < 0 || value > 60)
            {
                    throw new ArgumentOutOfRangeException("value", "Zone must be a value 0-60.");
            }

            utmZoneNumeric = value;
        }
    }
    
    }
    
    /// <summary>
    /// enum holding the valid properties for Hemisphere codes
    /// </summary>
    public enum UTMHemisphereCodeType { N='N', S='S'};
}
