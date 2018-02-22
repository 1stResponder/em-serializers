using EMS.EDXL.CT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.EXT
{
  /// <summary>
  /// Repersetns a Parameter Value Type
  /// </summary>
  public class ParameterValueType
  {
    private EDXLString paramValue;

    private string uom;

    /// <summary>
    /// XML Text of a Parameter value
    /// </summary>
    [XmlText]
    public string Value
    {
      get { return this.paramValue; }
      set { this.paramValue = value; }
    }

    /// <summary>
    /// Unit of measure of the Parameter value
    /// </summary>
    [XmlAttribute("uom")]
    public string UOM
    {
      get { return this.uom; }
      set { this.uom = value; }
    }

    /// <summary>
    /// Indicates whether or not the UOM was specified
    /// </summary>
    [XmlIgnore]
    public bool UOMSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.uom); }
    }
  }
}
