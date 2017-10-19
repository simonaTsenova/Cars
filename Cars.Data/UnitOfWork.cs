using Cars.Data.Contracts;
using System;

namespace Cars.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarsDbContext dbContext;

        public UnitOfWork(ICarsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Db context cannot be null");
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
