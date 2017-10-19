using Cars.Services.Contracts;
using Cars.Web.Factories;
using Cars.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Cars.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarService carService;
        private readonly ICarViewModelFactory factory;

        public SearchController(ICarService carService, ICarViewModelFactory factory)
        {
            if(carService == null)
            {
                throw new ArgumentNullException("Car service cannot be null.");
            }

            if(factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            this.carService = carService;
            this.factory = factory;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            var cars = this.carService
                .GetByOwnerId(model.OwnerId);

            var carsModel = cars
                .Select(car => this.factory.CreateCarViewModel(car));

            return this.PartialView("_CarsListPartial", carsModel);
        }
    }
}