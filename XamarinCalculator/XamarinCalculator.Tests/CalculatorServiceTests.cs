using Xunit;

namespace XamarinCalculator.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void Calculate_WhenCalledWithAdditionOperator_ReturnsCorrectResult()
        {
            SetupCalculatorService(10, 5.5, "+");
            var result = CalculatorService.Calculate();
            Assert.Equal(15.5, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithSubtractionOperator_ReturnsCorrectResult()
        {
            SetupCalculatorService(10, 5.5, "-");
            var result = CalculatorService.Calculate();
            Assert.Equal(4.5, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithMultiplicationOperator_ReturnsCorrectResult()
        {
            SetupCalculatorService(10, 5, "*");
            var result = CalculatorService.Calculate();
            Assert.Equal(50, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithDivisionOperator_ReturnsCorrectResult()
        {
            SetupCalculatorService(10, 5, "÷");
            var result = CalculatorService.Calculate();
            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculate_WhenCalledWithInvalidOperator_ReturnsCorrectResult()
        {
            SetupCalculatorService(10, 5, "$");
            var result = CalculatorService.Calculate();
            Assert.Equal(0, result);
        }

        private static void SetupCalculatorService(double firstNumber, double secondNumber, string mathOperator)
        {
            CalculatorService.FirstNumber = firstNumber;
            CalculatorService.SecondNumber = secondNumber;
            CalculatorService.UpdateMathOperator(mathOperator);
        }
    }
}