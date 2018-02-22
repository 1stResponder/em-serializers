//-----------------------------------------------------------------------
// <copyright file="LocationCreationCodeList.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// Code list of location creation codes
  /// </summary>
  [Serializable]
  public enum LocationCreationCodeList
  {
    /// <summary>
    /// Human created
    /// </summary>
    HUMAN,

    /// <summary>
    /// Human - estimated
    /// </summary>
    HUMAN_ESTIMATED,

    /// <summary>
    /// Human - calculated
    /// </summary>
    HUMAN_CALCULATED,

    /// <summary>
    /// Human - cut and paste
    /// </summary>
    HUMAN_CUTANDPASTE,

    /// <summary>
    /// Machine created
    /// </summary>
    MACHINE,

    /// <summary>
    /// Machine - mensurated
    /// </summary>
    MACHINE_MENSURATED,

    /// <summary>
    /// Machine - GPS
    /// </summary>
    MACHINE_GPS,

    /// <summary>
    /// Machine - magnetic
    /// </summary>
    MACHINE_MAGNETIC,

    /// <summary>
    /// Machine - simulated
    /// </summary>
    MACHINE_SIMULATED,

    /// <summary>
    /// Machine - fused
    /// </summary>
    MACHINE_FUSED,

    /// <summary>
    /// Machine - configured
    /// </summary>
    MACHINE_CONFIGURED,

    /// <summary>
    /// Machine - predicted
    /// </summary>
    MACHINE_PREDICTED,

    /// <summary>
    /// Machine - relayed
    /// </summary>
    MACHINE_RELAYED
  }
}
