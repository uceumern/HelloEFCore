using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

namespace uuf.PersonManagement.Data.EfCore
{
    public class EfRepository : IRepository
    {
        private readonly EFContext _context = new EFContext();

        public void Add<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Set<T>().Update(entity);
        }
    }
}
