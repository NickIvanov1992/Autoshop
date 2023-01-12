using System;
using System.Linq;

namespace Shop.Memory
{
    public class CarRepository : ICarRepository
    {
        private readonly Car[] cars = new[]
        {
            new Car(1, "Murano","Nissan","YEAR 2010","Не бита , не крашена.Печка ташкент",1200000m),
            new Car(2, "Land Cruiser","Toyota","2020","Один хозяин. продаю не спеша",3500000m),
            new Car(3, "Kalina","Lada", "2008","Родной цвет. Торга нет",120000m),
        };

        public Car[] GetAllByIds(IEnumerable<int> carIds)
        {
            var foundCars = from car in cars               //    идентификатор авто с внутреннего списка должен совпадать с внешним
                            join carId in carIds on car.Id equals carId
                            select car;
            return foundCars.ToArray();
        }

        public Car GetById(int id)
        {
            return cars.Single(car => car.Id == id);   // нужен только одн элемент либо выдаем исключение
        }

        public Car[] GetByModelOrBrand(string modelPartOrYear)
        {
            return cars.Where(car => car.Brand.Contains(modelPartOrYear) ||
            car.Model.Contains(modelPartOrYear)).ToArray();   // проверить массив авто
        }

        public Car[] GetByYear(string year)
        {
            return cars.Where(car => car.Year == year).ToArray();
        }
    }
}