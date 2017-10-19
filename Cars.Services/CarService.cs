using System.Collections.Generic;
using Cars.Models;
using Cars.Services.Contracts;
using Cars.Data.Contracts;
using System;
using System.Linq;

namespace Cars.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            if(carRepository == null)
            {
                throw new ArgumentNullException("Car repository cannot be null.");
            }

            this.carRepository = carRepository;
        }

        public IList<Car> GetByOwnerId(int ownerId)
        {
            var cars = this.carRepository.All
                .Where(c => c.OwnerId == ownerId)
                .ToList();

            return cars;
        }
    }
}
