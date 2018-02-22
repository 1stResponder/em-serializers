//-----------------------------------------------------------------------
// <copyright file="GML.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Geo4NIEM
{
  /// <summary>
  /// Abstract Base Class Defining Internal Interfaces for GML Objects
  /// </summary>
  public abstract partial class GML
  {
    #region Private Member Variables

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the GML class.
    /// Base Class Default Constructor
    /// </summary>
    public GML()
    {
    }

    #endregion

    /// <summary>
    /// Gets or sets Database handle for the object
    /// </summary>
    [XmlAttribute(Namespace = Constants.GmlNamespace)]
    [JsonProperty(PropertyName = "@ID")]
    public string ID
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets Coordinate Reference System Type
    /// </summary>
    [XmlAttribute(Namespace = Constants.GmlNamespace)]
    [JsonProperty(PropertyName = "@SRSName")]
    public string SRSName
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the the length of coordinate sequence (the number of entries in the list).
    /// </summary>
    [XmlAttribute(Namespace = Constants.GmlNamespace)]
    [JsonProperty(PropertyName = "@SRSDimension")]
    public uint SRSDimension
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Ordered list of labels for all the axes of this coordinate reference system
    /// </summary>
    [XmlAttribute(Namespace = Constants.GmlNamespace)]
    [JsonProperty(PropertyName = "@AxisLabels")]
    public string AxisLabels
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the Ordered list of unit of measure labels for all the axes 
    /// </summary>
    [XmlAttribute(Namespace = Constants.GmlNamespace)]
    [JsonProperty(PropertyName = "@UOMLabels")]
    public string UOMLabels
    {
      get; set;
    }

    #endregion
  }
}