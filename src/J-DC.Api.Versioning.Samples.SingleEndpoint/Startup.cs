using JDC.Api.Versioning.Samples.SingleEndpoint.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Routing;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Owin;
using System;
using System.Web.Http;

namespace JDC.Api.Versioning.Samples.SingleEndpoint {
    class Startup {

        public void Configuration(IAppBuilder builder) {
            var configuration = new HttpConfiguration();
            var httpServer = new HttpServer(configuration);
            var batchHandler = new DefaultODataBatchHandler(httpServer);

            configuration.AddApiVersioning(options => options.ReportApiVersions = true);

            var modelBuilder = new VersionedODataModelBuilder(configuration) {
                ModelConfigurations = { new DataModelConfiguration() }
            };
            var models = modelBuilder.GetEdmModels();

            configuration.MapVersionedODataRoutes("odata", "data/v{apiVersion}", models, ConfigureContainer, batchHandler);

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
