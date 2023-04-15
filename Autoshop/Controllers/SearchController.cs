using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.interfaces;
using Store.Models;
using Store.ViewModels;

namespace Store.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAllCars allCars;
        public SearchController(IAllCars allCars)
        {
            this.allCars = allCars;
        }

        [Route("Search/SearchResult")]
        [Route("Search/SearchResult/{carName}")]
        public IActionResult Index(string carName)
        {
            IEnumerable<Car> searchCars = null;
            string searchResult = "";

            if (string.IsNullOrEmpty(carName))
            {
                searchCars = allCars.Cars.OrderBy(i => i.Id);
                searchResult = "Автомобиль отсутствует";
            }
            else
            {
                searchCars = allCars.Cars.Where(x => x.Name.ToLower().Contains(carName.ToLower()));
                searchResult = "Результаты поиска";
            }
            var carObj = new CarsListViewModel
            {
                GetSearchCars = searchCars
            };
            return View(carObj);
        }
    }
}

