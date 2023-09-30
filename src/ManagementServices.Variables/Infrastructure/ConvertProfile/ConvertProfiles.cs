using ManagementServices.variables.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables.Infrastructure.ConvertProfile
{
    public static class ConvertProfiles
    {
        public static Database.Entities.EnvVariable  ConvertEnvVariable(Domain.Models.EnvVariable entity)
        {
            var result = new Database.Entities.EnvVariable { Key = entity.Key, Value = entity.Value };
            return result;
        }
        public static Domain.Models.EnvVariable ConvertEnvVariable(Database.Entities.EnvVariable entity)
        {
            var result = new Domain.Models.EnvVariable { Key = entity.Key, Value = entity.Value };
            return result;
        }
    }
}
