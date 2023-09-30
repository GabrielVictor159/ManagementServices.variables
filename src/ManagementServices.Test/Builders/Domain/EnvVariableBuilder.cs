using ManagementServices.variables.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.Test.Builders.Domain
{
    public class EnvVariableBuilder
    {
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
        public static EnvVariableBuilder New()
        {
            return new EnvVariableBuilder()
            { 
            Key = Guid.NewGuid().ToString(),
            Value = "Value Test"
            };
        }
        public EnvVariable Build()
        {
            return new EnvVariable() { Key = Key, Value = Value};
        }
        public EnvVariableBuilder WithKey(string value)
        {
            Key = value;
            return this;
        }
        public EnvVariableBuilder WithValue(string value)
        {
            Value = value;
            return this;
        }
    }
}
