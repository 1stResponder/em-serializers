using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NIEMSHARP.NIEMEMLCLib
{
    /// <summary>
    /// Represents a location identified by a unit of a grid system overlaid on an area
    /// </summary>
    public class AddressGrid
    {

        /// <summary>
        /// Initializes a new instance of the AddressGrid class
        /// </summary>
        public AddressGrid() { 
       
                ID = "";
                Text = "";
        }


        /// <summary>
        /// Initializes a new instance of the AddressGrid class
        /// </summary>
        /// <param name="id">ID of grid</param>
        /// <param name="text">The unit, quadrant, or other subdivision of the grid</param>
        public AddressGrid(string id, string text) 
        { 
            ID = id;
            Text = text;
        }     

        /// <summary>
        /// Gets or sets the Id for the grid
        /// Required Element 
        /// </summary>
        [XmlElement("AddressGridID", Namespace = Constants.NiemcoreNamespace)]
        public string ID
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the unit, quadrant, or other subdivision of the grid
        /// Required Element
        /// </summary>
        [XmlElement("AddressGridText", Namespace = Constants.NiemcoreNamespace)]
        public string Text
        {
            get; set;
        }



    }
}
