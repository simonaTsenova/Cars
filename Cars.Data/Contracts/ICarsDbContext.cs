using System.Data.Entity;

namespace Cars.Data.Contracts
{
    public interface ICarsDbContext
    {
        IDbSet<TEntity> DbSet<TEntity>() where TEntity : class;

        void Add<TEntry>(TEntry entity)
            where TEntry : class;

        void Delete<TEntry>(TEntry entity)
            where TEntry : class;

        void Update<TEntry>(TEntry entity)
            where TEntry : class;

        int SaveChanges();
    }
}
