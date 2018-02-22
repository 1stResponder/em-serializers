// ———————————————————————–
// <copyright file="NameObject.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLTestApplication
{
  /// <summary>
  /// Container intended to hold the name of a XML object and the XML object
  /// </summary>
  /// <typeparam name="N">String value</typeparam>
  /// <typeparam name="V">Object value</typeparam>
  [Serializable]
  public class NameObject<N, V>
  {
    /// <summary>
    /// Initializes a new instance of the NameObject class
    /// </summary>
    public NameObject() 
    { 
    }

    /// <summary>
    /// Initializes a new instance of the NameObject class
    /// </summary>
    /// <param name="name">Name of the NameObject</param>
    /// <param name="value">Object value of the NameObject</param>
    public NameObject(N name, V value)
    {
      this.Name = name;
      this.Value = value;
    }

    /// <summary>
    /// Gets or sets the name of the object
    /// </summary>
    public N Name { get; set; }

    /// <summary>
    /// Gets or sets the value of the object
    /// </summary>
    public V Value { get; set; }
  }
}