using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NIEMSharp;
using NIEMSharp.MutualAidRequest;
using NIEMSharp.MutualAidRespond;
using System.Xml.Serialization;
using NIEMSHARP.NIEMEMLCLib.Incident;
using NIEMSHARP.NIEMEMLCLib.Infrastructure;
using NIEMSHARP.NIEMEMLCLib.Resource;


namespace NIEMSHARP.NIEMEMLCLib
{
    /// <summary>
    /// Does all the work necessary to properly deserialize an Event Object.  Requires that the xml version of Event be provided.
    /// Call's default XML deserializer for Event
    /// Required to properly deserialize Mutual Aid
    /// </summary>
    public class deSerialEventConverter: JsonConverter
    {
        protected string xmlString; // Holds XML String of this Event object, required

        /// <summary>
        /// Initializes instance of this converter 
        /// </summary>
        /// <param name="xml">XML version of this Event</param>
        public deSerialEventConverter(string xml)
        {
            xmlString = xml;
        }

        /// <summary>
        /// If the object is an Event then it can be converted 
        /// </summary>
        /// <param name="objectType">Type of the Object being deserialized</param>
        /// <returns>True or false</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Event);
        }

        /// <summary>
        /// Sets XML string for the converter.  Must contain XML of object being deserialized 
        /// </summary>
        /// <param name="xml">XML version of this Event</param>
        public void setXML(string xml)
        {
            xmlString = xml;
        }


        /// <summary>
        /// Deserializes Event object with it's proper event detail.  
        /// Requires the xmlString which is used for the deserialization
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject obj = JObject.Load(reader);
                Object root = null;

                if (xmlString != null)
                {
                    //-- Deserializing Event without detail 
                    XmlDocument xD = new XmlDocument();
                    xD.LoadXml(xmlString);
                    string eventString = "";

                    foreach(XmlNode child in xD.ChildNodes)
                    {
                        if(child.Name == "emlc:Event")
                        {                               
                            eventString = child.OuterXml;
                            break;
                        }
                    }

                    xD.LoadXml(eventString);
                    

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Event));   
                    StringReader xmlReader = new StringReader(eventString);
                    Event myEvent = (Event)xmlSerializer.Deserialize(xmlReader);

                    //-- Deserializing EventDetails if it exists 
                    JToken incTok = obj.SelectToken("emlc:Event.emlc:IncidentDetail");
                    JToken resTok = obj.SelectToken("emlc:Event.emlc:ResourceDetail");
                    JToken maTok = obj.SelectToken("emlc:Event.maid:MutualAidDetail");
                    JToken infTok = obj.SelectToken("emlc:Event.emlc:InfrastructureDetail");

                    
                    if (incTok != null) // If Details is an IncidentDetail
                    {
                        string elementName = "emlc:IncidentDetail";
                        Type detailType = typeof(IncidentDetail);
                        string detailXML = "";
                        
                        // Getting XML for just this detail
                        foreach(XmlNode child in xD.FirstChild.ChildNodes)
                        {
                            if(child.Name == elementName)
                            {                               
                                detailXML = child.OuterXml;
                                break;
                            }
                        }

                        // Deserializing 
                        XmlSerializer detailSerializer = new XmlSerializer(detailType);
                        StringReader detailReader = new StringReader(detailXML);

                        IncidentDetail myDetail = (IncidentDetail)detailSerializer.Deserialize(detailReader);
                        myEvent.Details = myDetail;   


                    }
                    else if (resTok != null) // If Details is a ResourceDetail
                    {
                        Type detailType = typeof(ResourceDetail);
                        JToken detailToken = resTok;
                        string elementName = "emlc:ResourceDetail";
                        string detailXML = "";

                        // Getting XML for just this detail
                        foreach(XmlNode child in xD.FirstChild.ChildNodes)
                        {
                            if(child.Name == elementName)
                            {                               
                                detailXML = child.OuterXml;  
                                break;
                            }
                        }

                        // Deserializing 
                        XmlSerializer detailSerializer = new XmlSerializer(detailType);
                        StringReader detailReader = new StringReader(detailXML);

                        ResourceDetail myDetail = (ResourceDetail)detailSerializer.Deserialize(detailReader);
                        myEvent.Details = myDetail;   
                       
                    }
                    else if (infTok != null) // If Details is an InfrastructureDetail
                    {
                        Type detailType = typeof(InfrastructureDetail);
                        JToken detailToken = infTok;
                        string elementName = "emlc:InfrastructureDetail";
                        string detailXML = "";

                        // Getting XML for just this detail
                        foreach(XmlNode child in xD.FirstChild.ChildNodes)
                        {
                            if(child.Name == elementName)
                            {                               
                                detailXML = child.OuterXml;  
                                break;
                            }
                        }

                        // Deserializing 
                        XmlSerializer detailSerializer = new XmlSerializer(detailType);
                        StringReader detailReader = new StringReader(detailXML);

                        InfrastructureDetail myDetail = (InfrastructureDetail)detailSerializer.Deserialize(detailReader);
                        myEvent.Details = myDetail;                         
                    }
                    else if (maTok != null) // If Details is a MutualAidDetail
                    {
                        JToken detailToken = maTok;    
                        string elementName = "maid:MutualAidDetail";
                        string detailXML = "";

                        // Getting XML for just this detail
                        foreach(XmlNode child in xD.FirstChild.ChildNodes)
                        {
                            if(child.Name == elementName)
                            {                               
                                detailXML = child.OuterXml;  
                                break;
                            }
                        }

                        // Deserializing Mutual Aid Detail (requires MA Converter) 
                        string json = detailToken.ToString();
                   

                        NIEMUtil.setDefaultDeseralizeSetting();
                        MutualAidDetail myDetail = JsonConvert.DeserializeObject<MutualAidDetail>(json, new JsonConverter[]{new deserialMAConvert(detailXML)}); 


                        myEvent.Details = myDetail;    

                    } else
                    {
                        throw new JsonSerializationException("XML string must be specified");
                    }

                    return myEvent;
                }
               

                } catch (Exception e)
                {
                    string r = e.ToString();
                }
        
            return null;

        }

        // Can serialize as normal, use toString
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
