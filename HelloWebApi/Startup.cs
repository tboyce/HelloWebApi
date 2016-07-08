using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using HelloWebApi.Configuration;
using HelloWebApi.ErrorHandling;
using Owin;
using Swashbuckle.Application;

namespace HelloWebApi
{
    /// <summary>
    /// This is the OWIN startup class (located by convention).
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // create a configuration for Web API
            var configuration = new HttpConfiguration();

            // configure routes for Web API
            configuration.MapHttpAttributeRoutes();

            // handle unhandled exceptions
            configuration.Services.Replace(typeof(IExceptionHandler), new ErrorMessageExceptionHandler());

            // configure Unity
            UnityConfig.RegisterComponents(configuration);

            // configure swagger
            configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "Greetings API"))
                .EnableSwaggerUi(c => c.DocExpansion(DocExpansion.List));

            // register Web API with OWIN
            appBuilder.UseWebApi(configuration);
        }
    }
}
