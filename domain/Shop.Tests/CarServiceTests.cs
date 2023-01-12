using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests
{
    public class CarServiceTests
    {
        [Fact]
        public void GetAllByQuery_Year_GetByYear()
        {                                                                      // заглушка для CarRepository
            var carRepositoryStub = new Mock<ICarRepository>();          // при вызове метода GetByYear c любым строковым параметром, вернуть массив автомобилей с ID1  
            carRepositoryStub.Setup(x => x.GetByYear(It.IsAny<string>()))
                .Returns(new[] { new Car(1, "", "", "","",0m) });

            carRepositoryStub.Setup(x => x.GetByModelOrBrand(It.IsAny<string>()))
                .Returns(new[] { new Car(2, "", "", "","",0m) });

            var carService = new CarService(carRepositoryStub.Object);
            var validYear = "YEAR 1234";

            var actual = carService.GetAllByQuery(validYear);

            Assert.Collection(actual, car => Assert.Equal(1, car.Id));
        }

        [Fact]
        public void GetAllByQuery_Brand_GetByModelOrBrand()
        {                                                                      // заглушка для CarRepository
            var carRepositoryStub = new Mock<ICarRepository>();          // при вызове метода GetByYear c любым строковым параметром, вернуть массив автомобилей с ID1  
            carRepositoryStub.Setup(x => x.GetByYear(It.IsAny<string>()))
                .Returns(new[] { new Car(1, "", "", "", "", 0m) });

            carRepositoryStub.Setup(x => x.GetByModelOrBrand(It.IsAny<string>()))
                .Returns(new[] { new Car(2, "", "", "", "", 0m) });

            var carService = new CarService(carRepositoryStub.Object);
            var invalidYear = "1234";

            var actual = carService.GetAllByQuery(invalidYear);

            Assert.Collection(actual, car => Assert.Equal(2, car.Id));
        }
    }
}
