using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelloWebApi.Entities;

namespace HelloWebApi.Client
{
    public class GreetingsClient
    {
        private readonly Uri _baseUri;

        private readonly List<MediaTypeFormatter> _formatters = new List<MediaTypeFormatter>
        {
            new JsonMediaTypeFormatter()
        };

        public GreetingsClient(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<IEnumerable<Greeting>> GetGreetingsAsync()
        {
            var client = GetHttpClient(_baseUri);
            var response = await client.GetAsync("api/greetings");
            return await response.Content.ReadAsAsync<IEnumerable<Greeting>>(_formatters);
        }

        public async Task<Greeting> GetGreetingAsync(int id)
        {
            var client = GetHttpClient(_baseUri);
            var response = await client.GetAsync("api/greeting/" + id);
            return await response.Content.ReadAsAsync<Greeting>(_formatters);
        }

        public async Task<Greeting> GetGreetingAsync(Uri uri)
        {
            var client = GetHttpClient(null);
            var response = await client.GetAsync(uri);
            return await response.Content.ReadAsAsync<Greeting>(_formatters);
        }

        public async Task<Uri> AddGreetingAsync( Greeting greeting)
        {
            var client = GetHttpClient(_baseUri);
            var response = await client.PostAsJsonAsync("api/greetings/", greeting);
            return response.Headers.Location;
        }

        public async Task DeleteGreetingAsync(int id)
        {
            var client = GetHttpClient(_baseUri);
            await client.DeleteAsync("api/greeting/" + id);
        }

        private HttpClient GetHttpClient(Uri baseUri)
        {
            var client = new HttpClient {BaseAddress = baseUri };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}