using Xamarin.Forms;

namespace XamarinCalculator.Helpers
{
    public class ButtonHelper
    {
        private static FontSizeConverter fontSizeConverter = new FontSizeConverter();

        public static Button CreateNumberButton(string text)
        {
            return CreateButton(text, Color.Black, Color.LightGray);
        }

        public static Button CreateOperatorButton(string operatorString)
        {
            return CreateButton(operatorString, Color.White, Color.Blue);
        }

        private static Button CreateButton(string text, Color textColour, Color backgroundColour)
        {
            return new Button
            {
                Text = text,
                BackgroundColor = backgroundColour,
                TextColor = textColour,
                FontSize = (double)fontSizeConverter.ConvertFromInvariantString("Large"),
                CornerRadius = 0,
            };
        }
    }
}
