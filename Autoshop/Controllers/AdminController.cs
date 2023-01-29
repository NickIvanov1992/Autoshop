using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Store.interfaces;
using Store.Models;

namespace Store.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IAllCars allCars;
        public AdminController(IAllCars allCars)
        {
            this.allCars = allCars;
        }

        public ViewResult Index()
        {
            return View(allCars.Cars);
        }
        public ViewResult Edit(int Id)
        {
            Car car = allCars.Cars
                .FirstOrDefault(g => g.Id == Id);
            return View(car);
        }
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                allCars.SaveCar(car);
                TempData["message"] = string.Format("Автомобиль \"{0}\" изменен", car.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(car);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Car());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Car deletedCar = allCars.DeleteCar(Id);
            if (deletedCar != null)
            {
                TempData["message"] = string.Format("Автомобиль \"{0}\" удален",
                    deletedCar.Name);
            }
            return RedirectToAction("Index");
        }

    }
}
