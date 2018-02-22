using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
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
