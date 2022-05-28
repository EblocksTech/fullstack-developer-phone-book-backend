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
    }
}
