// ———————————————————————–
// <copyright file="MessageType.cs" company="EDXLSharp">
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
  /// Represents The 16 Different Resource Message Types
  /// </summary>
  [Serializable]
  public enum MessageType
  {
    /// <summary>
    /// Message used to request needed resources from one or many recipients, possibly spawning multiple responses. 
    /// </summary>
    RequestResource,

    /// <summary>
    /// Message used as the response to a “RequestResource”. Allows sender to list resource(s) which they feel represent suitable match with a resource request. 
    /// </summary>
    ResponseToRequestResource,

    /// <summary>
    /// Message used to “order” specific resource, or to confirm specific resource to be “ordered” relating to one or more responses to a “RequestResource”. 
    /// </summary>
    RequisitionResource,

    /// <summary>
    /// Message used to agree or commit specific resource in response to a RequestResource or RequisitionResource,”.
    /// </summary>
    CommitResource,

    /// <summary>
    /// Message used to ask resource questions or provide general description of situation and general resources needs. 
    /// </summary>
    RequestInformation,

    /// <summary>
    /// Message used as the response to a RequestInformation message providing general information or to list resource that may meet the specified need. 
    /// </summary>
    ResponseToRequestInformation,

    /// <summary>
    /// Message used to offer available resources (that have not been requested) to assist with an emergency response. 
    /// </summary>
    OfferUnsolicitedResource,

    /// <summary>
    /// Message used at the incident to “release” (demobilize) resource back to its original Supplier.
    /// </summary>
    ReleaseResource,

    /// <summary>
    /// Message used to request release (demobilize) of resources back to its original point of assignment or to another location / assignment ("I want my stuff back"). 
    /// </summary>
    RequestReturn,

    /// <summary>
    /// Message used as the response to a "RequestReturn" indicating whether the resource may be released, with relevant time-line information.
    /// </summary>
    ResponseToRequestReturn,

    /// <summary>
    /// Message used to request a price quote from a seller or supplier. 
    /// </summary>
    RequestQuote,

    /// <summary>
    /// Message used as the response to a “RequestQuote”. Allows sender to list resource(s) which they feel represent suitable match with the request, with pricing information. 
    /// </summary>
    ResponseToRequestQuote,

    /// <summary>
    /// Message used to request current “status” of resource. 
    /// </summary>
    RequestResourceDeploymentStatus,

    /// <summary>
    /// Message used to report on the current “status” of any resource. 
    /// </summary>
    ReportResourceDeploymentStatus,

    /// <summary>
    /// A request initiated by the requester / receiver of resource, “I want to extend how long I need to keep this resource” 
    /// </summary>
    RequestExtendedDeploymentDuration,

    /// <summary>
    /// Message used as the response to “RequestExtendedDeploymentDuration”. 
    /// </summary>
    ResponseToRequestExtendedDeploymentDuration
  }
}