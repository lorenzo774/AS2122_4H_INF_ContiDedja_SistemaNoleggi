using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Noleggio_Library;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Prima pagina
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SistemaNoleggi sistemaNoleggi;

        public MainPage()
        {
            this.InitializeComponent();

            sistemaNoleggi = new SistemaNoleggi();
            sistemaNoleggi.AggiungiAutomobile("al;kf", "nope", 23, 22, 4);
            sistemaNoleggi.AggiungiCliente("lollo", "conti", "a;lksdjf");
            sistemaNoleggi.AggiungiNoleggio("al;kf", "a;lksdjf", 1, DateTime.Now);
            sistemaNoleggi.AggiungiNoleggio("al;kf", "a;lksdjf", 1, DateTime.Now);
        }

        #region MenuBar buttons

        private void OnClienteMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddClientePage));
        }

        private void OnAutomobileMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAutomobilePage), sistemaNoleggi);
        }

        #endregion

        #region SplitView buttons

        private void OnSplitViewBtn_Click(object sender, RoutedEventArgs e)
        {
            splViewItems.IsPaneOpen = !splViewItems.IsPaneOpen;

        }

        private void OnSplitViewClienti_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = sistemaNoleggi.Clienti;
        }

        private void OnSplitViewVeicoli_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = sistemaNoleggi.Veicoli;
        }

        private void OnSplitViewNoleggi_Click(object sender, RoutedEventArgs e)
        {
            grdView.ItemsSource = sistemaNoleggi.Noleggi;
        }
        #endregion

    }
}
