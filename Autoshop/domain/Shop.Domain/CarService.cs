using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class CarService
    {
        private readonly IAllCars allCars;
        public CarService(IAllCars allCars)
        {
            this.allCars = allCars;
        }
        public async Task<IEnumerable<Car>> GetAllCars(string category = null)
        {
            IEnumerable<Car> AllCars = await allCars.GetAllCars(category);
            return AllCars;
        }
        public async Task<IEnumerable<Car>> GetSearchCar(string carName)
        {
            IEnumerable<Car> searchCars = await allCars.GetCarsAsync(carName);
             return searchCars;
        }
        public async Task<IEnumerable<Car>> GetFavouriteCars()
        {
            IEnumerable<Car> favouriteCars = await allCars.GetFavouriteCars();
            return favouriteCars;
        }

    }
}
