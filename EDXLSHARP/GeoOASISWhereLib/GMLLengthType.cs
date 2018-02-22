// ———————————————————————–
// <copyright file="GMLLengthType.cs" company="EDXLSharp">
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

namespace GeoOASISWhereLib
{
  /// <summary>
  /// This is a prototypical definition for a specific measure type defined as
  /// a vacuous extension . In this case, the
  /// content model supports the description of a length (or distance) quantity,
  /// with its units. The unit of measure referenced by unit of measure shall be suitable
  /// for a length, such as meters or feet.
  /// </summary>
  public abstract class GMLLengthType : GMLMeasureType
  {
  }
}