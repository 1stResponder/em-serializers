using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NIEMSharp.MutualAidRequest;
using NIEMSharp.MutualAidRespond;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NIEMSharp
{

    /// <summary>
    /// Does all the work necessary to properly deserialize a Mutual Aid Object.
    /// </summary>
    public class deserialMAConvert: JsonConverter
    {
        protected string xmlString;

        /// <summary>
        /// Initializes instance of this converter 
        /// </summary>
        public deserialMAConvert()
        {
        }

        /// <summary>
        /// Initializes instance of this converter 
        /// </summary>
        /// <param name="xml">XML version of this Mutual Aid Object</param>
        public deserialMAConvert(string xml)
        {
            xmlString = xml;
        }

        /// <summary>
        /// If the object is a MutualAidDetail then it can be converted 
        /// </summary>
        /// <param name="objectType">Type of the Object being deserialized</param>
        /// <returns>True or false</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MutualAidDetail);
        }

        /// <summary>
        /// Sets XML string for the converter.  Must contain XML of object being deserialized
        /// </summary>
        /// <param name="xml">XML version of this Mutual Aid Object</param>
        public void setXML(string xml)
        {
            xmlString = xml;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject obj = JObject.Load(reader);
                Object root = null;

                // TODO: Use xmlString to solve issue of empty vs null elements  
                if (xmlString != null)
                {
                    string formatXML = "";

                    //-- Formatting XML for deserialization                      
                    XDocument maDoc = XDocument.Parse(xmlString, LoadOptions.None);

                    var xmlWriter = new StringWriter();
                    maDoc.Save(xmlWriter);
                    formatXML = xmlWriter.ToString();
                    string formattedJson = NIEMUtil.xmlToJson(formatXML);
                    

                    reader = new JsonTextReader(new StringReader(formattedJson));

                } else
                {
                    //-- Converting JSON back to XML string so it can be formatted for deserialization 
                    string rootJson = obj.SelectToken("maid:MutualAidDetail").ToString();
                    XDocument xmlDoc = JsonConvert.DeserializeXNode(rootJson, "maid--MutualAidDetail");


                    StringWriter xmlWriter = new StringWriter();
                    xmlDoc.Save(xmlWriter);
                    string xml = xmlWriter.ToString();

                    string formattedJson = NIEMUtil.xmlToJson(xml);

                    reader = new JsonTextReader(new StringReader(formattedJson));    
                }


                    //-- Now starting deserialization

                    obj = JObject.Load(reader);
                    root = null;


                    JToken aidReq = obj.SelectToken("maid--MutualAidDetail.maid--AidRequested");
                    JToken aidRes = obj.SelectToken("maid--MutualAidDetail.maid--AidResponding");

                    if (aidReq != null)
                    {
                        JsonSerializerSettings setting = new JsonSerializerSettings();
                        setting.Converters.Add(new deserialRequestedResourceConvert());
                        setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;


                        string json = aidReq.ToString();
                        AidRequested ar = JsonConvert.DeserializeObject<AidRequested>(json, setting);
                        root = Activator.CreateInstance(typeof(MutualAidDetail), ar);


                    }
                    else if (aidRes != null)
                    {
                        JsonSerializerSettings setting = new JsonSerializerSettings();
                        setting.Converters.Add(new deserialRespondingResourceConvert());
                        setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;


                        string json = aidRes.ToString();
                        AidResponding ar = JsonConvert.DeserializeObject<AidResponding>(json, setting);
                        root = Activator.CreateInstance(typeof(MutualAidDetail), ar);


                    }
                    else
                    {
                        // no resources, invalid 
                        throw new JsonSerializationException("Message not defined.  Must be AidResponding or AidRequesting Message");
                    }
                
                    return root;

            } catch(Exception e)
            {
                return null;
            }

        }

        // Uses SubsitutePropertyNameContractResolver for serialization
         public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
    
    /// <summary>
    /// Converter used to desSeralize RequestedResouceKind 
    /// </summary>
    public class deserialRequestedResourceConvert: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RequestedResources);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            JObject obj = null;
            Object root = null; // Will hold instance of Requested Resource Object 

            try
            {
                obj = JObject.Load(reader);

            } catch(Exception e)
            {
                // no RequestedResources
                root  = Activator.CreateInstance(typeof(RequestedResources));
                return root;
            }
           
            JToken genRes = obj.SelectToken("maid--AidRequestedGenericResource");
            JToken speRes = obj.SelectToken("maid--AidRequestedSpecificResource");;
            JToken misNeed = obj.SelectToken("maid--AidRequestedMissionNeed");


            if(genRes != null)
            {
                List<GenericResource> resList = new List<GenericResource>(); // will hold list of generic resources 
                JArray resources = JArray.Parse(genRes.ToString());

                // For each Generic Resource
                for(int x = 0; x < resources.Count; x++)
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                  
                    JToken resTok = resources[x];
                    GenericResource temp = JsonConvert.DeserializeObject<GenericResource>(resTok.ToString(), setting);
                    resList.Add(temp);
                }

                root  = Activator.CreateInstance(typeof(RequestedResources),resList);
                
            } else if(speRes != null)
            {
                List<SpecificResource> resList = new List<SpecificResource>(); // will hold list of specific resources 
                JArray resources = JArray.Parse(speRes.ToString());

                // For each Specific Resource
                for(int x = 0; x < resources.Count; x++)
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                   

                    JToken resTok = resources[x];
                    SpecificResource temp = JsonConvert.DeserializeObject<SpecificResource>(resTok.ToString(), setting);
                    resList.Add(temp);
                }

                root  = Activator.CreateInstance(typeof(RequestedResources),resList);

                
            } else if(misNeed != null)
            {
               List<MissionNeed> resList = new List<MissionNeed>(); // will hold list of Mission Need resources 
               JArray resources = JArray.Parse(misNeed.ToString());

                // For each Mission Need Resource
                for(int x = 0; x < resources.Count; x++)
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    

                    JToken resTok = resources[x];
                    MissionNeed temp = JsonConvert.DeserializeObject<MissionNeed>(resTok.ToString(), setting);
                    resList.Add(temp);
                }

                root  = Activator.CreateInstance(typeof(RequestedResources),resList);
                
            } else 
            {
                // no resources 
                root  = Activator.CreateInstance(typeof(RequestedResources));

            }           

            return root;

           
        }

         public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }


    
    /// <summary>
    /// Converter used to desSeralize RespondingResourceKind
    /// </summary>
    public class deserialRespondingResourceConvert: JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RespondingResource);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {            
      
            JObject obj = JObject.Load(reader);
            Object root = null; // Will hold instance of Responding Resource Object 
            
           
            JToken perRes = obj.SelectToken("maid--AidRespondingPerson");
            JToken eqRes = obj.SelectToken("maid--AidRespondingEquipment");;


            if(perRes != null)
            {
                List<Person> resList = new List<Person>(); // will hold list of generic resources 
                JArray resources = JArray.Parse(perRes.ToString());

                // For each Generic Resource
                for(int x = 0; x < resources.Count; x++)
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    setting.DateParseHandling = DateParseHandling.DateTime;

                    JToken resTok = resources[x];
                    Person temp = JsonConvert.DeserializeObject<Person>(resTok.ToString(), setting);
                    resList.Add(temp);
                }

                root  = Activator.CreateInstance(typeof(RespondingResource),resList);
                
            } else if(eqRes != null)
            {
                List<Equipment> resList = new List<Equipment>(); // will hold list of specific resources 
                JArray resources = JArray.Parse(eqRes.ToString());

                // For each Specific Resource
                for(int x = 0; x < resources.Count; x++)
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    setting.DateParseHandling = DateParseHandling.DateTime;

                    JToken resTok = resources[x];
                    Equipment temp = JsonConvert.DeserializeObject<Equipment>(resTok.ToString(), setting);
                    resList.Add(temp);
                }

                root  = Activator.CreateInstance(typeof(RespondingResource),resList);

                
            } else 
            {
                // no resources
                root  = Activator.CreateInstance(typeof(RespondingResource));

            }           

            return root;

            

        }

         public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }

}



