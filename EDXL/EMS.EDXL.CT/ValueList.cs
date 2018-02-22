using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  /// <summary>
  /// Data Structure to Represent a Unique name and an associated list of values
  /// </summary>
  [Serializable]
  public class ValueList
  {
    #region Private Member Variables

    /// <summary>
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    private string sourceListURI;

    /// <summary>
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    private List<string> selectedValues;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ValueList class
    /// Default Constructor - Initializes List
    /// </summary>
    public ValueList()
    {
      this.selectedValues = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the ValueList class
    /// Constructor To Initialize Values - Preforms Deep Copy on List of Strings
    /// </summary>
    /// <param name="SourceListURI">Unique name of this list</param>
    /// <param name="SelectedValues">List of string values</param>
    public ValueList(string SourceListURI, List<string> SelectedValues)
    {
      if (SelectedValues == null || SelectedValues.Count < 1)
      {
        throw new ArgumentNullException("SelectedValue");
      }

      if (string.IsNullOrWhiteSpace(SourceListURI))
      {
        throw new ArgumentNullException("SourceListURI");
      }

      this.sourceListURI = SourceListURI;
      this.selectedValues = new List<string>(SelectedValues);
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    [XmlElement(ElementName = "valueListURI", Order = 0)]
    public string ValueListURI
    {
      get { return this.sourceListURI; }
      set { this.sourceListURI = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    [XmlElement(ElementName = "value", Order = 1)]
    public List<string> Value
    {
      get { return this.selectedValues; }
      set
      {
          this.selectedValues = value;
      }
    }

    #endregion

    /// <summary>
    /// Determines whether or not the data in this object is valid
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.sourceListURI))
      {
        throw new Exception("ValueList URI is null or empty.");
      }

      if (this.selectedValues == null)
      {
        throw new Exception("ValueList Value is null.");
      }

      if (this.selectedValues.Count < 1)
      {
        throw new Exception("ValueList Value is empty.");
      }
    }
  }
}
