using System.Web.Http;

namespace HelloWebApi.Controllers
{
    public class GreetingsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new[] {"Hello world"});
        }
    }
}