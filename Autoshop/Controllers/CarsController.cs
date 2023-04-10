using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Store.interfaces;
using Store.Models;
using Store.ViewModels;
using System.Drawing;
//using System.Web.Mvc;

namespace Store.Controllers
{
    public class CarsController : Controller
    {
        private readonly ILogger logger;

        private readonly IAllCars allCars;
        private readonly ICarsCategory carsCategories;
        public CarsController(IAllCars allCars, ICarsCategory carsCategories, ILogger<CarsController> logger)
        {
            this.allCars = allCars;
            this.carsCategories = carsCategories;
            this.logger = logger;
        }

        [Route("Cars/Index")]
        [Route("Cars/Index/{categ}")]
        public ViewResult Index(string categ)
        {

            string category = categ;
            IEnumerable<Car> cars =null;
            string currentCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                cars = allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("cars", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(x => x.CategoryID == 2).OrderBy(x => x.Id);
                    currentCategory = "Легковые";
                }
                else if (string.Equals("trucks", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(x => x.CategoryID == 1).OrderBy(x => x.Id);
                    currentCategory = "Грузовики";
                }
                
            }
            var carObj = new CarsListViewModel
            {
                GetAllCars = cars,
                CurrentCategory = currentCategory
            };
            
        
        
        ViewBag.Title = "Страница с автомобилями";
            logger.LogInformation("Test Message");
            return View(carObj);
        }
       
    }
}
