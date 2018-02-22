using EMS.NIEM.NIEMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.NIEM.MutualAid
{
    /// <summary>
    /// Used as placeholder for SpecificResource, GenericResource, and MissionNeed
    /// </summary>
    [XmlInclude(typeof(SpecificResource))]
    [XmlInclude(typeof(GenericResource))]
    [XmlInclude(typeof(MissionNeed))]
    public abstract class RequestResourceKind
    {
    }
}
