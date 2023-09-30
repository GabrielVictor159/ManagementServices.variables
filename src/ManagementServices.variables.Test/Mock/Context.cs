
using ManagementServices.variables.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.Test.Mock
{
    public class Context : DbContext
    {
        public DbSet<EnvVariable> envVariables => Set<EnvVariable>();   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseInMemoryDatabase("ManagementServicesVariablesInMemory");

        }
    }
}
