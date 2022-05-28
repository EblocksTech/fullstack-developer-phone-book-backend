using absa.phonebook.api.Data;
using absa.phonebook.api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Stores
{    
    /// <inheritdoc/>
    public class EntryStore : IEntryStore
    {
        /// <summary>
        ///     A <see cref="PhonebookContext"/> representing the database context.
        /// </summary>
        private readonly PhonebookContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntryStore"/> class
        /// </summary>
        public EntryStore(PhonebookContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateEntry(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
            var res = await Save();

            if (res == 0) return false;

            return true;
        }

        /// <inheritdoc/>
        public async Task<List<Entry>> GetAllEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Entry> GetEntryByNumber(string number)
        {
            return await _context.Entries.FirstOrDefaultAsync(x => x.Number == number);
        }

        /// <inheritdoc/>
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();            
        }
    }
}
