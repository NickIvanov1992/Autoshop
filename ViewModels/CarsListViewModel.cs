using Store.Models;

namespace Store.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
