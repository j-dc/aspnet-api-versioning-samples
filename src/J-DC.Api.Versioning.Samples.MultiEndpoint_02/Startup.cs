using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Routing;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Owin;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_02 {
    class Startup {

        public void Configuration(IAppBuilder builder) {
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer(configuration);

            configuration.AddApiVersioning(options => options.ReportApiVersions = true);


            //-----DATA V1-----
            var modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new Data.V1.DataModelConfiguration() }
            };
            var models = modelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-data-v1", "data/v{apiVersion}", models, ConfigureContainer);

            //-----DATA V2-----
            modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new Data.V2.DataModelConfiguration() }
            };
            models = modelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-data-v2", "data/v{apiVersion}", models, ConfigureContainer);

            //-----CONFIG V11-----
            modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new Config.V11.ConfigModelConfiguration() }
            };
            models = modelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-config-v11", "config/v{apiVersion}", models, ConfigureContainer);

            //-----CONFIG V12-----
            modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new Config.V12.ConfigModelConfiguration() }
            };
            models = modelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-config-v12", "config/v{apiVersion}", models, ConfigureContainer);


            var apiExplorer = configuration.AddODataApiExplorer(
                options => {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;

                });
            builder.UseWebApi(httpServer);
        }

        public static string ContentRootPath {
            get {
                var app = AppDomain.CurrentDomain;

                if (string.IsNullOrEmpty(app.RelativeSearchPath)) {
                    return app.BaseDirectory;
                }

                return app.RelativeSearchPath;
            }
        }
  

        static void ConfigureContainer(IContainerBuilder builder) {
            builder.AddService<IODataPathHandler>(ServiceLifetime.Singleton, sp => new DefaultODataPathHandler() { UrlKeyDelimiter = ODataUrlKeyDelimiter.Parentheses });
            builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new UnqualifiedCallAndEnumPrefixFreeResolver() { EnableCaseInsensitive = true });
        }
    }
}
