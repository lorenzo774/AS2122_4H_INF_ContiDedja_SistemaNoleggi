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
            grdView.ItemsSource = SistemaNoleggi.Instance.Noleggi;
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

        #region SplitView buttons

        private void OnSplitViewBtn_Click(object sender, RoutedEventArgs e)
        {
            splViewItems.IsPaneOpen = !splViewItems.IsPaneOpen;
        }

        private void OnSplitViewClienti_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = SistemaNoleggi.Instance.Clienti;
        }

        private void OnSplitViewVeicoli_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = SistemaNoleggi.Instance.Veicoli;
        }

        private void OnSplitViewNoleggi_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = SistemaNoleggi.Instance.Noleggi;
        }
        #endregion

    }
}
