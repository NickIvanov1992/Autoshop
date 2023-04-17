
using Store.interfaces;
using Store.Models;

namespace Store.EF
{
    public class DBObjects
    {
        public static void GetInitial(StoreDbContext storeDbContext)
        {

            if (!storeDbContext.Categories.Any())
                storeDbContext.Categories.AddRange(GetCategory.Select(c => c.Value));
            if (!storeDbContext.Car.Any())
            {
                storeDbContext.AddRange(
                    new Car
                    {
                        Name = "Toyota Corolla",
                        ShortDescription = "4-ех дверный седан для всей семьи ",
                        Price = 25000,
                        isFavourite = true,
                        Available = 1,
                        CategoryID = 2,
                    },
                   new Car
                   {
                       Name = "Mercedes_Benz S-klass ",
                       ShortDescription = "4-ех дверный седан бизнесс класса ",
                       Price = 8500,
                       isFavourite = false,
                       Available = 1,
                       CategoryID = 2,
                   },
                new Car
                {
                    Name = "КамАЗ-54907",
                    ShortDescription = "Трейлер Отечественного производства",
                    Price = 8000,
                    isFavourite = false,
                    Available = 1,
                    CategoryID = 1,
                },
                new Car
                {
                    Name = "Scania 730-s",
                    ShortDescription = "Шведский тягач для дальнемагистральных перевозок",
                    Price = 10000,
                    isFavourite = true,
                    Available = 1,
                    CategoryID = 1,
                }
              );
            }
            storeDbContext.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> GetCategory
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Легковые автомобили"},
                        new Category {CategoryName = "Грузовики"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category cat in list)
                    category.Add(cat.CategoryName,cat);
                }
                return category;
            }
        }
    }
}
