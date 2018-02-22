using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.EDXL.CIQ
{
  [Serializable]
  public enum ThoroughfareNameTypeList
  {
    NameOnly,
    PreDirection,
    PostDirection,
    NameAndNumber,
    NameAndType,
    NameNumberAndType,
    Unstructured,
    SubThoroughfareConnector,
    ReferenceLocation,
    Type
  }
}
