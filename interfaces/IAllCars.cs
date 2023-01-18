using Store.Models;

namespace Store.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; } 
        IEnumerable<Car> GetFavoriteCars { get; set; }
        Car GetObjectCar(int carId);

    }
}
