using Microsoft.EntityFrameworkCore;
using ShopsPages.Models;

namespace ShopsPages.DAL
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ShopsContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(ShopsContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual bool Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T? GetById(int? id)
        {
            return this.dbSet.Find(id);
        }

        public virtual bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
