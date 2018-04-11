using System;
using Xamarin.Forms;
using XamarinCalculator.Helpers;

namespace XamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        public enum MathOperator
        {
            NONE, ADD, SUBTRACT, MULTIPLY, DIVIDE
        }

        private static Grid grid;
        private static Label outputLabel;
        private static MathOperator mathOperatorClicked = MathOperator.NONE;

        private static double firstNumber;
        private static double secondNumber;
        private static string currentNumber;
        private static double result;

        public MainPage()
        {
            SetupGrid();
            Content = grid;
            Padding = SetupPadding();
        }

        private Thickness SetupPadding()
        {
            var topPadding = 0.0;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    topPadding = 20;
                    break;
                case Device.Android:
                    topPadding = 20;
                    break;
                default:
                    topPadding = 0;
                    break;
            }

            return new Thickness(20, topPadding, 20, 20);
        }

        private void SetupGrid()
        {
            var titleLabel = LabelHelper.CreateTitleLabel("Calculator");
            outputLabel = LabelHelper.CreateResultLabel(string.Empty);

            grid = GridHelper.CreateGrid(7, 4);
            GridHelper.AddItemToGrid(grid, titleLabel, 0, 0, 1, 4);
            GridHelper.AddItemToGrid(grid, outputLabel, 1, 0, 1, 4);
            CreateNumberKeyboard();
            CreateOperatorButtons();
        }

        private void CreateNumberKeyboard()
        {
            var baseRow = 2;

            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    var numberKey = 1 + (3 * row) + column;
                    SetupNumberKey(numberKey.ToString(), row + baseRow, column);
                }
            }

            SetupNumberKey("0", 5, 0, 3);
        }

        private void CreateOperatorButtons()
        {
            SetupOperatorButton('+', 2, 3);
            SetupOperatorButton('-', 3, 3);
            SetupOperatorButton('*', 4, 3);
            SetupOperatorButton('÷', 5, 3);
            SetupOperatorButton('=', 6, 0, 4);
        }

        private void SetupNumberKey(string key, int row, int column, int columnSpan = 1)
        {
            var button = ButtonHelper.CreateNumberButton(key);
            button.Clicked += new EventHandler(OnNumberKeyClick);
            GridHelper.AddItemToGrid(grid, button, row, column, 1, columnSpan);
        }

        private void SetupOperatorButton(char operatorChar, int row, int column, int columnSpan = 1)
        {
            var button = ButtonHelper.CreateOperatorButton(operatorChar);
            button.Clicked += new EventHandler(OnOperatorButtonClick);
            GridHelper.AddItemToGrid(grid, button, row, column, 1, columnSpan);
        }

        private void OnNumberKeyClick(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var numberKey = int.Parse(buttonClicked.Text);

            outputLabel.Text += numberKey;
            currentNumber += numberKey.ToString();
        }

        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var operatorChar = char.Parse(buttonClicked.Text);

            if (operatorChar == '=')
            {
                HandleEqualsButtonClick();
            }
            else
            {
                HandleMathOperatorButtonClick(operatorChar);
            }
        }

        private void HandleEqualsButtonClick()
        {
            secondNumber = double.Parse(currentNumber);
            result = CalculatorService.Calculate(firstNumber, secondNumber, mathOperatorClicked);
            currentNumber = result.ToString();

            outputLabel.Text = $"= {result}";
            mathOperatorClicked = MathOperator.NONE;
        }

        private void HandleMathOperatorButtonClick(char operatorChar)
        {
            firstNumber = double.Parse(currentNumber);
            currentNumber = string.Empty;

            outputLabel.Text += $" {operatorChar} ";
            UpdateMathOperatorClicked(operatorChar);
        }

        private void UpdateMathOperatorClicked(char operatorChar)
        {
            switch (operatorChar)
            {
                case '+':
                    mathOperatorClicked = MathOperator.ADD;
                    break;
                case '-':
                    mathOperatorClicked = MathOperator.SUBTRACT;
                    break;
                case '*':
                    mathOperatorClicked = MathOperator.MULTIPLY;
                    break;
                case '÷':
                    mathOperatorClicked = MathOperator.DIVIDE;
                    break;
                default:
                    mathOperatorClicked = MathOperator.NONE;
                    break;
            }
        }
    }
}
