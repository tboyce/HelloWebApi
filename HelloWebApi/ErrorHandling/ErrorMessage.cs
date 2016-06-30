using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using HelloWebApi.Models;

namespace HelloWebApi.ErrorHandling
{
    public class ErrorMessage : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;

        public ErrorMessage(HttpRequestMessage request)
        {
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var error = new Error
            {
                Message = "An error has occurred.",
                RequestId = _request.GetCorrelationId()
            };
            var response = _request.CreateResponse(HttpStatusCode.InternalServerError, error);
            return Task.FromResult(response);
        }
    }
}