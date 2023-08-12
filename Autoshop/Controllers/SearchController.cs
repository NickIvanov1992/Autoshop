using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Store.ViewModels;

namespace Store.Controllers
{
    public class SearchController : Controller
    {
        private readonly CarService carService;
        public SearchController(CarService carService)
        {
            this.carService = carService;
        }

        [Route("Search/SearchResult")]
        [Route("Search/SearchResult/{carName}")]
        public async Task<IActionResult> Index(string carName)
        {
            var searchCars = await carService.GetSearchCar(carName);

            var carObj = new CarsListViewModel
            {
                GetSearchCars = searchCars
            };
            return View(carObj);
        }

    }
}

