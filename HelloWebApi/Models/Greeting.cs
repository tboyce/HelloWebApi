// A convention in ASP.NET is to put your DTOs in a Models namespace.
namespace HelloWebApi.Models
{
    /// <summary>
    /// This is a greeting DTO.
    /// </summary>
    public class Greeting
    {
        public int Id { get; set; }

        public string Message { get; set; }
    }
}