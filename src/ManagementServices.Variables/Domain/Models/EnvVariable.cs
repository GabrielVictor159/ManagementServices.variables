using ManagementServices.variables.Domain;
using ManagementServices.variables.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables.Domain.Models
{
    public class EnvVariable : Entity<EnvVariable,EnvVariableValidator>
    {
        public required string Key {get; init;}
        public required string Value { get; init;}

        public EnvVariable()
            : base( new EnvVariableValidator())
        {

        }
    }
}
