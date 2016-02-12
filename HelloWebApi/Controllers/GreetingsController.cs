using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using HelloWebApi.Models;
using HelloWebApi.Repositories;

// A convention in ASP.NET is to put your API controllers in a Controllers namespace. Web API will find them automatically.
namespace HelloWebApi.Controllers
{
    /// <summary>
    ///     A controller representing the greeting resource. Resources are the building blocks of a REST API.
    /// </summary>
    public class GreetingsController : ApiController
    {
        private readonly IGreetingRepository _greetingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        ///     This is dependency injection. We specify interfaces to be injected into the constructor and Unity takes care of
        ///     creating an instance and passing it in.
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