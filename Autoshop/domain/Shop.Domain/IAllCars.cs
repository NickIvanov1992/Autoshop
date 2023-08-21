namespace Shop.Domain
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        Task<IEnumerable<Car>> GetFavouriteCars();
        Task<Car> GetObjectCar(int carId);
        public void SaveCar(Car car);
        Task<IEnumerable<Car>> GetCarsAsync(string carName);
        Task<IEnumerable<Car>> GetAllCars(string category);
        Car DeleteCar(int carId);

    }
}
