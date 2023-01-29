using Store.interfaces;
using Store.Models;

namespace Store.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Легковые автомобили", Desc = " автомобиль, предназначенный для перевозки пассажиров и багажа, вместимостью от 2 до 8 человек."},
                    new Category {CategoryName = "Грузовики", Desc = "автомобиль, предназначенный для перевозки грузов в кузове или на грузовой платформе."}
                };
            }
        }
    }
}
