using Xamarin.Forms;

namespace XamarinCalculator.Helpers
{
    public class ButtonHelper
    {
        public static Button CreateNumberButton(string text)
        {
            return CreateButton(text, Color.Black, Color.LightGray);
        }

        public static Button CreateOperatorButton(string text)
        {
            return CreateButton(text, Color.White, Color.Blue);
        }

        private static Button CreateButton(string text, Color textColour, Color backgroundColour)
        {
            return new Button
            {
                Text = text,
                BackgroundColor = backgroundColour,
                TextColor = textColour,
                FontSize = 12,
                CornerRadius = 0,
            };
        }
    }
}
