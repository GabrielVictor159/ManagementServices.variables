using FluentValidation;
using ManagementServices.variables.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables.Domain.Validators
{
    public class EnvVariableValidator : AbstractValidator<EnvVariable>
    {
        public EnvVariableValidator() 
        {
            RuleFor(e => e.Key)
                .NotEmpty()
                .NotNull()
                .WithMessage("key property cannot be null or empty");
        }
    }
}
