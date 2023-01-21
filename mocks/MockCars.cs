using Store.interfaces;
using Store.Models;

namespace Store.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory carsCategory = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Toyota Corolla",
                        ShortDescription = "4-ех дверный седан для всей семьи ",
                        LongDescription = "Стремительная, просторная, отлично оснащенная Toyota Corolla.",
                        Img = "/img/corolla.jpg",
                        Price = 25000,
                        isFavourite = true,
                        Available = true,
                        Category = carsCategory.AllCategories.Last()
                    },
                   new Car
                    {
                        Name = "Mercedes_Benz S-klass ",
                        ShortDescription = "4-ех дверный седан бизнесс класса ",
                        LongDescription = "Главное уникальный комфорт и технологии безопасности, на которые вы всегда можете рассчитывать",
                        Img="/img/mercedes.jpg",
                        Price =8500,
                        isFavourite = false,
                        Available = true,
                        Category = carsCategory.AllCategories.Last()
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
                    Category = carsCategory.AllCategories.First()
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
                    Category = carsCategory.AllCategories.First()
                },
                 new Car()
                {
                    Name = "Audi A7",
                    ShortDescription = "Sportback (код кузова — 4G)",
                    LongDescription = "пятидверный фастбэк класса Гран Туризмо, выпускаемый AUDI AG, на платформе А6, позиционируется в сегменте ниже Audi A8",
                    Img = "/img/audi.jpg",
                    Price =8000,
                    isFavourite = true,
                    Available = true,
                    Category = carsCategory.AllCategories.First()
                }

                };

            }
        }
        public IEnumerable<Car> GetFavoriteCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
