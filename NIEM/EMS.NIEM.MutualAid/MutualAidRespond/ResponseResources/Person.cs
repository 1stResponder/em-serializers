using System;
using System.Collections.Generic;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Linq;

namespace EMS.NIEM.MutualAid
{
  /// <summary>
  /// Represents a responding person
  /// </summary>
  [Serializable]
  public class Person: ResponseResourceKind
    {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the Person class
    /// </summary>
    public Person()
    {
      SerialID = new IdentificationID();
      EstimatedArrival = new DateTime();
      EstimatedAvailability = new DateTimeRange();
    }

    /// <summary>
    /// Initializes a new instance of the Person class
    /// </summary>
    /// <param name="perID">The Identitication ID</param>
    /// <param name="aval">(Optional) The Estimated Availability</param>
    /// <param name="arrival">(Optional) The Estimated Arrival</param>
    /// <param name="ra">(Optional) The Rank</param>
    /// <param name="cr">(Optional) The Credential List</param>
    public Person(IdentificationID perID, DateTimeRange aval = null,  DateTime? arrival = null, Rank ra = null, List<Credential> cr = null)
    {
      SerialID = perID;
      EstimatedArrival = (arrival != null) ? (DateTime)arrival : new DateTime();
      EstimatedAvailability = (aval != null) ? aval : new DateTimeRange();

      Rank = ra;
      Credentials = cr;
    }

    /// <summary>
    /// Initializes a new instance of the Person class
    /// </summary>
    /// <param name="perID">The Identitication ID as a string</param>
    /// <param name="arrival">(Optional) The Estimated Arrival</param>
    /// <param name="aval">(Optional) The Estimated Availability</param>
    /// <param name="ra">(Optional) The Rank</param>
    /// <param name="cr">(Optional) The Credential List</param>
    public Person(string perID, DateTimeRange aval = null, DateTime? arrival = null, Rank ra = null, List<Credential> cr = null) : this(new IdentificationID(perID), aval, arrival, ra, cr)
    {
    }

    #endregion

    #region Public Fields

    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "PersonHumanResourceIdentification", Namespace = Constants.NiemcoreNamespace, Order = 1)]
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
    /// Gets or sets the Person ID as a string
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
	/// Gets of sets the Estimated Arrival in UTC
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

    /// <summary>
    /// Gets or sets the Person's Rank
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "AidRespondingRank", Namespace = Constants.MaidNamespace, Order = 3)]
    public Rank Rank
    {
      get
      {
        return rank;
      }

      set
      {
        rank = value;
      }

    }

    /// <summary>
    /// Gets or sets the list of Credentials
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlElement(ElementName = "AidRespondingCredential", Namespace = Constants.MaidNamespace, Order = 4)]
    public List<Credential> Credentials
    {
      get
      {
        return credentials;
      }

      set
      {
        credentials = value;
      }

    }

    #endregion

    #region Private Fields

    /// <summary>
    /// Gets or sets the ID
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private IdentificationID id;

    /// <summary>
    /// Gets of sets the Estimated Arrival in UTC
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private DateTime estimatedArrival;

    /// <summary>
    /// Gets or sets the Estimated Availability as a DateTimeRange 
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private DateTimeRange estimatedAvailability;

    /// <summary>
    /// Gets or sets the Person's Rank
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private Rank rank;

    /// <summary>
    /// Gets or sets the list of Credentials
    /// </summary>
    /// <remarks>
    /// Optional Element
    /// </remarks>
    [XmlIgnore]
    private List<Credential> credentials;
    #endregion

    #region Serial methods

    /// <summary>
    /// If Credentials list is empty then it will not be serialized 
    /// </summary>
    /// <returns>true or false</returns>
    public bool ShouldSerializeCredentials()
    {
      return (Credentials != null)
          && (Credentials.Count > 0);
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Sets the Person ID
    /// </summary>
    /// <param name="personID">The ID</param>
    public void SetID(IdentificationID personID)
    {
      SerialID = personID;
    }

    /// <summary>
    /// Sets the Person ID
    /// </summary>
    /// <param name="personID">The ID as a string</param>
    public void SetID(string personID)
    {
      ID = personID;
    }

    /// <summary>
    /// Adds the value(s) to the Credentials List
	/// Value can not be null
    /// </summary>
    /// <param name="c">Credentials as List</param>
    public void AddCredential(List<Credential> c)
    {
      if (Credentials == null) Credentials = new List<Credential>();
      Credentials.AddRange(c);
    }

	/// <summary>
	/// Adds the value(s) to the Credentials List
	/// Value can not be null
	/// </summary>
	/// <param name="c">Credential</param>
	public void AddCredential(Credential c)
    {
       AddCredential(new List<Credential> {c });
    }

	/// <summary>
	/// Adds the value(s) to the Credentials List
	/// Value can not be null
	/// </summary>
	/// <param name="c">Credentials as Array</param>
	public void AddCredential(Credential[] c)
    {
      AddCredential(c.ToList());
    }

    /// <summary>
    /// Creates a new credential for this Person based on the given value
    /// </summary>
    /// <param name="valueText">The Value text for the rank</param>
    /// <param name="vAugmenPoint">(Optional) Value List URN Text</param>
    /// <param name="vListUrn">(Optional) Value Augmentation Point</param>
    public void AddCredential(string valueText, string vListUrn = null, string vAugmenPoint = null)
    {
      Credential c = new Credential(valueText, vListUrn, vAugmenPoint);
      AddCredential(c);
    }

	/// <summary>
	/// Sets the Rank
	/// </summary>
	/// <param name="r">The Rank</param>
	public void SetRank(Rank r)
	{
	  Rank = r;
	}

	/// <summary>
	/// Creates a new rank for this Person based on the given value
	/// </summary>
	/// <param name="valueText">The Value text for the rank</param>
	/// <param name="vAugmenPoint">(Optional) Value List URN Text</param>
	/// <param name="vListUrn">(Optional) Value Augmentation Point</param>
	public void SetRank(string valueText, string vListUrn = null, string vAugmenPoint = null)
    {
      Rank = new Rank(valueText, vListUrn, vAugmenPoint);
    }

    /// <summary>
    /// Sets the Estimated Availability Range
    /// </summary>
    /// <param name="avalRange">The DateTimeRange</param>
    public void setEstimatedAvalRange(DateTimeRange avalRange)
    {
      EstimatedAvailability = avalRange;
    }

    /// <summary>
    /// Sets the Estimated Availability Range
    /// </summary>
    /// <param name="start">Start Date</param>
    /// <param name="end">End Date</param>
    public void setEstimatedAvalRange(DateTime start, DateTime end)
    {
      setEstimatedAvalRange(new DateTimeRange(start, end));
    }
    #endregion

  }
}
