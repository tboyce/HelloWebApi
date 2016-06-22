using System.Linq;
using HelloWebApi.Console.Greetings;

namespace HelloWebApi.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new GreetingsClient();
            var greetings = client.Greetings.Get();
            System.Console.WriteLine(greetings.First().Message);
            System.Console.ReadKey();
        }
    }
}