//-----------------------------------------------------------------------
// <copyright file="AreaRegion.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System.Xml.Serialization;

namespace EMS.NIEM.NIEMCommon
{
    /// <summary>
    /// Represents a region
    /// </summary>
    [XmlInclude(typeof(LocationEllipse))]
    [XmlInclude(typeof(LocationExternalPolygon))]
    [XmlInclude(typeof(LocationLineString))]
    public abstract class AreaRegion
    {
    }
}
