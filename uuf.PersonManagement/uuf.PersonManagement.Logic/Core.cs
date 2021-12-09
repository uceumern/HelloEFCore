using uuf.PersonManagement.Data.EfCore;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

namespace uuf.PersonManagement.Logic
{
    public class Core
    {
        private IRepository _repository = new EfRepository();

        //private IRepository _repository;

        // dependency inversion: let caller provide IRepository implementation
        //public Core(IRepository repository)
        //{

        //}

        public IEnumerable<Customer> GetCustomersThatHaveBirthdayThatMonth(int month)
        {
            return _repository.GetAll<Customer>().Where(x => x.BirthDate.Month == month);
        }

    }
}