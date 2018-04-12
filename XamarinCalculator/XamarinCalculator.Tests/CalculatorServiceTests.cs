using Xunit;

namespace XamarinCalculator.Tests
{
    public class CalculatorServiceTests
    {
        public CalculatorServiceTests()
        {
            CalculatorService.FirstNumber = 0;
            CalculatorService.SecondNumber = 0;
            CalculatorService.UpdateMathOperator(string.Empty);
        }

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

        [Fact]
        public void Reset_WhenCalled_ResetsNumberVariables()
        {
            SetupCalculatorService(15, 2.25, "+");

            CalculatorService.Reset();

            Assert.Equal(0, CalculatorService.FirstNumber);
            Assert.Equal(0, CalculatorService.SecondNumber);
        }

        [Fact]
        public void Reset_WhenCalled_ResetsMathOperatorVariable()
        {
            SetupCalculatorService(2, 2, "+");
            CalculatorService.Reset();
            CalculatorService.FirstNumber = 2;
            CalculatorService.SecondNumber = 2;

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