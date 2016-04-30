using System.Web.Http;
using AutoMapper;
using HelloWebApi.Configuration;
using HelloWebApi.Repositories;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace HelloWebApi
{
    /// <summary>
    ///     Unity is a dependency injection container.
    ///     This class configures Unity and registers it with Web API.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration configuration)
        {
            // create a Unity container
            var container = new UnityContainer();

            // create an AutoMapper configuration
            var mapperConfiguration = DtoMapperConfiguration.Build();

            // register dependencies by convention
            // this will register all classes with matching interfaces in loaded assemblies (in a real world app you might want to be more explicit on assemblies to scan)
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            // register a dependency, in this case a mapping from the greeting repository interface to the greeting repository implementation
            // convention based registraton above will have already done this, shown explicitly here for demo purposes
            container.RegisterType<IGreetingRepository, GreetingRepository>();

            // here we are registering AutoMapper and controlling how Unity creates the instance by specifying an injection factory
            container.RegisterType<IMapper>("dtoMapper", new InjectionFactory(x => mapperConfiguration.CreateMapper()));

            // Web API has built in support for dependency injection by setting the DependencyResolver property on the configuration object
            // here we register the Unity container with Web API as a dependency resolver
            configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}