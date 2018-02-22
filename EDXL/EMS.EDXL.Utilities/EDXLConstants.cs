// ———————————————————————–
// <copyright file="EDXLConstants.cs" company="EDXLSharp">
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

namespace EMS.EDXL.Utilities
{
  /// <summary>
  /// Static Class to Hold Global Constants for the EDXLSharp Libraries
  /// </summary>
  [Serializable]
  public static partial class EDXLConstants
  {
    /// <summary>
    /// Gets or Sets Whether or Not To Run Secondary Validation Against The Stored Schema
    /// With the .NET Integrated Schema Validator
    /// </summary>
    public const bool SecondarySchemaValidation = true;

   /* /// <summary>
    /// Namespace for GML
    /// </summary>
    //public const string GMLNamespace = "http://www.opengis.net/gml/";
    
    /// <summary>
    /// Namespace for GML
    /// </summary>
    //public const string GML32Namespace = "http://www.opengis.net/gml/3.2";*/

  /*  /// <summary>
    /// Prefix To Use For GML
    /// </summary>
    //public const string GMLPrefix = "gml";*/

    /// <summary>
    /// Namespace For GeoOASISWhere
    /// </summary>
    public const string GeoOASISWhereNamespace = "urn:oasis:names:tc:emergency:EDXL:HAVE:1.0:geo-oasis";
    
    /// <summary>
    /// Prefix To Use For GeoOASISWhere
    /// </summary>
    public const string GeoOASISWherePrefix = "oasis";

   /* /// <summary>
    /// Namespaces for GSF
    /// </summary>
    //public const string GSFNameSpace = "urn:oasis:names:tc:emergency:edxl:gsf:1.0";*/

    /// <summary>
    /// URI For the Unique Name Of The Managed Content Keyword List
    /// </summary>
    public const string ContentKeywordListName = "http://edxlsharp.codeplex.com/ValueLists/ContentKeywords";

    /// <summary>
    /// Namespace For CAP 1.1
    /// </summary>
    public const string CAP11Namespace = "urn:oasis:names:tc:emergency:cap:1.1";

    /// <summary>
    /// Namespace For CAP 1.2
    /// </summary>
    public const string CAP12Namespace = "urn:oasis:names:tc:emergency:cap:1.2";

    /// <summary>
    /// Prefix To Use For CAP
    /// </summary>
    public const string CAPPrefix = "cap";

    /// <summary>
    /// Namespace for EDXL-DE 1.0
    /// </summary>
    public const string EDXLDE10Namespace = "urn:oasis:names:tc:emergency:EDXL:DE:1.0";

    /// <summary>
    /// The Base URI For SyndicationFeed Item Links
    /// </summary>
    public const string SyndicationLinkBaseURI = "http://tempuri.org/";

    /// <summary>
    /// Prefix To Use For Geo-RSS
    /// </summary>
    public const string GeoRSSPrefix = "georss";

    /// <summary>
    /// Geo-RSS Namespace
    /// </summary>
    public const string GeoRSSNamespace = "http://www.georss.org/georss";

    /// <summary>
    /// Category Scheme For Syndication Content
    /// </summary>
    public const string SyndicationCategoryScheme = "EDXLSharp";

    /// <summary>
    /// Category Label For Syndication Content
    /// </summary>
    public const string SyndicationCategoryLabel = "MessageType";

    /// <summary>
    /// Copyright Information For Syndication Content
    /// </summary>
    public const string SyndicationCopyright = "Copyright (c) EDXLSharp";

    /// <summary>
    /// Syndication Name For CAP Alerts
    /// </summary>
    public const string CAPSyndicationCategoryName = "CAP";

    /// <summary>
    /// Title To Use For CAP Syndication Items
    /// </summary>
    public const string CAPSyndicationTitle = "CAP v1.2 Report";

    /// <summary>
    /// Syndication Name For EDXL-DE
    /// </summary>
    public const string DESyndicationCategoryName = "EDXL-DE";

    /// <summary>
    /// Title To Use For EDXL-DE Syndication Items
    /// </summary>
    public const string DESyndicationTitle = "EDXL-DE v1.0 Report";

    /// <summary>
    /// Namespace For EDXL-HAVE 1.0
    /// </summary>
    public const string HAVE10Namespace = "urn:oasis:names:tc:emergency:EDXL:HAVE:1.0";

    /// <summary>
    /// Syndication Name For EDXL-HAVE
    /// </summary>
    public const string HAVESyndicationCategoryName = "EDXL-HAVE";

    /// <summary>
    /// Title To Use For EDXL-HAVE Syndication Items
    /// </summary>
    public const string HAVESyndicationTitle = "EDXL-HAVE v1.0 Report";

    /// <summary>
    /// Namespace for EDXL-TEP 1.0
    /// </summary>
    public const string TEP10Namespace = "urn:oasis:names:tc:emergency:EDXL:TEP:1.0";

    /// <summary>
    /// Syndication name for EDXL-TEP
    /// </summary>
    public const string TEPSyndicationCategoryName = "EDXL-TEP";

    /// <summary>
    /// Title to use for EDXL-TEP syndication items
    /// </summary>
    public const string TEPSyndicationTitle = "EDXP-TEP v1.0 Report";

    /// <summary>
    /// Namespace For EDXL-RM 1.0
    /// </summary>
    public const string RM10Namespace = "urn:oasis:names:tc:emergency:EDXL:RM:1.0";

    /// <summary>
    /// Namespace Prefix For the RM10Namespace
    /// </summary>
    public const string RM10Prefix = "rm";

    /// <summary>
    /// Namespace For EDXL-RM 1.0 Messages
    /// </summary>
    public const string RM10MsgNamespace = "urn:oasis:names:tc:emergency:EDXL:RM:1.0:msg";

    /// <summary>
    /// Namespace Prefix for the RM10MessageNamespace
    /// </summary>
    public const string RM10MsgPrefix = "rmsg";

    /// <summary>
    /// Syndication Name For EDXL-RM
    /// </summary>
    public const string RMSyndicationCategoryName = "EDXL-RM";

    /// <summary>
    /// Title To Use For EDXL-RM Syndication Items
    /// </summary>
    public const string RMSyndicationTitle = "EDXL-RM v1.0 Report";

    /// <summary>
    /// Prefix To Use With EDXL-RM Items
    /// </summary>
    public const string RMPrefix = "rm";

    /// <summary>
    /// Namespace for MEXL-SitRep 1.0
    /// </summary>
    public const string SitRep10Namespace = "http://edlxsharp.codeplex.com/mEXL/SitRep/";

    /// <summary>
    /// Syndication Name For MEXL-SitRep
    /// </summary>
    public const string SitRepSyndicationCategoryName = "SimpleSitRep";

    /// <summary>
    /// Title To Use For MEXL-SitRep Syndication Items
    /// </summary>
    public const string SitRepSyndicationTitle = "MEXL-SitRep 0.1 Report";

    /// <summary>
    /// Prefix To Use With MEXL-SitRep Items
    /// </summary>
    public const string SitRepPrefix = "mEXLSR";

  /*  /// <summary>
    /// Namespace for EDXL-SitRep 1.0
    /// </summary>
    //public const string EDXLSitRep10Namespace = "urn:oasis:names:tc:emergency:EDXL:SitRep:1.0";*/

    /// <summary>
    /// Title To Use For EDXL-RM Syndication Items
    /// </summary>
    public const string EDXLSitRepSyndicationCateforyName = "EDXL-SitRep";

    /// <summary>
    /// Prefix To Use With EDXL-SitRep Items
    /// </summary>
    public const string EDXLSitRepPrefix = "sr";

   /* /// <summary>
    /// Namespace for EDXL CommonTypes 1.0
    /// </summary>
    //public const string EDXLCommonTypes10Namespace = "urn:oasis:names:tc:emergency:edxl:ct:1.0";*/

    /// <summary>
    /// Prefix To Use With EDXL CommonTypes
    /// </summary>
    public const string EDXLCommonTypesPrefix = "ct";

    /// <summary>
    /// Namespace for MEXL-TEP 1.0
    /// </summary>
    public const string MEXLTEP10Namespace = "http://edxlsharp.codeplex.com/mEXL/TEP/";

    /// <summary>
    /// Prefix To Use With MEXL-TEP
    /// </summary>
    public const string MEXLTEPPrefix = "mEXLTEP";

    /// <summary>
    /// Syndication Name For MEXL-TEP
    /// </summary>
    public const string MEXLTEPSyndicationCategoryName = "TEP";

    /// <summary>
    /// Title To Use For MEXL-TEP Syndication Items
    /// </summary>
    public const string MEXLTEPSyndicationTitle = "MEXL-TEP 0.1 Report";

    /// <summary>
    /// Prefix To Use With xPIL Items
    /// </summary>
    public const string XPILPrefix = "xpil";

   /* /// <summary>
    /// Namespace of xPIL 1.0
    /// </summary>
    //public const string XPILEDXL10Namespace = "urn:oasis:names:tc:emergency:edxl:ciq:1.0:xpil";*/

    /// <summary>
    /// Namespace of xPIL 1.0
    /// </summary>
    public const string XPIL10Namespace = "urn:oasis:names:tc:ciq:xpil:3";

    /// <summary>
    /// Prefix To Use With xAL Items
    /// </summary>
    public const string XALPrefix = "xal";

   /* /// <summary>
    /// Namespace Of xAL 1.0
    /// </summary>
    //public const string XALEDXL10Namespace = "urn:oasis:names:tc:emergency:edxl:ciq:1.0:xal";*/

    /// <summary>
    /// Namespace Of xAL 1.0
    /// </summary>
    public const string XAL10Namespace = "urn:oasis:names:tc:ciq:xal:3";

    /// <summary>
    /// Prefix To Use With xNL Items
    /// </summary>
    public const string XNLPrefix = "xnl";

    /*/// <summary>
    /// Namespace Of xNL 1.0
    /// </summary>
    //public const string XNLEDXL10Namespace = "urn:oasis:names:tc:emergency:edxl:ciq:1.0:xnl";*/

    /// <summary>
    /// Namespace Of xNL 1.0
    /// </summary>
    public const string XNL10Namespace = "urn:oasis:names:tc:ciq:xnl:3";

    /*/// <summary>
    /// Namespace for the CIQ Common Types
    /// </summary>
    //public const string CIQEDXLCommonTypesNamespace = "urn:oasis:names:tc:emergency:edxl:ciq:1.0:ct";*/

    /// <summary>
    /// Namespace for the CIQ Common Types
    /// </summary>
    public const string CIQCommonTypesNamespace = "urn:oasis:names:tc:ciq:ct:3";

    /// <summary>
    /// Namespace for the xNAL
    /// </summary>
    public const string XNALNamespace = "urn:oasis:names:tc:ciq:xnal:3";

    /// <summary>
    /// This is the Default Unit of Measure URI
    /// </summary>
    public const string UomUri = "http://kilometers.com";

    /// <summary>
    /// Namespace for CoT inside of DE
    /// </summary>
    public const string EDXLCoTNamespace = "urn:cot:mitre:org";

    /// <summary>
    /// Prefix to use with CAD
    /// </summary>
    public const string CADPrefix = "cad";

    /// <summary>
    /// Namespace of CAD
    /// </summary>
    public const string CADNamespace = "http://em.niem.gov/emevent/0.8/cad2cad/";

    /// <summary>
    /// Prefix to use for EMEvent
    /// </summary>
    public const string EMEventPrefix = "emevent";

    /// <summary>
    /// Namespace of EMEvent
    /// </summary>
    public const string EMEventNamespace = "http://em.niem.gov/emevent/0.8/";

    /// <summary>
    /// Prefix for Niem Core elements
    /// </summary>
    public const string NiemCorePrefix = "nc";

    /// <summary>
    /// Namespace of Niem Core
    /// </summary>
    public const string NiemCoreNamespace = "http://release.niem.gov/niem/niem-core/3.0/";

    /// <summary>
    /// Prefix for Mil Ops
    /// </summary>
    public const string MilopsPrefix = "mof";

    /// <summary>
    /// Namespace for Mil Ops
    /// </summary>
    public const string MilopsNamespace = "http://example.com/milops/1.1/";

    /// <summary>
    /// Prefix for RTLT
    /// </summary>
    public const string RTLTPrefix = "rtlt";

    /// <summary>
    /// Namespace for RTLT
    /// </summary>
    public const string RTLTNamespace = "http://example.com/adapters/fema_rtlt/3.0/";

    /// <summary>
    /// Prefix for FEMA RTLT
    /// </summary>
    public const string FEMARTLTPrefix = "fema-rtlt";

    /// <summary>
    /// Namespace for FEMA RTLT
    /// </summary>
    public const string FEMARTLTNamespace = "http://www.ptaccenter.org/Rtlt.Core.Api.V1";
  }
}
