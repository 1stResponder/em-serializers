//-----------------------------------------------------------------------
// <copyright file="InfrastructureDetail.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib.Infrastructure
{
// NOTE: The xml name/namespace prefix of this class is hard coded in the JSON deserialization process.  
   // If the class name is changed then that must be updated as well.   
   // Places to Update:
   //      deSerialEventConverter


  /// <summary>
  /// Represents the status of infrastructure
  /// </summary>
  [Serializable]
  [XmlRootAttribute("InfrastructureDetail", Namespace = Constants.EmlcNamespace)]
  public class InfrastructureDetail : EventDetails
  {
    /// <summary>
    /// Initializes a new instance of the InfrastructureDetail class
    /// </summary>
    public InfrastructureDetail()
    {
      this.InfrastructureStatus = new InfrastructureStatus();
      this.SerialInfrastructureEstimatedMitigationTime = new NIEMDateTime();
      this.PointOfContact = new PointOfContact();
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.MofPrefix, Constants.MofNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
    }

    /// <summary>
    /// Gets or sets the status of the infrastructure
    /// </summary>
    public InfrastructureStatus InfrastructureStatus
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets Namespace object place for serializing prefixes for namespaces
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is supressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the percentage value that infrastructure is degraded
    /// </summary>
    public decimal InfrastructurePercentDegraded
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the trending of the infrastructure status
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