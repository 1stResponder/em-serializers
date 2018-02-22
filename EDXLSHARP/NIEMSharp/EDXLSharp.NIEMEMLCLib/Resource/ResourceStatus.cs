//-----------------------------------------------------------------------
// <copyright file="ResourceStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Resource
{
  /// <summary>
  /// Represents the status of a resource
  /// </summary>
  [Serializable]
  public class ResourceStatus
  {
    /// <summary>
    /// Gets or sets the primary status of this resource
    /// </summary>
    [XmlElement(ElementName = "ResourcePrimaryStatus")]
    public ResourcePrimaryStatusCodeList PrimaryStatus
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the secondary status of this resource
    /// </summary>
    [XmlElement("ResourceEIDDStatus", typeof(ResourceEIDDStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("ResourceUCADStatus", typeof(ResourceUCADStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("ResourceSecondaryTextStatus", typeof(TextStatus), Namespace = Constants.EmlcNamespace)]
    public List<AltStatus> SecondaryStatus
    {
      get; set;
    }
  }
}
