using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// A container for defining the unique characteristics of a person only
  /// </summary>
  [Serializable]
  public class PersonDetailsType
  {
    #region Private Member Variables

    /// <summary>
    /// Person Name
    /// </summary>
    private List<PersonNameElement> personName; 

    /// <summary>
    /// A Container for all party Addresses
    /// </summary>
    private List<AddressType> addresses;

    /// <summary>
    /// A container for all kinds of telecommunication lines of party used for contact purposes
    /// </summary>
    private List<ContactNumber> contactNumbers;

    /// <summary>
    /// A container for defining the unique characteristics of a person only
    /// </summary>
    private List<ElectronicAddressIdentifier> electronicAddressIdentifiers;

    /// <summary>
    /// A container for a list of Identifiers to recognize the party such as customer identifier, social security number, tax number, etc
    /// </summary>
    private List<Identifier> identifiers;

    #endregion Private Member Variables

    #region XML Elements

    /// <summary>
    /// Gets or sets
    /// Person Name
    /// </summary>
    [XmlArray("personName", Namespace = CIQNamespaces.v10_xNL, Order = 1)]
    [XmlArrayItem("nameElement")]
    public List<PersonNameElement> PersonName
    {
      get { return this.personName; }
      set { this.personName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A Container for all party Addresses
    /// </summary>
    [XmlArray("addresses", Namespace = CIQNamespaces.v10_xPIL, Order = 2)]
    [XmlArrayItem("address", Namespace = CIQNamespaces.v10_xAL)]
    public List<AddressType> Addresses
    {
      get { return this.addresses; }
      set { this.addresses = value; }
    }

    /// <summary>
    /// Set flag to determine if addresses element is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool AddressesSpecified
    {
      get { return this.addresses != null && this.addresses.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for all kinds of telecommunication lines of party used for contact purposes
    /// </summary>
    [XmlArray("contactNumbers", Namespace = CIQNamespaces.v10_xPIL, Order = 3)]
    [XmlArrayItem("contactNumber")]
    public List<ContactNumber> ContactNumbers
    {
      get { return this.contactNumbers; }
      set { this.contactNumbers = value; }
    }

    /// <summary>
    /// Set flag to determine if contactNumbers element is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool ContactNumbersSpecified
    {
      get { return this.contactNumbers != null && this.contactNumbers.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for defining the unique characteristics of a person only
    /// </summary>
    [XmlArray("electronicAddressIdentifiers", Namespace = CIQNamespaces.v10_xPIL, Order = 4)]
    [XmlArrayItem("electronicAddressIdentifier")]
    public List<ElectronicAddressIdentifier> ElectronicAddressIdentifiers
    {
      get { return this.electronicAddressIdentifiers; }
      set { this.electronicAddressIdentifiers = value; }
    }

    /// <summary>
    /// Set flag to determine if electronicAddressIdentifiers element is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool ElectronicAddressIdentifiersSpecified
    {
      get { return this.electronicAddressIdentifiers != null && this.electronicAddressIdentifiers.Count > 0; }
    }

    /// <summary>
    /// Gets or sets
    /// A container for a list of Identifiers to recognize the party such as customer identifier, social security number, tax number, etc
    /// </summary>
    [XmlArray("identifiers", Namespace = CIQNamespaces.v10_xPIL, Order = 5)]
    [XmlArrayItem("identifier")]
    public List<Identifier> Identifiers
    {
      get { return this.identifiers; }
      set { this.identifiers = value; }
    }

    /// <summary>
    /// Set flag to determine if Identifiers element is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool IdentifiersSpecified
    {
      get { return this.identifiers != null && this.identifiers.Count > 0; }
    }
    #endregion XML Elements
  }
}
