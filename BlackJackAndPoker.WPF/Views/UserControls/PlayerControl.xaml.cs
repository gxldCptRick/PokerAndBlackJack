using BlackJackAndPoker.Models;
using BlackJackAndPoker.WPF.Converters;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace BlackJackAndPoker.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private static IValueConverter converterCardToImage;
        private static IValueConverter converterCardToBacking;
        public PlayerControl()
        {
            InitializeComponent();
            converterCardToImage = TryFindResource("cToI") as CardToImageConverter;
            converterCardToBacking = TryFindResource("cToB") as CardToBackConverter;
        }

        private void CardDisplay_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Image cardImage)
            {
                if (cardImage.DataContext is Card sourceCard)
                {
                    cardImage.Source = converterCardToImage.Convert(sourceCard, typeof(ImageSource), null,  CultureInfo.CurrentCulture) as ImageSource;
                }
            }
        }

        private void CardDisplay_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Image cardImage)
            {
                if (cardImage.DataContext is Card sourceCard)
                {
                    cardImage.Source = converterCardToBacking.Convert(sourceCard, typeof(ImageSource), null, CultureInfo.CurrentCulture) as ImageSource;
                }
            }
        }
    }
}
