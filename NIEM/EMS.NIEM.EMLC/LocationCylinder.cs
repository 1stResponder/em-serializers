//-----------------------------------------------------------------------
// <copyright file="LocationCylinder.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Represents the location cylinder
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  [XmlRoot(ElementName = "WGS84LocationCylinder", Namespace = Constants.MoNamespace)]
  [Serializable]
  public class LocationCylinder
  {
    /// <summary>
    /// Initializes a new instance of the LocationCylinder class
    /// </summary>
    public LocationCylinder()
    {
      this.LocationPoint = new LocationPoint();
    }

    /// <summary>
    /// Gets or sets the location point of the cylinder
    /// </summary>
    [XmlElement(Namespace = Constants.MoNamespace)]
    [JsonProperty]
    public LocationPoint LocationPoint
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the radius of the cylinder
    /// </summary>
    [XmlElement(Namespace = Constants.MoNamespace)]
    [JsonProperty]
    public decimal? LocationCylinderRadiusValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the half height of the cylinder
    /// </summary>
    [XmlElement(Namespace = Constants.MoNamespace, IsNullable = true)]
    [JsonProperty]
    public decimal? LocationCylinderHalfHeightValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the code for how location was created
    /// </summary>
    [XmlIgnore]
    public LocationCreationCodeList? CodeValue
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for the location creation code
	/// Returns empty string if the CodeValue is null
    /// </summary>
    [XmlElement(Namespace = Constants.MoNamespace, IsNullable = true)]
    [JsonProperty]
    public string LocationCreationCode
    {
      get
      {
		return (CodeValue == null) ? "" : CodeValue.ToString().Replace('_', '.');
      }

      set
      {
		this.CodeValue = null;

		if (value != null)
		{
		  this.CodeValue = (LocationCreationCodeList)Enum.Parse(typeof(LocationCreationCodeList), value.Replace('.', '_'));
		}
		
      }
    }
  }
}