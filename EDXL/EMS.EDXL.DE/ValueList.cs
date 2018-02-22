using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.DE
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
    private string sourceListURN;

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
    /// <param name="SourceListURN">Unique name of this list</param>
    /// <param name="SelectedValues">List of string values</param>
    public ValueList(string SourceListURN, List<string> SelectedValues)
    {
      if (SelectedValues == null || SelectedValues.Count < 1)
      {
        throw new ArgumentNullException("SelectedValue");
      }

      if (string.IsNullOrWhiteSpace(SourceListURN))
      {
        throw new ArgumentNullException("SourceListURN");
      }

      this.ValueListURN = SourceListURN;
      this.selectedValues = new List<string>(SelectedValues);
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    [XmlElement(ElementName = "valueListUrn", Order = 0)]
    public string ValueListURN
    {
      get { return this.sourceListURN; }
      set { this.sourceListURN = value; }
    }

    /// <summary>
    /// Gets or sets
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    [XmlIgnore]
    public List<string> Value
    {
      get { return this.selectedValues; }
      set
      {
          this.selectedValues = value;
      }
    }

    /// <summary>
    /// Gets or sets
    /// XML Serialization Object for Value
    /// </summary>
    [XmlElement(ElementName = "value", Order = 1)]
    public string[] ValueXML
    {
      get
      {
        if (this.selectedValues.Count == 0)
        {
          return null;
        }
        else
        {
          return this.selectedValues.ToArray();
        }
      }

      set
      {
        if (value != null)
        {
          this.selectedValues = value.ToList();
        }
      }
    }

    #endregion

    /// <summary>
    /// Determines whether or not the data in this object is valid
    /// </summary>
    public void Validate()
    {
      if (string.IsNullOrEmpty(this.sourceListURN))
      {
        throw new Exception("ValueList URN is null or empty.");
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
