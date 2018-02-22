/*-----------------------------------------------------------------------
  Limitations of NIEMSharp Serializer:
   Most of these limitations have to do with how XML gets converted to JSON.  
   
   1] Json will treat empty elements as null when converting.  
       ex: <myEl /> --> "myEl": null 
   This is a problem with objects specifically because we have objects that are required by other elements but can be empty.  In this 
   scenario, the program will throw an error since a required object is null.  What we need instead, is for empty elements which are 
   objects to be treated as empty and not null.
   
       ex: <myEl /> --> "myEl": {}
       
   To make this happen, I created a function that goes through the XML, node by node, and gets the name of each node.  If that name is 
   one that I specified as a valid empty object then the function adds an attribute which contains that nodes type and then continues 
   on.  This attribute makes it clear to the JSON that the element is an object so the JSON will convert it correctly.   
    
       ex: <myEL /> --> <myEl p12:jsontype="NIEMSharp.MutualAidRequest.AidResponding.AidRespondingContactInformation, NIEMSharp" />
       
   This works but it does require manually specifying each object that can be empty.  Right now, these objects are only specified for 
   NIEMSharp so when using the other libraries the issue will still exist.  It should not throw errors (since null elements are 
   ignored) but it will not include them when deserializing.  
   
   
   2] Json will treat one element arrays as strings when converting.  This problem makes sense since there is no way for JSON to know 
   that a single element is an array without an attribute (which is not necessary for the schema or XML).  In this scenario, the 
   program will throw an error since a List/Array != string.  
    
       ex: <myEL>one</myEL> --> "myEL": "one"
       
   To fix this, I did the same as above except I specified names of elements that should be lists/Arrays. 
   
       ex: <myEL>one</myEL> --> <myEl p12:Array="true">one</myEL>
       <myEl p12:Array="true">one</myEL> --> "myEl": ["one"]
       
   Like before, I had to manually enter all the names of elements that are lists so this will not work with other libraries.  
   This means that deserializing single item lists from the other libraries can cause fatal errors unless they have this 
   attribute.
  
  3] Child elements from other libraries have no namespace as far as JSON is concerned.  In order to prevent errors I had to 
  manually remove any default namespaces they may of been given.  Also, if this kind of element has a namespace prefix it will be 
  ignored since the JSON will convert the element name to "prefix--name" and that element will not exist in the other library.  
  
  4] Attributes must be manually specified in the libraries in which they come from.  Otherwise, they will be turned into 
  normal elements during serialization and ignored during deserialization.  You can specify an attribute by adding this above 
  the class member:

 		[JsonProperty(PropertyName = "@myName")]

   Where myName is the element's name and the @ tells JSON.net it's an attribute.  

  5] Be cautious when renaming elements or changing namespaces/namespace prefixes.  Many objects/members had to be hard coded 
  during the JSON serialization/deserialization.  Mainly dynamic members and the objects that substitute them.  
-----------------------------------------------------------------------*/


using System;
using Newtonsoft.Json;
using NIEMSharp.MutualAidRequest;
using NIEMSharp.MutualAidRespond;
using NIEMSHARP.NIEMEMLCLib.CoreWarpper;
using NIEMSHARP.NIEMEMLCLib;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace NIEMSharp
{
    // NOTE: The JSON name/namespace of this class is hard coded in the JSON serialization/deserialization process.  
    // If the class name is changed then that must be updated as well.   
    // Places to Update:
    //      ToString() 
    //      deserialMAConvert (class)
    //      NIEMUtil.formatXML
    //      NIEMSHARP.EDXLSharp.NIEMEMLCLib.deSerialEventConverter 


    /// <summary>
    /// Represents a mutual aid request or response 
    /// </summary>
    [JsonObject(Title = "MutualAidDetail")]
    public class MutualAidDetail: EventDetails
    {

        /// <summary>
		/// Initializes a new instance of the MutualAidDetail class
		/// </summary>
        public MutualAidDetail() { 
            xmlnsAttributes = new List<XAttribute>();
            prefixList = XElement.Parse(NIEMSharp.Properties.Resources.NameSpacePrefixMapping);       
            xmlnsAttributes = NIEMUtil.readMapping(); 
        }

        /// <summary>
        /// Initializes a new instance of the MutualAidDetail class
        /// </summary>
        /// <param name="req">Mutual Aid Request</param>
        public MutualAidDetail(MutualAidRequest.AidRequested req): this()
        {
            Message = req;
        }

        /// <summary>
        /// Initializes a new instance of the MutualAidDetail class 
        /// </summary>
        /// <param name="res">Mutual Aid Response</param>
        public MutualAidDetail(MutualAidRespond.AidResponding res): this()
        {
            Message = res;
        }
         
         [JsonIgnore]
         private dynamic message;        
         

         // NOTE: The name of this member is hard coded in the JSON serialization/deserialization process.
         // Places to Update:
         // SubsitutePropertyNameContractResolver (class)
           
         /// <summary>
         /// Gets or sets the mutual aid request or response
         /// Required Element
         /// </summary>
         [JsonProperty] /// Defined in ContractResolver
         public dynamic Message {
            get 
            {
                return message;
            }
            set
            {
                if(value is MutualAidMessage)
                {
                    message = value;

                } else
                {
                    throw new ArgumentException("value","Message must be of MutualAidMessage Type");
                }

            }
         }  

        /// <summary>
        /// If Message is null then this should throw an error 
        /// </summary>
        /// <returns>true or false</returns>
        public bool ShouldSerializeMessage()
        {
            if(Message == null)
            {
                return false;
            }

            return true;
        }

         
        /// <summary>
        /// Will hold xml mapping file as XElement
        /// </summary>
        [JsonIgnore]
        private XElement prefixList {get; set;}

        /// <summary>
        /// List of all the namespaces to be added to xml doc
        /// </summary>
        [JsonIgnore]
        private List<XAttribute> xmlnsAttributes {get; set;}

        //-- Serializer methods 

        /// <summary>
        /// Returns XML string representing this MutualAid event
        /// </summary>
        /// <returns>XML String</returns>
        public override string ToString()
        {
            if(Message == null)
            {
                throw new JsonSerializationException("MutualAidDetail's Message cannot be null");
                return "";
            }

            string json = ToJson(this); // Holds JSON object representing the object 
            XDocument xmlDoc = JsonConvert.DeserializeXNode(json,"maid--MutualAidDetail");

            foreach (XElement el in xmlDoc.Descendants()) 
            {      
                string elementName = el.Name.LocalName;

                // Parsing JSON element names to split the namespace prefix and get the namespace URL.
                // Removes the prefix-- from the name and instead associates the element with it's namespace
                // Element names are in the form:  prefix--Name
                if (elementName.IndexOf("--") >= 0)
                {
                    
                    string prefix = elementName.Substring(0, elementName.IndexOf("--")); // prefix, used to map
                    string LocalName = elementName.Substring(elementName.IndexOf("--") + 2); // actual name of element
                    XNamespace nameSpaceMatch = prefixList.DescendantsAndSelf(prefix).First().Value; // namespace url

                    el.Name = nameSpaceMatch + LocalName; // new name
                }
            }

            // Adding namespaces to root
            foreach(XAttribute ab in xmlnsAttributes)
            {
                xmlDoc.Root.Add(ab);
            }

            var writer = new StringWriter();
            xmlDoc.Save(writer);

            return writer.ToString();
        }

        /// <summary>
        /// Returns Json string used to create XML 
        /// </summary>
        /// <param name="de">MutualAidDetail object being serialized</param>
        /// <returns>Json String</returns>
        private string ToJson(MutualAidDetail de)
        {
            List<Type> types = new List<Type>(); // Will hold runtime types of abstract elements 
         
            //-- Here I am adding the runtime types of our dynamic objects so the deserializer knowns which element name to use

            // MutualAidMessage
            try {

                Type messageType = Message.GetType();

                if(messageType == typeof(AidRequested))
                {
                    types.Add(new AidRequested().GetType());

                } else if(messageType == typeof(AidResponding))
                {                 
                   types.Add(new AidResponding().GetType());
                }

            } catch(Exception e)
            {
                // Message is null or invalid 
            }


           // RequestResourceKind
           try {

                Type resource = Message.Resource.ResourceList.GetType().GenericTypeArguments[0];
                
                if (resource == typeof(SpecificResource))
                {
                    types.Add(new SpecificResource().GetType());
                }
                else if (resource == typeof(GenericResource))
                {
                   types.Add(new GenericResource().GetType());
                }
                else if (resource == typeof(MissionNeed))
                {
                   types.Add(new MissionNeed().GetType());
                }
            } catch(Exception e)
            {
                // ResourceList is null or invalid 
            }

            // RespondingResourceKind
            try {

                Type resource = Message.Resources.ResourceList.GetType().GenericTypeArguments[0];
                
                if (resource == typeof(Person))
                {
                    types.Add(new Person().GetType());
                }
                else if (resource == typeof(Equipment))
                {
                   types.Add(new Equipment().GetType());
                }
               
            } catch(Exception e)
            {
                // ResourceList is null or invalid 
            }


            // AreaRegion
            try {

                Type areaRegType = Message.location.AreaRegion.GetType();

                if (areaRegType == typeof(LocationEllipse))
                {
                    types.Add(new LocationEllipse().GetType());
                }
                else if (areaRegType == typeof(LocationExternalPolygon))
                {
                    types.Add(new LocationExternalPolygon().GetType());
                }
                else if (areaRegType == typeof(LocationLineString))
                {
                    types.Add(new LocationLineString().GetType());
                }

            } catch(Exception e)
            {
                // AreaRegion is null or invalid
            }


            JsonSerializerSettings settings = new JsonSerializerSettings();
            SubsitutePropertyNameContractResolver cr = new SubsitutePropertyNameContractResolver(); // Contract Resolver renames the dynamic elements
            cr.setTypes(types); // sets runtime types in contract resolver 
            settings.ContractResolver = cr;
            settings.TypeNameHandling = TypeNameHandling.None;
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;

            
            string json = JsonConvert.SerializeObject(de, settings);
            return json;
        }

    }
}
