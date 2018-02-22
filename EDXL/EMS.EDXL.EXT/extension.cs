using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.EXT
{
  /// <summary>
  /// Base element to allow communities to extend/augment an EDXL data standard
  /// </summary>
  public class extension
  {
    private Uri community;

    private Uri id;

    private List<ParameterType> parameters;

    /// <summary>
    /// Unique identifier of the community
    /// </summary>
    [XmlElement("community")]
    public string Community
    {
      get { return this.community.ToString(); }
      set { this.community = new Uri(value); }
    }

    /// <summary>
    /// Unique identifier for this extension
    /// </summary>
    [XmlElement("id")]
    public string ID
    {
      get { return this.id.ToString(); }
      set { this.id = new Uri(value); }
    }

    /// <summary>
    /// Group of elements used to extend/augment an EDXL data standard
    /// </summary>
    /// <see cref="ParameterType"/>
    [XmlElement("parameter")]
    public List<ParameterType> Parameters
    {
      get { return this.parameters; }
      set { this.parameters = value; }
    }
  }
}
