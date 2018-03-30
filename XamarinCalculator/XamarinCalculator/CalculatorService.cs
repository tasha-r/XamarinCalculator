namespace XamarinCalculator
{
    public class CalculatorService
    {
        public static double Calculate(double firstNumber, double secondNumber, char mathOperator)
        {
            switch (mathOperator)
            {
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                case '*':
                    return firstNumber * secondNumber;
                case '÷':
                    return firstNumber / secondNumber;
                default:
                    return 0;
            }
        }
    }
}
