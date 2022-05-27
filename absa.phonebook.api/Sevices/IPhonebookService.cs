using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Sevices
{
    /// <summary>
    ///     Represents a phonebook service in the absa system.      
    /// </summary>
    public interface IPhonebookService
    {
        /// <summary>
        ///     Provides a method that returns all phonebooks.
        /// </summary>
        /// <returns></returns>
        public Task<List<Phonebook>> GetPhonebooks();

        /// <summary>
        ///     Provides a method that creates a new phonebook.
        /// </summary>
        /// <param name="phonebook">
        ///     A <see cref="Phonebook"/> that represents the phonebook to be created.
        /// </param>
        /// <returns>
        ///     a <see cref="bool"/> that represents whether the operation was a success or not.
        /// </returns>
        public Task<bool> CreatePhonebook(Phonebook phonebook);
        
    }
}
