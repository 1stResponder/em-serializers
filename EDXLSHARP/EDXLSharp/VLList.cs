// ———————————————————————–
// <copyright file="VLList.cs" company="EDXLSharp">
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp
{
  /// <summary>
  /// List wrapper for ValueList objects for a given root element
  /// </summary>
  [Serializable]
  public class VLList : ComplexTypeBase, IList<ValueList>
  {
    /// <summary>
    /// ValueLists for internal use
    /// </summary>
    private List<ValueList> valueLists;

    /// <summary>
    /// Name of the Root Element
    /// </summary>
    private string rootElementName;

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the VLList class
    /// Default Constructor - Initializes List
    /// </summary>
    public VLList() : base()
    {
      this.rootElementName = string.Empty;
      this.valueLists = new List<ValueList>();
    }

    /// <summary>
    /// Initializes a new instance of the VLList class
    /// </summary>
    /// <param name="rootName">Root Element Name</param>
    public VLList(string rootName) : this()
    {
      this.rootElementName = rootName;
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Wrapping XML Element Name
    /// </summary>
    public override string ElementName
    {
      get { throw new NotImplementedException(); }
    }

    /// <summary>
    /// Wrapping XML Element Namespace
    /// </summary>
    public override string ElementNamespace
    {
      get { throw new NotImplementedException(); }
    }

    /// <summary>
    /// Wrapping XML Element Namespace Prefix
    /// </summary>
    public override string ElementPrefix
    {
      get { throw new NotImplementedException(); }
    }

    /// <summary>
    /// Gets or sets the RootElementName
    /// </summary>
    [XmlIgnore]
    public string RootElementName
    {
      get { return this.rootElementName; }
      set { this.rootElementName = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A list of ValueLists
    /// </summary>
    [XmlIgnore]
    public IList<ValueList> Values
    {
      get
      {
        return this.ToList<ValueList>();
      }

      set
      {
        this.Clear();
        this.AddRange(value);
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Values
    /// </summary>
    public ValueList[] ValuesXML
    {
      get
      {
        if (this.Count() == 0)
        {
          return null;
        }
        else
        {
          return this.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.Clear();
          this.AddRange(value);
        }
      }
    }

    /// <summary>
    /// Gets a value indicating whether the collection is read only
    /// </summary>
    public bool IsReadOnly
    {
      get { return ((ICollection<ValueList>)this.valueLists).IsReadOnly; }
    }

    /// <summary>
    /// Gets number of items in the list
    /// </summary>
    public int Count
    {
      get { return this.valueLists.Count; }
    }

    /// <summary>
    /// Returns the ValueList item at a specified index
    /// </summary>
    /// <param name="index">Index of the array value to return</param>
    /// <returns>ValueList at the specified index</returns>
    public ValueList this[int index]
    {
      get
      {
        return this.valueLists[index];
      }

      set
      {
        this.valueLists[index] = value;
      }
    }

    /// <summary>
    /// Gets an enumerator for the collection
    /// </summary>
    /// <returns>Enumerator for the collection</returns>
    public IEnumerator<ValueList> GetEnumerator()
    {
      return this.valueLists.GetEnumerator();
    }

    /// <summary>
    /// Gets an enumerator for the collection
    /// </summary>
    /// <returns>Enumerator for the collection</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.valueLists.GetEnumerator();
    }

    #endregion

    #region Public Member Functions

    /// <summary>
    /// Method to determine if a given ValueList exists in the list
    /// </summary>
    /// <param name="listURN">ValueList urn to look for</param>
    /// <returns>Whether or not ValueList exists</returns>
    public bool Contains(string listURN)
    {
      ValueList temp = this.Find(delegate(ValueList vl) { return vl.ValueListURN == listURN; });

      return temp != null;
    }

    /// <summary>
    /// Method to return a given ValueList
    /// </summary>
    /// <param name="listURN">ValueList urn to look for</param>
    /// <returns>ValueList matching passed in urn</returns>
    public ValueList GetValueList(string listURN)
    {
      ValueList temp = this.Find(delegate(ValueList vl) { return vl.ValueListURN == listURN; });

      return temp;
    }

    /// <summary>
    /// Writes This IComposable Message To an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Writer for Current XML Document - Since the Root Element of ValueList is Determined by Implementation this only writes VLURN and Values</param>
    public override void WriteXML(XmlWriter xwriter)
    {
      try
      {
        this.Validate();
      }
      catch
      {
        return; ////empty list, so bail early
      }

      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      foreach (ValueList vl in this)
      {
        xwriter.WriteStartElement(this.rootElementName);
        vl.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      xwriter.Flush();
    }

    /// <summary>
    /// Writes This IComposable Message To an Existing XML Document
    /// </summary>
    /// <param name="wrapElementPrefix">Defines the prefix to use when writing the element wrapping the ValueLists</param>
    /// <param name="wrapElementXmlns">Defines the namespace to use when writing the element wrapping the ValueLists</param>
    /// <param name="prefix">Defines the prefix to use when writing the ValueLists in this object</param>
    /// <param name="xmlns">Defines the namespace to use when writing the ValueLists in this object</param>
    /// <param name="xwriter">Writer for Current XML Document - Since the Root Element of ValueList is Determined by Implementation this only writes VLURN and Values</param>
    public void WriteXML(string wrapElementPrefix, string wrapElementXmlns, string prefix, string xmlns, XmlWriter xwriter)
    {
      try
      {
        this.Validate();
      }
      catch
      {
        return; ////either empty or null internal list, so bail early
      }

      if (xwriter == (XmlWriter)null)
      {
        throw new ArgumentNullException("XWriter");
      }

      foreach (ValueList vl in this)
      {
        xwriter.WriteStartElement(wrapElementPrefix, this.rootElementName, wrapElementXmlns);
        vl.WriteXML(prefix, xmlns, xwriter);
        xwriter.WriteEndElement();
      }

      xwriter.Flush();
    }

    /// <summary>
    /// Writes this IComposable Message To and Existing XML Document
    /// Shorthand for schemas where wrapping element and VLs are in same namespace
    /// </summary>
    /// <param name="prefix">Prefix to use when writing this object</param>
    /// <param name="xmlns">Namespace to use when writing this object</param>
    /// <param name="xwriter">Writer for the XML Document</param>
    public void WriteXML(string prefix, string xmlns, XmlWriter xwriter)
    {
      this.WriteXML(prefix, xmlns, prefix, xmlns, xwriter);
    }

    /// <summary>
    /// Reads This IComposable Message From an Existing XML Document
    /// </summary>
    /// <param name="rootnode">XMLNode That Points to the list of VLURN or Values...Not the Root Element since that is standard specific</param>
    public override void ReadXML(XmlNode rootnode)
    {
      if (rootnode == (XmlNode)null)
      {
        throw new ArgumentNullException("RootNode");
      }

      this.Clear();

      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (!string.IsNullOrEmpty(node.InnerText) && node.LocalName == this.rootElementName)
        {
          ValueList tmp = new ValueList();
          tmp.ReadXML(node);
          this.Add(tmp);
        }
      }
    }
    
    /// <summary>
    /// Determines whether or not the data in this object is valid
    /// </summary>
    public override void Validate()
    {
      if (!this.Any())
      {
        throw new Exception("ValueList list is empty.");
      }
    }

    #region IEnumerableImplementation

    /// <summary>
    /// Adds a ValueList to the List
    /// </summary>
    /// <param name="item">ValueList Object to add</param>
    public void Add(ValueList item)
    {
      this.valueLists.Add(item);
    }

    /// <summary>
    /// Adds a specified collection to the list
    /// </summary>
    /// <param name="collection">An enumerable collection of ValueLists to add</param>
    public void AddRange(IEnumerable<ValueList> collection)
    {
      this.valueLists.AddRange(collection);
    }

    /// <summary>
    /// Clears the underlying List object
    /// </summary>
    public void Clear()
    {
      this.valueLists.Clear();
    }

    /// <summary>
    /// Searches the list to see if it contains the specified ValueList
    /// </summary>
    /// <param name="item">ValueList to search for</param>
    /// <returns>True if the ValueList exists in this collection</returns>
    public bool Contains(ValueList item)
    {
      return this.valueLists.Contains(item);
    }

    /// <summary>
    /// Copies the indexed item to the list
    /// </summary>
    /// <param name="array">Array to copy from</param>
    /// <param name="arrayIndex">Index within array to copy from</param>
    public void CopyTo(ValueList[] array, int arrayIndex)
    {
      this.valueLists.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Copies the indexed number of items to the list
    /// </summary>
    /// <param name="index">Index within list to copy to</param>
    /// <param name="array">Array to copy from</param>
    /// <param name="arrayIndex">Index within array to copy from</param>
    /// <param name="count">Number of ValueLists to copy</param>
    public void CopyTo(int index, ValueList[] array, int arrayIndex, int count)
    {
      this.valueLists.CopyTo(index, array, arrayIndex, count);
    }

    /// <summary>
    /// Finds a specified predicate
    /// </summary>
    /// <param name="match">Predicate to search for</param>
    /// <returns>ValueList matching the specified predicate</returns>
    public ValueList Find(Predicate<ValueList> match)
    {
      return this.valueLists.Find(match);
    }

    /// <summary>
    /// Finds the index of the specified predicate
    /// </summary>
    /// <param name="match">Predicate to search for</param>
    /// <returns>Index of the item</returns>
    public int FindIndex(Predicate<ValueList> match)
    {
      return this.valueLists.FindIndex(match);
    }

    /// <summary>
    /// Finds the index of the specified predicate starting from the specified index
    /// </summary>
    /// <param name="startIndex">Index within list to search from</param>
    /// <param name="match">Predicate to search for</param>
    /// <returns>Index of the item</returns>
    public int FindIndex(int startIndex, Predicate<ValueList> match)
    {
      return this.valueLists.FindIndex(startIndex, match);
    }

    /// <summary>
    /// Finds the index of the specified predicate starting from the specified index searching the specified number of items
    /// </summary>
    /// <param name="startIndex">Index within list to search from</param>
    /// <param name="count">Number of items to search</param>
    /// <param name="match">Predicate to search for</param>
    /// <returns>Index of the matched item</returns>
    public int FindIndex(int startIndex, int count, Predicate<ValueList> match)
    {
      return this.valueLists.FindIndex(startIndex, count, match);
    }

    /// <summary>
    /// Finds the index of a specified ValueList
    /// </summary>
    /// <param name="item">ValueList to search for</param>
    /// <returns>Index of the ValueList</returns>
    public int IndexOf(ValueList item)
    {
      return this.valueLists.IndexOf(item);
    }

    /// <summary>
    /// Inserts a ValueList at the specified index
    /// </summary>
    /// <param name="index">Index to insert the ValueList</param>
    /// <param name="item">ValueList to insert</param>
    public void Insert(int index, ValueList item)
    {
      this.valueLists.Insert(index, item);
    }

    /// <summary>
    /// Removes a specified ValueList from the collection
    /// </summary>
    /// <param name="item">ValueList to remove</param>
    /// <returns>True if operation is successful</returns>
    public bool Remove(ValueList item)
    {
      return this.valueLists.Remove(item);
    }

    /// <summary>
    /// Removes the ValueList at the specified index
    /// </summary>
    /// <param name="index">Index of the ValueList to remove</param>
    public void RemoveAt(int index)
    {
      this.valueLists.RemoveAt(index);
    }

    #endregion
    #endregion
  }
}
