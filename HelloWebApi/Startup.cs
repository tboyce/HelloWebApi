using System.Web.Http;
using HelloWebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace HelloWebApi
{
    /// <summary>
    ///     This is the class that starts the web application using OWIN.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // create an HTTP configuration
            var config = new HttpConfiguration();

            // configure Enterprise Library
            EntLibConfig.Register();

            // configure Web API
            WebApiConfig.Register(config);

            // configure Unity
            UnityConfig.RegisterComponents(config);

            // map to the /api path
            app.Map("/api", api =>
            {
                // register Web API with this path
                api.UseWebApi(config);
            });
        }
    }
}