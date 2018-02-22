// ———————————————————————–
// <copyright file="DeconCapacityType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVELib
{
  /// <summary>
  /// The container for all component parts of the DeconCapacityType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class DeconCapacityType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// The capacity for chemical/biological/radiological patient decontamination.
    /// Values: 
    /// 1. Inactive - Not being used, but available if needed
    /// 2. Open - In use and able to accept additional patients
    /// 3. Full - In use at maximum capacity
    /// 4. Exceeded - Needs exceed available capacity
    /// </summary>
    private DeconCapacityStatusType? deconCapacityStatus;

    /// <summary>
    /// OPTIONAL 
    /// The number of ambulatory patients which can be decontaminated over time (typically an hour). 
    /// </summary>
    private int? ambulatoryPatientsDeconCapacity;

    /// <summary>
    /// OPTIONAL 
    /// The number of non-ambulatory patients which can be decontaminated over time (typically an hour). 
    /// </summary>
    private int? nonAmbulatoryPatientsDeconCapacity;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the DeconCapacityType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public DeconCapacityType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The capacity for chemical/biological/radiological patient decontamination.
    /// Values: 
    /// 1. Inactive - Not being used, but available if needed
    /// 2. Open - In use and able to accept additional patients
    /// 3. Full - In use at maximum capacity
    /// 4. Exceeded - Needs exceed available capacity
    /// </summary>
    public DeconCapacityStatusType? DeconCapacityStatus
    {
      get { return this.deconCapacityStatus; }
      set { this.deconCapacityStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of ambulatory patients which can be decontaminated over time (typically an hour). 
    /// </summary>
    public int? AmbulatoryPatientsDeconCapacity
    {
      get { return this.ambulatoryPatientsDeconCapacity; }
      set { this.ambulatoryPatientsDeconCapacity = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// The number of non-ambulatory patients which can be decontaminated over time (typically an hour). 
    /// </summary>
    public int? NonAmbulatoryPatientsDeconCapacity
    {
      get { return this.nonAmbulatoryPatientsDeconCapacity; }
      set { this.nonAmbulatoryPatientsDeconCapacity = value; }
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
      xwriter.WriteStartElement("DeconCapacity");
      if (this.deconCapacityStatus != null)
      {
        xwriter.WriteElementString("DeconCapacityStatus", this.deconCapacityStatus.ToString());
      }

      if (this.ambulatoryPatientsDeconCapacity != null)
      {
        xwriter.WriteElementString("AmbulatoryPatientsDeconCapacity", this.ambulatoryPatientsDeconCapacity.ToString());
      }

      if (this.nonAmbulatoryPatientsDeconCapacity != null)
      {
        xwriter.WriteElementString("NonAmbulatoryPatientsDeconCapacity", this.nonAmbulatoryPatientsDeconCapacity.ToString());
      }

      xwriter.WriteEndElement();
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
          case "DeconCapacityStatus":
            this.deconCapacityStatus = (DeconCapacityStatusType)Enum.Parse(typeof(DeconCapacityStatusType), node.InnerText);
            break;
          case "AmbulatoryPatientsDeconCapacity":
            this.ambulatoryPatientsDeconCapacity = int.Parse(node.InnerText);
            break;
          case "NonAmbulatoryPatientsDeconCapacity":
            this.nonAmbulatoryPatientsDeconCapacity = int.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in DeconCapacityType");
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
