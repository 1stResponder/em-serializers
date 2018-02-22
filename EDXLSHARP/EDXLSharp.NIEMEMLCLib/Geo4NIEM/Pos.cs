using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EDXLSharp.NIEMEMLCLib.Geo4NIEM
{
   
    /// <summary>
    /// Holds coordinates for a sequence of direct positions
    /// </summary>
    public class Pos: posKind
    {
        /// <summary>
        /// Initializes instance of the Pos class
        /// </summary>
        public Pos()
        {
            posList = new List<double>();
        }

        /// <summary>
        /// Holds list of coordinates for this position
        /// </summary>
        [XmlIgnore]
        public List<double> posList
        {
            get; set;
        }

        /// <summary>
        /// Holds serialized version of the posList 
        /// </summary>
        [XmlText]
        public string SerialPosList
        {
            get
              {
                StringBuilder sb = new StringBuilder();
                foreach (double d in posList)
                {
                  sb.Append(d.ToString());
                  sb.Append(" ");                 
                }

                string st = sb.ToString();
                st = st.Trim();
                return st;
              }

            set
             {         
                string[] split = value.Split(' ');
                foreach (string spl in split)
                {
                    posList.Add(double.Parse(spl));
                }
                
             }  

        }


    }
}
