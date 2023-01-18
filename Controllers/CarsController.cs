using Microsoft.AspNetCore.Mvc;
using Store.interfaces;
using Store.ViewModels;

namespace Store.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory carsCategories;
        public CarsController(IAllCars allCars, ICarsCategory carsCategories)
        {
            this.allCars = allCars;
            this.carsCategories = carsCategories;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.GetAllCars = allCars.Cars;
            obj.CurrentCategory = "Автомобили";
            return View(obj);
        }
    }
}
