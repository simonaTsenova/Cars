using System.Linq;
using Cars.Data.Contracts;
using System;

namespace Cars.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ICarsDbContext dbContext;

        public Repository(ICarsDbContext dbContext)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("Db context cannot be null.");
            }

            this.dbContext = dbContext;
        }

        public IQueryable<T> All
        {
            get
            {
                return this.dbContext.DbSet<T>();
            }
        }

        public T GetById(object id)
        {
            return this.dbContext.DbSet<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.Delete(entity);
        }

        public void Update(T entity)
        {
            this.dbContext.Update(entity);
        }
    }
}
