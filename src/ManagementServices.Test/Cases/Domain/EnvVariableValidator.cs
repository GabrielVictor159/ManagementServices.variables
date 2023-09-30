using FluentAssertions;
using ManagementServices.Test.Builders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManagementServices.Test.Cases.Domain
{
    public class EnvVariableValidator
    {
        [Fact]
        public void ShouldSucess()
        {
            EnvVariableBuilder.New().Build().IsValid.Should().BeTrue();
        }
        [Fact]
        public void ShouldFailureInvalidKey()
        {
            EnvVariableBuilder.New().WithKey("").Build().IsValid.Should().BeFalse();
        }
    }
}
