//-----------------------------------------------------------------------
// <copyright file="AltStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------


namespace EMS.NIEM.NIEMCommon
{
  /// <summary>
  /// Abstract class for creating approved secondary statuses
  /// </summary>
  public abstract class AltStatus
  {
    /// <summary>
    /// Method for derived to override to provide a string representation of whatever
    /// secondary status should be associated with the object of that class.
    /// </summary>
    /// <returns></returns>
    public abstract string GetSecondaryStatusText();
  }
}
