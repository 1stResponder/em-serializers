using System;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a piece of equipment 
  /// </summary>
  [Serializable]
  public class Equipment : ResponseResourceKind
  {

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the Equipment class
    /// </summary>
    public Equipment()
    {
      SerialID = new IdentificationID();
      estimatedArrival = new DateTime();
      ResourceKind = new ResourceKind();
      EstimatedAvailability = new DateTimeRange();
    }

    /// <summary>
    /// Initializes a new instance of the Equipment class
    /// </summary>
    /// <param name="id">Equipment ID as string</param>
    /// <param name="arr">(Optional) Estimated Arrival DateTime</param>
    /// <param name="res">(Optional) Resource Kind</param>
    /// <param name="aval">(Optional) Availbility Range</param>
    public Equipment(IdentificationID id, DateTime? arr = null, ResourceKind res = null, DateTimeRange aval = null)
    {
      // Set Fields
      SerialID = id;

      EstimatedArrival = (arr != null) ? (DateTime)arr : new DateTime();
      ResourceKind = (res != null) ? res : new ResourceKind();
      EstimatedAvailability = (aval != null) ? aval : new DateTimeRange();
    }

    /// <summary>
    /// Initializes a new instance of the Equipment class
    /// </summary>
    /// <param name="id">Equipment ID as string</param>
    /// <param name="arr">(Optional) Estimated Arrival DateTime</param>
    /// <param name="res">(Optional) Resource Kind</param>
    /// <param name="aval">(Optional) Availbility Range</param>
    public Equipment(string id, DateTime? arr = null, ResourceKind res = null, DateTimeRange aval = null) : this(new IdentificationID(id), arr, res, aval)
    {
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets or sets the Equipment ID as a string
    /// </summary>
    [XmlIgnore]
    public string ID
    {
        get
        {
          return (SerialID != null) ? SerialID.ID : "";
        }

        set
        {
          SerialID = new IdentificationID(value);
        }
    }

      /// <summary>
      /// Gets or sets the Equipment ID
      /// </summary>
      /// <remarks>
      /// Required Element
      /// </remarks>
    [XmlElement(ElementName = "ResourceIdentifier", Namespace = Constants.EmlcNamespace, Order = 1)]
    public IdentificationID SerialID
    {
      get
      {
        return id;
      }

      set
      {
        id = value;
      }
    }

    /// <summary>
    /// The Estimated Arrival Time in UTC
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "EstimatedArrivalDateTime", Namespace = Constants.MaidNamespace, Order = 2)]
    public DateTime EstimatedArrival
    {
      get
      {
        return estimatedArrival.ToUniversalTime();
      }
      set
      {
        estimatedArrival = value.ToUniversalTime();
      }
    }

    /// <summary>
    /// Gets or sets the resource kind
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "AidRespondingResourceType", Namespace = Constants.MaidNamespace, Order = 3)]
    public ResourceKind ResourceKind
    {
      get
      {
        return resourceKind;
      }

      set
      {
        resourceKind = value;
      }

    }

    /// <summary>
    /// Gets or sets the Estimated Availability as a DateTimeRange 
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "EstimatedAvailabilityDateTimeRange", Namespace = Constants.MaidNamespace, Order = 5)]
    public DateTimeRange EstimatedAvailability
    {
      get
      {
        return estimatedAvailability;
      }

      set
      {
        estimatedAvailability = value;
      }

    }
    #endregion

    #region Private Fields

    /// <summary>
    /// Holds the ID
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private IdentificationID id;

    /// <summary>
    /// Holds the Estimated Arrival Time in UTC
    /// </summary>
    [XmlIgnore]
    private DateTime estimatedArrival;

    /// <summary>
    /// Holds the resource kind
    /// Required Element
    /// </summary>
    [XmlIgnore]
    private ResourceKind resourceKind;

    /// <summary>
    /// Holds the Estimated Availability as a DateTimeRange 
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private DateTimeRange estimatedAvailability;


    #endregion


    #region Helper Methods

    /// <summary>
    /// Sets the Equipment ID
    /// </summary>
    /// <param name="eqID">The Equipment ID as a string</param>
    public void SetID(IdentificationID eqID)
    {
      SerialID = eqID;
    }

    /// <summary>
    /// Sets the Equipment ID
    /// </summary>
    /// <param name="eqID">The Equipment ID as a string</param>
    public void SetID(string eqID)
    {
      ID = eqID;
    }

    /// <summary>
    /// Sets the Estimated Availability Range
    /// </summary>
    /// <param name="avalRange">The DateTimeRange</param>
    public void SetEstimatedAvalRange(DateTimeRange avalRange)
    {
      EstimatedAvailability = avalRange;
    }

    /// <summary>
    /// Sets the Estimated Availability Range
    /// </summary>
    /// <param name="start">Start Date</param>
    /// <param name="end">End Date</param>
    public void SetEstimatedAvalRange(DateTime start, DateTime end)
    {
      SetEstimatedAvalRange(new DateTimeRange(start, end));
    }

    /// <summary>
    /// Create the resource kind for the equipment based on the values
    /// </summary>
    /// <param name="typeCode">The resource type code</param>
    /// <param name="desc">The resource type descriptor list</param>
    /// <param name="def">The resource NIMS definition</param>
    public void SetResourceKind(EventTypeCodeList typeCode, List<string> desc = null, ResourceNIMSDefinition def = null)
    {
      ResourceKind = new ResourceKind(typeCode, desc, def);
    }

	/// <summary>
	/// Create the resource kind for the equipment based on the values
	/// </summary>
	/// <param name="typeCode">The resource type code as string</param>
	/// <param name="desc">The resource type descriptor list</param>
	/// <param name="def">The resource NIMS definition</param>
	public void SetResourceKind(string typeCode, List<string> desc = null, ResourceNIMSDefinition def = null)
	{
	  ResourceKind = new ResourceKind(typeCode, desc, def);
	}

	/// <summary>
	/// Sets the Resource Kind
	/// </summary>
	/// <param name="kind">The resource kind</param>
	public void SetResourceKind(ResourceKind kind)
	{
	  ResourceKind = kind;
	}

	#endregion


  }
}
