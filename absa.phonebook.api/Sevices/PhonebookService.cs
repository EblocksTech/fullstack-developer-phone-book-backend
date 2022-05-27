using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Sevices
{
    /// <inheritdoc/>
    public class PhonebookService : IPhonebookService
    {
        /// <inheritdoc/>
        public Task<bool> CreatePhonebook(Phonebook phonebook)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<Phonebook>> GetPhonebooks()
        {
            throw new NotImplementedException();
        }
    }
}
