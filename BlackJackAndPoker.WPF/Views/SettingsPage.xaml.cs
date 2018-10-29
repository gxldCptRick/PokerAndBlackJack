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
using BlackJackAndPoker.WPF.ViewModels;
using BlackJackAndPoker.WPF.Views.Enums;
using BlackJackAndPoker.WPF.Views.Interfaces;

namespace BlackJackAndPoker.WPF.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page, IPageNavigator
    {
        public SettingsPage()
        {
            InitializeComponent();
            
        }

        public event Action<PageRequest> PageChangeRequested;

        private void AmountOfPlayers_Loaded(object sender, RoutedEventArgs e)
        {
            this.AmountOfPlayers.ItemsSource = Enumerable.Range(1, 5);
            this.AmountOfPlayers.SelectedItem = 1;
        }

        private void BlackJacksonButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainData data)
            {
                data.GameData = new BlackJackData();
            }
            PageChangeRequested?.Invoke(PageRequest.GamePage);
        }

        private void PakerButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainData data)
            {
                data.GameData = new PokerData();
            }
            PageChangeRequested?.Invoke(PageRequest.GamePage);
        }
    }
}
