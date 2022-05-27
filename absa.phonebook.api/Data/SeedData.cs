using absa.phonebook.api.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Data
{
    /// <summary>
    ///     Provides seed data for the database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SeedData
    {
        /// <summary>
        ///     A <see cref="Guid"/> representing the id of the phonebook to be seeded. 
        /// </summary>
        private static Guid generalId = Guid.Parse("dca21998-eeab-4291-aae2-44a7b5e8ff03");

        /// <summary>
        ///     Creates and then returns a phonebook. 
        /// </summary>
        /// <returns>
        ///     A <see cref="Phonebook"/> representing the phonebook to seed.
        /// </returns>
        public static Phonebook SeedPhonebook()
        {
            return new Phonebook() 
            {
                Id = generalId,
                Name = "General",
            };
        }

        /// <summary>
        ///     Creates and then returns list of entry.
        /// </summary>
        /// <returns>
        ///     A <see cref="List{Entry}<>"/> representing the list of entries to seed.
        /// </returns>
        public static  List<Entry> SeedEntries()
        {
            return new List<Entry>()
            {
                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mom",
                    Number = "081-704-6758",
                    PhonebookId = generalId
                },

                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dad",
                    Number = "081-365-8532",
                    PhonebookId = generalId
                },

                new Entry()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mr D",
                    Number = "011-342-1720",
                    PhonebookId = generalId
                }
            };
        }
    }
}
