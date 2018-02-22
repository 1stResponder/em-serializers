using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EMS.NIEM.EMLC
{
  /// <summary>
  /// NIEM Utility Helper Class
  /// </summary>
    public static class NIEMEmlcUtil
    {
        /// <summary>
        /// Converts the XML into JSON
        /// Fails if this the xml string is invalid
        /// </summary>
        /// <remarks> 
        /// If this contains aMutualAidDetail then that would still need to be formatted correctly later on to 
        /// be deserialized correctly (This is done by the Json.net converter)
        /// </remarks>
        /// <param name="xml">XML string</param>
        /// <returns>JSON string from the XML if successful, empty string if fails</returns>
        public static string xmlToJson(string xml)
        {
            try
            {               
                XDocument xd = XDocument.Parse(xml);
                string json = JsonConvert.SerializeXNode(xd);
                return json;

            } catch(Exception e)
            {
                throw new InvalidOperationException("XML string is not a valid", e);
                //return "";
            }            
        }
    }
}
