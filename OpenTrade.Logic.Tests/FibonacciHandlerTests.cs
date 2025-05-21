using OpenTrade.Logic.Services;

namespace OpenTrade.Logic.Tests
{
    public class FibonacciHandlerTests
    {
        private readonly FibonacciHandler _handler = new FibonacciHandler();

        [Fact]
        public void GetPreviousFibonacci_ReturnsCorrectTuple_ForFibonacciNumber()
        {
            var result = _handler.GetPreviousFibonacci(13);
            Assert.Equal((5, 8), result);
        }

        [Fact]
        public void GetPreviousFibonacci_ReturnsCorrectTuple_ForFirstFibonacciNumber()
        {
            var result = _handler.GetPreviousFibonacci(1);
            Assert.Equal((0, 1), result);
        }

        [Fact]
        public void GetPreviousFibonacci_ThrowsArgumentException_ForNonFibonacciNumber()
        {
            Assert.Throws<ArgumentException>(() => _handler.GetPreviousFibonacci(4));
            Assert.Throws<ArgumentException>(() => _handler.GetPreviousFibonacci(6));
            Assert.Throws<ArgumentException>(() => _handler.GetPreviousFibonacci(10));
        }

        [Fact]
        public void GetPreviousFibonacci_ThrowsArgumentException_ForZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => _handler.GetPreviousFibonacci(0));
            Assert.Throws<ArgumentException>(() => _handler.GetPreviousFibonacci(-5));
        }
    }
}