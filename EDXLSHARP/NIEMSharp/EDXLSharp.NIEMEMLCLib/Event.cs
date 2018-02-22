//-----------------------------------------------------------------------
// <copyright file="Event.cs" company="EDXLSharp">
//     Licensed under Apache 2.0
// </copyright>
//-----------------------------------------------------------------------
using NIEMSHARP.NIEMEMLCLib.Incident;
using NIEMSHARP.NIEMEMLCLib.Infrastructure;
using NIEMSHARP.NIEMEMLCLib.Resource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using EDXLSharp;
using NIEMSharp;
using System.Runtime.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{

   // NOTE: The xml name/namespace prefix of this class is hard coded in the JSON deserialization process.  
   // If the class name is changed then that must be updated as well.   
   // Places to Update:
   //      deSerialEventConverter

  /// <summary>
  /// Represents the root event element
  /// Use JSON.net with deSerialEventConverter to deserialize 
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
      this.Xmlns.Add(Constants.MaidPrefix, Constants.MaidNamespace);
    }

    public Event(ResourceDetail det): this()
    {
        this.Details = det;
    }

     public Event(IncidentDetail det): this()
    {
        this.Details = det;
    }

     public Event(InfrastructureDetail det): this()
    {
        this.Details = det;

    }
     public Event(MutualAidDetail det): this()
    {
        this.Details = det;
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
          this.EventLink = new List<NIEMSHARP.NIEMEMLCLib.EventLink>(value);
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
          this.EventComment = new List<NIEMSHARP.NIEMEMLCLib.EventComment>(value);
        }
      }
    }

    /// <summary>
    /// Gets or sets the details extension for this event
    /// </summary>
    [XmlIgnore]
    public dynamic Details
    {
        get { return this.details; }

        set
        {
            if (value is EventDetails)
            {
                this.details = value;
            }
            else
            {
                throw new ArgumentException("value","Details must be of EventDetails Type");
            }

        }
    }

    // Have both a private and a public method here so we can be sure that the value being set is derived from EventDetails.
    // The field has to be dynamic (and not EventDetails type) for the serialization/deserialization.  Since MutualAidDetail needs to be
    // handled differently and if this was EventDetails type there would be no good way of knowing which derived type details holds. 
    private dynamic details;

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

      string summary = this.EventTypeDescriptor.CodeValue.ToString();

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
      myitem.Content = new TextSyndicationContent(this.EventTypeDescriptor.CodeValue.ToString());
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
        XmlDocument eventDoc = new XmlDocument(); // Will hold XMLDocument from serialized event 
        var eventWriter = new StringWriter(); // For serializing event without Details
        var detailWriter = new StringWriter(); // For serializing Details 
        Type detailType; // Will hold detail's runtime type
        XmlDocument detailDoc = new XmlDocument(); // XmlDocument 



        // Serializing Event without Details
        (new XmlSerializer(typeof(Event))).Serialize(eventWriter, this);
        eventDoc.LoadXml(eventWriter.ToString());

        if (this.Details != null)
        {
            // Serializing Details
            detailType = this.Details.GetType();

            if (detailType == typeof(MutualAidDetail))
            {
               
                detailDoc.LoadXml(this.Details.ToString());
                

            }
            else
            {
                (new XmlSerializer(detailType)).Serialize(detailWriter, this.Details);
                detailDoc.LoadXml(detailWriter.ToString());
            }

            // Combining XML 
            XmlNode final = eventDoc.ImportNode(detailDoc.DocumentElement, true);
            eventDoc.DocumentElement.AppendChild(final);
        }

        var writer2 = new StringWriter();    

        XDocument xD = XDocument.Parse(eventDoc.OuterXml);
        xD.Save(writer2,SaveOptions.OmitDuplicateNamespaces);

        return writer2.ToString();   
    }


    /// <summary>
    /// Adds the value to the event description extension 
    /// <see cref="NIEMSHARP.NIEMEMLCLib.EventTypeDescriptor.EventTypeDescriptorExtension"/>.
    /// </summary>
    public void AddEventTypeDescriptorExtension(string value)
    {
      this.EventTypeDescriptor.EventTypeDescriptorExtension.Add(value);
    }
     

    /// <summary>
    /// Adds point for Cylinder location <see cref="NIEMSHARP.NIEMEMLCLib.Point"/>.
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Point"/>.
    /// <seealso cref="NIEMSHARP.NIEMEMLCLib.LocationCylinder"/>
    /// </summary>
    public void setLocation(double? lat , double? lon, decimal? halfheight ,decimal? radius , LocationCreationCodeList createdcode)
    {
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lat = lat;
      this.EventLocation.LocationCylinder.LocationPoint.Point.Lon = lon;
      this.EventLocation.LocationCylinder.LocationCylinderHalfHeightValue = halfheight;
      this.EventLocation.LocationCylinder.LocationCylinderRadiusValue = radius;
      this.EventLocation.LocationCylinder.CodeValue = createdcode;
    }

    /// <summary>
    /// Sets the Latitude and Longitude
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Point"/>
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.Point"/>  
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.EventValidityDateTimeRange"/>.
    /// </summary>
    public void setValidity(DateTime start, DateTime end)
    {
      this.EventValidityDateTimeRange.StartDate = start;
      this.EventValidityDateTimeRange.EndDate = end;
    }
        
    /// <summary>
    /// Creates and then adds comment with the given text, organization ID, and time
    /// <see cref="NIEMSHARP.NIEMEMLCLib.EventComment"/>.
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
    /// <see cref="NIEMSHARP.NIEMEMLCLib.EventLink.LinkedEventID"/>.
    /// </summary>
    public void AddEventLink(string id, LinkedEventCategory category, EventTypeCodeList type)
    {
      EventLink link = new EventLink();
      link.LinkedEventID = id;
      link.LinkedEventCategory = category;
      link.LinkedEventCategory.EventTypeCode = type;

      this.EventLink.Add(link);
    }

    /// <summary>
    /// Sets the values for the USNG Coordinate
    /// <see cref="NIEMSHARP.NIEMEMLCLib.USNGCoordinate"/>.
    /// </summary>
    public void setUSNGCoordinate(string Cordid, int eastingValue, int northingValue, string geographicDatum, string zoneID, string SquaredZoneID)
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
