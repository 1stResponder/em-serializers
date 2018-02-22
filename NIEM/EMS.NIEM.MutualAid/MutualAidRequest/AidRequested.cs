using System;
using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using EMS.NIEM.MutualAid;
using System.Xml.Serialization;
using System.Collections.Generic;
using EMS.NIEM.Resource;
using System.Linq;

namespace EMS.NIEM.MutualAid
{

  /// <summary>
  /// Represents a mutual aid request
  /// </summary>
  [Serializable]
  public class AidRequested : MutualAidMessage
  {

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the AidRequested class
    /// </summary>
    public AidRequested()
    {
      Resources = new List<RequestResourceKind>();
    }

    /// <summary>
    /// Initializes a new instance of the AidRequested class
    /// </summary>
    /// <param name="resources">List of resources being requested</param>
    /// <param name="loc">(Optional) The Location Extension</param>
    public AidRequested(List<RequestResourceKind> resources, LocationExtension loc = null)
    {
      Resources = (resources != null) ? resources : new List<RequestResourceKind>();
      Location = loc;
    }
    #endregion
    #region Public Fields

    /// <summary>
    /// List of Resources for this Aid Request
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlArray("AidRequestedResources", Namespace = Constants.MaidNamespace, Order = 1)]
    [XmlArrayItem("AidRequestedSpecificResource", typeof(SpecificResource), Namespace = Constants.MaidNamespace)]
    [XmlArrayItem("AidRequestedGenericResource", typeof(GenericResource), Namespace = Constants.MaidNamespace)]
    [XmlArrayItem("AidRequestedMissionNeed", typeof(MissionNeed), Namespace = Constants.MaidNamespace)]
    public List<RequestResourceKind> Resources
    {
      get
      {
        return resources;
      }

      set
      {
        resources = value;
      }
    }

    /// <summary>
    /// Gets or sets the request location
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "AidRequestedLocationExtension", Namespace = Constants.MaidNamespace, Order = 2)]
    public LocationExtension Location { get; set; }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Adds the resource(s) to the Resource List
    /// </summary>
    /// <param name="res">The Resource</param>
    public void AddResource(RequestResourceKind res)
    {
      if (Resources == null) Resources = new List<RequestResourceKind>();
      Resources.Add(res);
    }

    /// <summary>
    /// Adds the resource(s) to the Resource List
    /// </summary>
    /// <param name="resource">The List of Resources</param>
    public void AddResource(List<RequestResourceKind> resource)
    {
      if (Resources == null) Resources = new List<RequestResourceKind>();
      Resources.AddRange(resource);
    }

    /// <summary>
    /// Adds the resource(s) to the Resource List
    /// </summary>
    /// <param name="resource">The List of Resources as an Array</param>
    public void AddResource(RequestResourceKind[] resource)
    {
      AddResource(resource.ToList());
    }

    /// <summary>
    /// Creates a SpecificResource with the given value and adds it to the request
    /// </summary>
    /// <param name="id">The id for this specific resource</param>
    public void AddSpecificResource(string id)
    {
      AddResource(new SpecificResource(id));
    }

	/// <summary>
	/// Adds the specific Resource
	/// </summary>
	/// <param name="res">The specific resouce</param>
	public void AddSpecificResource(SpecificResource res)
	{
	  AddResource(res);
	}

	/// <summary>
	/// Adds the genric Resource
	/// </summary>
	/// <param name="res">The generic resouce</param>
	public void AddGenericResource(GenericResource res)
	{
	  AddResource(res);
	}

	/// <summary>
	/// Creates a Generic Resource with the given value and adds it to the request
	/// </summary>
	/// <param name="quanity">Quantity for resource</param>
	/// <param name="grkind">The Generic Resource Kind</param>
	public void AddGenericResource(int quanity, GenericResourceKind grkind)
    {
      AddResource(new GenericResource(quanity, grkind));
    }

	/// <summary>
	/// Creates a Generic Resource with the given value and adds it to the request
	/// </summary>
	/// <param name="quanity">Quantity for resource</param>
	/// <param name="typeCode">Type code for Generic Resource Kind</param>
	/// <param name="def">(Optional) NIMS Definition for Generic Resource Kind</param>
	/// <param name="description">(Optional) Descriptor List for Generic Resource Kind</param>
	public void AddGenericResource(int quanity, EventTypeCodeList typeCode, ResourceNIMSDefinition def = null, List<string> description = null)
    {

	  if (description != null)
	  {
		AddResource(new GenericResource(quanity, typeCode, def, description));
	  }
	  else
	  {
		AddResource(new GenericResource(quanity, typeCode, def));
	  }

    }

	/// <summary>
	/// Adds the MissionNeed Resource
	/// </summary>
	/// <param name="res">The MissionNeed resouce</param>
	public void AddMissionNeed(MissionNeed res)
	{
	  AddResource(res);
	}

	/// <summary>
	/// Creates a Mission need Resource with the given value and adds it to the request
	/// </summary>
	/// <param name="qu">Quantity</param>
	/// <param name="vt">Value Text</param>
	/// <param name="vListUrn">(Optional) Value List URN Text</param>
	/// <param name="augmen">(Optional) Value Augmentation Point</param>
	public void AddMissionNeed(int qu, string vt, string vListUrn = null, string augmen = null)
    {
      AddResource(new MissionNeed(qu, vt, vListUrn, augmen));
    }

	/// <summary>
	/// Sets the Location for this Aid Request
	/// </summary>
	/// <param name="le">The Location Extension</param>
	public void SetLocation(LocationExtension le)
	{
	  Location = le;
	}

	/// <summary>
	/// Creates the Location to be set for the Aid Request
	/// </summary>
	/// <param name="add">Address object</param>
	/// <param name="cross">(Optional) AddressCrossStreet Object</param>
	/// <param name="grid">(Optional) AddressGrid</param>
	/// <param name="mgrs">(Optional) MGRS Coordinate</param>
	/// <param name="utm">(Optional) UTM Coordinate</param>
	/// <param name="ar">(Optional) Area Region</param>
	/// <param name="intersect">(Optional) Intersection Boolean</param>
	public void SetLocation(Address add, AddressCrossStreet cross = null, AddressGrid grid = null, MGRSCoordinate mgrs = null, UTMCoordinate utm = null, AreaRegion ar = null, bool? intersect = null)
	{

	  LocationExtension e = null;

	  if (intersect != null)
	  {
		e = new LocationExtension(add, cross, grid, mgrs, utm, ar, (bool)intersect);
	  }
	  else
	  {
		e = new LocationExtension(add, cross, grid, mgrs, utm, ar, false);
	  }

	  SetLocation(e);
	}


	#endregion

	#region Private Fields

	/// <summary>
	/// Holds the List of Resources for this Aid Request
	/// Required Element
	/// </summary>
	[XmlIgnore]
    private List<RequestResourceKind> resources;

    #endregion

    #region Serial helper

    /// <summary>
    /// If Resources is null then this should throw an error 
    /// </summary>
    /// <returns>true or false</returns>
    /// <exception cref="ArgumentNullException">If the Resources is null</exception>
    public bool ResourcesSpecified
    {
      get
      {
        if (Resources == null) throw new ArgumentNullException("Resources must be specified");

        return true;
      }
    }

    #endregion

  }
}
