using System.Collections.Generic;
using HelloWebApi.Entities;

namespace HelloWebApi.Repositories
{
    /// <summary>
    ///     This is the interface for the greeting repository.
    /// </summary>
    public interface IGreetingRepository
    {
        /// <summary>
        ///     Get all greetings.
        /// </summary>
        IEnumerable<Greeting> GetAll();

        /// <summary>
        ///     Get a specific greeting. Additional get methods could be added if there is another way that greetings might be
        ///     identified.
        /// </summary>
        Greeting Get(int id);

        /// <summary>
        ///     Add a greeting.
        /// </summary>
        void Add(Greeting greeting);

        /// <summary>
        ///     Delete a greeting
        /// </summary>
        void Delete(int id);

        /// <summary>
        ///     Update a greeting
        /// </summary>
        void Update(Greeting entity);
    }
}