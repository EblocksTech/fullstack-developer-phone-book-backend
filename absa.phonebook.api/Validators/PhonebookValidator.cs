using absa.phonebook.api.Data.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace absa.phonebook.api.Validators
{
    /// <summary>
    ///     Provides validation rules to validate the <see cref="PhonebookDto"/> class.
    /// </summary>
    public class PhonebookValidator : AbstractValidator<PhonebookDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhonebookValidator"/> class.
        /// </summary>
        public PhonebookValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
