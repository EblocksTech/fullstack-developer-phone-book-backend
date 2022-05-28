using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Stores
{
    /// <inheritdoc/>
    public class PhonebookStore : IPhonebookStore
    {
        /// <inheritdoc/>
        public Task<Phonebook> GetPhonebookById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
