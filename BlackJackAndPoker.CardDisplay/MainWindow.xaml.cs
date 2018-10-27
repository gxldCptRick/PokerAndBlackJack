using BlackJackAndPoker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJackAndPoker.CardDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Deck d = new Deck();
        public IEnumerable<string> backgrounds = new List<string>() { "Blue", "Faded", "Gradient", "TyeDye" };

        public MainWindow()
        {
            InitializeComponent();
            d.ShuffleCards();
            activeDeck.ItemsSource = d.Cards;
            activeDeck.SelectedIndex = 0;
            deckBackground.ItemsSource = backgrounds;
            deckBackground.SelectedIndex = 0;
        }

        private void UpdateCard(object sender, SelectionChangedEventArgs e)
        {
            Card c = (Card)activeDeck.SelectedItem;
            var cRank = (int)c.Rank;
            var cSuit = c.Suit.ToString() + "s";
            var faceSource = $"../../Assets/Cards/{cSuit}/{cRank}.png";

            var selectedBack = deckBackground.SelectedItem;
            if (selectedBack == null)
            {
                selectedBack = "Blue";
            }

            var backgroundSource = $"../../Assets/Cards/Back/{selectedBack}.png";

            displayedCard.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(faceSource);
            displayedCardBack.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(backgroundSource);
        }
    }
}
