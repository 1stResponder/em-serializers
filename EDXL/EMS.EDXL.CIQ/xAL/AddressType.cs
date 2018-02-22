// ———————————————————————–
// <copyright file="Address.cs" company="EDXLSharp">
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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Complex type that defines the structure of an address with geocode details for reuse
  /// </summary>
  [Serializable]
  public class AddressType
  {
    [XmlArray("freeTextAddress")]
    [XmlArrayItem("addressLine")]
    public List<string> freeTextAddress { get; set; }

    [XmlIgnore]
    public bool freeTextAddressSpecified { get { return freeTextAddress != null && freeTextAddress.Count > 0; } }

    /// <summary>
    /// The name of the country.
    /// </summary>
    [XmlElement("country")]
    public CountryType country;

    [XmlIgnore]
    public bool countrySpecified { get { return country != null; } }

    /// <summary>
    /// Details of the top level area division in the country. ex: State, District, Province etc.
    /// </summary>
    [XmlElement("administrativeArea")]
    public AdministrativeAreaType administrativeArea;

    [XmlIgnore]
    public bool administrativeAreaSpecified { get { return administrativeArea != null; } }

    /// <summary>
    /// Details of a locality, which is a named densely populated area, such as a town, village, suburb, etc.
    /// </summary>
    [XmlElement("locality")]
    public LocalityType locality;

    [XmlIgnore]
    public bool localitySpecified { get { return locality != null; } }

    /// <summary>
    /// A name of a thoroughfare
    /// </summary>
    [XmlElement("thoroughfare")]
    public ThoroughfareType thoroughfare;

    [XmlIgnore]
    public bool thoroughfareSpecified { get { return thoroughfare != null; } }

    /// <summary>
    /// A container for a single free text or structured post code.
    /// </summary>
    [XmlElement("postCode")]
    public IdentifierType postCode;

    [XmlIgnore]
    public bool postCodeSpecified { get { return postCode != null; } }

  }
}