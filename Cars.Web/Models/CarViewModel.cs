using Cars.Models;

namespace Cars.Web.Models
{
    public class CarViewModel
    {
        public CarViewModel()
        {
        }

        public CarViewModel(Car car)
        {
            this.Owner = car.Owner;
            this.CarModel = car.CarModel;
            this.Description = car.Description;
        }

        public Owner Owner { get; set; }

        public CarModel CarModel { get; set; }

        public string Description { get; set; }
    }
}