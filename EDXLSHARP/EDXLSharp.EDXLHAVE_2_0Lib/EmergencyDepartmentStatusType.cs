// ———————————————————————–
// <copyright file="EmergencyDepartmentStatusType.cs" company="EDXLSharp">
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the EmergencyDepartmentStatusType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class EmergencyDepartmentStatusType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL  
    /// The container of all of the elements related to the status of operations of EMS traffic. 
    /// 1. It defines the ability of this emergency department to receive patients via emergency medical services.
    /// </summary>
    private EMSTrafficType emsTraffic;

    /// <summary>
    /// OPTIONAL 
    /// The number of each triage patient type the hospital can accept.
    /// </summary>
    private TriageCountType emsCapacity;

    /// <summary>
    /// OPTIONAL 
    /// The number of each triage patient type the overall hospital currently has.
    /// </summary>
    private TriageCountType emsCensus;

    /// <summary>
    /// OPTIONAL
    /// The container element to indicate the status and offload time for ground ambulance capabilities. 
    /// 1. The time it takes to transfer care of a patient to hospital staff, thereby freeing the ambulance for assignment. 
    /// 2. Select from Normal or Delayed and/or specify the average offload average offload time in minutes.
    /// </summary>
    private OffloadType emsAmbulanceStatus;

    /// <summary>
    /// OPTIONAL
    /// The container element to indicate the status and offload time for air ambulance capabilities. 
    /// 1. The time it takes to transfer care of a patient to hospital staff, thereby freeing the ambulance for assignment. 
    /// 2. Select from Normal or Delayed and/or specify the average offload average offload time in minutes. 
    /// </summary>
    private OffloadType emsAirTransportStatus;

    /// <summary>
    /// Extension for additional items
    /// </summary>
    private SerializableDictionary<string, bool> additionalStatus;

    /// <summary>
    /// Comment Text
    /// </summary>
    private List<string> commentText;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the EmergencyDepartmentStatusType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public EmergencyDepartmentStatusType()
    {
      this.additionalStatus = new SerializableDictionary<string, bool>();
      this.commentText = new List<string>();
    }
    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Addition To Allow Additional Status Reporting
    /// </summary>
    public SerializableDictionary<string, bool> AdditionalStatus
    {
      get { return this.additionalStatus; }
      set { this.additionalStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL  
    /// The container of all of the elements related to the status of operations of EMS traffic. 
    /// 1. It defines the ability of this emergency department to receive patients via emergency medical services.
    /// </summary>
    public EMSTrafficType EMSTraffic
    {
      get { return this.emsTraffic; }
      set { this.emsTraffic = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of each triage patient type the hospital can accept.
    /// </summary>
    public TriageCountType EMSCapacity
    {
      get { return this.emsCapacity; }
      set { this.emsCapacity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of each triage patient type the overall hospital currently has.
    /// </summary>
    public TriageCountType EMSCensus
    {
      get { return this.emsCensus; }
      set { this.emsCensus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container element to indicate the status and offload time for ground ambulance capabilities. 
    /// 1. The time it takes to transfer care of a patient to hospital staff, thereby freeing the ambulance for assignment. 
    /// 2. Select from Normal or Delayed and/or specify the average offload average offload time in minutes.
    /// </summary>
    public OffloadType EMSAmbulanceStatus
    {
      get { return this.emsAmbulanceStatus; }
      set { this.emsAmbulanceStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The container element to indicate the status and offload time for air ambulance capabilities. 
    /// 1. The time it takes to transfer care of a patient to hospital staff, thereby freeing the ambulance for assignment. 
    /// 2. Select from Normal or Delayed and/or specify the average offload average offload time in minutes. 
    /// </summary>
    public OffloadType EMSAirTransportStatus
    {
      get { return this.emsAirTransportStatus; }
      set { this.emsAirTransportStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment Text
    /// </summary>
    public List<string> CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
    }
    #endregion

    #region Public Member Functions
    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Valid Syndication Item to Populate</param>
    /// <param name="contentstr">StringBuilder to create content string </param>
    public void ToGeoRSS(SyndicationItem myitem, StringBuilder contentstr)
    {
      if (this.emsTraffic != null && this.emsTraffic.EMSTrafficStatus != null)
      {
        myitem.Summary = new TextSyndicationContent("EMS Traffic=" + this.emsTraffic.EMSTrafficStatus.ToString());
      }

      if (this.emsCensus != null)
      {
        contentstr.Append("EMS Census: ");
        this.emsCensus.ToGeoRSS(myitem, contentstr);
      }

      if (this.emsCapacity != null)
      {
        contentstr.Append("EMS Capacity: ");
        this.emsCapacity.ToGeoRSS(myitem, contentstr);
      }

      if (this.emsAmbulanceStatus != null && this.emsAmbulanceStatus.EMSOffloadStatus != null)
      {
        contentstr.Append("  Ambulance Status= " + this.emsAmbulanceStatus.EMSOffloadStatus.ToString());
      }

      foreach (KeyValuePair<string, bool> pair in this.additionalStatus)
      {
        contentstr.Append("  " + pair.Key + "=" + pair.Value.ToString());
      }

      if (!string.IsNullOrEmpty(contentstr.ToString()))
      {
        myitem.Content = new TextSyndicationContent(contentstr.ToString());
      }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      if (this.emsTraffic != null)
      {
        xwriter.WriteStartElement("EMSTraffic");
        this.emsTraffic.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.emsCapacity != null)
      {
        xwriter.WriteStartElement("EMSCapacity");
        this.emsCapacity.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.emsCensus != null)
      {
        xwriter.WriteStartElement("EMSCensus");
        this.emsCensus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.emsAmbulanceStatus != null)
      {
        xwriter.WriteStartElement("EMSAmbulanceStatus");
        this.emsAmbulanceStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.emsAirTransportStatus != null)
      {
        xwriter.WriteStartElement("EMSAirTransportStatus");
        this.emsAirTransportStatus.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.additionalStatus.Count > 0)
      {
        xwriter.WriteStartElement("AdditionalStatus");
        foreach (KeyValuePair<string, bool> pair in this.additionalStatus)
        {
          xwriter.WriteStartElement("Service");
          xwriter.WriteElementString("Name", pair.Key);
          xwriter.WriteElementString("Status", pair.Value.ToString());
          xwriter.WriteEndElement();
        }

        xwriter.WriteEndElement();
      }

      if (this.commentText.Count > 0)
      {
        foreach (string commenttmp in this.commentText)
        {
          if (string.IsNullOrEmpty(commenttmp))
          {
            continue;
          }

          xwriter.WriteElementString("CommentText", commenttmp);
        }
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "EMSTraffic":
            this.emsTraffic = new EMSTrafficType();
            this.emsTraffic.ReadXML(node);
            break;
          case "EMSCapacity":
            this.emsCapacity = new TriageCountType();
            this.emsCapacity.ReadXML(node);
            break;
          case "EMSCensus":
            this.emsCensus = new TriageCountType();
            this.emsCensus.ReadXML(node);
            break;
          case "EMSAmbulanceStatus":
            this.emsAmbulanceStatus = new OffloadType();
            this.emsAmbulanceStatus.ReadXML(node);
            break;
          case "EMSAirTransportStatus":
            this.emsAirTransportStatus = new OffloadType();
            this.emsAirTransportStatus.ReadXML(node);
            break;
          case "CommentText":
            if (this.commentText == null)
            {
              this.commentText = new List<string>();
            }

            this.commentText.Add(node.InnerText);
            break;
          case "AdditionalStatus":
            string key;
            bool value;
            foreach (XmlNode childNode in node.ChildNodes)
            {
              if (childNode.ChildNodes[0].LocalName == "Name")
              {
                key = childNode.ChildNodes[0].InnerText;
                value = bool.Parse(childNode.ChildNodes[1].InnerText);
              }
              else if (childNode.ChildNodes[1].LocalName == "Name")
              {
                key = childNode.ChildNodes[1].InnerText;
                value = bool.Parse(childNode.ChildNodes[0].InnerText);
              }
              else
              {
                throw new ArgumentException("Bad things with the extension");
              }
            }

            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in EmergencyDepartmentStatusType");
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
    }
    #endregion

    #region Protected Member Functions
    #endregion
  }
}
