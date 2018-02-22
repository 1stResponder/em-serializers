using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NIEMSharp
{
    public static class NIEMUtil
    {      
        
        /// <summary>
        /// Parses the prefix to namespace mapping file to create a list
        /// of namespace attributes.
        /// Sets list of Namespaces to this newly created list
        /// Fails if resource file is not found
        /// </summary>
        public static List<XAttribute> readMapping()
        {
            List<XAttribute> xmlnsAttributes = new List<XAttribute>();
            XElement prefixList = XElement.Parse(NIEMSharp.Properties.Resources.NameSpacePrefixMapping);

            foreach(XElement n in prefixList.Descendants())
            {
                        string prefix = n.Name.LocalName;
                        string nameSpaceURL = n.Value;

                        xmlnsAttributes.Add(new XAttribute(XNamespace.Xmlns + prefix, nameSpaceURL));                        
            }

            return xmlnsAttributes;
        }

        
        /// <summary>
        /// For MutualAid JSON deserialization.  Formats XML so that more data is preserved when converting to JSON.
        /// If the string is already formatted then the same XML string is returned
        /// If the string is not a MutualAidDetai then an empty string is returned and an exception is thrown
        /// </summary>
        /// <remarks>The XML string is considered already formatted if the root node is "maid--MutualAidDetail"</remarks>
        /// <param name="xml">MutualAid XML string</param>
        /// <returns>Formatted XML string</returns>
        public static string formatXML(string xml)
        {
            //-- Formatting the XML for proper JSON deserialization
            //        1] Adding all known namespaces to Root node and removing them from children (JSON treats all elements with
            //              explicit namespace attributes as objects)
            //        2] Specifying types for lists (JSON will treat 1 element lists as strings) 
            //        3] Specifying types for objects then can be empty but still valid (JSON makes these NULL otherwise)
            //        4] Replacing : with -- for proper JSON deserialization (Quirk from serialization)
            //        5] Removing unknown default namespaces from child nodes (FRESH will add these when an element does not
            //             specify it's namespace).  This is necessary for objects outside of the NIEMSharp project since
            //              they are not configured to work with JSON and therefor have no namespace as far as the JSON 
            //              serializer/deserializer is concerned. 
            //--

            XElement root;
            XDocument xmlDoc = XDocument.Parse(xml);

            // Checking if XML is already formatted
            if(xmlDoc.Root.Name == "maid--MutualAidDetail")
            {
                return xml;     
            }

            // Making sure XML is MutualAidDetail
            if(xmlDoc.Root.Name.LocalName != "MutualAidDetail")
            {
                throw new InvalidOperationException("XML string is not a MutualAidDetail");
                return "";     
            }           

            // Adding known namespaces to root element 
            List<XAttribute> xmlnsAttributes = readMapping();
            
            foreach(XAttribute ab in xmlnsAttributes)
            {
                if(xmlDoc.Root.Attribute(ab.Name) == null)
                {
                   xmlDoc.Root.Add(ab);
                }
            }

            foreach (XElement el in xmlDoc.Descendants())
            {
                XNamespace nsJson = "json";
                XNamespace ns = "http://james.newtonking.com/projects/json";

                switch (el.Name.LocalName)
                {
                    // Specifying these are lists
                    case "AidRespondingPerson":
                    case "AidRespondingCredential":
                    case "ResourceTypeDescriptorExtension":
                    case "AidRespondingEquipment":
                    case "AidRequestedGenericResource":
                    case "AidRequestedSpecificResource":
                    case "AidRequestedMissionNeed":
                        el.Add(new XAttribute(ns + "Array", true));
                        break;

                    // Specifying the types of objects that can empty but valid 
                    case "AidRequested":
                        el.Add(new XAttribute(ns + "jsontype", "NIEMSharp.MutualAidRequest.AidRequested, NIEMSharp"));
                        break;
                    case "AidRequestedResources":
                        el.Add(new XAttribute(ns + "jsontype", "NIEMSharp.MutualAidRequest.RequestedResources, NIEMSharp"));
                        break;
                    case "AidRespondingContactInformation":
                        el.Add(new XAttribute(ns + "jsontype", "NIEMSharp.MutualAidRequest.AidResponding.AidRespondingContactInformation, NIEMSharp"));
                        break;
                    case "AidRespondingResources":
                        el.Add(new XAttribute(ns + "jsontype", "NIEMSharp.MutualAidRequest.AidResponding, NIEMSharp"));
                        break;
                    case "AidRequestedLocationExtension":
                        el.Add(new XAttribute(ns + "jsontype", "NIEMSharp.MutualAidRequest.AidRequested.AidRequestedLocationExtension, NIEMSharp"));
                        break;                  
                }       

                // If the element has a namespace prefix then add it to element name, separated by '--'
                if (!(string.IsNullOrWhiteSpace(el.GetPrefixOfNamespace(el.Name.Namespace))))
                {
                    el.Name = el.GetPrefixOfNamespace(el.Name.Namespace) + "--" + el.Name.LocalName;
                } 
                else // This element has no namespace prefix.  This means it is from another library and not configured for JSON
                {
                    // Removing any namespace attributes associated with this element 
                    // Required to prevent errors from unknown namespaces and to get the value to correctly deserialize
                    // Should be removed once the other libraries are configured for JSON since it can put the element in the wrong
                    // namespace once converted back to XML. (XML will assume it's the parent's namespace)
                    if(el.Attribute("xmlns") != null) 
                    {
                        el.Attribute("xmlns").Remove();  
                    }

                    el.Name = el.Name.LocalName;
                }

            }        

            StringWriter sw = new StringWriter();
            xmlDoc.Save(sw, SaveOptions.OmitDuplicateNamespaces); // this removes the extra namespace decelerations from the children     
            return sw.ToString();
        }

        /// <summary>
        /// When called sets the default deserialization settings for deserialization.  
        /// Without these settings the deserialization may not be successful
        /// </summary>
        public static void setDefaultDeseralizeSetting()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore       
            };

        }

        /// <summary>
        /// Converts the Mutual Aid XML into JSON 
        /// Fails if this is not an MA object
        /// </summary>
        /// <see cref="formatXML"/>
        /// <param name="xml">Mutual Aid XML string</param>
        /// <returns>JSON string from the XML if successful, empty string if fails</returns>
        public static string xmlToJson(string xml)
        {
            try
            {               
                xml = formatXML(xml);
                XDocument xd = XDocument.Parse(xml);
                
                string xmlNoDec = xd.Root.ToString();
                xd = XDocument.Parse(xmlNoDec);

                string json = JsonConvert.SerializeXNode(xd);
                return json;

            } catch(Exception e)
            {
                throw new InvalidOperationException("XML string is not a valid MutualAidDetail");
                return "";
            }            
        }

    }
}
