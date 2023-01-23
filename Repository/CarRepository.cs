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
        public IEnumerable<Car> Cars => storeDbContext.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavoriteCars => storeDbContext.Car.Where(x => x.isFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => storeDbContext.Car.FirstOrDefault(p => p.Id == carId);
       
    }
}
