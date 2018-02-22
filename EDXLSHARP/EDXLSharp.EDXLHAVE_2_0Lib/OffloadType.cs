// ———————————————————————–
// <copyright file="OffloadType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for all component parts of the OffloadType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class OffloadType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL
    /// Indicator of offload times of ambulance capabilities.  
    /// Values:
    /// 1. Normal – The time required to offload the patient is typical
    /// 2. Delayed – The time required to offload the patient is longer than typical.
    /// </summary>
    private EMSOffloadStatusType? emsOffloadStatus;

    /// <summary>
    /// OPTIONAL
    /// The average time to offload a patient, in minutes. 
    /// </summary>
    private int? emsOffloadMinutes;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the OffloadType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public OffloadType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// Indicator of offload times of ambulance capabilities.  
    /// Values:
    /// 1. Normal – The time required to offload the patient is typical
    /// 2. Delayed – The time required to offload the patient is longer than typical.
    /// </summary>
    public EMSOffloadStatusType? EMSOffloadStatus
    {
      get { return this.emsOffloadStatus; }
      set { this.emsOffloadStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL
    /// The average time to offload a patient, in minutes. 
    /// </summary>
    public int? EMSOffloadMinutes
    {
      get { return this.emsOffloadMinutes; }
      set { this.emsOffloadMinutes = value; }
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

      if (this.emsOffloadStatus != null)
      {
        xwriter.WriteElementString("EMSOffloadStatus", this.emsOffloadStatus.ToString());
      }

      if (this.emsOffloadMinutes != null)
      {
        xwriter.WriteElementString("EMSOffloadMinutes", this.emsOffloadMinutes.ToString());
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
          case "EMSOffloadStatus":
            this.emsOffloadStatus = (EMSOffloadStatusType)Enum.Parse(typeof(EMSOffloadStatusType), node.InnerText);
            break;
          case "EMSOffloadMinutes":
            this.emsOffloadMinutes = int.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in OffloadType");
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
  }
}