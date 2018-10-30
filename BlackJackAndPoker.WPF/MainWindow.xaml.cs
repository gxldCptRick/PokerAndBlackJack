using BlackJackAndPoker.WPF.Views;
using BlackJackAndPoker.WPF.Views.Enums;
using BlackJackAndPoker.WPF.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BlackJackAndPoker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _pagesNavigated = new Dictionary<Type, Page>();
            ChangePage(PageRequest.PokerTable);
        }

        private IDictionary<Type, Page> _pagesNavigated;

        private Page GeneratePage<T>() where T : Page, new()
        {
            if (!(_pagesNavigated.ContainsKey(typeof(T))))
            {
                T page = new T()
                {
                    DataContext = DataContext,
                };
                if (page is IPageNavigator pageNav)
                {
                    pageNav.PageChangeRequested += ChangePage;
                }
                _pagesNavigated[typeof(T)] = page;
            }

            return _pagesNavigated[typeof(T)];
        }

        private void ChangePage(PageRequest pageRequested)
        {
            Page pageToChangeTo = null;
            switch (pageRequested)
            {
                case PageRequest.MainPage:
                    pageToChangeTo = GeneratePage<MainPage>();
                    break;
                case PageRequest.SettingsPage:
                    pageToChangeTo = GeneratePage<SettingsPage>();
                    break;
                case PageRequest.GamePage:
                    pageToChangeTo = GeneratePage<GamePage>();
                    break;
                case PageRequest.BlackJackTable:
                    pageToChangeTo = GeneratePage<BlackJackTable>();
                    break;
                case PageRequest.PokerTable:
                    pageToChangeTo = GeneratePage<PokerTable>();
                    break;
                default:
                    throw new ArgumentException("The page you requested was not supported.",nameof(pageRequested));
            }
            mainFrame.Navigate(pageToChangeTo);
        }
    }
}
