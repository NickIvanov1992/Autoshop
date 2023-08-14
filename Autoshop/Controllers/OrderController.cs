using Microsoft.AspNetCore.Mvc;
using Shop.Data.EF;
using Shop.Domain;

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
        public async Task<IActionResult> Checkout()
        {
            storeCart.ListItems = await storeCart.GetStoreItems();
            if (storeCart.ListItems.Count == 0)
            {
                ViewBag.Message = "Нет выбранных автомобилей";
                return RedirectToAction("NoCars");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            storeCart.ListItems = await storeCart.GetStoreItems();
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
