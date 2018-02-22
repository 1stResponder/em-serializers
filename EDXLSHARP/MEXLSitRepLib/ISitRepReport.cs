// ———————————————————————–
// <copyright file="ISitRepReport.cs" company="EDXLSharp">
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

using System;
using System.ServiceModel.Syndication;
using System.Xml;
using EDXLSharp;

namespace MEXLSitRepLib
{
  /// <summary>
  /// Class for Standardizing Internal Functions To This Assembly
  /// </summary>
  [Serializable]
  public abstract partial class ISitRepReport
  {
    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal abstract void WriteXML(XmlWriter xwriter);

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal abstract void ReadXML(XmlNode rootnode);

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Syndication Item to Populate</param>
    internal abstract void ToGeoRSS(SyndicationItem myitem);

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal abstract void SetContentKeywords(ValueList ckw);

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected abstract void Validate();
  }
}
