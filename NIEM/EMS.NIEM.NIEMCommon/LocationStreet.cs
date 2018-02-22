//-----------------------------------------------------------------------
// <copyright file="LocationStreet.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a street address
  /// </summary>
  [Serializable]
  public class LocationStreet
  {

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the LocationStreet class
    /// </summary>
    public LocationStreet()
    {

    }

    /// <summary>
    /// Initializes a new instance of the LocationStreet class
    /// </summary>
    /// <param name="streetName">The Street name</param>
    /// <param name="streetCat">The Street category (i.e rd, ave, ln)</param>
    public LocationStreet(string streetName, string streetCat)
    {
      StreetName = streetName;
      StreetCategoryText = streetCat;
    }

	/// <summary>
	/// Initializes a new instance of the LocationStreet class
	/// </summary>
	/// <param name="streetNum">The Street number text</param>
	/// <param name="streetName">The Street name</param>
	/// <param name="streetCat">The Street category (i.e rd, ave, ln)</param>
	/// <param name="postdirection">(Optional) The post-direction text for this street</param>
	/// <param name="predirection">(Optional) The pre-direction text for this street</param>
	/// <param name="ext">(Optional) The extension text for this street</param>
	public LocationStreet(string streetNum, string streetName, string streetCat, string postdirection = null, string predirection = null, string ext = null)
	{
	  StreetNumberText = streetNum;
	  StreetName = streetName;
	  StreetCategoryText = streetCat;
	  StreetPostdirectionalText = postdirection;
	  StreetPredirectionalText = predirection;
	  StreetExtensionText = ext;
	}


	#endregion
	#region Public Fields

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

    #endregion
    #region Override 
    /// <summary>
    /// ToString override to return street info
    /// </summary>
    /// <returns>Street Info</returns>
    public override string ToString()
    {
      string temp = this.StreetFullText;

      if (string.IsNullOrWhiteSpace(temp))
      {
        temp += this.StreetNumberText;
        temp += " " + this.StreetPredirectionalText;
        temp += " " + this.StreetName;
        temp += " " + this.StreetPostdirectionalText;
        temp += " " + this.StreetExtensionText;
        temp += " " + this.StreetCategoryText;
      }

      temp.TrimStart();

      return temp;
    }
    #endregion
  }
}
