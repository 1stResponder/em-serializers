// ———————————————————————–
// <copyright file="CapacityType.cs" company="EDXLSharp">
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
// ———————————————————————–

using System;
using System.Xml;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the CapacityType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class CapacityType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL
    /// Indicator of status of bed type or sub-category bed type.  
    /// 1. Values:
    /// • VacantAvailable – The type of bed is available.
    /// • NotAvailable – The type of bed is not available.
    /// 1. No assumptions must be made about bed capacities that are not specified. 
    /// 2. Vacant/Available Beds refers to beds that are vacant and to which patients can be immediately transported. These will include supporting space, equipment, medical material, ancillary and support services and staff to operate under normal circumstances. These beds are licensed, physically available and have staff on hand to attend to the patient who occupies the bed. 
    /// Note: Please refer to appendix B 
    /// </summary>
    private CapacityStatusType? capacityStatus;

    /// <summary>
    /// OPTIONAL
    /// The number of vacant/available beds to which patients can be immediately transported.  
    /// 1. These will include supporting space, equipment, medical material, ancillary and support services, and staff to operate under normal circumstances. 
    /// 2. These beds are licensed, physically available and have staff on hand to attend to the patient who occupies the bed.
    /// </summary>
    private int? availableCount;

    /// <summary>
    /// OPTIONAL
    /// The maximum (baseline) number of beds in this category. 
    /// </summary>
    private int? baselineCount;

    /// <summary>
    /// OPTIONAL
    /// Estimate of the beds, above the current number, that could be made vacant/available within 24 hours. 
    /// 1. This includes institutional surge beds as well as beds made available by discharging or transferring patients.
    /// </summary>
    private int? additionalCapacityCount24Hr;

    /// <summary>
    /// OPTIONAL
    /// Estimate of the beds, above the current number, that could be made vacant/available within 72 hours. 
    /// 1. This includes institutional surge beds as well as beds made available by discharging or transferring patients.
    /// </summary>
    private int? additionalCapacityCount72Hr;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the CapacityType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public CapacityType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// Indicator of status of bed type or sub-category bed type.  
    /// 1. Values:
    /// • VacantAvailable – The type of bed is available.
    /// • NotAvailable – The type of bed is not available.
    /// 1. No assumptions must be made about bed capacities that are not specified. 
    /// 2. Vacant/Available Beds refers to beds that are vacant and to which patients can be immediately transported. These will include supporting space, equipment, medical material, ancillary and support services and staff to operate under normal circumstances. These beds are licensed, physically available and have staff on hand to attend to the patient who occupies the bed. 
    /// Note: Please refer to appendix B 
    /// </summary>
    public CapacityStatusType? CapacityStatus
    {
      get { return this.capacityStatus; }
      set { this.capacityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The number of vacant/available beds to which patients can be immediately transported.  
    /// 1. These will include supporting space, equipment, medical material, ancillary and support services, and staff to operate under normal circumstances. 
    /// 2. These beds are licensed, physically available and have staff on hand to attend to the patient who occupies the bed.
    /// </summary>
    public int? AvailableCount
    {
      get { return this.availableCount; }
      set { this.availableCount = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The maximum (baseline) number of beds in this category. 
    /// </summary>
    public int? BaselineCount
    {
      get { return this.baselineCount; }
      set { this.baselineCount = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// Estimate of the beds, above the current number, that could be made vacant/available within 24 hours. 
    /// 1. This includes institutional surge beds as well as beds made available by discharging or transferring patients.
    /// </summary>
    public int? AdditionalCapacityCount24Hr
    {
      get { return this.additionalCapacityCount24Hr; }
      set { this.additionalCapacityCount24Hr = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// Estimate of the beds, above the current number, that could be made vacant/available within 72 hours. 
    /// 1. This includes institutional surge beds as well as beds made available by discharging or transferring patients.
    /// </summary>
    public int? AdditionalCapacityCount72Hr
    {
      get { return this.additionalCapacityCount72Hr; }
      set { this.additionalCapacityCount72Hr = value; }
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
      if (this.capacityStatus != null)
      {
        xwriter.WriteElementString("CapacityStatus", CapacityStatusToString(this.capacityStatus));
      }

      if (this.availableCount != null)
      {
        xwriter.WriteElementString("AvailableCount", this.availableCount.ToString());
      }

      if (this.baselineCount != null)
      {
        xwriter.WriteElementString("BaselineCount", this.baselineCount.ToString());
      }

      if (this.additionalCapacityCount24Hr != null)
      {
        xwriter.WriteElementString("AdditionalCapacityCount24Hr", this.additionalCapacityCount24Hr.ToString());
      }

      if (this.additionalCapacityCount72Hr != null)
      {
        xwriter.WriteElementString("AdditionalCapacityCount72Hr", this.additionalCapacityCount72Hr.ToString());
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
          case "CapacityStatus":
            this.capacityStatus = StringToCapacityStatus(node.InnerText); ////(CapacityStatusType)Enum.Parse(typeof(CapacityStatusType), node.InnerText);
            break;
          case "AvailableCount":
            this.availableCount = int.Parse(node.InnerText);
            break;
          case "BaselineCount":
            this.baselineCount = int.Parse(node.InnerText);
            break;
          case "AdditionalCapacityCount24Hr":
            this.additionalCapacityCount24Hr = int.Parse(node.InnerText);
            break;
          case "AdditionalCapacityCount72Hr":
            this.additionalCapacityCount72Hr = int.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in CapacityType");
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

    /// <summary>
    /// Overload for the Capacity Status Type Enumeration which Contains a /
    /// </summary>
    /// <param name="type">Enumeration Input</param>
    /// <returns>Printable String</returns>
    private static string CapacityStatusToString(CapacityStatusType? type)
    {
      if (type == null)
      {
        return null;
      }

      switch (type)
      {
        case CapacityStatusType.Vacant_Available:
          return "Vacant/Available";
        case CapacityStatusType.NotAvailable:
          return "NotAvailable";
      }

      return null;
    }

    /// <summary>
    /// Method to Parse Capacity Status Enum from String
    /// </summary>
    /// <param name="input">Input String</param>
    /// <returns>CapacityStatusType Enumeration Value</returns>
    private static CapacityStatusType StringToCapacityStatus(string input)
    {
      if (input == null)
      {
        return CapacityStatusType.NotAvailable;
      }
      else if (input.Equals("Vacant/Available"))
      {
        return CapacityStatusType.Vacant_Available;
      }
      else if (input.Equals("NotAvailable"))
      {
        return CapacityStatusType.NotAvailable;
      }
      else
      {
        return CapacityStatusType.NotAvailable;
      }
    }
    #endregion
  }
}
