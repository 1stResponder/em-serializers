// ———————————————————————–
// <copyright file="TransportInfoType.cs" company="EDXLSharp">
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
using System.Xml;
using EDXLSharp;

namespace MEXLTEPLib
{
  /// <summary>
  /// Class That Represents Transport Information for a Patient
  /// </summary>
  [Serializable]
  public partial class TransportInfoType : IComposable
  {
    #region Private Member Variables

    /// <summary>
    /// Is this Unit Transporting
    /// </summary>
    private bool? transporting;

    /// <summary>
    /// ID of the Transporting Unit
    /// </summary>
    private string transportUnitID;

    /// <summary>
    /// Type of Vehicle
    /// </summary>
    private VLList vehicleType;

    /// <summary>
    /// Name of Agency Vehicle is From
    /// </summary>
    private string vehicleAgency;

    /// <summary>
    /// State Vehicle is From
    /// </summary>
    private string vehicleState;

    /// <summary>
    /// ETA To Destination
    /// </summary>
    private DateTime destinationETA;

    /// <summary>
    /// Actual Departure DateTime
    /// </summary>
    private DateTime departureDateTime;

    /// <summary>
    /// Actual Arrival DateTime
    /// </summary>
    private DateTime arrivalDateTime;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the TransportInfoType class
    /// Default Constructor - Initializes List
    /// </summary>
    public TransportInfoType()
    {
      this.vehicleType = new VLList("VehicleType");
    }

    #endregion

    #region Public Accessors

    /// <summary>
    /// Gets or sets
    /// Actual Arrival DateTime
    /// </summary>
    public DateTime ArrivalDateTime
    {
      get
      {
        return this.arrivalDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.arrivalDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// Actual Departure DateTime
    /// </summary>
    public DateTime DepartureDateTime
    {
      get
      {
        return this.departureDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.departureDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// ETA To Destination
    /// </summary>
    public DateTime DestinationETA
    {
      get
      {
        return this.destinationETA.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.destinationETA = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// State Vehicle is From
    /// </summary>
    public string VehicleState
    {
      get { return this.vehicleState; }
      set { this.vehicleState = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Name of Agency Vehicle is From
    /// </summary>
    public string VehicleAgency
    {
      get { return this.vehicleAgency; }
      set { this.vehicleAgency = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Type of Vehicle
    /// </summary>
    public IList<ValueList> VehicleType
    {
      get { return this.vehicleType.Values; }
      set { this.vehicleType.Values = value; }
    }

    /// <summary>
    /// Gets or sets
    /// ID of the Transporting Unit
    /// </summary>
    public string TransportUnitID
    {
      get { return this.transportUnitID; }
      set { this.transportUnitID = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Is this Unit Transporting
    /// </summary>
    public bool? Transporting
    {
      get { return this.transporting; }
      set { this.transporting = value; }
    }

    #endregion

    #region IComposable Interface Functions

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      xwriter.WriteStartElement(EDXLConstants.MEXLTEPPrefix, "TransportInfoType", EDXLConstants.MEXLTEP10Namespace);
      if (this.transporting != null)
      {
        xwriter.WriteElementString("Transporting", this.transporting.ToString());
      }

      if (!string.IsNullOrEmpty(this.transportUnitID))
      {
        xwriter.WriteElementString("TransportingUnitUD", this.transportUnitID);
      }

      this.vehicleType.WriteXML(xwriter);

      /*if (this.vehicleType != null)
      //{
      //  foreach (ValueList list in this.vehicleType)
      //  {
      //    xwriter.WriteStartElement("VehicleType");
      //    list.WriteXML(xwriter);
      //    xwriter.WriteEndElement();
      //  }
      //}*/
      
      if (!string.IsNullOrEmpty(this.vehicleAgency))
      {
        xwriter.WriteElementString("VehicleAgency", this.vehicleAgency);
      }
      
      if (!string.IsNullOrEmpty(this.vehicleState))
      {
        xwriter.WriteElementString("VehicleState", this.vehicleState);
      }
      
      if (this.destinationETA != DateTime.MinValue)
      {
        xwriter.WriteElementString("DetinationETA", this.destinationETA.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }
      
      if (this.departureDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("DepartureDT", this.departureDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }
      
      if (this.arrivalDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString("ArrivalDT", this.arrivalDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }
      
      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      ////ValueList temp;
      if (rootnode.LocalName == "TransportInfoType")
      {
        this.vehicleType.ReadXML(rootnode);

        foreach (XmlNode childnode in rootnode.ChildNodes)
        {
          if (string.IsNullOrEmpty(childnode.InnerText))
          {
            continue;
          }
      
          switch (childnode.LocalName)
          {
            case "Transporting":
              this.transporting = bool.Parse(childnode.InnerText);
              break;
            case "TransportingUnitUD":
              this.transportUnitID = childnode.InnerText;
              break;
            case "VehicleType":
              /*temp = new ValueList();
              //temp.ReadXML(childnode.ChildNodes[0]);
              //this.vehicleType.Add(temp);*/
              break;
            case "VehicleAgency":
              this.vehicleAgency = childnode.InnerText;
              break;
            case "VehicleState":
              this.vehicleState = childnode.InnerText;
              break;
            case "DestinationETA":
              this.destinationETA = DateTime.Parse(childnode.InnerText);
              if (this.destinationETA.Kind == DateTimeKind.Unspecified)
              {
                this.destinationETA = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.destinationETA = this.destinationETA.ToUniversalTime();
              break;
            case "DepartureDT":
              this.departureDateTime = DateTime.Parse(childnode.InnerText);
              if (this.departureDateTime.Kind == DateTimeKind.Unspecified)
              {
                this.departureDateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.departureDateTime = this.departureDateTime.ToUniversalTime();
              break;
            case "ArrivalDT":
              this.arrivalDateTime = DateTime.Parse(childnode.InnerText);
              if (this.arrivalDateTime.Kind == DateTimeKind.Unspecified)
              {
                this.arrivalDateTime = DateTime.MinValue;
                throw new ArgumentException("TimeZone Information Must Be Specified");
              }

              this.arrivalDateTime = this.arrivalDateTime.ToUniversalTime();
              break;
            case "#comment":
              break;
            default:
              throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in TransportInfoType");
          }
        }

        this.Validate();
      }
      else
      {
        throw new ArgumentException("Unexcepted Root Node Name: " + rootnode.Name + " in TransportInfoType");
      }
    }

    #endregion

    #region Public Member Functions

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
    }
    #endregion
  }
}
