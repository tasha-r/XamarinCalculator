using System;
using Xamarin.Forms;
using XamarinCalculator.Helpers;

namespace XamarinCalculator
{
    public partial class MainPage : ContentPage
    {
        private static Grid grid;
        private static Label outputLabel;

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

        private void SetupNumberKey(string key, int row, int column, int columnSpan = 1)
        {
            var button = ButtonHelper.CreateNumberButton(key);
            button.Clicked += new EventHandler(OnNumberKeyClick);
            GridHelper.AddItemToGrid(grid, button, row, column, 1, columnSpan);
        }

        private void OnNumberKeyClick(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var numberKey = int.Parse(buttonClicked.Text);
            outputLabel.Text += numberKey;
        }
    }
}
