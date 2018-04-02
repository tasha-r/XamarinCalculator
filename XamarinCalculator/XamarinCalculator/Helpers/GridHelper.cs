using System;
using Xamarin.Forms;

namespace XamarinCalculator.Helpers
{
    public class GridHelper
    {
        public static Grid CreateGrid(int numRows, int numColumns)
        {
            if ((numRows <= 0) || (numColumns <= 0))
            {
                throw new Exception("You must provide valid grid dimensions.");
            }

            return new Grid
            {
                Padding = 10,
                RowSpacing = 2,
                ColumnSpacing = 2,
                RowDefinitions = CreateRowDefinitions(numRows),
                ColumnDefinitions = CreateColumnDefinitions(numColumns),
            };
        }

        public static void AddItemToGrid(Grid grid, View view, int row, int column, int rowSpan = 1, int columnSpan = 1)
        {
            Grid.SetRow(view, row);
            Grid.SetColumn(view, column);
            Grid.SetRowSpan(view, rowSpan);
            Grid.SetColumnSpan(view, columnSpan);
            grid.Children.Add(view);
        }

        private static RowDefinitionCollection CreateRowDefinitions(int numRows)
        {
            var rowDefinition = new RowDefinition
            {
                Height = GridLength.Star,
            };

            var rowDefinitions = new RowDefinitionCollection();

            for (var i = 0; i < numRows; i++)
            {
                rowDefinitions.Add(rowDefinition);
            }

            return rowDefinitions;
        }

        private static ColumnDefinitionCollection CreateColumnDefinitions(int numColumns)
        {
            var columnDefinition = new ColumnDefinition
            {
                Width = GridLength.Star,
            };

            var columnDefinitions = new ColumnDefinitionCollection();

            for (var i = 0; i < numColumns; i++)
            {
                columnDefinitions.Add(columnDefinition);
            }

            return columnDefinitions;
        }
    }
}
