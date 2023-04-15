using Microsoft.AspNetCore.Mvc;
//using Store.Migrations;
using Store.Repository;
using Store.Models;
using Store.ViewModels;
using Store.interfaces;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly StoreCart storeCart;
        public CartController(IAllCars carRepository, StoreCart storeCart)
        {
            this.carRepository = carRepository;
            this.storeCart = storeCart;
        }
        public ViewResult Index()
        {
            var items = storeCart.GetStoreItems();
            storeCart.ListItems = items;

            var obj = new CartViewModel
            {
                storeCart = storeCart
            };
            return View(obj);
        }
        [HttpGet]
        public RedirectToActionResult AddToCart (int id)
        {
            var item = carRepository.Cars.FirstOrDefault(c => c.Id == id);
            var items = storeCart.GetStoreItems();
            bool isExsist = false;
            foreach (var i in items)
            {
                if (i.car.Id == id)
                {
                    isExsist = true;
                }
            }
            if (isExsist == true || item == null)
            {
                TempData["message"] = string.Format("Автомобиль уже добавлен");
            }
            else
            {
                storeCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveCar(int id)
        {
            var items = storeCart.GetStoreItems();
            foreach(var item in items)
            {
                if (id == item.car.Id)
                {
                    storeCart.RemoveCar(item);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
