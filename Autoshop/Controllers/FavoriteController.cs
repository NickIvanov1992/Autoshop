using Microsoft.AspNetCore.Mvc;
using domain.store.interfaces;
using domain.store;
using application.StoreApp.ViewModels;

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
