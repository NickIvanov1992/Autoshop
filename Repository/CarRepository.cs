using Microsoft.EntityFrameworkCore;
using Store.EF;
using Store.interfaces;
using Store.Models;

namespace Store.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly StoreDbContext storeDbContext;
        public CarRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public IEnumerable<Car> Cars => storeDbContext.Car;

        public IEnumerable<Car> GetFavoriteCars => storeDbContext.Car.Where(x => x.isFavourite);

        public Car GetObjectCar(int carId) => storeDbContext.Car.FirstOrDefault(p => p.Id == carId);

        public void SaveCar(Car car)
        {
            if (car.Id == 0)
                storeDbContext.Car.Add(car);
            else
            {
                Car db = storeDbContext.Car.Find(car.Id);
                if (car != null)
                {
                    db.Name = car.Name;
                    db.LongDescription = car.LongDescription;
                    db.Price = car.Price;
                    db.CategoryID = car.CategoryID;
                    db.Img = car.Img;
                    db.isFavourite = car.isFavourite;
                    db.ShortDescription = car.ShortDescription;
                }
            }
            storeDbContext.SaveChanges();
        }
    }
}
