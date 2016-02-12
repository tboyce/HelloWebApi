namespace HelloWebApi.Entities
{
    /// <summary>
    ///     This is a greeting entity. Typically entities would be defined in a separate project.
    /// </summary>
    public class Greeting
    {
        public int Id { get; set; }

        public string Message { get; set; }
    }
}