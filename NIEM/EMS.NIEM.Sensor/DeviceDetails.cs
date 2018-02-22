using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.NIEM.NIEMCommon;
using System.Xml.Serialization;

namespace EMS.NIEM.Sensor
{
  /// <summary>
  /// Base class for serializing device information
  /// </summary>
  [Serializable]
  public class DeviceDetails
  {
    private string hardwareRevision;
    private string serialNumber;
    private string modelNumber;
    private string manufacturerName;
    private string firmwareRevision;
    private string softwareRevision;

    /// <summary>
    /// Hardware Revision of the device
    /// </summary>
    [XmlElement("HardwareRevision")]
    public string HardwareRevision
    {
      get { return hardwareRevision; }
      set { hardwareRevision = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeHardwareRevision()
    {
      return !string.IsNullOrWhiteSpace(hardwareRevision);
    }

    /// <summary>
    /// Serial Number of the device
    /// </summary>
    [XmlElement("SerialNumber")]
    public string SerialNumber
    {
      get { return serialNumber; }
      set { serialNumber = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeSerialNumber()
    {
      return !string.IsNullOrWhiteSpace(SerialNumber);
    }

    /// <summary>
    /// Model Number of the device
    /// </summary>
    [XmlElement("ModelNumber")]
    public string ModelNumber
    {
      get { return modelNumber; }
      set { modelNumber = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeModelNumber()
    {
      return !string.IsNullOrWhiteSpace(modelNumber);
    }

    /// <summary>
    /// Manufacturer Name of the device
    /// </summary>
    [XmlElement("ManufacturerName")]
    public string ManufacturerName
    {
      get { return manufacturerName; }
      set { manufacturerName = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeManufacturerName()
    {
      return !string.IsNullOrWhiteSpace(manufacturerName);
    }

    /// <summary>
    /// Firmware Revision of the device
    /// </summary>
    [XmlElement("FirmwareRevision")]
    public string FirmwareRevision
    {
      get { return firmwareRevision; }
      set { firmwareRevision = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeFirmwareRevision()
    {
      return !string.IsNullOrWhiteSpace(firmwareRevision);
    }

    /// <summary>
    /// Software Revision of the device
    /// </summary>
    [XmlElement("SoftwareRevision")]
    public string SoftwareRevision
    {
      get { return softwareRevision; }
      set { softwareRevision = value; }
    }

    /// <summary>
    /// Controls the serialization of the associated property
    /// </summary>
    /// <returns>true/false</returns>
    public bool ShouldSerializeSoftwareRevision()
    {
      return !string.IsNullOrWhiteSpace(softwareRevision);
    }
  }
}
