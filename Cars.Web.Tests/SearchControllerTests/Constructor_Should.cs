using Cars.Services.Contracts;
using Cars.Web.Controllers;
using Cars.Web.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace Cars.Web.Tests.SearchControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCarServiceIsNull()
        {
            var factoryMock = new Mock<ICarViewModelFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new SearchController(null, factoryMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            var carServiceMock = new Mock<ICarService>();

            Assert.Throws<ArgumentNullException>(
                () => new SearchController(carServiceMock.Object, null));
        }

        [Test]
        public void DoesNotThrow_WhenDependenciesAreNotNull()
        {
            var carServiceMock = new Mock<ICarService>();
            var factoryMock = new Mock<ICarViewModelFactory>();

            Assert.DoesNotThrow(
                () => new SearchController(carServiceMock.Object, factoryMock.Object));
        }

        [Test]
        public void InitializeControllerCorrectly_WhenDependenciesAreNotNull()
        {
            var carServiceMock = new Mock<ICarService>();
            var factoryMock = new Mock<ICarViewModelFactory>();

            var controller = new SearchController(carServiceMock.Object, factoryMock.Object);

            Assert.IsNotNull(controller);
        }
    }
}
