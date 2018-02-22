//-----------------------------------------------------------------------
// <copyright file="LineString.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
  /// <summary>
  /// Represents a line of points
  /// </summary>
  [JsonObject(MemberSerialization.OptIn)]
  public class LineString : GML
  {
    /// <summary>
    /// Initializes a new instance of the LineString class
    /// </summary>
    public LineString()
    {
      posKind = new List<posKind>();
    }

    /// <summary>
    /// Required Element
    /// Holds list of position types describing the ring
    /// pos, pointProperty, and point need to have a min of 4 occurrences and are unbounded 
    /// coordinates and posList need to have a min and max of 1 occurrence
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("pos",typeof(Pos), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("pointProperty", typeof(PointProperty), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("point", typeof(PointRep), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("coordinates", typeof(Coordinates), Order = 1)]
    [System.Xml.Serialization.XmlElementAttribute("posList",typeof(PosList), Order = 1)]
    public List<posKind> posKind
    {
        get; set;
    }

    
    /// <summary>
    /// Sets the posKind property
    /// Allows posKind to be set to children lists (like pos<Pos/>) and single value children without implicitly casting 
    /// </summary>
    [XmlIgnore]
    public dynamic PosKind
    {
        get {
            return posKind;
        }

        set {
            
            posKind = new List<posKind>();

            if(value is IList)
            {

                foreach(posKind pk in value)
                {
                    posKind.Add(pk);
                }

            } else if (value is Coordinates || value is PosList)
            {
                posKind.Add(value);
            }  

        }
    }

    
  }
}