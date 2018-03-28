using XamarinCalculator;
using Xunit;

namespace XamarinCalculator.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void CalculatorService_WhenCalledWithNumbers_SetsPrivateVariables()
        {
            var calculatorService = new CalculatorService(5, 10);
            Assert.Equal(5, calculatorService.FirstNumber);
            Assert.Equal(10, calculatorService.SecondNumber);
        }

        [Fact]
        public void AddNumbers_WhenCalledWithTwoIntegers_ReturnsCorrectValue()
        {
            var result = AddNumbers(5, 10);

            Assert.Equal(15, result);
        }

        [Fact]
        public void AddNumbers_WhenCalledWithOneIntegerAndOneDouble_ReturnsCorrectValue()
        {
            var result = AddNumbers(5, 15.654);

            Assert.Equal(20.654, result);
        }

        [Fact]
        public void AddNumbers_WhenCalledWithTwoDoubles_ReturnsCorrectValue()
        {
            var result = AddNumbers(5.5, 10.5);

            Assert.Equal(16, result);
        }

        [Fact]
        public void AddNumbers_WhenCalledWithNegativeNumber_ReturnsCorrectValue()
        {
            var result = AddNumbers(-15, 10.5);

            Assert.Equal(-4.5, result);
        }

        [Fact]
        public void SubtractNumbers_WhenCalledWithTwoIntegers_ReturnsCorrectValue()
        {
            var result = SubtractNumbers(10, 2);

            Assert.Equal(8, result);
        }

        [Fact]
        public void SubtractNumbers_WhenCalledWithOneIntegerAndOneDouble_ReturnsCorrectValue()
        {
            var result = SubtractNumbers(10, 2.55);

            Assert.Equal(7.45, result);
        }

        [Fact]
        public void SubtractNumbers_WhenCalledWithTwoDoubles_ReturnsCorrectValue()
        {
            var result = SubtractNumbers(2.52, 1.52);

            Assert.Equal(1, result);
        }

        [Fact]
        public void SubtractNumbers_WhenCalledWithNegativeNumber_ReturnsCorrectValue()
        {
            var result = SubtractNumbers(8, -2);

            Assert.Equal(10, result);
        }

        [Fact]
        public void MultiplyNumbers_WhenCalledWithTwoIntegers_ReturnsCorrectValue()
        {
            var result = MultiplyNumbers(5, 10);

            Assert.Equal(50, result);
        }

        [Fact]
        public void MultiplyNumbers_WhenCalledWithOneIntegerAndOneDouble_ReturnsCorrectValue()
        {
            var result = MultiplyNumbers(5, 5.2);

            Assert.Equal(26, result);
        }

        [Fact]
        public void MultiplyNumbers_WhenCalledWithTwoDoubles_ReturnsCorrectValue()
        {
            var result = MultiplyNumbers(5.2, 2.4);

            Assert.Equal(12.48, result);
        }

        [Fact]
        public void MultiplyNumbers_WhenCalledWithNegativeNumber_ReturnsCorrectValue()
        {
            var result = MultiplyNumbers(-2, 5);

            Assert.Equal(-10, result);
        }

        [Fact]
        public void DivideNumbers_WhenCalledWithTwoIntegers_ReturnsCorrectValue()
        {
            var result = DivideNumbers(5, 10);

            Assert.Equal(0.5, result);
        }

        [Fact]
        public void DivideNumbers_WhenCalledWithOneIntegerAndOneDouble_ReturnsCorrectValue()
        {
            var result = DivideNumbers(16, 2.5);

            Assert.Equal(6.4, result);
        }

        [Fact]
        public void DivideNumbers_WhenCalledWithTwoDoubles_ReturnsCorrectValue()
        {
            var result = DivideNumbers(6.6, 3.3);

            Assert.Equal(2, result);
        }

        [Fact]
        public void DivideNumbers_WhenCalledWithNegativeNumber_ReturnsCorrectValue()
        {
            var result = DivideNumbers(-10, 5);

            Assert.Equal(-2, result);
        }

        private double AddNumbers(double firstNumber, double secondNumber)
        {
            var calculatorService = new CalculatorService(firstNumber, secondNumber);
            return calculatorService.AddNumbers();
        }

        private double SubtractNumbers(double firstNumber, double secondNumber)
        {
            var calculatorService = new CalculatorService(firstNumber, secondNumber);
            return calculatorService.SubtractNumbers();
        }

        private double MultiplyNumbers(double firstNumber, double secondNumber)
        {
            var calculatorService = new CalculatorService(firstNumber, secondNumber);
            return calculatorService.MultiplyNumbers();
        }

        private double DivideNumbers(double firstNumber, double secondNumber)
        {
            var calculatorService = new CalculatorService(firstNumber, secondNumber);
            return calculatorService.DivideNumbers();
        }
    }
}
