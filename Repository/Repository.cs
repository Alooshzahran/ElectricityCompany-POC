using Entity;
using Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseGet
    {
        public MyDbContext _myDbContext { get; set; }
        public Repository(MyDbContext myDbContext) 
        {
           _myDbContext = myDbContext;
        }
        public T Create(T entity)
        {
            return _myDbContext.Set<T>().Add(entity).Entity;
        }

        public bool Delete(T Entity)
        {
            _myDbContext.Set<T>().Remove(Entity);
            return true;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _myDbContext.Set<T>().Where(e => e.IsDeleted == false).Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _myDbContext.Set<T>().Where(e => e.IsDeleted == false).ToList();
        }

        public T GetByID(int id)
        {
            return _myDbContext.Set<T>().FirstOrDefault(e => e.Id == id && e.IsDeleted == false);
        }

        public T Update(T entity)
        {
            return _myDbContext.Set<T>().Update(entity).Entity;
        }
    }
}
