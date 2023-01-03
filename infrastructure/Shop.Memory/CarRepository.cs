using System;
using System.Linq;

namespace Shop.Memory
{
    public class CarRepository : ICarRepository
    {
        private readonly Car[] cars = new[]
        {
            new Car(1, "Nissan"),
            new Car(2, "Toyota"),
            new Car(3, "Lada"),
        };
        public Car[] GetByModel(string modelPart)
        {
            return cars.Where(car => car.Model.Contains(modelPart)).ToArray();
        }
    }
}