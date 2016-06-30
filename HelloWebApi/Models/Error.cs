using System;

namespace HelloWebApi.Models
{
    public class Error
    {
        public string Message { get; set; }

        public Guid RequestId { get; set; }
    }
}