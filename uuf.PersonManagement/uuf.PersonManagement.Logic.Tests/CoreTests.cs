using Moq;
using System.Collections.Generic;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;
using Xunit;

namespace uuf.PersonManagement.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetGetEmployeeWithMostCustomers_Employees_empty()
        {
            // using manual mocked Repository
            var core = new Core(new TestRepository());
            var result = core.GetEmployeeWithMostCustomers();

            Assert.Null(result);
        }

        [Fact]
        public void GetGetEmployeeWithMostCustomers_2_Employees_results_Fred_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Employee>()).Returns(new List<Employee>()
            {
                new Employee() { Name = "Fred" , Customers = new List<Customer> { new Customer(), new Customer(), new Customer() } },
                new Employee() { Name = "Barney" , Customers = new List<Customer> { new Customer(), new Customer(), new Customer() } },
            });
            var core = new Core(mock.Object);
            var result = core.GetEmployeeWithMostCustomers();
            Assert.Equal("Fred", result.Name);

            // make sure mocked method was called once
            mock.Verify(x => x.GetAll<Employee>(), Times.Once);
        }
    }
}