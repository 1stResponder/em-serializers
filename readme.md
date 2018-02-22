# **EDXL**

The Emergency Data Exchange Language (EDXL) libraries represent the suite of Emergency Management data standards from the Organization for the Advancement of Structured Information Standards (OASIS).

## **CIQ**

The Customer Information Quality (CIQ) standard represents information for People or Organizations, specifically their Name, Address, and Details.  For example, a person’s proper (full) name can be found in this standard as well as an Organization’s location (street address, geo coordinates, etc).

## **CT**

The Common Types (CT) library contains most of the base elements used by the EDXL standards.  This includes elements such as a formatted Date Time, formatted string, value list, etc…

## **DE**

The Distribution Element (DE) standard acts as a meta-data wrapper for the other EDXL standards, as well as plain old XML (POX) elements.  The meta-data information provides insight into the contents of the DE without having to examine the content directly.  This information can include: sender id, recipient description, content description, location information, keywords, among other values.

## **EXT**

The Extension (EXT) library serves as a structured mechanism to provide supplemental or additional information that has not been encoded into an EDXL standard.  The extension element contains a set of name/value pairs that allows other information to be included along with the core data standard information.  For example, communities of interest could leverage this mechanism to include required information in their messages that may not yet be a part of a data standard. 

## **GSF**

The GML Simple Features (GSF) standard acts as a wrapper that enables EDXL standards to contain GML structures, such as a GML Point. 

## **Shared**

The Shared library contains classes and methods are not part of the EDXL family of standards, but aid in their serialization and deserialization.

## **SitRep**

The Situation Report (SitRep) standard contains information that allows a first responder to generate a structured field report.  This standard allows them to ask for additional assistance/resources as well as provide a general status of the current incident.

## **Utilities**

Like the Shared library, the Utilities library contains classes and methods are not part of the EDXL family of standards, but aid in their serialization and deserialization.

 

# **NIEM**

The National Information Exchange Model (NIEM) libraries represent a suite of Emergency Management information exchanges, which are NIEM compliant.  NIEM is hosted and operated by several governmental agencies, including: DOJ, DHS, and HHS.

## **EMLC**

The Emergency Management Loose Coupler (EMLC) library represents the EMLC information exchange.  The main element of this exchange is the "event" element which acts as a general what, when, where data structure.  Each “event” allows 1 or more detail elements that contain more specifics about the general event.

## **Incident**

The Incident library represents the EMLC details about an Emergency Management incident.   

## **Infrastructure**

The Infrastructure library represents the EMLC details about a specific piece of infrastructure.

## **MutualAid**

The Mutual Aid library represents the EMLC details about a request and response for mutual aid assistance.  

## **NIEMCommon**

The NIEM Common library contains most of the base elements from the NIEM Core information exchanges. 

## **Resource**

The Resource library represents the EMLC details about an Emergency Management resource (unit/team/personnel).  

## **Sensor**

The Sensor library represents the EMLC details about a sensor or sensor system.     

## **DISCLAIMER OF LIABILITY NOTICE**:

                      

> The United States Government shall not be liable or responsible for
> any maintenance, updating or for correction of any errors in the
> software. 
>
> THIS SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND,
> EITHER EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED
> TO, ANY WARRANTY THAT THE SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY
> IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
> PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SOFTWARE
> WILL BE ERROR FREE, OR ANY WARRANTY THAT THE DOCUMENTATION, IF
> PROVIDED, WILL CONFORM TO THE SOFTWARE.  IN NO EVENT SHALL THE UNITED
> STATES GOVERNMENT OR ITS CONTRACTORS OR SUBCONTRACTORS BE LIABLE FOR
> ANY DAMAGES, INCLUDING, BUT NOT LIMITED TO, DIRECT, INDIRECT, SPECIAL
> OR CONSEQUENTIAL DAMAGES, ARISING OUT OF, RESULTING FROM, OR IN ANY
> WAY CONNECTED WITH THE SOFTWARE OR ANY OTHER PROVIDED DOCUMENTATION,
> WHETHER OR NOT BASED UPON WARRANTY, CONTRACT, TORT, OR OTHERWISE,
> WHETHER OR NOT INJURY WAS SUSTAINED BY PERSONS OR PROPERTY OR
> OTHERWISE, AND WHETHER OR NOT LOSS WAS SUSTAINED FROM, OR AROSE OUT OF
> THE RESULTS OF, OR USE OF, THE NICS SOFTWARE OR ANY PROVIDED
> DOCUMENTATION. THE UNITED STATES GOVERNMENT DISCLAIMS ALL WARRANTIES
> AND LIABILITIES REGARDING THIRD PARTY SOFTWARE, IF PRESENT IN THE
> SOFTWARE, AND DISTRIBUTES IT "AS IS."
>
>            
>
> LICENSEE AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST THE U.S.
> GOVERNMENT AND THE UNITED STATES GOVERNMENT'S CONTRACTORS AND
> SUBCONTRACTORS, AND SHALL INDEMNIFY AND HOLD HARMLESS THE U.S.
> GOVERNMENT AND THE UNITED STATES GOVERNMENT'S CONTRACTORS AND
> SUBCONTRACTORS FOR ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES, OR
> LOSSES THAT MAY ARISE FROM RECIPIENT'S USE OF THE SOFTWARE OR PROVIDED
> DOCUMENTATION, INCLUDING ANY LIABILITIES OR DAMAGES FROM PRODUCTS
> BASED ON, OR RESULTING FROM, THE USE THEREOF.
>
> **[ACKNOWLEDGEMENT NOTICE]**:
>
> *This software was developed with funds from the Department of
> Homeland Security's Science and Technology Directorate.* 
>
> **[PROHIBITION ON USE OF DHS IDENTITIES NOTICE]**:
>
> A.  No user shall use the DHS or its component name, seal or other
> identity, or any variation or adaptation thereof, for an enhancement,
> improvement, modification or derivative work utilizing the software.
>
> B.  No user shall use the DHS or its component name, seal or other
> identity, or any variation or adaptation thereof for advertising its
> products or services, with the exception of using a factual statement
> such as included in the ACKNOWLEDGEMENT NOTICE indicating DHS funding
> of development of the software.           
>
> C.  No user shall make any trademark claim to the DHS or its component
> name, seal or other identity, or any other confusing similar identity,
> and no user shall seek registration of these identities at the U.S.
> Patent and Trademark Office.

