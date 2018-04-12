using static XamarinCalculator.MainPage;

namespace XamarinCalculator
{
    public class CalculatorService
    {
        private static double firstNumber;
        private static double secondNumber;
        private static MathOperator currentMathOperator = MathOperator.NONE;

        private enum MathOperator
        {
            NONE, ADD, SUBTRACT, MULTIPLY, DIVIDE
        }

        public static double FirstNumber { get => firstNumber; set => firstNumber = value; }

        public static double SecondNumber { get => secondNumber; set => secondNumber = value; }

        public static double Calculate()
        {
            switch (currentMathOperator)
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

        public static void UpdateMathOperator(string operatorString)
        {
            if (operatorString == string.Empty)
            {
                currentMathOperator = MathOperator.NONE;
                return;
            }

            switch (operatorString)
            {
                case "+":
                    currentMathOperator = MathOperator.ADD;
                    break;
                case "-":
                    currentMathOperator = MathOperator.SUBTRACT;
                    break;
                case "*":
                    currentMathOperator = MathOperator.MULTIPLY;
                    break;
                case "÷":
                    currentMathOperator = MathOperator.DIVIDE;
                    break;
                default:
                    currentMathOperator = MathOperator.NONE;
                    break;
            }
        }

        public static void Reset()
        {
            firstNumber = 0;
            secondNumber = 0;
            currentMathOperator = MathOperator.NONE;
        }
    }
}
