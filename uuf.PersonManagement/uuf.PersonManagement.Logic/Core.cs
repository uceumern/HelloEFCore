using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

namespace uuf.PersonManagement.Logic
{
    public class Core
    {
        //dependency inversion: let caller provide IRepository implementation
        //so that this assembly does not need to reference EfRepository (and EFCore, etc.)
        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public IRepository Repository { get; }

        public IEnumerable<Customer> GetCustomersThatHaveBirthdayThatMonth(int month)
        {
            return Repository.GetAll<Customer>().Where(x => x.BirthDate.Month == month);
        }

        public Employee GetEmployeeWithMostCustomers()
        {
            return Repository.GetAll<Employee>().OrderByDescending(x => x.Customers.Count).FirstOrDefault();
        }
    }
}