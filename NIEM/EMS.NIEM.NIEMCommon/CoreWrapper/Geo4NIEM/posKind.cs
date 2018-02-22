using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon.Geo4NIEM
{

  /// <summary>
  /// Abstract class, used by LinearRing and LineString
  /// </summary>
  [XmlInclude(typeof(Pos))]
    [XmlInclude(typeof(PosList))]
    [XmlInclude(typeof(Coordinates))]
    [XmlInclude(typeof(PointRep))]
    [XmlInclude(typeof(PointProperty))]
    public abstract class posKind
    {
    }
}
