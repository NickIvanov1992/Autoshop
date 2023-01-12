using Microsoft.AspNetCore.Mvc;
using Shop.Memory;

namespace Shop.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IActionResult Index(int id)
        {
            Car car = carRepository.GetById(id);
            return View(car);
        }
    }
}
