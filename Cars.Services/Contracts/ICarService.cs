using Cars.Models;
using System.Collections.Generic;

namespace Cars.Services.Contracts
{
    public interface ICarService
    {
        IList<Car> GetByOwnerId(int ownerId);
    }
}
