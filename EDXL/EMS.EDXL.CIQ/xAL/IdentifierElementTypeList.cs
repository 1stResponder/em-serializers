using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.EDXL.CIQ
{
  [Serializable]
  public enum IdentifierElementTypeList
  {
    Name,
    RangeFrom,
    Range,
    RangeTo,
    Prefix,
    Suffix,
    Number,
    Separator,
    Extension
  }
}
