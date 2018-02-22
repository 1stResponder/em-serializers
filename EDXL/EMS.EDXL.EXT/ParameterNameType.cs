using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.EXT
{
  /// <summary>
  /// Repersetns a Parameter Name Type
  /// </summary>
  public class ParameterNameType
  {
    private Uri name;

    private string xPath;

    /// <summary>
    /// XML Text of the Parameter Name
    /// </summary>
    [XmlText]
    public string Name
    {
      get { return this.name.ToString(); }
      set { this.name = new Uri(value); }
    }

    /// <summary>
    /// xPath link to associated element within EDXL Standard
    /// </summary>
    [XmlAttribute("xPath")]
    public string XPath
    {
      get { return this.XPath; }
      set { this.xPath = value; }
    }

    /// <summary>
    /// Indicates whether or not the XPath was specified
    /// </summary>
    [XmlIgnore]
    public bool XPathSpecified
    {
      get { return !string.IsNullOrWhiteSpace(this.xPath); }
    }
  }
}
