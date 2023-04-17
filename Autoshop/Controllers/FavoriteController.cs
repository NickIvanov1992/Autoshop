using Microsoft.AspNetCore.Mvc;
using Store.interfaces;
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
                favoriteCars = carRepository.GetFavoriteCars.Where(x => x.Available > 0)   // есть ли авто в парке?
            };
            return View(primaryCars);
        }
    }
}
