using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02.Data.V2 {

    public class DataModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            if (apiVersion.MajorVersion == 2) {
                builder.EntitySet<V2.Models.LatestValueModel>("LatestValue").EntityType.HasKey((x) => x.ID).Select();
                builder.EntitySet<V2.Models.ValueModel>("Value").EntityType.HasKey((x) => x.ID).Select();
            }
        }
    }
}
