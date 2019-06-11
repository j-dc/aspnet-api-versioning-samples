using Microsoft.AspNet.OData.Builder;
using Microsoft.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti.Config {
    public class ConfigModelConfiguration : IModelConfiguration {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) {

            switch (apiVersion.MajorVersion) {
                case 11:
                    builder.EntitySet<V11.Models.AModel>("A").EntityType.HasKey((x) => x.ID).Select();
                    builder.EntitySet<V11.Models.BModel>("B").EntityType.HasKey((x) => x.ID).Select();

                    break;
                case 12:
                    builder.EntitySet<V12.Models.AModel>("A").EntityType.HasKey((x) => x.ID).Select();
                    builder.EntitySet<V12.Models.BModel>("B").EntityType.HasKey((x) => x.ID).Select();

                    break;
            }
        }
    }
}
