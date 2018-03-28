using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinCalculator
{
    public class CalculatorService
    {
        private double firstNumber;

        private double secondNumber;

        public double FirstNumber { get => firstNumber; set => firstNumber = value; }

        public double SecondNumber { get => secondNumber; set => secondNumber = value; }

        public CalculatorService()
        {
        }

        public CalculatorService(double firstNumberInput, double secondNumberInput)
        {
            firstNumber = firstNumberInput;
            secondNumber = secondNumberInput;
        }

        public double AddNumbers()
        {
            return firstNumber + secondNumber;
        }

        public double SubtractNumbers()
        {
            return firstNumber - secondNumber;
        }

        public double MultiplyNumbers()
        {
            return firstNumber * secondNumber;
        }

        public double DivideNumbers()
        {
            return firstNumber / secondNumber;
        }
    }
}
