using System;
using Xamarin.Forms;
using XamarinCalculator.Helpers;

namespace XamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        private static Grid grid;
        private static Label outputLabel;

        private static string currentNumber;

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
            outputLabel = LabelHelper.CreateOutputLabel(string.Empty);

            grid = GridHelper.CreateGrid(7, 4);
            GridHelper.AddItemToGrid(grid, titleLabel, 0, 0, 1, 4);
            GridHelper.AddItemToGrid(grid, outputLabel, 1, 0, 1, 4);
            CreateKeyboard();
            CreateOperatorButtons();
        }

        private void CreateKeyboard()
        {
            var baseRow = 2;

            for (var row = 0; row < 3; row++)
            {
                for (var column = 0; column < 3; column++)
                {
                    var numberKey = 1 + (3 * row) + column;
                    SetupKey(numberKey.ToString(), row + baseRow, column);
                }
            }

            SetupKey("0", 5, 0, 2);
            SetupKey(".", 5, 2);
        }

        private void CreateOperatorButtons()
        {
            SetupMathOperatorButton("+", 2, 3);
            SetupMathOperatorButton("-", 3, 3);
            SetupMathOperatorButton("*", 4, 3);
            SetupMathOperatorButton("÷", 5, 3);
            SetupMathOperatorButton("=", 6, 3);

            var clearButton = ButtonHelper.CreateOperatorButton("CLEAR");
            clearButton.Clicked += new EventHandler(OnClearButtonClick);
            GridHelper.AddItemToGrid(grid, clearButton, 6, 0, 1, 3);
        }

        private void SetupKey(string key, int row, int column, int columnSpan = 1)
        {
            var button = ButtonHelper.CreateNumberButton(key);
            button.Clicked += new EventHandler(OnKeyClick);
            GridHelper.AddItemToGrid(grid, button, row, column, 1, columnSpan);
        }

        private void SetupMathOperatorButton(string operatorString, int row, int column, int columnSpan = 1)
        {
            var button = ButtonHelper.CreateOperatorButton(operatorString);
            button.Clicked += new EventHandler(OnMathOperatorButtonClick);
            GridHelper.AddItemToGrid(grid, button, row, column, 1, columnSpan);
        }

        private void OnKeyClick(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var key = buttonClicked.Text;

            outputLabel.Text += key;
            currentNumber += key;
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void OnMathOperatorButtonClick(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var operatorString = buttonClicked.Text;

            if (operatorString == "=")
            {
                HandleEqualsButtonClick();
            }
            else
            {
                HandleMathOperatorButtonClick(operatorString);
            }
        }

        private void HandleEqualsButtonClick()
        {
            CalculatorService.SecondNumber = double.Parse(currentNumber);

            var result = CalculatorService.Calculate();
            currentNumber = result.ToString();
            outputLabel.Text = $"= {result}";

            CalculatorService.UpdateMathOperator(string.Empty);
        }

        private void HandleMathOperatorButtonClick(string operatorString)
        {
            CalculatorService.FirstNumber = double.Parse(currentNumber);

            currentNumber = string.Empty;
            outputLabel.Text += $" {operatorString} ";

            CalculatorService.UpdateMathOperator(operatorString);
        }

        private void ResetCalculator()
        {
            CalculatorService.Reset();
            currentNumber = string.Empty;
            outputLabel.Text = string.Empty;
        }
    }
}
