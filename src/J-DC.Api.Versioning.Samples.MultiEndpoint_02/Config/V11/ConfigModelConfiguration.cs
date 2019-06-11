using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02.Config.V11 {
    public class ConfigModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            if (apiVersion.MajorVersion == 11) {
                builder.EntitySet<Models.AModel>("A").EntityType.HasKey((x) => x.ID).Select();
            }
        }
    }
}

