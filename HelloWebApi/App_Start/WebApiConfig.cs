using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using HelloWebApi.Handlers;

namespace HelloWebApi
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // use attribute based routing
            config.MapHttpAttributeRoutes();

            // replace default exception handler with Enterprise Library exception handler
            config.Services.Replace(typeof(IExceptionHandler), new EnterpriseLibraryExceptionHandler());
        }
    }
}