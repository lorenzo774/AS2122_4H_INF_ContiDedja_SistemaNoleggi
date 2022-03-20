using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using SistemaNoleggi_UWP.Client;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;

namespace SistemaNoleggi_UWP
{
    /// <summary>Pagina che mostra la lista delle automobili e dei furgoni del sistema</summary>
    public sealed partial class VeicoliPage : Page
    {
        public VeicoliPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(SistemaNoleggi.Instance.Automobili);
            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(SistemaNoleggi.Instance.Furgoni);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(await SistemaNoleggiClient.Instance.GetAllAutomobiliAsync());
                listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(await SistemaNoleggiClient.Instance.GetAllFurgoniAsync());
            }
        }

        private async void removeAutomobile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava l'automobile (Veicolo) presente nell'elemento grafico

            SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                await SistemaNoleggiClient.Instance.RemoveAutomobileAsync(veicolo.Id);
            }

            listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(SistemaNoleggi.Instance.Automobili);
        }

        private async void removeFurgone_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava il furgone (Veicolo) presente nell'elemento grafico

            SistemaNoleggi.Instance.RimuoviVeicolo(veicolo);

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                await SistemaNoleggiClient.Instance.RemoveFurgoneAsync(veicolo.Id);
            }

            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(SistemaNoleggi.Instance.Furgoni);
        }
    }
}