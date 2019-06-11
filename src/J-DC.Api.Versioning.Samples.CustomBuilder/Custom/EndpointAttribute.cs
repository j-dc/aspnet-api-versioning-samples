using System;
using System.Collections.Generic;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Custom {

    [AttributeUsage(AttributeTargets.Class)]
    class EndPointAttribute  : Attribute {

        public HashSet<string> IncludedEndPoints { get; } = new HashSet<string>();
        public HashSet<string> ExcludedEndpoints { get; } = new HashSet<string>();

        public EndPointAttribute(string endpointName) {
            IncludedEndPoints.Add(endpointName);
        }

        public EndPointAttribute(string endpointName, string excludedEndpointName) {
            IncludedEndPoints.Add(endpointName);
            ExcludedEndpoints.Add(excludedEndpointName);
        }

        public EndPointAttribute(IEnumerable<string> endpointNames) {
            foreach (string endpointName in endpointNames) {
                IncludedEndPoints.Add(endpointName);
            }
        }

        public EndPointAttribute(IEnumerable<string> endpointNames, IEnumerable<string> excludedEndpointNames) {
            foreach (string endpointName in endpointNames) {
                IncludedEndPoints.Add(endpointName);
            }
            foreach (string endpointName in excludedEndpointNames) {
                ExcludedEndpoints.Add(endpointName);
            }
        }


    }
}
