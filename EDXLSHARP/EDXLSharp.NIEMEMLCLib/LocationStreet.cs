//-----------------------------------------------------------------------
// <copyright file="LocationStreet.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents a street address
  /// </summary>
  public class LocationStreet
  {
    /// <summary>
    /// Gets or sets the street address full text
    /// </summary>
    [XmlElement("StreetFullText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetFullText
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street number
    /// </summary>
    [XmlElement("StreetNumberText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetNumberText
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street direction prefix
    /// </summary>
    [XmlElement("StreetPredirectionalText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetPredirectionalText
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street name
    /// </summary>
    [XmlElement("StreetName", Namespace = Constants.NiemcoreNamespace)]
    public string StreetName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street category
    /// </summary>
    [XmlElement("StreetCategoryText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetCategoryText
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street direction suffix
    /// </summary>
    [XmlElement("StreetPostdirectionalText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetPostdirectionalText
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the street extension
    /// </summary>
    [XmlElement("StreetExtensionText", Namespace = Constants.NiemcoreNamespace)]
    public string StreetExtensionText
    {
      get; set;
    }
  }
}
