using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GenericRepository<T>:IRepository<T> where T : class
    {
        private TestContext db;

        public GenericRepository(TestContext context)
        {
            db = context;
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T item = db.Set<T>().Find(id);
            if (item != null)
                db.Set<T>().Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
