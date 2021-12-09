using uuf.PersonManagement.Data.EfCore;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

namespace uuf.PersonManagement.Logic
{
    public class Core
    {
        public IRepository Repository { get; } = new EfRepository();

        //private IRepository _repository;

        // dependency inversion: let caller provide IRepository implementation
        //public Core(IRepository repository)
        //{

        //}

        // FOO

        public IEnumerable<Customer> GetCustomersThatHaveBirthdayThatMonth(int month)
        {
            return Repository.GetAll<Customer>().Where(x => x.BirthDate.Month == month);
        }

    }
}