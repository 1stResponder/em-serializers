// ———————————————————————–
// <copyright file="ComplexTypeBase.cs" company="EDXLSharp">
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
using System.Xml;

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// Consolidated abstract base class for XML complexTypes
  /// that appear under different element names
  /// </summary>
  [Serializable]
  public abstract class ComplexTypeBase : IComposable
  {
    /// <summary>
    /// Gets the name of the XML element
    /// </summary>
    public abstract string ElementName { get; }

    /// <summary>
    /// Gets the XML namespace of the element
    /// </summary>
    public abstract string ElementNamespace { get; }

    /// <summary>
    /// Gets the prefix of the XML element name
    /// </summary>
    public abstract string ElementPrefix { get; }

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    /// <exception cref="System.ArgumentNullException">Thrown if XMLWriter is null</exception>
    /// <exception cref="ValidationException">Thrown if the object fails to validate</exception>
    public abstract void WriteXML(XmlWriter xwriter);

   /* /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="root">root XML Node of the Object element</param>
    /// <exception cref="System.ArgumentNullException">Thrown if root is null</exception>
    /// <exception cref="System.ArgumentException">Thrown if the root is not the correct type</exception>
    /// <exception cref="ValidationException">Thrown if the object fails to validate</exception>
    //public abstract void ReadXML(XmlNode root);*/

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    /// <exception cref="ValidationException">Thrown if the object fails to validate</exception>
    public abstract void Validate();
  }
}
