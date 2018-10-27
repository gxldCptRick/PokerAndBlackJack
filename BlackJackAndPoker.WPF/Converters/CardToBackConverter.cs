using BlackJackAndPoker.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BlackJackAndPoker.WPF.Converters
{
    internal class CardToBackConverter : IValueConverter
    {
        private static ImageSource DontWorryAboutIt;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Card card && DontWorryAboutIt is null)
            {
                var backgroundSource = "../../Assets/Cards/Back/Faded.png";
                DontWorryAboutIt = new ImageSourceConverter().ConvertFromString(backgroundSource) as ImageSource;
            }

            return DontWorryAboutIt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
