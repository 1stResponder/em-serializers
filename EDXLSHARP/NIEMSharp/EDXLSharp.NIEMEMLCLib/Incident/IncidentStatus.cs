//-----------------------------------------------------------------------
// <copyright file="IncidentStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Incident
{

  /// <summary>
  /// Represents the status of an incident
  /// </summary>
  [Serializable]
  public class IncidentStatus
  {

    /// <summary>
    /// Gets or sets the primary status of this incident
    /// TODO revist this type - EventTypeCodeList
    /// </summary>
    [XmlElement(ElementName = "IncidentPrimaryStatus")]
    public IncidentPrimaryStatusCodeList PrimaryStatus
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the secondary status of this incident
    /// </summary>
    [XmlElement("IncidentEIDDStatus", typeof(IncidentEIDDStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("IncidentPulsePointStatus", typeof(IncidentPulsePointStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("IncidentSecondaryStatusText", typeof(TextStatus), Namespace = Constants.EmlcNamespace)]
    public List<AltStatus> SecondaryStatus
    {
      get; set;
    }

  }
}
