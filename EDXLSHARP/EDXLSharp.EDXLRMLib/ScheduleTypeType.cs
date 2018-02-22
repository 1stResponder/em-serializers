// ———————————————————————–
// <copyright file="ScheduleTypeType.cs" company="EDXLSharp">
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

namespace EDXLSharp.EDXLRMLib
{
  /// <summary>
  /// The enumeration of ScheduleType for resource message
  /// </summary>
  [Serializable]
  public enum ScheduleTypeType 
  { 
    /// <summary>
    /// When the resource is needed. Completed for Resource requests,
    /// returns, etc.
    /// ICS uses the term "delivery" versus "arrival". “Arrival" is used here
    /// because this applies to Human Resources also
    /// </summary>
    RequestedArrival, 
    
    /// <summary>
    /// Date and time the resource is expected to arrive at its “ReportTo”
    /// location.
    /// </summary>
    EstimatedArrival, 
    
    /// <summary>
    /// Date and time when the resource arrives at its “ReportTo” location.
    /// </summary>
    ActualArrival, 
    
    /// <summary>
    /// Date and time when the resource is requested to Depart from its
    /// current location for transit to a “ReportTo” location.
    /// </summary>
    RequestedDeparture, 
    
    /// <summary>
    /// Date and time when the resource is estimated to Depart from its
    /// current location for transit to a “ReportTo” location.
    /// </summary>
    EstimatedDeparture, 
    
    /// <summary>
    /// Date and time when the resource Departs from its current location for
    /// transit to a “ReportTo” location.
    /// </summary>
    ActualDeparture, 
    
    /// <summary>
    /// Date and time the resource is expected to Depart from its deployment
    /// for transit to its “OwningJurisdiction”.
    /// </summary>
    EstimatedReturnDeparture,
    
    /// <summary>
    /// Date and time the resource is expected to arrive from its deployment
    /// at its “OwningJurisdiction”.
    /// </summary>
    EstimatedReturnArrival, 
    
    /// <summary>
    /// Date and time the resource is expected to arrive from its deployment
    /// at its “OwningJurisdiction”.
    /// </summary>
    ActualReturnArrival, 
    
    /// <summary>
    /// Date and time the resource is requested to Depart from its deployment
    /// for transit to its “OwningJurisdiction”.
    /// </summary>
    RequestedReturnDeparture, 
    
    /// <summary>
    /// Date and time the resource is requested to arrive from its deployment
    /// at its “OwningJurisdiction”.
    /// </summary>
    RequestedReturnArrival, 
    
    /// <summary>
    /// Date and time the resource Departs from its deployment for transit to
    /// its “OwningJurisdiction”.
    /// </summary>
    ActualReturnDeparture, 
    
    /// <summary>
    /// Date and time the resource will become available for allocation.
    /// </summary>
    BeginAvailable, 
    
    /// <summary>
    /// Date and time the resource will cease to be available for deployment.
    /// </summary>
    EndAvailable, 
    
    /// <summary>
    /// Confirmation from Resource Supplier that resource has been allocated
    /// to Resource Consumer, usually in response to a
    /// “RequisitionResource” message.
    /// May be part of an “OriginatingMessage”.
    /// </summary>
    Committed, 
    
    /// <summary>
    /// Location of resource at date and time of message.
    /// </summary>
    Current, 
    
    /// <summary>
    /// Location of place where resource is to be delivered.
    /// May include a text description which explains to whom or where the
    /// resource should report upon arrival. This could include a name for a
    /// person, place or functional role.
    /// </summary>
    ReportTo, 
    
    /// <summary>
    /// Information specifying the course of transit of resource from.Resource
    /// Supplier to Resource Consumer.
    /// </summary>
    Route
  }
}
