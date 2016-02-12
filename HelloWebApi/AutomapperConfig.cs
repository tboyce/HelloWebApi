using AutoMapper;

namespace HelloWebApi
{
    /// <summary>
    /// AutoMapper is used to map between entities and DTOs.
    /// This class builds an automapper configuration.
    /// </summary>
    public static class AutomapperConfig
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                // create DTO to entity mappings
                cfg.CreateMap<Models.Greeting, Entities.Greeting>();

                // create entity to DTO mappings
                cfg.CreateMap<Entities.Greeting, Models.Greeting>();
            });
        }
    }
}