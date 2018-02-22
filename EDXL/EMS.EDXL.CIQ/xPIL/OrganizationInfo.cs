//// ———————————————————————–
//// <copyright file="OrganizationInfo.cs" company="EDXLSharp">
////    Licensed under the Apache License, Version 2.0 (the "License");
////    you may not use this file except in compliance with the License.
////    You may obtain a copy of the License at
////    http://www.apache.org/licenses/LICENSE-2.0
////    Unless required by applicable law or agreed to in writing, software
////    distributed under the License is distributed on an "AS IS" BASIS,
////    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
////    See the License for the specific language governing permissions and
////    limitations under the License.
//// </copyright>
//// ———————————————————————–

//using System;
//using System.Xml;

//namespace EMS.EDXL.CIQ
//{
//  /// <summary>
//  /// Base Organization Information element with Attributes
//  /// </summary>
//  [Serializable]
//  public class OrganizationInfo 
//  {
//    #region Private Member Variables

//    /// <summary>
//    /// Type of Organization. For purposes of EDXL HAVE standard, this could be hospital, nursing center, trauma center etc.
//    /// </summary>
//    private string type;

//    /// <summary>
//    /// Operating hour start time for the Organization ex: 09:00:00.
//    /// </summary>
//    private DateTime operatingHourStartTime;

//    /// <summary>
//    /// Operating hour end time for the Organization ex: 17:00:00.
//    /// </summary>
//    private DateTime operatingHourEndTime;

//    #endregion

//    #region Constructors

//    /// <summary>
//    /// Initializes a new instance of the OrganizationInfo class
//    /// Default Constructor - Does Nothing
//    /// </summary>
//    public OrganizationInfo()
//    {
//    }

//    #endregion

//    #region Public Accessors

//    /// <summary>
//    /// Gets or sets
//    /// Operating hour end time for the Organization ex: 17:00:00.
//    /// </summary>
//    public DateTime OperatingHourEndTime
//    {
//      get { return this.operatingHourEndTime; }
//      set { this.operatingHourEndTime = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// Operating hour start time for the Organization ex: 09:00:00.
//    /// </summary>
//    public DateTime OperatingHourStartTime
//    {
//      get { return this.operatingHourStartTime; }
//      set { this.operatingHourStartTime = value; }
//    }

//    /// <summary>
//    /// Gets or sets
//    /// Type of Organization. For purposes of EDXL HAVE standard, this could be hospital, nursing center, trauma center etc.
//    /// </summary>
//    public string Type
//    {
//      get { return this.type; }
//      set { this.type = value; }
//    }
//    #endregion

//    #region Public Member Functions

//    /// <summary>
//    /// Reads an XML Position From An Existing DOM
//    /// </summary>
//    /// <param name="rootnode">Node Containing the GML Position</param>
//    public void ReadXML(XmlNode rootnode)
//    {
//      if (rootnode.LocalName == "OrganisationInfo")
//      {
//        foreach (XmlAttribute attrib in rootnode.Attributes)
//        {
//          if (string.IsNullOrEmpty(attrib.InnerText))
//          {
//            continue;
//          }

//          switch (attrib.LocalName)
//          {
//            case "Type":
//              this.type = attrib.InnerText;
//              break;
//            case "OperatingHourStartTime":
//              this.operatingHourStartTime = DateTime.Parse(attrib.InnerText);
//              break;
//            case "OperatingHourEndTime":
//              this.operatingHourEndTime = DateTime.Parse(attrib.InnerText);
//              break;
//            case "#comment":
//              break;
//            default:
//              if (attrib.Prefix != "xmlns")
//              {
//                throw new ArgumentException("Unexpected Child Attribute Name: " + attrib.Name + " in OrganizationName");
//              }

//              break;
//          }
//        }
//      }
//      else
//      {
//        throw new ArgumentException("Invalid Node Name: " + rootnode.Name + " in OrganizationName");
//      }

//      this.Validate();
//    }

//    /// <summary>
//    /// Writes This GML Position to an Existing XML Document
//    /// </summary>
//    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
//    public void WriteXML(XmlWriter xwriter)
//    {
//      this.Validate();
//      xwriter.WriteStartElement(EDXLConstants.XPILPrefix, "OrganisationInfo", EDXLConstants.XPIL10Namespace);
//      if (!string.IsNullOrEmpty(this.type))
//      {
//        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "Type", EDXLConstants.XPIL10Namespace, this.type);
//      }

//      if (this.operatingHourStartTime != DateTime.MinValue)
//      {
//        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "OperatingHourStartTime", EDXLConstants.XPIL10Namespace, this.operatingHourStartTime.ToString("HH:mm:ss.f%K"));
//      }

//      if (this.operatingHourEndTime != DateTime.MinValue)
//      {
//        xwriter.WriteAttributeString(EDXLConstants.XPILPrefix, "OperatingHourEndTime", EDXLConstants.XPIL10Namespace, this.operatingHourEndTime.ToString("HH:mm:ss.f%K"));
//      }

//      xwriter.WriteEndElement();
//    }

//    /// <summary>
//    /// Validates This Message element For Required Values and Conformance
//    /// </summary>
//    public void Validate()
//    {
//    }
//    #endregion

//    #region Protected Member Functions
//    #endregion

//    #region Private Member Functions

//    #endregion
//  }
//}