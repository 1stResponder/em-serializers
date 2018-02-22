//-----------------------------------------------------------------------
// <copyright file="IncidentEIDDStatusCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Incident
{
  /// <summary>
  /// EIDD Resource Status Wrapper
  /// </summary>
  [Serializable]
  public class IncidentEIDDStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the resource type code
    /// </summary>
    [XmlElement(ElementName = "IncidentEIDDCode")]
    public IncidentEIDDStatusCodeList EIDDCode      
    {
      get; set;
    }
  }
}
