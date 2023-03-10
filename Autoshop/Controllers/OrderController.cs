using Microsoft.AspNetCore.Mvc;
using Store.interfaces;
using Store.Models;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly StoreCart storeCart;
        public OrderController(IAllOrders allOrders, StoreCart storeCart)
        {
            this.allOrders = allOrders;
            this.storeCart = storeCart;
        }

        public IActionResult Checkout()
        {
            storeCart.ListItems = storeCart.GetStoreItems();
            if (storeCart.ListItems.Count == 0)
            {
                ViewBag.Message = "Нет выбранных автомобилей";
                return RedirectToAction("NoCars");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
            {
            storeCart.ListItems = storeCart.GetStoreItems();
            if (storeCart.ListItems.Count == 0)
            {
                ViewBag.Message = "Нет выбранных автомобилей";
                return View();
            }
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
            }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ принят в обработку";
            HttpContext.Session.Clear();
            return View();
        }
        public IActionResult NoCars()
        {
            ViewBag.Message = "Нет выбранных автомобилей";
            return View();
        }

    }
}
