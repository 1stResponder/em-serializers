// ———————————————————————–
// <copyright file="BedCapacityType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the BedCapacityType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class BedCapacityType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL, May use multiple
    /// Enumerated list of available Bed Types. 
    /// 1. Each bed type (AdultICU, MedicalSurgical, etc.) MAY optionally contain a collection of named sub-categories. 
    /// 2. The totals of sub-categories MAY equal the capacity data specified in the parent. 
    /// Example, a hospital may sub-categorize Adult ICU beds into Surgery, Cardiac, General and Neurological.
    /// private List EnumBedType  bedType;
    /// </summary>
    private BedTypeType? bedType;

    /* OPTIONAL, MAY use multiple
    // The name of the sub-category bed type
    // 1. Each bed type MAY have many one or more named sub-type categories. 
    // 2. If one or more sub category bed types are used, they MUST be preceded by the parent <BedType> element. In this case, <CapacityStatus> of the parent Bed Type MUST not be ‘NotAvailable’. 
    // 3. Each parent <BedType> element and its associated sub-category bed types MUST be encapsulated with a <BedCapacity> element. 
    // 4. If the capacity counts of sub-category beds are specified, they MAY not equal the capacity count of the parent bed type. 
    // 5. In general, if capacities are specified using sub-category bed types, then only the <CapacityStatus> of the parent bed type MUST be used, and this should reflect an ‘Available’ val. No assumptions should be made about capacities that are not specified.
    // 1. If a <Capacity> element is specified, it pertains to the preceding <BedType> or <SubCategoryBedType> element. 
    // Note: Please see example at the end of this section. 
    // private List<string> mSubCategoryBedType;*/

    /// <summary>
    /// OPTIONAL, May use multiple
    /// Container element to define the capacity information of each specified bed type or sub category bed type.  
    /// 1. BedType element or SubCategoryBedType elements MAY have a Capacity element. 
    /// 2. In general, if capacities are specified using sub-category bed types, then only the CapacityStatus of the parent bed type MUST be used, and this MUST reflect an ‘Available’ val. 
    /// 1. If a Capacity element is specified, it pertains to the preceding BedType or SubCategoryBedType element. 
    /// 2. No assumptions must be made about bed capacities that are not specified. 
    /// private List CapacityType capacity;
    /// </summary>
    private CapacityType capacity;

    /// <summary>
    /// Comment text
    /// </summary>
    private List<string> commentText;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the BedCapacityType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public BedCapacityType()
    {
      // bedType = new List<EnumBedType>();
      // mSubCategoryBedType = new List<string>();
      // capacity = new List<CapacityType>();
      this.commentText = new List<string>();
    }
    #endregion

    #region Public Accessors
    /*public List<EnumBedType> BedType 
    {
      get { return bedType; }
      set { bedType = val; }
    }
    public List<string> SubCategoryBedType 
    {
      get { return mSubCategoryBedType; }
      set { mSubCategoryBedType = val; }
    }
    public List<CapacityType> Capacity 
    {
      get { return capacity; }
      set { capacity = val; }
    }*/

    /// <summary>
    /// Gets or sets
    /// OPTIONAL, May use multiple
    /// Enumerated list of available Bed Types. 
    /// 1. Each bed type (AdultICU, MedicalSurgical, etc.) MAY optionally contain a collection of named sub-categories. 
    /// 2. The totals of sub-categories MAY equal the capacity data specified in the parent. 
    /// Example, a hospital may sub-categorize Adult ICU beds into Surgery, Cardiac, General and Neurological.
    /// private List EnumBedType  bedType;
    /// </summary>
    public BedTypeType? BedType
    {
      get { return this.bedType; }
      set { this.bedType = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL, May use multiple
    /// Container element to define the capacity information of each specified bed type or sub category bed type.  
    /// 1. BedType element or SubCategoryBedType elements MAY have a Capacity element. 
    /// 2. In general, if capacities are specified using sub-category bed types, then only the CapacityStatus of the parent bed type MUST be used, and this MUST reflect an ‘Available’ val. 
    /// 1. If a Capacity element is specified, it pertains to the preceding BedType or SubCategoryBedType element. 
    /// 2. No assumptions must be made about bed capacities that are not specified. 
    /// private List CapacityType capacity;
    /// </summary>
    public CapacityType Capacity
    {
      get { return this.capacity; }
      set { this.capacity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment text
    /// </summary>
    public List<string> CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
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

      if (this.bedType != null)
      {
        xwriter.WriteElementString("BedType", this.bedType.ToString());
      }

      if (this.capacity != null)
      {
        xwriter.WriteStartElement("Capacity");
        this.capacity.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      foreach (string comment in this.commentText)
      {
        xwriter.WriteElementString("CommentText", comment);
      }
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      // CapacityType capacitytypetmp;
      foreach (XmlNode node in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "BedType":
            /*if (bedType == null)
              bedType = new List<EnumBedType>();
            bedType.Add((EnumBedType)Enum.Parse(typeof(EnumBedType), node.InnerText));*/
            this.bedType = (BedTypeType)Enum.Parse(typeof(BedTypeType), node.InnerText);
            break;
          case "SubCategoryBedType":
            /*if (mSubCategoryBedType == null)
              mSubCategoryBedType = new List<string>();
            mSubCategoryBedType.Add(node.InnerText);
            break; */

            // This section will have to be fixed.
            throw new ArgumentNullException("SubCategoryBedType is broken");
          case "Capacity":
            /*if (capacity == null)
              capacity = new List<CapacityType>();
            capacitytypetmp = new CapacityType();
            capacitytypetmp.ReadXML(node);
            capacity.Add(capacitytypetmp);*/
            this.capacity = new CapacityType();
            this.capacity.ReadXML(node);
            break;
          case "CommentText":
            if (this.commentText == null)
            {
              this.commentText = new List<string>();
            }

            this.commentText.Add(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in BedCapacityType");
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
