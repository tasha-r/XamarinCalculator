using static XamarinCalculator.MainPage;

namespace XamarinCalculator
{
    public class CalculatorService
    {
        public static double Calculate(double firstNumber, double secondNumber, MathOperator mathOperator)
        {
            switch (mathOperator)
            {
                case MathOperator.ADD:
                    return firstNumber + secondNumber;
                case MathOperator.SUBTRACT:
                    return firstNumber - secondNumber;
                case MathOperator.MULTIPLY:
                    return firstNumber * secondNumber;
                case MathOperator.DIVIDE:
                    return firstNumber / secondNumber;
                default:
                    return 0;
            }
        }
    }
}
