using System;
using System.Xml;
using System.Xml.Serialization;

namespace EMS.EDXL.CIQ
{
  /// <summary>
  /// Container to Represent an Individual's Name
  /// </summary>
  [Serializable]
  public class PersonNameElement
  {
    #region Private Member Variables

    private string personNameValue;

    private PersonNameElementList? personNameKind;

    #endregion Private Member Variables

    #region XML Elements
    [XmlText]
    public string Value
    {
      get { return this.personNameValue; }
      set { this.personNameValue = value; }
    }
    #endregion XML Elements

    #region XML Attributes
    [XmlAttribute ("ElementType")]
    public PersonNameElementList Kind
    {
      get { return this.personNameKind.Value; }
      set { this.personNameKind = value; }
    }

    /// <summary>
    /// Set flag to determine if Kind attribute is serialized or not
    /// </summary>
    [XmlIgnore]
    public bool KindSpecified
    {
      get { return this.personNameKind.HasValue; }
    }
    #endregion XML Attributes
  }
}
