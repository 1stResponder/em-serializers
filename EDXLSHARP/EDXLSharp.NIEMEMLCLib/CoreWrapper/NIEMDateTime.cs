//-----------------------------------------------------------------------
// <copyright file="NIEMDateTime.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the NIEM wrapper for a date and time
  /// </summary>
  public class NIEMDateTime
  {
    /// <summary>
    /// Initializes a new instance of the NIEMDateTime class
    /// </summary>
    public NIEMDateTime()
    {
    }

    /// <summary>
    /// Initializes a new instance of the NIEMDateTime class
    /// </summary>
    /// <param name="datetime">The date and time</param>
    public NIEMDateTime(DateTime datetime)
    {
      this.DateTime = datetime;
    }

    /// <summary>
    /// Gets or sets the date and time 
    /// </summary>
    [XmlElement(Namespace = Constants.NiemcoreNamespace)]
    public DateTime DateTime
    {
      get; set;
    }
  }
}