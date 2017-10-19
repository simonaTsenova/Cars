using Cars.Data.Contracts;
using Cars.Models;
using System.Data.Entity;

namespace Cars.Data
{
    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext()
            : base("LocalCarsDbConnection")
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public static CarsDbContext Create()
        {
            return new CarsDbContext();
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void Add<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
