using Microsoft.EntityFrameworkCore;
using Shop.Domain;

namespace Shop.Data.EF
{
    public class CarRepository : IAllCars
    {

        private readonly StoreDbContext storeDbContext;
        public CarRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public IEnumerable<Car> Cars => storeDbContext.Car;
        public async Task<IEnumerable<Car>> GetAllCars(string category)
        {
            IEnumerable<Car>? cars = null;

            if (string.IsNullOrEmpty(category))
            {
                cars = await storeDbContext.Car.ToArrayAsync();
            }

            var allCars = storeDbContext.Car;
            if (string.Equals("cars", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = await storeDbContext.Car.Where(x => x.CategoryID == 1 && x.Available > 0).ToArrayAsync();              
            }
            else if (string.Equals("trucks", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = await storeDbContext.Car.Where(x => x.CategoryID == 2 && x.Available > 0).ToArrayAsync();
            }
     
            return cars.OrderBy(i=>i.Id);
        }
        public async Task<IEnumerable<Car>> GetFavouriteCars()
        {
           var result = await storeDbContext.Car.Where(x => x.isFavourite).ToArrayAsync(); // получить избранные авто
            return result.OrderBy(i => i.Id);
        }

        public async Task<IEnumerable<Car>> GetCarsAsync(string carName)
        {
            var result = await storeDbContext.Car.Where(x => x.Name.ToLower().Contains(carName.ToLower())).ToArrayAsync();
            return  result;
        }

        public Car DeleteCar(int carId)
        {
            Car? db = storeDbContext.Car.Find(carId);
            if (db != null)
            {
                storeDbContext.Car.Remove(db);
                storeDbContext.SaveChanges();
            }
            return db;
        }
        public async Task<Car> GetObjectCar(int carId)
        {
            var cars = await storeDbContext.Car.ToArrayAsync();
            return cars.FirstOrDefault(p => p.Id == carId);
        }
        
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
                    db.Price = car.Price;
                    db.CategoryID = car.CategoryID;
                    db.Img = car.Img;
                    db.isFavourite = car.isFavourite;
                    db.Available = car.Available;
                    db.ShortDescription = car.ShortDescription;
                }
            }
            storeDbContext.SaveChanges();
        }
    }
}
