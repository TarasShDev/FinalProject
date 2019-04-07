using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public void Create(T obj)
        {
            db.Set<T>().Add(obj);
        }

        public void Delete(int id)
        {
            T item = db.Set<T>().Find(id);
            if (item != null)
                db.Set<T>().Remove(item);
        }

        public async Task<IEnumerable<T>> Find(Func<T, bool> predicate)
        {
            Task<IEnumerable<T>> task = Task.Run(() => db.Set<T>().AsNoTracking().Where(predicate));
            return await task;
        }

        public async Task<T> Get(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
