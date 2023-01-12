using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CarService
    {
        private readonly ICarRepository carRepository;
        public CarService (ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public Car[] GetAllByQuery(string query)
        {
            if (Car.IsYear(query))
                return carRepository.GetByYear(query);

            return carRepository.GetByModelOrBrand(query);   
        }
    }
}
