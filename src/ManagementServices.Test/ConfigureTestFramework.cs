using Autofac;
using FluentAssertions.Common;
using ManagementServices.variables.Infrastructure.Database.Repositories;
using ManagementServices.Test.Mock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestFramework("ManagementServices.variables.Test.ConfigureTestFramework", "ManagementServices.variables.Test")]
namespace ManagementServices.Test
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink)
          : base(diagnosticMessageSink)
        {
          
            
        }
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(c => new Context()) 
                .As<Context>()
                .InstancePerLifetimeScope();
            builder.RegisterInstance(new EnvVariableRepository<Context>());

        }
    }
}
