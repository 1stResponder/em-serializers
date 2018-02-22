// ———————————————————————–
// <copyright file="HaveEnumUtils.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// Class to Handle Invalid Characters in HAVE Enumerations
  /// </summary>
  internal static class HAVEEnumUtils
  {
    /// <summary>
    /// Static Method to Return a string for CapacityStatus Enum
    /// </summary>
    /// <param name="type">CapacityStatus Enum Value</param>
    /// <returns>String that is valid to the schema</returns>
    internal static string CapacityStatusToString(CapacityStatusType? type)
    {
      if (type == null)
      {
        return null;
      }

      switch (type)
      {
        case CapacityStatusType.Vacant_Available:
          return "Vacant/Available";
        case CapacityStatusType.NotAvailable:
          return "NotAvailable";
      }

      return null;
    }

    /// <summary>
    /// Status Method to Parse a CapacityStatus Enum from a String
    /// </summary>
    /// <param name="input">Input String to Parse</param>
    /// <returns>CapacityStatus Enumeration</returns>
    internal static CapacityStatusType StringToCapacityStatus(string input)
    {
      if (input == null)
      {
        return CapacityStatusType.NotAvailable;
      }
      else if (input.Equals("Vacant/Available"))
      {
        return CapacityStatusType.Vacant_Available;
      }
      else if (input.Equals("NotAvailable"))
      {
        return CapacityStatusType.NotAvailable;
      }
      else
      {
        return CapacityStatusType.NotAvailable;
      }
    }
  }
}
