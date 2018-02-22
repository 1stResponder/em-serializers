using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class GeographicSizeType
  {
    private long size;

    private bool isEstimate;

    private string remarks;

    [XmlElement("size")]
    public long Size
    {
      get { return this.size; }
      set { this.size = value; }
    }

    [XmlElement("isEstimate")]
    public bool IsEstimate
    {
      get { return this.isEstimate; }
      set { this.isEstimate = value; }
    }

    [XmlElement("remarks")]
    public string Remarks
    {
      get { return this.remarks; }
      set { this.remarks = value; }
    }
  }
}
