using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.EXT
{
  /// <summary>
  /// Group of elements used to extend/augment an EDXL data standard
  /// </summary>
  public class ParameterType
  {
    private ParameterNameType nameURI;

    private List<ParameterValueType> values;

    /// <summary>
    /// Unique identifier of a parameter
    /// </summary>
    /// /// <see cref="ParameterNameType"/>
    [XmlElement("nameURI")]
    public ParameterNameType NameURI
    {
      get { return this.nameURI; }
      set { this.nameURI = value; }
    }

    /// <summary>
    /// Parameter values
    /// </summary>
    /// <see cref="ParameterValueType"/>
    [XmlElement("value")]
    public List<ParameterValueType> Values
    {
      get { return this.values; }
      set { this.values = value; }
    }
  }
}
