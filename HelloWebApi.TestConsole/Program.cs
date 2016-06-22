using System;
using System.Linq;
using HelloWebApi.Entities;

namespace HelloWebApi.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client.GreetingsClient(new Uri("http://localhost:28065"));
            var greetings = client.GetGreetingsAsync().Result.ToList();
            Console.WriteLine(greetings.Count() + " greetings found");
            var greeting = client.GetGreetingAsync(greetings.First().Id).Result;
            Console.WriteLine(greeting.Message);
            var uri = client.AddGreetingAsync(new Greeting {Message = "Test"}).Result;
            greeting = client.GetGreetingAsync(uri).Result;
            Console.WriteLine(greeting.Message);
            greetings = client.GetGreetingsAsync().Result.ToList();
            Console.WriteLine(greetings.Count() + " greetings found");
            client.DeleteGreetingAsync(greeting.Id).Wait();
            greetings = client.GetGreetingsAsync().Result.ToList();
            Console.WriteLine(greetings.Count() + " greetings found");
        }
    }
}
