using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.NIEM.MutualAid
{
  
  /// <summary>
  /// Utility class for Mutual Aid
  /// </summary>
  public static class MutualAidUtil
  {
    /// <summary>
    /// Returns true is this is a MissionNeed Resource
    /// </summary>
    /// <param name="res">The Resource</param>
    /// <returns>Returns true is this is a MissionNeed Resource, false otherwise</returns>
    public static bool isResourceMissionNeed(RequestResourceKind res)
    {
      MissionNeed resource = new MissionNeed();

      if (resource.GetType().Name == res.GetType().Name)
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Returns true is this is a Generic Resource
    /// </summary>
    /// <param name="res">The Resource</param>
    /// <returns>Returns true is this is a Generic Resource, false otherwise</returns>
    public static bool isResourceGeneric(RequestResourceKind res)
    {
      GenericResource resource = new GenericResource();

      if (resource.GetType().Name == res.GetType().Name)
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Returns true is this is a Specific Resource
    /// </summary>
    /// <param name="res">The Resource</param>
    /// <returns>Returns true is this is a Specific Resource, false otherwise</returns>
    public static bool isResourceSpecific(RequestResourceKind res)
    {
      SpecificResource resource = new SpecificResource();

      if (resource.GetType().Name == res.GetType().Name)
      {
        return true;
      }

      return false;
    }



  }
}
