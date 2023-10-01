using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServices.variables.Application.Interfaces
{
    public interface IEnvVariableRepository
    {
        int Add(Domain.Models.EnvVariable env);
        int AddRange(List<Domain.Models.EnvVariable> envs);
        Domain.Models.EnvVariable? Get(string Key);
        List<Domain.Models.EnvVariable> GetByFilter(Expression<Func<Infrastructure.Database.Entities.EnvVariable, bool>> expression, int page, int pageSize);
        int Update(Domain.Models.EnvVariable env);
        int Delete(string key);
        int DeleteRange(List<string> keys);
    }
}
