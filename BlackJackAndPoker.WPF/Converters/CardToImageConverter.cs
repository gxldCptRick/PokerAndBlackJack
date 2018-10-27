using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BlackJackAndPoker.WPF.Converters
{
    public class CardToImageConverter : IValueConverter
    {
        private static IDictionary<Card, ImageSource> _cardImages;
        static CardToImageConverter()
        {
            _cardImages = new Dictionary<Card, ImageSource>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource source = null;
            if (value is Card card)
            {
                if (!_cardImages.ContainsKey(card))
                {
                    var cRank = (int)card.Rank;
                    var cSuit = card.Suit.ToString() + "s";
                    var faceSource = $"../../Assets/Cards/{cSuit}/{cRank}.png";
                    var image = new ImageSourceConverter().ConvertFromString(faceSource) as ImageSource;
                    _cardImages[card] = image;
                }
                source = _cardImages[card];
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
