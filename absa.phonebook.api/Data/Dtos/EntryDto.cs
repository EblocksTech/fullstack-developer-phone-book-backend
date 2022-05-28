using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Data.Dtos
{
    /// <summary>
    ///     Represents the a entry data transfer object for storing and verifying a new entry.
    /// </summary>
    public class EntryDto
    {
        /// <summary>
        ///      A <see cref="String"/> reperesenting the name in the dto.  
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///      A <see cref="String"/> reperesenting the number in the dto.  
        /// </summary>
        public String Number { get; set; }

        /// <summary>
        ///     A <see cref="Guid"/> reperesenting the phonebook id to which the entry will belong.
        /// </summary>
        public Guid PhonebookId { get; set; }
    }
}
