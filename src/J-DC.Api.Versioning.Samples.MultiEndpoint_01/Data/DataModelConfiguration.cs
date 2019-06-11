using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti.Data {
    public class DataModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            switch (apiVersion.MajorVersion) {
                case 1: {
                    builder.EntitySet<V1.Models.ValueModel>("Value").EntityType.HasKey((x) => x.ID).Select();
                    break;
                }
                case 2: {
                    builder.EntitySet<V2.Models.LatestValueModel>("LatestValue").EntityType.HasKey((x) => x.ID).Select();
                    builder.EntitySet<V2.Models.ValueModel>("Value").EntityType.HasKey((x) => x.ID).Select();
                    break;
                }
            }
        }
    }
}
