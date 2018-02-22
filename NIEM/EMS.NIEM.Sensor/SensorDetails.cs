using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Class for serializing sensor details
  /// </summary>
  [Serializable]
  [XmlRoot("SensorDetail", Namespace = Constants.EmlcNamespace)]
  public class SensorDetail : EventDetails
  {
    private string id;
    private SensorStatusCodeList status;
    private DeviceDetails deviceDetails;
    private PowerDetails powerDetails;
    private PhysiologicalSensorDetails physiologicalDetails;
    private EnvironmentalSensorDetails environmentalDetails;
    private XYZLocationSensorDetails locationDetails;

    /// <summary>
    /// Default Constructor
    /// </summary>
    public SensorDetail()
    {
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.MoPrefix, Constants.MoNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.SensorPrefix, Constants.SensorNamespace);
    }

    /// <summary>
    /// Gets or sets Namespace object place for serializing prefixes for namespaces
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2235:MarkAllNonSerializableFields", Justification = "Warning is suppressed because this is for a namespace only")]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns
    {
      get; set;
    }

    /// <summary>
    /// Identifier for sensor device
    /// </summary>
    [XmlElement("ID")]
    public string ID
    {
      get { return id; }
      set { id = value; }
    }

    /// <summary>
    /// Status of sensor device
    /// </summary>
    [XmlElement("Status")]
    public SensorStatusCodeList Status
    {
      get { return status; }
      set { status = value; }
    }

    /// <summary>
    /// Wrapper for device information
    /// </summary>
    [XmlElement("DeviceDetails")]
    public DeviceDetails DeviceDetails
    {
      get { return deviceDetails; }
      set { deviceDetails = value; }
    }

    /// <summary>
    /// Serialization flag to determine whether or not
    /// to serialize the associated property/field
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeDeviceDetails()
    {
      return deviceDetails != null;
    }

    /// <summary>
    /// Wrapper for power information
    /// </summary>
    [XmlElement("PowerDetails")]
    public PowerDetails PowerDetails
    {
      get { return powerDetails; }
      set { powerDetails = value; }
    }

    /// <summary>
    /// Serialization flag to determine whether or not
    /// to serialize the associated property/field
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializePowerDetails()
    {
      return powerDetails != null;
    }

    /// <summary>
    /// Wrapper for physiological sensors
    /// </summary>
    [XmlElement("PhysiologicalDetails")]
    public PhysiologicalSensorDetails PhysiologicalDetails
    {
      get { return physiologicalDetails; }
      set { physiologicalDetails = value; }
    }

    /// <summary>
    /// Serialization flag to determine whether or not
    /// to serialize the associated property/field
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializePhysiologicalDetails()
    {
      return physiologicalDetails != null;
    }

    /// <summary>
    /// Wrapper for environmental sensors
    /// </summary>
    [XmlElement("EnvironmentalDetails")]
    public EnvironmentalSensorDetails EnvironmentalDetails
    {
      get { return environmentalDetails; }
      set { environmentalDetails = value; }
    }

    /// <summary>
    /// Serialization flag to determine whether or not
    /// to serialize the associated property/field
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeEnvironmentalDetails()
    {
      return environmentalDetails != null;
    }

    /// <summary>
    /// Wrapper for location sensors
    /// </summary>
    [XmlElement("XYZLocationDetails")]
    public XYZLocationSensorDetails LocationDetails
    {
      get { return locationDetails; }
      set { locationDetails = value; }
    }

    /// <summary>
    /// Serialization flag to determine whether or not
    /// to serialize the associated property/field
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeLocationDetails()
    {
      return locationDetails != null;
    }
  }
}
