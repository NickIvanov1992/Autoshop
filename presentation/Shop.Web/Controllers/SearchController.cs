using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly CarService carService;
        public SearchController(CarService carService)
        {
            this.carService = carService;
        }
    
        public IActionResult Index(string query)
        {
            var cars = carService.GetAllByQuery(query);
            return View("Index",cars);
        }
    }
}
