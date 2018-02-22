// ———————————————————————–
// <copyright file="EMSTrafficType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the EMS Traffic Type sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class EMSTrafficType : IComposable
  {
    #region Private Member Variables
    /// <summary>
    /// OPTIONAL 
    /// Identifies the status of EMS traffic operations. 
    /// Value must be one of: 
    /// 1. Normal - Accepting all EMS traffic
    /// 2. Advisory - Experiencing specific resource limitations which may affect transport of some EMS traffic.
    /// 3. Closed - Requesting re-route of EMS traffic to other facilities.
    /// 4. NotApplicable - Not Applicable. This hospital does not have an emergency department.
    /// </summary>
    private EMSTrafficStatusTypeType? emsTrafficStatus;

    /// <summary>
    /// OPTIONAL 
    /// It is used to report the contributing factor to the status specified in EMSTrafficStatus.
    /// </summary>
    private string emsTrafficReason;

    /// <summary>
    /// Comment Text
    /// </summary>
    private string commentText;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the EMSTrafficType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public EMSTrafficType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// Identifies the status of EMS traffic operations. 
    /// Value must be one of: 
    /// 1. Normal - Accepting all EMS traffic
    /// 2. Advisory - Experiencing specific resource limitations which may affect transport of some EMS traffic.
    /// 3. Closed - Requesting re-route of EMS traffic to other facilities.
    /// 4. NotApplicable - Not Applicable. This hospital does not have an emergency department.
    /// </summary>
    public EMSTrafficStatusTypeType? EMSTrafficStatus
    {
      get { return this.emsTrafficStatus; }
      set { this.emsTrafficStatus = value; }
    }

    /// <summary>
    /// Gets or sets
    /// OPTIONAL 
    /// It is used to report the contributing factor to the status specified in EMSTrafficStatus.
    /// </summary>
    public string EMSTrafficReason
    {
      get { return this.emsTrafficReason; }
      set { this.emsTrafficReason = value; }
    }

    /// <summary>
    /// Gets or sets
    /// Comment Text
    /// </summary>
    public string CommentText
    {
      get { return this.commentText; }
      set { this.commentText = value; }
    }
    #endregion

    #region Internal Member Functions
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();

      if (this.emsTrafficStatus != null)
      {
        xwriter.WriteElementString("EMSTrafficStatus", this.emsTrafficStatus.ToString());
      }

      if (!string.IsNullOrEmpty(this.emsTrafficReason))
      {
        xwriter.WriteElementString("EMSTrafficReason", this.emsTrafficReason);
      }

      if (!string.IsNullOrEmpty(this.commentText))
      {
        xwriter.WriteElementString("CommentText", this.commentText);
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
          case "EMSTrafficStatus":
            this.emsTrafficStatus = (EMSTrafficStatusTypeType)Enum.Parse(typeof(EMSTrafficStatusTypeType), node.InnerText);
            break;
          case "EMSTrafficReason":
            this.emsTrafficReason = node.InnerText;
            break;
          case "CommentText":
            this.commentText = node.InnerText;
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in EMSTrafficType");
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
