using Moq;
using Shop.Domain;

namespace Shop.Tests
{
    public class CarTests
    {
        [Fact]
        public void GetAllCars()
        {
            var carRepositoryStub = new Mock<IAllCars>();
            carRepositoryStub.Setup(c => c.GetAllCars(It.IsAny<string>()));
            var result = carRepositoryStub.Object;
            Assert.NotNull(result);
        }
    }
}