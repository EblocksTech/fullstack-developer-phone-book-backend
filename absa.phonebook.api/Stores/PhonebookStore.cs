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
    public class PhonebookStore : IPhonebookStore
    {
        /// <summary>
        ///      A <see cref="PhonebookContext"/> representing the database context.
        /// </summary>
        private readonly PhonebookContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhonebookStore"/> class
        /// </summary>
        public PhonebookStore(PhonebookContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<bool> CreatePhonebook(Phonebook phonebook)
        {
            await _context.Phonebooks.AddAsync(phonebook);
            var res = await Save();

            if (res == 0) return false;

            return true;
        }

        /// <inheritdoc/>
        public async Task<Phonebook> GetPhonebookById(Guid id)
        {
            return await _context.Phonebooks.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task<List<Phonebook>> GetPhonebooks()
        {
            return await _context.Phonebooks.ToListAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
