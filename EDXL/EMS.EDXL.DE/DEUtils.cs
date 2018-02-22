// ———————————————————————–
// <copyright file="EDXLDEUtils.cs" company="EDXLSharp">
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

using EMS.EDXL.CT;
using EMS.EDXL.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// Static Class To Preform Common Operations on DE Messages
  /// </summary>
  [Serializable]
  public static partial class EDXLDEUtils
  {
    /// <summary>
    /// Boxes any Object The Implements the IContentObjectInterface into a DE Content Object
    /// </summary>
    /// <param name="content">Object That Implements the IContentObject Interface</param>
    /// <returns>Boxed IContentObject Message in a DE Content Object</returns>
    /// <exception cref="ArgumentNullException">content is null</exception>
    /// <seealso cref="ContentObject"/>
    public static ContentObject Box(IContentObject content)
    {
      if (content == (IContentObject)null)
      {
        throw new ArgumentNullException("Input Object Can't Be Null");
      }

      ContentObject contentobj = new ContentObject();
      contentobj.ContentDescription = content.Description;
      contentobj.ContentKeyword = FromListofCTValueList(content.Keywords);

      XMLContentType xcontent = new XMLContentType();
      string s = content.ToXmlString();
     
      // imsg.ValidateToSchema(s);
      XElement xe = XElement.Parse(s);
      xcontent.EmbeddedXMLContent.Add(xe);
      contentobj.XMLContent = xcontent;

      xcontent = null;

      return contentobj;
    }

    /// <summary>
    /// DE.ValueList to CT.ValueList
    /// </summary>
    /// <param name="deValueList">DE.ValueList</param>
    /// <returns>CT.ValueList</returns>
    public static CT.ValueList FromDEValueList(DE.ValueList deValueList)
    {
      return new CT.ValueList(deValueList.ValueListURN, deValueList.Value);
    }

    /// <summary>
    /// CT.ValueList to DE.ValueList
    /// </summary>
    /// <param name="ctValueList">CT.ValueList</param>
    /// <returns>DE.ValueList</returns>
    public static DE.ValueList FromCTValueList(CT.ValueList ctValueList)
    {
      return new DE.ValueList(ctValueList.ValueListURI, ctValueList.Value);
    }

    /// <summary>
    /// List of DE.ValueList to List of CT.ValueList
    /// </summary>
    /// <param name="deValueList">List of DE.ValueList</param>
    /// <returns>DE of CT.ValueList</returns>
    public static List<CT.ValueList> FromListofDEValueList(List<DE.ValueList> deValueList)
    {
      List<CT.ValueList> ctValueLists = null;

      if (deValueList != null)
      {
        ctValueLists = new List<CT.ValueList>();
      }

      foreach (DE.ValueList vl in deValueList)
      {
        CT.ValueList ctValueList = new CT.ValueList(vl.ValueListURN, vl.Value);
        ctValueLists.Add(ctValueList);
      }

      return ctValueLists;
    }

    /// <summary>
    /// List of CT.ValueList to List of DE.ValueList
    /// </summary>
    /// <param name="ctValueList">List of CT.ValueList</param>
    /// <returns>List of DE.ValueList</returns>
    public static List<DE.ValueList> FromListofCTValueList(List<CT.ValueList> ctValueList)
    {
      List<DE.ValueList> deValueLists = null;

      if (ctValueList != null)
      {
        deValueLists = new List<DE.ValueList>();
      }

      foreach (CT.ValueList vl in ctValueList)
      {
        DE.ValueList deValueList = new DE.ValueList(vl.ValueListURI, vl.Value);
        deValueLists.Add(deValueList);
      }

      return deValueLists;
    }
  }
}