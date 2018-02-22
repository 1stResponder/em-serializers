//-----------------------------------------------------------------------
// <copyright file="IncidentDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace EMS.NIEM.Incident
{
  // NOTE: The xml name/namespace prefix of this class is hard coded in the JSON deserialization process.  
  // If the class name is changed then that must be updated as well.   
  // Places to Update:
  //      deSerialEventConverter


  /// <summary>
  /// Represents an incident
  /// </summary>
  [Serializable]
  [XmlRoot("IncidentDetail", Namespace = Constants.EmlcNamespace)]
  public class IncidentDetail : EventDetails
  {
    IncidentLocationExtension locationExtension;
    IncidentStatus status;
    IncidentOrganization owningOrg;

    /// <summary>
    /// Initializes a new instance of the IncidentDetail class
    /// </summary>
    public IncidentDetail()
    {
      //initialize required fields
      this.status = new IncidentStatus();
      this.status.SecondaryStatus = new List<AltStatus>();
      this.owningOrg = new IncidentOrganization();

      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.MoPrefix, Constants.MoNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
    }

    /// <summary>
    /// Gets or sets Namespace object place for serializing prefixes for namespaces
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is suppressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the status of this incident
    /// </summary>
    [XmlElement(ElementName = "IncidentStatus", Order = 1)]
    public IncidentStatus Status
    {
      get { return this.status; }
      set { this.status = value; }
    }

    /// <summary>
    /// Gets or sets the owning organization for this incident
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "IncidentOwningOrganization", Order = 2)]
    public IncidentOrganization OwningOrg
    {
      get { return this.owningOrg; }
      set { this.owningOrg = value; }
    }

    /// <summary>
    /// Gets or sets the owning organization for this incident
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "IncidentLocationExtension", Order = 3)]
    public IncidentLocationExtension LocationExtension
    {
      get { return this.locationExtension; }
      set { this.locationExtension = value; }
    }

    /// <summary>
    /// Sets primary status code 
    /// <see cref="IncidentStatus"/>.
    /// <seealso cref="IncidentPrimaryStatusCodeList"/>
    /// </summary>
    public void AddPrimaryStatus(IncidentPrimaryStatusCodeList value)
    {
      this.status.PrimaryStatus = value;
    }

    /// <summary>
    /// Sets a new street address 
    /// <see cref="IncidentLocationExtension.Address"/>.
    /// </summary>
    public void AddStreetAddress(string Number, string Name, string Predirection, string Postdirection, string Category, string Extension, string City, USStateCodeList State, string Zip, string ZipExtension)
    {
      SanityCheckAddress();

      this.locationExtension.Address.LocationStreet.StreetNumberText = Number;
      this.locationExtension.Address.LocationStreet.StreetName = Name;
      this.locationExtension.Address.LocationStreet.StreetPredirectionalText = Predirection;
      this.locationExtension.Address.LocationStreet.StreetPostdirectionalText = Postdirection;
      this.locationExtension.Address.LocationStreet.StreetCategoryText = Category;
      this.locationExtension.Address.LocationStreet.StreetExtensionText = Extension;
      this.locationExtension.Address.LocationCityName = City;
      this.locationExtension.Address.LocationPostalCode = Zip;
      this.locationExtension.Address.LocationPostalExtensionCode = ZipExtension;
      this.locationExtension.Address.LocationState = State;
    }

    /// <summary>
    /// Make sure the appropriate objects are instantiated
    /// </summary>
    private void SanityCheckAddress()
    {
      if (null == this.locationExtension)
      {
        this.locationExtension = new IncidentLocationExtension();
        this.locationExtension.Address = new Address();
        this.locationExtension.Address.LocationStreet = new LocationStreet();
      }

      if (null == this.locationExtension.Address)
      {
        this.locationExtension.Address = new Address();
        this.locationExtension.Address.LocationStreet = new LocationStreet();
      }

      if (null == this.locationExtension.Address.LocationStreet)
      {
        this.locationExtension.Address.LocationStreet = new LocationStreet();
      }
    }

    /// <summary>
    /// Make sure the appropriate objects are instantiated
    /// </summary>
    private void SanityCheckCrossStreet()
    {
      if (null == this.locationExtension)
      {
        this.locationExtension = new IncidentLocationExtension();
        this.locationExtension.AddressCrossStreet = new AddressCrossStreet();
        this.locationExtension.AddressCrossStreet.LocationStreet = new LocationStreet();
      }

      if (null == this.locationExtension.AddressCrossStreet)
      {
        this.locationExtension.AddressCrossStreet = new AddressCrossStreet();
        this.locationExtension.AddressCrossStreet.LocationStreet = new LocationStreet();
      }

      if (null == this.locationExtension.AddressCrossStreet.LocationStreet)
      {
        this.locationExtension.AddressCrossStreet.LocationStreet = new LocationStreet();
      }
    }

    /// <summary>
    /// Adds the cross street to the address 
    /// <see cref="IncidentLocationExtension.AddressCrossStreet"/>.
    /// </summary>
    public void AddCrossStreet(string Description, string Number, string Name, string Predirection, string Postdirection, string Category, string Extension)
    {
      SanityCheckCrossStreet();

      this.locationExtension.AddressCrossStreet.CrossStreetDescriptionText = Description;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetNumberText = Number;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetName = Name;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetPredirectionalText = Predirection;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetPostdirectionalText = Postdirection;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetCategoryText = Category;
      this.locationExtension.AddressCrossStreet.LocationStreet.StreetExtensionText = Extension;
    }

    /// <summary>
    /// Adds a new text status to secondary status 
    /// <see cref="TextStatus"/>.
    /// </summary>
    public void AddSecondaryStatusText(string description, string sourceID)
    {
      TextStatus status = new TextStatus();
      status.Description = description;
      status.SourceID = sourceID;

      this.status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new EIDD status to secondary status 
    /// <see cref="IncidentEIDDStatus"/>.
    /// <seealso cref="IncidentEIDDStatusCodeList"/>
    /// </summary>
    public void AddEIDDStatus(IncidentEIDDStatusCodeList value)
    {
      IncidentEIDDStatus status = new IncidentEIDDStatus();
      status.EIDDCode = value;

      this.status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new pulse point status to secondary status 
    /// <see cref="IncidentPulsePointStatus"/>.
    /// <seealso cref="IncidentPulsePointStatusCodeList"/>
    /// </summary>
    public void AddPulsePointStatus(IncidentPulsePointStatusCodeList value)
    {
      IncidentPulsePointStatus status = new IncidentPulsePointStatus();
      status.PulsePointCode = value;

      this.status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Sets the incident organization 
    /// <see cref="IncidentOrganization"/>.
    /// </summary>
    public void AddOwningOrganization(string orgID, string incidentID)
    {
      this.owningOrg.OrgID = orgID;
      this.owningOrg.IncidentID = incidentID;
    }
  }
}
