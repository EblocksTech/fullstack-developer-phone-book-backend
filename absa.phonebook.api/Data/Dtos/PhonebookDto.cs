using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Data.Dtos
{
    /// <summary>
    ///     Represents the a phonebook data transfer object for storing and verifying a new phonebook. 
    /// </summary>
    public class PhonebookDto
    {       
        /// <summary>
        ///       A <see cref="String"/> reperesenting the name in the dto.  
        /// </summary>
        public String Name { get; set; }
    }
}
