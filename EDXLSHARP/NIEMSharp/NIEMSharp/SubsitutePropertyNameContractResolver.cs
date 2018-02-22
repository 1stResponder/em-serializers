using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;
using NIEMSHARP.NIEMEMLCLib;
using NIEMSHARP.NIEMEMLCLib.CoreWarpper;
using NIEMSharp.MutualAidRequest;
using NIEMSharp.MutualAidRespond;
using Newtonsoft.Json.Serialization;

namespace NIEMSharp
{

    /// <summary>
    /// Used during Json serialization to substitute abstract elements' names
    /// with the correct child name
    /// </summary>
    public class SubsitutePropertyNameContractResolver : DefaultContractResolver
    {
        public new static readonly SubsitutePropertyNameContractResolver Instance = new SubsitutePropertyNameContractResolver();
        protected List<Type> runtime; // Holds all the runtime types of the abstract elements 

        /// <summary>
        /// Populates runtime with the abstract elements run time types
        /// </summary>
        /// <param name="rt">List of runtime types</param>
        public void setTypes(List<Type> rt)
        {
            runtime = rt;
        }


        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
      
            JsonProperty property = base.CreateProperty(member, memberSerialization);

                // substituting message in MutualAidDetail
                if (property.DeclaringType == typeof(MutualAidDetail) && property.PropertyName == "Message")
                {

                    foreach (Type T in runtime)
                    {
                        Type derive = T;

                        string t = property.UnderlyingName;
                        string y = property.ToString();

                        // Get Property name based on derived type
                        if (derive == typeof(AidRequested))
                        {
                            property.PropertyName = Constants.MaidPrefix + "--" + "AidRequested";

                            property.ShouldSerialize =
                            instance =>
                            {
                                return true;
                            };
                        }
                        else if (derive == typeof(AidResponding))
                        {
                            property.PropertyName = Constants.MaidPrefix + "--" + "AidResponding";

                            property.ShouldSerialize =
                            instance =>
                            {
                                return true;
                            };
                        } 
                       

                    }
               
            }


            // substituting request in RequestedResources
            if (property.DeclaringType == typeof(RequestedResources) && property.PropertyName == "resource")
            {

                foreach (Type T in runtime)
                {
                    Type derive = T;

                    // setting new name based on runtime type 
                    if (derive == typeof(SpecificResource))
                    {
                        property.PropertyName = Constants.MaidPrefix + "--" + "AidRequestedSpecificResource";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };
                    }
                    else if (derive == typeof(GenericResource))
                    {
                        property.PropertyName = Constants.MaidPrefix + "--" + "AidRequestedGenericResource";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };

                    }
                    else if (derive == typeof(MissionNeed))
                    {
                        property.PropertyName = Constants.MaidPrefix + "--" + "AidRequestedMissionNeed";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };
                    } 

                }
            }

            // substituting request in RespondingResources
            if (property.DeclaringType == typeof(RespondingResource) && property.PropertyName == "resource")
            {

                foreach (Type T in runtime)
                {
                    Type derive = T;

                    // setting new name based on runtime type 
                    if (derive == typeof(Person))
                    {
                        property.PropertyName = Constants.MaidPrefix + "--" + "AidRespondingPerson";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };
                    }
                    else if (derive == typeof(Equipment))
                    {
                        property.PropertyName = Constants.MaidPrefix + "--" + "AidRespondingEquipment";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };

                    }
                }

            }


            // substituting AreaRegion in LocationExtension
            if (property.DeclaringType == typeof(LocationExtension) && property.PropertyName == "AreaRegion")
            {

                foreach (Type T in runtime)
                {
                    Type derive = T;

                    // setting new name based on runtime type 
                    if (derive == typeof(LocationEllipse))
                    {
                        property.PropertyName = Constants.MofPrefix + "--" + "LocationEllipse";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };

                    }
                    else if (derive == typeof(LocationExternalPolygon))
                    {
                        property.PropertyName = Constants.MofPrefix + "--" + "LocationExternalPolygon";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };

                    }
                    else if (derive == typeof(LocationLineString))
                    {
                        property.PropertyName = Constants.MofPrefix + "--" + "LocationLineString";

                        property.ShouldSerialize =
                        instance =>
                        {
                            return true;
                        };
                    }
                }
            }

            return property;

            

        }
    }


} // end namespace
    
   



