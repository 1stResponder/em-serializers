using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  /// <summary>
  /// Data Structure to Represent a Unique name and an associated list of values
  /// </summary>
  [Serializable]
  public class TimePeriod
  {
    #region Private Member Variables
    /// <summary>
    /// The Beginning DateTime in the Period
    /// </summary>
    private EDXLDateTime fromDateTime;

    /// <summary>
    /// The Ending DateTime in the Period
    /// </summary>
    private EDXLDateTime toDateTime;

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// The Beginning DateTime in the Period
    /// </summary>
    [XmlElement(ElementName = "fromDateTime", Order = 1)]
    public EDXLDateTime FromDateTime
    {
      get { return this.fromDateTime; }
      set { this.fromDateTime = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The Ending DateTime in the Period
    /// </summary>
    [XmlElement(ElementName = "toDateTime", Order = 2)]
    public EDXLDateTime ToDateTime
    {
      get { return this.toDateTime; }
      set { this.toDateTime = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Determines whether or not the data in this object is valid
    /// </summary>
    public void Validate()
    {
      if (this.toDateTime == DateTime.MinValue)
      {
        throw new Exception("toDateTime is mandatory");
      }

      if (this.fromDateTime == DateTime.MinValue)
      {
        throw new Exception("fromDateTime is mandatory");
      }
    }
    #endregion
  }
}
