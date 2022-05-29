using absa.phonebook.api.Data.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Validators
{
    /// <summary>
    ///     Provides validation rules to validate the <see cref="EntryDto"/> class.
    /// </summary>
    public class EntryValidator : AbstractValidator<EntryDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EntryValidator"/> class.
        /// </summary>
        public EntryValidator()
       {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhonebookId).NotEmpty();            
            RuleFor(x => x.Number).NotEmpty().Matches(@"^\d{3}-\d{3}-\d{4}$");
        }
    }
}
