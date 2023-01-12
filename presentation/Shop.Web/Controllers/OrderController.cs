using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shop.Web.Controllers
{
    public class OrderController : Controller
    {
        //private readonly ICarRepository carRepository;
        //private readonly IOrderRepository orderRepository;
        //private readonly INotificationService notificationService;
        //public OrderController(ICarRepository carRepository, IOrderRepository orderRepository, INotificationService notificationService)
        //{
        //    this.carRepository = carRepository;
        //    this.orderRepository = orderRepository;
        //    this.notificationService = notificationService;
        //}

        private readonly ICarRepository carRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(ICarRepository carRepository, IOrderRepository orderRepository)
        {
            this.carRepository = carRepository;
            this.orderRepository = orderRepository;
        }
        
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetFavorites(out Favorites favorites))
            {
                var order = orderRepository.GetById(favorites.OrderId);
                OrderModel model = Map(order);
                return View(model);
            }
            return View("Empty");           // собрали модель заказа
        }

        private OrderModel Map(Order order)
        {
            var carIds = order.Items.Select(item => item.CarId);
            var cars = carRepository.GetAllByIds(carIds);          // автомобили в заказе
            var itemModels = from item in order.Items
                             join car in cars on item.CarId equals car.Id
                             select new OrderItemModel
                             {
                                 CarId = car.Id,
                                 Model = car.Model,
                                 Brand = car.Brand,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {                                             // модель заказа
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalCount,
            };
        }
      
        public IActionResult AddCar(int id)        //  передаем авто изрепозитория
        {

            Favorites favorites;
        Order order;

            if (HttpContext.Session.TryGetFavorites(out favorites))
            {
                order = orderRepository.GetById(favorites.OrderId);
            }
            else
            {

                order = orderRepository.Create();
                favorites = new Favorites(order.Id);
}

var car = carRepository.GetById(id);    // загружаем авто из репозитория
order.AddCar(car);
orderRepository.Update(order);

favorites.TotalCount = order.TotalCount;
 favorites.TotalPrice = order.TotalCount;

HttpContext.Session.Set(favorites);

return RedirectToAction("Index", "Car", new { id });
        }
        public IActionResult UpdateItem(int carId, int count)
        {
            (Order order, Favorites favorites) = GetOrCreateOrderAndFavorite();
            order.GetItem(carId).Count = count;
            SaveOrderAndFavorite(order, favorites);
            return RedirectToAction("Index", "Order");
        }
        private (Order order, Favorites favorites) GetOrCreateOrderAndFavorite()
        {
            Order order;
            if (HttpContext.Session.TryGetFavorites(out Favorites favorites))
            {
                order = orderRepository.GetById(favorites.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                favorites = new Favorites(order.Id);
            }
            return (order, favorites);
        }
        public IActionResult AddItem(int carId, int count = 1)
        {
            (Order order, Favorites favorites) = GetOrCreateOrderAndFavorite();
            var book = carRepository.GetById(carId);
            order.AddOrUpdateItem(book, count);
            SaveOrderAndFavorite(order, favorites);
            return RedirectToAction("Index", "Car", new { id = carId });
        }
        private void SaveOrderAndFavorite(Order order, Favorites favorites)
        {
            orderRepository.Update(order);
            favorites.TotalCount = order.TotalCount;
            favorites.TotalPrice = order.TotalCount;
            HttpContext.Session.Set(favorites);
        }
        //public IActionResult RemoveItem(int carId)
        //{
        //    (Order order, Favorites favorites) = GetOrCreateOrderAndFavorite();
        //    order.RemoveItem(carId);
        //    SaveOrderAndFavorite(order, favorites);
        //    return RedirectToAction("Index", "Order");
        //}

        //public IActionResult SendConfirmationCode(int id, string cellPhone)
        //{
        //    var order = orderRepository.GetById(id);
        //    var model = Map(order);

        //    if (!IsValidCellPhone(cellPhone))
        //    {
        //        model.Errors["cellPhone"] = "Неверный номер телефона";
        //        return View("Index", model);
        //    }

        //    int code = 5555; // random.Next(1000,10000)
        //    HttpContext.Session.SetInt32(cellPhone, code);
        //    notificationService.SendConfirmationCode(cellPhone, code);
        //        return View("Confirmation", new ConfirmationModel { CellPhone = cellPhone});
        //}
        //private bool IsValidCellPhone(string cellPhone)
        //{
        //    if (cellPhone == null)
        //        return false;
        //    cellPhone = cellPhone.Replace(" ", "")
        //        .Replace("-", "");
        //    return Regex.IsMatch(cellPhone, @"^\+?\d{11}$");

        //}
        public IActionResult RemoveCar(int id)
        {
            Order order;
            Favorites favorites;
            if (HttpContext.Session.TryGetFavorites(out favorites))
            {
                order = orderRepository.GetById(favorites.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                favorites = new Favorites(order.Id);
            }

            var car = carRepository.GetById(id);
            order.RemoveCar(car);
            orderRepository.Update(order);

            favorites.TotalCount = order.TotalCount;
            favorites.TotalPrice = order.TotalCount;
            
            HttpContext.Session.Set(favorites);
            return RedirectToAction("Index", "Car", new {id});
        }
        public IActionResult RemoveItem(int carId)
        {
            (Order order, Favorites favorites) = GetOrCreateOrderAndFavorite();
            order.RemoveItem(carId);
            SaveOrderAndFavorite(order, favorites);
            //Order order;
            //Favorites favorites;
            //if (HttpContext.Session.TryGetFavorites(out favorites))
            //{
            //    order = orderRepository.GetById(favorites.OrderId);
            //}
            //else
            //{
            //    throw new Exception("No favorites");
            //}

            //var car = carRepository.GetById(id);
            //order.RemoveItem(car);
            //orderRepository.Update(order);

            //favorites.TotalCount = order.TotalCount;
            //favorites.TotalPrice = order.TotalCount;
            //HttpContext.Session.Set(favorites);
            return RedirectToAction("Index", "Order");
        }

    }
}
