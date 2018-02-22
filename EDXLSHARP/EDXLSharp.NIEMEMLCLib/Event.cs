//-----------------------------------------------------------------------
// <copyright file="Event.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------
using EDXLSharp.NIEMEMLCLib.Incident;
using EDXLSharp.NIEMEMLCLib.Infrastructure;
using EDXLSharp.NIEMEMLCLib.Resource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib
{
  /// <summary>
  /// Represents the root event element
  /// </summary>
  [XmlRootAttribute("Event", Namespace = Constants.EmlcNamespace,
IsNullable = false)]
  [JsonObject(MemberSerialization.OptIn)]
  public class Event : IGeoRSS
  {
    /// <summary>
    /// Date and Time Event message is sent
    /// </summary>
    private DateTime eventMessageDateTime;

    /// <summary>
    /// Initializes a new instance of the Event class
    /// </summary>
    public Event()
    {
      this.SerialEventID = new IdentificationID();
      this.EventTypeDescriptor = new EventTypeDescriptor();
      this.EventLocation = new EventLocation();
      this.EventValidityDateTimeRange = new EventValidityDateTimeRange();
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.MofPrefix, Constants.MofNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
      this.Xmlns.Add(Constants.xlinkPrefix, Constants.xlinkNamespace);
    }
  
    /// <summary>
    /// Initializes a new instance of the Event class from an XML string
    /// </summary>
    public Event(string xmlString)
    {
      this.SerialEventID = new IdentificationID();
      this.EventTypeDescriptor = new EventTypeDescriptor();
      this.EventLocation = new EventLocation();
      this.EventValidityDateTimeRange = new EventValidityDateTimeRange();
      this.EventComment = new List<EventComment>(0);
      this.Xmlns = new XmlSerializerNamespaces();
      this.Xmlns.Add(Constants.EmeventPrefix, Constants.EmeventNamespace);
      this.Xmlns.Add(Constants.EmlcPrefix, Constants.EmlcNamespace);
      this.Xmlns.Add(Constants.GmlPrefix, Constants.GmlNamespace);
      this.Xmlns.Add(Constants.MofPrefix, Constants.MofNamespace);
      this.Xmlns.Add(Constants.NiemcorePrefix, Constants.NiemcoreNamespace);
      this.Xmlns.Add(Constants.NiemogcPrefix, Constants.NiemocgNamespace);
      this.Xmlns.Add(Constants.RtltPrefix, Constants.RtltNamespace);
      this.ReadXML(xmlString);
      // TODO: Validate NIEM Message?
    }

   /// <summary>
   /// Reads in the xml 
   /// </summary>
   /// <param name="xmlData">Xml as string</param>
    public void ReadXML(string xmlData)
    {
        if (string.IsNullOrEmpty(xmlData))
        {
            throw new ArgumentNullException("XMLData Can't Be Null!");
        }

        XmlDocument doc = new XmlDocument();
        try
        {
            doc.LoadXml(xmlData);
        }
        catch (XmlException)
        {
            throw new ArgumentException("Invalid XML String");
        }

        XmlNodeList denodelist = doc.GetElementsByTagName("Event", Constants.EmlcNamespace);
        if (denodelist.Count == 0)
        {
            throw new FormatException("No Event Element found!");
        }
        else if (denodelist.Count > 1)
        {
            throw new FormatException("Multiple Event Elements found!");
        }

        XmlNode deroot = denodelist[0];

        foreach (XmlNode node in deroot.ChildNodes)
        {
            if (string.IsNullOrEmpty(node.InnerText))
            {
                continue;
            }

            switch (node.LocalName)
            {
                case "EventID":
                    this.EventID = node.InnerText;
                    break;
                case "EventTypeDescriptor":
                        EventTypeDescriptor.EventTypeCode = new ValueList(doc.GetElementsByTagName("EventTypeCode", Constants.EmeventNamespace)[0]);
                        //this.EventTypeDescriptor.SerialEventTypeCode = doc.GetElementsByTagName("EventTypeCode", Constants.EmeventNamespace)[0];//.InnerText; // 1/11/2017 changed property to "SerialEventTypeCode" 
                                                                                                                                                        // to be consistent with LinkedEventCategory....should it be "EventTypeCode",
                                                                                                                                                        // or will XML be updated to be "SerialEventTypeCode"?
                    this.EventTypeDescriptor.EventTypeDescriptorExtension = new List<string>(0);
                    XmlNodeList extensions = doc.GetElementsByTagName("EventTypeDescriptorExtension", Constants.EmeventNamespace);
                    foreach(XmlNode extension in extensions)
                        {
                            this.EventTypeDescriptor.EventTypeDescriptorExtension.Add(extension.InnerText);
                        }
                    break;
                case "EventLocation":
                    this.EventLocation.LocationCylinder = new LocationCylinder();
                    this.EventLocation.LocationCylinder.LocationPoint = new LocationPoint();
                    this.EventLocation.LocationCylinder.LocationPoint.Point = new Point();
                    this.EventLocation.LocationCylinder.LocationPoint.Point.pos = doc.GetElementsByTagName("Point", Constants.GmlNamespace)[0].InnerText;
                    this.EventLocation.LocationCylinder.LocationCylinderRadiusValue = decimal.Parse(doc.GetElementsByTagName("LocationCylinderRadiusValue", Constants.MofNamespace)[0].InnerText);
                    this.EventLocation.LocationCylinder.LocationCreationCode = doc.GetElementsByTagName("LocationCreationCode", Constants.MofNamespace)[0].InnerText;
                    break;
                case "EventValidityDateTimeRange":
                    this.EventValidityDateTimeRange= new EventValidityDateTimeRange();
                    this.EventValidityDateTimeRange.StartDate = Convert.ToDateTime(doc.GetElementsByTagName("StartDate", Constants.NiemcoreNamespace)[0].InnerText);
                    this.EventValidityDateTimeRange.EndDate = Convert.ToDateTime(doc.GetElementsByTagName("EndDate", Constants.NiemcoreNamespace)[0].InnerText);
                    break;
                case "EventComment":
                    EventComment newComment = new EventComment();
                    XmlNodeList commentContent = node.ChildNodes;
                    foreach(XmlNode childNode in commentContent)
                        {
                            if (string.IsNullOrEmpty(childNode.InnerText))
                            {
                                continue;
                            }
                            switch (childNode.LocalName)
                            {
                                case "DateTime":
                                    newComment.DateTime = Convert.ToDateTime(childNode.InnerText);
                                    break;
                                case "CommentText":
                                    newComment.CommentText = childNode.InnerText;
                                    break;
                                case "OrganizationIdentification":
                                    newComment.OrganizationIdentification = childNode.InnerText;
                                    break;
                                case "PersonHumanResourceIdentification":
                                    newComment.PersonHumanResourceIdentification = childNode.InnerText;
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Event Comment");
                            }
                        }
                    this.EventComment.Add(newComment);
                    break;
                case "EventMessageDateTime":
                    this.EventMessageDateTime = Convert.ToDateTime(node.FirstChild.InnerXml);
                    break;
                case "ResourceDetail":
                    ResourceDetail resource = new ResourceDetail();
                    this.Details = CreateResourceDetail(node, resource);
                    break;
                case "IncidentDetail":
                        IncidentDetail incident = new IncidentDetail();
                        this.Details = CreateIncidentDetail(node, incident);
                        break;
                case "InfrastructureDetail":
                        throw new NotImplementedException("ReadXML for " + node.Name + " not implemented yet");
                default:
                    throw new ArgumentException("Unexpected Node Name: " + node.Name + " in NIEM Event");
            }
        }

        }

        private EventDetails CreateIncidentDetail(XmlNode node, IncidentDetail incident)
        {
            incident.Status = new IncidentStatus();
            incident.Status.SecondaryStatus = new List<AltStatus>(0);
            incident.OwningOrg = new IncidentOrganization();
            XmlNodeList incidentChildNodes = node.ChildNodes;
            foreach (XmlNode childNode in incidentChildNodes)
            {
                XmlNodeList statusNodes = childNode.ChildNodes;
                if (string.IsNullOrEmpty(childNode.InnerText))
                {
                    continue;
                }
                switch (childNode.LocalName)
                {
                    case "IncidentStatus":
                        foreach (XmlNode statusNode in statusNodes)
                        {
                            if (string.IsNullOrEmpty(statusNode.InnerText))
                            {
                                continue;
                            }
                            switch (statusNode.LocalName)
                            {
                                case "IncidentPrimaryStatus":
                                    IncidentPrimaryStatusCodeList outputPrim = GetCode<IncidentPrimaryStatusCodeList>(statusNode.InnerText);
                                    incident.Status.PrimaryStatus = outputPrim;
                                    break;
                                case "IncidentEIDDStatus":
                                    IncidentEIDDStatusCodeList outputEEID = GetCode<IncidentEIDDStatusCodeList>(statusNode.InnerText);
                                    incident.AddEIDDStatus(outputEEID);
                                    break;
                                case "IncidentPulsePointStatus":
                                    IncidentPulsePointStatusCodeList outputPulsePoint = GetCode<IncidentPulsePointStatusCodeList>(statusNode.InnerText);
                                    incident.AddPulsePointStatus(outputPulsePoint);
                                    break;
                                case "IncidentSecondaryStatusText":
                                    incident.AddSecondaryStatusText(statusNode.InnerText, "Freetext");
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + statusNode.Name + " in NIEM Incident Status");
                            }
                        }
                        break;
                    case "IncidentOwningOrganization":
                        foreach (XmlNode orgNode in childNode.ChildNodes)
                        {
                            switch (orgNode.LocalName)
                            {
                                case "OrganizationIdentification":
                                    incident.OwningOrg.OrgID = orgNode.InnerText;
                                    break;
                                case "ResourceIdentifier":
                                    incident.OwningOrg.IncidentID = orgNode.InnerText;
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Owning Organization");
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Event");
                }
            }
            return incident;
        }

        private EventDetails CreateResourceDetail(XmlNode node, ResourceDetail resource)
        {
            resource.Status = new ResourceStatus();
            resource.Status.SecondaryStatus = new List<AltStatus>(0);
            resource.ControllingOrg = new ResourceOrganization();
            XmlNodeList resourceDetailNodes = node.ChildNodes;
            foreach (XmlNode childNode in resourceDetailNodes)
            {
                XmlNodeList statusNodes = childNode.ChildNodes;
                if (string.IsNullOrEmpty(childNode.InnerText))
                {
                    continue;
                }
                switch (childNode.LocalName)
                {
                    case "ResourceStatus":
                        foreach (XmlNode statusNode in statusNodes)
                        {
                            if (string.IsNullOrEmpty(statusNode.InnerText))
                            {
                                continue;
                            }
                            switch (statusNode.LocalName)
                            {
                                case "ResourcePrimaryStatus":
                                    ResourcePrimaryStatusCodeList outputPrim = GetCode<ResourcePrimaryStatusCodeList>(statusNode.InnerText);
                                    resource.Status.PrimaryStatus = outputPrim;
                                    break;
                                case "ResouceEIDDStatus":
                                    ResourceEIDDStatusCodeList outputEEID = GetCode<ResourceEIDDStatusCodeList>(statusNode.InnerText);
                                    resource.AddEIDDStatus(outputEEID);
                                    break;
                                case "ResourceUCADStatus":
                                    ResourceUCADStatusCodeList outputUCAD = GetCode<ResourceUCADStatusCodeList>(statusNode.InnerText);
                                    resource.AddUCADStatus(outputUCAD);
                                    break;
                                case "ResourceSecondaryTextStatus":
                                    resource.AddSecondaryStatusText(statusNode.InnerText, "Freetext");
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + statusNode.Name + " in NIEM Resource Status");

                            }
                        }
                        break;


                    case "ResourceOwningOrganization":
                        resource.OwningOrg = new ResourceOrganization();
                        foreach (XmlNode orgNode in childNode.ChildNodes)
                        {
                            switch (orgNode.LocalName)
                            {
                                case "OrganizationIdentification":
                                    resource.OwningOrg.OrgID = orgNode.InnerText;
                                    break;
                                case "ResourceIdentifier":
                                    resource.OwningOrg.ResourceID = orgNode.InnerText;
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Owning Organization");
                            }
                        }
                        break;
                    case "ResourceControllingOrganization":
                        foreach (XmlNode orgNode in childNode.ChildNodes)
                        {
                            switch (orgNode.LocalName)
                            {
                                case "OrganizationIdentification":
                                    resource.OwningOrg.OrgID = orgNode.InnerText;
                                    break;
                                case "ResourceIdentifier":
                                    resource.OwningOrg.ResourceID = orgNode.InnerText;
                                    break;
                                default:
                                    throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Owning Organization");
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException("Unexpected Node Name: " + childNode.Name + " in NIEM Event");
                }  
            }
            return resource;
        }

    /// <summary>
    /// Get the correct Enum name 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pEnumVal"></param>
    /// <returns></returns>
    public static string GetXmlAttrNameFromEnumValue<T>(T pEnumVal)
    {
        // http://stackoverflow.com/q/3047125/194717
        Type type = pEnumVal.GetType();
        FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
        XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];
        //If there is an xmlattribute defined, return the name

        return att.Name;
    }

    /// <summary>
    /// Helper method for getting the correct code from a code list 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T GetCode<T>(string value)
    {
        // http://stackoverflow.com/a/3073272/194717
        foreach (object o in System.Enum.GetValues(typeof(T)))
        {
            T enumValue = (T)o;
            if (GetXmlAttrNameFromEnumValue<T>(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                return (T)o;
            }
        }

        throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof(T).ToString() + " corresponding to value of " + value);
        }

    /// <summary>
    /// Gets or sets Unique Identifier of the event
    /// </summary>
    [XmlIgnore]
    public string EventID
    {
      get
      {
        return SerialEventID != null ? SerialEventID.ID : "";
      }
      set
      {
        if (this.SerialEventID == null)
        {
          this.SerialEventID = new IdentificationID(value);
        }
        else
        {
          this.SerialEventID.ID = value;
        }
      }
    }

    /// <summary>
    /// Gets or sets the Serialization value for the Event ID
    /// </summary>
    [XmlElement(ElementName = "EventID", Namespace = Constants.MofNamespace, Order = 0)]
    [JsonProperty("EventID")]
    public IdentificationID SerialEventID
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the description of the event type
    /// </summary>
    [XmlElement(Namespace = Constants.EmeventNamespace, Order = 1)]
    [JsonProperty]
    public EventTypeDescriptor EventTypeDescriptor
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the location of the event
    /// </summary>
    [XmlElement(Namespace = Constants.MofNamespace, Order = 2)]
    [JsonProperty]
    public EventLocation EventLocation
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the date and time range event is valid
    /// </summary>
    [XmlElement(Namespace = Constants.MofNamespace, Order = 3)]
    [JsonProperty]
    public EventValidityDateTimeRange EventValidityDateTimeRange
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the event message date and time sent
    /// </summary>
    [XmlIgnore]
    public DateTime EventMessageDateTime
    {
      get
      {
        return this.eventMessageDateTime;
      }

      set
      {
        this.eventMessageDateTime = value;
      }
    }

    /// <summary>
    /// Gets or sets the serialization message date and time
    /// </summary>
    [XmlElement(ElementName = "EventMessageDateTime", Namespace = Constants.MofNamespace, Order = 4)]
    [JsonProperty("EventMessageDateTime")]
    public NIEMDateTime SerialEventMessageDateTime
    {
      get
      {
        return new NIEMDateTime(this.eventMessageDateTime);
      }

      set
      {
        this.eventMessageDateTime = value.DateTime;
      }
    }

    /// <summary>
    /// Gets or sets the US National Grid Coordinate of this event
    /// </summary>
    [XmlElement(Namespace = Constants.EmeventNamespace, Order = 5)]
    [JsonProperty]
    public USNGCoordinate USNGCoordinate
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets a link to another event
    /// </summary>
    [XmlIgnore]
    public List<EventLink> EventLink
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value to link to another event
    /// </summary>
    [XmlElement(ElementName = "EventLink", Namespace = Constants.EmeventNamespace, Order = 6)]
    [JsonProperty("EventLink")]
    public EventLink[] SerialEventLink
    {
      get
      {
        if (this.EventLink == null)
        {
          return null;
        }
        else
        {
          return this.EventLink.ToArray();
        }
      }

      set
      {
        if (value == null)
        {
        }
        else
        {
          this.EventLink = new List<EDXLSharp.NIEMEMLCLib.EventLink>(value);
        }
      }
    }

    /// <summary>
    /// Gets or sets the list of comments for this event
    /// </summary>
    [XmlIgnore]
    [JsonProperty("EventComment")]
    public List<EventComment> EventComment
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the serialization value for comment list
    /// </summary>
    [XmlElement(ElementName = "EventComment", Namespace = Constants.EmeventNamespace, Order = 7)]
    public EventComment[] SerialEventComment
    {
      get
      {
        if (this.EventComment == null)
        {
          return null;
        }
        else
        {
          return this.EventComment.ToArray();
        }
      }

      set
      {
        if (value == null)
        {
        }
        else
        {
          this.EventComment = new List<EDXLSharp.NIEMEMLCLib.EventComment>(value);
        }
      }
    }

    /// <summary>
    /// Gets or sets the details extension for this event
    /// </summary>
    [XmlElement("IncidentDetails", typeof(IncidentDetail), Namespace = Constants.EmlcNamespace, Order = 8)]
    [XmlElement("ResourceDetails", typeof(ResourceDetail), Namespace = Constants.EmlcNamespace, Order = 8)]
    [XmlElement("InfrastructureDetails", typeof(InfrastructureDetail), Namespace = Constants.EmlcNamespace, Order = 8)]
    [JsonProperty]
    public EventDetails Details
    {
      get; set;
    }

    /// <summary>
    /// Gets or sets the community extension for this event
    /// </summary>
    [XmlElement(Order = 9, Namespace = Constants.EmeventNamespace)]
    [JsonProperty]
    public EventCommunityExtensions Extensions
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
    /// Converts this event to a set of feed items
    /// </summary>
    /// <param name="items">List of feed items to populate</param>
    /// <param name="linkUID">Link unique ID to use</param>
    public void ToGeoRSS(List<SyndicationItem> items, Guid linkUID)
    {
      SyndicationItem myitem = new SyndicationItem();
      myitem.Authors.Add(new SyndicationPerson(this.EventLocation.LocationCylinder.CodeValue.ToString(), "How", string.Empty));
      myitem.Categories.Add(new SyndicationCategory("EMLC", EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      this.WriteGeoRSSGML(myitem);
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.EventMessageDateTime;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "HTML/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;

      myitem.ElementExtensions.Add("expire_time", string.Empty, this.EventValidityDateTimeRange.EndDate.ToUniversalTime().ToString());

      string summary = this.EventTypeDescriptor.EventTypeSummary;

      /*ICotDetailComponent details = this.cotevent.Detail.GetFirstElement("_EMTasking");
      if (details != null)
      {
        XmlNode node = details.XmlNode.SelectSingleNode("Address");
        if (node != null)
        {
          summary = node.InnerText;
        }
      }
      else
      {
        ICotDetailComponent remarks = this.cotevent.Detail.GetFirstElement("remarks");
        if (remarks != null && remarks.XmlNode != null)
        {
          summary = remarks.XmlNode.InnerText;
        }

        if (string.IsNullOrWhiteSpace(summary))
        {
          summary = this.cotevent.Type;
        }
      }*/

      myitem.Summary = new TextSyndicationContent(summary);

      /*ICotDetailComponent detailsUID = this.cotevent.Detail.GetFirstElement("uid");
      if (detailsUID != null && detailsUID.XmlNode != null)
      {
        XmlAttribute fvcotDetailsUID = detailsUID.XmlNode.Attributes["fvcot"];
        XmlAttribute icnetDetailsUID = detailsUID.XmlNode.Attributes["icnet"];

        if (fvcotDetailsUID != null)
        {
          myitem.Title = new TextSyndicationContent(fvcotDetailsUID.Value + " (CoT)");
        }
        else if (icnetDetailsUID != null)
        {
          myitem.Title = new TextSyndicationContent(icnetDetailsUID.Value + " (CoT)");
        }
        else
        {
          myitem.Title = new TextSyndicationContent(this.cotevent.Uid + " (CoT)");
        }
      }
      else
      {
        myitem.Title = new TextSyndicationContent(this.cotevent.Uid + " (CoT)");
      }*/

      StringBuilder contentstr = new StringBuilder();
      myitem.Content = new TextSyndicationContent(this.EventTypeDescriptor.EventTypeSummary);
      items.Add(myitem);
    }

    /// <summary>
    /// Writes this NIEMEMLC Object to GeoRSS GML
    /// </summary>
    /// <param name="item">Syndication Item to Convert to GML</param>
    private void WriteGeoRSSGML(SyndicationItem item)
    {
      StringBuilder output = new StringBuilder();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      xsettings.OmitXmlDeclaration = true;
      XmlWriter xwriter = XmlWriter.Create(output, xsettings);
      xwriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", EDXLConstants.GMLNamespace);
      xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace, this.EventLocation.LocationCylinder.LocationPoint.Point.pos);
      xwriter.WriteEndElement();
      xwriter.WriteEndElement();
      xwriter.Flush();
      xwriter.Close();
      MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
      item.ElementExtensions.Add(XmlReader.Create(ms));
    }

    /// <summary>
    /// Returns XML string representing this NIEM event
    /// </summary>
    /// <returns>XML String</returns>
    public override string ToString()
    {
      var writer = new StringWriter();
      (new XmlSerializer(typeof(Event))).Serialize(writer, this);
      return writer.ToString();
    }


    /// <summary>
    /// Adds the value to the event description extension 
    /// <see cref="EDXLSharp.NIEMEMLCLib.EventTypeDescriptor.EventTypeDescriptorExtension"/>.
    /// </summary>
    public void AddEventTypeDescriptorExtension(string value)
    {
      this.EventTypeDescriptor.EventTypeDescriptorExtension.Add(value);
    }
     

    /// <summary>
    /// Adds point for Cylinder location <see cref="EDXLSharp.NIEMEMLCLib.Point"/>.
    /// </summary>
    public void addPoint(string id, double? lat, double? lon, double? height, string srsName)
    {
      this.EventLocation.LocationCylinder.LocationPoint.Point = new Point(id);
      this.EventLocation.LocationCylinder.LocationPoint.Point.id = id;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = lat;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = lon;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Height = height;
      this.EventLocation.LocationCylinder.LocationPoint.Point.srsName = srsName;
    }

    /// <summary>
    /// Sets the location's latitude, longitude, half height, radius, and creation code
    /// <see cref="EDXLSharp.NIEMEMLCLib.Point"/>.
    /// <seealso cref="EDXLSharp.NIEMEMLCLib.LocationCylinder"/>
    /// </summary>
    public void setLocation(double? lat , double? lon, decimal halfheight ,decimal radius , LocationCreationCodeList createdcode)
    {
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = lat;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lon = lon;
      this.EventLocation.LocationCylinder.LocationCylinderHalfHeightValue = halfheight;
      this.EventLocation.LocationCylinder.LocationCylinderRadiusValue = radius;
      this.EventLocation.LocationCylinder.CodeValue = createdcode;
    }

    /// <summary>
    /// Sets the Latitude and Longitude
    /// <see cref="EDXLSharp.NIEMEMLCLib.Point"/>
    /// </summary>
    /// <param name="valueLat">Latitude</param>      
    /// <param name="valueLon">Longitude</param>   
    public void setPointCoordinates(double? valueLat, double? valueLon)
    {
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lon = valueLon;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = valueLat;
    }

    /// <summary>
    /// Sets the Latitude, Longitude, and Height
    /// <see cref="EDXLSharp.NIEMEMLCLib.Point"/>  
    /// </summary>
    /// <param name="valueLat">Latitude</param>      
    /// <param name="valueLon">Longitude</param> 
    /// <param name="valueHeight">Height</param>  
    public void setPointCoordinates(double? valueLat, double? valueLon, double? valueHeight)
    {
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lon = valueLon;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = valueLat;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Height = valueHeight;
    }
    
    /// <summary>
    /// Set the start and end date/time of the interval
    /// <see cref="EDXLSharp.NIEMEMLCLib.EventValidityDateTimeRange"/>.
    /// </summary>
    public void setValidity(DateTime start, DateTime end)
    {
      this.EventValidityDateTimeRange.StartDate = start;
      this.EventValidityDateTimeRange.EndDate = end;
    }
        
    /// <summary>
    /// Creates and then adds comment with the given text, organization ID, and time
    /// <see cref="EDXLSharp.NIEMEMLCLib.EventComment"/>.
    /// </summary>
    public void AddComment(string text, string organizationId, string personHumanResourceIdentification, DateTime time)
    {
      EventComment comment = new EventComment();

      comment.OrganizationIdentification = organizationId;
      comment.DateTime = time;
      comment.CommentText = text;
      comment.PersonHumanResourceIdentification = personHumanResourceIdentification;

      this.EventComment.Add(comment);
    }

    /// <summary>
    /// Add new event link
    /// <see cref="EDXLSharp.NIEMEMLCLib.EventLink.LinkedEventID"/>.
    /// </summary>
    public void AddEventLink(string id, LinkedEventCategory category, ValueList eventTypeCode)
    {
      EventLink link = new EventLink();
      link.LinkedEventID = id;
      link.LinkedEventCategory = category;
      link.LinkedEventCategory.EventTypeCode = eventTypeCode;//type;

            this.EventLink.Add(link);
    }

    /// <summary>
    /// Sets the values for the USNG Coordinate
    /// <see cref="EDXLSharp.NIEMEMLCLib.USNGCoordinate"/>.
    /// </summary>
    public void setUSNGCoordinate(string Cordid, string eastingValue, string northingValue, string geographicDatum, string zoneID, string SquaredZoneID)
    {
      this.USNGCoordinate.CoordinateID = Cordid;
      this.USNGCoordinate.EastingValue = eastingValue;
      this.USNGCoordinate.NorthingValue = northingValue;
      this.USNGCoordinate.GeographicDatum = geographicDatum;
      this.USNGCoordinate.GridZoneID = zoneID;
      this.USNGCoordinate.GridZoneSquareId = SquaredZoneID;
    }

    }
}
