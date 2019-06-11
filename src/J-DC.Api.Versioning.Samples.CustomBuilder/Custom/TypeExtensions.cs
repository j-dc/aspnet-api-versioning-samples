using JDC.Api.Versioning.Samples.CustomBuilder.Custom;
using Microsoft.AspNet.OData;
using System;

namespace JDC.Api.Versioning.Samples.CustomBuilder {
    public static class TypeExtensions {

        internal static readonly Type ODataRoutingAttributeType = typeof(ODataRoutingAttribute);
        internal static readonly Type EndpointAttributeType = typeof(EndPointAttribute);
        internal static readonly Type VersionedMetadataControllerType = typeof(VersionedMetadataController);
        internal static readonly Type MetadataControllerType = typeof(MetadataController);


        internal static bool IsNotInternal(this Type controllerType) {
            return !controllerType.Equals(VersionedMetadataControllerType)
                & !controllerType.Equals(MetadataControllerType);
                
        }

        internal static bool IsODataController(this Type controllerType) {
            return Attribute.IsDefined(controllerType, ODataRoutingAttributeType);
        }

        internal static bool IsContainedByEndPoint(this Type controllerType, string endPointName) {
            //Inclusive modus..  if no attribute,  then controller is included.
            if (!Attribute.IsDefined(controllerType, EndpointAttributeType)) {
                return true;
            }

            var ca = (EndPointAttribute)Attribute.GetCustomAttribute(controllerType, EndpointAttributeType);



            if (ca.IncludedEndPoints.Count > 0)
                return ca.IncludedEndPoints.Contains(endPointName);
                

            if (ca.ExcludedEndpoints.Count > 0) {
                return !ca.ExcludedEndpoints.Contains(endPointName);
            }

            //This should never be reached..
            return true;

        }

    }
}
