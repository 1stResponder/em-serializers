// ———————————————————————–
// <copyright file="HAVE.cs" company="EDXLSharp">
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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EDXLSharp.EDXLHAVE_2_0Lib
{
  /// <summary>
  /// The container for the HAVE message 
  /// </summary>
  [XmlRoot("HosptitalStatus"), Serializable]
  public partial class EDXLHAVE : IContentObject, IGeoRSS
  {
    #region Private Member Variables

    /// <summary>
    /// Class Variable To Store Concatenated Schema Validation Errors
    /// </summary>
    private static string schemaErrorString = string.Empty;

    /// <summary>
    /// Class Variable To Store Number of Schema Validation Errors
    /// </summary>
    private static int schemaErrors = 0;

    /// <summary>
    /// The container element for reporting status of a hospital.  
    /// REQUIRED, May Use Multiple; Must be used for each reporting hospital status. 
    /// </summary>
    private List<HospitalType> hospital;

    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the EDXLHAVE class Default Constructor - Initializes Lists (if applicable)
    /// </summary>
    public EDXLHAVE()
    {
      this.hospital = new List<HospitalType>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// The container element for reporting status of a hospital.  
    /// REQUIRED, May Use Multiple; Must be used for each reporting hospital status. 
    /// </summary>
    [XmlElement("Hospital")]
    public List<HospitalType> Hospital
    {
      get { return this.hospital; }
      set { this.hospital = value; }
    }

    /// <summary>
    /// Gets the date and time this message is invalid
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get { return this.Hospital[0].LastUpdateTime.AddHours(24); }
    }

    #endregion

    #region Public Member Functions
    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    /// <returns>String to Process ContentKeyWord Value From</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("EDXL-HAVE");
      return "EDXL-HAVE Hospital Availability Report";
    }
    
    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      this.Validate();
      
      xwriter.WriteStartDocument(false);
      xwriter.WriteStartElement("HospitalStatus", EDXLConstants.HAVE10Namespace);
      if (this.hospital.Count != 0)
      {
        foreach (HospitalType hosp in this.hospital)
        {
          xwriter.WriteStartElement("Hospital");
          hosp.WriteXML(xwriter);
          xwriter.WriteEndElement();
        }
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads an XML Object From An Existing DOM
    /// </summary>
    /// <param name="rootnode">Node Containing the root Object element</param>
    public void ReadXML(XmlNode rootnode)
    {
      XmlNode haveroot = rootnode;

      HospitalType hospitaltypetmp;

      foreach (XmlNode node in haveroot.ChildNodes)
      {
        if (string.IsNullOrEmpty(node.InnerText))
        {
          continue;
        }

        switch (node.LocalName)
        {
          case "Hospital":
            if (this.hospital == null)
            {
              this.hospital = new List<HospitalType>();
            }
            
            hospitaltypetmp = new HospitalType();
            hospitaltypetmp.ReadXML(node);
            this.hospital.Add(hospitaltypetmp);
            break;
        }
      }

      this.Validate();
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitems">Pointer to a Valid Syndication Item to Populate</param>
    /// <param name="linkUID">Pointer to a Valid link UID</param>
    public void ToGeoRSS(List<SyndicationItem> myitems, Guid linkUID)
    {
      SyndicationItem tempitem;
      foreach (HospitalType myhospital in this.hospital)
      {
        tempitem = new SyndicationItem();
        myhospital.ToGeoRSS(tempitem, linkUID);
        myitems.Add(tempitem);
      }
    }

    /// <summary>
    /// Validates The Current DE Object Against The XSD Schema File
    /// </summary>
    public void ValidateToSchema()
    {
      return; // TODO:  HAVE.ValidateToSchema FIXME

      /* XmlReader vr;
      XmlReaderSettings xs = new XmlReaderSettings();
      XmlSchemaSet coll = new XmlSchemaSet();
      StringReader xsdsr = new StringReader(string.Empty);
      StringReader xmlsr = new StringReader(xmldata);
      XmlReader xsdread = XmlReader.Create(xsdsr);
      coll.Add(EDXLConstants.EDXLDE10Namespace, xsdread);
      xs.Schemas.Add(coll);
      xs.ValidationType = ValidationType.Schema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      vr = XmlReader.Create(xmlsr, xs);
      while (vr.Read())
      {
      }

      vr.Close();
      xmlsr.Close();
      xsdread.Close();
      xsdsr.Close();
      if (schemaErrors > 0)
      {
        throw new ArgumentException("Schema Validation Error: " + schemaErrorString);
      }

        
      XmlReader vr;
      XmlReaderSettings xs = new XmlReaderSettings();
      XmlSchemaSet coll = new XmlSchemaSet();
      StringReader xsdsr = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.edxl_have_cs01);
      StringReader xmlsr = new StringReader(xmldata);
      XmlReader xsdread = XmlReader.Create(xsdsr);
      coll.Add(EDXLConstants.HAVE10Namespace, xsdread);
      StringReader commontypesread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.CommonTypes);
      XmlReader commonxsd = XmlReader.Create(commontypesread);
      coll.Add(EDXLConstants.CIQCommonTypesNamespace, commonxsd);
      StringReader geooasisread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.geo_oasis);
      XmlReader geooasisxsd = XmlReader.Create(geooasisread);
      coll.Add(EDXLConstants.GeoOASISWhereNamespace, geooasisxsd);
      StringReader gmlread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.gml_oasis);
      XmlReader gmlxsd = XmlReader.Create(gmlread);
      coll.Add(EDXLConstants.GMLNamespace, gmlxsd);
      StringReader xalread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xAL);
      XmlReader xalxsd = XmlReader.Create(xalread);
      coll.Add(EDXLConstants.XAL10Namespace, xalxsd);
      StringReader xaltypesread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xAL_types);
      XmlReader xaltypesxsd = XmlReader.Create(xaltypesread);
      coll.Add(EDXLConstants.XAL10Namespace, xaltypesxsd);
      //StringReader xlinkread = new StringReader(EDXLSharp.EDXLHAVELib.Properties.Resources.xLink);
      //XmlReader xlinkxsd = XmlReader.Create(xlinkread);
      //coll.Add("http://www.w3.org/1999/xlink", xlinkxsd);
      StringReader xlink2read = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xlink_2003_12_31);
      XmlReader xlink2xsd = XmlReader.Create(xlink2read);
      coll.Add("http://www.w3.org/1999/xlink1", xlink2xsd);
      StringReader xlinksread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xlinks);
      XmlReader xlinksxsd = XmlReader.Create(xlinksread);
      coll.Add("http://www.w3.org/1999/xlink", xlinksxsd);
      StringReader xnlread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xNL);
      XmlReader xnlxsd = XmlReader.Create(xnlread);
      coll.Add(EDXLConstants.XNL10Namespace, xnlxsd);
      StringReader xnltypesread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xNL_types);
      XmlReader xnltypesxsd = XmlReader.Create(xnltypesread);
      coll.Add(EDXLConstants.XNL10Namespace, xnltypesxsd);
      StringReader xpilread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xPIL);
      XmlReader xpilxsd = XmlReader.Create(xpilread);
      coll.Add(EDXLConstants.XPIL10Namespace, xpilxsd);
      StringReader xpiltypesread = new StringReader(EDXLSharp.EDXLHAVE_2_0Lib.Properties.Resources.xPIL_types);
      XmlReader xpiltypesxsd = XmlReader.Create(xpiltypesread);
      coll.Add(EDXLConstants.XPIL10Namespace, xpiltypesxsd);
      xs.Schemas.Add(coll);
      xs.ValidationType = ValidationType.Schema;
      //xs.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
      xs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
      xs.ValidationEventHandler += new ValidationEventHandler(SchemaErrorCallback);
      vr = XmlReader.Create(xmlsr, xs);
      while (vr.Read()) ;
      vr.Close();
      xmlsr.Close();
      xsdread.Close();
      xsdsr.Close();
      if (schemaErrors > 0)
      {
          throw new ArgumentException("Schema Validation Error: " + schemaErrorString);
      }
         * */
    }

    /// <summary>
    /// Checks This Object For Required Values and Conformance
    /// </summary>
    public void Validate()
    {
      if (this.hospital.Count == 0)
      {
        throw new ArgumentNullException("Hospital is required and can't be null");
      }
    }
    #endregion

    #region Private Member Functions

    /// <summary>
    /// Callback Function For Schema Validation Delegate
    /// </summary>
    /// <param name="sender">Object Causing the Event Firing</param>
    /// <param name="args">Arguments that contain the schema validation errors</param>
    private static void SchemaErrorCallback(object sender, ValidationEventArgs args)
    {
      if (args.Severity == XmlSeverityType.Error)
      {
        schemaErrorString = schemaErrorString + args.Message + "\r\n";
        schemaErrors++;
      }
    }
    #endregion
  }
}
