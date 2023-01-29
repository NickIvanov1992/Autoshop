using domain.store;

namespace domain.store.interfaces
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
