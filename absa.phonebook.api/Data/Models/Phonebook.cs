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
    ///     Represents a Phonebook in the absa system.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Phonebook
    {
        /// <summary>
        ///     Gets or sets a <see cref="Guid"/> representing the phonebook unique identifier.
        /// </summary>
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id")]        
        public Guid Id { get; set; }


        /// <summary>
        ///     Gets or sets a <see cref="String"/> representing the phonebook name.
        /// </summary>
        [DataMember(Name = "name")]
        public String Name { get; set; }
    }
}
