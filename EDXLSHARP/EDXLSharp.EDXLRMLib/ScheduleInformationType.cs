// ———————————————————————–
// <copyright file="ScheduleInformationType.cs" company="EDXLSharp">
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
using System.Xml;

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The container for all component parts of the ScheduleInformationType sub-element of the resource message 
  /// </summary>
  [Serializable]
  public partial class ScheduleInformationType
  {
    #region Private Member Variables
    /// <summary>
    ///    A scheduled event that occurs at a particular time and/or at a particular location.
    /// </summary>
    private ScheduleTypeType? scheduleType;
    
    /// <summary>
    /// Usage 
    ///    OPTIONAL, MAY be used once and only once
    ///  Definition 
    ///    The date and time that a scheduled event takes place.
    /// </summary>
    private DateTime scheduleDateTime;
    
    /// <summary>
    /// Location Object
    /// </summary>
    private LocationType location;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the ScheduleInformationType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public ScheduleInformationType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// A scheduled event that occurs at a particular time and/or at a particular location.
    /// </summary>
    public ScheduleTypeType? ScheduleType
    {
      get { return this.scheduleType; }
      set { this.scheduleType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The date and time that a scheduled event takes place.
    /// </summary>
    public DateTime ScheduleDateTime
    {
      get
      {
        return this.scheduleDateTime.ToUniversalTime();
      }

      set
      {
        if (value.Kind != DateTimeKind.Unspecified)
        {
          this.scheduleDateTime = value.ToUniversalTime();
        }
        else
        {
          throw new ArgumentException("TimeZone Information Must Be Specified");
        }
      }
    }

    /// <summary>
    /// Gets or sets
    /// Location Object
    /// </summary>
    public LocationType Location
    {
      get { return this.location; }
      set { this.location = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    /// <param name="messageContent">MessageType of this RM Message</param>
    internal void WriteToXML(XmlWriter xwriter, MessageType? messageContent)
    {
      this.Validate(messageContent);

      if (this.scheduleType != null)
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "ScheduleType", EDXLConstants.RM10MsgNamespace, this.scheduleType.ToString());
      }

      if (this.scheduleDateTime != DateTime.MinValue)
      {
        xwriter.WriteElementString(EDXLConstants.RM10MsgPrefix, "DateTime", EDXLConstants.RM10MsgNamespace, this.scheduleDateTime.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz"));
      }

      if (this.location != null)
      {
        xwriter.WriteStartElement(EDXLConstants.RM10MsgPrefix, "Location", EDXLConstants.RM10MsgNamespace);
        this.location.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootNode">Node Containing the root Object element</param>
    /// <param name="messageContent">MessageType of this RM Message</param>
    internal void ReadXML(XmlNode rootNode, MessageType? messageContent)
    {
      foreach (XmlNode node in rootNode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "ScheduleType":
            this.scheduleType = (ScheduleTypeType)Enum.Parse(typeof(ScheduleTypeType), node.InnerText);
            break;
          case "DateTime":
            this.scheduleDateTime = DateTime.Parse(node.InnerText);
            if (this.scheduleDateTime.Kind == DateTimeKind.Unspecified)
            {
              this.scheduleDateTime = DateTime.MinValue;
              throw new ArgumentException("TimeZone Information Must Be Specified");
            }

            this.scheduleDateTime = this.scheduleDateTime.ToUniversalTime();
            break;
          case "Location":
            this.location = new LocationType();
            this.location.ReadXML(node);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in ScheduleInformationType");
        }
      }

      this.Validate(messageContent);
    }

    #endregion

    #region Private Member Functions
    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    /// <param name="messageContent">MessageType of this RM Message</param>
    private void Validate(MessageType? messageContent)
    {
      if (this.scheduleType == null)
      {
        throw new ArgumentNullException("ScheduleType is required and can't be null");
      }
      else
      {
        switch (messageContent)
        {
          case MessageType.RequestResource:
            if (this.scheduleType != ScheduleTypeType.RequestedArrival && this.scheduleType != ScheduleTypeType.RequestedDeparture && this.scheduleType != ScheduleTypeType.EstimatedReturnArrival && this.scheduleType != ScheduleTypeType.EstimatedReturnDeparture && this.scheduleType != ScheduleTypeType.ReportTo && this.scheduleType != ScheduleTypeType.Route)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.ResponseToRequestResource:
            if (this.scheduleType == ScheduleTypeType.ActualArrival || this.scheduleType == ScheduleTypeType.ActualDeparture || this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture || this.scheduleType == ScheduleTypeType.Committed || this.scheduleType == ScheduleTypeType.Current)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.RequisitionResource:
            if (this.scheduleType == ScheduleTypeType.ActualArrival || this.scheduleType == ScheduleTypeType.ActualDeparture || this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture || this.scheduleType == ScheduleTypeType.Committed || this.scheduleType == ScheduleTypeType.Current)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.CommitResource:
            if (this.scheduleType == ScheduleTypeType.ActualArrival || this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.RequestInformation:
            break;
          case MessageType.ResponseToRequestInformation:
            break;
          case MessageType.OfferUnsolicitedResource:
            if (this.scheduleType != ScheduleTypeType.EstimatedArrival && this.scheduleType != ScheduleTypeType.EstimatedDeparture && this.scheduleType != ScheduleTypeType.RequestedReturnArrival && this.scheduleType != ScheduleTypeType.RequestedReturnDeparture && this.scheduleType != ScheduleTypeType.BeginAvailable && this.scheduleType != ScheduleTypeType.EndAvailable && this.scheduleType != ScheduleTypeType.Route)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.ReleaseResource:
            if (this.scheduleType == ScheduleTypeType.ActualReturnArrival)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.RequestReturn:
            if (this.scheduleType == ScheduleTypeType.EstimatedReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.EstimatedReturnDeparture || this.scheduleType == ScheduleTypeType.ActualReturnDeparture)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.ResponseToRequestReturn:
            if (this.scheduleType == ScheduleTypeType.ActualReturnArrival)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.RequestQuote:
            if (this.scheduleType != ScheduleTypeType.RequestedArrival && this.scheduleType != ScheduleTypeType.RequestedDeparture && this.scheduleType != ScheduleTypeType.EstimatedReturnArrival && this.scheduleType != ScheduleTypeType.EstimatedReturnDeparture && this.scheduleType != ScheduleTypeType.ReportTo && this.scheduleType != ScheduleTypeType.Route)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.ResponseToRequestQuote:
            if (this.scheduleType == ScheduleTypeType.ActualArrival || this.scheduleType == ScheduleTypeType.ActualDeparture || this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture || this.scheduleType == ScheduleTypeType.Committed)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.RequestResourceDeploymentStatus:
            break;
          case MessageType.ReportResourceDeploymentStatus:
            break;
          case MessageType.RequestExtendedDeploymentDuration:
            if (this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture || this.scheduleType == ScheduleTypeType.BeginAvailable || this.scheduleType == ScheduleTypeType.EndAvailable)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
          case MessageType.ResponseToRequestExtendedDeploymentDuration:
            if (this.scheduleType == ScheduleTypeType.ActualReturnArrival || this.scheduleType == ScheduleTypeType.ActualReturnDeparture || this.scheduleType == ScheduleTypeType.BeginAvailable)
            {
              throw new ArgumentException("ScheduleType Incorrect For Message Type: " + messageContent.ToString());
            }

            break;
        }
      }
    }
    #endregion
  }
}
