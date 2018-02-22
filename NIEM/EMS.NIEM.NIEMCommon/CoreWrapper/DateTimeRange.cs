using System;
//using Newtonsoft.Json;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Represents a DateTime Range
  /// </summary>
  [Serializable]
  public class DateTimeRange
  {

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the DateTimeRange class
    /// </summary>
    public DateTimeRange()
    {
      StartDate = new DateTime();
      EndDate = new DateTime();
    }

    /// <summary>
    /// Initializes a new instance of the DateTimeRange class
    /// </summary>
    /// <param name="start">Start date</param>
    /// <param name="end">end date</param>
    public DateTimeRange(DateTime start, DateTime end)
    {
      StartDate = start.ToUniversalTime();
      EndDate = end.ToUniversalTime();
    }

    #endregion

    #region Public Fields
    /// <summary>
    /// Gets/Sets the End Date
    /// </summary>
    [XmlIgnore]
    public DateTime EndDate
    {
      get
      {
        return endDate.ToUniversalTime();
      }
      set
      {
        endDate = value.ToUniversalTime();
      }
    }

    /// <summary>
    /// Gets/Sets the startDate
    /// </summary>
    [XmlIgnore]
    public DateTime StartDate
    {
      get
      {
        return startDate.ToUniversalTime();
      }
      set
      {
        startDate = value.ToUniversalTime();
      }
    }

    #endregion
    #region Private Fields

    /// <summary>
    /// Gets or sets the Start DateTime in UTC
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private DateTime startDate;


    /// <summary>
    /// Gets or sets the End DateTime in UTC
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlIgnore]
    private DateTime endDate;

    #endregion

    #region Serial Fields

    /// <summary>
    /// Gets or Sets Start Date as string 
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "StartDate", Namespace = Constants.NiemcoreNamespace, Order = 1)]
    public NIEMDateTime SerialStartDate
    {
      get
      {
        return new NIEMDateTime(this.startDate);
      }

      set
      {
        this.startDate = value.DateTime;
      }
    }

    /// <summary>
    /// Gets or Sets End Date as string 
    /// </summary>
    /// <remarks>
    /// Required Element
    /// </remarks>
    [XmlElement(ElementName = "EndDate", Namespace = Constants.NiemcoreNamespace, Order = 2)]
    public NIEMDateTime SerialEndDate
    {
      get
      {
        return new NIEMDateTime(this.endDate);
      }

      set
      {
        this.endDate = value.DateTime;
      }
    }

    #endregion
  }
}
