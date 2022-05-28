using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Stores
{
    /// <summary>
    ///     Provides methods for accessing the data in the entry table.
    /// </summary>
    public interface IEntryStore
    {
        /// <summary>
        ///     Return all <see cref="Entry"/> in the entries table.
        /// </summary>
        /// <returns>
        ///     A <see cref="Lazy{Entry}"/> representing all of the entries.
        /// </returns>
        public Task<List<Entry>> GetAllEntries();

        /// <summary>
        ///     Inserts a new <see cref="Entry"/> into the entries table.
        /// </summary>
        /// <returns>
        ///     A <see cref="bool"/> representing the result of the operation.
        /// </returns>
        public Task<bool> CreateEntry(Entry entry);

        /// <summary>
        ///     Return a <see cref="Entry"/> in the entries table.
        /// </summary>
        /// <param name="number">
        ///     Represents the <see cref="String"/> of the entry.
        /// </param>
        /// <returns>
        ///     A <see cref="Entry"/>.
        /// </returns>
        public Task<Entry> GetEntryByNumber(String number);

        /// <summary>
        ///     Saves all model changes to database.      
        /// </summary>
        /// <returns>
        ///     An <see cref="int"/> representing the async save operation. The task result contains the number of entries written to the database.
        /// </returns>
        public Task<int> Save();
    }
}
