using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Stores
{
    /// <summary>
    ///      Provides methods for accessing the data in the phonebook table.
    /// </summary>
    public interface IPhonebookStore
    {
        /// <summary>
        ///      Provides a method that returns a single phonebook.
        /// </summary>
        /// <param name="Id">
        ///     A <see cref="Guid"/> that represents the id of the phonebook.
        /// </param>
        /// <returns>
        ///     A <see cref="Phonebook"/> representing the phonebook.
        /// </returns>
        public Task<Phonebook> GetPhonebookById(Guid Id);

        /// <summary>
        ///     Provides a method that returns all phonebooks.         
        /// </summary>
        /// <returns>
        ///      A <see cref="List{Phonebook}"/> representing the phonebook. 
        /// </returns>
        public Task<List<Phonebook>> GetPhonebooks();

        /// <summary>
        ///      Provides a method that creates a phonebook.       
        /// </summary>
        /// <param name="phonebook">
        ///     A <see cref="Phonebook"/> representing the phonebook to be created.
        /// </param>
        /// <returns>
        ///     A <see cref="bool"/> representing the result of the operation.
        /// </returns>
        public Task<bool> CreatePhonebook(Phonebook phonebook);

        /// <summary>
        ///     Saves all model changes to database.      
        /// </summary>
        /// <returns>
        ///     An <see cref="int"/> representing the async save operation. The task result contains the number of entries written to the database.
        /// </returns>
        public Task<int> Save();
    }
}
