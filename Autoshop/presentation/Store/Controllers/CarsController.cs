using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Store.ViewModels;



namespace Store.Controllers
{
    public class CarsController : Controller
    {
        private readonly ILogger logger;

        private readonly IAllCars allCars;
        private readonly ICarsCategory carsCategories;
        private readonly CarService carService;
        public CarsController(IAllCars allCars, ICarsCategory carsCategories, ILogger<CarsController> logger,CarService carService)
        {
            this.allCars = allCars;
            this.carsCategories = carsCategories;
            this.logger = logger;
            this.carService = carService;
        }

        [Route("Cars/Index")]
        [Route("Cars/Index/{category}")]
        public async Task<ViewResult> Index(string category)
        {
            string currentCategory = "";
            if (category == "cars")
                 currentCategory = "Легковые";

            else if (category == "trucks")
                  currentCategory = "Грузовики";

            IEnumerable<Car> cars = await carService.GetAllCars(category);

            var carObj = new CarsListViewModel
            {
                GetAllCars = cars,
                CurrentCategory = currentCategory,  
            };

            ViewBag.Title = "Страница с автомобилями";
            logger.LogInformation("Test Message");
            return View(carObj);
        }

    }
}
