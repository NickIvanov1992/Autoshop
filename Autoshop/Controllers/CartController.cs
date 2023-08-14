using Microsoft.AspNetCore.Mvc;
using Store.ViewModels;
using Shop.Domain;
using Shop.Data.EF;


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
        public async Task<ViewResult> Index()
        {
            var items = await storeCart.GetStoreItems();
            storeCart.ListItems = items;

            var obj = new CartViewModel
            {
                storeCart = storeCart
            };
            return View(obj);
        }

        [HttpGet]
        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await carRepository.GetObjectCar(id);
            var items = await storeCart.GetStoreItems();
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
        public async Task<RedirectToActionResult> RemoveCar(int id)
        {
            var items = await storeCart.GetStoreItems();
            foreach (var item in items)
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
