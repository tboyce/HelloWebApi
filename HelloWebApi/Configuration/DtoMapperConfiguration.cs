using AutoMapper;

namespace HelloWebApi.Configuration
{
    /// <summary>
    /// AutoMapper is used to map between entities and DTOs.
    /// This class builds an AutoMapper configuration.
    /// In this simple demo, both types have exactly the same properties,
    /// so all that has to be done is create a map from one type to another.
    /// AutoMapper can be used to do more complex mapping as well.
    /// </summary>
    public static class DtoMapperConfiguration
    {
        public static MapperConfiguration Build()
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