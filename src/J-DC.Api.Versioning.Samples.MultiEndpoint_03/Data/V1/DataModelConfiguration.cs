using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_03.Data.V1 {

    public class DataModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            if (apiVersion.MajorVersion == 1) {
                builder.EntitySet<V1.Models.ValueModel>("Value").EntityType.HasKey((x) => x.ID).Select();
            }
        }
    }
}
