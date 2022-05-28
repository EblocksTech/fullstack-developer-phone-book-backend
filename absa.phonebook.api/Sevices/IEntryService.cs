using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Sevices
{
    /// <summary>
    ///     Represents a entry service in the absa system.      
    /// </summary>
    public interface IEntryService
    {
        /// <summary>
        ///     Provides a method that returns all entries.
        /// </summary>
        /// <returns>
        ///     A <see cref="List{Entry}"/> that represents all entries.
        /// </returns>
        public Task<List<Entry>> GetAllEntries();

        /// <summary>
        ///     Provides a method that creates a new phonebook.
        /// </summary>
        /// <param name="entry">
        ///     A <see cref="Entry"/> that represents the entry to be created.
        /// </param>
        /// <returns>
        ///     a <see cref="bool"/> that represents whether the operation was a success or not.
        /// </returns>
        public Task<bool> CreateEntry(Entry entry);
    }
}
