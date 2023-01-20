using Microsoft.AspNetCore.Mvc;
//using Store.Migrations;
using Store.Repository;
using Store.Models;
using Store.ViewModels;
using Store.interfaces;

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
        public RedirectToActionResult AddToCart (int id)
        {
            var item = carRepository.Cars.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                storeCart.AddToCart(item);
            }
            return RedirectToAction("Index");

        }

    }
}
