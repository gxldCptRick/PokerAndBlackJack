using BlackJackAndPoker.WPF.Views.Enums;
using BlackJackAndPoker.WPF.Views.Interfaces;
using System;
using System.Collections.Generic;
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

namespace BlackJackAndPoker.WPF.Views
{
    public partial class PokerTable : Page, IPageNavigator
    {
        public PokerTable()
        {
            InitializeComponent();
        }

        public event Action<PageRequest> PageChangeRequested;

        private void Bet_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User bets 1");
        }

        private void Bet_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User bets 5");
        }

        private void Bet_10(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User bets 10");
        }

        private void Call(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User calls");
        }

        private void Fold(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User folds");
        }

        private void Raise(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User raises");
        }
    }
}
