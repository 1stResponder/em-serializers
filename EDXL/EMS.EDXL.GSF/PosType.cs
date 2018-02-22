using EMS.EDXL.Shared;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EMS.EDXL.GSF
{
  public class PosType
  {
    [XmlIgnore]
    private List<double> posItems;

    [XmlAttribute("SrsName")]
    public Uri SrsName { get; set; }

    [XmlAttribute("SrsDimension")]
    public int SrsDimension { get; set; }

    [XmlAttribute("AxisLabels")]
    public List<NCName> AxisLabels { get; set; }

    [XmlAttribute("UomLabels")]
    public List<NCName> UomLabels { get; set; }

    [XmlText]
    public string Value
    {
      get
      {
        if (posItems == null)
        {
          return "";
        }
        else if (posItems.Count < 1)
        {
          return "";
        }
        else
        {
          string tmp = "";

          foreach (double posItem in posItems)
          {
            //initialize the string with the first double
            if (tmp.Length == 0)
            {
              tmp = posItem.ToString();
            }
            else
            {
              tmp = tmp + " " + posItem.ToString();
            }
          }
          return tmp;
        }
      }
      set
      {
        string[] items = value.Split(new char[] { ' ' });

        if (items.Length > 0)
        {
          posItems = new List<double>();

          foreach (string item in items)
          {
            bool parsed = false;

            double tmp;

            parsed = Double.TryParse(item, out tmp);

            if (parsed)
            {
              posItems.Add(tmp);
            }
          }
        }
      }
    }
  }
}
