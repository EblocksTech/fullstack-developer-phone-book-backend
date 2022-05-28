using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Stores
{
    /// <inheritdoc/>
    public class EntryStore : IEntryStore
    {
        /// <inheritdoc/>
        public async Task<bool> CreateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<Entry>> GetAllEntries()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<Entry> GetEntryByNumber(string number)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
