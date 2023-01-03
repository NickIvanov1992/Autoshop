using Microsoft.AspNetCore.Mvc;

namespace Shop.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICarRepository carRepository;
            public SearchController (ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public IActionResult Index(string query)
        {
            var cars = carRepository.GetByModel(query);
            return View(cars);
        }
    }
}
