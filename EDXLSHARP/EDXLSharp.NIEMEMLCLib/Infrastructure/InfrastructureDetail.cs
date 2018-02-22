//-----------------------------------------------------------------------
// <copyright file="InfrastructureDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Infrastructure
{
  /// <summary>
  /// Represents the status of infrastructure
  /// </summary>
  [Serializable]
  public class InfrastructureDetail : EventDetails
  {
    /// <summary>
    /// Initializes a new instance of the InfrastructureDetail class
    /// </summary>
    public InfrastructureDetail()
    {
      this.InfrastructureStatus = new InfrastructureStatus();
      this.SerialInfrastructureEstimatedMitigationTime = new NIEMDateTime();
      //this.IncidentLocationExtension = new IncidentLocationExtension();
      this.PointOfContact = new PointOfContact();
    }

    /// <summary>
    /// Gets or sets the status of the infrastructure
    /// Required Element 
    /// </summary>
    public InfrastructureStatus InfrastructureStatus
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the percentage value that infrastructure is degraded
    ///  Required Element
    /// </summary>
    public decimal InfrastructurePercentDegraded
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the trending of the infrastructure status
    ///  Required Element
    /// </summary>
    public InfrastructureTrendCodeList InfrastructureTrend
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the date and time when the infrastructure will be mitigates
    /// </summary>
    [XmlIgnore]
    public DateTime InfrastructureEstimatedMitigationTime
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value of the date and time when the infrastructure will be mitigates
    /// </summary>
    [XmlElement(ElementName = "InfrastructureEstimatedMitigationTime")]
    public NIEMDateTime SerialInfrastructureEstimatedMitigationTime
    {
      get
      {
        return new NIEMDateTime(this.InfrastructureEstimatedMitigationTime);
      }

      set
      {
        this.InfrastructureEstimatedMitigationTime = value.DateTime;
      }
    }

    /// <summary>
    /// Gets or sets the location of the infrastructure
    /// </summary>
    public IncidentLocationExtension IncidentLocationExtension
    {
      get; set;
    }

    /// <summary>
    /// Determines whether or not to serialize IncidentLocationExtension
    /// </summary>
    /// <returns>Yes or No</returns>
    public bool ShouldSerializeIncidentLocationExtension()
    {
      return this.IncidentLocationExtension != null;
    }

    /// <summary>
    /// Gets or sets the point of contact information
    /// </summary>
    public PointOfContact PointOfContact
    {
      get; set;
    }
  }
}