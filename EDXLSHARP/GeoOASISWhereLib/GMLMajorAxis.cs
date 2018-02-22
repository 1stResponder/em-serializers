// ———————————————————————–
// <copyright file="GMLMajorAxis.cs" company="EDXLSharp">
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

using EDXLSharp;

namespace GeoOASISWhereLib
{
  /// <summary>
  /// Represents a major axis
  /// </summary>
  public class GMLMajorAxis : GMLLengthType
  {
    /// <summary>
    /// Gets the name of the element
    /// </summary>
    public override string ElementName
    {
      get { return "majorAxis"; }
    }

    /// <summary>
    /// Gets the namespace of the element
    /// </summary>
    public override string ElementNamespace
    {
      get { return EDXLConstants.GMLNamespace; }
    }

    /// <summary>
    /// Gets the XML namespace prefix
    /// </summary>
    public override string ElementPrefix
    {
      get { return EDXLConstants.GMLPrefix; }
    }
  }
}