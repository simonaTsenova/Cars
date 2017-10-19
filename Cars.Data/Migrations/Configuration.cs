namespace Cars.Data.Migrations
{
    using Cars.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Cars.Data.CarsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CarsDbContext context)
        {
            this.SeedOwners(context);
            context.SaveChanges();
            this.SeedCarModels(context);
            context.SaveChanges();
            this.SeedCars(context);
            context.SaveChanges();
        }

        private void SeedOwners(CarsDbContext context)
        {
            if (!context.Owners.Any())
            {
                var owners = new Owner[]
                {
                    new Owner("Georgi", "Georgiev"),
                    new Owner("Ivan", "Ivanov"),
                    new Owner("Petar", "Petrov")
                };

                foreach (var owner in owners)
                {
                    context.Owners.Add(owner);
                }
            }
        }

        private void SeedCarModels(CarsDbContext context)
        {
            if (!context.CarModels.Any())
            {
                var carModels = new CarModel[]
                {
                    new CarModel("Model 1"),
                    new CarModel("Model 2")
                };

                foreach (var carModel in carModels)
                {
                    context.CarModels.Add(carModel);
                }
            }
        }

        private void SeedCars(CarsDbContext context)
        {
            if (!context.Cars.Any())
            {
                var cars = new Car[]
                {
                    new Car("Car 1", context.Owners.First(o => o.ID == 1), context.CarModels.First(m => m.ID == 1)),
                    new Car("Car 2", context.Owners.First(o => o.ID == 3), context.CarModels.First(m => m.ID == 1)),
                    new Car("Car 3", context.Owners.First(o => o.ID == 2), context.CarModels.First(m => m.ID == 1)),
                    new Car("Car 4", context.Owners.First(o => o.ID == 1), context.CarModels.First(m => m.ID == 2)),
                    new Car("Car 5", context.Owners.First(o => o.ID == 2), context.CarModels.First(m => m.ID == 1)),
                    new Car("Car 6", context.Owners.First(o => o.ID == 1), context.CarModels.First(m => m.ID == 2))
                };

                foreach (var car in cars)
                {
                    context.Cars.Add(car);
                }
            }
        }
    }
}
