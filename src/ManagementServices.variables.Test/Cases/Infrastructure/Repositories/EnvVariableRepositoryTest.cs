using FluentAssertions;
using ManagementServices.variables.Domain.Models;
using ManagementServices.variables.Infrastructure.Database.Repositories;
using ManagementServices.Test.Builders.Domain;
using ManagementServices.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace ManagementServices.Test.Cases.Infrastructure.Repositories
{
    [UseAutofacTestFramework]
    public class EnvVariableRepositoryTest
    {
        private readonly EnvVariableRepository<Context> repository;
        public EnvVariableRepositoryTest
            (EnvVariableRepository<Context> repository)
        {
            this.repository = repository;
        }

        [Fact]
        public void ShouldSucessAdd()
        {
            repository.Add(EnvVariableBuilder.New().Build()).Should().Be(1);
        }

        [Fact]
        public void ShouldSucessAddRange()
        {
            repository.AddRange(new List<EnvVariable>(){ EnvVariableBuilder.New().Build()}).Should().Be(1);
        }

        [Fact]
        public void ShouldSucessGet()
        {
            var list = new List<EnvVariable>() { EnvVariableBuilder.New().Build() };
            repository.AddRange(list);
            repository.Get(list[0].Key).Should().NotBeNull();
        }

        [Fact]
        public void ShouldSucessGetByFilter()
        {
            var list = new List<EnvVariable>() { EnvVariableBuilder.New().Build() };
            repository.AddRange(list);
            repository.GetByFilter(e => e.Key == list[0].Key, 1, 10).Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ShouldSucessUpdate()
        {
            var list = new List<EnvVariable>() { EnvVariableBuilder.New().Build() };
            repository.AddRange(list);
            var newAttributes = EnvVariableBuilder.New().WithKey(list[0].Key).Build();
            repository.Update(newAttributes);
        }

        [Fact]
        public void ShouldSucessDelete() 
        {
            var list = new List<EnvVariable>() { EnvVariableBuilder.New().Build() };
            repository.AddRange(list);
            repository.Delete(list[0].Key).Should().Be(1);
        }

        [Fact]
        public void ShouldSucessDeleteRange()
        {
            var list = new List<EnvVariable>() { EnvVariableBuilder.New().Build() };
            repository.AddRange(list);
            var listIds = new List<string>();
            list.ForEach(e=> listIds.Add(e.Key));
            repository.DeleteRange(listIds).Should().Be(list.Count);
        }

    }
}
