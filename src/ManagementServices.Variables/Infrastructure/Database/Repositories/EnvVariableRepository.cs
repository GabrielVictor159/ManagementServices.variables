using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagementServices.variables.Infrastructure.ConvertProfile;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ManagementServices.variables.Domain;

namespace ManagementServices.variables.Infrastructure.Database.Repositories
{
    public class EnvVariableRepository<Context> where Context : DbContext, new()
    {
        public int Add(Domain.Models.EnvVariable env)
        {
            using var context = new Context();  
            if (!env.IsValid)
            {
                throw new ManagementServicesVariablesException(env.ValidationResult!.ToString());
            }
            context.Set<Entities.EnvVariable>().Add(ConvertProfiles.ConvertEnvVariable(env));
            return context.SaveChanges();
        }


        public int AddRange(List<Domain.Models.EnvVariable> envs)
        {
            using var context = new Context();
            foreach (var env in envs) 
            {
                if (!env.IsValid)
                {
                    throw new ManagementServicesVariablesException(env.ValidationResult!.ToString());
                }
            }
            var entities = new List<Entities.EnvVariable>();
            foreach (var env in envs)
            {
                entities.Add(ConvertProfiles.ConvertEnvVariable(env));
            }
            context.Set<Entities.EnvVariable>().AddRange(entities);
            return context.SaveChanges();
        }


        public Domain.Models.EnvVariable? Get(string Key)
        {
            using var context = new Context();
            var entity = context.Set<Entities.EnvVariable>().Find(Key);
            if (entity != null)
            {
                return ConvertProfiles.ConvertEnvVariable(entity);
            }
            else
            {
                return null;
            }
        }


        public List<Domain.Models.EnvVariable> GetByFilter(Expression<Func<Entities.EnvVariable, bool>> expression, int page, int pageSize)
        {
            using var context = new Context();
            var query = context.Set<Entities.EnvVariable>().Where(expression);
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            var entities = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var domainList = new List<Domain.Models.EnvVariable>();
            entities.ForEach(entity =>
            { 
                domainList.Add(ConvertProfiles.ConvertEnvVariable(entity));
            });
            return domainList;
        }

        public int Update(Domain.Models.EnvVariable env)
        {
            using var context = new Context();
            var entity = ConvertProfiles.ConvertEnvVariable(env);
            context.Set<Entities.EnvVariable>().Update(entity);
            return context.SaveChanges();
        }
        public int Delete(string key) 
        {
            using var context = new Context();
            int result = 0;
            var entity = context.Set<Entities.EnvVariable>().Find(key);
            if (entity!=null)
            {
                context.Set<Entities.EnvVariable>().Remove(entity);
                result = context.SaveChanges();
            }
            return result;
        }
        public int DeleteRange(List<string> keys)
        {
            using var context = new Context();
            int result = 0;
            foreach (var id in keys)
            {
                var entity = context.Set<Entities.EnvVariable>().Find(id);

                if (entity != null)
                {
                    context.Set<Entities.EnvVariable>().Remove(entity);
                    result += context.SaveChanges();
                }
            }

            return result;
        }
    }
}
