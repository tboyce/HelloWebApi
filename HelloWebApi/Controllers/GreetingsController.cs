using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using HelloWebApi.Models;
using HelloWebApi.Repositories;

namespace HelloWebApi.Controllers
{
    /// <summary>
    ///     A Web API controller representing the greetings resource.
    ///     Resources are the building blocks of a REST API.
    ///     You can implement whichever HTTP verbs make sense for your use case.
    ///     Web API will automatically route incoming HTTP requests by matching the verb on the request to the attributes on the methods below.
    /// </summary>
    public class GreetingsController : ApiController
    {
        private readonly IGreetingRepository _greetingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        ///     This is dependency injection. We specify interfaces to be injected into the constructor.
        ///     Because we registered Unity with Web API as a dependency resolver, it knows to ask Unity for dependencies when creating controller instances.
        /// </summary>
        public GreetingsController(IGreetingRepository greetingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _greetingRepository = greetingRepository;
        }

        /// <summary>
        ///     Get all greetings.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            // get all greetings from the repository
            var greetings = _greetingRepository.GetAll();
            // map from the entity to the DTO
            var result = _mapper.Map<IEnumerable<Greeting>>(greetings);
            // return it
            return Ok(result);
        }

        /// <summary>
        ///     Get a specific greeting.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            // get the greeting from the repository
            var greeting = _greetingRepository.Get(id);
            if (greeting != null)
            {
                // map from the entity to the DTO
                var result = _mapper.Map<Greeting>(greeting);
                // return it
                return Ok(result);
            }
            return NotFound();
        }

        /// <summary>
        ///     Add a new greeting.
        /// </summary>
        [HttpPost]
        public void Add([FromBody] Greeting greeting)
        {
            // map from the DTO to the entity
            var entity = _mapper.Map<Entities.Greeting>(greeting);
            // add to the repository
            _greetingRepository.Add(entity);
        }

        /// <summary>
        ///     Delete a greeting.
        /// </summary>
        [HttpDelete]
        public void Delete(int id)
        {
            // delete from the repository
            _greetingRepository.Delete(id);
        }
    }
}
