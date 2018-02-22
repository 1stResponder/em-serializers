//-----------------------------------------------------------------------
// <copyright file="ResourceStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Resource
{
  /// <summary>
  /// Represents the status of a resource
  /// </summary>
  [Serializable]
  public class ResourceStatus
  {

    /// <summary>
    /// Initializes instance of ResourceStatus class 
    /// </summary>
    public ResourceStatus()
    {
        SecondaryStatus = new List<AltStatus>();
    }

    /// <summary>
    /// Gets or sets the primary status of this resource
    /// Required Element
    /// </summary>
    [XmlElement(ElementName = "ResourcePrimaryStatus")]
    public ResourcePrimaryStatusCodeList PrimaryStatus
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the secondary status of this resource
    /// Optional Element
    /// </summary>
    [XmlElement("ResourceEIDDStatus", typeof(ResourceEIDDStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("ResourceUCADStatus", typeof(ResourceUCADStatus), Namespace = Constants.EmlcNamespace)]
    [XmlElement("ResourceSecondaryStatusText", typeof(TextStatus), Namespace = Constants.EmlcNamespace)]
    public List<AltStatus> SecondaryStatus
    {
      get; set;
    }

    /// <summary>
    /// If secondary status is null or empty then it wont be serialized 
    /// </summary>
    /// <returns></returns>
    public bool ShouldSerializeSecondaryStatus() {
      
        if(SecondaryStatus == null)
        {
            return false;
        }

        return (SecondaryStatus.Count > 0);
   }

  }
}
