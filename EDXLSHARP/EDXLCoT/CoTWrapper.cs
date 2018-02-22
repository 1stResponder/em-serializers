// ———————————————————————–
// <copyright file="CoTWrapper.cs" company="EDXLSharp">
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

using CoT_Library;
using CoT_Library.Details;
using EDXLSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EDXLCoT
{
  /// <summary>
  /// Wrapper for Cot.NET to implement the EDXL Sharp Interfaces
  /// </summary>
  public class CoTWrapper : IContentObject, IGeoRSS
  {
    /// <summary>
    /// The default stale time if there is none provided. Currently set to one day
    /// </summary>
    private static TimeSpan defaultStaleOffset = new TimeSpan(1, 0, 0, 0, 0);

    /// <summary>
    /// The CoT Event Object
    /// </summary>
    private CotEvent cotevent;

    /// <summary>
    /// Gets or sets the CoT Event Object
    /// </summary>
    public CotEvent CoTEvent
    {
      get { return this.cotevent; }
      set { this.cotevent = value; }
    }

    /// <summary>
    /// Gets the time this CoT Event is considered stale
    /// </summary>
    public DateTime ExpiresDateTime
    {
      get { return this.cotevent.Stale; }
    }

    /// <summary>
    /// Override of IContentObject Interface Function
    /// </summary>
    /// <param name="ckw">ValueList Object for Content Keywords</param>
    /// <returns>String to Process ContentKeyWord Value From</returns>
    public string SetContentKeywords(ValueList ckw)
    {
      ckw.ValueListURN = EDXLConstants.ContentKeywordListName;
      ckw.Value.Add("CoTEvent");
      ckw.Value.Add(this.cotevent.Type);
      return "CoTEvent";
    }

    /// <summary>
    /// Validates This Message to the schema
    /// </summary>
    public void ValidateToSchema()
    {
      // TODO: CoTWrapper.ValidateToSchema()
    }

    /// <summary>
    /// Converts This IComposableMessage Into A Geo-RSS SyndicationItem
    /// </summary>
    /// <param name="items">Pointer to a Valid List of Syndication Items to Populate</param>
    /// <param name="linkUID">Unique Identifier to Link This Item To</param>
    public void ToGeoRSS(List<SyndicationItem> items, Guid linkUID)
    {
      SyndicationItem myitem = new SyndicationItem();
      myitem.Authors.Add(new SyndicationPerson(this.cotevent.How, "How", string.Empty));
      myitem.Categories.Add(new SyndicationCategory("CoT", EDXLConstants.SyndicationCategoryScheme, EDXLConstants.SyndicationCategoryLabel));
      this.WriteGeoRSSGML(myitem);
      myitem.Copyright = new TextSyndicationContent(EDXLConstants.SyndicationCopyright);
      myitem.LastUpdatedTime = this.cotevent.Start;
      myitem.Links.Add(new SyndicationLink(new Uri(EDXLConstants.SyndicationLinkBaseURI + "HTML/" + linkUID.ToString())));
      myitem.PublishDate = DateTime.Now;

      if (this.cotevent.Stale != null)
      {
        myitem.ElementExtensions.Add("expire_time", string.Empty, this.cotevent.Stale.ToUniversalTime().ToString());
      }
      else
      {
        myitem.ElementExtensions.Add("expire_time", string.Empty, myitem.PublishDate.Add(defaultStaleOffset).ToUniversalTime().ToString());
      }

      string summary = this.cotevent.Type;

      ICotDetailComponent details = this.cotevent.Detail.GetFirstElement("_EMTasking");
      if (details != null)
      {
        XmlNode node = details.XmlNode.SelectSingleNode("Address");
        if (node != null)
        {
          summary = node.InnerText;
        }
      }
      else
      {
        ICotDetailComponent remarks = this.cotevent.Detail.GetFirstElement("remarks");
        if (remarks != null && remarks.XmlNode != null)
        {
          summary = remarks.XmlNode.InnerText;
        }

        if (string.IsNullOrWhiteSpace(summary))
        {
          summary = this.cotevent.Type;
        }
      }

      myitem.Summary = new TextSyndicationContent(summary);

      ICotDetailComponent detailsUID = this.cotevent.Detail.GetFirstElement("uid");
      if (detailsUID != null && detailsUID.XmlNode != null)
      {
        XmlAttribute fvcotDetailsUID = detailsUID.XmlNode.Attributes["fvcot"];
        XmlAttribute icnetDetailsUID = detailsUID.XmlNode.Attributes["icnet"];

        if (fvcotDetailsUID != null)
        {
          myitem.Title = new TextSyndicationContent(fvcotDetailsUID.Value + " (CoT)");
        }
        else if (icnetDetailsUID != null)
        {
          myitem.Title = new TextSyndicationContent(icnetDetailsUID.Value + " (CoT)");
        }
        else
        {
          myitem.Title = new TextSyndicationContent(this.cotevent.Uid + " (CoT)");
        }
      }
      else
      {
        myitem.Title = new TextSyndicationContent(this.cotevent.Uid + " (CoT)");
      }

      StringBuilder contentstr = new StringBuilder();

      myitem.Content = new TextSyndicationContent(this.cotevent.Type);

      items.Add(myitem);
    }

    /// <summary>
    /// Writes This Object to an Existing XML Document
    /// </summary>
    /// <param name="xwriter">Pointer to the XMLWriter Writing the Document</param>
    public void WriteXML(XmlWriter xwriter)
    {
      XNamespace xn = EDXLConstants.EDXLCoTNamespace;
      XElement xe = XElement.Parse(this.cotevent.ToString());
      xe.SetAttributeValue("xmlns", xn);

      // Then also prefix the name of the element with the namespace
      xe.Name = xn + xe.Name.LocalName;
      xe.WriteTo(xwriter);
    }

    /// <summary>
    /// Reads A CoT Message From A String
    /// </summary>
    /// <param name="rootnode">String of XML CoT Data</param>
    public void ReadXML(XmlNode rootnode)
    {
      string s = rootnode.OuterXml;
      int index, end, len;
      index = s.IndexOf("xmlns=");
      while (index != -1)
      {
        end = s.IndexOf('"', index);
        end++;
        end = s.IndexOf('"', end);
        end++;
        len = end - index;
        s = s.Remove(index, len);
        index = s.IndexOf("xmlns=");
      }

      this.cotevent = new CotEvent(s);
    }

    /// <summary>
    /// Validates this message to be conformant to the schema
    /// </summary>
    public void Validate()
    {
      // TODO: CoTWrapper.Validate()
    }

    /// <summary>
    /// Writes this CoT Object to GeoRSS GML
    /// </summary>
    /// <param name="item">Syndication Item to Convert to GML</param>
    private void WriteGeoRSSGML(SyndicationItem item)
    {
      StringBuilder output = new StringBuilder();
      XmlWriterSettings xsettings = new XmlWriterSettings();
      xsettings.Indent = true;
      xsettings.IndentChars = "\t";
      xsettings.OmitXmlDeclaration = true;
      XmlWriter xwriter = XmlWriter.Create(output, xsettings);
      xwriter.WriteStartElement(EDXLConstants.GeoRSSPrefix, "where", EDXLConstants.GeoRSSNamespace);
      xwriter.WriteStartElement(EDXLConstants.GMLPrefix, "Point", EDXLConstants.GMLNamespace);
      xwriter.WriteElementString(EDXLConstants.GMLPrefix, "pos", EDXLConstants.GMLNamespace, this.cotevent.Point.Latitude.ToString() + " " + this.cotevent.Point.Longitude.ToString());
      xwriter.WriteEndElement();
      xwriter.WriteEndElement();
      xwriter.Flush();
      xwriter.Close();
      MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(output.ToString()));
      item.ElementExtensions.Add(XmlReader.Create(ms));
    }
  }
}
