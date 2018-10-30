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
using BlackJackAndPoker.WPF.Views.Enums;
using BlackJackAndPoker.WPF.Views.Interfaces;

namespace BlackJackAndPoker.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, IPageNavigator
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public event Action<PageRequest> PageChangeRequested;

        private void ExitButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void gOTsHOT(object sender, RoutedEventArgs e)
        {
            PageChangeRequested?.Invoke(PageRequest.SettingsPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageChangeRequested?.Invoke(PageRequest.Halp);
        }
    }
}
