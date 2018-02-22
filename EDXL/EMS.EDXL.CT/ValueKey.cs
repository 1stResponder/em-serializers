using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CT
{
  /// <summary>
  /// Data Structure to Represent a Unique name and a single value
  /// </summary>
  [Serializable]
  public class ValueKey
  {
    #region Private Member Variables
    /// <summary>
    /// The name of a certified list maintained by the Community of Interest (COI) for the val referenced.
    /// </summary>
    private string sourceListURI;

    /// <summary>
    /// A val from a certified list maintained by the Community of Interest (COI) for the referenced element.
    /// </summary>
    private string selectedValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ValueKey class
    /// Default Constructor - Initializes List
    /// </summary>
    public ValueKey()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ValueKey class
    /// Constructor To Initialize Values - Performs Deep Copy on List of Strings
    /// </summary>
    /// <param name="SourceListURI">Unique name of this list</param>
    /// <param name="SelectedValue">String value</param>
    public ValueKey(string SourceListURI, string SelectedValue)
    {
      if (string.IsNullOrWhiteSpace(SelectedValue))
      {
        throw new ArgumentNullException("SelectedValue");
      }

      if (string.IsNullOrWhiteSpace(SourceListURI))
      {
        throw new ArgumentNullException("SourceListURI");
      }

      this.selectedValue = SelectedValue;
      this.sourceListURI = SourceListURI;
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
    public string Value
    {
      get { return this.selectedValue; }
      set { this.selectedValue = value; }
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

      if (string.IsNullOrEmpty(this.selectedValue))
      {
        throw new Exception("ValueList Value is null.");
      }
    }
  }
}
