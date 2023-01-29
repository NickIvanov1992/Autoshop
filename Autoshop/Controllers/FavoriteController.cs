using Microsoft.AspNetCore.Mvc;
using Store.interfaces;
using Store.Models;
using Store.ViewModels;

namespace Store.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IAllCars carRepository;
        public FavoriteController(IAllCars carRepository)
        {
            this.carRepository = carRepository;
        }
        public ViewResult Index()
        {
            var primaryCars = new FavoriteViewModel
            {
                favoriteCars = carRepository.GetFavoriteCars
            };
            return View(primaryCars);
        }
    }
}
