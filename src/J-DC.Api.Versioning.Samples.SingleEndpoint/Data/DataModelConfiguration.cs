
using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.SingleEndpoint.Data {

        public class DataModelConfiguration : IModelConfiguration {
            public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {
            switch (apiVersion.MajorVersion) {
                case 17: {
                    builder.EntitySet<V17.Models.ValueModel>("Value").EntityType.HasKey((x)=>x.ID);
                    break;
                }
                case 18: {
                    builder.EntitySet<V18.Models.ValueModel>("Value").EntityType.HasKey((x) => x.ID);
                    break;
                }
            }
        }
    }
}
