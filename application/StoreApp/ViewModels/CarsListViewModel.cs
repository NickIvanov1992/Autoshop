using domain.store;

namespace application.StoreApp.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
