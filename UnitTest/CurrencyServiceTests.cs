using DiamondApp.classes;
using DiamondApp.Interfaces;
using Moq;

namespace UnitTest
{
    public class CurrencyServiceTests
    {
        [Theory]
        [InlineData(100, 2.0, 200)]
        [InlineData(50, 1.5, 75)]
        public void Convert_CalculatesCorrectAmount(decimal amount, double rate, decimal expected)
        {
            var mock = new Mock<ICurrencyService>();
            mock.Setup(m => m.RateToRub).Returns(rate);

            var service = new CurrencyService(mock.Object);
            var result = service.Convert(amount);

            Assert.Equal(expected, result);
        }
    }
}