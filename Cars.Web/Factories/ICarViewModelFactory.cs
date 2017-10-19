using Cars.Models;
using Cars.Web.Models;

namespace Cars.Web.Factories
{
    public interface ICarViewModelFactory
    {
        CarViewModel CreateCarViewModel(Car car);
    }
}
