using System;
using System.Collections.Generic;
using System.Linq;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;
using Xunit;

namespace uuf.PersonManagement.Logic.Tests
{
    /// <summary>
    /// manaual mock repository
    /// </summary>
    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Model.Entity
        {
            if (typeof(T) == typeof(Employee))
            {
                return new List<Employee>().Cast<T>();
            }
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Model.Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Model.Entity
        {
            throw new NotImplementedException();
        }
    }

    public class CoreTests
    {
        [Fact]
        public void GetGetEmployeeWithMostCustomers_Employees_empty()
        {
            var core = new Core(new TestRepository());
            var result = core.GetEmployeeWithMostCustomers();

            Assert.Null(result);
        }

        [Fact]
        public void GetGetEmployeeWithMostCustomers_2_Employees_results_Fred()
        {
            var core = new Core(new TestRepository());
            var result = core.GetEmployeeWithMostCustomers();
            Assert.Equal("Fred", result.Name);
        }

        [Fact]
        public void GetGetEmployeeWithMostCustomers_2_Employees_same_customer_count_results_Fred()
        {
            var core = new Core(new TestRepository());
            var result = core.GetEmployeeWithMostCustomers();
            Assert.Equal("Fred", result.Name);
        }
    }
}