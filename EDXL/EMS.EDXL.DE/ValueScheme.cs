// ———————————————————————–
// <copyright file="ValueScheme.cs" company="EDXLSharp">
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

using EMS.EDXL.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.DE
{
  /// <summary>
  /// The identifier of an explicit recipient
  /// </summary>
  [Serializable]
  public partial class ValueScheme
  {
    #region Private Member Variables
    /// <summary>
    /// Identifies the distribution addressing scheme used. 
    /// Required Element
    /// </summary>
    /// <seealso cref="ExplicitAddressScheme"/>
    private string explicitAddressScheme;

    /// <summary>
    /// A properly formed -escaped if necessary- XML string denoting the addressees value. 
    /// </summary>
    /// <seealso cref="ExplicitAddressValue"/>
    private List<string> explicitAddressValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ValueScheme class
    /// Default Constructor - Initializes List
    /// </summary>
    public ValueScheme()
    {
      this.explicitAddressValue = new List<string>();
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets ExplicitAddressScheme
    /// Required Element
    /// </summary>
    /// <value>Identifies the distribution addressing scheme used.</value>
    /// <remarks>Examples for this type of distribution includes - email, military USMTF, etc. . .</remarks>
    /// <seealso cref="explicitAddressScheme"/>
    [XmlElement(ElementName = "explicitAddressScheme", Order = 0)]
    [JsonProperty("explicitAddressScheme", NullValueHandling = NullValueHandling.Ignore)]
    public string ExplicitAddressScheme
    {
      get { return this.explicitAddressScheme; }
      set
      {
        this.explicitAddressScheme = value;
        Validate();
      }
    }

    /// <summary>
    /// Gets or sets the ExplicitAddressValue
    /// </summary>
    /// <value>A properly formed -escaped if necessary- XML string denoting the addressees value. </value>
    /// <remarks>For serialization/deserialization</remarks>
    /// <seealso cref="explicitAddressValue"/>
    [XmlElement(ElementName = "explicitAddressValue", Order = 1)]
    [JsonProperty("explicitAddressValue", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> ExplicitAddressValue
    {
      get { return this.explicitAddressValue; }
      set { this.explicitAddressValue = value; }
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Validates This Message Element For Required Values and Conformance
    /// </summary>
    /// <exception cref="ArgumentException">ExplicitAddressScheme is null or empty</exception>
    public void Validate()
    {
      if (string.IsNullOrWhiteSpace(this.explicitAddressScheme))
      {
        throw new ArgumentException("ExplicitAddressScheme Can't Be Null or Empty!");
      }
    }
    #endregion

    #region Private Member Functions
    #endregion
  }
}
