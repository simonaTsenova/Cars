using Cars.Data.Contracts;
using Cars.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Cars.Services.Tests.CarServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CarService(null));
        }

        [Test]
        public void DoesNotThrow_WhenRepositoryIsNotNull()
        {
            var repositoryMock = new Mock<IRepository<Car>>();

            Assert.DoesNotThrow(() => new CarService(repositoryMock.Object));
        }

        [Test]
        public void InitializeCarServiceCorrectly_WhenRepositoryIsNotNull()
        {
            var repositoryMock = new Mock<IRepository<Car>>();

            var service = new CarService(repositoryMock.Object);

            Assert.IsNotNull(service);
        }
    }
}
