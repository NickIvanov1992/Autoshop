namespace Shop.Tests
{
    public class CarTests
    {
        [Fact]
        public void IsYear_Null()     // вернуть false в случае ввода null
        {
            bool actual = Car.IsYear(null);
            Assert.False(actual);
        }

        [Fact]
        public void IsYear_BlankString()     // вернуть false в случае ввода пробела
        {
            bool actual = Car.IsYear("   ");
            Assert.False(actual);
        }

        [Fact]
        public void IsYear_InvalidNumber()     // вернуть false в случае ввода несуществующего года
        {
            bool actual = Car.IsYear("Year -202");
            Assert.False(actual);
        }

        [Fact]
        public void IsYear_TrueNumber()     // вернуть true  в случае ввода верного года
        {
            bool actual = Car.IsYear("year 2023");
            Assert.True(actual);
        }

        [Fact]
        public void IsYear_MoreNumber()     // вернуть true  в случае ввода верного года
        {
            bool actual = Car.IsYear("year 2023563");
            Assert.True(actual);
        }

        [Fact]
        public void IsYear_InvalidSymbol()     // вернуть true  в случае ввода верного года
        {
            bool actual = Car.IsYear("zxc year 202356 yui");
            Assert.False(actual);
        }
    }
}