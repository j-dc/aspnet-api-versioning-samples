using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;
using System;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02.Config.V12 {
    public class ConfigModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            if (apiVersion.MajorVersion == 12) {
                builder.EntitySet<V12.Models.AModel>("A").EntityType.HasKey((x) => x.ID).Select();
                builder.EntitySet<V12.Models.BModel>("B").EntityType.HasKey((x) => x.ID).Select();
            }
        }
    }
}
