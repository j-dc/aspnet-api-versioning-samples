using JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti.Config;
using JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Routing;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Owin;
using System;
using System.Web.Http;

namespace JDC.Api.Versioning.Samples.MultiEndpoint_01.MSVersioningMulti {
    class Startup {

        public void Configuration(IAppBuilder builder) {
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer(configuration);

            configuration.AddApiVersioning(options => options.ReportApiVersions = true);

            //-----DATA-----
            var modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new DataModelConfiguration() }
            };
            var models = modelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-data", "data/v{apiVersion}", models);


            //-----CONFIG-----
            var configModelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new ConfigModelConfiguration() }
            };
            var configModels = configModelBuilder.GetEdmModels();
            configuration.MapVersionedODataRoutes("odata-config", "config/v{apiVersion}", configModels);

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
