using Store.Models;

namespace Store.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; } 
        IEnumerable<Car> GetFavoriteCars { get; }
        Car GetObjectCar(int carId);

    }
}
