using Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public IEnumerable<Car> GetSearchCars { get; set; }
        public string CurrentCategory { get; set; }
        
    }
}
