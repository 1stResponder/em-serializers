using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIEMSharp;
using NIEMSharp.MutualAidRequest;
using NIEMSharp.MutualAidRespond;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using NIEMSHARP.NIEMEMLCLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using NIEMSHARP.NIEMEMLCLib.CoreWarpper;
using NIEMSHARP.NIEMEMLCLib.Geo4NIEM;
using NIEMSHARP.NIEMEMLCLib.Resource;
using NIEMSHARP.NIEMEMLCLib.Incident;
using NIEMSHARP.NIEMEMLCLib.Infrastructure;
using System.Xml.Linq;
using NIEMSharp.MutualAidRespond.ResponseResources;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            

        try
        { 

            //-- Creating Event with default values (check if these vary...)
                 
                Event newEvent = new Event();

                //set the basics
                newEvent.EventID = "1839-a784-199d-fe33";
                newEvent.EventMessageDateTime = System.DateTime.UtcNow;
                newEvent.EventTypeDescriptor.CodeValue = EventTypeCodeList.Tasking; 
                newEvent.EventValidityDateTimeRange.StartDate = System.DateTime.UtcNow;
                newEvent.EventValidityDateTimeRange.EndDate = System.DateTime.UtcNow.AddHours(1.0);

                //set the location
                EventLocation location = new EventLocation();
                location.LocationCylinder.CodeValue = LocationCreationCodeList.MACHINE;
                location.LocationCylinder.LocationPoint.Point.id = "ID1";
                location.LocationCylinder.LocationPoint.Point.Lat = 30.1;
                location.LocationCylinder.LocationPoint.Point.Lon = 30.1;
                location.LocationCylinder.LocationCylinderHalfHeightValue = (decimal)1.4;
                location.LocationCylinder.LocationCylinderRadiusValue = (decimal)1.0;
                newEvent.EventLocation = location;

                //set a comment
             /*   EventComment comment = new EventComment();
                comment.CommentText = "";
                comment.DateTime = System.DateTime.UtcNow;
                comment.OrganizationIdentification = "ARDENTMC General";
                comment.PersonHumanResourceIdentification = "Dr. Brian Wilkins";
                newEvent.EventComment = new List<EventComment>();
                newEvent.EventComment.Add(comment);*/
      
            
            //-- Creating MutualAidDetail 

                MutualAidDetail md = new MutualAidDetail();

            //-- Aid Request areq1

                AidRequested areq1 = new AidRequested();

                GenericResource grA = new GenericResource();
                grA.Quantity = 1;
                grA.ResourceKind.ResourceTypeCodeValue = EventTypeCodeList.ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_EMS_AMBULANCE;
                areq1.Resource = new RequestedResources(grA);

                GenericResource grB = new GenericResource();
                grB.Quantity = 1;
                grB.ResourceKind.ResourceTypeCodeValue = EventTypeCodeList.ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE;
                areq1.Resource.ResourceList.Add(grB);
                
                areq1.location = new LocationExtension(new Address(new LocationStreet()));
                areq1.location.Address.LocationStreet.StreetName = "2332";
                areq1.location.Address.LocationStreet.StreetNumberText = "Riverside";
                areq1.location.Address.LocationStreet.StreetCategoryText = "Pkwy";
                areq1.location.Address.LocationState = USStateCodeList.CA;
                areq1.location.Address.LocationCityName = "Sacramento";
                areq1.location.Address.LocationPostalCode = "95605";
            
            //-- Aid Request areq2
                
                AidRequested areq2 = new AidRequested();

                SpecificResource srA = new SpecificResource();
                srA.ResourceIdentifier = "3-508-1028";
                areq2.Resource = new RequestedResources(srA);

            //-- Aid Request areq3
                
                AidRequested areq3 = new AidRequested();

                MissionNeed mn1 = new MissionNeed();
                mn1.Quantity = 1;
                mn1.ValueText = "ATOM.GRDTRK.EQT.GRDVEH.CVLVEH.EM.PUBLICWORKS.TRUCK.WATER"; // will need to change here... 
                areq3.Resource = new RequestedResources(mn1);

            //-- Aid Request ares1

                AidResponding ares1 = new AidResponding();
                ares1.Approved = true;

                Equipment eq1 = new Equipment();
                eq1.ID = "3-508-1023";
                eq1.EstimatedArrival = DateTime.UtcNow.AddHours(1);
                eq1.ResourceKind.ResourceTypeCodeValue = EventTypeCodeList.ATOM_GRDTRK_EQT_GRDVEH_CVLVEH_EM_FIRE_TRUCK;
                eq1.EstimatedAvailability.StartDate = DateTime.UtcNow;
                eq1.EstimatedAvailability.EndDate = DateTime.UtcNow.AddMinutes(30);
                ares1.Resources = new RespondingResource(eq1);

                ares1.ContactInformation.Entity = "ArdentMC Fire Co.";
                ares1.ContactInformation.Responder = "John Smith";

            //-- Aid Request ares2
                AidResponding ares2 = new AidResponding();
                ares2.Approved = true;

                Person p1 = new Person();
                p1.ID = "ID2";
                p1.EstimatedArrival = DateTime.UtcNow.AddMinutes(20);
                p1.EstimatedAvailability.StartDate = DateTime.UtcNow;
                p1.EstimatedAvailability.EndDate = DateTime.UtcNow.AddMinutes(50);
                ares2.Resources = new RespondingResource(p1);

                Person p2 = new Person();
                p2.ID = "ID3";
                p2.EstimatedArrival = DateTime.UtcNow.AddMinutes(20);
                p2.EstimatedAvailability.StartDate = DateTime.UtcNow;
                p2.EstimatedAvailability.EndDate = DateTime.UtcNow.AddMinutes(50);
                p2.Rank = new Rank();
                p2.Rank.ValueText = "EMT-P"; // may need to change since this since this isn't on any list I know of 
                ares2.Resources.ResourceList.Add(p2);                        
                ares2.ContactInformation.Entity = "ArdentMC Medical Facilities";
                       
        
                // Adding Detail to Event 

                string xmlSample = "";


                // areq1

                md.Message = areq1;
                newEvent.Details = md;

                xmlSample = newEvent.ToString();
                File.WriteAllText(@"C:\Sample\MutualAidReq1.xml", xmlSample);

               
                // areq2

                md.Message = areq2;
                newEvent.Details = md;

                xmlSample = newEvent.ToString();
                File.WriteAllText(@"C:\Sample\MutualAidReq2.xml", xmlSample);

                // areq3

                md.Message = areq3;
                newEvent.Details = md;

                xmlSample = newEvent.ToString();
                File.WriteAllText(@"C:\Sample\MutualAidReq3.xml", xmlSample);

                // ares1

                md.Message = ares1;
                newEvent.Details = md;

                xmlSample = newEvent.ToString();
                File.WriteAllText(@"C:\Sample\MutualAidRes1.xml", xmlSample);

                // ares2

                md.Message = ares2;
                newEvent.Details = md;

                xmlSample = newEvent.ToString();
                File.WriteAllText(@"C:\Sample\MutualAidRes2.xml", xmlSample);





/*
            //-- Serializing Event Object 

                string xml = newEvent.ToString();
                File.WriteAllText(@"C:\event.xml", xml);


            //-- Deserializing from newly created xml 
        
                string json = NIEMEmlcUtil.xmlToJson(xml);      
                Event testEv =  JsonConvert.DeserializeObject<Event>(json, new NIEMSHARP.NIEMEMLCLib.deSerialEventConverter(xml);
                string newXML = testEv.ToString();
                File.WriteAllText(@"C:\newEvent.xml", newXML);            
                 

 // */ 
 //--------- Test with provided string             
 /*

                string xmlString;
                xmlString = ""; // where string goes 
                
                Event stringEv =  JsonConvert.DeserializeObject<Event>(json, new NIEMSHARP.NIEMEMLCLib.deSerialEventConverter(xmlString);
                string stringXML = stringEv.ToString();
                File.WriteAllText(@"C:\stringEvent.xml", stringXML);

 // */
        }
            catch (Exception e)
            {
               string s = e.Message + "\n";
            }
           
        }
    }
}
