using Windows.UI.Xaml.Controls;
using Noleggio_Library;
using SistemaNoleggi_UWP.Client;
using System.Collections.ObjectModel;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Pagina che mostra la lista delle automobili e dei furgoni del sistema
    /// </summary>
    public sealed partial class VeicoliPage : Page
    {
        public VeicoliPage()
        {
            this.InitializeComponent();
        }

        private async void removeAutomobile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava l'automobile (Veicolo) presente nell'elemento grafico

            await SistemaNoleggiClient.Instance.RemoveAutomobileAsync(veicolo.Id);
            
            listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(await SistemaNoleggiClient.Instance.GetAllAutomobiliAsync());
        }

        private async void removeFurgone_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var veicolo = (sender as Button).DataContext as Veicolo; // Ricava il furgone (Veicolo) presente nell'elemento grafico

            await SistemaNoleggiClient.Instance.RemoveFurgoneAsync(veicolo.Id);

            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(await SistemaNoleggiClient.Instance.GetAllFurgoniAsync());
        }

        private async void VeicoliPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var furgoni = SistemaNoleggi.Instance.Furgoni;
            var automobili = SistemaNoleggi.Instance.Automobili;

            if (SistemaNoleggi.Instance.IsDatabaseSynchronized)
            {
                automobili = await SistemaNoleggiClient.Instance.GetAllAutomobiliAsync();
                furgoni = await SistemaNoleggiClient.Instance.GetAllFurgoniAsync();
            }

            listViewAutomobili.ItemsSource = new ObservableCollection<Automobile>(automobili);
            listViewFurgoni.ItemsSource = new ObservableCollection<Furgone>(furgoni);
        }
    }
}