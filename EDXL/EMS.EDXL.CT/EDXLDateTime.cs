using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  /// <summary>
  /// DateTime wrapper class to support EDXL DateTime format
  /// </summary>
  public struct EDXLDateTime
  {
    private DateTime _RealDateTime;

    /// <summary>
    /// EDXL DateTime Format
    /// </summary>
    [XmlText]
    public string EDXLCustomFormat
    {
      get { return _RealDateTime.ToUniversalTime().ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssK"); }
      set { _RealDateTime = System.DateTime.Parse(value); }
    }

    /// <summary>
    /// DateTime/EDXL conversion
    /// </summary>
    /// <param name="custom">EDXLDateTime</param>
    public static implicit operator DateTime(EDXLDateTime custom)
    {
      return custom._RealDateTime;
    }

    /// <summary>
    /// DateTime/EDXL conversion
    /// </summary>
    /// <param name="datetime">DateTime</param>
    public static implicit operator EDXLDateTime(DateTime datetime)
    {
      return new EDXLDateTime { _RealDateTime = datetime };
    }
  }
}
