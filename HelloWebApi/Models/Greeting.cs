using System.ComponentModel.DataAnnotations;

namespace HelloWebApi.Models
{
    /// <summary>
    /// This is a greeting DTO.
    /// </summary>
    public class Greeting
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Message { get; set; }
    }
}