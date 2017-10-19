using Cars.Models;
using Cars.Services.Contracts;
using Cars.Web.Controllers;
using Cars.Web.Factories;
using Cars.Web.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;


namespace Cars.Web.Tests.SearchControllerTests
{
    [TestFixture]
    public class Search_Should
    {
        [Test]
        public void CallCarServiceGetByOwnerId_WhenInvoked()
        {
            var id = 1;

            var cars = new List<Car>()
            {
                new Car() { OwnerId = id },
            };
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(s => s.GetByOwnerId(id)).Returns(cars);
            var factoryMock = new Mock<ICarViewModelFactory>();
            var controller = new SearchController(carServiceMock.Object, factoryMock.Object);
            var searchViewModel = new SearchViewModel() { OwnerId = id };

            controller.Search(searchViewModel);

            carServiceMock.Verify(s => s.GetByOwnerId(id), Times.Once);
        }

        [Test]
        public void RenderPartialViewWithCorrectModel_WhenInvoked()
        {
            var id = 1;

            var cars = new List<Car>()
            {
                new Car() { OwnerId = id },
            };
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(s => s.GetByOwnerId(id)).Returns(cars);
            var factoryMock = new Mock<ICarViewModelFactory>();
            var carViewModel = new CarViewModel();
            factoryMock.Setup(f => f.CreateCarViewModel(It.IsAny<Car>())).Returns(carViewModel);
            var controller = new SearchController(carServiceMock.Object, factoryMock.Object);
            var searchViewModel = new SearchViewModel() { OwnerId = id };
            var expected = new List<CarViewModel>() { carViewModel };

            controller.WithCallTo(c => c.Search(searchViewModel))
                .ShouldRenderPartialView("_CarsListPartial")
                .WithModel<IEnumerable<CarViewModel>>(m => CollectionAssert.AreEqual(expected, m));
        }
    }
}
