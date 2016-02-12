using System.Web.Http;
using AutoMapper;
using HelloWebApi.Repositories;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace HelloWebApi
{
    /// <summary>
    ///     Unity is a dependency injection container.
    ///     This class configures the Unity and registers it with Web API.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration configuration)
        {
            // create a Unity container
            var container = new UnityContainer();

            // create an AutoMapper configuration
            var config = AutomapperConfig.Configure();

            // register a dependency - this is the most common way to register (this can actually be done by convention, but done explicitly here for demo purposes)
            container.RegisterType<IGreetingRepository, GreetingRepository>();
            // here we are registering AutoMapper and controlling how Unity creates the instance by specifying an injection factory
            container.RegisterType<IMapper>(new InjectionFactory(x => config.CreateMapper()));

            // Web API has built in support for dependency injection by setting the DependencyResolver property on the configuration object
            // here we register the Unity container with Web API as a dependency resolver
            configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}