using Shop.Domain;
using System.Drawing;
using System.Drawing.Imaging;


namespace Shop.Data.EF
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
                        ShortDescription = "компактный автомобиль, выпускаемый компанией Toyota. " +
                        "Появившись в 1966 году, он к 1997 стал одним из самых продаваемых автомобилей в истории." +
                        " С 1968 года в производство была запущена модель Toyota Sprinter, которая представляла собой" +
                        " более скромную версию автомобиля, продававшуюся только на территории Японии",
                        Price = 2500000,
                        Img = ImageToByte(Properties.Resources.corolla),
                        isFavourite = true,
                        Available = 15,
                        CategoryID = 2,
                    },
                   new Car
                   {
                       Name = "Mercedes_Benz S-klass ",
                       ShortDescription = "флагманская серия представительских автомобилей немецкой компании Mercedes-Benz, " +
                       "дочернего подразделения концерна Daimler AG. Представляет собой наиболее значимую линейку моделей " +
                       "в иерархии классов торговой марки. Первые представительские седаны появились ещё в начале 1950-х годов," +
                       " но официально S-класс появился лишь в 1972 году",
                       Price = 8500000,
                       Img = ImageToByte(Properties.Resources.mercedes),

                       isFavourite = false,
                       Available = 5,
                       CategoryID = 2,
                   },
                new Car
                {
                    Name = "КамАЗ-54907",
                    ShortDescription = " российский магистральный седельный тягач линейки шестого поколения (К6), выпускаемый ПАО «КАМАЗ»." +
                    " Является преемником тягача KAMAZ-54901 и выпускается параллельно с ним с 2021 года серийно. " +
                    "Буксирует трёхосный полуприцеп КАМАЗ (НЕФАЗ)-93341-1300010-60",
                    Price = 8000000,
                    Img = ImageToByte(Properties.Resources.kamaz),
                    isFavourite = false,
                    Available = 10,
                    CategoryID = 1,
                },
                new Car
                {
                    Name = "Scania 730-s",
                    ShortDescription = "магистральный седельный тягач, предназначением которого" +
                    " является перевозка грузов по дорогам всех категорий в составе автопоезда " +
                    "(с использованием широкого спектра полуприцепов), в том числе и в " +
                    "тяжелых условиях… Впервые грузовик был продемонстрирован мировой общественности" +
                    " в 2010 году на автомобильной выставке в Ганновере, после чего стартовало " +
                    "его серийное производство.",
                    Price = 10000000,
                    Img = ImageToByte(Properties.Resources.scania),
                    isFavourite = true,
                    Available = 3,
                    CategoryID = 1,
                },
                new Car
                {
                    Name = "Ferrari F-40",
                    ShortDescription = "среднемоторный двухдверный заднеприводный суперкар, " +
                    "имеющий кузов типа берлинетта. Производился Ferrari с 1987 по 1992. " +
                    "Автомобиль основан на шасси GTO Evoluzione, " +
                    "является дальнейшим развитием для гоночной версии Ferrari 288 GTO. " +
                    "В общей сложности было произведено 1315 таких авто." +
                    "Ferrari F40 — последняя модель, созданная при жизни Энцо Феррари",
                    Price = 100000000,
                    Img = ImageToByte(Properties.Resources.ferrari),
                    isFavourite = false,
                    Available = 1,
                    CategoryID = 2,
                },
                new Car
                {
                    Name = "Audi A7",
                    ShortDescription = "пятидверный фастбэк класса Гран Туризмо, выпускаемый AUDI AG, " +
                    "на платформе А6, позиционируется в сегменте ниже Audi A8. " +
                    "Его основные конкуренты — Mercedes-Benz CLS и BMW 6 Gran Coupe",
                    Price = 5000000,
                    Img = ImageToByte(Properties.Resources.audi),
                    isFavourite = true,
                    Available = 10,
                    CategoryID = 2,
                },
                new Car
                {
                    Name = "Peterbilt 379",
                    ShortDescription = "крупнотоннажный грузовой автомобиль компании Peterbilt, " +
                    "серийно выпускаемый с 1987 по 2007 год. Автомобиль обладает " +
                    "повышенным уровнем комфорта и мощности. Для снижения массы кабина сделана из алюминия." +
                    "Автомобиль Peterbilt 379 обслуживает как местные,так и дальнобойные маршруты." +
                    "Спальная кабина оборудована системой Unibilt Cab Sleeper System",
                    Price = 8500000,
                    Img = ImageToByte(Properties.Resources.peterbilt),
                    isFavourite = false,
                    Available = 1,
                    CategoryID = 1,
                }
              ) ;
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
                        new Category { CategoryName = "Легковые автомобили"},
                        new Category { CategoryName = "Грузовики"} 
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category cat in list)
                    category.Add(cat.CategoryName,cat);
                }
                return category;
            }
        }
        public static byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
        
    }
    
}
