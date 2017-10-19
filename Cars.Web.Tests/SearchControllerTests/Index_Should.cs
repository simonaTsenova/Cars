using Cars.Services.Contracts;
using Cars.Web.Controllers;
using Cars.Web.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Cars.Web.Tests.SearchControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView_WhenInvoked()
        {
            var carServiceMock = new Mock<ICarService>();
            var factoryMock = new Mock<ICarViewModelFactory>();
            var controller = new SearchController(carServiceMock.Object, factoryMock.Object);

            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
