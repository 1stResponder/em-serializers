//-----------------------------------------------------------------------
// <copyright file="IncidentEIDDStatusCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using EMS.NIEM.NIEMCommon;
using System;
using System.Xml.Serialization;

namespace EMS.NIEM.Incident
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


    public override string GetSecondaryStatusText()
    {
      return $"EIDDCode:  {EIDDCode.ToString()}";
    }
  }
}
