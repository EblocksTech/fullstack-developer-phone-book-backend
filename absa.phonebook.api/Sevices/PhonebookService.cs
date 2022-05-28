using absa.phonebook.api.Data.Models;
using absa.phonebook.api.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Sevices
{
    /// <inheritdoc/>
    public class PhonebookService : IPhonebookService
    {
        /// <summary>
        ///      A <see cref="PhonebookStore"/> representing the phonebook store to be called.
        /// </summary>
        private readonly IPhonebookStore _store;

        /// <summary>
        ///     Initialise an  instance of the <see cref="PhonebookService"/>  class.
        /// </summary>
        public PhonebookService(IPhonebookStore store)
        {
            _store = store;
        }
        
        /// <inheritdoc/>
        public async Task<bool> CreatePhonebook(Phonebook phonebook)
        {
            var list = await _store.GetPhonebooks();

            var obj = list.Find(x => (x.Name == phonebook.Name));

            if (obj != null) return false;

            return await _store.CreatePhonebook(phonebook);
        }

        /// <inheritdoc/>
        public async Task<List<Phonebook>> GetPhonebooks()
        {
            return await _store.GetPhonebooks();
        }
    }
}
