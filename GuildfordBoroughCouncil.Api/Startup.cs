using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Cors;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(GuildfordBoroughCouncil.Api.Startup))]
namespace GuildfordBoroughCouncil.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region WebAPI Config

            var apiConfig = new HttpConfiguration();

            // Load controllers from other assemblies
            apiConfig.Services.Replace(typeof(IAssembliesResolver), new DefaultAssembliesResolver());
            
            // Map attribute routes
            apiConfig.MapHttpAttributeRoutes();
            apiConfig.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Set JSON
            apiConfig.Formatters.Clear();
            apiConfig.Formatters.Add(new JsonMediaTypeFormatter());
            apiConfig.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                };
            apiConfig.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new GuildfordBoroughCouncil.Json.Converters.ObjectToStringConverter<long>());
            apiConfig.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter { CamelCaseText = true });

            apiConfig.EnableSystemDiagnosticsTracing();

            //var BinDir = new System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + @"\bin");

            //foreach (var file in BinDir.EnumerateFiles("*.xml"))
            //{
            //    apiConfig.EnableSwagger(file.Name.ToLower() + "/docs/{apiVersion}/swagger", c =>
            //    {
            //        c.IgnoreObsoleteProperties();
            //        //c.UseFullTypeNameInSchemaIds();
            //        c.DescribeAllEnumsAsStrings();

            //        c.SingleApiVersion("v1", "Test");

            //        c.IncludeXmlComments(file.FullName);
            //    })
            //    .EnableSwaggerUi(c =>
            //    {
            //        c.EnableDiscoveryUrlSelector();
            //    });
            //}            

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            #endregion

            app.UseWebApi(apiConfig);
            //app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}