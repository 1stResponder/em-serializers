// ———————————————————————–
// <copyright file="Helper.cs" company="EDXLSharp">
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
// ———————————————————————–

using System.Collections.Generic;
using System.Windows.Forms;

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// Common items used by multiple features of the test app
  /// </summary>
  public static class Helper
  {
#region Public Delegates/Events

#endregion

#region Private Member Variables

#endregion

#region Public Accessors

#endregion

#region Constructors

#endregion

#region Public Member Functions
    /// <summary>
    /// Removes selected items from the passed ListBox object
    /// </summary>
    /// <param name="mLB">ListBox object to remove selected values form</param>
    /// <returns>null for success, else error message</returns>
    public static string MRemoveSelectedValuesFromListBox(ListBox mLB)
    {
      if (mLB != null && mLB.SelectedItems.Count > 0)
      {
        List<object> obj = new List<object>();
        foreach (object myobj in mLB.SelectedItems)
        {
          obj.Add(myobj);
        }

        foreach (object obje in obj)
        {
          mLB.Items.Remove(obje);
        }
      }
      else
      {
        return "Removing ListBox items: but no items selectd";
      }

      return null;
    }
  }

#endregion

#region Protected Member Functions

#endregion

#region Private Member Functions

#endregion
}
