using Xamarin.Forms;

namespace XamarinCalculator.Helpers
{
    public class LabelHelper
    {
        private static FontSizeConverter fontSizeConverter = new FontSizeConverter();

        public static Label CreateTitleLabel(string text)
        {
            return new Label
            {
                Text = text,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Blue,
                FontFamily = "Arial",
                FontSize = (double)fontSizeConverter.ConvertFromInvariantString("Large"),
            };
        }

        public static Label CreateOutputLabel(string text)
        {
            return new Label
            {
                Text = text,
                HorizontalTextAlignment = TextAlignment.Start,
                FontFamily = "Arial",
                FontSize = (double)fontSizeConverter.ConvertFromInvariantString("Large"),
            };
        }
    }
}
