using Xunit;

namespace XamarinCalculator.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void Calculate_WhenCalledWithAdditionOperator_ReturnsCorrectResult()
        {
            var result = CalculatorService.Calculate(10, 5.5, '+');
            Assert.Equal(15.5, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithSubtractionOperator_ReturnsCorrectResult()
        {
            var result = CalculatorService.Calculate(10, 5.5, '-');
            Assert.Equal(4.5, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithMultiplicationOperator_ReturnsCorrectResult()
        {
            var result = CalculatorService.Calculate(10, 5, '*');
            Assert.Equal(50, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithDivisionOperator_ReturnsCorrectResult()
        {
            var result = CalculatorService.Calculate(10, 5, '÷');
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithInvalidOperator_ReturnsCorrectResult()
        {
            var result = CalculatorService.Calculate(10, 5, '$');
            Assert.Equal(0, result);
        }
    }
}
