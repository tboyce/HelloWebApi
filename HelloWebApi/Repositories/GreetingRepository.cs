using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebApi.Entities;

namespace HelloWebApi.Repositories
{
    /// <summary>
    ///     This is the implementation of the greeting repository interface.
    ///     It simply uses an in-memory List to store data.
    ///     In a real application this would probably use Entity Framework to access a database.
    /// </summary>
    public class GreetingRepository : IGreetingRepository
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
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Must be a positive number.");
            }

            return _greetings.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        ///     Add a greeting.
        /// </summary>
        public void Add(Greeting greeting)
        {
            // fake an auto-incrementing database identity
            greeting.Id = _greetings.Max(x => x.Id) + 1;
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
                    Id = 1,
                    Message = "Hello world"
                };
                _greetings = new List<Greeting> {greeting};
            }
        }

        /// <summary>
        ///     Update a greeting
        /// </summary>
        public void Update(Greeting greeting)
        {
            var existing = Get(greeting.Id);
            if (existing == null)
            {
                throw new InvalidOperationException("Existing greeting not found.");
            }
            existing.Message = greeting.Message;
        }
    }
}