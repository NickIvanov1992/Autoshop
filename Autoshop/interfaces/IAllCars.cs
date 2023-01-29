using Store.Models;

namespace Store.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; } 
        IEnumerable<Car> GetFavoriteCars { get; }
        Car GetObjectCar(int carId);
        public void SaveCar(Car car);
        Car DeleteCar(int carId);

    }
}
