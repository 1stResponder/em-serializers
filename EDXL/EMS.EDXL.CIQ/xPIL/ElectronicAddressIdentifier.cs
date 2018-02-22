using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// A container of different types of electronic addresses of party (e.g. email, chat, skype, etc)
  /// </summary>
  [Serializable]
  public class ElectronicAddressIdentifier
  {
    #region Private Member Variables

    /// <summary>
    /// Type of the electronic Address
    /// </summary>
    private ElectronicAddressIdentifierTypeList? electronicAddressKind;

    /// <summary>
    /// Usage of electronic address identifier. e.g. business, personal
    /// </summary>
    private string usage;

    /// <summary>
    /// The Free-Text Address
    /// </summary>
    private string electronicAddressValue;

    #endregion

    #region XML Attributes

    /// <summary>
    /// Gets or sets
    /// Usage of electronic address identifier. e.g. business, personal
    /// </summary>
    [XmlAttribute("Usage")]
    public string Usage
    {
      get { return this.usage; }
      set { this.usage = value; }
    }

    /// <summary>
    /// Set flag to determine if Usage attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool UsageSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.usage); }
    }

    /// <summary>
    /// Gets or sets
    /// Kind of the contact number
    /// </summary>
    [XmlAttribute("Kind")]
    public ElectronicAddressIdentifierTypeList Kind
    {
      get { return this.electronicAddressKind.Value; }
      set { this.electronicAddressKind = value; }
    }

    /// <summary>
    /// Set flag to determine if Kind attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool KindSpecified
    {
      get { return this.electronicAddressKind.HasValue; }
    }

    #endregion XML Attributes

    #region XML Elements

    /// <summary>
    /// Gets or sets
    /// Electronic address of party
    /// </summary>
    [XmlText]
    public string Value
    {
      get { return this.electronicAddressValue; }
      set { this.electronicAddressValue = value; }
    }

    #endregion XML Elements
  }
}