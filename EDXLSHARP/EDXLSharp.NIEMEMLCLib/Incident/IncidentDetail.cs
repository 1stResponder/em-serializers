//-----------------------------------------------------------------------
// <copyright file="IncidentDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Incident
{
  /// <summary>
  /// Represents an incident
  /// </summary>
  [Serializable]
  public class IncidentDetail : EventDetails
  {

    /// <summary>
    /// Initializes a new instance of the IncidentDetail class
    /// </summary>
    public IncidentDetail()
    {
        Status = new IncidentStatus();
        OwningOrg = new IncidentOrganization();

    }

    /// <summary>
    /// Gets or sets the status of this incident
    /// </summary>
    [XmlElement(ElementName = "IncidentStatus", Order=1)]
    public IncidentStatus Status
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the owning organization for this incident
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "IncidentOwningOrganization", Order=2)]
    public IncidentOrganization OwningOrg
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the owning organization for this incident
    /// Optional Element
    /// </summary>
    [XmlElement(ElementName = "IncidentLocationExtension", Order =3)]
    public IncidentLocationExtension LocationExtension
    {
      get; set;
    }

    /// <summary>
    /// Sets primary status code 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentPrimaryStatusCodeList"/>
    /// </summary>
    public void setPrimaryStatus(IncidentPrimaryStatusCodeList value)
    {
        Status.PrimaryStatus = value;
    }
        
    /// <summary>
    /// Sets a new street address 
    /// <see cref="EDXLSharp.NIEMEMLCLib.IncidentLocationExtension.Address"/>.
    /// </summary>
    public void AddStreetAddress(string Number, string Name, string Predirection, string Postdirection, string Category, string Extension, string City, USStateCodeList State, string Zip, string ZipExtension)
    {
        LocationExtension.Address.LocationStreet.StreetNumberText = Number;
        LocationExtension.Address.LocationStreet.StreetName = Name;
        LocationExtension.Address.LocationStreet.StreetPredirectionalText = Predirection;
        LocationExtension.Address.LocationStreet.StreetPostdirectionalText = Postdirection;
        LocationExtension.Address.LocationStreet.StreetCategoryText = Category;
        LocationExtension.Address.LocationStreet.StreetExtensionText = Extension;
        LocationExtension.Address.LocationCityName = City;
        LocationExtension.Address.LocationPostalCode = Zip;  
        LocationExtension.Address.LocationPostalExtensionCode = ZipExtension;
        LocationExtension.Address.LocationState = State;
    }
        
    /// <summary>
    /// Adds the cross street to the address 
    /// <see cref="EDXLSharp.NIEMEMLCLib.IncidentLocationExtension.AddressCrossStreet"/>.
    /// </summary>
    public void AddCrossStreet(string Description , string Number , string Name , string Predirection , string Postdirection , string Category , string Extension)
    {
        LocationExtension.AddressCrossStreet.CrossStreetDescriptionText = Description;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetNumberText = Number;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetName = Name;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetPredirectionalText = Predirection;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetPostdirectionalText = Postdirection;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetCategoryText = Category;
        LocationExtension.AddressCrossStreet.LocationStreet.StreetExtensionText = Extension;
    }

    /// <summary>
    /// Adds a new text status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.TextStatus"/>.
    /// </summary>
    public void AddSecondaryStatusText(string description, string sourceID)
    {
        TextStatus status = new TextStatus();
        status.Description = description;
        status.SourceID = sourceID;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new EIDD status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentEIDDStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentEIDDStatusCodeList"/>
    /// </summary>
    public void AddEIDDStatus(IncidentEIDDStatusCodeList value)
    {
        IncidentEIDDStatus status = new IncidentEIDDStatus();
        status.EIDDCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Adds a new pulse point status to secondary status 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentPulsePointStatus"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentPulsePointStatusCodeList"/>
    /// </summary>
    public void AddPulsePointStatus(IncidentPulsePointStatusCodeList value)
    {
        IncidentPulsePointStatus status = new IncidentPulsePointStatus();
        status.PulsePointCode = value;
        Status.SecondaryStatus.Add(status);
    }

    /// <summary>
    /// Sets the incident organization 
    /// <see cref="EDXLSharp.NIEMEMLCLib.Incident.IncidentOrganization"/>.
    /// </summary>
    public void setOrganization(string orgID, string incidentID)
    {
        OwningOrg.OrgID = orgID;
        OwningOrg.IncidentID = incidentID;
    }



    }
}
 