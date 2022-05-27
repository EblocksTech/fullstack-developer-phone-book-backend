using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace absa.phonebook.api.Data.Models
{
    /// <summary>
    ///     Represents one entry in an phonebook in absa system
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Entry
    {
        /// <summary>
        ///     Gets or sets a <see cref="Guid"/> representing the entry unique identifier.
        /// </summary>
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="String"/> representing the entry name.
        /// </summary>
        [DataMember(Name = "name")]
        public String Name { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="String"/> representing the unique entry number.
        /// </summary>
        [DataMember(Name = "number")]
        public String Number { get; set; }


        /// <summary>
        ///     Gets or sets a <see cref="Phonebook"/> that the entry belongs to.
        /// </summary>
        [DataMember(Name = "phonebook")]
        public Phonebook Phonebook { get; set; }
    }
}
