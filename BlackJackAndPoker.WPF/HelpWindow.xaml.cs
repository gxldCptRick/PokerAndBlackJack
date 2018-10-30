using BlackJackAndPoker.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace BlackJackAndPoker.WPF
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void PokerClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is HalpData data)
            {
                data.GameTitle = "Poker";
                coolThing.Navigate($"{Directory.GetCurrentDirectory()}\\assets\\poker.html");
            }
        }

        private void BlackJackClicked(object sender, RoutedEventArgs e)
        {
            if (DataContext is HalpData data)
            {
                data.GameTitle = "Black Jack";
                coolThing.Navigate($"{Directory.GetCurrentDirectory()}\\assets\\blackjack.html");
            }
        }
    }
}
