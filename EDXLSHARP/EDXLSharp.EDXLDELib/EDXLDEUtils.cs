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

using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EDXLSharp.EDXLDELib
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
    /// <param name="imsg">Object That Implements the IContentObject Interface</param>
    /// <returns>Boxed IContentObject Message in a DE Content Object</returns>
    /// <exception cref="ArgumentNullException">ismg is null</exception>
    /// <seealso cref="ContentObject"/>
    public static ContentObject Box(IContentObject imsg)
    {
      if (imsg == (IContentObject)null)
      {
        throw new ArgumentNullException("Input Object Can't Be Null");
      }

      ContentObject contentobj = new ContentObject();
      ValueList ckw = new ValueList();
      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      contentobj.ContentDescription = imsg.SetContentKeywords(ckw);
      contentobj.ContentKeyword.Add(ckw);
      XMLContentType xcontent = new XMLContentType();
      StringBuilder sb = new StringBuilder();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.CloseOutput = true;
      xsettings.Encoding = Encoding.UTF8;
      xsettings.Indent = true;
      xsettings.OmitXmlDeclaration = true;
      XmlWriter xwriter = XmlWriter.Create(sb, xsettings);
      imsg.WriteXML(xwriter);
      xwriter.Flush();
      xwriter.Close();
      string s = sb.ToString();
      sb = null;

      // imsg.ValidateToSchema(s);
      XElement xe = XElement.Parse(s);
      xcontent.EmbeddedXMLContent.Add(xe);
      contentobj.XMLContent = xcontent;
      ckw = null;
      xcontent = null;
      xwriter = null;

      return contentobj;
    }
  }
}