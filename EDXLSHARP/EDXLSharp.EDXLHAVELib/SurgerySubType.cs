// ———————————————————————–
// <copyright file="SurgerySubType.cs" company="EDXLSharp">
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
  /// The container for all component parts of the SurgerySubType sub-element of the HAVE message 
  /// </summary>
  [Serializable]
  public partial class SurgerySubType : IComposable
  {
    #region Private Member Variables
    // All data members: 
    // 1. Sub-type element of the adult general services.
    // 2. Values: 
    // • “true” or “1” - This type of services is available. 
    // • “false” or “0” - This type of services is not available.

    /// <summary>
    /// The availability of general surgical services.
    /// </summary>
    private bool? general;

    /// <summary>
    /// The availability of adult general services. 
    /// </summary>
    private bool? adultGeneralSurgery;

    /// <summary>
    /// The availability of Pediatrics general surgical services.
    /// </summary>
    private bool? pediatrics;

    /// <summary>
    /// The availability of Orthopedic surgical services
    /// </summary>
    private bool? orthopedics;

    /// <summary>
    /// The availability of Neurosurgery services.
    /// </summary>
    private bool? neurosurgery;

    /// <summary>
    /// The availability of facial surgical services. 
    /// </summary>
    private bool? facial;

    /// <summary>
    /// The availability of cardiothoracic surgical services.
    /// </summary>
    private bool? cardioThoracic;

    /// <summary>
    /// The availability of hand surgery services.
    /// </summary>
    private bool? hand;

    /// <summary>
    /// The availability of reimplantation surgical services. 
    /// </summary>
    private bool? reimplantation;

    /// <summary>
    /// The availability of spinal surgical services. 
    /// </summary>
    private bool? spinal;

    /// <summary>
    /// The availability of vascular surgical services. 
    /// </summary>
    private bool? vascular;

    /// <summary>
    /// The availability of anesthesia services.
    /// </summary>
    private bool? anesthesia;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the SurgerySubType class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public SurgerySubType()
    {
    }
    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The availability of general surgical services.
    /// </summary>
    public bool? General
    {
      get { return this.general; }
      set { this.general = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of adult general services. 
    /// </summary>
    public bool? AdultGeneralSurgery
    {
      get { return this.adultGeneralSurgery; }
      set { this.adultGeneralSurgery = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of Pediatrics general surgical services.
    /// </summary>
    public bool? Pediatrics
    {
      get { return this.pediatrics; }
      set { this.pediatrics = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of Orthopedic surgical services
    /// </summary>
    public bool? Orthopedics
    {
      get { return this.orthopedics; }
      set { this.orthopedics = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of Neurosurgery services.
    /// </summary>
    public bool? Neurosurgery
    {
      get { return this.neurosurgery; }
      set { this.neurosurgery = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of facial surgical services. 
    /// </summary>
    public bool? Facial
    {
      get { return this.facial; }
      set { this.facial = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of cardiothoracic surgical services.
    /// </summary>
    public bool? CardioThoracic
    {
      get { return this.cardioThoracic; }
      set { this.cardioThoracic = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of hand surgery services.
    /// </summary>
    public bool? Hand
    {
      get { return this.hand; }
      set { this.hand = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of reimplantation surgical services. 
    /// </summary>
    public bool? Reimplantation
    {
      get { return this.reimplantation; }
      set { this.reimplantation = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of spinal surgical services. 
    /// </summary>
    public bool? Spinal
    {
      get { return this.spinal; }
      set { this.spinal = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of vascular surgical services. 
    /// </summary>
    public bool? Vascular
    {
      get { return this.vascular; }
      set { this.vascular = value; }
    }

    /// <summary>
    /// Gets or sets
    /// The availability of anesthesia services.
    /// </summary>
    public bool? Anesthesia
    {
      get { return this.anesthesia; }
      set { this.anesthesia = value; }
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

      if (this.general != null)
      {
        xwriter.WriteElementString("General", this.general.ToString().ToLower());
      }

      if (this.adultGeneralSurgery != null)
      {
        xwriter.WriteElementString("AdultGeneralSurgery", this.adultGeneralSurgery.ToString().ToLower());
      }

      if (this.pediatrics != null)
      {
        xwriter.WriteElementString("Pediatrics", this.pediatrics.ToString().ToLower());
      }

      if (this.orthopedics != null)
      {
        xwriter.WriteElementString("Orthopedics", this.orthopedics.ToString().ToLower());
      }

      if (this.neurosurgery != null)
      {
        xwriter.WriteElementString("Neurosurgery", this.neurosurgery.ToString().ToLower());
      }

      if (this.facial != null)
      {
        xwriter.WriteElementString("Facial", this.facial.ToString().ToLower());
      }

      if (this.cardioThoracic != null)
      {
        xwriter.WriteElementString("CardioThoracic", this.cardioThoracic.ToString().ToLower());
      }

      if (this.hand != null)
      {
        xwriter.WriteElementString("Hand", this.hand.ToString().ToLower());
      }

      if (this.reimplantation != null)
      {
        xwriter.WriteElementString("Reimplantation", this.reimplantation.ToString().ToLower());
      }

      if (this.spinal != null)
      {
        xwriter.WriteElementString("Spinal", this.spinal.ToString().ToLower());
      }

      if (this.vascular != null)
      {
        xwriter.WriteElementString("Vascular", this.vascular.ToString().ToLower());
      }

      if (this.anesthesia != null)
      {
        xwriter.WriteElementString("Anesthesia", this.anesthesia.ToString().ToLower());
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
          case "General":
            this.general = bool.Parse(node.InnerText);
            break;
          case "AdultGeneralSurgery":
            this.adultGeneralSurgery = bool.Parse(node.InnerText);
            break;
          case "Pediatrics":
            this.pediatrics = bool.Parse(node.InnerText);
            break;
          case "Orthopedics":
            this.orthopedics = bool.Parse(node.InnerText);
            break;
          case "Neurosurgery":
            this.neurosurgery = bool.Parse(node.InnerText);
            break;
          case "Facial":
            this.facial = bool.Parse(node.InnerText);
            break;
          case "CardioThoracic":
            this.cardioThoracic = bool.Parse(node.InnerText);
            break;
          case "Hand":
            this.hand = bool.Parse(node.InnerText);
            break;
          case "Reimplantation":
            this.reimplantation = bool.Parse(node.InnerText);
            break;
          case "Spinal":
            this.spinal = bool.Parse(node.InnerText);
            break;
          case "Vascular":
            this.vascular = bool.Parse(node.InnerText);
            break;
          case "Anesthesia":
            this.anesthesia = bool.Parse(node.InnerText);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected node name: " + node.Name + " in SurgerySubType");
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
