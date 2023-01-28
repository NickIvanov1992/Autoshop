
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
                        LongDescription = "Стремительная, просторная, отлично оснащенная Toyota Corolla.",
                        Img = "/img/corolla.jpg",
                        Price = 25000,
                        isFavourite = true,
                        Available = true,
                        CategoryID = 2,
                    },
                   new Car
                   {
                       Name = "Mercedes_Benz S-klass ",
                       ShortDescription = "4-ех дверный седан бизнесс класса ",
                       LongDescription = "Главное уникальный комфорт и технологии безопасности, на которые вы всегда можете рассчитывать",
                       Img = "/img/mercedes.jpg",
                       Price = 8500,
                       isFavourite = false,
                       Available = true,
                       CategoryID = 2,
                   },
                new Car
                {
                    Name = "КамАЗ-54907",
                    ShortDescription = "Трейлер Отечественного производства",
                    LongDescription = "Тягач нового типа, который предназначен для дальнемагистральных грузоперевозок.",
                    Img = "/img/kamaz.jpg",
                    Price = 8000,
                    isFavourite = false,
                    Available = false,
                    CategoryID = 1,
                },
                new Car
                {
                    Name = "Scania 730-s",
                    ShortDescription = "Шведский тягач для дальнемагистральных перевозок",
                    LongDescription = "двухосный магистральный седельный тягач с колесной компоновкой «4×2», который направлен, в первую очередь, для осуществления грузоперевозок по дорогам общего пользования в составе автопоезда с использованием полуприцепов различного назначения…",
                    Img = "/img/scania.jpg",
                    Price = 10000,
                    isFavourite = true,
                    Available = true,
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
                        new Category {CategoryName = "Легковые автомобили", Desc = " автомобиль, предназначенный для перевозки пассажиров и багажа, вместимостью от 2 до 8 человек."},
                        new Category {CategoryName = "Грузовики", Desc = "автомобиль, предназначенный для перевозки грузов в кузове или на грузовой платформе."}
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
