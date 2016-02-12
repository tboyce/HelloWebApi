using System.Web.Http;
using Owin;

namespace HelloWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();

            configuration.Routes.MapHttpRoute(
                name: "Default Route",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );


            appBuilder.UseWebApi(configuration);
        }
    }
}