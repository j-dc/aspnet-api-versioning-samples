using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace JDC.Api.Versioning.Samples.CustomBuilder.Custom {
    public class MyModelBuilder : VersionedODataModelBuilder {
        public string EndPointName { get; }



        public MyModelBuilder(HttpConfiguration config, string endPointName = null) : base(config) {
            EndPointName = endPointName;
        }


        protected override IReadOnlyList<ApiVersion> GetApiVersions() {
            Contract.Ensures(Contract.Result<IReadOnlyList<ApiVersion>>() != null);

            var services = Configuration.Services;
            var assembliesResolver = services.GetAssembliesResolver();
            var typeResolver = services.GetHttpControllerTypeResolver();
            var actionSelector = services.GetActionSelector();
            var controllerTypes = typeResolver.GetControllerTypes(assembliesResolver).Where(
                (x) => {
                    return
                        x.IsNotInternal() &
                        x.IsODataController() &
                        x.IsContainedByEndPoint(EndPointName);
                });

            var controllerDescriptors = services.GetHttpControllerSelector().GetControllerMapping().Values;
            var supported = new HashSet<ApiVersion>();
            var deprecated = new HashSet<ApiVersion>();

            foreach (var controllerType in controllerTypes) {

                var controller = FindControllerDescriptor(controllerDescriptors, controllerType);

                if (controller == null) {
                    continue;
                }

                var actions = actionSelector.GetActionMapping(controller).SelectMany(g => g);

                foreach (var action in actions) {
                    var model = action.GetApiVersionModel();
                    var versions = model.SupportedApiVersions;

                    for (var i = 0; i < versions.Count; i++) {
                        supported.Add(versions[i]);
                    }

                    versions = model.DeprecatedApiVersions;

                    for (var i = 0; i < versions.Count; i++) {
                        deprecated.Add(versions[i]);
                    }
                }
            }

            deprecated.ExceptWith(supported);

            if (supported.Count == 0 && deprecated.Count == 0) {
                supported.Add(Options.DefaultApiVersion);
            }

            ConfigureMetadataController(supported, deprecated);

            return supported.Union(deprecated).ToArray();
        }

        static HttpControllerDescriptor FindControllerDescriptor(IEnumerable<HttpControllerDescriptor> controllerDescriptors, Type controllerType) {
            Contract.Requires(controllerDescriptors != null);
            Contract.Requires(controllerType != null);

            foreach (var controllerDescriptor in controllerDescriptors) {
                if (controllerDescriptor is IEnumerable<HttpControllerDescriptor> groupedControllerDescriptors) {
                    foreach (var groupedControllerDescriptor in groupedControllerDescriptors) {
                        if (controllerType.Equals(groupedControllerDescriptor.ControllerType)) {
                            return groupedControllerDescriptor;
                        }
                    }
                } else if (controllerType.Equals(controllerDescriptor.ControllerType)) {
                    return controllerDescriptor;
                }
            }

            return default;
        }




    }
}
