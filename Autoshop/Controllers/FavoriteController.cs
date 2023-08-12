using Microsoft.AspNetCore.Mvc;
using Shop.Domain;
using Store.ViewModels;

namespace Store.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly CarService carService;
        public FavoriteController(CarService carService)
        {
            this.carService = carService;
        }
        public async Task<ViewResult> Index()
        {
            var primaryCars = new FavoriteViewModel
            {
                favoriteCars = await carService.GetFavouriteCars(),
            };
                return View(primaryCars);
        }


    }
}
