using System.Collections.Generic;
using System.Linq;
using HelloWebApi.Entities;

namespace HelloWebApi.Repositories
{
    /// <summary>
    ///     This is the implementation of the greeting repository interface.
    /// </summary>
    internal class GreetingRepository : IGreetingRepository
    {
        private static List<Greeting> _greetings;

        public GreetingRepository()
        {
            SetDefaultData();
        }

        /// <summary>
        ///     Get all greetings.
        /// </summary>
        public IEnumerable<Greeting> GetAll()
        {
            return _greetings;
        }

        /// <summary>
        ///     Get a specific greeting. Additional get methods could be added if there is another way that greetings might be
        ///     identified.
        /// </summary>
        public Greeting Get(int id)
        {
            return _greetings.ElementAtOrDefault(id);
        }

        /// <summary>
        ///     Add a greeting.
        /// </summary>
        public void Add(Greeting greeting)
        {
            _greetings.Add(greeting);
        }

        /// <summary>
        ///     Delete a greeting
        /// </summary>
        public void Delete(int id)
        {
            var greeting = Get(id);
            if (greeting != null)
            {
                _greetings.Remove(greeting);
            }
        }

        /// <summary>
        ///     Sets some default data. This would normally be stored in a database.
        /// </summary>
        private void SetDefaultData()
        {
            if (_greetings == null)
            {
                var greeting = new Greeting
                {
                    Message = "Hello world"
                };
                _greetings = new List<Greeting> {greeting};
            }
        }
    }
}