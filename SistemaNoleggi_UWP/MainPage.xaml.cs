using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Prima pagina
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region MenuBar buttons

        private void OnClienteMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddClientePage));
        }

        private void OnAutomobileMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAutomobilePage));
        }

        #endregion

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            //ContentFrame.Navigate(typeof(NoleggiPage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "noleggi":
                        ContentFrame.Navigate(typeof(NoleggiPage));
                        break;
                    case "clienti":
                        ContentFrame.Navigate(typeof(ClientiPage));
                        break;
                    case "veicoli":
                        ContentFrame.Navigate(typeof(VeicoliPage));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
