using System;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a mutual aid response
  /// </summary>
  [Serializable]
  public class AidResponding : MutualAidMessage
  {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the AidResponding class
    /// </summary>
    public AidResponding()
    {
      Resources = new List<ResponseResourceKind>();
      ContactInformation = new ContactInformation();
    }

    /// <summary>
    /// Initializes a new instance of the AidResponding class
    /// </summary>
    /// <param name="app">Approved Status</param>
    /// <param name="resourceList">(Optional) List of Responding Resource Kinds</param>
    /// <param name="info">(Optional) Contact Information</param>
    public AidResponding(bool app, List <ResponseResourceKind> resourceList = null, ContactInformation info = null)
    {
      Approved = app;
      Resources = (resourceList != null) ? resourceList : new List<ResponseResourceKind>();
      ContactInformation = (info != null) ? info : new ContactInformation();
    }
    #endregion

    #region Public Fields

    /// <summary>
    /// Gets or sets Approved Status
    /// </summary>   
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(Namespace = Constants.MaidNamespace, Order = 1)]
    public bool Approved { get; set; }

    /// <summary>
    /// Gets or sets the List of resources
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlArray("AidRespondingResources", Namespace = Constants.MaidNamespace, Order = 2)]
    [XmlArrayItem("AidRespondingEquipment", typeof(Equipment), Namespace = Constants.MaidNamespace)]
    [XmlArrayItem("AidRespondingPerson", typeof(Person), Namespace = Constants.MaidNamespace)]
    public List<ResponseResourceKind> Resources { get; set; }

    /// <summary>
    /// Gets or sets the contact information
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "AidRespondingContactInformation", Namespace = Constants.MaidNamespace, Order = 3)]
    public ContactInformation ContactInformation { get; set; }
    #endregion

    #region Helper Methods

    /// <summary>
    /// Adds the response resource(s) to the resource list
	/// Value can not be null
    /// </summary>
    /// <param name="res">List of Response Resources</param>
    public void AddResource(List<ResponseResourceKind> res)
    {
      if (Resources == null) Resources = new List<ResponseResourceKind>();
      Resources.AddRange(res);
    }

	/// <summary>
	/// Adds the response resource(s) to the resource list
	/// Value can not be null
	/// </summary>
	/// <param name="res">List of Response Resources</param>
	public void AddResource(List<Equipment> res)
	{
	  if (Resources == null)
		Resources = new List<ResponseResourceKind>();
	  Resources.AddRange(res);
	}

	/// <summary>
	/// Adds the response resource(s) to the resource list
	/// Value can not be null
	/// </summary>
	/// <param name="res">List of Response Resources</param>
	public void AddResource(List<Person> res)
	{
	  if (Resources == null)
		Resources = new List<ResponseResourceKind>();
	  Resources.AddRange(res);
	}

	/// <summary>
	/// Adds the response resource(s) to the resource list
	/// Value can not be null
	/// </summary>
	/// <param name="res">A Response Resource</param>
	public void AddResource(ResponseResourceKind res)
    {
      AddResource(new List<ResponseResourceKind> { res });
    }

	/// <summary>
	/// Adds the Person(s) Resource
	/// Value can not be null
	/// </summary>
	/// <param name="p">Person</param>
	public void AddPersonResource(Person p)
	{
	  AddResource(p);
	}

	/// <summary>
	/// Adds the Person(s) Resource
	/// Value can not be null
	/// </summary>
	/// <param name="p">Person List</param>
	public void AddPersonResource(List<Person> p)
	{
	  AddResource(p);
	}

	/// <summary>
	/// Creates a person with the given values and adds them to the resource list
	/// </summary>
	/// <param name="perID">The Identitication ID</param>
	/// <param name="aval">(Optional) The Estimated Availability</param>
	/// <param name="arrival">(Optional) The Estimated Arrival</param>
	/// <param name="ra">(Optional) The Rank</param>
	/// <param name="cr">(Optional) The Credential List</param>
	public void AddPersonResource(IdentificationID perID, DateTimeRange aval = null, DateTime? arrival = null, Rank ra = null, List<Credential> cr = null)
    {
      Person p = new Person(perID, aval, arrival, ra, cr);
      AddResource(p);
    }

	/// <summary>
	/// Creates a person with the given values and adds them to the resource list
	/// </summary>
	/// <param name="perID">The Identitication ID as string</param>
	/// <param name="aval">(Optional) The Estimated Availability</param>
	/// <param name="arrival">(Optional) The Estimated Arrival</param>
	/// <param name="ra">(Optional) The Rank</param>
	/// <param name="cr">(Optional) The Credential List</param>
	public void AddPersonResource(string perID, DateTimeRange aval = null, DateTime? arrival = null, Rank ra = null, List<Credential> cr = null)
    {
	  AddPersonResource(new IdentificationID(perID), aval, arrival, ra, cr);
    }

	/// <summary>
	/// Adds the equipment object
	/// </summary>
	/// <param name="e">Equipment</param>
	public void AddEquipmentResource(Equipment e)
	{
	  AddResource(e);
	}

	/// <summary>
	/// Adds the equipment object(s)
	/// </summary>
	/// <param name="e">Equipment List</param>
	public void AddEquipmentResource(List<Equipment> e)
	{
	  AddResource(e);
	}

	/// <summary>
	/// Creates the equipment with the given values and adds it to the resource list
	/// </summary>//
	/// <param name="id">Equipment ID</param>
	/// <param name="arr">(Optional) Estimated Arrival DateTime</param>
	/// <param name="res">(Optional) Resource Kind</param>
	/// <param name="aval">(Optional) Availbility Range</param>
	public void AddEquipmentResource(IdentificationID id, DateTime? arr = null, ResourceKind res = null, DateTimeRange aval = null)
    {
      Equipment e = new Equipment(id, arr, res, aval);
      AddResource(e);
    }

    /// <summary>
    /// Creates the equipment with the given values and adds it to the resource list
    /// </summary>
    /// <param name="id">Equipment ID as string</param>
    /// <param name="arr">(Optional) Estimated Arrival DateTime</param>
    /// <param name="res">(Optional) Resource Kind</param>
    /// <param name="aval">(Optional) Availbility Range</param>
    public void AddEquipmentResource(string id, DateTime? arr = null, ResourceKind res = null, DateTimeRange aval = null)
    {
      Equipment e = new Equipment(id, arr, res, aval);
      AddResource(e);
    }

    /// <summary>
    /// Approve the Aid Response.  
    /// Sets the Approved field as true
    /// </summary>
    public void ApproveAidResponse()
    {
      Approved = true;
    }

    /// <summary>
    /// Reject the Aid Response.
    /// Sets the Approved field as false
    /// </summary>
    public void RejectAidResponse()
    {
      Approved = false;
    }

	/// <summary>
	/// Sets the Contact Information
	/// </summary>
	/// <param name="i">Contact Informatiom Object</param>
	public void SetContactInformation(ContactInformation i)
	{
	  ContactInformation = i;
	}

	/// <summary>
	/// Creates a new contact infomation object and sets it
	/// </summary>
	/// <param name="mean">The contact mean</param>
	/// <param name="entity">(Optional) The contact entity</param>
	/// <param name="entityDesc">(Optional) The contact entity's description</param>
	/// <param name="infoDesc">(Optional) The contact information description</param>
	/// <param name="responder">(Optional) The contact responder</param>
	/// <param name="augmentPoint">(Optional) The contact augmentation point</param>
	public void SetContactInformation(string mean, string entity = null, string entityDesc = null, string infoDesc = null, string responder = null, string augmentPoint = null)
	{
	  ContactInformation = new ContactInformation(mean, entity, entityDesc, infoDesc, responder, augmentPoint);
	}

	#endregion

  }
}
