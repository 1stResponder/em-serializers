// ———————————————————————–
// <copyright file="ITEPComposableObject.cs" company="EDXLSharp">
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
using System.Xml;

namespace MEXLTEPLib
{
  /// <summary>
  /// Class for Standardizing Internal Functions To This Assembly
  /// </summary>
  [Serializable]
  public abstract partial class IComposable
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
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected abstract void Validate();
  }
}
