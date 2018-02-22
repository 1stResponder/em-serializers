// ———————————————————————–
// <copyright file="ResponseResourcesTotals.cs" company="EDXLSharp">
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
using EDXLSharp;

namespace MEXLSitRep
{
  /// <summary>
  /// Response Resources Totals Sit Rep Type
  /// </summary>
  [Serializable]
  public partial class ResponseResourcesTotals : MEXLSitRepLib.ISitRepReport
  {
    #region Public Delegates/Events

    #endregion

    #region Private Member Variables
    /// <summary>
    /// Required Resources container object
    /// </summary>
    private TotalResources required;

    /// <summary>
    /// Requested Resources container object
    /// </summary>
    private TotalResources requested;

    /// <summary>
    /// Committed Resources container object
    /// </summary>
    private TotalResources committed;

    /// <summary>
    /// On Hand Resources container object
    /// </summary>
    private TotalResources onhand;

    /// <summary>
    /// Still Needed Resources container object
    /// </summary>
    private TotalResources stillNeeded;

    /// <summary>
    /// List of Response Resources Detail container objects
    /// </summary>
    private List<ResponseResourcesDetail> resourcesDetail;
    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the ResponseResourcesTotals class
    /// Default Constructor - Does Nothing
    /// </summary>
    public ResponseResourcesTotals()
    {
      this.resourcesDetail = new List<ResponseResourcesDetail>();
    }

    #endregion

    #region Public Accessors
    /// <summary>
    /// Gets or sets
    /// </summary>
    public TotalResources Required
    {
      get { return this.required; }
      set { this.required = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public TotalResources Requested
    {
      get { return this.requested; }
      set { this.requested = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public TotalResources Committed
    {
      get { return this.committed; }
      set { this.committed = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public TotalResources OnHand
    {
      get { return this.onhand; }
      set { this.onhand = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public TotalResources StillNeeded
    {
      get { return this.stillNeeded; }
      set { this.stillNeeded = value; }
    }

    /// <summary>
    /// Gets or sets
    /// </summary>
    public List<ResponseResourcesDetail> ResourcesDetail
    {
      get { return this.resourcesDetail; }
      set { this.resourcesDetail = value; }
    }
    #endregion

    #region Public Member Functions

    /// <summary>
    /// Writes this Object to an inline XML Document
    /// </summary>
    /// <param name="xwriter">Valid XMLWriter</param>
    internal override void WriteXML(XmlWriter xwriter)
    {
      xwriter.WriteStartElement("ResponseResourcesTotals");

      if (this.required != null)
      {
        xwriter.WriteStartElement("TotalResourcesRequired");
        this.required.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.requested != null)
      {
        xwriter.WriteStartElement("TotalResourcesRequested");
        this.requested.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.committed != null)
      {
        xwriter.WriteStartElement("TotalResourcesCommitted");
        this.committed.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.onhand != null)
      {
        xwriter.WriteStartElement("TotalResourcesOnHand");
        this.onhand.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.stillNeeded != null)
      {
        xwriter.WriteStartElement("TotalResourcesStillNeeded");
        this.stillNeeded.WriteXML(xwriter);
        xwriter.WriteEndElement();
      }

      if (this.resourcesDetail.Count != 0)
      {
        foreach (ResponseResourcesDetail detailtemp in this.resourcesDetail)
        {
          detailtemp.WriteXML(xwriter);
        }
      }

      xwriter.WriteEndElement();
    }

    /// <summary>
    /// Reads this Object's values from an XML node list
    /// </summary>
    /// <param name="rootnode">root XML Node of the Object element</param>
    internal override void ReadXML(XmlNode rootnode)
    {
      ResponseResourcesDetail detailstemp;

      foreach (XmlNode childnode in rootnode.ChildNodes)
      {
        if (string.IsNullOrEmpty(childnode.InnerText))
        {
          continue;
        }

        switch (childnode.LocalName)
        {
          case "TotalResourcesRequired":
            this.required = new TotalResources();
            this.required.ReadXML(childnode);
            break;
          case "TotalResourcesRequested":
            this.requested = new TotalResources();
            this.requested.ReadXML(childnode);
            break;
          case "TotalResourcesCommitted":
            this.committed = new TotalResources();
            this.committed.ReadXML(childnode);
            break;
          case "TotalResourcesOnHand":
            this.onhand = new TotalResources();
            this.onhand.ReadXML(childnode);
            break;
          case "TotalResourcesStillNeeded":
            this.stillNeeded = new TotalResources();
            this.stillNeeded.ReadXML(childnode);
            break;
          case "ResponseResourcesDetail":
            if (this.resourcesDetail == null)
            {
              this.resourcesDetail = new List<ResponseResourcesDetail>();
            }
            
            detailstemp = new ResponseResourcesDetail();
            detailstemp.ReadXML(childnode);
            this.resourcesDetail.Add(detailstemp);
            break;
          case "#comment":
            break;
          default:
            throw new ArgumentException("Unexpected Child Node Name: " + childnode.Name + " in ResponseResourcesTotals");
        }
      }
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="myitem">Pointer to a Syndication Item to Populate</param>
    internal override void ToGeoRSS(System.ServiceModel.Syndication.SyndicationItem myitem)
    {
      // myitem.Title = new TextSyndicationContent("Field Observation - " + observationType.ToString() + " (EDXL-SitRep)");
      // TextSyndicationContent content = new TextSyndicationContent("Observation: " + this.observationText + "\nImmediate Needs: " + this.immediateNeeds);
      myitem.Title = new TextSyndicationContent("Response Resources Totals - " + " (EDXL-SitRep)");
      TextSyndicationContent content = new TextSyndicationContent("Response Resources Totals: " + "\nImmediate Needs: ");
      myitem.Content = content;
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    internal override void SetContentKeywords(ValueList ckw)
    {
      ckw.Value.Add("MEXL-SitRep ResponseResourcesTotals");
    }
    #endregion

    #region Protected Member Functions

    /// <summary>
    /// Validates This Message element For Required Values and Conformance
    /// </summary>
    protected override void Validate()
    {
    }

    #endregion

    #region Private Member Functions

    #endregion
  }
}
