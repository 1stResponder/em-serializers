// ———————————————————————–
// <copyright file="SerializableDictionary.cs" company="EDXLSharp">
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
// From http://weblogs.asp.net/pwelter34/archive/2006/05/03/444961.aspx

using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// Class that can be used to serialize a dictionary object
  /// </summary>
  /// <typeparam name="TKey">Template Dictionary Key</typeparam>
  /// <typeparam name="TValue">Template Dictionary Values</typeparam>
  [XmlRoot("dictionary")]
  public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
  {
    #region IXmlSerializable Members

    /// <summary>
    /// Method to return the Schema Item
    /// </summary>
    /// <returns>Null for now</returns>
    public System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    /// <summary>
    /// Overloaded ReadXml Method to Manually Parse a Dictionary
    /// </summary>
    /// <param name="reader">XmlReader to Use</param>
    public void ReadXml(System.Xml.XmlReader reader)
    {
      XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
      bool wasEmpty = reader.IsEmptyElement;
      reader.Read();
      if (wasEmpty)
      {
        return;
      }

      while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
      {
        reader.ReadStartElement("item");
        reader.ReadStartElement("key");
        TKey key = (TKey)keySerializer.Deserialize(reader);
        reader.ReadEndElement();
        reader.ReadStartElement("value");
        TValue value = (TValue)valueSerializer.Deserialize(reader);
        reader.ReadEndElement();
        this.Add(key, value);
        reader.ReadEndElement();
        reader.MoveToContent();
      }

      reader.ReadEndElement();
    }

    /// <summary>
    /// Overloaded Write Method to Manually Write a Dictionary
    /// </summary>
    /// <param name="writer">XMLWriter to Use</param>
    public void WriteXml(System.Xml.XmlWriter writer)
    {
      XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
      foreach (TKey key in this.Keys)
      {
        writer.WriteStartElement("item");
        writer.WriteStartElement("key");
        keySerializer.Serialize(writer, key);
        writer.WriteEndElement();
        writer.WriteStartElement("value");
        TValue value = this[key];
        valueSerializer.Serialize(writer, value);
        writer.WriteEndElement();
        writer.WriteEndElement();
      }
    }

    #endregion
  }
}
