//-----------------------------------------------------------------------
// <copyright file="InfrastructureStatus.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Infrastructure
{
  /// <summary>
  /// Represents the status of infrastructure over time
  /// </summary>
  [Serializable]
  public class InfrastructureStatus
  {
    /// <summary>
    /// Initializes a new instance of the InfrastructureStatus class
    /// </summary>
    public InfrastructureStatus()
    {
      //this.InfrastructureSecondaryStatus = new List<string>();
    }

    /// <summary>
    /// Gets or sets the status of the infrastructure
    /// </summary>
    public InfrastructurePrimaryStatusCodeList InfrastructurePrimaryStatus
    {
      get; set;
    }

    ///// <summary>
    ///// Gets or sets the secondary status of the infrastructure
    ///// </summary>
    //[XmlIgnore]
    //public List<string> InfrastructureSecondaryStatus
    //{
    //  get; set;
    //}

    //TODO: InfrastructureSecondaryStatus is an abstract element, currently there are no
    //TODO: structures to substitute in
    ///// <summary>
    ///// Gets or sets the serialization value of the secondary status of the infrastructure
    ///// </summary>
    //[XmlElement(ElementName = "InfrastructureSecondaryStatus")]
    //public string[] SerialInfrastructureSectondaryStatus
    //{
    //  get
    //  {
    //    return this.InfrastructureSecondaryStatus.ToArray();
    //  }

    //  set
    //  {
    //    this.InfrastructureSecondaryStatus = new List<string>(value);
    //  }
    //}

    /// <summary>
    /// Gets or sets the reason for the status of the infrastructure
    /// </summary>
    public string InfrastructureStatusReason
    {
      get; set;
    }
  }
}