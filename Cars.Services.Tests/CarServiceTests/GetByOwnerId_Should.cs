using Cars.Data.Contracts;
using Cars.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Cars.Services.Tests.CarServiceTests
{
    [TestFixture]
    public class GetByOwnerId_Should
    {
        [Test]
        public void CallRepositoryAll_WhenInvoked()
        {
            var id = 1;

            var repositoryMock = new Mock<IRepository<Car>>();
            var service = new CarService(repositoryMock.Object);

            service.GetByOwnerId(id);

            repositoryMock.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ReturnCorrectCars_WhenInvoked()
        {
            var id = 1;

            var cars = new List<Car>()
            {
                new Car() { OwnerId = id },
                new Car() { OwnerId = id },
                new Car() { OwnerId = 2 },
            };
            var expected = new List<Car>()
            {
                cars[0], cars[1]
            };
            var repositoryMock = new Mock<IRepository<Car>>();
            repositoryMock.Setup(r => r.All).Returns(cars.AsQueryable());
            var service = new CarService(repositoryMock.Object);

            var result = service.GetByOwnerId(id);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
