using EMS.EDXL.CT;
using EMS.EDXL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS.EDXL.SitRep
{
  public class IncidentInformationType
  {
    private string incidentName;

    private List<IncidentKindDefaultValues> incidentKind;

    private IncidentComplexityDefaultValues? incidentComplexity;

    private EDXLDateTime? incidentStartDateTime;

    private GeographicSizeType geographicSize;

    private List<DisasterInformationType> disasterInformation;

    private EDXLLocationType incidentLocation;

    private List<JurisdictionInformationType> jurisdictionInformation;

    private List<IncidentStagingType> incidentStaging;

    [XmlElement("incidentName")]
    public string IncidentName
    {
      get
      {
        return incidentName;
      }

      set
      {
        incidentName = value;
      }
    }

    [XmlElement("incidentKind")]
    public List<IncidentKindDefaultValues> IncidentKind
    {
      get
      {
        return incidentKind;
      }

      set
      {
        incidentKind = value;
      }
    }

    [XmlIgnore]
    public bool IncidentKindSpecified
    {
      get { return this.incidentKind != null && this.incidentKind.Count > 0; }
    }

    [XmlElement("incidentComplexity")]
    public IncidentComplexityDefaultValues IncidentComplexity
    {
      get
      {
        return incidentComplexity.Value;
      }

      set
      {
        incidentComplexity = value;
      }
    }

    [XmlIgnore]
    public bool IncidentComplexitySpecified
    {
      get { return this.incidentComplexity.HasValue; }
    }

    [XmlElement("IncidentStartDateTime")]
    public string IncidentStartDateTime
    {
      get
      {
        return incidentStartDateTime.Value.EDXLCustomFormat;
      }

      set
      {
        incidentStartDateTime = DateTime.Parse(value);
      }
    }

    [XmlIgnore]
    public bool IncidentStartDateTimeSpecified
    {
      get { return this.incidentStartDateTime.HasValue; }
    }

    [XmlElement("geographicSize")]
    public GeographicSizeType GeographicSize
    {
      get
      {
        return geographicSize;
      }

      set
      {
        geographicSize = value;
      }
    }

    [XmlElement("disasterInformation")]
    public List<DisasterInformationType> DisasterInformation
    {
      get
      {
        return disasterInformation;
      }

      set
      {
        disasterInformation = value;
      }
    }
    [XmlIgnore]
    public bool DisasterInformationSpecified
    {
      get { return this.disasterInformation != null && this.disasterInformation.Count > 0; }
    }

    [XmlElement("incidentLocation")]
    public EDXLLocationType IncidentLocation
    {
      get
      {
        return incidentLocation;
      }

      set
      {
        incidentLocation = value;
      }
    }

    [XmlElement("jurisdictionInformation")]
    public List<JurisdictionInformationType> JurisdictionInformation
    {
      get
      {
        return jurisdictionInformation;
      }

      set
      {
        jurisdictionInformation = value;
      }
    }

    [XmlIgnore]
    public bool JurisdictionInformationSpecified
    {
      get { return this.jurisdictionInformation != null && this.jurisdictionInformation.Count > 0; }
    }

    [XmlElement("incidentStaging")]
    public List<IncidentStagingType> IncidentStaging
    {
      get
      {
        return incidentStaging;
      }

      set
      {
        incidentStaging = value;
      }
    }

    [XmlIgnore]
    public bool IncidentStagingSpecified
    {
      get { return this.incidentStaging != null && this.incidentStaging.Count > 0; }
    }
  }
}
