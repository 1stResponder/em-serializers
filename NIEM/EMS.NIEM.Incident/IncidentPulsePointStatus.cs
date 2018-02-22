//-----------------------------------------------------------------------
// <copyright file="IncidentPulsePointStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.Incident
{
    /// <summary>
    /// Represents a pulse point status of an incident
    /// </summary>
    [Serializable]
    public class IncidentPulsePointStatus : AltStatus
  {
    /// <summary>
    /// Gets or sets the pulse point status code
    /// </summary>
    /// 
    [XmlElement(ElementName = "IncidentPulsePointCode")]
    public IncidentPulsePointStatusCodeList PulsePointCode
    {
      get; set;
    }


    public override string GetSecondaryStatusText()
    {
      return $"PulsePointCode:  {PulsePointCode.ToString()}";
    }
  }
}
