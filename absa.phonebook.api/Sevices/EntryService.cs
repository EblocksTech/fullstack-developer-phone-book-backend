using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Sevices
{
    /// <inheritdoc/>
    public class EntryService : IEntryService
    {
        /// <summary>
        ///     A <see cref="IEntryStore"/> representing the entry store to be called.
        /// </summary>
        private readonly IEntryStore _store;

        /// <summary>
        ///      A <see cref="IPhonebookStore"/> representing the entry store to be called.
        /// </summary>
        public IPhonebookStore _phonebookStore { get; }

        /// <summary>
        ///     Initialise an  instance of the<see cref="EntryService"/> class.
        /// </summary>
        /// <param name="store">
        ///      A <see cref="IEntryStore"/> representing the entry store to be called.
        /// </param>
        public EntryService(IEntryStore store, IPhonebookStore phonebookStore)
        {
            _store = store;
            _phonebookStore = phonebookStore;
        }

        /// <inheritdoc/>
        public async Task<bool> CreateEntry(Entry newEntry)
        {
            var phonebook = await _phonebookStore.GetPhonebookById(newEntry.PhonebookId);

            if (phonebook == null) return false;

            var entry = await _store.GetEntryByNumber(newEntry.Number);

            if (entry != null) return false;

            return true;
        }

        /// <inheritdoc/>
        public async Task<List<Entry>> GetAllEntries()
        {
            return await  _store.GetAllEntries();
        }
    }
}
