using absa.phonebook.api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Data
{
    /// <summary>
    ///     Provides method to seed data and sets up the database sets.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PhonebookContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhonebookContext"/> class
        /// </summary>
        /// <param name="options">
        ///      A <see cref="DbContextOptions"/> of context <see cref="PhonebookContext"/> options.
        /// </param>
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options)
        {}

        /// <summary>
        ///     A <see cref="DbSet"/> of type <see cref="Phonebook"/> representing the phonebook database set.
        /// </summary>
        public virtual DbSet<Phonebook> Phonebooks { get; set; }

        /// <summary>
        ///     A <see cref="DbSet"/> of type <see cref="Entry"/> representing the entry database set.
        /// </summary>
        public virtual DbSet<Entry> Entries { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);         
        }
    }
}
